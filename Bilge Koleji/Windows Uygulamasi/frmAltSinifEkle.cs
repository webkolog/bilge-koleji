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
    public partial class frmAltSinifEkle : Form
    {
        public frmAltSinifEkle()
        {
            InitializeComponent();
        }

        private void frmAltSinifEkle_Load(object sender, EventArgs e)
        {
            comboSube.Enabled = false;
            for (int i = 9; i <= 12; i++)
                comboKademe.Items.Add(i.ToString());
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT d.DerslikAdi, d.DerslikID FROM (SELECT *, CASE WHEN CHARINDEX(' ',DerslikAdi,0) = 0 THEN 0 ELSE CAST(SUBSTRING(DerslikAdi,CHARINDEX(' ',DerslikAdi,0)+1,LEN(DerslikAdi)) AS INT) END AS derslik_no FROM Derslikler) d LEFT JOIN Siniflar s ON d.DerslikID=s.DerslikID WHERE s.DerslikID IS NULL ORDER BY derslik_no, DerslikAdi", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.VeriAdi = sdr["DerslikAdi"].ToString();
                vt.veriID = sdr["DerslikID"].ToString();
                comboDerslik.Items.Add(vt);
            }
            conn.Close();
            conn = dbIslem.baglantiOlustur();
            cmd = new SqlCommand("SELECT * FROM Ogretmenler o LEFT JOIN Siniflar s ON o.OgretmenID=s.OgretmenID WHERE s.OgretmenID IS NULL ORDER BY OgretmenAdi, OgretmenSoyadi", conn);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (comboKademe.SelectedIndex == -1)
                ht.hataEkle("Kademe seçmediniz");
            if (comboSube.SelectedIndex == -1)
                ht.hataEkle("Şube seçmediniz");
            if (comboDerslik.SelectedIndex == -1)
                ht.hataEkle("Derslik seçmediniz");
            if (comboOgretmen.SelectedIndex == -1)
                ht.hataEkle("Öğretmen seçmediniz");
            if (dbIslem.aynisiVarmi("Siniflar", "Kademe", "Sube", comboKademe.Text, comboSube.Text))
                ht.hataEkle("Böyle bir sınıf zaten mevcut");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                dbIslem.dbEkleVeriIslem("Siniflar", null, null, "Kademe", "Sube", "DerslikID", "OgretmenID", comboKademe.Text, comboSube.Text, (comboDerslik.SelectedItem as VeriTututucu).veriID, (comboOgretmen.SelectedItem as VeriTututucu).veriID);
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }

        private void comboKademe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKademe.SelectedIndex == -1)
                return;
            comboSube.Enabled = true;
            comboSube.Items.Clear();
            foreach (char item in "ABCDEFGHIJKLMNOPRSUVYZ")
                if (!dbIslem.aynisiVarmi("Siniflar", "Kademe", "Sube", comboKademe.Text, item.ToString()))
                    comboSube.Items.Add(item);
        }
    }
}
