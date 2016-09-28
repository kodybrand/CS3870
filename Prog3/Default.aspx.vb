
Partial Class Prog3_Default
    Inherits System.Web.UI.Page

    Private Sub Prog3_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        SQLDataClass.getAllProducts()

        GridView1.DataSource = SQLDataClass.tblProducts
        GridView1.DataBind()

    End Sub
End Class
