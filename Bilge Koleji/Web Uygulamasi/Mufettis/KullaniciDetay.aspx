<%@ Page Title="" Language="C#" MasterPageFile="~/Mufettis/Main.Master" AutoEventWireup="true"
    CodeBehind="KullaniciDetay.aspx.cs" Inherits="Web_Uygulamasi.Mufettis.KullaniciDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divOgrenci" runat="server" class="post">
        <div class="post_h">
        </div>
        <div class="postcontent">
            <span class="date">Öğrenci</span>
            <h2>
                <asp:Literal ID="ltrOgrenciAdi" runat="server"></asp:Literal></h2>
            <p>
                <b>Cinsiyet: </b>
                <asp:Literal ID="ltrOgrenciCinsiyet" runat="server"></asp:Literal><br />
                <b>Sınıf: </b>
                <asp:HyperLink ID="hlOgrenciSinif" runat="server"></asp:HyperLink><br />
                <b>Okul No: </b>
                <asp:Literal ID="ltrOgrenciOkulNo" runat="server"></asp:Literal><br />
                <b>Durumu: </b>
                <asp:Literal ID="ltrOgrenciDurumu" runat="server"></asp:Literal><br />
                <b>Bitirdiği Okul: </b>
                <asp:Literal ID="ltrOgrenciOkul" runat="server"></asp:Literal><br />
                <b>Kayıt Yılı: </b>
                <asp:Literal ID="ltrOgrenciKayitYili" runat="server"></asp:Literal>
            </p>
        </div>
        <div class="post_b">
            <span class="comment">
                <asp:HyperLink ID="hlOgrenciMG" runat="server">Mesaj Gönder</asp:HyperLink>
            </span>
        </div>
    </div>
    <div id="divOgretmen" runat="server" class="post">
        <div class="post_h">
        </div>
        <div class="postcontent">
            <span class="date">Öğretmen</span>
            <h2>
                <asp:Literal ID="ltrOgretmenAdi" runat="server"></asp:Literal></h2>
            <p>
                <b>Branş: </b>
                <asp:Literal ID="ltrOgretmenBrans" runat="server"></asp:Literal><br />
                <b>Görev: </b>
                <asp:Literal ID="ltrOgretmenGorev" runat="server"></asp:Literal><br />
                <b>Sınıf: </b>
                <asp:HyperLink ID="hlOgretmenSinif" runat="server"></asp:HyperLink><br />
                <b>Dersine Girdiği Sınıflar:</b>
                <asp:BulletedList ID="blOgretmenSiniflari" DisplayMode="HyperLink" Target="_blank"
                    runat="server">
                </asp:BulletedList>
            </p>
            <b>Ders Programı:</b>
            <asp:Table ID="tblOgretmenDP" runat="server" Width="100%" border="1" CellPadding="1"
                CellSpacing="2">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Gün"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Saat"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Sınıf"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div class="post_b">
            <span class="comment">
                <asp:HyperLink ID="hlOgretmenMG" runat="server">Mesaj Gönder</asp:HyperLink>
            </span>
        </div>
    </div>
    <div id="divVeli" runat="server" class="post">
        <div class="post_h">
        </div>
        <div class="postcontent">
            <span class="date">Veli</span>
            <h2>
                <asp:Literal ID="ltrVeliAdi" runat="server"></asp:Literal></h2>
            <p>
                <b>Öğrencileri: </b>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CellSpacing="2" ForeColor="#333333" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Okul No">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OkulNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("OkulNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Öğrenci Adı">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Ogrenci") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Ogrenci") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cinsiyet">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cins") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cins") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sınıf">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Sinif") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Sinif") %>'></asp:Label>
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
            </p>
        </div>
        <div class="post_b">
            <span class="comment">
                <asp:HyperLink ID="HyperLink2" runat="server">Mesaj Gönder</asp:HyperLink>
            </span>
        </div>
    </div>
    <div id="divMuffetis" runat="server" class="post">
        <div class="post_h">
        </div>
        <div class="postcontent">
            <span class="date">Müfettis</span>
            <h2>
                <asp:Literal ID="ltrMufettisAdi" runat="server"></asp:Literal></h2>
            <p>
            </p>
        </div>
        <div class="post_b">
            <span class="comment">
                <asp:HyperLink ID="HyperLink4" runat="server">Mesaj Gönder</asp:HyperLink>
            </span>
        </div>
    </div>
</asp:Content>
