<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci/Main.Master" AutoEventWireup="true"
    CodeBehind="DosyaGonder.aspx.cs" Inherits="Web_Uygulamasi.Ogrenci.DosyaGonder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Dosya Gönder</h3>
    <table>
        <tr>
            <td align="right">
                Dosya Adı:
            </td>
            <td>
                <asp:TextBox ID="txtDosyaAdi" runat="server" ValidationGroup="Grup1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDosyaAdi"
                    Display="Dynamic" ErrorMessage="Dosya adı yazmadınız!" ValidationGroup="Grup1">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
        <td align="right">
        Öğretmen:
        </td>
        <td>
            <asp:DropDownList ID="ddlOgretmen" runat="server" DataTextField="Ogretmen" DataValueField="OgretmenID">


            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="ddlOgretmen" ErrorMessage="Öğretmen Seçmediniz!" 
                ValidationGroup="Grup1">*</asp:RequiredFieldValidator>
        </td>
        </tr>

        <tr>
            <td align="right">
                Dosya:
            </td>
            <td>
                <asp:FileUpload ID="fuDosya" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fuDosya"
                    ErrorMessage="Dosya Seçmediniz" ValidationGroup="Grup1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnGonder" runat="server" Text="Gönder" OnClick="btnGonder_Click"
                    ValidationGroup="Grup1" /><br />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"
                    ValidationGroup="Grup1">*</asp:CustomValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Grup1" />
            </td>
        </tr>
    </table>
</asp:Content>
