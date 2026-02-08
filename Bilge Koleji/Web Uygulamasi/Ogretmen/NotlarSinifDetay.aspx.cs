using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace Web_Uygulamasi.Ogretmen
{
    public partial class NotlarSinifDetay : System.Web.UI.Page
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        string veriID;
        string ogretmenID;
        string SezonID;

        protected void Page_Load(object sender, EventArgs e)
        {
            SezonID = SezonIDBul();
            ogretmenID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            veriID = Request.QueryString["ID"];
            if (veriID != null)
            {
                string Tip = Request.QueryString["Tip"];
                //derslerine giriyor musun?
                if (dbIslem.aynisiVarmi("DersProgrami", "SinifID", "OgretmenID", veriID, ogretmenID))
                {
                    string donem = Request.QueryString["Donem"];
                    if (donem != null)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Siniflar WHERE SinifID = @SinifID", conn);
                        cmd.Parameters.AddWithValue("@SinifID", veriID);
                        conn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            Baslik.InnerText =  sdr["Kademe"].ToString() + sdr["Sube"].ToString() + " Ders Notları";
                        }
                        conn.Close();
                        ltrDers.Text = AnaDersBul();
                        switch (donem)
                        {
                            case "1":
                                {
                                    gvDersDonem1.Style.Add("Display", "");
                                    gvDersDonem2.Style.Add("Display", "None");
                                    ltrDonem.Text = "1.Dönem";
                                    ListeleDO(gvDersDonem1);
                                    break;
                                }
                            case "2":
                                {
                                    gvDersDonem1.Style.Add("Display", "None");
                                    gvDersDonem2.Style.Add("Display", "");
                                    ltrDonem.Text = "2.Dönem";
                                    ListeleDO(gvDersDonem2);
                                    break;
                                }
                        }
                    }
                }

            }
        }

        private void ListeleDO(GridView GrdView)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT o.OgrenciID, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, CASE Donem1SinavNotu1 WHEN -1 THEN null ELSE Donem1SinavNotu1 END AS Donem1SinavNotu1, CASE Donem1SinavNotu2 WHEN -1 THEN null ELSE Donem1SinavNotu2 END AS Donem1SinavNotu2, CASE Donem1SinavNotu3 WHEN -1 THEN null ELSE Donem1SinavNotu3 END AS Donem1SinavNotu3, CASE Donem1SinavNotu4 WHEN -1 THEN null ELSE Donem1SinavNotu4 END AS Donem1SinavNotu4, CASE Donem1SozluNotu1 WHEN -1 THEN null ELSE Donem1SozluNotu1 END AS Donem1SozluNotu1, CASE Donem1SozluNotu2 WHEN -1 THEN null ELSE Donem1SozluNotu2 END AS Donem1SozluNotu2, CASE Donem1SozluNotu3 WHEN -1 THEN null ELSE Donem1SozluNotu3 END AS Donem1SozluNotu3, CASE Donem1SozluNotu4 WHEN -1 THEN null ELSE Donem1SozluNotu4 END AS Donem1SozluNotu4, CASE Donem1OdevNotu WHEN -1 THEN null ELSE Donem1OdevNotu END AS Donem1OdevNotu, CASE Donem2SinavNotu1 WHEN -1 THEN null ELSE Donem2SinavNotu1 END AS Donem2SinavNotu1, CASE Donem2SinavNotu2 WHEN -1 THEN null ELSE Donem2SinavNotu2 END AS Donem2SinavNotu2, CASE Donem2SinavNotu3 WHEN -1 THEN null ELSE Donem2SinavNotu3 END AS Donem2SinavNotu3, CASE Donem2SinavNotu4 WHEN -1 THEN null ELSE Donem2SinavNotu4 END AS Donem2SinavNotu4, CASE Donem2SozluNotu1 WHEN -1 THEN null ELSE Donem2SozluNotu1 END AS Donem2SozluNotu1, CASE Donem2SozluNotu2 WHEN -1 THEN null ELSE Donem2SozluNotu2 END AS Donem2SozluNotu2, CASE Donem2SozluNotu3 WHEN -1 THEN null ELSE Donem2SozluNotu3 END AS Donem2SozluNotu3, CASE Donem2SozluNotu4 WHEN -1 THEN null ELSE Donem2SozluNotu4 END AS Donem2SozluNotu4, CASE Donem2OdevNotu WHEN -1 THEN null ELSE Donem2OdevNotu END AS Donem2OdevNotu, * FROM Ogrenciler o LEFT JOIN Notlar n ON o.OgrenciID=n.OgrenciID AND n.SezonID=@SezonID JOIN Siniflar s ON o.SinifID=s.SinifID WHERE s.SinifID=@veriID ORDER BY o.OgrenciAdi, o.OgrenciSoyadi", conn);
            sda.SelectCommand.Parameters.AddWithValue("@veriID", veriID);
            sda.SelectCommand.Parameters.AddWithValue("@SezonID", SezonID);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GrdView.DataSource = dt;
            GrdView.DataBind();
        }

        protected void gvDersDonem1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDersDonem1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDersDonem1.EditIndex = e.NewEditIndex;
            ListeleDO(gvDersDonem1);
        }

        protected void gvDersDonem1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NotlariGuncelle(sender, e, 1);
        }

        private void NotlariGuncelle(object sender, GridViewUpdateEventArgs e, int donem)
        {
            GridView gvOrtak = (GridView)sender;
            string[] Columnlar = new string[9];
            int a = 0;
            foreach (string name in Request.Form)
            {
                string temp = Request.Form[name];
                if (Regex.IsMatch(name, @"txtBox[0-9]{1,1}"))
                {
                    if (Request.Form[name] == null | Request.Form[name] == "")
                    {
                        Columnlar[a] = "-1";
                        a++;
                    }
                    else
                    {
                        try
                        {
                            int sayi = Convert.ToInt32(Request.Form[name]);
                            Columnlar[a] = sayi.ToString();
                        }
                        catch
                        {
                            Columnlar[a] = "-1";
                        }
                        a++;
                    }
                }
            }
            string OgrenciID = (gvOrtak.Rows[e.RowIndex].Cells[0].Controls[1] as Label).Text;
            string AltDersID = null;
            AltDersID = AltDersBul(OgrenciID);
            if (dbIslem.aynisiVarmi("Notlar", "OgrenciID", "SezonID", OgrenciID, SezonID))
            {
                dbIslem.dbHizliGuncelle("Notlar", "OgrenciID", OgrenciID, "Donem" + donem + "SozluNotu1", "Donem" + donem + "SozluNotu2", "Donem" + donem + "SozluNotu3", "Donem" + donem + "SozluNotu4", "Donem" + donem + "SinavNotu1", "Donem" + donem + "SinavNotu2", "Donem" + donem + "SinavNotu3", "Donem" + donem + "SinavNotu4", "Donem" + donem + "OdevNotu", Columnlar[0], Columnlar[1], Columnlar[2], Columnlar[3], Columnlar[4], Columnlar[5], Columnlar[6], Columnlar[7], Columnlar[8]);
            }
            else
            {
                if (AltDersID != null & SezonID != null)
                {
                    dbIslem.dbEkleVeriIslem("Notlar", null, null, "AltDersID", "OgrenciID", "Donem" + donem + "SozluNotu1", "Donem" + donem + "SozluNotu2", "Donem" + donem + "SozluNotu3", "Donem" + donem + "SozluNotu4", "Donem" + donem + "SinavNotu1", "Donem" + donem + "SinavNotu2", "Donem" + donem + "SinavNotu3", "Donem" + donem + "SinavNotu4", "Donem" + donem + "OdevNotu", "SezonID", AltDersID, OgrenciID, Columnlar[0], Columnlar[1], Columnlar[2], Columnlar[3], Columnlar[4], Columnlar[5], Columnlar[6], Columnlar[7], Columnlar[8], SezonID);
                }
            }
            gvOrtak.EditIndex = -1;
            ListeleDO(gvOrtak);
        }

        private string SezonIDBul()
        {
            string sznID = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Sezonlar ORDER BY SezonID DESC", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                sznID = sdr[0].ToString();
            }
            conn.Close();
            return sznID;
        }

        private string AltDersBul(string OgrenciID)
        {
            string AltDersID = null;
            SqlCommand cmd = new SqlCommand("SELECT altD.AltDersID FROM Ogrenciler o JOIN Siniflar s ON o.SinifID=s.SinifID JOIN AltDersler altD ON s.Kademe=altD.Kademe JOIN AnaDersler anaD ON anaD.AnaDersID=altD.AnaDersID JOIN Ogretmenler e ON e.Brans=anaD.AnaDersID WHERE o.OgrenciID=@OgrenciID AND e.OgretmenID=@OgretmenID", conn);
            cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
            cmd.Parameters.AddWithValue("@OgretmenID", ogretmenID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                AltDersID = sdr[0].ToString();
            }
            conn.Close();
            return AltDersID;
        }

        private string AnaDersBul()
        {
            string AnaDersAdi = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT o.OgretmenID, anaD.DersAdi, * FROM Ogretmenler o JOIN AnaDersler anaD ON o.Brans=anaD.AnaDersID JOIN AltDersler AltD ON anaD.AnaDersID=AltD.AnaDersID WHERE o.OgretmenID=@OgretmenID", conn);
            cmd.Parameters.AddWithValue("@OgretmenID", ogretmenID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                AnaDersAdi = sdr["DersAdi"].ToString();
            }
            conn.Close();
            return AnaDersAdi;
        }

        protected void gvDersDonem1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDersDonem1.EditIndex = -1;
            ListeleDO(gvDersDonem1);
        }

        protected void gvDersDonem2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDersDonem2.EditIndex = e.NewEditIndex;
            ListeleDO(gvDersDonem2);
        }

        protected void gvDersDonem2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NotlariGuncelle(sender, e, 2);
        }

        protected void gvDersDonem2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDersDonem2.EditIndex = -1;
            ListeleDO(gvDersDonem2);
        }

    }
}