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
            this.tabPage2 = new AntdUI.TabPage();
            this.inputProxy = new AntdUI.Input();
            this.tableAI = new AntdUI.Table();
            this.buttonAddAi = new AntdUI.Button();
            this.selectAi = new AntdUI.Select();
            this.tabPage1 = new AntdUI.TabPage();
            this.buttonAskHotKey = new AntdUI.Button();
            this.buttonShowHotKey = new AntdUI.Button();
            this.buttonOk = new AntdUI.Button();
            this.buttonCancel = new AntdUI.Button();
            this.tabs.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.titlebar.Size = new System.Drawing.Size(809, 40);
            this.titlebar.SubText = "";
            this.titlebar.TabIndex = 1;
            this.titlebar.Text = "系统设置";
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabs.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabs.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.tabs.Gap = 12;
            this.tabs.Location = new System.Drawing.Point(9, 49);
            this.tabs.Margin = new System.Windows.Forms.Padding(6);
            this.tabs.Name = "tabs";
            this.tabs.Pages.Add(this.tabPage2);
            this.tabs.Pages.Add(this.tabPage1);
            this.tabs.Size = new System.Drawing.Size(785, 346);
            this.tabs.Style = styleLine1;
            this.tabs.TabIndex = 2;
            this.tabs.Text = "tabs1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.inputProxy);
            this.tabPage2.Controls.Add(this.tableAI);
            this.tabPage2.Controls.Add(this.buttonAddAi);
            this.tabPage2.Controls.Add(this.selectAi);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(90, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(689, 334);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "AI配置";
            // 
            // inputProxy
            // 
            this.inputProxy.AllowClear = true;
            this.inputProxy.Enabled = false;
            this.inputProxy.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputProxy.Location = new System.Drawing.Point(447, 3);
            this.inputProxy.Name = "inputProxy";
            this.inputProxy.PlaceholderText = "可选输入IP:端口";
            this.inputProxy.Size = new System.Drawing.Size(153, 32);
            this.inputProxy.TabIndex = 32;
            this.inputProxy.WaveSize = 0;
            // 
            // tableAI
            // 
            this.tableAI.EmptyHeader = true;
            this.tableAI.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableAI.Gap = 8;
            this.tableAI.Location = new System.Drawing.Point(17, 45);
            this.tableAI.Name = "tableAI";
            this.tableAI.ShowTip = false;
            this.tableAI.Size = new System.Drawing.Size(669, 270);
            this.tableAI.TabIndex = 31;
            this.tableAI.Text = "table1";
            // 
            // buttonAddAi
            // 
            this.buttonAddAi.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddAi.Location = new System.Drawing.Point(606, 1);
            this.buttonAddAi.Name = "buttonAddAi";
            this.buttonAddAi.Size = new System.Drawing.Size(80, 38);
            this.buttonAddAi.TabIndex = 5;
            this.buttonAddAi.Text = "添加";
            this.buttonAddAi.Type = AntdUI.TTypeMini.Primary;
            this.buttonAddAi.Click += new System.EventHandler(this.buttonAddAi_Click);
            // 
            // selectAi
            // 
            this.selectAi.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.selectAi.List = true;
            this.selectAi.Location = new System.Drawing.Point(17, 3);
            this.selectAi.Name = "selectAi";
            this.selectAi.PlaceholderText = "请选择要添加的AI";
            this.selectAi.Size = new System.Drawing.Size(424, 32);
            this.selectAi.TabIndex = 4;
            this.selectAi.WaveSize = 0;
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
            // buttonOk
            // 
            this.buttonOk.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(245)))), ((int)(((byte)(160)))));
            this.buttonOk.BackExtend = "45, #85c1e9,#d5f5e3 ";
            this.buttonOk.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(129)))));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonOk.IconSvg = resources.GetString("buttonOk.IconSvg");
            this.buttonOk.Location = new System.Drawing.Point(702, 404);
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
            this.buttonCancel.Location = new System.Drawing.Point(606, 404);
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
            this.ClientSize = new System.Drawing.Size(809, 452);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.titlebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemSettingForm";
            this.Text = "SystemSettingForm";
            this.Load += new System.EventHandler(this.SystemSettingForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private AntdUI.Select selectAi;
        private AntdUI.Button buttonAddAi;
        private AntdUI.Table tableAI;
        private AntdUI.Input inputProxy;
    }
}