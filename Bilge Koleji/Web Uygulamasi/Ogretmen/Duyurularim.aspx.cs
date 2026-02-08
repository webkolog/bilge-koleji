using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace Web_Uygulamasi.Ogretmen
{
    public partial class Duyurularim : System.Web.UI.Page
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            Listele();
        }

        void Listele()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT DuyuruID, CASE KitleTuru WHEN 1 THEN 'Sınıfa Özel' ELSE 'Herkes' END AS Kitle, Baslik, Tarih FROM Duyuru WHERE YazanID=@YazanID ORDER BY Tarih DESC", conn);
            sda.SelectCommand.Parameters.AddWithValue("@YazanID",Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string silinecekID = e.Values[0].ToString();
            dbIslem.dbVeriSil("Duyuru","DuyuruID",silinecekID);
            Listele();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Listele();
        }

    }
}