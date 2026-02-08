using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace Web_Uygulamasi.Ogrenci
{
    public partial class DosyaGonder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SinifID = dbIslem.tekVeriCek("Ogrenciler","OgrenciID",Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString(),"SinifID");
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT o.OgretmenID, o.OgretmenAdi, o.OgretmenSoyadi, o.OgretmenAdi + ' ' + o.OgretmenSoyadi + ' (' + ad.DersAdi + ')' AS Ogretmen FROM Ogretmenler o JOIN AnaDersler ad ON ad.AnaDersID=o.Brans JOIN DersProgrami dp ON dp.OgretmenID=o.OgretmenID AND dp.SinifID=@SinifID ORDER BY o.OgretmenAdi, o.OgretmenSoyadi", conn);
            sda.SelectCommand.Parameters.AddWithValue("@SinifID", SinifID);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlOgretmen.DataSource = dt;
            ddlOgretmen.DataBind();
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (fuDosya.FileName == "")
            {
                CustomValidator1.ErrorMessage = "Dosya Yok!";
                CustomValidator1.IsValid = false;
            }
            else
            {
                string DosyaUzantisi = Path.GetExtension(fuDosya.FileName);
                string[] UygunUzantilar = { ".txt", ".docx", ".doc", ".xls", "xlsx", ".pdf", ".jpg", ".jpeg", ".png", ".gif", ".rar", ".zip" };
                string OgrenciID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                if (UygunUzantilar.Contains(DosyaUzantisi.ToLower()))
                {
                    string OgretmenID = ddlOgretmen.SelectedItem.Value;
                    string Boyut = fuDosya.PostedFile.ContentLength.ToString();
                    string YeniDosyaAdi = null;
                    string Rastgele = Guid.NewGuid().ToString();
                    YeniDosyaAdi = DateTime.Now.ToString("yyyyMMddHHmmss-") + Rastgele + DosyaUzantisi;
                    fuDosya.SaveAs(Server.MapPath("~/Dosyalar/" + YeniDosyaAdi));
                    dbIslem.dbEkleVeriIslem("Dosyalar", null, null, "OgrenciID", "OgretmenID", "DosyaAdi", "YeniDosyaAdi", "Boyut", "Tarih", OgrenciID, OgretmenID, txtDosyaAdi.Text + DosyaUzantisi, YeniDosyaAdi, Boyut, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Response.Redirect("Dosyalar.aspx");
                }
                else
                {
                    CustomValidator1.ErrorMessage = "Dosya Uzantısı Uygun Değil!";
                    CustomValidator1.IsValid = false;
                }
            }
        }
    }
}