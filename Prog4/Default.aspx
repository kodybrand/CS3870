<%@ Page Title="" Language="VB" MasterPageFile="~/Prog4/Prog4MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Prog4_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog4Body" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>

