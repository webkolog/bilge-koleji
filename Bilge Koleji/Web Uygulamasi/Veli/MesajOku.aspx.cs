using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace Web_Uygulamasi.Veli
{
    public partial class MesajOku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gelenVeri = Request.QueryString["ID"];
            if (gelenVeri != null)
            {
                if (!Regex.IsMatch(gelenVeri, "[0-9]"))
                {
                    ltrMesaj.Text = "Kayıt Yok!";
                }
                else
                {
                    hlGeriGit.NavigateUrl = "Mesajlar.aspx?Sayfa=" + Request.QueryString["Sayfa"] + "&Bolum=" + Request.QueryString["Bolum"];
                    string KullaniciID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                    //başkalarına gelen özel mesajlarını görmemeli (ama kendi gönderdiyse görebilir)
                    if (dbIslem.aynisiVarmi("Mesajlar", "MesajID", "KimdenID", gelenVeri, KullaniciID) | dbIslem.aynisiVarmi("Mesajlar", "MesajID", "KimeID", gelenVeri, KullaniciID))
                    {
                        //kendisine gelmişse okundu say
                        if (dbIslem.aynisiVarmi("Mesajlar", "MesajID", "KimeID", gelenVeri, KullaniciID))
                            dbIslem.dbHizliGuncelle("Mesajlar", "MesajID", gelenVeri, "OkunduMu", "1");
                        SqlConnection conn = dbIslem.baglantiOlustur();
                        SqlCommand cmd = new SqlCommand("SELECT m.MesajID, m.Mesaj, CASE m.KimdenID WHEN fo.OgrenciID THEN fo.OgrenciAdi + ' ' + fo.OgrenciSoyadi WHEN fv.VeliID THEN fv.VeliAdi + ' ' + fv.VeliSoyadi WHEN fe.OgretmenID THEN fe.OgretmenAdi + ' ' + fe.OgretmenSoyadi WHEN fm.MufettisID THEN fm.MufettisAdi + ' ' + fm.MufettisSoyadi END AS Kimden, CASE m.KimeID WHEN tor.OgrenciID THEN tor.OgrenciAdi + ' ' + tor.OgrenciSoyadi WHEN tv.VeliID THEN tv.VeliAdi + ' ' + tv.VeliSoyadi WHEN te.OgretmenID THEN te.OgretmenAdi + ' ' + te.OgretmenSoyadi WHEN tm.MufettisID THEN tm.MufettisAdi + ' ' + tm.MufettisSoyadi END AS Kime, m.KimdenID, m.KimeID, m.Baslik, m.Tarih, CASE WHEN fe.Gorev = 1 THEN 'Müdür' WHEN fe.Gorev = 2 THEN 'Müdür Yardımcısı' WHEN m.KimdenID=fo.OgrenciID THEN 'Öğrenci' WHEN m.KimdenID=fv.VeliID THEN 'Veli' WHEN m.KimdenID=fe.OgretmenID THEN 'Öğretmen' WHEN m.KimdenID=fm.MufettisID THEN 'Müfettiş' END AS Statu, CASE m.OkunduMu WHEN 0 THEN 'YENİ' ELSE '' END Okunma  FROM Mesajlar m LEFT JOIN Ogrenciler fo ON fo.OgrenciID=m.KimdenID LEFT JOIN Ogretmenler fe ON fe.OgretmenID=m.KimdenID LEFT JOIN Veliler fv ON fv.VeliID=m.KimdenID LEFT JOIN Ogrenciler tor ON tor.OgrenciID=m.KimeID LEFT JOIN Ogretmenler te ON te.OgretmenID=m.KimeID LEFT JOIN Veliler tv ON tv.VeliID=m.KimeID LEFT JOIN Mufettisler fm ON fm.MufettisID=m.KimdenID LEFT JOIN Mufettisler tm ON tm.MufettisID=m.KimdenID WHERE m.MesajID = @MesajID", conn);
                        cmd.Parameters.AddWithValue("@MesajID", gelenVeri);
                        conn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            ltrBaslik.Text = sdr["Baslik"].ToString();
                            ltrMesaj.Text = sdr["Mesaj"].ToString().Replace("\r\n", "<br />");
                            ltrTarih.Text = ((DateTime)sdr["Tarih"]).ToString("dd MMMM yyyy");
                            hlYazan.NavigateUrl = "KullaniciDetay.aspx?ID=" + sdr["KimdenID"];
                            hlYazan.Text = sdr["Kimden"] + " (" + sdr["Statu"] + ")";
                            hlCevap.NavigateUrl = "MesajYaz.aspx?MID=" + sdr["MesajID"] + "&ID=" + sdr["KimdenID"];
                        }
                        conn.Close();
                    }
                    else
                    {
                        ltrMesaj.Text = "Kayıt Yok!";
                    }
                }
            }
        }
    }
}