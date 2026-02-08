<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Uygulamasi.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Sayfası</title>
    <style type="text/css">
        .ana_div
        {
            width:300px;
            margin-left:auto;
            margin-right:auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br /><br /><br /><br /><br /><br /><br />
    <div class="ana_div">
        <asp:Login ID="Login1" runat="server" BorderStyle="Solid" 
            FailureText="Giriş yapılamadı. Lütfen tekrar deneyiniz." 
            LoginButtonText="Giriş Yap" PasswordLabelText="Şifre:" 
            PasswordRequiredErrorMessage="Şifre kısmı boş." RememberMeText="Beni hatırla" 
            TitleText="Giriş" UserNameLabelText="TC Kimlik No:" 
            UserNameRequiredErrorMessage="boş bırakılamaz." Width="289px" 
            DestinationPageUrl="~/Director.aspx">
        </asp:Login>
    </div>
    </form>
</body>
</html>
