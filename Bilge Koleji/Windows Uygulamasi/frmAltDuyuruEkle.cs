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
    public partial class frmAltDuyuruEkle : Form
    {
        string uyeID;
        public frmAltDuyuruEkle(string _uyeID)
        {
            InitializeComponent();
            uyeID = _uyeID;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (txtBaslik.Text.Length < 3)
                ht.hataEkle("Başlık 3 karakterden az olamaz");
            if (txtDuyuru.Text.Length < 3)
                ht.hataEkle("Mesaj 3 karakterden az olamaz");
            if (ht.HataVarMi)
                ht.HatalariGoster();
            else
            {
                dbIslem.dbEkleVeriIslem("Duyuru", null, null, "YazanID", "KitleTuru", "Baslik", "Mesaj", "Tarih", uyeID, "0", txtBaslik.Text, txtDuyuru.Text, DateTime.Now.ToString("yyyy-MM-dd"));
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }

        private void frmAltDuyuruEkle_Load(object sender, EventArgs e)
        {

        }

    }
}
