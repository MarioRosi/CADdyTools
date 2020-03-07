using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void showDialog(int left, int top)
        {
            this.Left = left - (this.Width / 2);
            this.Top = top - (this.Height / 2);
            this.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
