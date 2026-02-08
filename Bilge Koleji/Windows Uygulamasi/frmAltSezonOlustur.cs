using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_Uygulamasi
{
    public partial class frmAltSezonOlustur : Form
    {
        int buYil;
        string mudurID, mudurYID;
        public frmAltSezonOlustur()
        {
            InitializeComponent();
        }

        private void frmAltSezonOlustur_Load(object sender, EventArgs e)
        {
            mudurID = dbIslem.tekVeriCek("Ogretmenler", "Gorev", "1", "OgretmenID");
            mudurYID = dbIslem.tekVeriCek("Ogretmenler", "Gorev", "2", "OgretmenID");
            buYil = DateTime.Now.Year;
            radioButton1.Text = (buYil - 1) + " - " + buYil;
            radioButton2.Text = buYil + " - " + (buYil + 1);
            radioButton2.Checked = true;
        }

        private void btnSonra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            string Donem1;
            string Donem2;
            if (mudurID == null)
            {
                MessageBox.Show("Herhangi bir müdür belirlenmediği için sezon yaratılamadı!\nLütfen Okul Müdürünü belirtledikten sonra uygulamayı tekrar çalıştırın.", "Uyarı!");
                this.Close();
            }
            else if (mudurYID == null)
            {
                MessageBox.Show("Herhangi bir müdür yardımcısı belirlenmediği için sezon yaratılamadı!\nLütfen Okul Müdür Yardımcısını belirtledikten sonra uygulamayı tekrar çalıştırın.", "Uyarı!");
                this.Close();
            }
            if (radioButton1.Checked)
            {
                Donem1 = (buYil - 1).ToString();
                Donem2 = buYil.ToString();
            }
            else
            {
                Donem1 = buYil.ToString();
                Donem2 = (buYil + 1).ToString();
            }
            dbIslem.dbEkleVeriIslem("Sezonlar", null, null, "Donem1", "Donem2", "MudurID", "MudurYardimciID", Donem1, Donem2, mudurID, mudurYID);
            this.Close();
        }
    }
}
