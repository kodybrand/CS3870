﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Prog4/Prog4MasterPage.master" AutoEventWireup="false" CodeFile="Shopping.aspx.vb" Inherits="Prog4_Shopping" %>
<script runat="server">
'---------------------------------------------------------------------------------------------
' Class      : CS 3870CS 5870
'
' Name       : Kody Brand 
'
' UserName   : brandk
'
' Description: Shopping page where you can enter a product and get grand total.
'
'---------------------------------------------------------------------------------------------
</script>

<%@ MasterType VirtualPath="~/Prog4/Prog4MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog4Body" Runat="Server">
   <asp:Label ID="lblID" runat="server" Text="Product ID" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: center"></asp:Label>
    <asp:Label ID="lblName" runat="server" Text="Product Name" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center"></asp:Label>
    <asp:Label ID="lblPrice" runat="server" Text="Price" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center"></asp:Label>
    <br />
    <asp:TextBox ID="txtID" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:17.5%" AutoPostBack="True"></asp:TextBox>
    <asp:TextBox ID="txtName" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: right"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: right"></asp:TextBox>
    <br /><br /><br /><br />
    <asp:Label ID="lblQuanity" runat="server" Text="Quantity" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: center"></asp:Label>
    <br />
    <asp:TextBox ID="txtQuanity" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:17.5%"></asp:TextBox>
    <br /><br /><br /><br />
    <asp:Label ID="lblSub" runat="server" Text="Sub Total" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: center"></asp:Label>
    <asp:Label ID="lbltax" runat="server" Text="Tax" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center"></asp:Label>
    <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center"></asp:Label>
    <br />
    <asp:TextBox ID="txtSubTotal" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:17.5%"></asp:TextBox>
    <asp:TextBox ID="txtTax" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: right"></asp:TextBox>
    <asp:TextBox ID="txtGrandTotal" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: right"></asp:TextBox>
   <br /><br />
   <asp:Button ID="btnCompute" runat="server" Text="Compute" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left: 43%" />
</asp:Content>

