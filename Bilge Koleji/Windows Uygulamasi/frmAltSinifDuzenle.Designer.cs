namespace Windows_Uygulamasi
{
    partial class frmAltSinifDuzenle
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
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDerslik = new System.Windows.Forms.ComboBox();
            this.comboOgretmen = new System.Windows.Forms.ComboBox();
            this.comboSube = new System.Windows.Forms.ComboBox();
            this.comboKademe = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Rehber Öğretmen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Derslik:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Şube:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kademe:";
            // 
            // comboDerslik
            // 
            this.comboDerslik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDerslik.FormattingEnabled = true;
            this.comboDerslik.Location = new System.Drawing.Point(110, 60);
            this.comboDerslik.Name = "comboDerslik";
            this.comboDerslik.Size = new System.Drawing.Size(145, 21);
            this.comboDerslik.TabIndex = 2;
            // 
            // comboOgretmen
            // 
            this.comboOgretmen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOgretmen.FormattingEnabled = true;
            this.comboOgretmen.Location = new System.Drawing.Point(110, 87);
            this.comboOgretmen.Name = "comboOgretmen";
            this.comboOgretmen.Size = new System.Drawing.Size(145, 21);
            this.comboOgretmen.TabIndex = 3;
            // 
            // comboSube
            // 
            this.comboSube.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSube.FormattingEnabled = true;
            this.comboSube.Location = new System.Drawing.Point(110, 33);
            this.comboSube.Name = "comboSube";
            this.comboSube.Size = new System.Drawing.Size(75, 21);
            this.comboSube.TabIndex = 1;
            // 
            // comboKademe
            // 
            this.comboKademe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKademe.FormattingEnabled = true;
            this.comboKademe.Location = new System.Drawing.Point(110, 6);
            this.comboKademe.Name = "comboKademe";
            this.comboKademe.Size = new System.Drawing.Size(75, 21);
            this.comboKademe.TabIndex = 0;
            this.comboKademe.SelectedIndexChanged += new System.EventHandler(this.comboKademe_SelectedIndexChanged);
            // 
            // frmAltSinifDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 148);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDerslik);
            this.Controls.Add(this.comboOgretmen);
            this.Controls.Add(this.comboSube);
            this.Controls.Add(this.comboKademe);
            this.Name = "frmAltSinifDuzenle";
            this.Text = "frmAltSinifDuzenle";
            this.Load += new System.EventHandler(this.frmAltSinifDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDerslik;
        private System.Windows.Forms.ComboBox comboOgretmen;
        private System.Windows.Forms.ComboBox comboSube;
        private System.Windows.Forms.ComboBox comboKademe;
    }
}