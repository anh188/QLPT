using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = bunifuFlatButton1.Height;
            phongTroControl11.BringToFront();
        }


        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton1.Height;
            SidePanel.Top = bunifuFlatButton1.Top;
            phongTroControl11.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton2.Height;
            SidePanel.Top = bunifuFlatButton2.Top;
            khachHangControl11.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton3.Height;
            SidePanel.Top = bunifuFlatButton3.Top;
            hoaDonControl11.BringToFront();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton7.Height;
            SidePanel.Top = bunifuFlatButton7.Top;
            hopDongControl11.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton4.Height;
            SidePanel.Top = bunifuFlatButton4.Top;
            hoaDonDienControl11.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton5.Height;
            SidePanel.Top = bunifuFlatButton5.Top;
            hoaDonNuocControl11.BringToFront();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            SidePanel.Height = bunifuFlatButton6.Height;
            SidePanel.Top = bunifuFlatButton6.Top;
            dichVuControl11.BringToFront();
        }
    }
}
