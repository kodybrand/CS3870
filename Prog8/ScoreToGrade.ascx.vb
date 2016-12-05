
Partial Class Prog8_ScoreToGrade
   Inherits System.Web.UI.UserControl

   Private _theID, _theMessage, _theScore As String
   Private _theMaxPoints As Integer
   Private _theValid As Boolean

   Private percentage As Single
   Private grade As String

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

   Public Property theScore As String
      Set(value As String)
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
      Dim validNumber As Integer

      txtID.Text = _theID
      txtMaxPoints.Text = _theMaxPoints
      txtScore.Text = _theScore

      validNumber = ScoreAndGrade.CheckInput(_theScore, _theMaxPoints)

      Select Case validNumber
         Case -1
            lblMessage.Text = _theMessage
            txtPercentage.Text = ""
            txtGrade.Text = ""
            _theValid = False
         Case 0
            lblMessage.Text = _theMessage
            txtPercentage.Text = ""
            txtGrade.Text = ""
            _theValid = False
         Case 2
            lblMessage.Text = _theMessage
            txtPercentage.Text = ""
            txtGrade.Text = ""
            _theValid = False
         Case 1
            ScoreAndGrade.ComputePercentageAndGrade(_theScore, _theMaxPoints, percentage, grade)
            lblMessage.Text = _theMessage
            txtPercentage.Text = (percentage * 100) & "%"
            txtGrade.Text = grade
            _theValid = True
      End Select

   End Sub

   Private Sub txtScore_TextChanged(sender As Object, e As EventArgs) Handles txtScore.TextChanged
      Dim s As Integer
      Dim valid As Boolean

      valid = Integer.TryParse(txtScore.Text, s)

      If Integer.TryParse(txtScore.Text, s) And (s <= _theMaxPoints And s > -1) Then
         _theValid = True
         _theMessage = ""
         _theScore = Convert.ToInt32(s)
         ScoreAndGrade.ComputePercentageAndGrade(_theScore, _theMaxPoints, percentage, grade)
         lblMessage.Text = _theMessage
         txtPercentage.Text = percentage * 100 & "%"
         txtGrade.Text = grade
         RaiseEvent ScoreChanged(Me)
      Else
         _theValid = False
         _theMessage = "Invalid Score!"
         _theScore = txtScore.Text
         lblMessage.Text = _theMessage
         txtPercentage.Text = ""
         txtGrade.Text = ""
         RaiseEvent ScoreChanged(Me)
      End If
   End Sub
End Class
