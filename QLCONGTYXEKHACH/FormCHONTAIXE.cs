using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCONGTYXEKHACH
{
    public partial class FormCHONTAIXE : Form
    {
        DataAccess DataAccess = new DataAccess();
        public int MaTaiXe { get; set; }
        public FormCHONTAIXE()
        {
            InitializeComponent();
        }

        private void FormNHANVIEN_Load(object sender, EventArgs e)
        {
            dgv.DataSource = DataAccess.GetDataTable("select MANHANVIEN, HOTEN, TENCHUCVU, NGAYSINH, DIENTHOAI, DIACHI from NHANVIEN N, CHUCVU C WHERE N.MACHUCVU=C.MACHUCVU AND TENCHUCVU=N'TÀI XẾ' order by HOTEN");
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedCells.Count > 0 && dgv.SelectedCells[0].Selected)
            {
                int i = dgv.SelectedCells[0].RowIndex;
                try
                {
                    MaTaiXe = int.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    this.Close();
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
        }
    }
}
