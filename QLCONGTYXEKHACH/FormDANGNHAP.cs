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
    public partial class FormDANGNHAP : Form
    {
        DataAccess DataAccess= new DataAccess();
        public FormDANGNHAP()
        {
            InitializeComponent();
        }

        private void ckBHienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBHienthi.Checked)
            {
                txtMatkhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatkhau.PasswordChar = '*';
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FormMAIN f=new FormMAIN();
            this.Hide();f.ShowDialog();this.Close();
            
        }

        private void txtTaikhoan_MouseClick(object sender, MouseEventArgs e)
        {
            txtTaikhoan.SelectAll();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            
            if (txtTaikhoan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập của tài khoản.");
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            string s=DataAccess.GetFirstCellValue("select MANHOMQUYEN from DANGNHAP where TENDANGNHAP='"+txtTaikhoan.Text+"' and MATKHAU='"+txtMatkhau.Text+"'");
            if (s == "")
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị sai.");
                return;
            }
            FormMAIN.DANGNHAP= int.Parse(s);
            if(FormMAIN.DANGNHAP!=2) FormMAIN.manhanvien= int.Parse (DataAccess.GetFirstCellValue("select manhanvien from DANGNHAP where TENDANGNHAP='" + txtTaikhoan.Text + "' and MATKHAU='" + txtMatkhau.Text + "'"));
            FormMAIN f= new FormMAIN();
             this.Hide();f.ShowDialog();
        }

        private void FormDANGNHAP_Load(object sender, EventArgs e)
        {

        }

        private void txtMatkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)   btnDangnhap_Click(sender, e);
        }
    }
}
