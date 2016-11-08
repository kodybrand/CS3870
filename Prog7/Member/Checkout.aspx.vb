
Partial Class Prog7_Member_Checkout
   Inherits System.Web.UI.Page

   Private Sub Prog7_Member_Checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim bag As SortedList = Session("Prog7_Bag")
      Dim c, c1 As Prog7_ShoppingItem
      Dim theForm As Control = Master.Master.FindControl("form2")
      Dim total As Single

      For index = 0 To bag.Count - 1
         c = bag.GetByIndex(index)
         c1 = CType(LoadControl("./../ShoppingItem.ascx"), Prog7_ShoppingItem)
         c1.theID = c.theID
         c1.theName = c.theName
         c1.ThePrice = c.ThePrice
         c1.TheQuantity = c.theQuantity
         c1.theCost = c.thePrice * c.theQuantity
         AddHandler c1.ItemChanged, AddressOf HandleChangeEvent
         Panel1.Controls.Add(c1)
         total += c.theCost
      Next

      txtTotal.Text = FormatCurrency(total)

   End Sub

   Private Sub HandleChangeEvent(ByVal item As Prog7_ShoppingItem, ByVal valid As Boolean)
      Dim bag As SortedList = Session("Prog7_Bag")
      Dim c2 As Prog7_ShoppingItem
      Dim total As Single

      If Not valid Then
         txtTotal.Text = ""
         Exit Sub
      Else
         For i = 0 To bag.Count - 1
            c2 = bag.GetByIndex(i)
            If c2.theID = item.theID Then
               c2.TheQuantity = item.theQuantity
               c2.TheCost = item.theCost
            End If
            total += c2.TheCost
         Next
      End If

      txtTotal.Text = FormatCurrency(total)
   End Sub

   Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
      Dim c1, c2 As Prog7_ShoppingItem
      Dim bag As SortedList = Session("Prog7_Bag")
      bag.Clear()
      Server.Transfer("../Default.aspx")
   End Sub
End Class
