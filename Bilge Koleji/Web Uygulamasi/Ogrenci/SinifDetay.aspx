<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci/Main.Master" AutoEventWireup="true" CodeBehind="SinifDetay.aspx.cs" Inherits="Web_Uygulamasi.Ogrenci.SinifDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Ogrenci" runat="server" class="post">
        <div class="post_h">
        </div>
        <div class="postcontent">
            <asp:Label ID="lblDers" runat="server" Text="Label" class="date"></asp:Label>
            <h2>
                <asp:Literal ID="ltrSinifAdi" runat="server"></asp:Literal></h2>
            <p>
                <b>Öğrenciler: </b>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="No" DataField="OkulNo" />
                        <asp:BoundField HeaderText="Öğrenci Adı" DataField="Ogrenci" />
                        <asp:BoundField HeaderText="Cinsiyet" DataField="Cins" />
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
            <p>
                <b>Ders Programı: </b>
                <table width="100%" border="1" cellpadding="1" cellpadding="1">
                    <tr>
                        <th width="5%">
                            Saat
                        </th>
                        <th width="19%">
                            Pazartesi
                        </th>
                        <th width="19%">
                            Salı
                        </th>
                        <th width="19%">
                            Çarşamba
                        </th>
                        <th width="19%">
                            Perşembe
                        </th>
                        <th width="19%">
                            Cuma
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# Eval("Saat") %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%# Eval("g1Ders") %></b><br />
                                    <%# Eval("g1Ogretmen") %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%# Eval("g2Ders") %></b><br />
                                    <%# Eval("g2Ogretmen") %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%# Eval("g3Ders") %></b><br />
                                    <%# Eval("g3Ogretmen") %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%# Eval("g4Ders") %></b><br />
                                    <%# Eval("g4Ogretmen") %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%# Eval("g5Ders") %></b><br />
                                    <%# Eval("g5Ogretmen") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </p>
        </div>
        <div class="post_b">
            <span class="permalink">Rehber Öğretmen:
                <asp:HyperLink ID="hlRehberOgretmen" runat="server"></asp:HyperLink>
            </span>
        </div>
    </div>
</asp:Content>
