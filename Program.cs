using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using AIComposer.AISupport;

namespace AIComposer
{
    public static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;
        private const int SW_SHOW = 5;

        public static SystemSetting Setting { get; set; }

        public static List<AIBase> AIList { get; set; } = new List<AIBase>(){
            new TongYiAI(),
            new KimiAI(),
            new DouBaoAI(),
            new ChatGpt(),
            new ChatGLM(),
            new PoeAI(),
            new TiangongAI(),
            //new XunFeiAI(),
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(true, "Global\\MyUniqueAppName", out bool createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("程序已在运行中！");
                    return;
                }

                Application.Run(new AIComposer());
            }
        }
    }
}
