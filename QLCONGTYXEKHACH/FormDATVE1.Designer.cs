namespace QLCONGTYXEKHACH
{
    partial class FormDATVE1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnthoat = new System.Windows.Forms.Button();
            this.panelnhap = new System.Windows.Forms.Panel();
            this.cboLOAIVE = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNS = new System.Windows.Forms.DateTimePicker();
            this.cboTUYEN = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.BTNCHON = new System.Windows.Forms.Button();
            this.panelnhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHỌN TUYẾN";
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnthoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnthoat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnthoat.ForeColor = System.Drawing.Color.Red;
            this.btnthoat.Location = new System.Drawing.Point(91, 231);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(139, 50);
            this.btnthoat.TabIndex = 5;
            this.btnthoat.Text = "QUAY LẠI";
            this.btnthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // panelnhap
            // 
            this.panelnhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelnhap.Controls.Add(this.cboLOAIVE);
            this.panelnhap.Controls.Add(this.label4);
            this.panelnhap.Controls.Add(this.dtpNS);
            this.panelnhap.Controls.Add(this.cboTUYEN);
            this.panelnhap.Controls.Add(this.label3);
            this.panelnhap.Controls.Add(this.label1);
            this.panelnhap.Location = new System.Drawing.Point(12, 85);
            this.panelnhap.Name = "panelnhap";
            this.panelnhap.Size = new System.Drawing.Size(426, 140);
            this.panelnhap.TabIndex = 5;
            // 
            // cboLOAIVE
            // 
            this.cboLOAIVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLOAIVE.FormattingEnabled = true;
            this.cboLOAIVE.Location = new System.Drawing.Point(196, 87);
            this.cboLOAIVE.Name = "cboLOAIVE";
            this.cboLOAIVE.Size = new System.Drawing.Size(215, 33);
            this.cboLOAIVE.TabIndex = 9;
            this.cboLOAIVE.SelectedIndexChanged += new System.EventHandler(this.cboLOAIVE_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "CHỌN LOẠI VÉ";
            // 
            // dtpNS
            // 
            this.dtpNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNS.Location = new System.Drawing.Point(13, 90);
            this.dtpNS.Name = "dtpNS";
            this.dtpNS.Size = new System.Drawing.Size(177, 30);
            this.dtpNS.TabIndex = 2;
            this.dtpNS.Value = new System.DateTime(2022, 10, 7, 0, 0, 0, 0);
            // 
            // cboTUYEN
            // 
            this.cboTUYEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTUYEN.FormattingEnabled = true;
            this.cboTUYEN.Location = new System.Drawing.Point(13, 28);
            this.cboTUYEN.Name = "cboTUYEN";
            this.cboTUYEN.Size = new System.Drawing.Size(398, 33);
            this.cboTUYEN.TabIndex = 0;
            this.cboTUYEN.SelectedIndexChanged += new System.EventHandler(this.cboTUYEN_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "CHỌN NGÀY ĐI";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelTitle.Location = new System.Drawing.Point(131, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(204, 58);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "ĐẶT VÉ";
            // 
            // BTNCHON
            // 
            this.BTNCHON.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCHON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTNCHON.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTNCHON.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BTNCHON.ForeColor = System.Drawing.Color.Red;
            this.BTNCHON.Location = new System.Drawing.Point(236, 231);
            this.BTNCHON.Name = "BTNCHON";
            this.BTNCHON.Size = new System.Drawing.Size(99, 50);
            this.BTNCHON.TabIndex = 4;
            this.BTNCHON.Text = "TIẾP";
            this.BTNCHON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTNCHON.UseVisualStyleBackColor = false;
            this.BTNCHON.Click += new System.EventHandler(this.BTNCHON_Click);
            // 
            // FormDATVE1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(450, 291);
            this.Controls.Add(this.BTNCHON);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.panelnhap);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormDATVE1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDATVE1";
            this.Load += new System.EventHandler(this.FormDATVE1_Load);
            this.panelnhap.ResumeLayout(false);
            this.panelnhap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelnhap;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNS;
        private System.Windows.Forms.ComboBox cboTUYEN;
        private System.Windows.Forms.Button BTNCHON;
        private System.Windows.Forms.ComboBox cboLOAIVE;
        private System.Windows.Forms.Label label4;
    }
}