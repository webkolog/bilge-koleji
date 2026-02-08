using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace Web_Uygulamasi.Mufettis
{
    public partial class Mesajlar : System.Web.UI.Page
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        string Bolum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Bolum"] == "Giden")
                Bolum = "Giden";
            else
                Bolum = "Gelen";
            Listele();
        }

        void Listele()
        {
            string SqlSorgusu = "";
            if (Bolum == "Giden")
            {
                anaBaslik.InnerText = "Giden Mesajlar";
                msjLink.Text = "Gelen Mesajlara Git";
                msjLink.NavigateUrl = "?Bolum=Gelen";
                GridView1.Columns[2].HeaderText = "Kime";
                SqlSorgusu = "SELECT m.MesajID, CASE m.KimdenID WHEN fo.OgrenciID THEN fo.OgrenciAdi + ' ' + fo.OgrenciSoyadi WHEN fv.VeliID THEN  fv.VeliAdi + ' ' + fv.VeliSoyadi WHEN fe.OgretmenID THEN fe.OgretmenAdi + ' ' + fe.OgretmenSoyadi END AS Kimden, CASE m.KimeID WHEN tor.OgrenciID THEN tor.OgrenciAdi + ' ' + tor.OgrenciSoyadi WHEN tv.VeliID THEN  tv.VeliAdi + ' ' + tv.VeliSoyadi WHEN te.OgretmenID THEN te.OgretmenAdi + ' ' + te.OgretmenSoyadi WHEN tm.MufettisID THEN tm.MufettisAdi + ' ' + tm.MufettisSoyadi END AS IlgiliKisi, m.KimdenID, m.KimeID, m.Baslik, m.Tarih, CASE WHEN te.Gorev = 1 THEN 'Müdür' WHEN te.Gorev = 2 THEN 'Müdür Yardımcısı' WHEN m.KimeID=tor.OgrenciID THEN 'Öğrenci' WHEN m.KimeID=tv.VeliID THEN 'Veli' WHEN m.KimeID=te.OgretmenID THEN 'Öğretmen' WHEN m.KimeID=tm.MufettisID THEN 'Müfettiş' END AS Statu, m.OkunduMu, m.KimeID AS IlgiliID FROM Mesajlar m LEFT JOIN Ogrenciler fo ON fo.OgrenciID=m.KimdenID LEFT JOIN Ogretmenler fe ON fe.OgretmenID=m.KimdenID LEFT JOIN Veliler fv ON fv.VeliID=m.KimdenID LEFT JOIN Ogrenciler tor ON tor.OgrenciID=m.KimeID LEFT JOIN Ogretmenler te ON te.OgretmenID=m.KimeID LEFT JOIN Veliler tv ON tv.VeliID=m.KimeID LEFT JOIN Mufettisler tm ON tm.MufettisID=m.KimeID WHERE m.KimdenID=@KullaniciID ORDER BY m.OkunduMu, Tarih DESC";
            }
            else
            {
                anaBaslik.InnerText = "Gelen Mesajlara Git";
                msjLink.Text = "Giden Mesajlar";
                msjLink.NavigateUrl = "?Bolum=Giden";
                GridView1.Columns[2].HeaderText = "Kimden";
                SqlSorgusu = "SELECT m.MesajID, CASE m.KimdenID WHEN fo.OgrenciID THEN fo.OgrenciAdi + ' ' + fo.OgrenciSoyadi WHEN fv.VeliID THEN fv.VeliAdi + ' ' + fv.VeliSoyadi WHEN fe.OgretmenID THEN fe.OgretmenAdi + ' ' + fe.OgretmenSoyadi WHEN fm.MufettisID THEN fm.MufettisAdi + ' ' + fm.MufettisSoyadi END AS IlgiliKisi, CASE m.KimeID WHEN tor.OgrenciID THEN tor.OgrenciAdi + ' ' + tor.OgrenciSoyadi WHEN tv.VeliID THEN  tv.VeliAdi + ' ' + tv.VeliSoyadi WHEN te.OgretmenID THEN te.OgretmenAdi + ' ' + te.OgretmenSoyadi END AS Kime, m.KimdenID, m.KimeID, m.Baslik, m.Tarih, CASE WHEN fe.Gorev = 1 THEN 'Müdür' WHEN fe.Gorev = 2 THEN 'Müdür Yardımcısı' WHEN m.KimdenID=fo.OgrenciID THEN 'Öğrenci' WHEN m.KimdenID=fv.VeliID THEN 'Veli' WHEN m.KimdenID=fe.OgretmenID THEN 'Öğretmen' WHEN m.KimdenID=fm.MufettisID THEN 'Müfettiş' END AS Statu, m.OkunduMu, m.KimdenID AS IlgiliID FROM Mesajlar m LEFT JOIN Ogrenciler fo ON fo.OgrenciID=m.KimdenID LEFT JOIN Ogretmenler fe ON fe.OgretmenID=m.KimdenID LEFT JOIN Veliler fv ON fv.VeliID=m.KimdenID LEFT JOIN Ogrenciler tor ON tor.OgrenciID=m.KimeID LEFT JOIN Ogretmenler te ON te.OgretmenID=m.KimeID LEFT JOIN Veliler tv ON tv.VeliID=m.KimeID LEFT JOIN Mufettisler fm ON fm.MufettisID=m.KimdenID WHERE m.KimeID=@KullaniciID ORDER BY m.OkunduMu, Tarih DESC";
            }
            SqlDataAdapter sda = new SqlDataAdapter(SqlSorgusu, conn);
            sda.SelectCommand.Parameters.AddWithValue("@KullaniciID", Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dbIslem.dbVeriSil("Mesajlar", "MesajID", e.Values[0].ToString());
            Listele();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isnew = (bool)DataBinder.Eval(e.Row.DataItem, "OkunduMu");
                if (!isnew) e.Row.Font.Bold = true;
            }
        }
    }
}