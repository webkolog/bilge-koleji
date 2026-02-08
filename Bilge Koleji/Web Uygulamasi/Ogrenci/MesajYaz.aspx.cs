using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;

namespace Web_Uygulamasi.Ogrenci
{
    public partial class MesajYaz : System.Web.UI.Page
    {
        string veriId;
        protected void Page_Load(object sender, EventArgs e)
        {
            veriId = Request.QueryString["ID"];
            if (veriId != null)
            {
                SqlCommand cmd;
                SqlDataReader sdr;
                SqlConnection conn = dbIslem.baglantiOlustur();
                if (dbIslem.aynisiVarmi("Ogrenciler", "OgrenciID", veriId))
                {
                    cmd = new SqlCommand("SELECT * FROM Ogrenciler WHERE OgrenciID = @OgrenciID", conn);
                    cmd.Parameters.AddWithValue("@OgrenciID", veriId);
                    conn.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        hlKime.Text = sdr["OgrenciAdi"] + " " + sdr["OgrenciSoyadi"] + " (Öğrenci)";
                        hlKime.NavigateUrl = "KullaniciDetay.aspx?ID=" + veriId;
                    }
                    conn.Close();
                }
                else if (dbIslem.aynisiVarmi("Ogretmenler", "OgretmenID", veriId))
                {
                    cmd = new SqlCommand("SELECT * FROM Ogretmenler WHERE OgretmenID = @OgretmenID", conn);
                    cmd.Parameters.AddWithValue("@OgretmenID", veriId);
                    conn.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        string gorev = "Öğretmen";
                        switch (Convert.ToInt32(sdr["Gorev"]))
                        {
                            case 1:
                                {
                                    gorev = "Müdür";
                                    break;
                                }
                            case 2:
                                {
                                    gorev = "Müdür Yardımcısı";
                                    break;
                                }
                        }
                        hlKime.Text = sdr["OgretmenAdi"] + " " + sdr["OgretmenSoyadi"] + " (" + gorev + ")";
                        hlKime.NavigateUrl = "KullaniciDetay.aspx?ID=" + veriId;
                    }
                    conn.Close();
                }

                string msjID = Request.QueryString["MID"];
                if (msjID != null)
                {
                    if (dbIslem.aynisiVarmi("Mesajlar", "MesajID", msjID))
                    {
                        cmd = new SqlCommand("SELECT * FROM Mesajlar WHERE MesajID = @MesajID", conn);
                        cmd.Parameters.AddWithValue("@MesajID", msjID);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            txtBaslik.Text = "Ce: " + (sdr["Baslik"].ToString().Length >= 50 ? sdr["Baslik"].ToString().Substring(0, 46) : sdr["Baslik"].ToString());
                        }
                        conn.Close();
                    }
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (veriId != "")
            {
                if (dbIslem.aynisiVarmi("aspnet_Membership", "UserId", veriId))
                {
                    string sonuc = dbIslem.dbEkleVeriIslem("Mesajlar", null, null, "Baslik", "Mesaj", "KimdenID", "KimeID", "OkunduMu", "Tarih", txtBaslik.Text, txtMesaj.Text, Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString(), veriId, "0", DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                    if (sonuc.Length > 0)
                        Response.Redirect("Default.aspx");
                }
            }
        }
    }
}