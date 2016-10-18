
<script runat="server">
'---------------------------------------------------------------------------------------------
' Class      : CS 3870CS 5870
'
' Name       : Kody Brand 
'
' UserName   : brandk
'
' Description: Page has datagrid view on it and can be sorted and paged through
'
'---------------------------------------------------------------------------------------------
</script>
<%@ Page Title="" Language="VB" MasterPageFile="~/Prog4/Prog4MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Prog4_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog4Body" Runat="Server">
   <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" style="background-color:White;border-color:#999999;border-width:1px;border-style:Solid;border-collapse:collapse;z-index: 1; position: relative; width: 60%; margin-left:20%; align-items: center; height: 176px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="5">
      <Columns>
         <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" SortExpression="ProductID">
         <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
         <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Unit Price" SortExpression="UnitPrice">
         <ItemStyle HorizontalAlign="Right" />
         </asp:BoundField>
         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
         <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
      </Columns>
      <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
   </asp:GridView>
</asp:Content>

