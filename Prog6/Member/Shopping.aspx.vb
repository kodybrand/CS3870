
Partial Class Prog6_Member_Shopping
   Inherits System.Web.UI.Page

   Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
      Dim c1 As Prog6_ShoppingItem
      Dim bag As SortedList = Session("Prog6_Bag")

      c1 = New Prog6_ShoppingItem
      c1.TheID = txtID.Text
      c1.TheName = txtName.Text
      c1.ThePrice = txtPrice.Text
      c1.TheQuantity = txtQuanity.Text
      c1.Valid = True
      c1.TheMessage = ""

      bag.Remove(c1.TheID)
      bag.Add(c1.TheID, c1)

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
         End If
      Catch ex As Exception
         lblQuantError.Text = "Invalid Quantity!"
      End Try


   End Sub

   Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
      ' Now we can access DataSource from the master page
      Dim ds As SqlDataSource = Master.MyDataSource

      Dim id As String = txtID.Text
      Dim row As Data.DataRow

      Dim dv As Data.DataView = ds.Select(DataSourceSelectArguments.Empty)

      ' Same as SQL statement: “Product = ‘p101’”
      dv.RowFilter = "ProductID = '" & id & "'"

      If dv.Count = 1 Then
         row = dv.ToTable.Rows(0)
         txtName.Text = row(1)
         txtPrice.Text = Convert.ToDouble(row(2)).ToString("C")
         txtQuanity.Focus()
      Else
         Session("Prog5_ID") = ""
         txtID.Text = ""
         txtID.Focus()
      End If
   End Sub
End Class
