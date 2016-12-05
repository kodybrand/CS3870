
Partial Class Prog8_Grade
   Inherits System.Web.UI.Page



   Private Sub Prog8_Grade_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim bag As SortedList = Session("Prog8_Bag")
      Dim s, s1 As Prog8_ScoreToGrade
      Dim theForm As Control = Master.Master.FindControl("form2")

      Dim allValid As Boolean = True
      Dim totalPoints As Single
      Dim totalEarned As Single
      Dim totalPercentage As Single
      Dim totalGrade As String = ""

      If bag.Count > 0 Then
         For index = 0 To bag.Count - 1
            s = bag.GetByIndex(index)
            If Not s.theValid Then
               allValid = False
            End If
            s1 = CType(LoadControl("ScoreToGrade.ascx"), Prog8_ScoreToGrade)
            s1.theID = s.theID
            s1.theMaxPoints = s.theMaxPoints
            s1.theScore = s.theScore
            s1.theMessage = s.theMessage
            AddHandler s1.ScoreChanged, AddressOf HandleChangeEvent
            Panel1.Controls.Add(s1)
            If s.theValid Then
               totalPoints += s.theMaxPoints
               totalEarned += s.theScore
            End If

         Next
      End If

      If allValid Then
         ScoreAndGrade.ComputePercentageAndGrade(totalEarned, totalPoints, totalPercentage, totalGrade)
         txtTotalPercentage.Text = totalEarned & "/" & totalPoints & ": " & Format((totalPercentage * 100), "N1") & "%"
         txtTotalGrade.Text = totalGrade
      Else
         txtTotalPercentage.Text = ""
         txtTotalGrade.Text = ""
      End If

   End Sub

   Private Sub HandleChangeEvent(ByVal item As Prog8_ScoreToGrade)
      Dim bag As SortedList = Session("Prog8_Bag")
      Dim s As Prog8_ScoreToGrade
      Dim allValid As Boolean = True

      Dim totalPoints As Single
      Dim totalEarned As Single
      Dim totalPercentage As Single
      Dim totalGrade As String = ""

      For index = 0 To bag.Count - 1
         s = bag.GetByIndex(index)

         If s.theID = item.theID Then
            s.theScore = item.theScore
            s.theValid = item.theValid
            s.theMessage = item.theMessage
         End If

         If s.theValid Then
            totalEarned += s.theScore
            totalPoints += s.theMaxPoints
         Else
            allValid = False
         End If
      Next

      Session("Prog8_Bag") = bag

      If allValid Then
         ScoreAndGrade.ComputePercentageAndGrade(totalEarned, totalPoints, totalPercentage, totalGrade)
         txtTotalPercentage.Text = totalEarned & "/" & totalPoints & ": " & Format((totalPercentage * 100), "N1") & "%"
         txtTotalGrade.Text = totalGrade
      Else
         txtTotalPercentage.Text = ""
         txtTotalGrade.Text = ""
      End If

   End Sub
End Class
