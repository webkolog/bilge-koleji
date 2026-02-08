using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Windows_Uygulamasi
{
    public partial class frmAltDuyuruDuzenle : Form
    {
        string uyeID, veriID;
        public frmAltDuyuruDuzenle(string _uyeID, string _veriID)
        {
            InitializeComponent();
            uyeID = _uyeID;
            veriID = _veriID;
        }

        private void frmAltDuyuruDuzenle_Load(object sender, EventArgs e)
        {

            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Duyuru WHERE DuyuruID = @DuyuruID", conn);
            cmd.Parameters.AddWithValue("@DuyuruID", veriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtBaslik.Text = sdr["Baslik"].ToString();
                txtDuyuru.Text = sdr["Mesaj"].ToString();
            }
            conn.Close();
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
                dbIslem.dbHizliGuncelle("Duyuru", "DuyuruID", veriID, "Baslik", "Mesaj", txtBaslik.Text, txtDuyuru.Text);
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }
    }
}
