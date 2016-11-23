
Partial Class Prog6_ShoppingItem
   Inherits System.Web.UI.UserControl

   ' Private data
   Private _theID, _theName, _thePrice As String
   Private _theCost As Single
   Private _theQuantity As Integer

   Private _valid As Boolean = True
   Private _message As String = ""

   Private Sub Prog6_ShoppingItem_Load(sender As Object, e As EventArgs) Handles Me.Load
      txtID.Text = _theID
      txtName.Text = _theName
      txtPrice.Text = _thePrice
      txtQuantity.Text = _theQuantity
      lblMessage.Text = _message
   End Sub
End Class
