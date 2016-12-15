
Partial Class Prog9_Admin_Updating
   Inherits System.Web.UI.Page
   Dim obj As Object
   Dim myTable As Data.DataTable

   Private Sub Prog9_Admin_Updating_Load(sender As Object, e As EventArgs) Handles Me.Load
      If Session("Prog9_WS") Is Nothing Then
         Response.Redirect("~/Prog9/Default.aspx")
      End If

      obj = Session(“Prog9_WS")
      myTable = obj.WS_GetAllProducts()

      DisplayRow(Session(“Prog9_Index”))
      ToggleButtons()
   End Sub
   Private Sub DisplayRow(Index As Integer)
      Dim row As Data.DataRow
      row = myTable.Rows(Index)

      If (IsDBNull(row(0))) Then
         txtID.Text = ""
      Else
         txtID.Text = row(0)
      End If
      If (IsDBNull(row(1))) Then
         txtName.Text = ""
      Else
         txtName.Text = row(1)
      End If

      If (IsDBNull(row(2))) Then
         txtPrice.Text = ""
      Else
         txtPrice.Text = Convert.ToDouble(row(2)).ToString("C")
      End If

      If (IsDBNull(row(3))) Then
         txtDescription.Text = ""
      Else
         txtDescription.Text = row(3)
      End If
   End Sub
   Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
      Session(“Prog9_Index”) = 0
      DisplayRow(Session(“Prog9_Index”))
      ToggleButtons()
   End Sub
   Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
      Session(“Prog9_Index”) += 1
      DisplayRow(Session(“Prog9_Index”))
      ToggleButtons()
   End Sub
   Protected Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
      Session(“Prog9_Index”) -= 1
      DisplayRow(Session(“Prog9_Index”))
      ToggleButtons()
   End Sub

   Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
      Session(“Prog9_Index”) = myTable.Rows.Count - 1
      DisplayRow(Session(“Prog9_Index”))
      ToggleButtons()
   End Sub

   Sub ToggleButtons()
      If Session(“Prog9_Index”) = 0 Then
         btnFirst.Enabled = False
         btnPrevious.Enabled = False
         btnNext.Enabled = True
         btnLast.Enabled = True
      ElseIf Session(“Prog9_Index") = myTable.Rows.Count - 1 Then
         btnNext.Enabled = False
         btnLast.Enabled = False
         btnFirst.Enabled = True
         btnPrevious.Enabled = True
      Else
         btnFirst.Enabled = True
         btnNext.Enabled = True
         btnPrevious.Enabled = True
         btnLast.Enabled = True
      End If

   End Sub

   Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
      Dim row As Data.DataRow
      row = myTable.Rows(Session(“Prog9_Index”))
      Try
         obj.WS_UpdateProduct(row(0), txtName.Text,
                  txtPrice.Text, txtDescription.Text)
      Catch ex As Exception
         txtMsg.Text = ex.Message
      End Try
   End Sub
End Class
