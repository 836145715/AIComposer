using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIComposer
{
    public partial class AIInputForm : AntdUI.Window
    {
        public AIInputForm()
        {
            InitializeComponent();
            CenterToScreen();
            TopMost = true; 
        }

        public string Content => inputContent.Text;
        private async void AIInputControl_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            inputContent.Focus();
        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            if (keyData == (Keys.Control | Keys.Enter))
            {
                DialogResult = DialogResult.OK;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
