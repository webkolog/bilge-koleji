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
    public partial class frmAltDerslikEkle : Form
    {
        public frmAltDerslikEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (txtDerslikAdi.Text == "")
                ht.hataEkle("Derslik adı girmediniz");
            if (dbIslem.aynisiVarmi("Derslikler", "DerslikAdi", txtDerslikAdi.Text))
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
                dbIslem.dbEkleVeriIslem("Derslikler", null, null, "DerslikAdi", "Kat", "Kapasite", txtDerslikAdi.Text, comboKat.Text, txtKapasite.Text);
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }

        private void frmAltDerslikEkle_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 15; i++)
                comboKat.Items.Add(i);
            comboKat.SelectedIndex = 0;
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Derslikler ORDER BY DerslikID DESC", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                try
                {
                    int sonRakam;
                    sonRakam = Convert.ToInt32(sdr["DerslikAdi"].ToString().Split(' ').Last());
                    sonRakam++;
                    txtDerslikAdi.Text = "Derslik " + sonRakam.ToString();
                }
                catch
                {
                    txtDerslikAdi.Text = "Derslik 1";
                }
            }
            else
            {
                txtDerslikAdi.Text = "Derslik 1";
            }
            conn.Close();
        }
    }
}
