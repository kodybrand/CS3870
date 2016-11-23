
Partial Class Prog6_Admin_SetRoles
   Inherits System.Web.UI.Page

   Private Sub Prog6_Admin_SetRoles_Load(sender As Object, e As EventArgs) Handles Me.Load
      If Not IsPostBack Then
         Try
            ListUsersBind（）
            ListRolesBind()
            ListUsersInRolesBind()
         Catch ex As Exception
            txtMessage.Text = ex.Message
         End Try
      End If

   End Sub
   Protected Sub btnAddUserToRole_Click(sender As Object, e As EventArgs) Handles btnAddUserToRole.Click
      Try
         Roles.AddUserToRole(lstUsers.Text,
                  lstRoles.SelectedValue)
         txtMessage.Text = "User has been added from role."
         ListUsersInRolesBind()
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try

   End Sub

   Private Sub ListRolesBind()
      Try
         lstRoles.DataSource = Roles.GetAllRoles()
         lstRoles.DataBind()
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try
   End Sub

   Private Sub ListUsersInRolesBind()
      Try
         lstUsersInRoles.DataSource =
         Roles.GetUsersInRole(lstRoles.SelectedValue)
         lstUsersInRoles.DataBind()
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try
   End Sub

   Private Sub ListUsersBind()
      lstUsers.DataSource = Membership.GetAllUsers()
      lstUsers.DataBind()
   End Sub

   Private Sub btnAddRole_Click(sender As Object, e As EventArgs) Handles btnAddRole.Click
      Try
         ' Role name is txtRoles.Text
         Roles.CreateRole(txtRoles.Text)
         txtMessage.Text = "The role has been created."
         ListRolesBind()
         ListUsersInRolesBind()
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try

   End Sub

   Private Sub btnRemoveRole_Click(sender As Object, e As EventArgs) Handles btnRemoveRole.Click
      Try
         ' Delete the selected role 
         Roles.DeleteRole(lstRoles.Text)
         txtMessage.Text = "The role has been removed."
         ListRolesBind()
         ListUsersInRolesBind()
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try

   End Sub

   Private Sub btnRemoveUserFromRole_Click(sender As Object, e As EventArgs) Handles btnRemoveUserFromRole.Click
      Try
         Roles.RemoveUserFromRole(lstUsersInRoles.Text,
                lstRoles.Text)
         txtMessage.Text = "User has been removed from role."
         ListUsersInRolesBind()
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try

   End Sub

   Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
      Try
         Membership.DeleteUser(lstUsers.Text, True)
         txtMessage.Text = "User " & lstUsers.Text &
             " has been deleted."
         ListUsersBind（）
         ListUsersInRolesBind（）
      Catch ex As Exception
         txtMessage.Text = ex.Message
      End Try

   End Sub

   Private Sub lstRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRoles.SelectedIndexChanged
      Roles.GetUsersInRole(lstRoles.Text)
      ListUsersBind()
      ListUsersInRolesBind()
   End Sub
End Class
