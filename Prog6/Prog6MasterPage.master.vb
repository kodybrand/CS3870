
Partial Class Prog6_Prog6MasterPage
   Inherits System.Web.UI.MasterPage

   Public Function MyDataSource() As SqlDataSource
      Return SqlDataSource1
   End Function

   Private Sub LoginStatus1_LoggedOut(sender As Object, e As EventArgs) Handles LoginStatus1.LoggedOut
      Response.Redirect("~/Login.aspx")

   End Sub

End Class

