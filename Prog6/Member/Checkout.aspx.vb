

Partial Class Prog6_Member_Checkout
   Inherits System.Web.UI.Page

   Private Sub Prog6_Member_Checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim bag As SortedList = Session("Prog6_Bag")
      Dim c, c1 As Prog6_ShoppingItem
      Dim theForm As Control = Master.Master.FindControl("form2")
      Dim total As Single
      Dim allValid As Boolean = True


      For index = 0 To bag.Count - 1
         c = bag.GetByIndex(index)
         c1 = CType(LoadControl("./../ShoppingItem.ascx"), Prog6_ShoppingItem)
         c1.TheID = c.TheID
         c1.theName = c.theName
         c1.ThePrice = c.ThePrice
         c1.TheQuantity = c.TheQuantity
         If c.Valid Then
            c1.TheCost = c.TheCost
         End If
         c1.TheCost = c.ThePrice * c.TheQuantity
         If c1.Valid = False Then
            allValid = False
         End If
         AddHandler c1.ItemChanged, AddressOf HandleChangeEvent
         Panel1.Controls.Add(c1)
         total += c1.TheCost
      Next

      If allValid = True Then
         txtTotal.Text = FormatCurrency(total)
      Else
         txtTotal.Text = ""
      End If
      txtTotal.Text = FormatCurrency(total)

   End Sub

   Private Sub HandleChangeEvent(ByVal item As Prog6_ShoppingItem)
      Dim bag As SortedList = Session("Prog6_Bag")
      Dim c As Prog6_ShoppingItem

      Dim allValid As Boolean = True
      Dim total As Integer = 0
      For i = 0 To bag.Count - 1
         c = bag.GetByIndex(i)
         If c.theID = item.TheID Then
            c.TheCost = item.TheQuantity * item.ThePrice
         End If
         If c.Valid Then
            total += c.TheCost
         Else
            allValid = False
         End If
      Next
      If allValid Then
         txtTotal.Text = total
      Else
         txtTotal.Text = ""
      End If



   End Sub

   Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
      Dim bag As SortedList = Session("Prog6_Bag")
      bag.Clear()
      Server.Transfer("../Default.aspx")
   End Sub
End Class

