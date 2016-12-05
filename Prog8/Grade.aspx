<%@ Page Title="" Language="VB" MasterPageFile="~/Prog8/Prog8MasterPage.master" AutoEventWireup="false" CodeFile="Grade.aspx.vb" Inherits="Prog8_Grade" %>
<script runat="server">
'---------------------------------------------------------------------------------------------
' Class      : CS 3870CS 5870
'
' Name       : Kody Brand 
'
' UserName   : brandk
'
' Description: This page displays current grades and allows users to update grades.
'
'---------------------------------------------------------------------------------------------
</script>
<%@ Register Src="~/Prog8/ScoreToGrade.ascx" 
             TagPrefix="uc1" 
             TagName="ScoreToGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog8Body" Runat="Server">
   <asp:Panel ID="Panel1" runat="server" style="position: relative; margin-left: 35%">

   </asp:Panel>
   <asp:TextBox ID="txtTotalPercentage" runat="server" style="position: relative; top: 100px; width: 10%; margin-left: 35%; text-align: center" ReadOnly="True"></asp:TextBox>
   <asp:TextBox ID="txtTotalGrade" runat="server" style="position: relative; top: 100px; width: 10%; margin-left: 10%; text-align: center" ReadOnly="True"></asp:TextBox>
</asp:Content>

