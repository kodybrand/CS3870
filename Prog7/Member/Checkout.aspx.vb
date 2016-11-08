
Partial Class Prog7_Member_Checkout
   Inherits System.Web.UI.Page

   Private Sub Prog7_Member_Checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim c1, c2 As Prog7_ShoppingItem
      Dim bag As SortedList = Session("Prog7_Bag")
      Dim index As Integer = 0

      ' Need to find the form to add the control
      Dim theForm As Control = Master.Master.FindControl("form1")

      ' Must use a loop to add all items in bag
      For index = 0 To bag.Count - 1

         c1 = CType(LoadControl("../ShoppingItem.ascx"), Prog7_ShoppingItem)
         c2 = bag.GetByIndex(index)
         c1.theID = c2.theID
         c1.theQuantity = c2.theQuantity

         theForm.Controls.Add(c1)
      Next

   End Sub
End Class
