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
    public partial class frmAltMesajOku : Form
    {
        string VeriID;
        public frmAltMesajOku(string _veriID)
        {
            InitializeComponent();
            VeriID = _veriID;
        }

        private void frmAltMesajOku_Load(object sender, EventArgs e)
        {
            string kime = "";
            string Yazilar = "";
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT m.MesajID, CASE m.KimdenID WHEN fo.OgrenciID THEN fo.OgrenciAdi + ' ' + fo.OgrenciSoyadi WHEN fv.VeliID THEN  fv.VeliAdi + ' ' + fv.VeliSoyadi WHEN fe.OgretmenID THEN fe.OgretmenAdi + ' ' + fe.OgretmenSoyadi END AS Kimden, CASE m.KimeID WHEN tor.OgrenciID THEN tor.OgrenciAdi + ' ' + tor.OgrenciSoyadi WHEN tv.VeliID THEN  tv.VeliAdi + ' ' + tv.VeliSoyadi WHEN te.OgretmenID THEN te.OgretmenAdi + ' ' + te.OgretmenSoyadi END AS Kime, m.KimdenID, m.KimeID, m.Baslik, m.Tarih, m.Mesaj, CASE m.KimeID WHEN tor.OgrenciID THEN 'Öğrenci' WHEN tv.VeliID THEN  'Veli' WHEN te.OgretmenID THEN 'Öğretmen' END AS Statu, m.OkunduMu FROM Mesajlar m LEFT JOIN Ogrenciler fo ON fo.OgrenciID=m.KimdenID LEFT JOIN Ogretmenler fe ON fe.OgretmenID=m.KimdenID LEFT JOIN Veliler fv ON fv.VeliID=m.KimdenID LEFT JOIN Ogrenciler tor ON tor.OgrenciID=m.KimeID LEFT JOIN Ogretmenler te ON te.OgretmenID=m.KimeID LEFT JOIN Veliler tv ON tv.VeliID=m.KimeID WHERE MesajID = @MesajID", conn);
            cmd.Parameters.AddWithValue("@MesajID", VeriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                kime = sdr["KimeID"].ToString();
                Yazilar += "Kimden: " + sdr["Kimden"] + "\r\n";
                Yazilar += "Kime: " + sdr["Kime"] + "\r\n";
                Yazilar += "Tarih: " + sdr["Tarih"] + "\r\n";
                Yazilar += "\r\nBaşlık: " + sdr["Baslik"] + "\r\n";
                Yazilar += "\r\nMesaj:\r\n" + sdr["Mesaj"];
            }
            conn.Close();
            textBox1.Text = Yazilar;
            textBox1.Select(textBox1.Text.Length, 0);
            if ((Application.OpenForms[0] as frm_AnaForm).uyeID == kime)
            {
                dbIslem.dbHizliGuncelle("Mesajlar", "MesajID", VeriID, "OkunduMu", "1");
                (Application.OpenForms[0] as frm_AnaForm).tabMenu.TabPages[5].Text = "Mesajlar (" + dbIslem.KayitToplami("Mesajlar", "KimeID", "KimeID", "OkunduMu", (Application.OpenForms[0] as frm_AnaForm).uyeID, "false") + ")";
                (Application.OpenForms[0] as frm_AnaForm).Listele();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Select(textBox1.Text.Length, 0);
        }
    }
}
