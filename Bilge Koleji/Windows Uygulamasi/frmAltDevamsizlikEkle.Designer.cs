namespace Windows_Uygulamasi
{
    partial class frmAltDevamsizlikEkle
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
            this.ComboSiniflar = new System.Windows.Forms.ComboBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lvOgrenciler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboSiniflar
            // 
            this.ComboSiniflar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSiniflar.FormattingEnabled = true;
            this.ComboSiniflar.Location = new System.Drawing.Point(45, 7);
            this.ComboSiniflar.Name = "ComboSiniflar";
            this.ComboSiniflar.Size = new System.Drawing.Size(121, 21);
            this.ComboSiniflar.TabIndex = 0;
            this.ComboSiniflar.SelectedIndexChanged += new System.EventHandler(this.ComboSiniflar_SelectedIndexChanged);
            // 
            // dtpTarih
            // 
            this.dtpTarih.Checked = false;
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(396, 8);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(105, 20);
            this.dtpTarih.TabIndex = 1;
            // 
            // lvOgrenciler
            // 
            this.lvOgrenciler.CheckBoxes = true;
            this.lvOgrenciler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvOgrenciler.FullRowSelect = true;
            this.lvOgrenciler.GridLines = true;
            this.lvOgrenciler.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOgrenciler.LabelEdit = true;
            this.lvOgrenciler.Location = new System.Drawing.Point(9, 34);
            this.lvOgrenciler.Name = "lvOgrenciler";
            this.lvOgrenciler.Size = new System.Drawing.Size(492, 316);
            this.lvOgrenciler.TabIndex = 2;
            this.lvOgrenciler.UseCompatibleStateImageBehavior = false;
            this.lvOgrenciler.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Okul No";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sınıf";
            this.columnHeader2.Width = 41;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Şube";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Adı";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Soyadı";
            this.columnHeader5.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sınıf:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tarih:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(332, 356);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(169, 23);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmAltDevamsizlikEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 386);
            this.Controls.Add(this.lvOgrenciler);
            this.Controls.Add(this.ComboSiniflar);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label1);
            this.Name = "frmAltDevamsizlikEkle";
            this.Text = "frmAltDevamsizlikEkle";
            this.Load += new System.EventHandler(this.frmAltDevamsizlikEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboSiniflar;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.ListView lvOgrenciler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKaydet;
    }
}