

Partial Class Prog9_Default
   Inherits System.Web.UI.Page

   Private Sub Prog9_Default_Load(sender As Object, e As EventArgs) Handles Me.Load

      Dim ws As String = DropDownList1.Text
      Dim obj As Object

      DropDownList1.SelectedValue = Session("Prog9_WSName")

      If ws = "CS3870" Then
         obj = New CS3870.UWPCSSEWebService2016SoapClient
      ElseIf ws = “YangQ" Then
         obj = New YangQ.UWPCSSEWebService2016SoapClient
      Else
         obj = New brandk.UWPCSSEWebService2016SoapClient
      End If

      Session(“Prog9_WS") = obj

      ws = obj.ToString
      Dim c As Control = Master.Master.FindControl("form1")
      c = c.FindControl("MainBody")
      c = c.FindControl("Label1")
      CType(c, Label).Text = ws

      Session("Prog9_WSName") = ws

   End Sub
End Class
