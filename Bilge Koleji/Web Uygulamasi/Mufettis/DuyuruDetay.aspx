<%@ Page Title="" Language="C#" MasterPageFile="~/Mufettis/Main.Master" AutoEventWireup="true"
    CodeBehind="DuyuruDetay.aspx.cs" Inherits="Web_Uygulamasi.Mufettis.DuyuruDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <span class="comment">
                <asp:HyperLink ID="hlYazan" runat="server"></asp:HyperLink></span>
        </div>
    </div>
</asp:Content>
