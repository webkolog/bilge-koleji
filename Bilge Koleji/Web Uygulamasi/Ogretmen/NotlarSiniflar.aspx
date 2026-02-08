<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen/Main.Master" AutoEventWireup="true"
    CodeBehind="NotlarSiniflar.aspx.cs" Inherits="Web_Uygulamasi.Ogretmen.NotlarSiniflar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Derslerine Girdiğiniz Sınıflar</h3>
    <asp:Table ID="tblDersSinif" runat="server" Width="100%" border="1" CellPadding="1" CellSpacing="2">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Width="20%" ColumnSpan="2">Sınıf</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="30%">Dönem</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="30%">Derslik</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="20%">Kat</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
