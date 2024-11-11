using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIComposer
{
    public partial class SystemSettingForm : AntdUI.Window
    {
        // public SystemSetting Setting
        // {
        //     get => FormMain.Setting;
        //     set => FormMain.Setting = value;
        // }
        public SystemSettingForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void SystemSettingForm_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void LoadSetting()
        {
            var setting = Program.Setting;
            if (setting.ShowHotkey != null)
            {
                buttonShowHotKey.Text = "显示窗口热键：" + setting.ShowHotkey.ToString();
            }
            else
            {
                buttonShowHotKey.Text = "显示窗口热键：未注册";
            }
            if (setting.AskHotkey != null)
            {
                buttonAskHotKey.Text = "发起提问热键：" + setting.AskHotkey.ToString();
            }
            else
            {
                buttonAskHotKey.Text = "发起提问热键：未注册";
            }
        }


        private void InitAiSelect()
        {

        }

        private void buttonShowHotKey_Click(object sender, EventArgs e)
        {
            using (var dialog = new HotkeyInputForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.Setting.ShowHotkey = dialog.Hotkey;
                }
            }
            LoadSetting();
        }

        private void buttonAskHotKey_Click(object sender, EventArgs e)
        {
            using (var dialog = new HotkeyInputForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.Setting.AskHotkey = dialog.Hotkey;
                }
            }
            LoadSetting();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                buttonOk_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Escape))
            {
                buttonCancel_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
