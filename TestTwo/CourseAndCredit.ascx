<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CourseAndCredit.ascx.vb" Inherits="TestTwo_CourseAndCredit" %>
<asp:TextBox ID="txtCourseID" runat="server" ReadOnly="True"></asp:TextBox>
<asp:TextBox ID="txtCourseName" runat="server" ReadOnly="True"></asp:TextBox>
<asp:TextBox ID="txtCredits" runat="server" AutoPostBack="True"></asp:TextBox>
<asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label><br />