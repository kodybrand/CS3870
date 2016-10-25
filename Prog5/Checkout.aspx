<script runat="server">
'---------------------------------------------------------------------------------------------
' Class      : CS 3870CS 5870
'
' Name       : Kody Brand 
'
' UserName   : brandk
'
' Description: The checkout page displays the items that have been added to the cart.
'
'---------------------------------------------------------------------------------------------
</script>
<%@ Page Title="" Language="VB" MasterPageFile="~/Prog5/MasterPage.master" AutoEventWireup="false" CodeFile="Checkout.aspx.vb" Inherits="Prog5_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog5Body" Runat="Server">
   <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="color:#333333;border-collapse:collapse;z-index: 1; position: relative; width: 50%; margin-left:25%; 
     align-items: center; height: 176px">
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

