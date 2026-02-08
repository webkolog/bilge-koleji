<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Director.aspx.cs" Inherits="Web_Uygulamasi.Director" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
            string KullaniciAdi = null, Rutbe = null;
            KullaniciAdi = Membership.GetUser(HttpContext.Current.User.Identity.Name).ToString();
            if (KullaniciAdi != null)
            {
                Rutbe = Roles.GetRolesForUser(KullaniciAdi)[0];
                switch (Rutbe)
                {
                    case "Müfettiş":
                        {
                            Response.Redirect("Mufettis");
                            break;
                        }
                    case "Öğrenci":
                        {
                            Response.Redirect("Ogrenci");
                            break;
                        }
                    case "Öğretmen":
                        {
                            Response.Redirect("Ogretmen");
                            break;
                        }
                    case "Veli":
                        {
                            Response.Redirect("Veli");
                            break;
                        }
                }
            }
            else
            {
                Response.Write("Hata!");
            }
        %>
    </div>
    </form>
</body>
</html>
