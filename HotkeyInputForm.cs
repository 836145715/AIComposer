using System;
using System.Windows.Forms;

namespace AIComposer
{
    public partial class HotkeyInputForm : AntdUI.Window
    {
        public HotkeySetting Hotkey { get; private set; } = new HotkeySetting();

        public HotkeyInputForm()
        {
            InitializeComponent();
            Hotkey.Key = Keys.None;
            Hotkey.Modifiers = KeyModifiers.None;
            this.KeyDown += HotkeyInputForm_KeyDown;
            this.KeyUp += HotkeyInputForm_KeyUp;
        }

        private void HotkeyInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            // 忽略单独的修饰键
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey ||
                e.KeyCode == Keys.Menu || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                return;
            }

            KeyModifiers modifiers = KeyModifiers.None;
            if (e.Control) modifiers |= KeyModifiers.Control;
            if (e.Alt) modifiers |= KeyModifiers.Alt;
            if (e.Shift) modifiers |= KeyModifiers.Shift;
            if ((Control.ModifierKeys & Keys.LWin) == Keys.LWin) modifiers |= KeyModifiers.Win;

            Hotkey.Key = e.KeyCode;
            Hotkey.Modifiers = modifiers;
            inputHotkey.Text = Hotkey.ToString();
            buttonOk.Enabled = true;
        }

        private void HotkeyInputForm_KeyUp(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private string GetHotkeyDisplayString(KeyModifiers modifiers, Keys key)
        {
            var text = "";
            if ((modifiers & KeyModifiers.Control) != 0) text += "Ctrl + ";
            if ((modifiers & KeyModifiers.Alt) != 0) text += "Alt + ";
            if ((modifiers & KeyModifiers.Shift) != 0) text += "Shift + ";
            if ((modifiers & KeyModifiers.Win) != 0) text += "Win + ";

            if (modifiers == KeyModifiers.None)
            {
                text = key.ToString();
            }
            else
            {
                text += key.ToString();
            }
            return text;
        }

        private void HotkeyInputForm_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
