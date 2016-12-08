<%@ Page Title="" Language="VB" MasterPageFile="~/Ajax/Test3MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Ajax_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Test3Body" runat="Server">
   <asp:DropDownList ID="lstEmployees" runat="server" DataSourceID="SQLDataSource1" DataTextField="LastName" Style="position: relative; width: 10%; margin-left: 45%" AutoPostBack="True"></asp:DropDownList>
   <br />
   <br />

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">

      <ContentTemplate>
         <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="SqlDataSource1" Style="height: 50px; width: 125px; border-collapse: collapse; position: relative; width: 30%; margin-left: 35%"></asp:DetailsView>
      </ContentTemplate>

      <Triggers>
         <asp:AsyncPostBackTrigger ControlID="lstEmployees" EventName="SelectedIndexChanged" />
      </Triggers>

   </asp:UpdatePanel>
   <br /><br />
   

   <asp:Label ID="lblHours" runat="server" Text="Weekly Hours" Style="position: relative; width: 10%; margin-left: 35%"></asp:Label>

   <asp:UpdatePanel ID="UpdatePanel2" runat="server">

      <ContentTemplate>
         <asp:TextBox ID="txtWeeklyHours" runat="server" Style="position: relative; top: -20px; width: 10%; margin-left: 47%"></asp:TextBox>
         <asp:TextBox ID="txtWeeklySalary" runat="server" style="position: relative; top: 100px; width:10%; margin-left:45%; text-align: right" ReadOnly="True"></asp:TextBox>
         <asp:Label ID="lblMessage" runat="server" Text="" style="position: relative; display: block; width:30%; margin-left:35%; text-align: center"></asp:Label>
      </ContentTemplate>

      <Triggers>
         <asp:AsyncPostBackTrigger ControlID="lstEmployees" EventName="SelectedIndexChanged" />
         <asp:AsyncPostBackTrigger ControlID="btnCalculateSalary" EventName="Click" />
      </Triggers>

   </asp:UpdatePanel>

   <asp:Button ID="btnCalculateSalary" runat="server" Text="Calculate Weekly Salary" style="position: relative; width:20%; margin-left:40%" />

</asp:Content>

