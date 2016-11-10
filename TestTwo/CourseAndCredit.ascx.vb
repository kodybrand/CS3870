
Partial Class TestTwo_CourseAndCredit
   Inherits System.Web.UI.UserControl

   Public Event CreditsChanged(ByVal item As TestTwo_CourseAndCredit, ByVal valid As Boolean)

   Private _theCourseID, _theCourseName, _theCourseDescription As String
   Private _theCredits As Integer

   Public Property theCourseID As String
      Set(value As String)
         _theCourseID = value
      End Set
      Get
         Return _theCourseID
      End Get
   End Property

   Public Property theCourseName As String
      Set(value As String)
         _theCourseName = value
      End Set
      Get
         Return _theCourseName
      End Get
   End Property

   Public Property theCourseDescription As String
      Set(value As String)
         _theCourseDescription = value
      End Set
      Get
         Return _theCourseDescription
      End Get
   End Property

   Public Property theCredits As Integer
      Set(value As Integer)
         _theCredits = value
      End Set
      Get
         Return _theCredits
      End Get
   End Property



   Private Sub txtCredits_TextChanged(sender As Object, e As EventArgs) Handles txtCredits.TextChanged
      Dim c As Integer

      If Integer.TryParse(txtCredits.Text, c) And (c >= 1 And c <= 5) Then
         _theCredits = c
         lblMessage.Text = ""
         RaiseEvent CreditsChanged(Me, True)
      Else
         If Integer.TryParse(txtCredits.Text, c) = False Then
            lblMessage.Text = "Not an Integer!"
         ElseIf txtCredits.Text <= 0 Then
            lblMessage.Text = "Not a Positive!"
         ElseIf txtCredits.Text > 5 Then
            lblMessage.Text = "Larger than 5!"
         End If
         RaiseEvent CreditsChanged(Me, False)
      End If
   End Sub

   Private Sub TestTwo_CourseAndCredit_Load(sender As Object, e As EventArgs) Handles Me.Load
      txtCourseID.Text = _theCourseID
      txtCourseName.Text = _theCourseName
      txtCredits.Text = _theCredits
      lblMessage.Text = ""
   End Sub
End Class
