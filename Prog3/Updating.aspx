<%@ Page Title="" Language="VB" MasterPageFile="~/Prog3/MasterPage.master" AutoEventWireup="false" CodeFile="Updating.aspx.vb" Inherits="Prog3_Updating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server" >

    <asp:Button ID="btnFirst" runat="server" Text="First" style="z-index: 1; position: relative; width: 10%; margin-left:22.5%; text-align: center"/>
    <asp:Button ID="btnPrevious" runat="server" Text="Previous" style="z-index: 1; position: relative; width: 10%; margin-left:5%; text-align: center" />
    <asp:Button ID="btnNext" runat="server" Text="Next" style="z-index: 1; position: relative; width: 10%; margin-left:5%; text-align: center"/>
    <asp:Button ID="btnLast" runat="server" Text="Last" style="z-index: 1; position: relative; width: 10%; margin-left:5%; text-align: center" />
    <br /><br /><br /><br />
    <asp:Label ID="lblProdID" runat="server" Text="Product ID" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:12.5%; text-align: center"></asp:Label>
    <asp:Label ID="lblProdName" runat="server" Text="Product Name" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:5%; text-align: center"></asp:Label>
    <asp:Label ID="lblProdUnitPrice" runat="server" Text="Unit Price" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:5%; text-align: center"></asp:Label>
    <asp:Label ID="lblDesc" runat="server" Text="Description" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:5%; text-align: center"></asp:Label>
    <br />
    <asp:TextBox ID="txtID" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:12.5%"></asp:TextBox>
    <asp:TextBox ID="txtName" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:5%"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:5%; text-align: right"></asp:TextBox>
    <asp:TextBox ID="txtDescription" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:5%"></asp:TextBox>
    <br /><br /><br /><br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" style="z-index: 1; position: relative; width: 10%; margin-left:25%; text-align: center"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" style="z-index: 1; position: relative; width: 10%; margin-left:10%; text-align: center"/>
    <asp:Button ID="btnNew" runat="server" Text="New" style="z-index: 1; position: relative; width: 10%; margin-left:10%; text-align: center" />
    <br /><br /><br /><br />
    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" style="height:200px;z-index: 1; position: relative; width: 40%; margin-left:30%"></asp:TextBox>
<br />
</asp:Content>

