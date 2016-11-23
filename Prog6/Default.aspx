<%@ Page Title="" Language="VB" MasterPageFile="~/Prog6/Prog6MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Prog6_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog6Body" Runat="Server">
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" style="color:#333333;border-collapse:collapse;z-index: 1; position: relative; width: 50%; margin-left:25%; align-items: center; height: 176px" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5">
      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      <Columns>
         <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" SortExpression="ProductID" >
         <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" >
         <ItemStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" DataFormatString="{0:c}" >
         <ItemStyle HorizontalAlign="Right" />
         </asp:BoundField>
         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
      </Columns>
      <EditRowStyle BackColor="#999999" />
      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
      <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
      <SortedAscendingCellStyle BackColor="#E9E7E2" />
      <SortedAscendingHeaderStyle BackColor="#506C8C" />
      <SortedDescendingCellStyle BackColor="#FFFDF8" />
      <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
   </asp:GridView>
</asp:Content>

