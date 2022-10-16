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
    public partial class FormLUACHONDANGNHAP : Form
    {
        public FormLUACHONDANGNHAP()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            
            FormDANGNHAP f= new FormDANGNHAP();
            this.Hide();f.ShowDialog();this.Close();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FormMAIN.DANGNHAP = 0;
            FormMAIN f = new FormMAIN();
            this.Hide();f.ShowDialog(); this.Close();
            
        }

        private void FormLUACHONDANGNHAP_Load(object sender, EventArgs e)
        {

        }
    }
}
