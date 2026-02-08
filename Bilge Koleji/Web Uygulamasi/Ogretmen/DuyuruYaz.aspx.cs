using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Web_Uygulamasi.Ogretmen
{
    public partial class DuyuruYaz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string sonuc = dbIslem.dbEkleVeriIslem("Duyuru", null, null, "YazanID", "KitleTuru", "Baslik", "Mesaj", "Tarih", Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString(), ddlKitle.SelectedValue, txtBaslik.Text, txtMesaj.Text, DateTime.Now.ToString("yyyy-MM-dd"));
            if (sonuc.Length > 0)
                Response.Redirect("Default.aspx");
        }
    }
}