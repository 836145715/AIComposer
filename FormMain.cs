using AntdUI;
using HuExtend;
using Microsoft.Playwright;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIComposer
{
    public partial class AIComposer : AntdUI.Window
    {

        public static string SettingFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIComposerSetting.json");
        private void LoadSetting()
        {
            try
            {
                Program.Setting = SettingFilePath.FromJsonConfig<SystemSetting>();
            }
            catch (System.Exception)
            {
                Program.Setting = null;
            }

            if (Program.Setting == null)
            {
                Program.Setting = new SystemSetting()
                {
                    ShowHotkey = new HotkeySetting()
                    {
                        Modifiers = KeyModifiers.Alt,
                        Key = Keys.D1
                    },
                    AskHotkey = new HotkeySetting()
                    {
                        Modifiers = KeyModifiers.Alt,
                        Key = Keys.D2
                    }
                };
            }

        }

        private void SaveSetting()
        {
            Program.Setting.ToJsonConfig(SettingFilePath);
        }

        public AIComposer()
        {
            InitializeComponent();
            //设置窗口类名
            this.Name = "AIComposer";
            CenterToScreen();
        }


        private const int _top = 60;
        private const int _bottom = 20;
        private const int _left = 10;
        private const int _right = 0;

        private List<string> _urls = new List<string>(){
            "https://tongyi.aliyun.com/qianwen",
            "https://kimi.moonshot.cn/",
            "https://www.doubao.com/chat/"
        };

        private List<WebView2> _webViews = new List<WebView2>();

        //根据url列表，初始化webview2
        private async Task InitializeWebViewList()
        {
            foreach (var url in _urls)
            {
                var webView = new WebView2();
                webView.CoreWebView2InitializationCompleted += WebViewInitializeCompleted;
                await InitializeWebView(webView);
                webView.Source = new Uri(url);
                _webViews.Add(webView);
            }

            for (int i = 0; i < _webViews.Count; i++)
            {
                this.Controls.Add(_webViews[i]);
            }
        }


        private async Task InitializeWebView(WebView2 webView)
        {
            // 指定缓存路径，这里以LocalApplicationData目录为例
            string userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIComposerCache");

            // 确保目录存在
            Directory.CreateDirectory(userDataFolder);

            // 创建CoreWebView2Environment实例，并指定缓存目录
            var environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, new CoreWebView2EnvironmentOptions()
            {
                AdditionalBrowserArguments = "--remote-debugging-port=10083",
            });

            // 确保WebView2控件使用指定的环境
            await webView.EnsureCoreWebView2Async(environment);
        }


        public class GlobalHotkey
        {
            // 导入Windows API函数
            [DllImport("user32.dll")]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

            [DllImport("user32.dll")]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            // 定义修饰键
            public const uint MOD_ALT = 0x0001;
            public const uint MOD_CONTROL = 0x0002;
            public const uint MOD_SHIFT = 0x0004;
            public const uint MOD_WIN = 0x0008;
        }

        private const int KEY_SHOW = 1;
        private const int KEY_QUESTION = 2;

        private async void FormMain_Load(object sender, EventArgs e)
        {
            AntdUI.Config.ShowInWindow = true;
            LoadSetting();
            RefreshSetting();

            await InitializeWebViewList();
            //当前屏幕宽度的80%和高度的80%  
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Size = new Size((int)(screenWidth * 0.8), (int)(screenHeight * 0.8));
            //FormMain_Resize(this, null);
            //自己居中显示窗口
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);
        }

        // 监听窗口消息
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == KEY_SHOW)
            {
                //显示或者隐藏
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                }
            }

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == KEY_QUESTION)
            {
                OnQuestion().ConfigureAwait(false);
            }
            base.WndProc(ref m);
        }


        private AIInputForm _inputForm = null;


        private async Task OnQuestion()
        {
            if (_inputForm == null || _inputForm.IsDisposed)
            {
                _inputForm = new AIInputForm();
                var dlgRes = _inputForm.ShowDialog();

                if (dlgRes == DialogResult.OK)
                {
                    // 检查窗体是否是最小化状态
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        // 将窗体恢复到正常状态
                        this.WindowState = FormWindowState.Normal;
                    }

                    // 将窗体显示到前台
                    this.Show();

                    // 激活窗体，使其成为活动窗口
                    this.Activate();
                    await AskQuestion(_inputForm.Content);
                }
                _inputForm.Dispose();
            }
            else
            {
                _inputForm.Activate();
            }

        }


        private async Task AskQuestion(string content)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.ConnectOverCDPAsync("http://localhost:10083");
            var context = browser.Contexts[0];

            foreach (var page in context.Pages)
            {
                var defaultTimeout = 1000;
                var defaultClickOptions = new LocatorClickOptions()
                {
                    Timeout = defaultTimeout
                };
                var defaultFillOptions = new LocatorFillOptions()
                {
                    Timeout = defaultTimeout
                };

                try
                {
                    if (page.Url.Contains("qianwen"))
                    {
                        await page.GetByPlaceholder("“/”唤起指令中心，Shift+Enter").ClickAsync(defaultClickOptions);
                        await page.GetByPlaceholder("“/”唤起指令中心，Shift+Enter").FillAsync(content, defaultFillOptions);
                        await page.Locator("[class*=operateBtn]").ClickAsync(defaultClickOptions);
                    }

                    if (page.Url.Contains("kimi"))
                    {
                        await page.GetByTestId("msh-chatinput-editor").ClickAsync(defaultClickOptions);
                        await page.GetByTestId("msh-chatinput-editor").FillAsync(content, defaultFillOptions);
                        await page.GetByTestId("msh-chatinput-send-button").ClickAsync(defaultClickOptions);
                    }

                    if (page.Url.Contains("doubao"))
                    {
                        await page.GetByTestId("chat_input_input").ClickAsync(defaultClickOptions);
                        await page.GetByTestId("chat_input_input").FillAsync(content, defaultFillOptions);
                        await page.GetByTestId("chat_input_send_button").ClickAsync(defaultClickOptions);
                    }
                }
                catch
                {
                    AntdUI.Notification.error(this, "错误","提问失败，请调整窗口布局：" + page.Url,TAlignFrom.Top);
                }
            }
        }


        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (_webViews.Count <= 0)
                return;
            Console.WriteLine("FormMain_Resize：" + this.Width + " " + this.Height);
            var realHeight = this.Height - _top - _bottom;
            int webViewWidth = this.Width / _webViews.Count - _left - _right;
            for (int i = 0; i < _webViews.Count; i++)
            {
                _webViews[i].Size = new Size(webViewWidth, realHeight);
                _webViews[i].Left = _left + webViewWidth * i;
                _webViews[i].Top = _top;
            }
        }

        private void WebViewInitializeCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                Console.WriteLine("WebView2 initialized");
            }
        }


        private bool _isNotify = false;

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GlobalHotkey.UnregisterHotKey(this.Handle, KEY_SHOW);
            //GlobalHotkey.UnregisterHotKey(this.Handle, KEY_QUESTION);
            if (_isNotify == false)
            {
                notifyIcon.ShowBalloonTip(3000, "AI创作者", "我会在小托盘常驻，可以在小托盘图标右键退出哦！", ToolTipIcon.Info);
                _isNotify = true;
            }

            e.Cancel = true;
            Hide();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            // 清理托盘图标资源
            notifyIcon.Visible = false;
            // 关闭应用
            Environment.Exit(0);
        }

        private async void buttonAsk_Click(object sender, EventArgs e)
        {
            await OnQuestion();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            //注销热键
            GlobalHotkey.UnregisterHotKey(this.Handle, KEY_SHOW);
            GlobalHotkey.UnregisterHotKey(this.Handle, KEY_QUESTION);
            var form = new SystemSettingForm();
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                SaveSetting();
            }
            RefreshSetting();
            form.Dispose();
            //删除焦点
            this.ActiveControl = null;
        }

        private void RefreshSetting()
        {

            var sb = new StringBuilder();

            var setting = Program.Setting;
            if (setting.ShowHotkey != null)
            {
                bool registered = GlobalHotkey.RegisterHotKey(this.Handle, KEY_SHOW, (uint)setting.ShowHotkey.Modifiers, (uint)setting.ShowHotkey.Key);
                if (!registered)
                {
                    AntdUI.Message.error(this, "显示热键注册失败：" + setting.ShowHotkey, autoClose: 3);
                }
                else
                {
                    AntdUI.Message.success(this, "显示热键注册成功：" + setting.ShowHotkey, autoClose: 3);
                    sb.Append("显示:" + setting.ShowHotkey).Append(" ");
                }
            }

            if (setting.AskHotkey != null)
            {
                bool registered = GlobalHotkey.RegisterHotKey(this.Handle, KEY_QUESTION, (uint)setting.AskHotkey.Modifiers, (uint)setting.AskHotkey.Key);
                if (!registered)
                {
                    AntdUI.Message.error(this, "提问热键注册失败：" + setting.AskHotkey, autoClose: 3);
                }
                else
                {
                    AntdUI.Message.success(this, "提问热键注册成功：" + setting.AskHotkey, autoClose: 3);
                    sb.Append("提问:" + setting.AskHotkey);
                }
            }

            sb.Append(" QQ交流群：654387244 持续更新");

            windowBar.SubText = sb.ToString();
        }


    }
}
