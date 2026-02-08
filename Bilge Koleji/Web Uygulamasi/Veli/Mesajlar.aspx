<%@ Page Title="" Language="C#" MasterPageFile="~/Veli/Main.Master" AutoEventWireup="true" CodeBehind="Mesajlar.aspx.cs" Inherits="Web_Uygulamasi.Veli.Mesajlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h3 id="anaBaslik" runat="server">
            Gelen Mesajlar</h3>
        <asp:HyperLink ID="msjLink" runat="server">HyperLink</asp:HyperLink>
    </center>
    <asp:GridView ID="GridView1" runat="server" Width="641px" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CellSpacing="2" ForeColor="#333333" GridLines="None" PageSize="30"
        OnRowDeleting="GridView1_RowDeleting" 
        onrowdatabound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MesajID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mesaj Başlık">
                <ItemTemplate>
                    <a href='MesajOku.aspx?ID=<%# Eval("MesajID") %>&Sayfa=<%# Request.QueryString["Sayfa"] ==null ? "1":Request.QueryString["Sayfa"] %>&Bolum=<%# Request.QueryString["Bolum"] %>'>
                        <%# Eval("Baslik") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Kimden">
                <ItemTemplate>
                    <a href="KullaniciDetay.aspx?ID=<%# Eval("IlgiliID") %>">
                        <%# Eval("IlgiliKisi") %>
                        (<%# Eval("Statu") %>)</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tarih">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Tarih") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Sil"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
