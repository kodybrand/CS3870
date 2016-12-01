<%@ Page Title="" Language="VB" MasterPageFile="~/Prog8/Prog8MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Prog8_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Prog8Body" runat="Server">

   <asp:DropDownList ID="lstAssignments" runat="server" Style="position: relative; width: 10%; margin-left: 45%" DataSourceID="SqlDataSource1" DataTextField="AssignmentID" AutoPostBack="True"></asp:DropDownList>
   <br /> <br /> <br />
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
         <asp:DetailsView ID="DetailsView1" runat="server" Style="height: 50px; border-collapse: collapse; position: relative; width: 26%; margin-left: 37%" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
         </asp:DetailsView>
      </ContentTemplate>
      <Triggers>
         <asp:AsyncPostBackTrigger ControlID="lstAssignments" EventName="SelectedIndexChanged" />
      </Triggers>

   </asp:UpdatePanel>

   <br /> <br />

   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
         <asp:TextBox ID="txtScore" runat="server" Style="position: relative; width: 10%; margin-left: 45%; text-align: center"></asp:TextBox>

         <asp:TextBox ID="txtMessage" runat="server" Style="position: relative; top: 150px; width: 20%; margin-left: 40%; text-align: center"></asp:TextBox>
      <br /> <br /> <br /> <br /> <br /> <br /> <br />

      </ContentTemplate>

      <Triggers>
         <asp:AsyncPostBackTrigger ControlID="lstAssignments" EventName="SelectedIndexChanged" />
      </Triggers>
   </asp:UpdatePanel>


   <asp:Button ID="bntAddScore" runat="server" Text="Add Score" Style="position: relative; top: -80px; width: 15%; margin-left: 42.5%" />
   <br />
   <br />


</asp:Content>

