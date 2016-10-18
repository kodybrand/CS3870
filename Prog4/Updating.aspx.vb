
Partial Class Prog4_Updating
   Inherits System.Web.UI.Page


   Private Sub GridView1_PageIndexChanged(sender As Object,
        e As EventArgs) Handles DetailsView1.PageIndexChanged
      ' Keep the Record index
      Session("Prog4_RecordIndex") = DetailsView1.PageIndex
   End Sub

   Private Sub Prog4_Updating_Load(sender As Object, e As EventArgs) Handles Me.Load
      If Not IsPostBack Then
         DetailsView1.PageIndex = Session("Prog4_RecordIndex")
      End If
   End Sub

   ' Same for updating and inserting
   ' Not event ItemDeleting
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
