using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCONGTYXEKHACH
{
    public partial class FormMAIN : Form
    {
        public static int DANGNHAP = 0;
        public static int manhanvien = 0;
        public static string sodienthoai;
        public FormMAIN()
        {
            InitializeComponent();
        }

        private void tlssThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void tlsbLichChuyenXe_Click(object sender, EventArgs e)
        {
            FormTHONGTINDATVE formTHONGTINDATVE = new FormTHONGTINDATVE();
            formTHONGTINDATVE.ShowDialog();
        }

        private void tlsbDatVe_Click(object sender, EventArgs e)
        {
            FormDATVE1 f= new FormDATVE1();
            f.ShowDialog();
        }
        private void tlsbBanVe_Click(object sender, EventArgs e)
        {
            tlsbDatVe_Click(sender, e);
        }

        private void lịchĐiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lịchChuyếnXeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chuyếnĐIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCHUYENXE f= new FormCHUYENXE();
            f.ShowDialog(this);
        }

        private void bếnXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBENXE f= new FormBENXE();
            f.ShowDialog(this);
        }

        private void tuyếnXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTUYEN f = new FormTUYEN();
            f.ShowDialog();
        }

        private void bảngGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBANGGIA f= new FormBANGGIA();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNHANVIEN f= new FormNHANVIEN();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKHACH h= new FormKHACH();
            h.ShowDialog();
        }

        private void loạiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLOAIVE f= new FormLOAIVE(); 
            f.ShowDialog();
        }

        private void xeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormXE formXE= new FormXE();
            formXE.ShowDialog();
        }

        private void tlsbTraCuu_Click(object sender, EventArgs e)
        {
            FormTRACUUCHUYENDI formT = new FormTRACUUCHUYENDI();
            formT.ShowDialog();
        }

        private void tlsbDoanhThuChuyen_Click(object sender, EventArgs e)
        {
            FormDOANHTHUCHUYEN formT = new FormDOANHTHUCHUYEN();
            formT.ShowDialog();
        }

        private void FormMAIN_Load(object sender, EventArgs e)
        {
            if (DANGNHAP == 2)
            {
                toolStrip1.Items.Remove(tlsbDatVe);
                toolStrip1.Items.Remove(tlsbLichsudatve);
                return;
            }
            menuStrip1.Items.Clear(); 
            menuStrip1.Items.Add(hệThốngToolStripMenuItem);
            menuStrip1.Items.Add(traCứuToolStripMenuItem);
            toolStrip1.Items.Clear();
            toolStrip1.Items.Add(tlsbTraCuu);
            switch (DANGNHAP)
            {
                case 0: //KHACH
                    toolStrip1.Items.Add(tlsbDatVe);
                    toolStrip1.Items.Add(tlsbLichsudatve);
                    break;
                case 3://NHAN SU
                    menuStrip1.Items.Add(qlnvmenutoolstripitem);
                    break;
                case 4://LE TAN
                    menuStrip1.Items.Add(quanlykhmenutoolstripitem);
                    toolStrip1.Items.Add(tlsbBanVe);
                    toolStrip1.Items.Add(thongtindatvetoolstripbutton);
                    break;
                case 5://TAI XE 
                    menuStrip1.Items.Add(CHUCNANGToolStripMenuItem);
                    toolStrip1.Items.Add(thongtindatvetoolstripbutton);
                    break;
            }
            toolStrip1.Items.Add(tlssThoat);
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDANGNHAP formT = new FormDANGNHAP();
            formT.ShowDialog();
        }

        private void dSĐặtVéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTHONGTINDATVE f= new FormTHONGTINDATVE();
            f.ShowDialog();        
        }

        private void lịchChuyếnĐiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLICHTAIXE f= new FormLICHTAIXE();
            f.ShowDialog(this); 
        }

        private void FormMAIN_Activated(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void bếnXeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormTRACUUBEN f= new FormTRACUUBEN();
            f.ShowDialog();
        }

        private void tlsbDoanhThuNam_Click(object sender, EventArgs e)
        {
            FormDOANHTHUNAM f= new FormDOANHTHUNAM();
            f.ShowDialog();
        }

        private void doanhThuNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlsbDoanhThuNam_Click(sender, e);
        }

        private void tlsbLichsudatve_click(object sender, EventArgs e)
        {
            FormSDT f= new FormSDT();f.ShowDialog();
        }
    }
}
