
Partial Class Prog4_Prog4MasterPage
   Inherits System.Web.UI.MasterPage
   ' Make a public function to return the DataSource
   Public Function MyDataSource() As SqlDataSource
      Return SqlDataSource1
   End Function

End Class

