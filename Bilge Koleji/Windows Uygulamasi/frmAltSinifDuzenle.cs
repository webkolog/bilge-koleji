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
    public partial class frmAltSinifDuzenle : Form
    {
        string VeriID;
        public frmAltSinifDuzenle(string _veriID)
        {
            InitializeComponent();
            VeriID = _veriID;
        }

        private void frmAltSinifDuzenle_Load(object sender, EventArgs e)
        {
            string Kademe = "", Sube = "", DerslikAdi = "", OgretmenAdi = "", OgretmenID="";
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT s.SinifID, s.Kademe, s.Sube, o.OgretmenID, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS RehberOgretmen, d.DerslikAdi, d.Kat FROM Siniflar s JOIN Derslikler d ON s.DerslikID=d.DerslikID JOIN Ogretmenler o ON o.OgretmenID=s.OgretmenID WHERE s.SinifID=@SinifID", conn);
            cmd.Parameters.AddWithValue("@SinifID", VeriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                Kademe = sdr["Kademe"].ToString();
                Sube = sdr["Sube"].ToString();
                DerslikAdi = sdr["DerslikAdi"].ToString();
                OgretmenAdi = sdr["RehberOgretmen"].ToString();
                OgretmenID = sdr["OgretmenID"].ToString();
            }
            conn.Close();
            for (int i = 9; i <= 12; i++)
                comboKademe.Items.Add(i.ToString());
            foreach (char item in "ABCDEFGHIJKLMNOPRSUVYZ")
                if (!dbIslem.aynisiVarmi("Siniflar", "!SinifID", "Kademe", "Sube", VeriID, comboKademe.Text, item.ToString()))
                    comboSube.Items.Add(item);
            cmd = new SqlCommand("SELECT d.DerslikAdi, d.DerslikID FROM (SELECT *, CASE WHEN CHARINDEX(' ',DerslikAdi,0) = 0 THEN 0 ELSE CAST(SUBSTRING(DerslikAdi,CHARINDEX(' ',DerslikAdi,0)+1,LEN(DerslikAdi)) AS INT) END AS derslik_no FROM Derslikler) d LEFT JOIN Siniflar s ON d.DerslikID=s.DerslikID WHERE s.DerslikID IS NULL OR d.DerslikAdi=@DerslikAdi ORDER BY derslik_no, DerslikAdi", conn);
            cmd.Parameters.AddWithValue("@VeriID", VeriID);
            cmd.Parameters.AddWithValue("@DerslikAdi", DerslikAdi);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.VeriAdi = sdr["DerslikAdi"].ToString();
                vt.veriID = sdr["DerslikID"].ToString();
                comboDerslik.Items.Add(vt);
            }
            conn.Close();
            conn = dbIslem.baglantiOlustur();
            cmd = new SqlCommand("SELECT * FROM Ogretmenler o LEFT JOIN Siniflar s ON o.OgretmenID=s.OgretmenID WHERE s.OgretmenID IS NULL OR o.OgretmenID=@OgretmenID ORDER BY OgretmenAdi, OgretmenSoyadi", conn);
            cmd.Parameters.AddWithValue("@OgretmenID", OgretmenID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.VeriAdi = sdr["OgretmenAdi"] + " " + sdr["OgretmenSoyadi"];
                vt.veriID = sdr["OgretmenID"].ToString();
                comboOgretmen.Items.Add(vt);
            }
            conn.Close();
            comboKademe.Text = Kademe;
            comboSube.Text = Sube;
            comboDerslik.Text = DerslikAdi;
            comboOgretmen.Text = OgretmenAdi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (dbIslem.aynisiVarmi("Siniflar", "!SinifID", "Kademe", "Sube", VeriID, comboKademe.Text, comboSube.Text))
                ht.hataEkle("Böyle bir sınıf zaten mevcut");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                dbIslem.dbHizliGuncelle("Siniflar", "SinifID", VeriID, "Kademe", "Sube", "DerslikID", "OgretmenID", comboKademe.Text, comboSube.Text, (comboDerslik.SelectedItem as VeriTututucu).veriID, (comboOgretmen.SelectedItem as VeriTututucu).veriID);
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }

        private void comboKademe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKademe.SelectedIndex == -1)
                return;
            comboSube.Items.Clear();
            foreach (char item in "ABCDEFGHIJKLMNOPRSUVYZ")
                if (!dbIslem.aynisiVarmi("Siniflar", "!SinifID", "Kademe", "Sube", VeriID, comboKademe.Text, item.ToString()))
                    comboSube.Items.Add(item);
        }
    }
}
