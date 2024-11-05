using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuExtend;

namespace AIComposer
{
    public class SystemSetting
    {

        public HotkeySetting ShowHotkey { get; set; }
        public HotkeySetting AskHotkey { get; set; }
    }

    public enum KeyModifiers
    {
        None = 0,
        Control = 0x0002,
        Alt = 0x0001,
        Shift = 0x0004,
        Win = 0x0008
    }

    public class HotkeySetting
    {
        public KeyModifiers Modifiers { get; set; }
        public Keys Key { get; set; }
        public override string ToString()
        {
            var text = "";
            if ((Modifiers & KeyModifiers.Control) != 0) text += "Ctrl + ";
            if ((Modifiers & KeyModifiers.Alt) != 0) text += "Alt + ";
            if ((Modifiers & KeyModifiers.Shift) != 0) text += "Shift + ";
            if ((Modifiers & KeyModifiers.Win) != 0) text += "Win + ";
            text += Key.ToString();
            return text;
        }
    }


}
