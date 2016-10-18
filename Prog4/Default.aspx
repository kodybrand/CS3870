<%@ Page Title="" Language="VB" MasterPageFile="~/Prog4/Prog4MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Prog4_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog4Body" Runat="Server">
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="AccessDataSource1">
      <Columns>
         <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
         <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
         <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
      </Columns>
   </asp:GridView>
   <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/UWPCS3870.accdb" DeleteCommand="DELETE FROM [Product] WHERE [ProductID] = ?" InsertCommand="INSERT INTO [Product] ([ProductID], [ProductName], [UnitPrice], [Description]) VALUES (?, ?, ?, ?)" SelectCommand="SELECT * FROM [Product] ORDER BY [ProductID]" UpdateCommand="UPDATE [Product] SET [ProductName] = ?, [UnitPrice] = ?, [Description] = ? WHERE [ProductID] = ?">
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
   </asp:AccessDataSource>
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UWPCS3870ConnectionString %>" SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
</asp:Content>

