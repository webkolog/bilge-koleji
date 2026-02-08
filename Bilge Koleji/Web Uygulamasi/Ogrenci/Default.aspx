<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Uygulamasi.Ogrenci.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <div class="post">
                <div class="post_h">
                </div>
                <div class="postcontent">
                    <span class="date">
                        <%# Convert.ToDateTime(Eval("Tarih")).ToString("dd MMMM yyyy") %></span>
                    <h2>
                        <%# Eval("Baslik") %></h2>
                    <p>
                        <%# Eval("Mesaj") %></p>
                </div>
                <div class="post_b">
                    <span class="permalink"><a href="DuyuruDetay.aspx?id=<%# Eval("DuyuruID") %>">Devamı</a></span><span class="comment"><a href="KullaniciDetay.aspx?ID=<%# Eval("YazanID") %>"><%# Eval("Ogretmen") %> (<%# Eval("Statu") %>)</a></span></div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div id="pagination">
        <span class="alignleft">Sayfalar:&nbsp;
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" QueryStringField="Sayfa"
                PageSize="10">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </span><span class="alignright">&nbsp;</span></div>
</asp:Content>
