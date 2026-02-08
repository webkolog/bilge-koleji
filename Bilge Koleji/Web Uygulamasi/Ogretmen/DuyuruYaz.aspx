<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen/Main.Master" AutoEventWireup="true"
    CodeBehind="DuyuruYaz.aspx.cs" Inherits="Web_Uygulamasi.Ogretmen.DuyuruYaz" %>

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
            Duyuru Yaz</h3>
        <table>
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
                <td align="right">
                    Kitle Türü:
                </td>
                <td align="left" class="style1">
                    <asp:DropDownList ID="ddlKitle" runat="server" Width="100px">
                        <asp:ListItem Selected="True" Value="0">Herkes</asp:ListItem>
                        <asp:ListItem Value="1">Sınıfa Özel</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
