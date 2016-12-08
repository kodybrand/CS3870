
Partial Class TestTwo_Default
   Inherits System.Web.UI.Page

   Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
      Session("Test3_ID") = DropDownList1.SelectedIndex
      DetailsView1.PageIndex = DropDownList1.SelectedIndex

   End Sub
   Protected Sub btnAddCourse_Click(sender As Object, e As EventArgs) Handles btnAddCourse.Click
      Dim c1 As TestTwo_CourseAndCredit
      Dim bag As SortedList = Session("TestTwo_Bag")

      c1 = New TestTwo_CourseAndCredit
      c1.theCourseID = DetailsView1.Rows(0).Cells(1).Text
      c1.theCourseName = DetailsView1.Rows(1).Cells(1).Text
      c1.theCourseDescription = DetailsView1.Rows(2).Cells(1).Text
      c1.theCredits = DetailsView1.Rows(3).Cells(1).Text

      bag.Remove(c1.theCourseID)
      bag.Add(c1.theCourseID, c1)

   End Sub

   Private Sub TestTwo_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
      If Not IsPostBack Then
         DropDownList1.SelectedIndex = Session("TestTwo_ID")
         DetailsView1.PageIndex = Session("TestTwo_ID")
      End If
   End Sub
End Class
