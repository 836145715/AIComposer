using AntdUI;
using HuExtend;
using Microsoft.Playwright;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using NewLife;
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
                Program.Setting = SettingFilePath.FromJsonConfig<SystemSetting>() ?? new SystemSetting();
            }
            catch (System.Exception)
            {
                Program.Setting = new SystemSetting();
            }

            var setting = Program.Setting;

            //默认热键
            if (setting.ShowHotkey == null)
            {
                setting.ShowHotkey = new HotkeySetting()
                {
                    Modifiers = KeyModifiers.Alt,
                    Key = Keys.D1
                };
            }
            if (setting.AskHotkey == null)
            {
                setting.AskHotkey = new HotkeySetting()
                {
                    Modifiers = KeyModifiers.Alt,
                    Key = Keys.D2
                };
            }

            //默认AI配置
            if (setting.AISettings == null || setting.AISettings.Count <= 0)
            {
                setting.AISettings = new List<AISetting>();
                foreach (var ai in Program.AIList)
                {
                    setting.AISettings.Add(new AISetting() { Key = ai.Key, Enabled = true });
                }
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



        private List<WebView2> _webViews = new List<WebView2>();

        //根据url列表，初始化webview2
        private async Task InitializeWebViewList()
        {
            //先关闭所有webview2
            foreach (var webView in _webViews)
            {
                this.Controls.Remove(webView);
                webView.Dispose();
            }
            _webViews.Clear();

            //输出窗口内所有控件
            foreach (Control control in this.Controls)
            {
                Console.WriteLine(control.Name);
            }

            foreach (var aiSetting in Program.Setting.AISettings)
            {
                if (aiSetting.Enabled == false)
                    continue;
                var ai = Program.AIList.FirstOrDefault(x => x.Key == aiSetting.Key);
                if (ai == null)
                {
                    continue;
                }
                var webView = new WebView2();
                webView.CoreWebView2InitializationCompleted += WebViewInitializeCompleted;
                await InitializeWebView(webView);
                webView.Source = new Uri(ai.Url);
                webView.Tag = ai;
                _webViews.Add(webView);
            }

            for (int i = 0; i < _webViews.Count; i++)
            {
                this.Controls.Add(_webViews[i]);
            }
        }


        private async Task InitializeWebView(WebView2 webView)
        {
            string userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIComposerCache");
            Directory.CreateDirectory(userDataFolder);

            // 创建CoreWebView2Environment实例，并指定缓存目录
            var environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, new CoreWebView2EnvironmentOptions()
            {
                AdditionalBrowserArguments = "--remote-debugging-port=10083",
            });

            // 确保WebView2控件使用指定的环境
            await webView.EnsureCoreWebView2Async(environment);
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
                    // 检查窗体是否是最小化状态
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        // 将窗体恢复到正常状态
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.Activate();
                    TopLevel = true;
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
                    TopLevel = true;
                    await AskQuestion(_inputForm.Content);
                }
                _inputForm.Dispose();
            }
            else
            {
                _inputForm.Close();
            }

        }


        private async Task AskQuestion(string content)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.ConnectOverCDPAsync("http://localhost:10083");
            var context = browser.Contexts[0];

            foreach (var page in context.Pages)
            {
                foreach (var ai in Program.AIList)
                {
                    if (page.Url.Contains(ai.Key))
                    {
                        var res = await ai.AskAsync(content, page);
                        if (res.code == 0)
                        {
                            AntdUI.Notification.error(this, "错误", $"向{ai.Name}提问失败，请调整窗口布局！", TAlignFrom.Top);
                        }
                        else
                        {
                            AntdUI.Message.success(this, $"提问成功：{ai.Name}");
                        }
                    }

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

        private async void buttonSetting_Click(object sender, EventArgs e)
        {
            //注销热键
            GlobalHotkey.UnregisterHotKey(this.Handle, KEY_SHOW);
            GlobalHotkey.UnregisterHotKey(this.Handle, KEY_QUESTION);
            var form = new SystemSettingForm();
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                SaveSetting();
                await InitializeWebViewList();
                FormMain_Resize(this, null);
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

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await InitializeWebViewList();
            FormMain_Resize(this,null);
        }
    }
}
