Imports System.Web.Security
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Configuration
Imports System.Diagnostics
Imports System.Web
Imports System.Globalization
Imports Microsoft.VisualBasic

' 
' This provider works with the following schema for the tables of role data. 
'  
' CREATE TABLE Roles 
' ( 
'   Rolename Text (128) NOT NULL, 
'   ApplicationName Text (255) NOT NULL, 
'     CONSTRAINT PKRoles PRIMARY KEY (Rolename, ApplicationName) 
' ) 
' 
' CREATE TABLE UsersInRoles 
' ( 
'   Username Text (128) NOT NULL, 
'   Rolename Text (128) NOT NULL, 
'   ApplicationName Text (128) NOT NULL, 
'     CONSTRAINT PKUsersInRoles PRIMARY KEY (Username, Rolename, ApplicationName) 
' ) 
' 
' 


Namespace UWPCS3870

   Public NotInheritable Class AlphaRoleProvider
      Inherits RoleProvider

      ' 
      ' Global OdbcConnection, generated password length, generic exception message, event log info. 
      ' 

      Private alphaAdapter As System.Data.SqlClient.SqlDataAdapter
      Private alphaBuilder As System.Data.SqlClient.SqlDataAdapter
      Private alphaCmd As New Data.SqlClient.SqlCommand
      Private conn As New Data.SqlClient.SqlConnection
      Private tblRoles As New Data.DataTable("Roles")

      'Private eventSource As String = "OdbcRoleProvider"
      'Private eventLog As String = "Application"
      'Private exceptionMessage As String = "An exception occurred. Please check the Event Log."

      Private pConnectionStringSettings As ConnectionStringSettings
      Private connectionString As String

      ' If false, exceptions are Thrown to the caller. If true, 
      ' exceptions are written to the event log. 
      Private pWriteExceptionsToEventLog As Boolean = False

      Public Property WriteExceptionsToEventLog As Boolean
         Get
            Return pWriteExceptionsToEventLog
         End Get
         Set
            pWriteExceptionsToEventLog = Value
         End Set
      End Property

      ' System.Configuration.Provider.ProviderBase.Initialize Method 
      Public Overrides Sub Initialize(name As String, config As NameValueCollection)

         ' Initialize values from web.config. 

         If config Is Nothing Then _
            Throw New ArgumentNullException("config")

         If name Is Nothing OrElse name.Length = 0 Then _
            name = "OdbcRoleProvider"

         If String.IsNullOrEmpty(config("description")) Then
            config.Remove("description")
            config.Add("description", "Sample ODBC Role provider")
         End If

         ' Initialize the abstract base class. 
         MyBase.Initialize(name, config)

         If config("applicationName") Is Nothing OrElse config("applicationName").Trim() = "" Then
            pApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath
         Else
            pApplicationName = config("applicationName")
         End If

         'If Not config("writeExceptionsToEventLog") Is Nothing Then
         '   If config("writeExceptionsToEventLog").ToUpper() = "TRUE" Then
         '      pWriteExceptionsToEventLog = True
         '   End If
         'End If

         ' Initialize OdbcConnection. 
         pConnectionStringSettings =
            ConfigurationManager.ConnectionStrings(config("connectionStringName"))

         If pConnectionStringSettings Is Nothing OrElse pConnectionStringSettings.ConnectionString.Trim() = "" Then
            Throw New ProviderException("Connection string cannot be blank.")
         End If

         connectionString = pConnectionStringSettings.ConnectionString

         ' Added
         alphaCmd.CommandType = CommandType.Text
         conn.ConnectionString = connectionString
         alphaCmd.Connection = conn

      End Sub

      ' System.Web.Security.RoleProvider properties. 
      Private pApplicationName As String

      Public Overrides Property ApplicationName As String
         Get
            Return pApplicationName
         End Get
         Set
            pApplicationName = Value
         End Set
      End Property

      ' 
      ' System.Web.Security.RoleProvider methods. 
      ' 
      ' RoleProvider.AddUsersToRoles 
      Public Overrides Sub AddUsersToRoles(usernames As String(), rolenames As String())
         For Each rolename As String In rolenames
            If Not RoleExists(rolename) Then
               Throw New ProviderException("Role name not found.")
            End If
         Next

         For Each username As String In usernames
            If username.Contains(",") Then
               Throw New ArgumentException("User names cannot contain commas.")
            End If

            For Each rolename As String In rolenames
               If IsUserInRole(username, rolename) Then
                  Throw New ProviderException("User is already in role.")
               End If
            Next
         Next

         '         Dim tran As System.Data.IDbTransaction = Nothing
         Dim tran As SqlClient.SqlTransaction = Nothing

         Try
            conn.Open()
            tran = conn.BeginTransaction()
            alphaCmd.Transaction = tran

            For Each username As String In usernames
               For Each rolename As String In rolenames
                  alphaCmd.CommandText = " INSERT INTO UsersInRoles " &
                                        " (Username, Rolename, ApplicationName) " &
                                        " Values('" & username & "', '" & rolename & "', '" & ApplicationName & "')"

                  alphaCmd.ExecuteNonQuery()
               Next
            Next

            tran.Commit()
         Catch e As Exception
            Try
               tran.Rollback()
            Catch
            End Try
         Finally
            conn.Close()
         End Try
      End Sub

      ' RoleProvider.CreateRole 
      Public Overrides Sub CreateRole(rolename As String)

         If rolename.Contains(",") Then
            Throw New ArgumentException("Role names cannot contain commas.")
         End If

         If RoleExists(rolename) Then
            Throw New ProviderException("Role name already exists.")
         End If


         alphaCmd.CommandText = " INSERT INTO Roles " &
                               " (Rolename, ApplicationName) " &
                               " Values('" & rolename & "', '" & ApplicationName & "')"

         Try
            conn.Open()

            alphaCmd.ExecuteNonQuery()
         Catch e As Exception
            Throw e
         Finally
            conn.Close()
         End Try
      End Sub

      ' RoleProvider.DeleteRole 
      Public Overrides Function DeleteRole(ByVal rolename As String, ByVal throwOnPopulatedRole As Boolean) As Boolean

         If Not RoleExists(rolename) Then
            Throw New ProviderException("Role does not exist.")
         End If

         'If throwOnPopulatedRole AndAlso GetUsersInRole(rolename).Length > 0 Then
         '   Throw New ProviderException("Cannot delete a populated role.")
         'End If

         alphaCmd.CommandText = " DELETE FROM Roles " &
                                " WHERE Rolename = '" & rolename & "' and ApplicationName = '" & ApplicationName & "' "

         Dim cmd2 As New Data.SqlClient.SqlCommand
         cmd2.Connection = conn
         cmd2.CommandType = CommandType.Text
         cmd2.CommandText = " DELETE FROM UsersInRoles " &
                            " WHERE Rolename = '" & rolename & "' and ApplicationName = '" & ApplicationName & "' "

         Dim tran As SqlClient.SqlTransaction = Nothing   '  
         '         Dim tran As System.Data.IDbTransaction = Nothing

         Try
            conn.Open()
            tran = conn.BeginTransaction()
            alphaCmd.Transaction = tran
            cmd2.Transaction = tran

            cmd2.ExecuteNonQuery()
            alphaCmd.ExecuteNonQuery()

            tran.Commit()
         Catch e As Exception
            Try
               tran.Rollback()
            Catch
            End Try

            Throw e
         Finally
            conn.Close()
         End Try

         Return True
      End Function

      ' RoleProvider.GetAllRoles 
      Public Overrides Function GetAllRoles() As String()
         Dim tmpRoleNames As String = ""

         alphaCmd.CommandText = " SELECT Rolename FROM Roles " &
                                " WHERE ApplicationName = '" & ApplicationName & "'"

         Dim reader As SqlClient.SqlDataReader = Nothing

         Try
            conn.Open()

            reader = alphaCmd.ExecuteReader()

            Do While reader.Read()
               tmpRoleNames &= reader.GetString(0) & ","
            Loop

         Catch e As Exception
            Throw e
         Finally
            If Not reader Is Nothing Then reader.Close()
            conn.Close()
         End Try

         If tmpRoleNames.Length > 0 Then
            ' Remove trailing comma.
            tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1)
            Return tmpRoleNames.Split(CChar(","))
         End If

         Return New String() {}
      End Function

      ' RoleProvider.GetRolesForUser 
      Public Overrides Function GetRolesForUser(ByVal username As String) As String()
         Dim tmpRoleNames As String = ""

         alphaCmd.CommandText = " SELECT Rolename FROM UsersInRoles " &
                                " WHERE Username = '" & username & "' " &
                                "   and ApplicationName = '" & ApplicationName & "'"

         Dim reader As SqlClient.SqlDataReader = Nothing

         Try
            conn.Open()

            reader = alphaCmd.ExecuteReader()

            Do While reader.Read()
               tmpRoleNames &= reader.GetString(0) & ","
            Loop
         Catch e As Exception
            Throw e
         Finally
            If Not reader Is Nothing Then reader.Close()
            conn.Close()
         End Try

         If tmpRoleNames.Length > 0 Then
            ' Remove trailing comma.
            tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1)
            Return tmpRoleNames.Split(CChar(","))
         End If

         Return New String() {}
      End Function

      ' RoleProvider.GetUsersInRole 
      Public Overrides Function GetUsersInRole(ByVal rolename As String) As String()
         Dim tmpUserNames As String = ""

         alphaCmd.CommandText = " SELECT Username FROM UsersInRoles " &
                                 " WHERE Rolename = '" & rolename & "' " &
                                 "   And ApplicationName = '" & ApplicationName & "' "

         Dim reader As SqlClient.SqlDataReader = Nothing

         Try
            conn.Open()

            reader = alphaCmd.ExecuteReader()

            Do While reader.Read()
               tmpUserNames &= reader.GetString(0) & ","
            Loop
         Catch e As Exception
            Throw e
         Finally
            If Not reader Is Nothing Then reader.Close()
            conn.Close()
         End Try

         If tmpUserNames.Length > 0 Then
            ' Remove trailing comma.
            tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1)
            Return tmpUserNames.Split(CChar(","))
         End If

         Return New String() {}
      End Function

      ' RoleProvider.IsUserInRole 
      Public Overrides Function IsUserInRole(ByVal username As String, ByVal rolename As String) As Boolean

         Dim userIsInRole As Boolean = False

         alphaCmd.CommandText = " SELECT COUNT(*) " &
                                " FROM UsersInRoles " &
                                " WHERE Username = '" & username & "' " &
                                "   And Rolename = '" & rolename & "' " &
                                "   And ApplicationName = '" & ApplicationName & "' "

         Try
            conn.Open()

            Dim numRecs As Integer = CType(alphaCmd.ExecuteScalar(), Integer)

            If numRecs > 0 Then
               userIsInRole = True
            End If
         Catch e As Exception
            Throw e
         Finally
            conn.Close()
         End Try

         Return userIsInRole
      End Function

      ' RoleProvider.RemoveUsersFromRoles 
      Public Overrides Sub RemoveUsersFromRoles(ByVal usernames As String(), ByVal rolenames As String())

         For Each rolename As String In rolenames
            If Not RoleExists(rolename) Then
               Throw New ProviderException("Role name Not found.")
            End If
         Next

         For Each username As String In usernames
            For Each rolename As String In rolenames
               If Not IsUserInRole(username, rolename) Then
                  Throw New ProviderException("User Is Not in role.")
               End If
            Next
         Next

         Dim tran As SqlClient.SqlTransaction = Nothing

         Try
            conn.Open()
            tran = conn.BeginTransaction
            alphaCmd.Transaction = tran

            For Each username As String In usernames
               For Each rolename As String In rolenames
                  alphaCmd.CommandText = " DELETE FROM UsersInRoles " &
                                         " WHERE Username = '" & username & "' " &
                                         "   And Rolename = '" & rolename & "' " &
                                         "   And ApplicationName = '" & ApplicationName & "' "

                  alphaCmd.ExecuteNonQuery()
               Next
            Next

            tran.Commit()
         Catch e As Exception
            Try
               tran.Rollback()
            Catch
            End Try

            Throw e
         Finally
            conn.Close()
         End Try
      End Sub

      ' RoleProvider.RoleExists 
      Public Overrides Function RoleExists(ByVal rolename As String) As Boolean
         Dim exists As Boolean = False

         alphaCmd.CommandText = " SELECT COUNT(*) FROM Roles " &
                               " WHERE Rolename = '" & rolename & "' " &
                               "   And ApplicationName = '" & ApplicationName & "' "

         Try
            conn.Open()

            Dim numRecs As Integer = CType(alphaCmd.ExecuteScalar(), Integer)

            If numRecs > 0 Then
               exists = True
            End If
         Catch e As Exception
            Throw e
         Finally
            conn.Close()
         End Try

         Return exists
      End Function

      ' RoleProvider.FindUsersInRole 
      Public Overrides Function FindUsersInRole(ByVal rolename As String, ByVal usernameToMatch As String) As String()

         alphaCmd.CommandText = " SELECT Username FROM UsersInRoles  " &
                                " WHERE Username Like '%" & usernameToMatch & "%' " &
                                "   And RoleName = '" & rolename & "' " &
                                "   And ApplicationName = '" & "' "

         Dim tmpUserNames As String = ""
         Dim reader As SqlClient.SqlDataReader = Nothing

         Try
            conn.Open()

            reader = alphaCmd.ExecuteReader()

            Do While reader.Read()
               tmpUserNames &= reader.GetString(0) & ","
            Loop
         Catch e As Exception
            Throw e
         Finally
            If Not reader Is Nothing Then reader.Close()

            conn.Close()
         End Try

         If tmpUserNames.Length > 0 Then
            ' Remove trailing comma.
            tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1)
            Return tmpUserNames.Split(CChar(","))
         End If

         Return New String() {}
      End Function

   End Class
End Namespace
