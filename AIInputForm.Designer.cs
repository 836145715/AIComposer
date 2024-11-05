namespace AIComposer
{
    partial class AIInputForm
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIInputForm));
            this.inputContent = new AntdUI.Input();
            this.buttonAsk = new AntdUI.Button();
            this.buttonCancel = new AntdUI.Button();
            this.windowBar = new AntdUI.WindowBar();
            this.SuspendLayout();
            // 
            // inputContent
            // 
            this.inputContent.AutoScroll = true;
            this.inputContent.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputContent.Location = new System.Drawing.Point(12, 58);
            this.inputContent.Multiline = true;
            this.inputContent.Name = "inputContent";
            this.inputContent.PlaceholderText = "请输入你要问的问题";
            this.inputContent.Size = new System.Drawing.Size(479, 320);
            this.inputContent.TabIndex = 3;
            this.inputContent.WaveSize = 0;
            // 
            // buttonAsk
            // 
            this.buttonAsk.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAsk.Location = new System.Drawing.Point(344, 386);
            this.buttonAsk.Name = "buttonAsk";
            this.buttonAsk.Size = new System.Drawing.Size(147, 32);
            this.buttonAsk.TabIndex = 6;
            this.buttonAsk.Text = "发起提问(Ctrl + Enter)";
            this.buttonAsk.Type = AntdUI.TTypeMini.Info;
            this.buttonAsk.WaveSize = 0;
            this.buttonAsk.Click += new System.EventHandler(this.buttonAsk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.Location = new System.Drawing.Point(249, 386);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 32);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "取消(Esc)";
            this.buttonCancel.WaveSize = 0;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // windowBar
            // 
            this.windowBar.DividerMargin = 10;
            this.windowBar.DividerShow = true;
            this.windowBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowBar.ForeColor = System.Drawing.Color.Chocolate;
            this.windowBar.Icon = ((System.Drawing.Image)(resources.GetObject("windowBar.Icon")));
            this.windowBar.IconSvg = resources.GetString("windowBar.IconSvg");
            this.windowBar.IsMax = false;
            this.windowBar.Location = new System.Drawing.Point(0, 0);
            this.windowBar.Name = "windowBar";
            this.windowBar.Size = new System.Drawing.Size(506, 46);
            this.windowBar.SubText = "";
            this.windowBar.TabIndex = 8;
            this.windowBar.Text = "发起提问";
            // 
            // AIInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 428);
            this.Controls.Add(this.windowBar);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAsk);
            this.Controls.Add(this.inputContent);
            this.Name = "AIInputForm";
            this.Load += new System.EventHandler(this.AIInputControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Input inputContent;
        private AntdUI.Button buttonAsk;
        private AntdUI.Button buttonCancel;
        private AntdUI.WindowBar windowBar;
    }
}
