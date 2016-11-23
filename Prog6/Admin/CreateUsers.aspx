<%@ Page Title="" Language="VB" MasterPageFile="~/Prog6/Prog6MasterPage.master" AutoEventWireup="false" CodeFile="CreateUsers.aspx.vb" Inherits="Prog6_Admin_CreateUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog6Body" Runat="Server">
   <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" style="border-collapse:collapse;position: relative; width: 26%; height: 150px; margin-left:37%; top: 0px; left: -43px;" >
      <WizardSteps>
         <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
         </asp:CreateUserWizardStep>
         <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
         </asp:CompleteWizardStep>
      </WizardSteps>
   </asp:CreateUserWizard>
</asp:Content>

