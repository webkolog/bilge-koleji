<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci/Main.Master" AutoEventWireup="true" CodeBehind="Devamsizlik.aspx.cs" Inherits="Web_Uygulamasi.Ogrenci.Devamsizlik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3>Devamsızlık</h3>
<b>Toplam Devamsızlık: </b>
    <asp:Literal ID="ltrTopDevasizlik" runat="server"></asp:Literal>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%" CellPadding="1">
        <Columns>
            <asp:BoundField DataField="Tarih" HeaderText="Tarih">
            </asp:BoundField>
            <asp:BoundField DataField="Gun" HeaderText="Gün">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Sebep" HeaderText="Özel Neden">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
