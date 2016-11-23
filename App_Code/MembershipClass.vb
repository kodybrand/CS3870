' Imports Microsoft.VisualBasic
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
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Configuration

Namespace UWPCS3870

   Public NotInheritable Class AlphaMembershipProvider

      Inherits MembershipProvider

      '      Private Const ConStr As String = "Data Source=Alpha;Initial Catalog=UWPCS3870;Persist Security Info=True;User ID=MSCS;Password=MasterInCS"
      Private alphaAdapter As System.Data.SqlClient.SqlDataAdapter
      Private alphaBuilder As System.Data.SqlClient.SqlDataAdapter
      Private alphaCmd As New Data.SqlClient.SqlCommand
      Private conn As New Data.SqlClient.SqlConnection
      Private tblUsers As New Data.DataTable("User")

      ' Global generated password length, generic exception message, event log info. 
      Private newPasswordLength As Integer = 8
      Private eventSource As String = "OdbcMembershipProvider"
      Private eventLog As String = "Application"
      Private exceptionMessage As String = "An exception occurred. Please check the Event Log."
      Private connectionString As String

      ' System.Web.Security.MembershipProvider properties. 
      Private pApplicationName As String
      Private pEnablePasswordReset As Boolean
      Private pEnablePasswordRetrieval As Boolean
      Private pRequiresQuestionAndAnswer As Boolean
      Private pRequiresUniqueEmail As Boolean
      Private pMaxInvalidPasswordAttempts As Integer
      Private pPasswordAttemptWindow As Integer
      Private pPasswordFormat As MembershipPasswordFormat

      ' Used when determining encryption key values. 
      Private machineKey As MachineKeySection

      ' If False, exceptions are thrown to the caller. If True, 
      ' exceptions are written to the event log. 
      Private pWriteExceptionsToEventLog As Boolean

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
            name = "AlphaMembershipProvider"

         If String.IsNullOrEmpty(config("description")) Then
            config.Remove("description")
            config.Add("description", "Membership provider on Alpha")
         End If

         ' Initialize the abstract base class. 
         MyBase.Initialize(name, config)

         pApplicationName = GetConfigValue(config("applicationName"),
                                        System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
         pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config("maxInvalidPasswordAttempts"), "5"))
         pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config("passwordAttemptWindow"), "10"))
         pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config("minRequiredAlphaNumericCharacters"), "1"))
         pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config("minRequiredPasswordLength"), "7"))
         pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config("passwordStrengthRegularExpression"), ""))
         pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config("enablePasswordReset"), "False"))
         pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config("enablePasswordRetrieval"), "False"))
         pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config("requiresQuestionAndAnswer"), "False"))
         pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config("requiresUniqueEmail"), "false"))
         pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config("writeExceptionsToEventLog"), "False"))

         Dim temp_format As String = config("passwordFormat")
         If temp_format Is Nothing Then
            temp_format = "Hashed"
         End If

         Select Case temp_format
            Case "Hashed"
               pPasswordFormat = MembershipPasswordFormat.Hashed
            Case "Encrypted"
               pPasswordFormat = MembershipPasswordFormat.Encrypted
            Case "Clear"
               pPasswordFormat = MembershipPasswordFormat.Clear
            Case Else
               Throw New ProviderException("Password format not supported.")
         End Select

         ' Initialize AlphaConnection. 
         Dim ConnectionStringSettings As ConnectionStringSettings =
             ConfigurationManager.ConnectionStrings(config("connectionStringName"))

         If ConnectionStringSettings Is Nothing OrElse ConnectionStringSettings.ConnectionString.Trim() = "" Then
            Throw New ProviderException("Connection string cannot be blank.")
         End If

         connectionString = ConnectionStringSettings.ConnectionString

         ' Added
         alphaCmd.CommandType = CommandType.Text
         conn.ConnectionString = connectionString
         alphaCmd.Connection = conn

         ' Get encryption and decryption key information from the configuration. 
         Dim cfg As System.Configuration.Configuration =
             WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
         machineKey = CType(cfg.GetSection("system.web/machineKey"), MachineKeySection)

         If machineKey.ValidationKey.Contains("AutoGenerate") Then _
            If PasswordFormat <> MembershipPasswordFormat.Clear Then _
               Throw New ProviderException("Hashed or Encrypted passwords " &
                                           "are not supported with auto-generated keys.")
      End Sub

      ' A helper function to retrieve config values from the configuration file. 
      Private Function GetConfigValue(configValue As String, defaultValue As String) As String
         If String.IsNullOrEmpty(configValue) Then _
            Return defaultValue

         Return configValue
      End Function

      Public Overrides Property ApplicationName As String
         Get
            Return pApplicationName
         End Get
         Set
            pApplicationName = Value
         End Set
      End Property

      Public Overrides ReadOnly Property EnablePasswordReset As Boolean
         Get
            Return pEnablePasswordReset
         End Get
      End Property

      Public Overrides ReadOnly Property EnablePasswordRetrieval As Boolean
         Get
            Return pEnablePasswordRetrieval
         End Get
      End Property

      Public Overrides ReadOnly Property RequiresQuestionAndAnswer As Boolean
         Get
            Return pRequiresQuestionAndAnswer
         End Get
      End Property

      Public Overrides ReadOnly Property RequiresUniqueEmail As Boolean
         Get
            Return pRequiresUniqueEmail
         End Get
      End Property

      Public Overrides ReadOnly Property MaxInvalidPasswordAttempts As Integer
         Get
            Return pMaxInvalidPasswordAttempts
         End Get
      End Property

      Public Overrides ReadOnly Property PasswordAttemptWindow As Integer
         Get
            Return pPasswordAttemptWindow
         End Get
      End Property

      Public Overrides ReadOnly Property PasswordFormat As MembershipPasswordFormat
         Get
            Return pPasswordFormat
         End Get
      End Property

      Private pMinRequiredNonAlphanumericCharacters As Integer

      Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
         Get
            Return pMinRequiredNonAlphanumericCharacters
         End Get
      End Property

      Private pMinRequiredPasswordLength As Integer

      Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
         Get
            Return pMinRequiredPasswordLength
         End Get
      End Property

      Private pPasswordStrengthRegularExpression As String

      Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
         Get
            Return pPasswordStrengthRegularExpression
         End Get
      End Property

      ' 
      ' System.Web.Security.MembershipProvider methods. 
      ' 

      ' MembershipProvider.ChangePassword: Do Not change password 
      Public Overrides Function ChangePassword(username As String,
                                               oldPwd As String,
                                               newPwd As String) As Boolean
         Return False
      End Function

      ' MembershipProvider.ChangePasswordQuestionAndAnswer: We do Not change it.
      Public Overrides Function ChangePasswordQuestionAndAnswer(username As String,
                    password As String,
                    newPwdQuestion As String,
                    newPwdAnswer As String) As Boolean
         Return False
      End Function

      ' MembershipProvider.CreateUser 
      Public Overrides Function CreateUser(ByVal username As String, ByVal password As String,
                                           ByVal email As String, ByVal passwordQuestion As String,
                                           ByVal passwordAnswer As String, ByVal isApproved As Boolean,
                                           ByVal providerUserKey As Object, ByRef status As MembershipCreateStatus) As MembershipUser

         alphaCmd.CommandText = " Insert into [Users] ([Username], [ApplicationName], [Password]) " +
                                " Values('" & username & "', '" & ApplicationName & "', '" & EncodePassword(password) & "') "

         Try
            conn.Open()
            alphaCmd.ExecuteNonQuery()
         Catch ex As Exception
            Throw ex
         Finally
            conn.Close()
         End Try

         Return Nothing
      End Function

      ' MembershipProvider.DeleteUser
      Public Overrides Function DeleteUser(username As String,
                                         deleteAllRelatedData As Boolean) As Boolean

         alphaCmd.CommandText = " Delete From [UsersInRoles] " +
                                " Where [Username] = '" & username & "' " +
                                "   and [ApplicationName] = '" & ApplicationName & "'"

         Try
            conn.Open()
            alphaCmd.ExecuteNonQuery()
         Catch ex As Exception
            Throw ex
         Finally
            conn.Close()
         End Try

         alphaCmd.CommandText = " Delete From [Users] " +
                                " Where [Username] = '" & username & "' " +
                                "   and [ApplicationName] = '" & ApplicationName & "'"

         Dim rowsAffected As Integer = 0

         Try
            conn.Open()
            rowsAffected = alphaCmd.ExecuteNonQuery
         Catch ex As Exception
            Throw ex
         Finally
            conn.Close()
         End Try

         If rowsAffected > 0 Then
            Return True
         Else
            Return False
         End If
      End Function


      ' 
      ' MembershipProvider.GetAllUsers: may not need it
      Public Overrides Function GetAllUsers(ByVal pageIndex As Integer,
                                            ByVal pageSize As Integer,
                                            ByRef totalRecords As Integer) _
                                  As MembershipUserCollection
         Dim users As MembershipUserCollection = New MembershipUserCollection()

         alphaCmd.CommandText = " SELECT * FROM Users " &
                                " where ApplicationName = '" & ApplicationName & "' "


         Dim reader As SqlClient.SqlDataReader = Nothing

         Try
            conn.Open()

            reader = alphaCmd.ExecuteReader()

            Do While reader.Read()

               Dim u As MembershipUser = GetUserFromReader(reader)
               users.Add(u)

            Loop

         Catch e As Exception
            Throw e
         Finally
            If Not reader Is Nothing Then reader.Close()
            conn.Close()
         End Try



         Return users
      End Function

      ' 
      ' MembershipProvider.GetNumberOfUsersOnline: not need for now
      Public Overrides Function GetNumberOfUsersOnline() As Integer
         Return 0
      End Function

      ' 
      ' MembershipProvider.GetPassword: not needed
      Public Overrides Function GetPassword(username As String, answer As String) As String
         Return ""
      End Function

      ' 
      ' MembershipProvider.GetUser(String, Boolean): not needed
      Public Overrides Function GetUser(ByVal username As String,
      ByVal userIsOnline As Boolean) As MembershipUser
         Return Nothing
      End Function

      ' 
      ' MembershipProvider.GetUser(Object, Boolean): not needed
      Public Overrides Function GetUser(ByVal providerUserKey As Object,
      ByVal userIsOnline As Boolean) As MembershipUser
         Return Nothing
      End Function

      ' GetUserFromReader 
      '    A helper function that takes the current row from the OdbcDataReader 
      ' and hydrates a MembershiUser from the values. Called by the  
      ' MembershipUser.GetUser implementation. 
      ' 

      Private Function GetUserFromReader(ByVal reader As SqlClient.SqlDataReader) As MembershipUser
         Dim providerUserKey As Object = reader.GetValue(1)
         Dim username As String = reader.GetString(0)
         Dim email As String = "email"      'reader.GetString(2)

         Dim passwordQuestion As String = ""
         'If Not reader.GetValue(5) Is DBNull.Value Then _
         '     passwordQuestion = reader.GetString(5)

         Dim comment As String = ""
         'If Not reader.GetValue(3) Is DBNull.Value Then _
         '     comment = reader.GetString(3)

         Dim isApproved As Boolean = True    'reader.GetBoolean(5)
         Dim isLockedOut As Boolean = False     'reader.GetBoolean(6)
         Dim creationDate As DateTime = New DateTime()      'reader.GetDateTime(11)

         Dim lastLoginDate As DateTime = New DateTime()
         'If Not reader.GetValue(8) Is DBNull.Value Then _
         '     lastLoginDate = reader.GetDateTime(8)

         Dim lastActivityDate As DateTime = New DateTime()     'reader.GetDateTime(9)
         Dim lastPasswordChangedDate As DateTime = New DateTime()    'reader.GetDateTime(10)

         Dim lastLockedOutDate As DateTime = New DateTime()
         'If Not reader.GetValue(11) Is DBNull.Value Then _
         '     lastLockedOutDate = reader.GetDateTime(11)

         Dim u As MembershipUser = New MembershipUser(Me.Name,
                                                  username,
                                                  providerUserKey,
                                                  email,
                                                  passwordQuestion,
                                                  comment,
                                                  isApproved,
                                                  isLockedOut,
                                                  creationDate,
                                                  lastLoginDate,
                                                  lastActivityDate,
                                                  lastPasswordChangedDate,
                                                  lastLockedOutDate)

         Return u
      End Function

      ' 
      ' MembershipProvider.UnlockUser: not needed
      Public Overrides Function UnlockUser(ByVal username As String) As Boolean
         Return False
      End Function

      ' 
      ' MembershipProvider.GetUserNameByEmail: not needed
      Public Overrides Function GetUserNameByEmail(email As String) As String
         Return ""
      End Function

      ' 
      ' MembershipProvider.ResetPassword: not needed
      Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String
         Return ""
      End Function

        ' 
        ' MembershipProvider.UpdateUser: not needed
        Public Overrides Sub UpdateUser(ByVal user As MembershipUser)
            Dim x As Integer
            x += 1

        End Sub

        ' 
        ' MembershipProvider.ValidateUser 
        Public Overrides Function ValidateUser(username As String, password As String) As Boolean
         Dim isValid As Boolean = False
         Dim counter As Integer = 0

         password = EncodePassword(password)
         alphaCmd.CommandText = " Select * From [Users] " &
                                " Where [Username] = '" & username & "' " &
                                "  and  [Password] = '" & password & "' " &
                                "  and  [ApplicationName] = '" & ApplicationName & "'"

         Try
            Dim reader As System.Data.SqlClient.SqlDataReader

            conn.Open()
            reader = alphaCmd.ExecuteReader

            Do While reader.Read()
               counter += 1
            Loop

         Catch ex As Exception
            Throw ex
         Finally
            conn.Close()
         End Try

         If counter = 1 Then
            isValid = True
         Else
            isValid = False
         End If

         Return isValid
      End Function

      ' 
      ' UpdateFailureCount 
      '   A helper method that performs the checks and updates associated with 
      ' password failure tracking: not needed
      Private Sub UpdateFailureCount(username As String, failureType As String)
      End Sub

      ' 
      ' CheckPassword 
      '   Compares password values based on the MembershipPasswordFormat: not needed
      Private Function CheckPassword(password As String, dbpassword As String) As Boolean
         Return True
      End Function

      ' 
      ' EncodePassword 
      '   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat. 
      Private Function EncodePassword(password As String) As String
         Dim encodedPassword As String = password

         Select Case PasswordFormat
            Case MembershipPasswordFormat.Clear

            Case MembershipPasswordFormat.Encrypted
               encodedPassword =
            Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)))
            Case MembershipPasswordFormat.Hashed
               Dim hash As HMACSHA1 = New HMACSHA1()
               hash.Key = HexToByte(machineKey.ValidationKey)
               encodedPassword =
            Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)))
            Case Else
               Throw New ProviderException("Unsupported password format.")
         End Select

         Return encodedPassword
      End Function

      ' 
      ' UnEncodePassword 
      '   Decrypts or leaves the password clear based on the PasswordFormat. 
      Private Function UnEncodePassword(encodedPassword As String) As String
         Dim password As String = encodedPassword

         Select Case PasswordFormat
            Case MembershipPasswordFormat.Clear

            Case MembershipPasswordFormat.Encrypted
               password =
            Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)))
            Case MembershipPasswordFormat.Hashed
               Throw New ProviderException("Cannot unencode a hashed password.")
            Case Else
               Throw New ProviderException("Unsupported password format.")
         End Select

         Return password
      End Function

      ' 
      ' HexToByte 
      '   Converts a hexadecimal string to a byte array. Used to convert encryption 
      ' key values from the configuration. 
      Private Function HexToByte(hexString As String) As Byte()
         Dim ReturnBytes((hexString.Length \ 2) - 1) As Byte
         For i As Integer = 0 To ReturnBytes.Length - 1
            ReturnBytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
         Next
         Return ReturnBytes
      End Function

      ' 
      ' MembershipProvider.FindUsersByName 
      Public Overrides Function FindUsersByName(usernameToMatch As String,
                                                pageIndex As Integer,
                                                pageSize As Integer,
                                                ByRef totalRecords As Integer) _
                                As MembershipUserCollection
         Dim users As MembershipUserCollection = New MembershipUserCollection()
         Return users
      End Function

      ' 
      ' MembershipProvider.FindUsersByEmail 
      Public Overrides Function FindUsersByEmail(emailToMatch As String,
                                               pageIndex As Integer,
                                               pageSize As Integer,
                                               ByRef totalRecords As Integer) _
                              As MembershipUserCollection
         Dim users As MembershipUserCollection = New MembershipUserCollection()
         Return users
      End Function

   End Class

End Namespace
