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



   End Sub

   Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
      ' Code that runs when a session ends. 
      ' Note: The Session_End event is raised only when the sessionstate mode
      ' is set to InProc in the Web.config file. If session mode is set to StateServer 
      ' or SQLServer, the event is not raised.
   End Sub

</script>