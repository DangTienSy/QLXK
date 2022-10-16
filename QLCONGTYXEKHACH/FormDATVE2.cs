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
    public partial class FormDATVE2 : Form
    {
        
        public DataAccess DataAccess = new DataAccess();

        public FormDATVE2()
        {
            InitializeComponent();
        }
        
        private void FormDATVE2_Load(object sender, EventArgs e)
        {
            txttuyen.Text = DATVE.Tuyen;
            txtloaive.Text = DATVE.LoaiVe;
            dtpngaydi.Text = DATVE.Ngay;
            txtqd.Text = DataAccess.GetFirstCellValue("SELECT QUANGDUONG FROM TUYEN_BENXE WHERE TUYEN=N'"+txttuyen.Text+"'")+" KM";
            txthr.Text = DataAccess.GetFirstCellValue("SELECT TGDUKIEN FROM TUYEN_BENXE WHERE TUYEN=N'" + txttuyen.Text + "'");

            string dt = DataAccess.GetFirstCellValue("select sotien from BANGGIA_TUYEN_LOAIVE where tuyen=N'" + DATVE.Tuyen +"' AND TENLOAIVE=N'"+ DATVE.LoaiVe +"'");
            if(dt!="")txtgia.Text= String.Format("{0:0,0}",int.Parse(dt));
            LoadDataGridView();
        }
       
        private void LoadDataGridView()
        {
            string cmd = String.Format("SELECT MACHUYENXE, XUATBEN, DEN,CONCHO FROM CHUYEN_DATVE2 " +
                "WHERE TUYEN=N'{0}' AND TENLOAIVE=N'{1}' AND CAST(XUATBEN AS DATE)='"+ DATVE.Ngay +"' order by XUATBEN ", DATVE.Tuyen, DATVE.LoaiVe);
            dgv.DataSource = DataAccess.GetDataTable(cmd);
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDATVE1 f = new FormDATVE1();
            f.ShowDialog();        
        }

        
        
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedCells.Count > 0) if (dgv.SelectedCells[0].Selected)
                {
                    int i = dgv.SelectedCells[0].RowIndex;
                    try
                    {

                        string m = dgv.Rows[i].Cells[0].Value.ToString();

                        txtd1.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        txtd2.Text = dgv.Rows[i].Cells[2].Value.ToString();
                        txtsocho.Text = dgv.Rows[i].Cells[3].Value.ToString();


                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0) if (dgv.SelectedCells[0].Selected)
                {
                    int i = dgv.SelectedCells[0].RowIndex;
                    try
                    {
                        string m = dgv.Rows[i].Cells[0].Value.ToString();

                        txtd1.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        txtd2.Text = dgv.Rows[i].Cells[2].Value.ToString();
                        txtsocho.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        

                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            FormBANGGIA f = new FormBANGGIA();
            f.ShowDialog();
        }



        private void BUTTONTIEP_CLICK(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0) if (dgv.SelectedCells[0].Selected)
                {
                    int i = dgv.SelectedCells[0].RowIndex;
                    try
                    {
                        if (int.Parse(dgv.Rows[i].Cells[3].Value.ToString()) <= 0)
                        {
                            MessageBox.Show("Hết chỗ");
                            return;
                        }
                        DATVE.MACHUYEN = dgv.Rows[i].Cells[0].Value.ToString();
                        DATVE.GIAVE = txtgia.Text;
                        DATVE.XUATBEN = txtd1.Text;
                        DATVE.DEN = txtd2.Text;
                        this.Close();
                        FormDATVE3 f = new FormDATVE3(0);
                        f.ShowDialog();
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }
                }
        }
    }
}
