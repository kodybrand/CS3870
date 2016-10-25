
Partial Class Prog5_Shopping
   Inherits System.Web.UI.Page


   Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
      Dim myBag As Data.DataTable = Session("Prog5_Bag")
      Dim row As Data.DataRow = myBag.NewRow
      row(0) = txtID.Text
      row(1) = txtName.Text
      row(2) = txtPrice.Text
      row(3) = txtQuanity.Text
      row(4) = txtSubTotal.Text

      Dim r As Data.DataRow = myBag.Rows.Find(row(0))
      If Not r Is Nothing Then
         myBag.Rows.Remove(r)
      End If
      myBag.Rows.Add(row)

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

   Private Sub Prog5_Shopping_Load(sender As Object, e As EventArgs) Handles Me.Load
      If Not IsPostBack Then
         ' Set focus
         txtID.Focus()
         Session("Prog5_ID") = ""
      End If

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
