﻿
Partial Class Prog9_Member_Checkout
   Inherits System.Web.UI.Page
   Private Sub Prog6_Member_Checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim bag As SortedList = Session("Prog9_Bag")
      Dim c, c1 As Prog9_ShoppingItem
      Dim theForm As Control = Master.Master.FindControl("form2")
      Dim total As Single
      Dim allValid As Boolean = True

      For index = 0 To bag.Count - 1
         c = bag.GetByIndex(index)
         c1 = CType(LoadControl("./../ShoppingItem.ascx"), Prog9_ShoppingItem)
         c1.TheID = c.TheID
         c1.theName = c.TheName
         c1.ThePrice = FormatCurrency(c.ThePrice)
         c1.TheQuantity = c.TheQuantity
         total += c.ThePrice * c.TheQuantity
         If c1.Valid = False Then
            allValid = False
         End If
         AddHandler c1.ItemChanged, AddressOf HandleChangeEvent
         Panel1.Controls.Add(c1)

      Next

      If allValid = True Then
         txtTotal.Text = FormatCurrency(total)
      Else
         txtTotal.Text = ""
      End If


   End Sub

   Private Sub HandleChangeEvent(ByVal item As Prog9_ShoppingItem)
      Dim bag As SortedList = Session("Prog9_Bag")
      Dim c As Prog9_ShoppingItem
      Dim AllValid As Boolean = True

      Dim grandTotal As Single = 0

      For index = 0 To bag.Count - 1
         c = bag.GetByIndex(index)

         If c.TheID = item.TheID Then
            c.Valid = item.Valid
            c.TheMessage = item.TheMessage
         End If

         If c.Valid Then
            grandTotal += c.ThePrice * c.TheQuantity
         Else
            AllValid = False
         End If
      Next

      Session("Prog9_Bag") = bag

      If AllValid Then
         txtTotal.Text = FormatCurrency(grandTotal)
      Else
         txtTotal.Text = ""
      End If
   End Sub

   Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
      Dim bag As SortedList = Session("Prog9_Bag")
      bag.Clear()
      Session.Abandon()
      FormsAuthentication.SignOut()

      Response.Redirect(FormsAuthentication.LoginUrl)

   End Sub
End Class
