namespace QCP.Server.UIControls
{
    partial class NetworkClientControl
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewClient = new System.Windows.Forms.ListView();
            this.toolStripNetworkClient = new System.Windows.Forms.ToolStrip();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewClient
            // 
            this.listViewClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewClient.Location = new System.Drawing.Point(3, 28);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(857, 452);
            this.listViewClient.TabIndex = 0;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            // 
            // toolStripNetworkClient
            // 
            this.toolStripNetworkClient.Location = new System.Drawing.Point(0, 0);
            this.toolStripNetworkClient.Name = "toolStripNetworkClient";
            this.toolStripNetworkClient.Size = new System.Drawing.Size(860, 25);
            this.toolStripNetworkClient.TabIndex = 1;
            this.toolStripNetworkClient.Text = "toolStrip1";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "*";
            // 
            // NetworkClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripNetworkClient);
            this.Controls.Add(this.listViewClient);
            this.Name = "NetworkClientControl";
            this.Size = new System.Drawing.Size(860, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.ToolStrip toolStripNetworkClient;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
