<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen/Main.Master" AutoEventWireup="true"
    CodeBehind="MesajYaz.aspx.cs" Inherits="Web_Uygulamasi.Ogretmen.MesajYaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 327px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h3>
            Mesaj Yaz</h3>
        <table>
            <tr>
                <td align="right">
                    Kime:
                </td>
                <td align="left" class="style1">
                    <asp:HyperLink ID="hlKime" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Başlık:
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtBaslik" runat="server" Width="311px" ValidationGroup="Grup1"
                        MaxLength="250"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBaslik"
                        Display="Dynamic" ErrorMessage="Başlık Yazmadınız!" 
                        ValidationGroup="Grup1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Mesaj:
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtMesaj" runat="server" Height="179px" TextMode="MultiLine" Width="312px"
                        ValidationGroup="Grup1" MaxLength="4000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMesaj"
                        Display="Dynamic" ErrorMessage="Mesaj Yazmadınız!" ValidationGroup="Grup1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnKaydet" runat="server" Text="Gönder" ValidationGroup="Grup1" OnClick="btnKaydet_Click" />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Grup1" />
                    <br />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
