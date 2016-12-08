
Partial Class Ajax_Default
   Inherits System.Web.UI.Page

   Private Sub Ajax_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
      If Not IsPostBack Then
         lstEmployees.SelectedIndex = Session("Test3_ID")
         DetailsView1.PageIndex = Session("Test3_ID")
         txtWeeklyHours.Focus()
      End If

   End Sub

   Private Sub btnCalculateSalary_Click(sender As Object, e As EventArgs) Handles btnCalculateSalary.Click
      Dim hours As Integer

      If Integer.TryParse(txtWeeklyHours.Text, hours) Then
         If hours >= 0 Then
            If hours <= 60 Then
               calculatePay()
               lstEmployees.Focus()
            Else
               lblMessage.Text = "Employees cannot work more than 60 hours a week!"
               txtWeeklySalary.Text = ""
               txtWeeklyHours.Focus()
            End If
         Else
            lblMessage.Text = "Hours cannot be negative!"
            txtWeeklySalary.Text = ""
            txtWeeklyHours.Focus()

         End If
      Else
         lblMessage.Text = "Hours must be a number!"
         txtWeeklySalary.Text = ""
         txtWeeklyHours.Focus()
      End If

   End Sub

   Private Sub lstEmployees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEmployees.SelectedIndexChanged
      DetailsView1.PageIndex = lstEmployees.SelectedIndex
      Session("Test3_ID") = lstEmployees.SelectedIndex
      txtWeeklyHours.Text = ""
      txtWeeklySalary.Text = ""
      lblMessage.Text = ""
      txtWeeklyHours.Focus()
   End Sub

   Private Sub calculatePay()
      Dim hours As Integer
      Dim otHours As Integer
      Dim regularHours As Integer

      Dim payRate As Single = DetailsView1.Rows(5).Cells(1).Text

      Dim total As Single

      Try
         Integer.TryParse(txtWeeklyHours.Text, hours)
         If hours <= 40 Then
            regularHours = hours
         Else
            regularHours = 40
            otHours = hours - 40
         End If

         total = (regularHours * payRate) + (otHours * (payRate * 1.5))
         txtWeeklySalary.Text = FormatCurrency(total)
         lblMessage.Text = ""

      Catch ex As Exception
         lblMessage.Text = ex.Message
      End Try
   End Sub

End Class
