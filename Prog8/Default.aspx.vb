
Partial Class Prog8_Default
   Inherits System.Web.UI.Page

   Private Sub bntAddScore_Click(sender As Object, e As EventArgs) Handles bntAddScore.Click

      Dim validNumber = ScoreAndGrade.CheckInput(txtScore.Text, DetailsView1.Rows(1).ToString)

      Select Case validNumber
         Case -1
            txtMessage.Text = "Score must be an integer!"
            txtScore.Focus()
         Case 0
            txtMessage.Text = "Score cannot be negative!"
            txtScore.Focus()
         Case 2
            txtMessage.Text = "Score is too large!"
            txtScore.Focus()
         Case 1
            ' add to bag
      End Select
   End Sub

   Private Sub lstAssignments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAssignments.SelectedIndexChanged
      DetailsView1.PageIndex = lstAssignments.SelectedIndex
      Session("Prog8_Index") = lstAssignments.SelectedIndex
      txtScore.Focus()
   End Sub

   Private Sub Prog8_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
      txtScore.Focus()
      If Not IsPostBack Then
         lstAssignments.SelectedIndex = Session("Prog8_Index")
         DetailsView1.PageIndex = Session("Prog8_Index")
      End If
   End Sub
End Class
