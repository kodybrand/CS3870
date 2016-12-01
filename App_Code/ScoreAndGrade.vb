Imports Microsoft.VisualBasic

Public Class ScoreAndGrade

   Private Const A_PERCENTAGE As Single = 0.92
   Private Const A_MINUS_PERCENTAGE As Single = 0.89
   Private Const B_PLUS_PERCENTAGE As Single = 0.87
   Private Const B_PERCENTAGE As Single = 0.82
   Private Const B_MINUS_PERCENTAGE As Single = 0.79
   Private Const C_PLUS_PERCENTAGE As Single = 0.77
   Private Const C_PERCENTAGE As Single = 0.72
   Private Const C_MINUS_PERCENTAGE As Single = 0.69
   Private Const D_PLUS_PERCENTAGE As Single = 0.67
   Private Const D_PERCENTAGE As Single = 0.6

   ' The sub computes the score percentage and 
   ' determines the grade according to the computed percentage.
   Public Shared Sub ComputePercentageAndGrade(ByVal score As Integer, ByVal max As Integer,
                                               ByRef percentage As Single, ByRef grade As String)
      percentage = max / score

      Select Case percentage
         Case percentage > A_PERCENTAGE
            grade = "A"
         Case percentage < A_PERCENTAGE And percentage > B_PLUS_PERCENTAGE
            grade = "A-"
         Case percentage < B_PLUS_PERCENTAGE And percentage > B_PERCENTAGE
            grade = "B+"
         Case percentage < B_PERCENTAGE And percentage > B_MINUS_PERCENTAGE
            grade = "B"
         Case percentage < B_MINUS_PERCENTAGE And percentage > C_PLUS_PERCENTAGE
            grade = "B-"
         Case percentage < C_PLUS_PERCENTAGE And percentage > C_PERCENTAGE
            grade = "C+"
         Case percentage < C_PERCENTAGE And percentage > C_MINUS_PERCENTAGE
            grade = "C"
         Case percentage < C_MINUS_PERCENTAGE And percentage > D_PLUS_PERCENTAGE
            grade = "C-"
         Case percentage < D_PLUS_PERCENTAGE And percentage > D_PERCENTAGE
            grade = "D+"
         Case percentage < D_PERCENTAGE
            grade = "D"
      End Select

   End Sub

   ' The function checks if input represent an integer.
   ' It returns -1 if input does not represent an integer,
   '             0 if input represent a negative integer (too small),
   '             2 if input is greater than max (too large), or
   '             1 otherwise (positive integer in the range).
   Public Shared Function CheckInput(ByVal input As String, ByVal max As Integer) As Integer
      Dim myInt As Integer

      If Not Integer.TryParse(input, myInt) Then
         Return -1
      End If

      If myInt < 0 Then
         Return 0
      End If

      If myInt > max Then
         Return 2
      End If

      Return 1
   End Function
End Class
