Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="https://alpha.ion.uwplatt.edu/brandk")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class UWPCSSEWebService2016
    Inherits System.Web.Services.WebService

   <WebMethod()>
   Public Function HelloWorld() As String
      Return "Hello World"
   End Function

   ' The method returns a DataTable that contains all records of table Product.
   <WebMethod()>
   Public Function WS_GetAllProducts() As Data.DataTable
      SQLDataClass.getAllProdcts()
      Return SQLDataClass.tblProducts
   End Function

   ' The method modifies the record with ProductID being ID in table Product.
   <WebMethod()>
   Public Sub WS_UpdateProduct(ByVal ID As String, ByVal newName As String, ByVal newPrice As Double,
                               ByVal newDescription As String)
      SQLDataClass.UpdateProduct(ID, newName, newPrice, newDescription)
   End Sub

   ' The method inserts a new record into table Product.   
   <WebMethod()>
   Public Sub WS_InsertProduct(ByVal ID As String, ByVal Name As String, ByVal Price As Double,
                               ByVal Description As String)
      SQLDataClass.saveProduct(ID, Name, Price, Description)
   End Sub

   ' The method deletes the record with ProductID being ID from table Product.
   <WebMethod()>
   Public Sub WS_DeleteProduct(ByVal ID As String)
      SQLDataClass.deleteProduct(ID)
   End Sub

End Class