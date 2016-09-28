<%@ Page Title="" Language="VB" MasterPageFile="~/Prog3/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Prog3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" 
     style="z-index: 1; position: relative; width: 50%; margin-left:25%; 
     align-items: center; height: 176px" >

   <Columns>
      <asp:BoundField DataField="ProductID" HeaderText="Product ID" >
        <ItemStyle HorizontalAlign="Center"  Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="ProductName" HeaderText="Product Name" >
        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" 
        DataFormatString="{0:c}" HtmlEncode="False" >
        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="Description" HeaderText="Description">
        <ItemStyle HorizontalAlign="right" Width="10%"></ItemStyle></asp:BoundField>
   </Columns>

</asp:GridView>

</asp:Content>

