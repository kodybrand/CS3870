
Partial Class Prog9_ShoppingItem
   Inherits System.Web.UI.UserControl
   Private _theID, _theName, _thePrice, _theMessage As String
   Private _theQuantity As String
   Private _theValid As Boolean = True

   Public Event ItemChanged(ByVal x As Prog9_ShoppingItem)

   Public Property TheID As String
      Get
         Return _theID
      End Get
      Set(value As String)
         _theID = value
      End Set
   End Property
   Public Property TheName As String
      Get
         Return _theName
      End Get
      Set(value As String)
         _theName = value
      End Set
   End Property

   Public Property ThePrice As String
      Get
         Return _thePrice
      End Get
      Set(value As String)
         _thePrice = value
      End Set
   End Property

   Public Property TheQuantity As String
      Get
         Return _theQuantity
      End Get
      Set(value As String)
         _theQuantity = value
      End Set
   End Property


   Public Property Valid As Boolean
      Get
         Return _theValid
      End Get
      Set(value As Boolean)
         _theValid = value
      End Set
   End Property

   Public Property TheMessage As String
      Get
         Return _theMessage
      End Get
      Set(value As String)
         _theMessage = value
      End Set
   End Property

   Private Sub Prog6_ShoppingItem_Load(sender As Object, e As EventArgs) Handles Me.Load
      lblMessage.Text = ""
      txtID.Text = _theID
      txtPrice.Text = _thePrice
      txtName.Text = _theName
      txtQuantity.Text = _theQuantity
      lblMessage.Text = _theMessage
   End Sub

   Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
      Dim quant As Integer

      If Integer.TryParse(txtQuantity.Text, quant) And (quant > 0) Then
         _theValid = True
         _theMessage = ""
         _theQuantity = quant
         lblMessage.Text = _theMessage
         txtPrice.Text = _thePrice
         txtQuantity.Text = _theQuantity
         txtCost.Text = _theQuantity * _thePrice
         RaiseEvent ItemChanged(Me)
      Else
         _theValid = False
         _theMessage = "Invalid Quantity!"
         _theQuantity = quant
         lblMessage.Text = _theMessage
         txtPrice.Text = _thePrice
         lblMessage.Text = _theMessage
         txtCost.Text = ""
         RaiseEvent ItemChanged(Me)
      End If

   End Sub
End Class
