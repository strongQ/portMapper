using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace portmap_net
{
    public partial class FrmAbout : Form
    {
        public const string product_version = "1.0.0.2";
        public const string product_version_addl = "Stanley";
        public FrmAbout()
        {
            InitializeComponent();
            this.btnExit.Click += BtnExit_Click;
            this.lblVersion.Text = product_version;
            this.lblCopyRight.Text = product_version_addl;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
