<%@ Page Title="" Language="VB" MasterPageFile="~/TestTwo/TestTwoMasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="TestTwo_Default" %>

<%@ Register Src="~/TestTwo/CourseAndCredit.ascx" 
             TagPrefix="uc1" 
             TagName="CourseAndCredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TestTwoProgBody" Runat="Server">
   <asp:DropDownList ID="DropDownList1" runat="server" style="position: relative; width: 10%; margin-left: 45%" DataSourceID="SqlDataSource1" DataTextField="CourseID" AutoPostBack="True"></asp:DropDownList>
   <br />
   <br />
   <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" DataSourceID="SqlDataSource1" style="height:50px;width:125px;border-collapse:collapse;position: relative; width: 20%; margin-left: 40%"></asp:DetailsView>
   <br /><br /><br />
   <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" style="position: relative; width: 10%; margin-left: 45%" />
</asp:Content>

