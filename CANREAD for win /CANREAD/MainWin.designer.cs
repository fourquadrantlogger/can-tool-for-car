namespace CsharpUSBCan
{
    partial class MainWin
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.图表 = new System.Windows.Forms.Button();
            this.连接 = new System.Windows.Forms.Button();
            this.button关闭 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 图表
            // 
            this.图表.Location = new System.Drawing.Point(258, 2);
            this.图表.Name = "图表";
            this.图表.Size = new System.Drawing.Size(122, 52);
            this.图表.TabIndex = 8;
            this.图表.Text = "图表";
            this.图表.UseVisualStyleBackColor = true;
            this.图表.Click += new System.EventHandler(this.表格ToolStripMenuItem_Click);
            // 
            // 连接
            // 
            this.连接.Location = new System.Drawing.Point(2, 2);
            this.连接.Name = "连接";
            this.连接.Size = new System.Drawing.Size(122, 52);
            this.连接.TabIndex = 9;
            this.连接.Text = "连接";
            this.连接.UseVisualStyleBackColor = true;
            this.连接.Click += new System.EventHandler(this.连接ToolStripMenuItem_Click);
            // 
            // button关闭
            // 
            this.button关闭.Location = new System.Drawing.Point(130, 2);
            this.button关闭.Name = "button关闭";
            this.button关闭.Size = new System.Drawing.Size(122, 52);
            this.button关闭.TabIndex = 11;
            this.button关闭.Text = "关闭";
            this.button关闭.UseVisualStyleBackColor = true;
            this.button关闭.Click += new System.EventHandler(this.button关闭_Click);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(879, 605);
            this.Controls.Add(this.button关闭);
            this.Controls.Add(this.连接);
            this.Controls.Add(this.图表);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainWin";
            this.Text = "汽车can控制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 图表;
        private System.Windows.Forms.Button 连接;
        private System.Windows.Forms.Button button关闭;

    }
}

