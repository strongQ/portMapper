using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Zhangqi;
using System.Threading.Tasks;

namespace portmap_net
{
    public partial class FrmMapper : Form
    {
        public static bool IsFirstEnter=false;
        public static bool IsClear=false;
        public delegate void showLog();
        public static  List<PortMap> PmList = new List<PortMap>();
        public List<string> LocalIPS = new List<string>();
        public bool Ischeck
        {
            set; get;
        }
        public FrmMapper()
        {
            InitializeComponent();
            this.Load += FrmMapper_Load;
            this.tsBtnAdd.Click += TsBtnAdd_Click;
        
            this.tsBtnAbout.Click += TsBtnAbout_Click;
            this.tsBtnDelete.Click += TsBtnDelete_Click;
            this.tsBtnRun.Click += TsBtnRun_Click;
            this.tsBtnStop.Click += TsBtnStop_Click;
            this.FormClosing += FrmMapper_FormClosing;
            this.lVMapper.SelectedIndexChanged += LVMapper_SelectedIndexChanged;
            this.退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
         
            this.notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
            this.lVMapper.DoubleClick += LVMapper_DoubleClick;
            this.toolStrip1.MouseLeave += ToolStrip1_MouseLeave;
            this.tsBtnAbout.MouseMove += TsBtn_MouseMove;
            this.tsBtnAdd.MouseMove += TsBtn_MouseMove;
            this.tsBtnDelete.MouseMove += TsBtn_MouseMove;
            this.tsBtnRun.MouseMove += TsBtn_MouseMove;
            this.tsBtnStop.MouseMove += TsBtn_MouseMove;
            this.tsBtnExit.Click += TsBtnExit_Click;
            this.tsBtnExit.MouseMove += TsBtn_MouseMove;
            LogHelpMe.GetLogEvent += LogHelpMe_GetLogEvent;
            this.tsBtnModify.Click += TsBtnModify_Click;

        }

      
        // 写日志事件方法
        private void LogHelpMe_GetLogEvent(object message, LogHelpMe.LogEnum logType)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    rTbLog.AppendText(string.Format("{0} {1} {2}\n", DateTime.Now, logType.ToString(), message));
                    this.rTbLog.ScrollToCaret();
                }));
            }
            else
            {
                rTbLog.AppendText(string.Format("{0} {1} {2}\n", DateTime.Now, logType.ToString(), message));
                this.rTbLog.ScrollToCaret();
            }
          
        }

        



      



      
        private void LVMapper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lVMapper.SelectedIndices.Count == 0) return;
          
            this.tsBtnRun.Enabled = true;
            int selectID =Convert.ToInt32( this.lVMapper.SelectedItems[0].Tag);
            var result = PmList.Where(x => x.Id == selectID);
            if (result.Count()>0)
            {
                if (result.First().IsRun)
                {
                    this.tsBtnRun.Enabled = false;
                    this.tsBtnStop.Enabled = true;
                }
                else
                {
                    this.lVMapper.SelectedItems[0].ImageIndex = 1;
                    this.tsBtnStop.Enabled = false;
                }
            }
          
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;   //设置图标不可见
            notifyIcon1.BalloonTipTitle = "";
            notifyIcon1.BalloonTipText = "";
            this.Close();     //关闭窗体
            this.Dispose();                //释放资源
            Application.Exit();            //关闭应用程序窗体

        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void FrmMapper_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
            if (notifyIcon1.BalloonTipText != "")
                this.notifyIcon1.ShowBalloonTip(1000);
        }

      



        private void TsBtnStop_Click(object sender, EventArgs e)
        {
         
            if (this.lVMapper.SelectedItems.Count < 1) return;
            int id = Convert.ToInt32(this.lVMapper.SelectedItems[0].Tag);
            var result = PmList.Where(x => x.Id == id);
            if (result.Count() > 0)
            {
                LogHelpMe.WriteLog(string.Format("映射组'{0}'关闭,手动停止", result.First().Name), LogHelpMe.LogEnum.提示);
                result.First().IsRun = false;
                result.First().IsAuto = false;
                ClearClientSockets(result.First());            
                this.tsBtnRun.Enabled = true;
                this.tsBtnStop.Enabled = false;
                
               this.lVMapper.SelectedItems[0].ImageIndex = 1;                
                
            }    

        }

       

        private void LVMapper_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void FrmMapper_Load(object sender, EventArgs e)
        {
            IsFirstEnter = true;
            this.tsBtnStop.Enabled = false;
            this.tsBtnRun.Enabled = false;
            this.lVMapper.Columns.Add("名称", 100, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("输入IP", 90, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("输入端口", 60, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("输出IP", 90, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("输出端口", 60, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("单IP最大连接数", 75, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("最大连接数", 75, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("映射开始时间", 130, HorizontalAlignment.Left);
            this.lVMapper.Columns.Add("映射结束时间", 130, HorizontalAlignment.Left);

            this.lVShow.Columns.Add("名称", 100, HorizontalAlignment.Left);
            this.lVShow.Columns.Add("输入IP", 130, HorizontalAlignment.Left);
            this.lVShow.Columns.Add("输出IP", 130, HorizontalAlignment.Left);
            this.lVShow.Columns.Add("连接数", 75, HorizontalAlignment.Left);
            this.lVShow.Columns.Add("接收字节", 80, HorizontalAlignment.Left);
            this.lVShow.Columns.Add("发送字节", 80, HorizontalAlignment.Left);

            LoadData();
            RefreshUI();
            RunTaskClearSocket();
            this.tslblAll.Text = PmList.Count.ToString() ;
            Ischeck = false;
            Task.Factory.StartNew(() =>
            {
                Run();
            });
        }

        private void RunTaskClearSocket()
        {
            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    for (int i = 0; i < PmList.Count; i++)
                    {
                        if (PmList[i].tcpClientList.Count > 0 && IsClear)
                        {
                            for(int j = 0; j < PmList[i].tcpClientList.Count; j++)
                            {
                                TcpClient sock = PmList[i].tcpClientList[j];
                                try
                                {
                                  
                                    if (!Zhangqi.Common.LookServer(sock.Client))
                                    {
                                        
                                        PmList[i].tcpClientList.Remove(sock);
                                      //  CloseSocket(sock);
                                    }
                                    
                                }
                                catch 
                                {
                                    PmList[i].tcpClientList.Remove(sock);
                                  //  CloseSocket(sock);
                                }
                            }
                        
                        }
                    }
                    Thread.Sleep(1000);
                }
                
            }).ContinueWith(x =>
            {
                try
                {
                    x.Wait();
                }
                catch { }
            });
        }

        private void RefreshUI()
        {
            this.lVMapper.BeginUpdate();
          
            foreach (var pm in PmList)
            {
                ListViewItem ivi = new ListViewItem();
                ivi.Tag = pm.Id;
                ivi.ImageIndex = 1;
                ivi.Text = pm.Name;
                ivi.SubItems.Add(pm.Point_in_host);
                ivi.SubItems.Add(pm.Point_in_port.ToString());
                ivi.SubItems.Add(pm.Point_out_host);
                ivi.SubItems.Add(pm.Point_out_port.ToString());
                ivi.SubItems.Add(pm.SingleNum.ToString());
                ivi.SubItems.Add(pm.MaxNum.ToString());
                ivi.SubItems.Add(pm.Start_time);
                ivi.SubItems.Add(pm.Stop_time);
                this.lVMapper.Items.Add(ivi);
            }
            this.lVMapper.EndUpdate();
        }

        private void LoadData()
        {
          
                DataTable dt = Database.work_group.SelectDataTableBase("select * from work_group");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PortMap pm = new PortMap();
                    pm.Id = Convert.ToInt32(dt.Rows[i]["T1ID"]);
                    pm.Name = dt.Rows[i]["T1NAME"].ToString();
                    pm.Point_in_host = dt.Rows[i]["T1INIP"].ToString();

                    pm.Point_in_port = Convert.ToInt32(dt.Rows[i]["T1INPORT"]);
                    pm.Point_out_host = dt.Rows[i]["T1OUTIP"].ToString();
                    pm.Point_out_port = Convert.ToInt32(dt.Rows[i]["T1OUTPORT"]);
                    pm.SingleNum = Convert.ToInt32(dt.Rows[i]["T1SINGLEMAX"]);
                    pm.MaxNum = Convert.ToInt32(dt.Rows[i]["T1MAXNUM"]);
                    pm.Start_time = dt.Rows[i]["T1STARTTIME"].ToString();
                    pm.Stop_time = dt.Rows[i]["T1STOPTIME"].ToString();
                    PmList.Add(pm);

                }
            
           
        }
        private void UpdateData()
        {
            this.lVShow.Items.Clear();
            this.lVShow.BeginUpdate();
            var result = PmList.Where(x => x.IsRun);
            tslblSome.Text = result.Count().ToString();
            int clientNum = 0;
            foreach(var pm in PmList)
            {
                clientNum += pm.tcpClientList.Count;
            }
            tsbClientNum.Text = clientNum.ToString();
            foreach (var item in PmList)
            {
                if (!item.IsRun) continue;
                ListViewItem ivi = new ListViewItem();
                ivi.Tag = item.Id;
                ivi.Text = item.Name;
                ivi.SubItems.Add(item.Point_in_host + ":" + item.Point_in_port);
                ivi.SubItems.Add(item.Point_out_host+":"+item.Point_out_port);
                ivi.SubItems.Add(item.tcpClientList.Count.ToString());
                ivi.SubItems.Add(item.RecieveBytes.ToString());
                ivi.SubItems.Add(item.SendBytes.ToString());
                this.lVShow.Items.Add(ivi);
            }
            this.lVShow.EndUpdate();

        }
        public static ListViewItem objToItem(Database.work_group wg)
        {
            ListViewItem ivi = new ListViewItem();
            ivi.Tag = wg.T1ID;
            ivi.ImageIndex = 1;
            ivi.Text = wg.T1NAME;
            ivi.SubItems.Add(wg.T1INIP);
            ivi.SubItems.Add(wg.T1INPORT.ToString());
            ivi.SubItems.Add(wg.T1OUTIP);
            ivi.SubItems.Add(wg.T1OUTPORT.ToString());
            ivi.SubItems.Add(wg.T1SINGLEMAX.ToString());
            ivi.SubItems.Add(wg.T1MAXNUM.ToString());
            ivi.SubItems.Add(wg.T1STARTTIME.ToString());
            ivi.SubItems.Add(wg.T1STOPTIME.ToString());
            return ivi;
        }
        private void TsBtnRun_Click(object sender, EventArgs e)
        {
         
            if (!Ischeck)
            {
                if (!checkIP()) return;
            }
            if (lVMapper.SelectedItems.Count < 1) return;
            var result = PmList.Where(x => x.Id == Convert.ToInt32(lVMapper.SelectedItems[0].Tag));
            PortMap pm = result.First();
            if (result.Count() == 0) return;
          
            string result1 = pm.StartMap();
            if (result1 != "")
            {
                LogHelpMe.WriteLog(string.Format("映射组'{0}'无法启动", pm.Name), LogHelpMe.LogEnum.提示);
                return;
            }
            LogHelpMe.WriteLog(string.Format("映射组'{0}'手动成功启动\n", pm.Name), LogHelpMe.LogEnum.提示);
            pm.IsRun = true;
            lVMapper.SelectedItems[0].ImageIndex = 0;
            this.tsBtnRun.Enabled = false;
            this.tsBtnStop.Enabled = true;

        }

     

        /// <summary>
        /// 检查IP
        /// </summary>
        /// <returns></returns>
        private bool checkIP()
        {
            string hostname = Dns.GetHostName();
            IPAddress[] ips = Dns.GetHostEntry(hostname).AddressList.ToArray();
            string[] items = ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(x => x.ToString()).ToArray();
            LocalIPS.AddRange(items);
          
            foreach (ListViewItem group in this.lVMapper.Items)
            {
                if (!LocalIPS.Contains(group.SubItems[1].Text) && group.SubItems[1].Text!="Any IP" )
                {
                    MessageBox.Show(string.Format("{0}输入IP有误", group.Text));
                    Ischeck = false;
                    return false;
                }
            }
            Ischeck = true;
            return true;

        }
        // 循环定时启动
        private void Run()
        {
            while (true)
            {
                if (this.InvokeRequired)
                    this.BeginInvoke(new Action(() => UpdateData()));
         
                for (int i = 0; i < PmList.Count; i++)
                {

                    DateTime startTime = Convert.ToDateTime(PmList[i].Start_time);

                    if (DateTime.Compare(startTime, DateTime.Now) > 0) continue;
                    DateTime stopTime = Convert.ToDateTime(PmList[i].Stop_time);
                    if (PmList[i].Start_time == PmList[i].Stop_time) continue;

                    if (DateTime.Compare(DateTime.Now, stopTime) >= 0)
                    {
                        if (PmList[i].IsRun)
                        {
                            LogHelpMe.WriteLog(string.Format("映射组'{0}'关闭,定时结束时间到", PmList[i].Name), LogHelpMe.LogEnum.提示);

                            ClearClientSockets(PmList[i]);
                            PmList[i].IsRun = false;
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    foreach (ListViewItem item in lVMapper.Items)
                                    {
                                        if (item.Tag.ToString() == PmList[i].Id.ToString())
                                        {
                                            item.ImageIndex = 1;

                                            break;
                                        }
                                    }
                                }));
                            }
                         
                        }
                        continue;
                    }
                    if (PmList[i].IsRun) continue;
                    if (PmList[i].IsAuto && IsFirstEnter)
                        if (MessageBox.Show(string.Format("{0} 时间范围满足启动要求，是否启动?", PmList[i].Name), "提示", MessageBoxButtons.YesNo)== DialogResult.No)
                        {
                            PmList[i].IsAuto = false;
                            continue;
                        }
                    if (!PmList[i].IsAuto) continue;
                    string result = PmList[i].StartMap();
                    if (result != "")
                    {
                        LogHelpMe.WriteLog(string.Format("映射组'{0}'无法启动", PmList[i].Name), LogHelpMe.LogEnum.提示);
                        continue;
                    }
                    LogHelpMe.WriteLog(string.Format("映射组'{0}'定时成功启动\n", PmList[i].Name), LogHelpMe.LogEnum.提示);
                    PmList[i].IsRun = true;
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            foreach (ListViewItem item in lVMapper.Items)
                            {
                                if (item.Tag.ToString() == PmList[i].Id.ToString())
                                {
                                    item.ImageIndex = 0;
                                    break;
                                }
                            }
                        }));
                    }
                  
                }
                IsFirstEnter = false;
                Thread.Sleep(1000);
            }
        }

                    

        private static void ClearClientSockets(PortMap pm)
        {
            Task.Factory.StartNew(() =>
            {
           
                foreach (var sock in pm.tcpClientList)
                {
                    CloseSocket(sock.Client);
                }

                try
                {

                    //   pm.ServerSocket.Shutdown(SocketShutdown.Both);

                    pm.serverListener.Server.Close();
                }
                catch (Exception ee) { }
            });
        }

        private static void CloseSocket(Socket sock)
        {
            try
            {
                sock.Shutdown(SocketShutdown.Both);


                sock.Close();
            }
            catch (Exception) { }
        }




        private void ItemToGroup(PortMap pm, ListViewItem lvItem)
        {
            pm.Name = lvItem.Text;
            pm.Id = Convert.ToInt32(lvItem.Tag);
            pm.IsAuto = true;
            pm.Point_in_host=lvItem.SubItems[1].Text;
            pm.Point_in_port =  Convert.ToInt32(lvItem.SubItems[2].Text);
            pm.Point_out_host = lvItem.SubItems[3].Text;
            pm.Point_out_port = Convert.ToUInt16(lvItem.SubItems[4].Text);
            pm.SingleNum = Convert.ToInt32(lvItem.SubItems[5].Text);
            pm.MaxNum = Convert.ToInt32(lvItem.SubItems[6].Text);
            pm.Start_time = lvItem.SubItems[7].Text;
            pm.Stop_time = lvItem.SubItems[8].Text;
           
        }

        private void TsBtnModify_Click(object sender, EventArgs e)
        {
            if (this.lVMapper.SelectedItems.Count < 1) return;
            Edit();
        }

        private void TsBtnDelete_Click(object sender, EventArgs e)
        {
            if (this.lVMapper.SelectedItems.Count < 1) return;
            var result = PmList.Where(x => x.Id == Convert.ToInt32(lVMapper.SelectedItems[0].Tag));
            PortMap pm = result.First();
            if (result.First().IsRun) return;
            if (MessageBox.Show("确认删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Database.work_group.Delete(Convert.ToInt32(this.lVMapper.SelectedItems[0].Tag));
            this.lVMapper.Items.Remove(this.lVMapper.SelectedItems[0]);
            PmList.Remove(pm);
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void Edit()
        {
            FrmAddMapper fm = new FrmAddMapper();
            fm.transItem += AddMapper_transItem;
            fm.LVItem = this.lVMapper.SelectedItems[0];

            fm.IsAdd = false;
            fm.ShowDialog();
        }



        private void ToolStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.tsStatusMsg.Text = "";
        }

        private void TsBtn_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            this.tsStatusMsg.Text = tsb.Tag.ToString();
        }

        private void TsBtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void TsBtnAdd_Click(object sender, EventArgs e)
        {
            FrmAddMapper addMapper = new FrmAddMapper() { IsAdd = true };
            addMapper.transItem += AddMapper_transItem;
            addMapper.ShowDialog();
        }

        private void AddMapper_transItem(object sender, EventArgs e)
        {
            Database.work_group wg = (Database.work_group)sender;
            if (this.lVMapper.SelectedItems.Count > 0)
            {
                if ((int)this.lVMapper.SelectedItems[0].Tag == wg.T1ID)
                {
                    this.lVMapper.SelectedItems[0].Text = wg.T1NAME;
                    this.lVMapper.SelectedItems[0].SubItems[1].Text = wg.T1INIP;
                    this.lVMapper.SelectedItems[0].SubItems[2].Text = wg.T1INPORT.ToString();
                    this.lVMapper.SelectedItems[0].SubItems[3].Text = wg.T1OUTIP;
                    this.lVMapper.SelectedItems[0].SubItems[4].Text = wg.T1OUTPORT.ToString();
                    this.lVMapper.SelectedItems[0].SubItems[5].Text = wg.T1SINGLEMAX.ToString();
                    this.lVMapper.SelectedItems[0].SubItems[6].Text = wg.T1MAXNUM.ToString();
                    this.lVMapper.SelectedItems[0].SubItems[7].Text = wg.T1STARTTIME.ToString();
                    this.lVMapper.SelectedItems[0].SubItems[8].Text = wg.T1STOPTIME.ToString();
                    ItemToGroup(PmList.Where(x => x.Id == wg.T1ID).First(),lVMapper.SelectedItems[0]);
                }
                else
                {
                    lVMapper.Items.Add(objToItem(wg));
                    PortMap pm = new PortMap();
                    ItemToGroup(pm,objToItem(wg));
                    PmList.Add(pm);
                }
            }
            else
            {
                lVMapper.Items.Add(objToItem(wg));
                PortMap pm = new PortMap();
                ItemToGroup(pm,objToItem(wg));
                PmList.Add(pm);
            }
        }

        private void TsBtnExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "";
            notifyIcon1.BalloonTipText = "";
            this.Close();                  //关闭窗体
            this.Dispose();                //释放资源
            Application.Exit();            //关闭应用程序窗体

        }
    }
}
