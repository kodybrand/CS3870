<%@ Page Title="" Language="VB" MasterPageFile="~/Prog9/Prog9MasterPage.master" AutoEventWireup="false" CodeFile="AllProducts.aspx.vb" Inherits="Prog9_AllProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog9Body" Runat="Server">
   <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="color:#333333;border-collapse:collapse;position: relative; width: 30%; margin-left: 33%">
      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

