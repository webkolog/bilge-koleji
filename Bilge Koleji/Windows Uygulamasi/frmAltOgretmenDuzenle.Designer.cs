namespace Windows_Uygulamasi
{
    partial class frmAltOgretmenDuzenle
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
            this.BtnRandomSifre = new System.Windows.Forms.Button();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.comboBrans = new System.Windows.Forms.ComboBox();
            this.comboGorev = new System.Windows.Forms.ComboBox();
            this.txtSoyadi = new System.Windows.Forms.TextBox();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRandomSifre
            // 
            this.BtnRandomSifre.Location = new System.Drawing.Point(182, 141);
            this.BtnRandomSifre.Name = "BtnRandomSifre";
            this.BtnRandomSifre.Size = new System.Drawing.Size(21, 20);
            this.BtnRandomSifre.TabIndex = 6;
            this.BtnRandomSifre.Text = "R";
            this.BtnRandomSifre.UseVisualStyleBackColor = true;
            this.BtnRandomSifre.Click += new System.EventHandler(this.BtnRandomSifre_Click_1);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(71, 141);
            this.txtSifre.MaxLength = 16;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(105, 20);
            this.txtSifre.TabIndex = 5;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(71, 115);
            this.txtEMail.MaxLength = 256;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(132, 20);
            this.txtEMail.TabIndex = 4;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Location = new System.Drawing.Point(71, 167);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.BtnKaydet.TabIndex = 7;
            this.BtnKaydet.Text = "Kaydet";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click_1);
            // 
            // comboBrans
            // 
            this.comboBrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrans.FormattingEnabled = true;
            this.comboBrans.Location = new System.Drawing.Point(71, 87);
            this.comboBrans.Name = "comboBrans";
            this.comboBrans.Size = new System.Drawing.Size(132, 21);
            this.comboBrans.TabIndex = 3;
            // 
            // comboGorev
            // 
            this.comboGorev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGorev.FormattingEnabled = true;
            this.comboGorev.Location = new System.Drawing.Point(71, 59);
            this.comboGorev.Name = "comboGorev";
            this.comboGorev.Size = new System.Drawing.Size(132, 21);
            this.comboGorev.TabIndex = 2;
            // 
            // txtSoyadi
            // 
            this.txtSoyadi.Location = new System.Drawing.Point(71, 32);
            this.txtSoyadi.MaxLength = 35;
            this.txtSoyadi.Name = "txtSoyadi";
            this.txtSoyadi.Size = new System.Drawing.Size(132, 20);
            this.txtSoyadi.TabIndex = 1;
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(71, 6);
            this.txtAdi.MaxLength = 35;
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(132, 20);
            this.txtAdi.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Şifre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Branşı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Görevi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Soyadı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Adı:";
            // 
            // frmAltOgretmenDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 200);
            this.Controls.Add(this.BtnRandomSifre);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.comboBrans);
            this.Controls.Add(this.comboGorev);
            this.Controls.Add(this.txtSoyadi);
            this.Controls.Add(this.txtAdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAltOgretmenDuzenle";
            this.Text = "frmAltOgretmenDuzenle";
            this.Load += new System.EventHandler(this.frmAltOgretmenDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRandomSifre;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.ComboBox comboBrans;
        private System.Windows.Forms.ComboBox comboGorev;
        private System.Windows.Forms.TextBox txtSoyadi;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}