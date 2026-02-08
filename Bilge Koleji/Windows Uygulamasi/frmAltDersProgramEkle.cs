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
    public partial class frmAltDersProgramEkle : Form
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        string sinif, gun, saat;

        public frmAltDersProgramEkle(string _sinif, string _gun, string _saat)
        {
            InitializeComponent();
            sinif = _sinif;
            gun = _gun;
            saat = _saat;
        }

        private void frmAltDersProgramEkle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Siniflar WHERE sinifID = @SinifID", conn);
            cmd.Parameters.AddWithValue("@SinifID", sinif);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                label1.Text = sdr["Kademe"] + " " + sdr["Sube"] + " sınıfının " + gunAdi(gun) + " günkü " + saat + ". dersi:";
            }
            conn.Close();
            cmd = new SqlCommand("SELECT altD.AltDersID, anaD.AnaDersID, anaD.DersAdi, altD.HaftalikDersSaati FROM AltDersler altD JOIN AnaDersler anaD ON anaD.AnaDersID=altD.AnaDersID JOIN Siniflar s ON s.Kademe=altD.Kademe WHERE s.SinifID=@SID ORDER BY anaD.DersAdi", conn);
            cmd.Parameters.AddWithValue("@SID", sinif);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int Averaj = Convert.ToInt32(sdr["HaftalikDersSaati"]) - dbIslem.KayitToplami("DersProgrami", "AnaDersID", "SinifID", "AnaDersID", sinif, sdr["AnaDersID"].ToString());
                if (Averaj > 0)
                {
                    VeriTututucu vt = new VeriTututucu();
                    vt.VeriAdi = sdr["DersAdi"] + " (HD: " + Averaj + ")";
                    vt.veriID = sdr["AnaDersID"].ToString();
                    comboDers.Items.Add(vt);
                }
            }
            conn.Close();
        }

        string gunAdi(string gun)
        {
            string gunIsim = null;
            switch (gun)
            {
                case "1":
                    gunIsim = "Pazartesi";
                    break;
                case "2":
                    gunIsim = "Salı";
                    break;
                case "3":
                    gunIsim = "Çarşamba";
                    break;
                case "4":
                    gunIsim = "Perşembe";
                    break;
                case "5":
                    gunIsim = "Cuma";
                    break;
            }
            return gunIsim;
        }

        private void comboDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ogretmenler WHERE Brans = @AnaDersID", conn);
            cmd.Parameters.AddWithValue("@AnaDersID", (comboDers.SelectedItem as VeriTututucu).veriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            comboOgretmen.Items.Clear();
            if (sdr.HasRows)
                comboOgretmen.Enabled = true;
            else
                comboOgretmen.Enabled = false;
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.VeriAdi = sdr["OgretmenAdi"] + " " + sdr["OgretmenSoyadi"];
                vt.veriID = sdr["OgretmenID"].ToString();
                comboOgretmen.Items.Add(vt);
            }
            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (comboDers.SelectedIndex == -1)
                ht.hataEkle("Ders seçmediniz");
            if (comboOgretmen.SelectedIndex == -1)
                ht.hataEkle("Öğretmen seçmediniz");
            if (comboDers.SelectedIndex != -1 & comboOgretmen.SelectedIndex != -1)
                if (dbIslem.aynisiVarmi("DersProgrami", "OgretmenID", "Saat", "Gun", (comboOgretmen.SelectedItem as VeriTututucu).veriID, saat, gun))
                    ht.hataEkle(comboOgretmen.Text + ", zaten " + gunAdi(gun) + " günü " + saat + ". derse başka bir sınıfa giriyor");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                dbIslem.dbEkleVeriIslem("DersProgrami", null, null, "AnaDersID", "OgretmenID", "SinifID", "Saat", "Gun",(comboDers.SelectedItem as VeriTututucu).veriID,(comboOgretmen.SelectedItem as VeriTututucu).veriID,sinif,saat,gun);
                frm_AnaForm frm = (Application.OpenForms[0] as frm_AnaForm);
                frm.DersProgramiListele((frm.comboSinif.SelectedItem as VeriTututucu).veriID);
                this.Close();
            }
        }
    }
}
