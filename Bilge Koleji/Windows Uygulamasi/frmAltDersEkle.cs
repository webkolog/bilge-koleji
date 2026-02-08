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
    public partial class frmAltDersEkle : Form
    {
        public frmAltDersEkle()
        {
            InitializeComponent();
        }

        private void frmAltDersEkle_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
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
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (txtDersKodu.Text == "")
                    {
                        ht.hataEkle("Ders kodunuz yazmadınız");
                    }
                    else
                    {
                        if (dbIslem.aynisiVarmi("AltDersler", "DersKodu", txtDersKodu.Text))
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
                        dbIslem.dbEkleVeriIslem("AltDersler", null, null, "DersKodu", "AnaDersID", "Kademe", "HaftalikDersSaati", txtDersKodu.Text.ToUpper(), (comboAnaDers.SelectedItem as VeriTututucu).veriID, comboKademe.SelectedItem.ToString(), comboHDS.SelectedItem.ToString());
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
                        if (dbIslem.aynisiVarmi("AnaDersler", "DersAdi", txtDersAdi.Text))
                            ht.hataEkle(txtDersAdi.Text + ", dersi daha önce eklenmiş");
                    }
                    if (ht.HataVarMi)
                    {
                        ht.HatalariGoster();
                    }
                    else
                    {
                        dbIslem.dbEkleVeriIslem("AnaDersler", null, null, "DersAdi", txtDersAdi.Text);
                        (Application.OpenForms[0] as frm_AnaForm).Listele();
                        this.Close();
                    }
                    break;
            }
        }
    }
}
