namespace QLCONGTYXEKHACH
{
    partial class FormKHUNGGIO
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
            this.radPM = new System.Windows.Forms.RadioButton();
            this.radAM = new System.Windows.Forms.RadioButton();
            this.numPHUT = new System.Windows.Forms.NumericUpDown();
            this.numGIO = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panelnhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPHUT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnsua.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnsua.Location = new System.Drawing.Point(6, 59);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(129, 50);
            this.btnsua.TabIndex = 5;
            this.btnsua.Text = "SỬA";
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnthem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnthem.Location = new System.Drawing.Point(141, 3);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(116, 50);
            this.btnthem.TabIndex = 7;
            this.btnthem.Text = "THÊM";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "GIỜ";
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnxoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnxoa.Location = new System.Drawing.Point(6, 115);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(129, 50);
            this.btnxoa.TabIndex = 6;
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
            this.panel2.Location = new System.Drawing.Point(317, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 179);
            this.panel2.TabIndex = 7;
            // 
            // btnnhapmoi
            // 
            this.btnnhapmoi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnnhapmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnnhapmoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnnhapmoi.Location = new System.Drawing.Point(6, 3);
            this.btnnhapmoi.Name = "btnnhapmoi";
            this.btnnhapmoi.Size = new System.Drawing.Size(129, 50);
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
            this.btnhuy.Location = new System.Drawing.Point(141, 115);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(116, 50);
            this.btnhuy.TabIndex = 9;
            this.btnhuy.Text = "HỦY";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnluu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnluu.Location = new System.Drawing.Point(141, 59);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(116, 50);
            this.btnluu.TabIndex = 8;
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
            this.btnthoat.Location = new System.Drawing.Point(402, 370);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(110, 50);
            this.btnthoat.TabIndex = 10;
            this.btnthoat.Text = "THOÁT";
            this.btnthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // panelnhap
            // 
            this.panelnhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelnhap.Controls.Add(this.radPM);
            this.panelnhap.Controls.Add(this.radAM);
            this.panelnhap.Controls.Add(this.numPHUT);
            this.panelnhap.Controls.Add(this.numGIO);
            this.panelnhap.Controls.Add(this.label2);
            this.panelnhap.Controls.Add(this.label1);
            this.panelnhap.Location = new System.Drawing.Point(317, 70);
            this.panelnhap.Name = "panelnhap";
            this.panelnhap.Size = new System.Drawing.Size(270, 109);
            this.panelnhap.TabIndex = 5;
            // 
            // radPM
            // 
            this.radPM.AutoSize = true;
            this.radPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPM.Location = new System.Drawing.Point(186, 59);
            this.radPM.Name = "radPM";
            this.radPM.Size = new System.Drawing.Size(55, 24);
            this.radPM.TabIndex = 3;
            this.radPM.Text = "PM";
            this.radPM.UseVisualStyleBackColor = true;
            // 
            // radAM
            // 
            this.radAM.AutoSize = true;
            this.radAM.Checked = true;
            this.radAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAM.Location = new System.Drawing.Point(187, 29);
            this.radAM.Name = "radAM";
            this.radAM.Size = new System.Drawing.Size(55, 24);
            this.radAM.TabIndex = 2;
            this.radAM.TabStop = true;
            this.radAM.Text = "AM";
            this.radAM.UseVisualStyleBackColor = true;
            // 
            // numPHUT
            // 
            this.numPHUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPHUT.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numPHUT.Location = new System.Drawing.Point(108, 47);
            this.numPHUT.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numPHUT.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.numPHUT.Name = "numPHUT";
            this.numPHUT.ReadOnly = true;
            this.numPHUT.Size = new System.Drawing.Size(72, 36);
            this.numPHUT.TabIndex = 1;
            this.numPHUT.ValueChanged += new System.EventHandler(this.numGIO_ValueChanged);
            // 
            // numGIO
            // 
            this.numGIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGIO.Location = new System.Drawing.Point(32, 47);
            this.numGIO.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numGIO.Name = "numGIO";
            this.numGIO.ReadOnly = true;
            this.numGIO.Size = new System.Drawing.Size(72, 36);
            this.numGIO.TabIndex = 0;
            this.numGIO.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGIO.ValueChanged += new System.EventHandler(this.numGIO_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "PHÚT";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(11, 70);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(300, 350);
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
            this.labelTitle.Location = new System.Drawing.Point(168, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(310, 58);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "KHUNG GIỜ";
            // 
            // FormKHUNGGIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(596, 435);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.panelnhap);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormKHUNGGIO";
            this.Text = "FormKHUNGGIO";
            this.Activated += new System.EventHandler(this.FormKHUNGGIO_Load);
            this.Load += new System.EventHandler(this.FormKHUNGGIO_Load);
            this.panel2.ResumeLayout(false);
            this.panelnhap.ResumeLayout(false);
            this.panelnhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPHUT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGIO)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnnhapmoi;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.NumericUpDown numPHUT;
        private System.Windows.Forms.NumericUpDown numGIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radPM;
        private System.Windows.Forms.RadioButton radAM;
    }
}