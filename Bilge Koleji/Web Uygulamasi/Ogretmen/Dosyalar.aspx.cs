using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.IO;

namespace Web_Uygulamasi.Ogretmen
{
    public partial class Dosyalar : System.Web.UI.Page
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        protected void Page_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT o.OgrenciID, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, d.DosyaAdi, d.Boyut, d.Tarih, d.DosyaID, CONVERT(NVARCHAR(2),s.Kademe) + s.Sube AS Sinif FROM Dosyalar d JOIN Ogrenciler o ON d.OgrenciID=o.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID WHERE d.OgretmenID = @OgretmenID ORDER BY d.Tarih DESC", conn);
            sda.SelectCommand.Parameters.AddWithValue("@OgretmenID", Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string YeniDosyaAdi = dbIslem.tekVeriCek("Dosyalar", "DosyaID", (GridView1.Rows[e.RowIndex].Cells[0].Controls[1] as Label).Text, "YeniDosyaAdi");
            File.Delete(Server.MapPath("~/Dosyalar/" + YeniDosyaAdi));
            dbIslem.dbVeriSil("Dosyalar", "DosyaID", (GridView1.Rows[e.RowIndex].Cells[0].Controls[1] as Label).Text);
            Listele();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Listele();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Boyut = (int)DataBinder.Eval(e.Row.DataItem, "Boyut");
                e.Row.Cells[4].Text = BoyutBul(Boyut);
            }
        }

        string BoyutBul(int sayi)
        {
            decimal Boyut = sayi;
            string BoyutTipi = "Byte";
            if (Boyut >= 1024)
            {
                Boyut = Boyut / 1024;
                BoyutTipi = "KB";
            }

            if (Boyut >= 1024)
            {
                Boyut = Boyut / 1024;
                BoyutTipi = "MB";
            }
            if (Boyut >= 1024)
            {
                Boyut = Boyut / 1024;
                BoyutTipi = "GB";
            }
            return Math.Round(Boyut).ToString() + " " + BoyutTipi;
        }
    }
}