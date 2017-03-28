namespace portmap_net
{
    partial class FrmMapper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMapper));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnModify = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRun = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStop = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMonitor = new System.Windows.Forms.TabControl();
            this.tbMapGroup = new System.Windows.Forms.TabPage();
            this.lVMapper = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tb = new System.Windows.Forms.TabPage();
            this.lVShow = new System.Windows.Forms.ListView();
            this.tabLogRecord = new System.Windows.Forms.TabPage();
            this.rTbLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslblAll = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tslblSome = new System.Windows.Forms.ToolStripLabel();
            this.tslAllClient = new System.Windows.Forms.ToolStripLabel();
            this.tsbClientNum = new System.Windows.Forms.ToolStripLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbMonitor.SuspendLayout();
            this.tbMapGroup.SuspendLayout();
            this.tb.SuspendLayout();
            this.tabLogRecord.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(826, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusMsg
            // 
            this.tsStatusMsg.Name = "tsStatusMsg";
            this.tsStatusMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnDelete,
            this.tsBtnModify,
            this.tsBtnRun,
            this.tsBtnStop,
            this.tsBtnAbout,
            this.tsBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(826, 48);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.Image = global::portmap_net.Properties.Resources.add1;
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnAdd.Size = new System.Drawing.Size(56, 45);
            this.tsBtnAdd.Tag = "为服务端或本地增加一个映射组";
            this.tsBtnAdd.Text = "增加";
            this.tsBtnAdd.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsBtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = global::portmap_net.Properties.Resources.delete1;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnDelete.Size = new System.Drawing.Size(56, 45);
            this.tsBtnDelete.Tag = "删除服务端或本地一个映射组";
            this.tsBtnDelete.Text = "删除";
            this.tsBtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnModify
            // 
            this.tsBtnModify.Image = global::portmap_net.Properties.Resources.application_edit1;
            this.tsBtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModify.Name = "tsBtnModify";
            this.tsBtnModify.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnModify.Size = new System.Drawing.Size(56, 45);
            this.tsBtnModify.Tag = "修改服务端或本地一个映射组";
            this.tsBtnModify.Text = "修改";
            this.tsBtnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnRun
            // 
            this.tsBtnRun.Image = global::portmap_net.Properties.Resources.control_play_blue1;
            this.tsBtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRun.Name = "tsBtnRun";
            this.tsBtnRun.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnRun.Size = new System.Drawing.Size(56, 45);
            this.tsBtnRun.Tag = "启动开始时间与结束时间相同，该映射会一直存在";
            this.tsBtnRun.Text = "启动";
            this.tsBtnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnStop
            // 
            this.tsBtnStop.Image = global::portmap_net.Properties.Resources.control_pause_blue1;
            this.tsBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStop.Name = "tsBtnStop";
            this.tsBtnStop.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnStop.Size = new System.Drawing.Size(56, 45);
            this.tsBtnStop.Tag = "停止服务端或本地一个映射组";
            this.tsBtnStop.Text = "停止";
            this.tsBtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnAbout
            // 
            this.tsBtnAbout.Image = global::portmap_net.Properties.Resources.help1;
            this.tsBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAbout.Name = "tsBtnAbout";
            this.tsBtnAbout.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnAbout.Size = new System.Drawing.Size(56, 45);
            this.tsBtnAbout.Tag = "关于端口映射器";
            this.tsBtnAbout.Text = "关于";
            this.tsBtnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.Image = global::portmap_net.Properties.Resources.cart_go1;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsBtnExit.Size = new System.Drawing.Size(56, 45);
            this.tsBtnExit.Tag = "退出程序";
            this.tsBtnExit.Text = "退出";
            this.tsBtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbMonitor);
            this.splitContainer1.Size = new System.Drawing.Size(826, 338);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 33);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(353, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎使用 端口映射器";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMonitor
            // 
            this.tbMonitor.Controls.Add(this.tbMapGroup);
            this.tbMonitor.Controls.Add(this.tb);
            this.tbMonitor.Controls.Add(this.tabLogRecord);
            this.tbMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMonitor.Location = new System.Drawing.Point(0, 0);
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.SelectedIndex = 0;
            this.tbMonitor.Size = new System.Drawing.Size(826, 301);
            this.tbMonitor.TabIndex = 0;
            // 
            // tbMapGroup
            // 
            this.tbMapGroup.Controls.Add(this.lVMapper);
            this.tbMapGroup.Location = new System.Drawing.Point(4, 22);
            this.tbMapGroup.Name = "tbMapGroup";
            this.tbMapGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tbMapGroup.Size = new System.Drawing.Size(818, 275);
            this.tbMapGroup.TabIndex = 0;
            this.tbMapGroup.Text = "映射组";
            this.tbMapGroup.UseVisualStyleBackColor = true;
            // 
            // lVMapper
            // 
            this.lVMapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVMapper.FullRowSelect = true;
            this.lVMapper.Location = new System.Drawing.Point(3, 3);
            this.lVMapper.Name = "lVMapper";
            this.lVMapper.Size = new System.Drawing.Size(812, 269);
            this.lVMapper.SmallImageList = this.imageList1;
            this.lVMapper.TabIndex = 0;
            this.lVMapper.UseCompatibleStateImageBehavior = false;
            this.lVMapper.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_green.png");
            this.imageList1.Images.SetKeyName(1, "bullet_black.png");
            this.imageList1.Images.SetKeyName(2, "bullet_red.png");
            // 
            // tb
            // 
            this.tb.Controls.Add(this.lVShow);
            this.tb.Location = new System.Drawing.Point(4, 22);
            this.tb.Name = "tb";
            this.tb.Padding = new System.Windows.Forms.Padding(3);
            this.tb.Size = new System.Drawing.Size(818, 275);
            this.tb.TabIndex = 1;
            this.tb.Text = "连接监控";
            this.tb.UseVisualStyleBackColor = true;
            // 
            // lVShow
            // 
            this.lVShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVShow.FullRowSelect = true;
            this.lVShow.Location = new System.Drawing.Point(3, 3);
            this.lVShow.Name = "lVShow";
            this.lVShow.Size = new System.Drawing.Size(812, 269);
            this.lVShow.TabIndex = 0;
            this.lVShow.UseCompatibleStateImageBehavior = false;
            this.lVShow.View = System.Windows.Forms.View.Details;
            // 
            // tabLogRecord
            // 
            this.tabLogRecord.Controls.Add(this.rTbLog);
            this.tabLogRecord.Controls.Add(this.toolStrip2);
            this.tabLogRecord.Location = new System.Drawing.Point(4, 22);
            this.tabLogRecord.Name = "tabLogRecord";
            this.tabLogRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogRecord.Size = new System.Drawing.Size(818, 275);
            this.tabLogRecord.TabIndex = 2;
            this.tabLogRecord.Text = "日志记录";
            this.tabLogRecord.UseVisualStyleBackColor = true;
            // 
            // rTbLog
            // 
            this.rTbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTbLog.Location = new System.Drawing.Point(3, 28);
            this.rTbLog.Name = "rTbLog";
            this.rTbLog.Size = new System.Drawing.Size(812, 244);
            this.rTbLog.TabIndex = 3;
            this.rTbLog.Text = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tslblAll,
            this.toolStripLabel2,
            this.tslblSome,
            this.tslAllClient,
            this.tsbClientNum});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(812, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel1.Text = "映射组总数：";
            // 
            // tslblAll
            // 
            this.tslblAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tslblAll.Name = "tslblAll";
            this.tslblAll.Size = new System.Drawing.Size(15, 22);
            this.tslblAll.Text = "0";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel2.Text = "已启动连接数：";
            // 
            // tslblSome
            // 
            this.tslblSome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tslblSome.Name = "tslblSome";
            this.tslblSome.Size = new System.Drawing.Size(15, 22);
            this.tslblSome.Text = "0";
            // 
            // tslAllClient
            // 
            this.tslAllClient.Name = "tslAllClient";
            this.tslAllClient.Size = new System.Drawing.Size(104, 22);
            this.tslAllClient.Text = "客户端连接总数：";
            // 
            // tsbClientNum
            // 
            this.tsbClientNum.ForeColor = System.Drawing.Color.Red;
            this.tsbClientNum.LinkColor = System.Drawing.Color.Red;
            this.tsbClientNum.Name = "tsbClientNum";
            this.tsbClientNum.Size = new System.Drawing.Size(15, 22);
            this.tsbClientNum.Text = "0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "程序正在后台运行";
            this.notifyIcon1.BalloonTipTitle = "小提示";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "端口映射器";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            // 
            // FrmMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 408);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMapper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "端口映射器";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbMonitor.ResumeLayout(false);
            this.tbMapGroup.ResumeLayout(false);
            this.tb.ResumeLayout(false);
            this.tabLogRecord.ResumeLayout(false);
            this.tabLogRecord.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnModify;
        private System.Windows.Forms.ToolStripButton tsBtnRun;
        private System.Windows.Forms.ToolStripButton tsBtnStop;
        private System.Windows.Forms.ToolStripButton tsBtnAbout;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tbMonitor;
        private System.Windows.Forms.TabPage tbMapGroup;
        private System.Windows.Forms.TabPage tb;
        private System.Windows.Forms.TabPage tabLogRecord;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusMsg;
        private System.Windows.Forms.ListView lVMapper;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lVShow;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslblAll;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel tslblSome;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox rTbLog;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripLabel tslAllClient;
        private System.Windows.Forms.ToolStripLabel tsbClientNum;
    }
}