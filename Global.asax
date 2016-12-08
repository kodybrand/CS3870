<%@ Application Language="VB" %>

<script runat="server">
   '---------------------------------------------------------------------------------------------
   ' Class      : CS 3870CS 5870
   '
   ' Name       : Kody Brand 
   '
   ' UserName   : brandk
   '
   ' Description: Manages the Session data, it is set by OrderingProduct.aspx
   '---------------------------------------------------------------------------------------------

   Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
      ' Code that runs on application startup
      SQLDataClass.setupProdAdapter()
   End Sub

   Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
      ' Code that runs on application shutdown
   End Sub

   Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
      ' Code that runs when an unhandled error occurs
   End Sub

   Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
      Session("Prog2_ProductID") = ""
      Session("Prog2_ProductPrice") = ""
      Session("Prog2_ProductQuantity") = ""
      Session("Prog2_ProductSubTotal") = ""
      Session("Prog2_ProductTax") = ""
      Session("Prog2_ProductGrandTotal") = ""
      Session("Prog2_Computed") = False
      Session(“Prog3_Index”) = 0

      ' Prog4
      Session("Prog4_PageIndex") = 0
      Session("Prog4_RecordIndex") = 0
      Session("Prog4_UnitPrice") = 0
      Session("Prog4_ID") = ""

      ' Prog5
      Session("Prog5_PageIndex") = 0
      Session("Prog5_RecordIndex") = 0
      Session("Prog5_UnitPrice") = 0
      Session("Prog5_ID") = ""
      Session(“Prog5_Bag") = SQLDataClass.NewShoppingBag

      'Prog7
      Session("Prog7_PageIndex") = 0
      Session("Prog7_RecordIndex") = 0
      Session("Prog7_UnitPrice") = 0
      Session("Prog7_ID") = ""
      Session("Prog7_Bag") = New SortedList

      'TestTwo
      Session("TestTwo_Bag") = New SortedList
      Session("TestTwo_ID") = 0

      'Prog6
      Session("Prog6_PageIndex") = 0
      Session("Prog6_RecordIndex") = 0
      Session("Prog6_UnitPrice") = 0
      Session("Prog6_ID") = ""
      Session("Prog6_Bag") = New SortedList

      'Prog8
      Session("Prog8_Index") = 0
      Session("Prog8_Bag") = New SortedList

      'Test3
      Session("Test3_ID") = 0


   End Sub

   Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
      ' Code that runs when a session ends. 
      ' Note: The Session_End event is raised only when the sessionstate mode
      ' is set to InProc in the Web.config file. If session mode is set to StateServer 
      ' or SQLServer, the event is not raised.
   End Sub

</script>