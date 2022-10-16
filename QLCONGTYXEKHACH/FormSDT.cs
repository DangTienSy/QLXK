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
    public partial class FormSDT : Form
    {
        public FormSDT()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
            if(e.KeyChar == (char)Keys.Enter) button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMAIN.sodienthoai=textBox1.Text;
            if (new DataAccess().GetFirstCellValue("select makhach from khach where dienthoai='" + textBox1.Text + "'") == "")
            {
                if (MessageBox.Show("Bạn có muốn đăng kí thông tin?", "Chưa có thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Hide();
                    FormTHONGTINKHACH f = new FormTHONGTINKHACH();
                    f.ShowDialog();
                }
                else this.Close();
            }
            else
            {
                this.Close();
                FormLICHSUDATVE form = new FormLICHSUDATVE();
                form.ShowDialog();
            }
        }

        private void FormSDT_Load(object sender, EventArgs e)
        {
            if(! String.IsNullOrEmpty(FormMAIN.sodienthoai)) textBox1.Text=FormMAIN.sodienthoai;    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 10)
                if (new DataAccess().GetFirstCellValue("select makhach from khach where dienthoai='" + textBox1.Text + "'") != "")
                {
                    this.Close();
                    FormMAIN.sodienthoai = textBox1.Text;
                    FormLICHSUDATVE form = new FormLICHSUDATVE();
                    form.ShowDialog();
                }
        }
    }
}
