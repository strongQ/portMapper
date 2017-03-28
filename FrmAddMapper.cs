using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace portmap_net
{
    public partial class FrmAddMapper : Form
    {
        private bool _isAdd;
        private Database.work_group _workGroup = new Database.work_group();
        /// <summary>
        /// 是否增加
        /// </summary>
        public bool IsAdd
        {
            set
            {
                _isAdd = value;
                if (value == true)
                {
                    this.Text = "增加端口映射";
                }
                else
                {
                    this.Text = "修改端口映射";
                }
            }
            get
            {
                return _isAdd;
            }
        }
        public ListViewItem LVItem
        {
            set;get;
        }
        public int ID
        {
            set;get;
        }
        public event EventHandler transItem;

        public FrmAddMapper()
        {
            InitializeComponent();
            this.Load += FrmAddMapper_Load;
            this.btnOK.Click += BtnOK_Click;
            this.btnCancer.Click += BtnCancer_Click;
          
        }

     

        private void BtnCancer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UiToObj()
        {
            _workGroup.T1INIP = cbInIP.SelectedItem.ToString();
            _workGroup.T1INPORT = int.Parse(txtInPort.Text);
            _workGroup.T1OUTIP = txtOutIP.Text;
            _workGroup.T1OUTPORT = int.Parse(txtOutPort.Text);
            _workGroup.T1NAME = txtName.Text;
            _workGroup.T1SINGLEMAX = int.Parse(txtSingleMax.Text);
            _workGroup.T1MAXNUM = int.Parse(txtMaxNum.Text);
            _workGroup.T1STARTTIME = dtpStart.Text;
            _workGroup.T1STOPTIME = dtpStop.Text;
            if (!IsAdd) _workGroup.T1ID = ID;
        }
        private void ItemToUi()
        {
            this.ID = Convert.ToInt32(LVItem.Tag);
            this.txtName.Text = LVItem.Text;
           this.cbInIP.SelectedItem = LVItem.SubItems[1].Text;
            this.txtInPort.Text =LVItem.SubItems[2].Text;
            this.txtOutIP.Text = LVItem.SubItems[3].Text;
            this.txtOutPort.Text = LVItem.SubItems[4].Text;
            this.txtSingleMax.Text = LVItem.SubItems[5].Text;
            this.txtMaxNum.Text = LVItem.SubItems[6].Text;
            this.dtpStart.Text = LVItem.SubItems[7].Text;
            this.dtpStop.Text = LVItem.SubItems[8].Text;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpStop.Text)) > 0)
            {
                MessageBox.Show("开始时间小于结束时间");
                return;
            }
            
            UiToObj();
            _workGroup.T1ID = Database.work_group.SaveReturn(_workGroup);
            if (transItem != null) transItem(_workGroup,null);
            this.Close();
        }

        private void FrmAddMapper_Load(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();
            IPAddress[] ips = Dns.GetHostEntry(hostname).AddressList.ToArray();
            string[] items = ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(x=>x.ToString()).ToArray();
            cbInIP.Items.Add("Any IP");
            cbInIP.Items.AddRange(items);
            cbInIP.SelectedItem = cbInIP.Items[0];
            this.dtpStart.Text = DateTime.Now.ToString();
            this.dtpStop.Text = DateTime.Now.ToString();
            if (IsAdd) return;
            ItemToUi();
            
        }
    }
}
