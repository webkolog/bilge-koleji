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
    public partial class frmlAltMesajGonder : Form
    {
        string Kimden, Kime, VeriID;
        public frmlAltMesajGonder(string _kimden, string _kime, string _veriID)
        {
            InitializeComponent();
            Kimden = _kimden;
            Kime = _kime;
            VeriID = _veriID;
        }

        private void frmlAltMesajGonder_Load(object sender, EventArgs e)
        {
            /* -VeriID boş değilse- */
            if (VeriID != null)
            {
                SqlConnection conn = dbIslem.baglantiOlustur();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Mesajlar WHERE MesajID = @MesajID", conn);
                cmd.Parameters.AddWithValue("@MesajID", VeriID);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    Kime = sdr["KimeID"].ToString();
                    txtBaslik.Text = "Ce: " + (sdr["Baslik"].ToString().Length <= 45 ? sdr["Baslik"].ToString() : sdr["Baslik"].ToString().Substring(0, 45));
                    txtMesaj.Text = sdr["Mesaj"].ToString();
                }
                conn.Close();
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (txtBaslik.Text.Length < 3)
                ht.hataEkle("Başlık 3 karakterden az olamaz");
            if (txtMesaj.Text.Length < 3)
                ht.hataEkle("Mesaj 3 karakterden az olamaz");
            if (ht.HataVarMi)
                ht.HatalariGoster();
            else
            {
                dbIslem.dbEkleVeriIslem("Mesajlar", null, null, "KimdenID", "KimeID", "Baslik", "Mesaj", "Tarih","OkunduMu", Kimden, Kime, txtBaslik.Text, txtMesaj.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm"),"false");
                (Application.OpenForms[0] as frm_AnaForm).tabMenu.TabPages[5].Text = "Mesajlar (" + dbIslem.KayitToplami("Mesajlar", "KimeID", "KimeID", "OkunduMu", Kimden, "false") + ")";
                this.Close();
            }
        }
    }
}
