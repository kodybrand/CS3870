<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ScoreToGrade.ascx.vb" Inherits="Prog8_ScoreToGrade" %>
<script runat="server">
'---------------------------------------------------------------------------------------------
' Class      : CS 3870CS 5870
'
' Name       : Kody Brand 
'
' UserName   : brandk
'
' Description: User Control for the grade
'
'---------------------------------------------------------------------------------------------
</script>
<asp:TextBox ID="txtID" runat="server" Width="70px" ReadOnly="True" Style="text-align: center"></asp:TextBox>
<asp:TextBox ID="txtMaxPoints" runat="server" Width="70px" ReadOnly="True" Style="text-align: right"></asp:TextBox>
<asp:TextBox ID="txtScore" runat="server" Width="70px" Style="text-align: right" AutoPostBack="True"></asp:TextBox>
<asp:TextBox ID="txtPercentage" runat="server" Width="70px" ReadOnly="True" Style="text-align: center"></asp:TextBox>
<asp:TextBox ID="txtGrade" runat="server" Width="70px" ReadOnly="True" Style="text-align: center"></asp:TextBox>
<asp:Label ID="lblMessage" runat="server" Width="200px" ReadOnly="True"></asp:Label>
<br /><br />

