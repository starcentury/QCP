namespace QCP.Server
{
    partial class LocalServerController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalServerController));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lableCenterStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCpuLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelNetworkInInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelNetworkOutInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.lableCenterStatus,
            this.labelCpuLoad,
            this.labelNetworkInInfo,
            this.labelNetworkOutInfo});
            this.statusStripMain.Location = new System.Drawing.Point(0, 404);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(872, 22);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(47, 17);
            this.labelStatus.Text = "Ready.";
            // 
            // lableCenterStatus
            // 
            this.lableCenterStatus.Name = "lableCenterStatus";
            this.lableCenterStatus.Size = new System.Drawing.Size(85, 17);
            this.lableCenterStatus.Text = "Center Status";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(872, 25);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.serverToolStripMenuItem.Text = "&Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonStop});
            this.toolStripMain.Location = new System.Drawing.Point(0, 25);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(872, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = global::QCP.Server.Properties.Resources.media_controls_dark_play;
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStart.Text = "toolStripButton1";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = global::QCP.Server.Properties.Resources.media_controls_dark_stop;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "toolStripButton2";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Local Server";
            this.notifyIconMain.Visible = true;
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(104, 76);
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Image = global::QCP.Server.Properties.Resources.media_controls_dark_play;
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem1.Text = "Start";
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.Image = global::QCP.Server.Properties.Resources.media_controls_dark_stop;
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.stopToolStripMenuItem1.Text = "Stop";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // labelCpuLoad
            // 
            this.labelCpuLoad.Name = "labelCpuLoad";
            this.labelCpuLoad.Size = new System.Drawing.Size(32, 17);
            this.labelCpuLoad.Text = "CPU";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Empty;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 53);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            series1.Legend = "Legend1";
            series1.LegendText = "CPU";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(848, 337);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // labelNetworkInInfo
            // 
            this.labelNetworkInInfo.Name = "labelNetworkInInfo";
            this.labelNetworkInInfo.Size = new System.Drawing.Size(73, 17);
            this.labelNetworkInInfo.Text = "Network In";
            // 
            // labelNetworkOutInfo
            // 
            this.labelNetworkOutInfo.Name = "labelNetworkOutInfo";
            this.labelNetworkOutInfo.Size = new System.Drawing.Size(83, 17);
            this.labelNetworkOutInfo.Text = "Network Out";
            // 
            // LocalServerController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 426);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "LocalServerController";
            this.Text = "LocalServer.Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LocalServerController_FormClosing);
            this.Load += new System.EventHandler(this.LocalServerController_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lableCenterStatus;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel labelCpuLoad;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripStatusLabel labelNetworkInInfo;
        private System.Windows.Forms.ToolStripStatusLabel labelNetworkOutInfo;
    }
}