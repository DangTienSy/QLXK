namespace QLCONGTYXEKHACH
{
    partial class FormXE
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
            this.panelnhap = new System.Windows.Forms.Panel();
            this.numSOCHO = new System.Windows.Forms.NumericUpDown();
            this.cboLOAIVE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBIENSOXE = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnLOAIVE = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panelnhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSOCHO)).BeginInit();
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
            this.btnsua.Size = new System.Drawing.Size(89, 50);
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
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIỂN SỐ XE";
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnxoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnxoa.Location = new System.Drawing.Point(244, 3);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(92, 50);
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
            this.panel2.Location = new System.Drawing.Point(533, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 115);
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
            this.btnhuy.Location = new System.Drawing.Point(244, 59);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(92, 50);
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
            this.btnluu.Location = new System.Drawing.Point(149, 59);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(89, 50);
            this.btnluu.TabIndex = 3;
            this.btnluu.Text = "LƯU";
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // panelnhap
            // 
            this.panelnhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelnhap.Controls.Add(this.numSOCHO);
            this.panelnhap.Controls.Add(this.cboLOAIVE);
            this.panelnhap.Controls.Add(this.label3);
            this.panelnhap.Controls.Add(this.label2);
            this.panelnhap.Controls.Add(this.label1);
            this.panelnhap.Controls.Add(this.txtBIENSOXE);
            this.panelnhap.Location = new System.Drawing.Point(533, 73);
            this.panelnhap.Name = "panelnhap";
            this.panelnhap.Size = new System.Drawing.Size(345, 221);
            this.panelnhap.TabIndex = 5;
            // 
            // numSOCHO
            // 
            this.numSOCHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSOCHO.Location = new System.Drawing.Point(8, 174);
            this.numSOCHO.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSOCHO.Name = "numSOCHO";
            this.numSOCHO.Size = new System.Drawing.Size(100, 36);
            this.numSOCHO.TabIndex = 7;
            this.numSOCHO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSOCHO.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboLOAIVE
            // 
            this.cboLOAIVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLOAIVE.FormattingEnabled = true;
            this.cboLOAIVE.Location = new System.Drawing.Point(8, 102);
            this.cboLOAIVE.Name = "cboLOAIVE";
            this.cboLOAIVE.Size = new System.Drawing.Size(328, 33);
            this.cboLOAIVE.TabIndex = 6;
            this.cboLOAIVE.SelectedIndexChanged += new System.EventHandler(this.cboLOAIVE_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "LOẠI VÉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "SỐ CHỖ";
            // 
            // txtBIENSOXE
            // 
            this.txtBIENSOXE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIENSOXE.Location = new System.Drawing.Point(8, 44);
            this.txtBIENSOXE.Name = "txtBIENSOXE";
            this.txtBIENSOXE.Size = new System.Drawing.Size(328, 30);
            this.txtBIENSOXE.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 9);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(514, 455);
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
            this.labelTitle.Location = new System.Drawing.Point(674, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(91, 58);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "XE";
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnthoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnthoat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnthoat.ForeColor = System.Drawing.Color.Red;
            this.btnthoat.Location = new System.Drawing.Point(756, 417);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(122, 50);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "THOÁT";
            this.btnthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnLOAIVE
            // 
            this.btnLOAIVE.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLOAIVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLOAIVE.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLOAIVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLOAIVE.ForeColor = System.Drawing.Color.Red;
            this.btnLOAIVE.Location = new System.Drawing.Point(532, 417);
            this.btnLOAIVE.Name = "btnLOAIVE";
            this.btnLOAIVE.Size = new System.Drawing.Size(218, 50);
            this.btnLOAIVE.TabIndex = 8;
            this.btnLOAIVE.Text = "QUẢN LÝ LOẠI VÉ";
            this.btnLOAIVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLOAIVE.UseVisualStyleBackColor = false;
            this.btnLOAIVE.Click += new System.EventHandler(this.btnLOAIVE_Click);
            // 
            // FormXE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(888, 472);
            this.Controls.Add(this.btnLOAIVE);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.panelnhap);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormXE";
            this.Text = "FormXE";
            this.Activated += new System.EventHandler(this.FormXE_Load);
            this.Load += new System.EventHandler(this.FormXE_Load);
            this.panel2.ResumeLayout(false);
            this.panelnhap.ResumeLayout(false);
            this.panelnhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSOCHO)).EndInit();
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
        private System.Windows.Forms.TextBox txtBIENSOXE;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnnhapmoi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.ComboBox cboLOAIVE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSOCHO;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnLOAIVE;
    }
}