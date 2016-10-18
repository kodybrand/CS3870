<%@ Page Title="" Language="VB" MasterPageFile="~/Prog4/Prog4MasterPage.master" AutoEventWireup="false" CodeFile="Updating.aspx.vb" Inherits="Prog4_Updating" %>
<script runat="server">
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
<asp:Content ID="Content1" ContentPlaceHolderID="Prog4Body" Runat="Server">
   <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" Height="50px" Width="125px" style="border: 1px None #DEBA84; background-color:#DEBA84; height:50px;width:125px; position: relative; width: 50%; margin-left: 25%; top: 1px; left: 0px;" cellpadding="3" cellspacing="2">
      <Fields>
         <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
         <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
         <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
         <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
      </Fields>
      <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
   </asp:DetailsView>
   <br />
   <br />
   <br />
   <asp:TextBox ID="txtMsg" runat="server" style="height:200px;z-index: 1; position: relative; width: 40%; margin-left:30%"></asp:TextBox>
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" DeleteCommand="DELETE FROM [Product] WHERE [ProductID] = ?" InsertCommand="INSERT INTO [Product] ([ProductID], [ProductName], [UnitPrice], [Description]) VALUES (?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [Product] ORDER BY [ProductID]" UpdateCommand="UPDATE [Product] SET [ProductName] = ?, [UnitPrice] = ?, [Description] = ? WHERE [ProductID] = ?">
      <DeleteParameters>
         <asp:Parameter Name="ProductID" Type="String" />
      </DeleteParameters>
      <InsertParameters>
         <asp:Parameter Name="ProductID" Type="String" />
         <asp:Parameter Name="ProductName" Type="String" />
         <asp:Parameter Name="UnitPrice" Type="Double" />
         <asp:Parameter Name="Description" Type="String" />
      </InsertParameters>
      <UpdateParameters>
         <asp:Parameter Name="ProductName" Type="String" />
         <asp:Parameter Name="UnitPrice" Type="Double" />
         <asp:Parameter Name="Description" Type="String" />
         <asp:Parameter Name="ProductID" Type="String" />
      </UpdateParameters>
   </asp:SqlDataSource>
</asp:Content>

