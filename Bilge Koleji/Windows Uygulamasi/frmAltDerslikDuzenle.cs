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
    public partial class frmAltDerslikDuzenle : Form
    {
        string veriID;
        public frmAltDerslikDuzenle(string _veriID)
        {
            InitializeComponent();
            veriID = _veriID;
        }

        private void frmAltDerslikDuzenle_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 15; i++)
                comboKat.Items.Add(i);
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Derslikler WHERE DerslikID = @DerslikID", conn);
            cmd.Parameters.AddWithValue("@DerslikID", veriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtDerslikAdi.Text = sdr["DerslikAdi"].ToString();
                comboKat.Text = sdr["Kat"].ToString();
                txtKapasite.Text = sdr["Kapasite"].ToString();
            }
            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (txtDerslikAdi.Text == "")
                ht.hataEkle("Derslik adı girmediniz");
            if (dbIslem.aynisiVarmi("Derslikler", "!DerslikID", "DerslikAdi", veriID, txtDerslikAdi.Text))
                ht.hataEkle("Bu isimle daha önce derslik eklenmiş");
            if (txtKapasite.Text == "")
                ht.hataEkle("Kapasite girmediniz");
            else
            {
                try
                {
                    Convert.ToInt32(txtKapasite.Text);
                }
                catch
                {
                    ht.hataEkle("Kapasite değeri sayı olmalı");
                }
            }
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                dbIslem.dbHizliGuncelle("Derslikler", "DerslikID", veriID, "DerslikAdi", "Kat", "Kapasite", txtDerslikAdi.Text, comboKat.Text, txtKapasite.Text);
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }
    }
}
