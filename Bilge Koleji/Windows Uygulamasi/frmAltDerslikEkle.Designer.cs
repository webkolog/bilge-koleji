namespace Windows_Uygulamasi
{
    partial class frmAltDerslikEkle
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
            this.txtDerslikAdi = new System.Windows.Forms.TextBox();
            this.comboKat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtKapasite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Derslik Adı:";
            // 
            // txtDerslikAdi
            // 
            this.txtDerslikAdi.Location = new System.Drawing.Point(78, 6);
            this.txtDerslikAdi.MaxLength = 50;
            this.txtDerslikAdi.Name = "txtDerslikAdi";
            this.txtDerslikAdi.Size = new System.Drawing.Size(166, 20);
            this.txtDerslikAdi.TabIndex = 0;
            // 
            // comboKat
            // 
            this.comboKat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKat.FormattingEnabled = true;
            this.comboKat.Location = new System.Drawing.Point(78, 33);
            this.comboKat.Name = "comboKat";
            this.comboKat.Size = new System.Drawing.Size(48, 21);
            this.comboKat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kapasite:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(78, 87);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(119, 23);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtKapasite
            // 
            this.txtKapasite.Location = new System.Drawing.Point(78, 61);
            this.txtKapasite.MaxLength = 2;
            this.txtKapasite.Name = "txtKapasite";
            this.txtKapasite.Size = new System.Drawing.Size(48, 20);
            this.txtKapasite.TabIndex = 2;
            // 
            // frmAltDerslikEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 119);
            this.Controls.Add(this.txtKapasite);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboKat);
            this.Controls.Add(this.txtDerslikAdi);
            this.Controls.Add(this.label1);
            this.Name = "frmAltDerslikEkle";
            this.Text = "frmAltDerslikEkle";
            this.Load += new System.EventHandler(this.frmAltDerslikEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDerslikAdi;
        private System.Windows.Forms.ComboBox comboKat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtKapasite;

    }
}