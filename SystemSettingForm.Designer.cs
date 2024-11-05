namespace AIComposer
{
    partial class SystemSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSettingForm));
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            this.titlebar = new AntdUI.WindowBar();
            this.tabs = new AntdUI.Tabs();
            this.tabPage1 = new AntdUI.TabPage();
            this.tabPage2 = new AntdUI.TabPage();
            this.buttonShowHotKey = new AntdUI.Button();
            this.buttonAskHotKey = new AntdUI.Button();
            this.buttonOk = new AntdUI.Button();
            this.buttonCancel = new AntdUI.Button();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlebar
            // 
            this.titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titlebar.IconSvg = resources.GetString("titlebar.IconSvg");
            this.titlebar.IsMax = false;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.MaximizeBox = false;
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(441, 40);
            this.titlebar.SubText = "";
            this.titlebar.TabIndex = 1;
            this.titlebar.Text = "系统设置";
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabs.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.tabs.Gap = 12;
            this.tabs.Location = new System.Drawing.Point(9, 49);
            this.tabs.Margin = new System.Windows.Forms.Padding(6);
            this.tabs.Name = "tabs";
            this.tabs.Pages.Add(this.tabPage2);
            this.tabs.Pages.Add(this.tabPage1);
            this.tabs.SelectedIndex = 1;
            this.tabs.Size = new System.Drawing.Size(421, 346);
            this.tabs.Style = styleLine1;
            this.tabs.TabIndex = 2;
            this.tabs.Text = "tabs1";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.buttonAskHotKey);
            this.tabPage1.Controls.Add(this.buttonShowHotKey);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.tabPage1.Location = new System.Drawing.Point(90, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(325, 334);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "热键配置";
            // 
            // tabPage2
            // 
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(90, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(502, 384);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "AI配置";
            // 
            // buttonShowHotKey
            // 
            this.buttonShowHotKey.BorderWidth = 2F;
            this.buttonShowHotKey.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonShowHotKey.Ghost = true;
            this.buttonShowHotKey.Location = new System.Drawing.Point(13, 15);
            this.buttonShowHotKey.Name = "buttonShowHotKey";
            this.buttonShowHotKey.Size = new System.Drawing.Size(187, 38);
            this.buttonShowHotKey.TabIndex = 4;
            this.buttonShowHotKey.Text = "显示窗口热键：未注册";
            this.buttonShowHotKey.Type = AntdUI.TTypeMini.Primary;
            this.buttonShowHotKey.Click += new System.EventHandler(this.buttonShowHotKey_Click);
            // 
            // buttonAskHotKey
            // 
            this.buttonAskHotKey.BorderWidth = 2F;
            this.buttonAskHotKey.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAskHotKey.Ghost = true;
            this.buttonAskHotKey.Location = new System.Drawing.Point(13, 59);
            this.buttonAskHotKey.Name = "buttonAskHotKey";
            this.buttonAskHotKey.Size = new System.Drawing.Size(187, 38);
            this.buttonAskHotKey.TabIndex = 5;
            this.buttonAskHotKey.Text = "发起提问热键：未注册";
            this.buttonAskHotKey.Type = AntdUI.TTypeMini.Primary;
            this.buttonAskHotKey.Click += new System.EventHandler(this.buttonAskHotKey_Click);
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
            this.buttonOk.Location = new System.Drawing.Point(340, 404);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(84, 38);
            this.buttonOk.TabIndex = 14;
            this.buttonOk.Text = "保存";
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
            this.buttonCancel.Location = new System.Drawing.Point(256, 404);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(78, 38);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Type = AntdUI.TTypeMini.Primary;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SystemSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 450);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.titlebar);
            this.Name = "SystemSettingForm";
            this.Text = "SystemSettingForm";
            this.Load += new System.EventHandler(this.SystemSettingForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.WindowBar titlebar;
        private AntdUI.Tabs tabs;
        private AntdUI.TabPage tabPage2;
        private AntdUI.TabPage tabPage1;
        private AntdUI.Button buttonAskHotKey;
        private AntdUI.Button buttonShowHotKey;
        private AntdUI.Button buttonOk;
        private AntdUI.Button buttonCancel;
    }
}