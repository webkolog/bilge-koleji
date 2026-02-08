namespace Windows_Uygulamasi
{
    partial class frmAltDersProgramEkle
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
            this.comboOgretmen = new System.Windows.Forms.ComboBox();
            this.comboDers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sınıf, Gün, Saat";
            // 
            // comboOgretmen
            // 
            this.comboOgretmen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOgretmen.Enabled = false;
            this.comboOgretmen.FormattingEnabled = true;
            this.comboOgretmen.Location = new System.Drawing.Point(96, 55);
            this.comboOgretmen.Name = "comboOgretmen";
            this.comboOgretmen.Size = new System.Drawing.Size(190, 21);
            this.comboOgretmen.TabIndex = 1;
            // 
            // comboDers
            // 
            this.comboDers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDers.FormattingEnabled = true;
            this.comboDers.Location = new System.Drawing.Point(96, 28);
            this.comboDers.Name = "comboDers";
            this.comboDers.Size = new System.Drawing.Size(190, 21);
            this.comboDers.TabIndex = 0;
            this.comboDers.SelectedIndexChanged += new System.EventHandler(this.comboDers_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ders Seç:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Öğretmen Seç:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(96, 82);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(88, 23);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmAltDersProgramEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 117);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.comboDers);
            this.Controls.Add(this.comboOgretmen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "frmAltDersProgramEkle";
            this.Text = "frmAltDersProgramEkle";
            this.Load += new System.EventHandler(this.frmAltDersProgramEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboOgretmen;
        private System.Windows.Forms.ComboBox comboDers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.BindingSource altDerslerBindingSource;
    }
}