<%@ Page Title="" Language="VB" MasterPageFile="~/Prog7/Prog7MasterPage.master" AutoEventWireup="false" CodeFile="Checkout.aspx.vb" Inherits="Prog7_Member_Checkout" %>
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
<%@ Register Src="~/Prog7/ShoppingItem.ascx" 
             TagPrefix="uc1" 
             TagName="ShoppingItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog7Body" Runat="Server">
   <asp:Panel ID="Panel1" runat="server"></asp:Panel>
   <br /><br />
   <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" style="position: relative; width: 16%; margin-left: 42%; text-align: right"></asp:TextBox>
   <br /><br />

   <asp:Button ID="btnCheckout" runat="server" Text="Checkout" style="position: relative; width: 10%; margin-left: 45%"/>
</asp:Content>