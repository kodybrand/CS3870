
Partial Class Prog9_Member_Shopping
   Inherits System.Web.UI.Page
   Dim obj As Object
   Dim myTable As Data.DataTable
   Protected Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
      Dim id As String

      Dim price As Double
      id = txtID.Text.Trim

      Dim row As Data.DataRow

      row = myTable.Rows.Find(id)

      If row Is Nothing Then
         txtName.Text = ""
         txtPrice.Text = ""
         txtQuanity.Text = ""
         txtSubTotal.Text = ""
         txtTax.Text = ""
         txtGrandTotal.Text = ""
         txtID.Focus()
      Else

         txtName.Text = row(1)
         price = row(2)
         txtPrice.Text = FormatCurrency(price)
         txtQuanity.Focus()
         txtQuanity.Text = ""
         txtSubTotal.Text = ""
         txtTax.Text = ""
         txtGrandTotal.Text = ""
      End If
   End Sub

   Private Sub Prog9_Member_Shopping_Load(sender As Object, e As EventArgs) Handles Me.Load
      obj = Session(“Prog9_WS")
      myTable = obj.WS_GetAllProducts()
      Dim c As Control = Master.Master.FindControl("form1")
      c = c.FindControl("MainBody")
      c = c.FindControl("Label1")
      CType(c, Label).Text = Session("Prog9_WSName")
      btnAddToCart.Enabled = False
   End Sub

   Private Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
      Dim quant As String = txtQuanity.Text
      Try
         If Not Integer.TryParse(txtQuanity.Text, quant) Or quant < 0 Then
            txtSubTotal.Text = ""
            txtTax.Text = ""
            txtGrandTotal.Text = ""
            lblQuantError.Text = "Invalid Quantity!"
         Else
            lblQuantError.Text = ""
            txtSubTotal.Text = (txtPrice.Text * txtQuanity.Text).ToString("C")
            txtTax.Text = (txtSubTotal.Text * 0.055).ToString("C")
            txtGrandTotal.Text = ((txtSubTotal.Text * 0.055) + txtSubTotal.Text).ToString("C")
            btnAddToCart.Enabled = True
         End If
      Catch ex As Exception
         lblQuantError.Text = "Invalid Quantity!"
      End Try

   End Sub

   Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
      Dim c1 As Prog9_ShoppingItem
      Dim bag As SortedList = Session("Prog9_Bag")

      c1 = New Prog9_ShoppingItem
      c1.TheID = txtID.Text
      c1.TheName = txtName.Text
      c1.ThePrice = txtPrice.Text
      c1.TheQuantity = txtQuanity.Text
      c1.Valid = True
      c1.TheMessage = ""

      bag.Remove(c1.TheID)
      bag.Add(c1.TheID, c1)
   End Sub
End Class
