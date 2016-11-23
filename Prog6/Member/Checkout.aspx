<%@ Page Title="" Language="VB" MasterPageFile="~/Prog6/Prog6MasterPage.master" AutoEventWireup="false" CodeFile="Checkout.aspx.vb" Inherits="Prog6_Member_Checkout" %>
<%@ Register Src="~/Prog6/ShoppingItem.ascx" 
             TagPrefix="uc1" 
             TagName="ShoppingItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog6Body" Runat="Server">
   <asp:Panel ID="Panel1" runat="server"></asp:Panel>
   <br /><br />
   <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" style="position: relative; width: 16%; margin-left: 42%; text-align: right"></asp:TextBox>
   <br /><br />

   <asp:Button ID="btnCheckout" runat="server" Text="Checkout" style="position: relative; width: 10%; margin-left: 45%"/>
</asp:Content>

