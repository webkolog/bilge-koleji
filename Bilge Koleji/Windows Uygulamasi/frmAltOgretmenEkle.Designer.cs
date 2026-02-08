namespace Windows_Uygulamasi
{
    partial class frmAltOgretmenEkle
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
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.txtSoyadi = new System.Windows.Forms.TextBox();
            this.comboGorev = new System.Windows.Forms.ComboBox();
            this.comboBrans = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnRandomSifre = new System.Windows.Forms.Button();
            this.txtTcKimlikNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adı:";
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(71, 32);
            this.txtAdi.MaxLength = 35;
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(132, 20);
            this.txtAdi.TabIndex = 1;
            this.txtAdi.TextChanged += new System.EventHandler(this.txtSoyadi_TextChanged);
            // 
            // txtSoyadi
            // 
            this.txtSoyadi.Location = new System.Drawing.Point(71, 58);
            this.txtSoyadi.MaxLength = 35;
            this.txtSoyadi.Name = "txtSoyadi";
            this.txtSoyadi.Size = new System.Drawing.Size(132, 20);
            this.txtSoyadi.TabIndex = 2;
            this.txtSoyadi.TextChanged += new System.EventHandler(this.txtSoyadi_TextChanged);
            // 
            // comboGorev
            // 
            this.comboGorev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGorev.FormattingEnabled = true;
            this.comboGorev.Location = new System.Drawing.Point(71, 85);
            this.comboGorev.Name = "comboGorev";
            this.comboGorev.Size = new System.Drawing.Size(132, 21);
            this.comboGorev.TabIndex = 3;
            // 
            // comboBrans
            // 
            this.comboBrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrans.FormattingEnabled = true;
            this.comboBrans.Location = new System.Drawing.Point(71, 113);
            this.comboBrans.Name = "comboBrans";
            this.comboBrans.Size = new System.Drawing.Size(132, 21);
            this.comboBrans.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyadı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Görevi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Branşı:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Location = new System.Drawing.Point(71, 193);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(77, 23);
            this.BtnKaydet.TabIndex = 8;
            this.BtnKaydet.Text = "Kaydet";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(71, 141);
            this.txtEMail.MaxLength = 256;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(132, 20);
            this.txtEMail.TabIndex = 5;
            this.txtEMail.Text = "@bilgekoleji.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(71, 167);
            this.txtSifre.MaxLength = 16;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(105, 20);
            this.txtSifre.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Şifre:";
            // 
            // BtnRandomSifre
            // 
            this.BtnRandomSifre.Location = new System.Drawing.Point(182, 167);
            this.BtnRandomSifre.Name = "BtnRandomSifre";
            this.BtnRandomSifre.Size = new System.Drawing.Size(21, 20);
            this.BtnRandomSifre.TabIndex = 7;
            this.BtnRandomSifre.Text = "R";
            this.BtnRandomSifre.UseVisualStyleBackColor = true;
            this.BtnRandomSifre.Click += new System.EventHandler(this.BtnRandomSifre_Click);
            // 
            // txtTcKimlikNo
            // 
            this.txtTcKimlikNo.Location = new System.Drawing.Point(71, 6);
            this.txtTcKimlikNo.MaxLength = 11;
            this.txtTcKimlikNo.Name = "txtTcKimlikNo";
            this.txtTcKimlikNo.Size = new System.Drawing.Size(132, 20);
            this.txtTcKimlikNo.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "TC No:";
            // 
            // frmAltOgretmenEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 226);
            this.Controls.Add(this.BtnRandomSifre);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.comboBrans);
            this.Controls.Add(this.comboGorev);
            this.Controls.Add(this.txtSoyadi);
            this.Controls.Add(this.txtTcKimlikNo);
            this.Controls.Add(this.txtAdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "frmAltOgretmenEkle";
            this.Text = "frmAltOgretmenEkle";
            this.Load += new System.EventHandler(this.frmAltOgretmenEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.TextBox txtSoyadi;
        private System.Windows.Forms.ComboBox comboGorev;
        private System.Windows.Forms.ComboBox comboBrans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnRandomSifre;
        private System.Windows.Forms.TextBox txtTcKimlikNo;
        private System.Windows.Forms.Label label7;
    }
}