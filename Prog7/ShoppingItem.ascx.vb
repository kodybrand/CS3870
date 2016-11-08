Partial Class Prog7_ShoppingItem
   Inherits System.Web.UI.UserControl

   Public Event ItemChanged(ByVal item As Prog7_ShoppingItem, ByVal valid As Boolean)

   ' Private data
   Private _theID, _theName As String
   Private _thePrice, _theCost As Single
   Private _theQuantity As Integer

   Public Property theID As String
      Set(value As String)
         _theID = value
      End Set
      Get
         Return _theID
      End Get
   End Property

   Public Property theName As String
      Set(value As String)
         _theName = value
      End Set
      Get
         Return _theName
      End Get
   End Property

   Public Property thePrice As Single
      Set(value As Single)
         _thePrice = value
      End Set
      Get
         Return _thePrice
      End Get
   End Property

   Public Property theCost As Single
      Set(value As Single)
         _theCost = value
      End Set
      Get
         Return _theCost
      End Get
   End Property

   Public Property theQuantity As Integer
      Set(value As Integer)
         _theQuantity = value
      End Set
      Get
         Return _theQuantity
      End Get
   End Property

   Private Sub Prog7_ShoppingItem_Load(sender As Object, e As EventArgs) Handles Me.Load
      lblMessage.Text = ""
      txtID.Text = _theID
      txtName.Text = _theName
      txtPrice.Text = FormatCurrency(_thePrice)
      txtQuantity.Text = _theQuantity
      txtCost.Text = FormatCurrency(_theCost)

   End Sub

   Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
      Dim q As Integer

      If Integer.TryParse(txtQuantity.Text, q) And q >= 0 Then
         'raise event
         RaiseEvent ItemChanged(Me, True)
      Else
         RaiseEvent ItemChanged(Me, False)
      End If

   End Sub

   


End Class