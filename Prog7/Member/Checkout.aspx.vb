
Partial Class Prog7_Member_Checkout
   Inherits System.Web.UI.Page

   Private Sub Prog7_Member_Checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim c1, c2 As Prog7_ShoppingItem
      Dim bag As SortedList = Session("Prog7_Bag")




      ' Need to find the form to add the control
      Dim theForm As Control = Master.Master.FindControl("form1")

      ' Must use a loop to add all items in bag
      For index = 0 To bag.Count - 1

         c1 = CType(LoadControl("../ShoppingItem.ascx"), Prog7_ShoppingItem)
         c2 = bag.GetByIndex(index)
         c1.theID = c2.theID
         c1.theName = c2.theName
         c1.thePrice = c2.thePrice
         c1.theQuantity = c2.theQuantity
         c1.theCost = c2.theCost

         theForm.Controls.Add(c1)

      Next

   End Sub

   Private Sub HandleChangeEvent(ByVal item As Prog7_ShoppingItem, ByVal valid As Boolean)
      Dim c1, c2 As Prog7_ShoppingItem
      Dim bag As SortedList = Session("Prog7_Bag")
      Dim total As Single

      AddHandler c1.ItemChanged,
         AddressOf HandleChangeEvent
      If valid Then
         For i = 0 To bag.Count - 1
            c2 = bag.GetByIndex(i)
            If c2.theID = item.theID Then
               c1.theQuantity = c2.theQuantity
            End If
            total += c2.theCost
         Next
      End If
   End Sub

   Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
      Dim c1, c2 As Prog7_ShoppingItem
      Dim bag As SortedList = Session("Prog7_Bag")

      bag.Clear()
   End Sub
End Class
