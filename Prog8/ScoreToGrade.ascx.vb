
Partial Class Prog8_ScoreToGrade
   Inherits System.Web.UI.UserControl

   Private _theID, _theMessage As String
   Private _theScore, _theMaxPoints As Integer
   Private _theValid As Boolean

   Public Event ScoreChanged(ByVal score As Prog8_ScoreToGrade)

   Public Property theID As String
      Set(value As String)
         _theID = value
      End Set
      Get
         Return _theID
      End Get
   End Property

   Public Property theMaxPoints As Integer
      Set(value As Integer)
         _theMaxPoints = value
      End Set
      Get
         Return _theMaxPoints
      End Get
   End Property

   Public Property theScore As Integer
      Set(value As Integer)
         _theScore = value
      End Set
      Get
         Return _theScore
      End Get
   End Property

   Public Property theMessage As String
      Set(value As String)
         _theMessage = value
      End Set
      Get
         Return _theMessage
      End Get
   End Property

   Public Property theValid As Boolean
      Set(value As Boolean)
         _theValid = value
      End Set
      Get
         Return _theValid
      End Get
   End Property

   Private Sub Prog8_ScoreToGrade_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim percentage As Single
      Dim grade As String = ""
      Dim validNumber As Integer

      txtID.Text = _theID
      txtMaxPoints.Text = _theMaxPoints
      txtScore.Text = _theScore

      validNumber = ScoreAndGrade.CheckInput(_theScore, _theMaxPoints)

      Select Case validNumber
         Case -1
            _theMessage = "Score must be an integer!"
            txtPercentage.Text = ""
            txtGrade.Text = ""
            _theValid = False
         Case 0
            _theMessage = "Score cannot be negative!"
            txtPercentage.Text = ""
            txtGrade.Text = ""
            _theValid = False
         Case 2
            _theMessage = "Score is too large!"
            txtPercentage.Text = ""
            txtGrade.Text = ""
            _theValid = False
         Case 1
            ScoreAndGrade.ComputePercentageAndGrade(_theScore, _theMaxPoints, percentage, grade)
            _theMessage = ""
            txtPercentage.Text = percentage
            txtGrade.Text = grade
            _theValid = True
      End Select


   End Sub
End Class
