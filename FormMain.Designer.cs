namespace AIComposer
{
    partial class AIComposer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIComposer));
            this.windowBar = new AntdUI.WindowBar();
            this.buttonAsk = new AntdUI.Button();
            this.buttonSetting = new AntdUI.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRefresh = new AntdUI.Button();
            this.windowBar.SuspendLayout();
            this.contextMenuStripNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBar
            // 
            this.windowBar.Controls.Add(this.buttonRefresh);
            this.windowBar.Controls.Add(this.buttonAsk);
            this.windowBar.Controls.Add(this.buttonSetting);
            this.windowBar.DividerMargin = 10;
            this.windowBar.DividerShow = true;
            this.windowBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowBar.ForeColor = System.Drawing.Color.Chocolate;
            this.windowBar.Icon = ((System.Drawing.Image)(resources.GetObject("windowBar.Icon")));
            this.windowBar.IsMax = false;
            this.windowBar.Location = new System.Drawing.Point(0, 0);
            this.windowBar.Name = "windowBar";
            this.windowBar.Size = new System.Drawing.Size(1440, 46);
            this.windowBar.SubText = "";
            this.windowBar.TabIndex = 3;
            this.windowBar.Text = "AI创作者";
            // 
            // buttonAsk
            // 
            this.buttonAsk.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAsk.Ghost = true;
            this.buttonAsk.IconSvg = resources.GetString("buttonAsk.IconSvg");
            this.buttonAsk.Location = new System.Drawing.Point(1196, 0);
            this.buttonAsk.Name = "buttonAsk";
            this.buttonAsk.Radius = 0;
            this.buttonAsk.Size = new System.Drawing.Size(50, 46);
            this.buttonAsk.TabIndex = 2;
            this.buttonAsk.WaveSize = 0;
            this.buttonAsk.Click += new System.EventHandler(this.buttonAsk_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSetting.Ghost = true;
            this.buttonSetting.IconSvg = resources.GetString("buttonSetting.IconSvg");
            this.buttonSetting.Location = new System.Drawing.Point(1246, 0);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Radius = 0;
            this.buttonSetting.Size = new System.Drawing.Size(50, 46);
            this.buttonSetting.TabIndex = 1;
            this.buttonSetting.WaveSize = 0;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.contextMenuStripNotify.Name = "contextMenuStripNotify";
            this.contextMenuStripNotify.Size = new System.Drawing.Size(101, 26);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(100, 22);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRefresh.Ghost = true;
            this.buttonRefresh.IconRatio = 1F;
            this.buttonRefresh.IconSvg = resources.GetString("buttonRefresh.IconSvg");
            this.buttonRefresh.Location = new System.Drawing.Point(1146, 0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Radius = 0;
            this.buttonRefresh.Size = new System.Drawing.Size(50, 46);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.WaveSize = 0;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // AIComposer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 784);
            this.Controls.Add(this.windowBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AIComposer";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.windowBar.ResumeLayout(false);
            this.contextMenuStripNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.WindowBar windowBar;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private AntdUI.Button buttonSetting;
        private AntdUI.Button buttonAsk;
        private AntdUI.Button buttonRefresh;
    }
}

