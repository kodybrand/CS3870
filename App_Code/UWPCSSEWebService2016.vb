Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="https://alpha.ion.uwplatt.edu/BrandK/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class UWPCSSEWebService2016
   Inherits System.Web.Services.WebService

   <WebMethod()>
   Public Function HelloWorld() As String
      Return "Hello World"
   End Function

   <WebMethod()>
   Public Function WS_GetAllProducts() As Data.DataTable
      SQLDataClass.setupProdAdapter()
      SQLDataClass.getAllProducts()
      Return SQLDataClass.tblProduct
   End Function

End Class