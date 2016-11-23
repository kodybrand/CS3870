
Partial Class Prog6_ShoppingItem
   Inherits System.Web.UI.UserControl

   Private _theID, _theName, _thePrice, _message As String
   Private _theCost As Single
   Private _theQuantity As String

   Private _valid As Boolean = True

   Public Event ItemChanged(ByVal x As Prog6_ShoppingItem)

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

   Public Property TheCost As Single
      Get
         Return _theCost
      End Get
      Set(value As Single)
         _theCost = value
      End Set
   End Property

   Public Property Valid As Boolean
      Get
         Return _valid
      End Get
      Set(value As Boolean)
         _valid = value
      End Set
   End Property

   Public Property TheMessage As String
      Get
         Return _message
      End Get
      Set(value As String)
         _message = value
      End Set
   End Property

   Private Sub Prog6_ShoppingItem_Load(sender As Object, e As EventArgs) Handles Me.Load
      lblMessage.Text = ""
      txtID.Text = _theID
      txtPrice.Text = _thePrice
      txtName.Text = _theName
      txtQuantity.Text = _theQuantity
      txtCost.Text = _theCost
      lblMessage.Text = _message
   End Sub

   Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
      Dim quant As Integer

      If Integer.TryParse(txtQuantity.Text, quant) Then
         If quant <= 0 Then
            _theQuantity = txtQuantity.Text
            _theCost = 0
            _message = "Invalid Quantity!"
            _valid = False
         Else
            _theCost = _thePrice * quant
            _theQuantity = quant
            _message = ""
            _valid = True
         End If
      Else
         _theQuantity = txtQuantity.Text
         _theCost = 0
         _message = "Invalid Quantity!"
         _valid = False
      End If
      txtQuantity.Text = _theQuantity
      If _valid = True Then
         txtCost.Text = _theCost
      Else
         txtCost.Text = ""
      End If
      lblMessage.Text = _message

      RaiseEvent ItemChanged(Me)

   End Sub
End Class
