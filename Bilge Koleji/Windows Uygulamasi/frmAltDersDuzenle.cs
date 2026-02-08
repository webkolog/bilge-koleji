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
    public partial class frmAltDersDuzenle : Form
    {
        string veriID;
        bool anaDersMi;
        public frmAltDersDuzenle(string _veriID, bool _anaDersMi)
        {
            InitializeComponent();
            veriID = _veriID;
            anaDersMi = _anaDersMi;
        }

        private void frmAltDersDuzenle_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            if (anaDersMi)
            {
                tabControl1.SelectedIndex = 1;
                SqlCommand cmd;
                SqlDataReader sdr;
                cmd = new SqlCommand("SELECT * FROM AltDersler WHERE AltDersID=@AltDersID", conn);
                cmd.Parameters.AddWithValue("@AltDersID", veriID);
                conn.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    veriID = sdr["AnaDersID"].ToString();
                }
                conn.Close();
                cmd = new SqlCommand("SELECT * FROM AnaDersler WHERE AnaDersID=@AnaDersID", conn);
                cmd.Parameters.AddWithValue("@AnaDersID", veriID);
                conn.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    txtDersAdi.Text = sdr["DersAdi"].ToString();
                }
                conn.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM AnaDersler ORDER BY DersAdi ASC", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                comboAnaDers.Items.Clear();
                while (sdr.Read())
                {
                    VeriTututucu vt = new VeriTututucu();
                    vt.VeriAdi = sdr["DersAdi"].ToString();
                    vt.veriID = sdr["AnaDersID"].ToString();
                    comboAnaDers.Items.Add(vt);
                }
                conn.Close();
                for (int i = 9; i <= 12; i++)
                    comboKademe.Items.Add(i.ToString());
                for (int i = 1; i <= 20; i++)
                    comboHDS.Items.Add(i.ToString());
                cmd = new SqlCommand("SELECT altDer.AltDersID, altDer.DersKodu, anaDer.DersAdi, altDer.Kademe, altDer.HaftalikDersSaati FROM AltDersler altDer LEFT JOIN AnaDersler anaDer ON altDer.AnaDersID=anaDer.AnaDersID WHERE altDer.AltDersID = @AltDersID", conn);
                cmd.Parameters.AddWithValue("@AltDersID", veriID);
                conn.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    txtDersKodu.Text = sdr["DersKodu"].ToString();
                    comboAnaDers.Text = sdr["DersAdi"].ToString();
                    comboKademe.Text = sdr["Kademe"].ToString();
                    comboHDS.Text = sdr["HaftalikDersSaati"].ToString();
                }
                conn.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (anaDersMi & tabControl1.SelectedIndex == 0)
            {
                ht.hataEkle("Ana dersi düzenlemelisiniz");
            }
            else if (!anaDersMi & tabControl1.SelectedIndex == 1)
            {
                ht.hataEkle("Alt dersi düzenlemelisiniz");
            }
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
                return;
            }
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (txtDersKodu.Text == "")
                    {
                        ht.hataEkle("Ders kodunuz yazmadınız");
                    }
                    else
                    {
                        if (dbIslem.aynisiVarmi("AltDersler", "!AltDersID", "DersKodu", veriID, txtDersKodu.Text))
                            ht.hataEkle(txtDersKodu.Text + ", ders kodu daha önce eklenmiş");
                    }
                    if (comboAnaDers.SelectedIndex == -1)
                        ht.hataEkle("Ana ders seçmediniz");
                    if (comboKademe.SelectedIndex == -1)
                        ht.hataEkle("Kademe seçmediniz");
                    if (comboHDS.SelectedIndex == -1)
                        ht.hataEkle("Haftalık ders saati seçmediniz");
                    if (ht.HataVarMi)
                    {
                        ht.HatalariGoster();
                    }
                    else
                    {
                        dbIslem.dbHizliGuncelle("AltDersler", "AltDersID", veriID, "DersKodu", "AnaDersID", "Kademe", "HaftalikDersSaati", txtDersKodu.Text.ToUpper(), (comboAnaDers.SelectedItem as VeriTututucu).veriID, comboKademe.SelectedItem.ToString(), comboHDS.SelectedItem.ToString());
                        (Application.OpenForms[0] as frm_AnaForm).Listele();
                        this.Close();
                    }
                    break;
                case 1:
                    if (txtDersAdi.Text == "")
                    {
                        ht.hataEkle("Ders adını yazmadınız");
                    }
                    else
                    {
                        if (dbIslem.aynisiVarmi("AnaDersler", "!AnaDersID", "DersAdi", veriID, txtDersAdi.Text))
                            ht.hataEkle(txtDersAdi.Text + ", dersi daha önce eklenmiş");
                    }
                    if (ht.HataVarMi)
                    {
                        ht.HatalariGoster();
                    }
                    else
                    {
                        dbIslem.dbHizliGuncelle("AnaDersler", "AnaDersID", veriID, "DersAdi", txtDersAdi.Text);
                        (Application.OpenForms[0] as frm_AnaForm).Listele();
                        this.Close();
                    }
                    break;
            }
        }
    }
}
