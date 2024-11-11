using System.Windows.Forms;

namespace AIComposer
{
    partial class HotkeyInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyInputForm));
            this.windowBar = new AntdUI.WindowBar();
            this.inputHotkey = new AntdUI.Input();
            this.buttonOk = new AntdUI.Button();
            this.buttonCancel = new AntdUI.Button();
            this.SuspendLayout();
            // 
            // windowBar
            // 
            this.windowBar.DividerMargin = 10;
            this.windowBar.DividerShow = true;
            this.windowBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowBar.ForeColor = System.Drawing.Color.Chocolate;
            this.windowBar.IconSvg = resources.GetString("windowBar.IconSvg");
            this.windowBar.IsMax = false;
            this.windowBar.Location = new System.Drawing.Point(0, 0);
            this.windowBar.Name = "windowBar";
            this.windowBar.Size = new System.Drawing.Size(327, 39);
            this.windowBar.SubText = "";
            this.windowBar.TabIndex = 9;
            this.windowBar.Text = "热键配置";
            // 
            // inputHotkey
            // 
            this.inputHotkey.BorderWidth = 2F;
            this.inputHotkey.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputHotkey.IconGap = 0.5F;
            this.inputHotkey.IconRatio = 1F;
            this.inputHotkey.Location = new System.Drawing.Point(37, 64);
            this.inputHotkey.Name = "inputHotkey";
            this.inputHotkey.PlaceholderText = "请按下按键";
            this.inputHotkey.PrefixSvg = resources.GetString("inputHotkey.PrefixSvg");
            this.inputHotkey.ReadOnly = true;
            this.inputHotkey.Size = new System.Drawing.Size(253, 41);
            this.inputHotkey.TabIndex = 10;
            this.inputHotkey.WaveSize = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(245)))), ((int)(((byte)(160)))));
            this.buttonOk.BackExtend = "45, #85c1e9,#d5f5e3 ";
            this.buttonOk.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(129)))));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonOk.IconSvg = resources.GetString("buttonOk.IconSvg");
            this.buttonOk.Location = new System.Drawing.Point(204, 124);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(84, 38);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "确认";
            this.buttonOk.Type = AntdUI.TTypeMini.Primary;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(147)))), ((int)(((byte)(171)))));
            this.buttonCancel.BackExtend = "135, #8693AB, #BDD4E7";
            this.buttonCancel.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.IconSvg = resources.GetString("buttonCancel.IconSvg");
            this.buttonCancel.Location = new System.Drawing.Point(120, 124);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(78, 38);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Type = AntdUI.TTypeMini.Primary;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // HotkeyInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 178);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.inputHotkey);
            this.Controls.Add(this.windowBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeyInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置热键";
            this.Load += new System.EventHandler(this.HotkeyInputForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.WindowBar windowBar;
        private AntdUI.Input inputHotkey;
        private AntdUI.Button buttonOk;
        private AntdUI.Button buttonCancel;
    }
}