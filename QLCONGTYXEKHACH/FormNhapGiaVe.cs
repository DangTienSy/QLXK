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
    public partial class FormNhapGiaVe : Form
    {
        string TUYEN;
        string LOAIVE;
        public FormNhapGiaVe(string TUYEN, string LOAIVE)
        {
            InitializeComponent();
            this.TUYEN = TUYEN;
            this.LOAIVE = LOAIVE;
            
        }

        private void FormNhapGiaVe_Load(object sender, EventArgs e)
        {
            LBLLOAIVE.Text = LOAIVE;
            LBLTUYEN.Text = TUYEN;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (NUMGIA.Value == 0)
            {
                MessageBox.Show("Hãy nhập giá khác 0");
                return;
            }
            string cmd = String.Format("declare @T int = (select maTUYEN from TUYEN_BENXE where TUYEN= N'{0}')\n", TUYEN);
            cmd += String.Format("declare @LV int = (select maLOAIVE from LOAIVE where tenLOAIVE= N'{0}')\n", LOAIVE);
            cmd += String.Format("insert into BANGGIA values (@T,@LV,{0})", NUMGIA.Value);
            new DataAccess().Execute(cmd);
            this.Close();
        }
    }
}
