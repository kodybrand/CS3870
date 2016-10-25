
Partial Class Prog5_Updating
   Inherits System.Web.UI.Page
   Private Sub DetailsView1_ItemDeleted(sender As Object, e As DetailsViewDeletedEventArgs) Handles DetailsView1.ItemDeleted
      If Not IsNothing(e.Exception) Then
         e.ExceptionHandled = True
         txtMsg.Text = e.Exception.Message
      Else
         txtMsg.Text = "Record Deleted."
      End If
   End Sub

   Private Sub DetailsView1_ItemInserted(sender As Object, e As DetailsViewInsertedEventArgs) Handles DetailsView1.ItemInserted
      If Not IsNothing(e.Exception) Then
         e.ExceptionHandled = True
         txtMsg.Text = e.Exception.Message
      Else
         txtMsg.Text = "Record Inserted."
      End If
   End Sub

   Private Sub DetailsView1_ItemUpdated(sender As Object, e As DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated
      If Not IsNothing(e.Exception) Then
         e.ExceptionHandled = True
         txtMsg.Text = e.Exception.Message
      Else
         txtMsg.Text = "Record Updated."
      End If
   End Sub
End Class
