<%@ Page Title="" Language="VB" MasterPageFile="~/Prog6/Prog6MasterPage.master" AutoEventWireup="false" CodeFile="SetRoles.aspx.vb" Inherits="Prog6_Admin_SetRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog6Body" Runat="Server">

   <asp:TextBox ID="txtRoles" runat="server" style="position: relative; width:10%; margin-left:22.5%"></asp:TextBox> 
   <asp:DropDownList ID="lstUsers" runat="server" style="position: relative; width:15%; margin-left:32.5%"></asp:DropDownList>
   <br /> <br />

   <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" style="position: relative; width:15%; margin-left:65%" />
   <br /> <br />

   <asp:Button ID="btnAddRole" runat="server" Text="Add Role" style="position: relative; width:19%; margin-left:8.5%"/>
   <asp:Button ID="btnRemoveRole" runat="server" Text="Remove Role" style="position: relative; width:19%; margin-left:0%"/>
   <asp:Button ID="btnAddUserToRole" runat="server" Text="Add User To Role" style="position: relative; width:19%; margin-left:7%"/>
   <asp:Button ID="btnRemoveUserFromRole" runat="server" Text="Remove User From Fole" style="position: relative; width:19%; margin-left:0%" />
   <br /> <br />

   <asp:DropDownList ID="lstRoles" runat="server" style="position: relative; width:15%; margin-left:20%"></asp:DropDownList> <asp:DropDownList ID="lstUsersInRoles" runat="server" style="position: relative; width:15%; margin-left:30%"></asp:DropDownList>
   <br /> <br />

   <asp:TextBox ID="txtMessage" runat="server" style="position: relative; width:50%; margin-left:25%; height: 100px"></asp:TextBox>
   <br /> <br />

</asp:Content>

