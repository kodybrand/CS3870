
Partial Class TestTwo_Credits
   Inherits System.Web.UI.Page

   Private Sub TestTwo_Credits_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim bag As SortedList = Session("TestTwo_Bag")
      Dim c, c1 As TestTwo_CourseAndCredit
      Dim theForm As Control = Master.Master.FindControl("form2")
      Dim total As Single

      For index = 0 To bag.Count - 1
         c = bag.GetByIndex(index)
         c1 = CType(LoadControl("CourseAndCredit.ascx"), TestTwo_CourseAndCredit)
         c1.theCourseID = c.theCourseID
         c1.theCourseName = c.theCourseName
         c1.theCourseDescription = c.theCourseDescription
         c1.theCredits = c.theCredits
         AddHandler c1.CreditsChanged, AddressOf HandleChangeEvent
         Panel1.Controls.Add(c1)
         total += c.theCredits
      Next

      txtCredits.Text = total

   End Sub

   Private Sub HandleChangeEvent(ByVal item As TestTwo_CourseAndCredit, ByVal valid As Boolean)
      Dim bag As SortedList = Session("TestTwo_Bag")
      Dim c2 As TestTwo_CourseAndCredit
      Dim total As Single

      If Not valid Then
         txtCredits.Text = ""
         Exit Sub
      Else
         For i = 0 To bag.Count - 1
            c2 = bag.GetByIndex(i)
            If c2.theCourseID = item.theCourseID Then
               c2.theCredits = item.theCredits
            End If
            total += c2.theCredits
         Next
      End If

      txtCredits.Text = total
   End Sub
End Class
