
Partial Class Prog3_Updating
    Inherits System.Web.UI.Page

    Private Sub Prog3_Updating_Load(sender As Object, e As EventArgs) Handles Me.Load
        DisplayRow(Session(“Prog3_Index”))
        ToggleButtons()
    End Sub

    Private Sub DisplayRow(Index As Integer)
        Dim row As Data.DataRow
      row = SQLDataClass.tblProduct.Rows(Index)

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
        Session(“Prog3_Index”) = 0
        DisplayRow(Session(“Prog3_Index”))
        ToggleButtons()
    End Sub
    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Session(“Prog3_Index”) += 1
        DisplayRow(Session(“Prog3_Index”))
        ToggleButtons()
    End Sub
    Protected Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Session(“Prog3_Index”) -= 1
        DisplayRow(Session(“Prog3_Index”))
        ToggleButtons()
    End Sub

    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
      Session(“Prog3_Index”) = SQLDataClass.tblProduct.Rows.Count - 1
      DisplayRow(Session(“Prog3_Index”))
        ToggleButtons()
    End Sub

    Sub ToggleButtons()
      If Session(“Prog3_Index”) = 0 Then
         btnFirst.Enabled = False
         btnPrevious.Enabled = False
         btnNext.Enabled = True
         btnLast.Enabled = True
      ElseIf Session(“Prog3_Index") = SQLDataClass.tblProduct.Rows.Count - 1 Then
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

End Class
