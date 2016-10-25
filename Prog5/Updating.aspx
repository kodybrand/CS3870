﻿<script runat="server">
'---------------------------------------------------------------------------------------------
' Class      : CS 3870CS 5870
'
' Name       : Kody Brand 
'
' UserName   : brandk
'
' Description: You can view, edit, and update products.
'
'---------------------------------------------------------------------------------------------
</script>
<%@ Page Title="" Language="VB" MasterPageFile="~/Prog5/MasterPage.master" AutoEventWireup="false" CodeFile="Updating.aspx.vb" Inherits="Prog5_Updating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog5Body" Runat="Server">
   <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AllowPaging="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" style="color:#333333;height:50px;width:340px;border-collapse:collapse;position: relative; width: 50%; margin-left: 25%">
      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
      <EditRowStyle BackColor="#999999" />
      <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
      <Fields>
         <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
         <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
         <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
      </Fields>
      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
      <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
   </asp:DetailsView>
   <br /><br /><br /><br />
   <asp:TextBox ID="txtMsg" runat="server" style="height:200px;z-index: 1; position: relative; width: 40%; margin-left:30%"></asp:TextBox>
</asp:Content>

