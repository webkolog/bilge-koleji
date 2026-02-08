<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen/Main.Master" AutoEventWireup="true"
    CodeBehind="NotlarSinifDetay.aspx.cs" Inherits="Web_Uygulamasi.Ogretmen.NotlarSinifDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="NotlarSiniflar.aspx">Diğer Sınıflar</a><br />
    <h3 id="Baslik" runat="server"></h3>
    <div id="Ders" runat="server">
        <b>Dönem: </b>
        <asp:Literal ID="ltrDonem" runat="server"></asp:Literal><br />
        <b>Ders: </b>
        <asp:Literal ID="ltrDers" runat="server"></asp:Literal>
        <br />
        <asp:GridView ID="gvDersDonem1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CellSpacing="2" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="gvDersDonem1_RowDataBound"
            OnRowCancelingEdit="gvDersDonem1_RowCancelingEdit" OnRowEditing="gvDersDonem1_RowEditing"
            OnRowUpdating="gvDersDonem1_RowUpdating" DataKeyNames="OgrenciID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OgrenciID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OgrenciID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Öğrenci Adı">
                    <EditItemTemplate>
                        <%# Eval("Ogrenci") %>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Ogrenci") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="1.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox1" runat="server" Text='<%# Bind("Donem1SozluNotu1") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Donem1SozluNotu1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox2" runat="server" Text='<%# Bind("Donem1SozluNotu2") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Donem1SozluNotu2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox3" runat="server" Text='<%# Bind("Donem1SozluNotu3") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Donem1SozluNotu3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="4.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox4" runat="server" Text='<%# Bind("Donem1SozluNotu4") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Donem1SozluNotu4") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="1.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox5" runat="server" Text='<%# Bind("Donem1SinavNotu1") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Donem1SinavNotu1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox6" runat="server" Text='<%# Bind("Donem1SinavNotu2") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Donem1SinavNotu2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox7" runat="server" Text='<%# Bind("Donem1SinavNotu3") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Donem1SinavNotu3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="4.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox8" runat="server" Text='<%# Bind("Donem1SinavNotu4") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Donem1SinavNotu4") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ö">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox9" runat="server" Text='<%# Bind("Donem1OdevNotu") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Donem1OdevNotu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="İşlem" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Güncelle"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="İptal"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Düzenle"></asp:LinkButton>
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
        <asp:GridView ID="gvDersDonem2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CellSpacing="2" ForeColor="#333333" GridLines="None" Width="100%" OnRowCancelingEdit="gvDersDonem2_RowCancelingEdit"
            OnRowEditing="gvDersDonem2_RowEditing" OnRowUpdating="gvDersDonem2_RowUpdating">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OgrenciID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OgrenciID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Öğrenci Adı">
                    <EditItemTemplate>
                        <%# Eval("Ogrenci") %>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Ogrenci") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="1.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox1" runat="server" Text='<%# Bind("Donem2SozluNotu1") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Donem2SozluNotu1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox2" runat="server" Text='<%# Bind("Donem2SozluNotu2") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Donem2SozluNotu2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox3" runat="server" Text='<%# Bind("Donem2SozluNotu3") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Donem2SozluNotu3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="4.S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox4" runat="server" Text='<%# Bind("Donem2SozluNotu4") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Donem2SozluNotu4") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="1.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox5" runat="server" Text='<%# Bind("Donem2SinavNotu1") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Donem2SinavNotu1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox6" runat="server" Text='<%# Bind("Donem2SinavNotu2") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Donem2SinavNotu2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox7" runat="server" Text='<%# Bind("Donem2SinavNotu3") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Donem2SinavNotu3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="4.Y">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox8" runat="server" Text='<%# Bind("Donem2SinavNotu4") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Donem2SinavNotu4") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ö">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBox9" runat="server" Text='<%# Bind("Donem2OdevNotu") %>' Width="25"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Donem2OdevNotu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="İşlem" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Güncelle"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="İptal"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Düzenle"></asp:LinkButton>
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
    </div>
</asp:Content>
