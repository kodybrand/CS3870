
Partial Class Prog7_Member_Shopping
   Inherits System.Web.UI.Page

   Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
      Dim c1 As Prog7_ShoppingItem
      Dim bag As SortedList = Session("Prog7_Bag")

      ' New works here
      c1 = New Prog7_ShoppingItem
      c1.theID = txtID.Text
      c1.theName = txtName.Text
      c1.thePrice = txtPrice.Text
      c1.theQuantity = txtQuanity.Text

      bag.Remove(c1.theID)
      bag.Add(c1.theID, c1)


   End Sub

   Private Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
      Dim quant As String = txtQuanity.Text

      If Not Integer.TryParse(txtQuanity.Text, quant) Or quant < 0 Then
         txtID.Text = ""
         txtName.Text = ""
         txtPrice.Text = ""
         Exit Sub
      End If

      txtSubTotal.Text = (txtPrice.Text * txtQuanity.Text).ToString("C")
      txtTax.Text = (txtSubTotal.Text * 0.055).ToString("C")
      txtGrandTotal.Text = ((txtSubTotal.Text * 0.055) + txtSubTotal.Text).ToString("C")
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
