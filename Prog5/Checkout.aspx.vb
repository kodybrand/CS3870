
Partial Class Prog5_Checkout
   Inherits System.Web.UI.Page

   Private Sub Prog5_Checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
      GridView1.DataSource = Session("Prog5_Bag")
      GridView1.DataBind()

   End Sub
End Class
