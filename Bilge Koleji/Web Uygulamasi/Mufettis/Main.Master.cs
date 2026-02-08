using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;

namespace Web_Uygulamasi.Mufettis
{
    public partial class Main : System.Web.UI.MasterPage
    {
        string KullaniciID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

        SqlConnection conn = dbIslem.baglantiOlustur();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ayarlar", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                baslik.InnerText = sdr["OkulAdi"].ToString();
                Page.Title = sdr["OkulAdi"].ToString() + " Öğretmen Portalı";
            }
            conn.Close();
            mmMsj.InnerText = "Mesajlar (" + dbIslem.KayitToplami("Mesajlar", "KimeID", "KimeID", "OkunduMu", KullaniciID, "false") + ")";
            switch (Request.Url.LocalPath.Split('/').Last())
            {
                case "default.aspx":
                    {
                        mmL1.Attributes.Add("Class", "active");
                        break;
                    }
                case "Default.aspx":
                    {
                        mmL1.Attributes.Add("Class", "active");
                        break;
                    }
                case "Mesajlar.aspx":
                    {
                        mmL2.Attributes.Add("Class", "active");
                        break;
                    }
                case "Siniflar.aspx":
                    {
                        mmL3.Attributes.Add("Class", "active");
                        break;
                    }
                case "Ogretmenler.aspx":
                    {
                        mmL5.Attributes.Add("Class", "active");
                        break;
                    }
            }
        }
    }
}