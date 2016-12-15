
Partial Class Prog9_AllProducts
   Inherits System.Web.UI.Page
   Dim obj As Object
   Dim myTable As Data.DataTable

   Private Sub Prog9_AllProducts_Load(sender As Object, e As EventArgs) Handles Me.Load
      obj = Session(“Prog9_WS")
      myTable = obj.WS_GetAllProducts()

      GridView1.DataSource = myTable
      GridView1.DataBind()

      Dim ws = obj.ToString
      Dim c As Control = Master.Master.FindControl("form1")
      c = c.FindControl("MainBody")
      c = c.FindControl("Label1")
      CType(c, Label).Text = ws


   End Sub
End Class
