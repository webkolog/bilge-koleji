<%@ Page Title="" Language="C#" MasterPageFile="~/Mufettis/Main.Master" AutoEventWireup="true"
    CodeBehind="MesajOku.aspx.cs" Inherits="Web_Uygulamasi.Mufettis.MesajOku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="hlGeriGit" runat="server">Geri Git</asp:HyperLink>
    <div class="post">
        <div class="post_h">
        </div>
        <div class="postcontent">
            <span class="date">
                <asp:Literal ID="ltrTarih" runat="server"></asp:Literal></span>
            <h2>
                <asp:Literal ID="ltrBaslik" runat="server"></asp:Literal></h2>
            <p>
                <asp:Literal ID="ltrMesaj" runat="server"></asp:Literal></p>
        </div>
        <div class="post_b">
            <span class="permalink">
                <asp:HyperLink ID="hlCevap" runat="server">Cevap Yaz</asp:HyperLink></span><span
                    class="comment"><asp:HyperLink ID="hlYazan" runat="server"></asp:HyperLink>
                </span>
        </div>
    </div>
</asp:Content>
