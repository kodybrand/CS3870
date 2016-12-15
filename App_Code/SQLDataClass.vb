Imports Microsoft.VisualBasic

Public Class SQLDataClass
   Private Const ConStr As String = "Data Source=Alpha;” &
          “Initial Catalog=UWPCS3870;Persist Security Info=True;” &
          “User ID=MSCS;Password=MasterInCS"

   'Private Const ConStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\UWPCS3870.accdb"

   'Private Const ConStr As String = "Data Source=|DataDirectory|\UWPCS3870.accdb"

   Private Shared prodAdapter As System.Data.SqlClient.SqlDataAdapter
   ' Private Shared prodBuilder As System.Data.SqlClient.SqlDataAdapter
   Private Shared prodCmd As New Data.SqlClient.SqlCommand
   Private Shared con As New Data.SqlClient.SqlConnection

   Public Shared tblProducts As New Data.DataTable

   Public Shared Sub setupProdAdapter()
      con.ConnectionString = ConStr

      'con.ConnectionString = "Data Source=~\App_Data\UWPCS3870.accdb"

      prodCmd.Connection = con
      prodCmd.CommandType = Data.CommandType.Text
      prodCmd.CommandText = "Select * from Product order by ProductID"

      prodAdapter = New System.Data.SqlClient.SqlDataAdapter(prodCmd)

      prodAdapter.FillSchema(tblProducts, Data.SchemaType.Source)
   End Sub

   Public Shared Sub getAllProdcts()
      If prodAdapter Is Nothing Then
         setupProdAdapter()
      End If

      ' Need to reset the command
      prodCmd.CommandText = "Select * from Product order by ProductID"

      Try
         If Not tblProducts Is Nothing Then
            tblProducts.Clear()
         End If
         prodAdapter.Fill(tblProducts)

      Catch ex As Exception
         Throw ex
      Finally
         con.Close()
      End Try
   End Sub

   Public Shared Sub UpdateProduct(theID As String, newName As String, newPrice As Double, newDesc As String)
      If prodAdapter Is Nothing Then
         setupProdAdapter()
      End If

      ' Building SQL statement with variables
      prodCmd.CommandText = " Update Product" &
                                    " Set ProductName = '" & newName & "', " &
                                    "     UnitPrice   = " & newPrice & ", " &
                                    "     Description = '" & newDesc & "' " &
                                    " Where ProductID = '" & theID & "'"

      Try
         con.Open()
         prodCmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw New Exception(ex.Message & “ ” & prodCmd.CommandText)

      Finally
         con.Close()
      End Try
   End Sub

   Public Shared Sub saveProduct(pID As String, pname As String, uprice As Double, desc As String)
      If prodAdapter Is Nothing Then
         setupProdAdapter()
      End If

      prodCmd.CommandText = " Insert into Product" +
                            " Values('" & pID & "', '" & pname & "', " & uprice & ", '" & desc & "')"

      Try
         con.Open()
         prodCmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      Finally
         con.Close()
      End Try

   End Sub

   Public Shared Sub deleteProduct(pID As String)
      If prodAdapter Is Nothing Then
         setupProdAdapter()
      End If

      prodCmd.CommandText = " Delete from Product" +
                            " Where ProductID = '" & pID & "'"

      Try
         con.Open()
         prodCmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      Finally
         con.Close()
      End Try
   End Sub


   Public Shared Function NewShoppingBag() As Data.DataTable
      Dim bag As New Data.DataTable

      bag.Columns.Add("Product ID")
      bag.Columns.Add("Product Name")
      bag.Columns.Add("Unit Price")
      bag.Columns.Add("Quantity")
      bag.Columns.Add("Cost")

      Dim PK() As Data.DataColumn = {bag.Columns(0)}
      bag.PrimaryKey = PK

      Return bag
   End Function

End Class
