namespace CsharpUSBCan
{
    partial class databox
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
            this.components = new System.ComponentModel.Container();
            this.data = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.texts = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Length,
            this.byte0,
            this.byte1,
            this.byte2,
            this.byte3,
            this.byte4,
            this.byte5,
            this.byte6,
            this.byte7});
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.Location = new System.Drawing.Point(0, 0);
            this.data.Name = "data";
            this.data.RowHeadersVisible = false;
            this.data.RowTemplate.Height = 23;
            this.data.Size = new System.Drawing.Size(385, 440);
            this.data.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Width = 40;
            // 
            // byte0
            // 
            this.byte0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.byte0.HeaderText = "0";
            this.byte0.Name = "byte0";
            this.byte0.ReadOnly = true;
            this.byte0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.byte0.Width = 30;
            // 
            // byte1
            // 
            this.byte1.HeaderText = "1";
            this.byte1.Name = "byte1";
            this.byte1.ReadOnly = true;
            this.byte1.Width = 30;
            // 
            // byte2
            // 
            this.byte2.HeaderText = "2";
            this.byte2.Name = "byte2";
            this.byte2.ReadOnly = true;
            this.byte2.Width = 30;
            // 
            // byte3
            // 
            this.byte3.HeaderText = "3";
            this.byte3.Name = "byte3";
            this.byte3.ReadOnly = true;
            this.byte3.Width = 30;
            // 
            // byte4
            // 
            this.byte4.HeaderText = "4";
            this.byte4.Name = "byte4";
            this.byte4.ReadOnly = true;
            this.byte4.Width = 30;
            // 
            // byte5
            // 
            this.byte5.HeaderText = "5";
            this.byte5.Name = "byte5";
            this.byte5.ReadOnly = true;
            this.byte5.Width = 30;
            // 
            // byte6
            // 
            this.byte6.HeaderText = "6";
            this.byte6.Name = "byte6";
            this.byte6.ReadOnly = true;
            this.byte6.Width = 30;
            // 
            // byte7
            // 
            this.byte7.HeaderText = "7";
            this.byte7.Name = "byte7";
            this.byte7.ReadOnly = true;
            this.byte7.Width = 30;
            // 
            // time
            // 
            this.time.Interval = 10;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.data);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.texts);
            this.splitContainer1.Size = new System.Drawing.Size(742, 440);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 2;
            // 
            // texts
            // 
            this.texts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texts.Location = new System.Drawing.Point(0, 0);
            this.texts.Multiline = true;
            this.texts.Name = "texts";
            this.texts.Size = new System.Drawing.Size(353, 440);
            this.texts.TabIndex = 1;
            // 
            // databox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 440);
            this.Controls.Add(this.splitContainer1);
            this.Name = "databox";
            this.ShowIcon = false;
            this.Text = "databox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.databox_FormClosing);
            this.Load += new System.EventHandler(this.databox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte0;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte4;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte5;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte6;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox texts;
    }
}