<%@ Page Title="" Language="VB" MasterPageFile="~/TestTwo/TestTwoMasterPage.master" AutoEventWireup="false" CodeFile="Credits.aspx.vb" Inherits="TestTwo_Credits" %>

<%@ Register Src="~/TestTwo/CourseAndCredit.ascx" 
             TagPrefix="uc1" 
             TagName="CourseAndCredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TestTwoProgBody" Runat="Server">
   <asp:Panel ID="Panel1" runat="server" style="position: relative; width: 60%; margin-left: 25%"></asp:Panel>
   <br /><br /><br />
   <asp:TextBox ID="txtCredits" runat="server" style="position: relative; width: 10%; margin-left: 45%"></asp:TextBox>
</asp:Content>

