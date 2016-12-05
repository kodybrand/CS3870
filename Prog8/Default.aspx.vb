
Partial Class Prog8_Default
   Inherits System.Web.UI.Page

   Private Sub btnAddScore_Click(sender As Object, e As EventArgs) Handles btnAddScore.Click
      Dim bag As SortedList = Session("Prog8_Bag")
      Dim s1 As Prog8_ScoreToGrade

      Dim validNumber = ScoreAndGrade.CheckInput(txtScore.Text, DetailsView1.Rows(1).Cells(1).Text)

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
            s1 = New Prog8_ScoreToGrade
            s1.theID = DetailsView1.Rows(0).Cells(1).Text
            s1.theMaxPoints = CInt(DetailsView1.Rows(1).Cells(1).Text)
            s1.theScore = txtScore.Text
            s1.theValid = True
            s1.theMessage = ""

            bag.Remove(s1.theID)
            bag.Add(s1.theID, s1)
            txtMessage.Text = "Score has been added!"
            lstAssignments.Focus()
            txtScore.Text = ""

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
