namespace QLCONGTYXEKHACH
{
    partial class FormNHANVIEN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnxoa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnnhapmoi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.panelnhap = new System.Windows.Forms.Panel();
            this.dtpNS = new System.Windows.Forms.DateTimePicker();
            this.cboCHUCVU = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBLDIACHI = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txttenNHANVIEN = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnCHUCVU = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panelnhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnsua.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnsua.Location = new System.Drawing.Point(149, 3);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(110, 50);
            this.btnsua.TabIndex = 2;
            this.btnsua.Text = "SỬA";
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnthem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnthem.Location = new System.Drawing.Point(8, 59);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(135, 50);
            this.btnthem.TabIndex = 1;
            this.btnthem.Text = "THÊM";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỌ TÊN";
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnxoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnxoa.Location = new System.Drawing.Point(265, 3);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(113, 50);
            this.btnxoa.TabIndex = 4;
            this.btnxoa.Text = "XÓA";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnnhapmoi);
            this.panel2.Controls.Add(this.btnhuy);
            this.panel2.Controls.Add(this.btnluu);
            this.panel2.Controls.Add(this.btnxoa);
            this.panel2.Controls.Add(this.btnsua);
            this.panel2.Controls.Add(this.btnthem);
            this.panel2.Location = new System.Drawing.Point(596, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 115);
            this.panel2.TabIndex = 7;
            // 
            // btnnhapmoi
            // 
            this.btnnhapmoi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnnhapmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnnhapmoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnnhapmoi.Location = new System.Drawing.Point(6, 3);
            this.btnnhapmoi.Name = "btnnhapmoi";
            this.btnnhapmoi.Size = new System.Drawing.Size(137, 50);
            this.btnnhapmoi.TabIndex = 4;
            this.btnnhapmoi.Text = "NHẬP MỚI";
            this.btnnhapmoi.UseVisualStyleBackColor = false;
            this.btnnhapmoi.Click += new System.EventHandler(this.btnnhapmoi_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnhuy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnhuy.Location = new System.Drawing.Point(265, 59);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(113, 50);
            this.btnhuy.TabIndex = 5;
            this.btnhuy.Text = "HỦY";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnluu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnluu.Location = new System.Drawing.Point(149, 58);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(110, 50);
            this.btnluu.TabIndex = 3;
            this.btnluu.Text = "LƯU";
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnthoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnthoat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnthoat.ForeColor = System.Drawing.Color.Red;
            this.btnthoat.Location = new System.Drawing.Point(988, 447);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(120, 50);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "THOÁT";
            this.btnthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // panelnhap
            // 
            this.panelnhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelnhap.Controls.Add(this.dtpNS);
            this.panelnhap.Controls.Add(this.cboCHUCVU);
            this.panelnhap.Controls.Add(this.label4);
            this.panelnhap.Controls.Add(this.label3);
            this.panelnhap.Controls.Add(this.txtSDT);
            this.panelnhap.Controls.Add(this.label2);
            this.panelnhap.Controls.Add(this.LBLDIACHI);
            this.panelnhap.Controls.Add(this.txtDiaChi);
            this.panelnhap.Controls.Add(this.label1);
            this.panelnhap.Controls.Add(this.txttenNHANVIEN);
            this.panelnhap.Location = new System.Drawing.Point(596, 85);
            this.panelnhap.Name = "panelnhap";
            this.panelnhap.Size = new System.Drawing.Size(386, 295);
            this.panelnhap.TabIndex = 5;
            // 
            // dtpNS
            // 
            this.dtpNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNS.Location = new System.Drawing.Point(114, 193);
            this.dtpNS.Name = "dtpNS";
            this.dtpNS.Size = new System.Drawing.Size(261, 30);
            this.dtpNS.TabIndex = 7;
            this.dtpNS.Value = new System.DateTime(2000, 1, 1, 11, 3, 0, 0);
            // 
            // cboCHUCVU
            // 
            this.cboCHUCVU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCHUCVU.FormattingEnabled = true;
            this.cboCHUCVU.Location = new System.Drawing.Point(8, 142);
            this.cboCHUCVU.Name = "cboCHUCVU";
            this.cboCHUCVU.Size = new System.Drawing.Size(367, 33);
            this.cboCHUCVU.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "NGÀY SINH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "ĐIỆN THOẠI";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(8, 257);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(367, 30);
            this.txtSDT.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "CHỨC VỤ";
            // 
            // LBLDIACHI
            // 
            this.LBLDIACHI.AutoSize = true;
            this.LBLDIACHI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDIACHI.Location = new System.Drawing.Point(4, 63);
            this.LBLDIACHI.Name = "LBLDIACHI";
            this.LBLDIACHI.Size = new System.Drawing.Size(70, 20);
            this.LBLDIACHI.TabIndex = 3;
            this.LBLDIACHI.Text = "ĐỊA CHỈ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(8, 86);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(367, 30);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txttenNHANVIEN
            // 
            this.txttenNHANVIEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenNHANVIEN.Location = new System.Drawing.Point(8, 27);
            this.txttenNHANVIEN.Name = "txttenNHANVIEN";
            this.txttenNHANVIEN.Size = new System.Drawing.Size(367, 30);
            this.txttenNHANVIEN.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(578, 489);
            this.dgv.TabIndex = 4;
            this.dgv.TabStop = false;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelTitle.Location = new System.Drawing.Point(641, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(295, 58);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "NHÂN VIÊN";
            // 
            // btnCHUCVU
            // 
            this.btnCHUCVU.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCHUCVU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCHUCVU.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCHUCVU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCHUCVU.ForeColor = System.Drawing.Color.Red;
            this.btnCHUCVU.Location = new System.Drawing.Point(988, 193);
            this.btnCHUCVU.Name = "btnCHUCVU";
            this.btnCHUCVU.Size = new System.Drawing.Size(120, 107);
            this.btnCHUCVU.TabIndex = 9;
            this.btnCHUCVU.Text = "QUẢN LÝ CHỨC VỤ";
            this.btnCHUCVU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCHUCVU.UseVisualStyleBackColor = false;
            this.btnCHUCVU.Click += new System.EventHandler(this.btnCHUCVU_Click);
            // 
            // FormNHANVIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1120, 511);
            this.Controls.Add(this.btnCHUCVU);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.panelnhap);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormNHANVIEN";
            this.Text = "FormNHANVIEN";
            this.Activated += new System.EventHandler(this.FormNHANVIEN_Load);
            this.Load += new System.EventHandler(this.FormNHANVIEN_Load);
            this.panel2.ResumeLayout(false);
            this.panelnhap.ResumeLayout(false);
            this.panelnhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelnhap;
        private System.Windows.Forms.TextBox txttenNHANVIEN;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnnhapmoi;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label LBLDIACHI;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.DateTimePicker dtpNS;
        private System.Windows.Forms.ComboBox cboCHUCVU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCHUCVU;
    }
}