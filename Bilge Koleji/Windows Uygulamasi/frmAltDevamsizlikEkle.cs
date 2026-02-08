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
    public partial class frmAltDevamsizlikEkle : Form
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        string sezonID;

        public frmAltDevamsizlikEkle()
        {
            InitializeComponent();
        }

        private void frmAltDevamsizlikEkle_Load(object sender, EventArgs e)
        {
            sezonID = (Application.OpenForms[0] as frm_AnaForm).sezonID;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Siniflar", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = sdr["SinifID"].ToString();
                vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                ComboSiniflar.Items.Add(vt);
            }
            conn.Close();
        }

        private void ComboSiniflar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvOgrenciler.Items.Clear();
            if (ComboSiniflar.SelectedIndex == -1)
                return;
            SqlCommand cmd = new SqlCommand("SELECT o.OgrenciID, o.OkulNo, s.Kademe, s.Sube, o.OgrenciAdi, o.OgrenciSoyadi FROM Ogrenciler o JOIN Siniflar s ON o.SinifID=s.SinifID WHERE o.SinifID = @SinifID", conn);
            cmd.Parameters.AddWithValue("@SinifID", (ComboSiniflar.SelectedItem as VeriTututucu).veriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ListViewItem li = new ListViewItem();
                li.Text = sdr["OkulNo"].ToString();
                li.SubItems.Add(sdr["Kademe"].ToString());
                li.SubItems.Add(sdr["Sube"].ToString());
                li.SubItems.Add(sdr["OgrenciAdi"].ToString());
                li.SubItems.Add(sdr["OgrenciSoyadi"].ToString());
                li.Tag = sdr["OgrenciID"].ToString();
                lvOgrenciler.Items.Add(li);
            }
            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (sezonID == null)
                MessageBox.Show("Sezon oluşturmadan devamsizlik ekleyemezsiniz");
            HataTutucu ht = new HataTutucu();
            if (ComboSiniflar.SelectedIndex == -1)
                ht.hataEkle("Sınıf seçmediniz");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                foreach (ListViewItem item in lvOgrenciler.Items)
                {
                    if (item.Checked)
                    {
                        if (!dbIslem.aynisiVarmi("OgrenciDevamsizlik", "Tarih", "OgrenciID", dtpTarih.Value.ToString("yyyy-MM-dd"), item.Tag.ToString()))
                            dbIslem.dbEkleVeriIslem("OgrenciDevamsizlik", null, null, "OgrenciID", "Tarih", "TamGunMu", "OzelNeden", "SezonID", item.Tag.ToString(), dtpTarih.Value.ToString("yyyy-MM-dd"), "1", "0", sezonID);
                    }
                }
                (Application.OpenForms[0] as frm_AnaForm).Listele();
                this.Close();
            }
        }
    }
}
