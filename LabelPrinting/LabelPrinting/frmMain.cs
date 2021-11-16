using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelPrinting
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Form1 frm = new Form1();
            //frm.Show();
            //frm.ControlBox = false;
            //frm.MinimizeBox = false;
            //frm.MaximizeBox = false;
            //frm.Dock = DockStyle.Fill;
            //frm.MdiParent = this;

            //frm.BringToFront();
            //this.ContainerPanell

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucItemInfor frm = new ucItemInfor();
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.Parent = pnMain;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ucPrint frm = new ucPrint();
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.Parent = pnMain;
        }
    }
}
