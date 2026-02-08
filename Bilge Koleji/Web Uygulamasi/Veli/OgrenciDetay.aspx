<%@ Page Title="" Language="C#" MasterPageFile="~/Veli/Main.Master" AutoEventWireup="true" CodeBehind="OgrenciDetay.aspx.cs" Inherits="Web_Uygulamasi.Veli.OgrenciDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 id="Baslik" runat="server"></h3>
    <b>1.Dönem Notları</b>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="DersAdi" HeaderText="Ders Adı">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s1" HeaderText="1.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s2" HeaderText="2.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s3" HeaderText="3.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s4" HeaderText="4.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y1" HeaderText="1.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y2" HeaderText="2.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y3" HeaderText="3.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y4" HeaderText="4.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Odev" HeaderText="Ödv">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <b>2. Dönem Notları</b>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="DersAdi" HeaderText="Ders Adı">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s1" HeaderText="1.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s2" HeaderText="2.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s3" HeaderText="3.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="s4" HeaderText="4.S">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y1" HeaderText="1.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y2" HeaderText="2.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y3" HeaderText="3.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="y4" HeaderText="4.Y">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Odev" HeaderText="Ödv">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <b>Devamsızlık: </b>
    <asp:Literal ID="ltrTopDevasizlik" runat="server"></asp:Literal>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        Width="100%" CellPadding="1">
        <Columns>
            <asp:TemplateField HeaderText="Tarih">
                <ItemTemplate>
                    <%# Convert.ToDateTime(Eval("Tarih")).ToString("dd.MM.yyyy") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Tarih") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Gün">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Gun") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Gun") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Özel Neden">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Sebep") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Sebep") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
