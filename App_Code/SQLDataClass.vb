Imports Microsoft.VisualBasic

Public Class SQLDataClass
    Private Const ConStr As String = "Data Source=Alpha;” &
           “Initial Catalog=UWPCS3870;Persist Security Info=True;” &
           “User ID=MSCS;Password=MasterInCS"

    Private Shared prodAdapter As System.Data.SqlClient.SqlDataAdapter
    Private Shared prodBuilder As System.Data.SqlClient.SqlDataAdapter
    Private Shared prodCmd As New Data.SqlClient.SqlCommand
    Private Shared con As New Data.SqlClient.SqlConnection

    Public Shared tblProducts As New Data.DataTable("Product")

    ' Sets up the connection, command and adapter
    Public Shared Sub setupProdAdapter()
        con.ConnectionString = ConStr

        prodCmd.Connection = con
        prodCmd.CommandType = Data.CommandType.Text
        prodCmd.CommandText = "Select * from Product order by ProductID"

        prodAdapter = New System.Data.SqlClient.SqlDataAdapter(prodCmd)

        prodAdapter.FillSchema(tblProducts, Data.SchemaType.Source)
    End Sub

    Public Shared Sub getAllProducts()
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



End Class
