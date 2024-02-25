Imports System.Data.SqlClient
Imports AFBO
Imports [Interface]

Namespace AnonForum
    Public Class UserAuthDAL
        Implements IUser

        Private ReadOnly strConn As String
        Private conn As SqlConnection
        Private cmd As SqlCommand
        Private dr As SqlDataReader

        Public Sub New()
            strConn = "Server=.\BSISqlExpress;Database=AnonForum;Trusted_Connection=True;"
            conn = New SqlConnection(strConn)
        End Sub

        'Public Function GetAllUser() As List(Of UserAuth) Implements IUser.GetAllUsers
        '    Throw New NotImplementedException()
        'End Function

        Public Function GetAll() As List(Of UserAuth) Implements IUser.GetAllUser
            Dim UserAuths As New List(Of UserAuth)
            Try
                Dim strSql = "SELECT * FROM dbo.UserAuth"

                conn = New SqlConnection(strConn)
                cmd = New SqlCommand(strSql, conn)
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read
                        Dim user As New UserAuth With {
                            .UserID = CInt(dr("UserID")),
                            .Username = dr("Username").ToString(),
                            .Email = dr("Email").ToString(),
                            .Nickname = dr("Nickname").ToString()
                        }
                        UserAuths.Add(user)
                    End While
                End If
                dr.Close()

                Return UserAuths
            Catch ex As Exception
                Throw
            Finally
                cmd.Dispose()
                conn.Close()
            End Try
        End Function

        Public Function UserLogin(ByVal username As String, ByVal email As String, ByVal password As String) As UserAuth Implements IUser.UserLogin
            Dim user As New UserAuth()
            Using conn As New SqlConnection(strConn)
                Dim strSql As String = "DECLARE	@return_value int
                                EXEC @return_value = [dbo].[UserLogin]
		                        @username,
		                        @email,
		                        @password
                                SELECT	'Return Value' = @return_value"
                Dim cmd As New SqlCommand(strSql, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@password", password)
                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    user.UserID = CInt(dr("UserID"))
                    user.Username = dr("Username").ToString()
                    user.Email = dr("Email").ToString()
                    user.Nickname = dr("Nickname").ToString()
                    user.Password = dr("Password").ToString()
                End If

                dr.Close()
                cmd.Dispose()
                conn.Close()
            End Using

            Return user
        End Function

        Public Function CreateUser(user As UserAuth) Implements IUser.AddNewUser
            Dim status = ""
            Using conn As New SqlConnection(strConn)
                Dim strSql As String = "DECLARE	@return_value int
                EXEC	@return_value = [dbo].[NewUser]
		                @username,
		                @email,
		                @password,
		                @nickname
                SELECT	'Return Value' = @return_value"
                Dim cmd As New SqlCommand(strSql, conn)
                cmd.Parameters.AddWithValue("@username", user.Username)
                cmd.Parameters.AddWithValue("@email", user.Email)
                cmd.Parameters.AddWithValue("@password", user.Password)
                cmd.Parameters.AddWithValue("@nickname", user.Nickname)
                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    status = dr("Status")
                End If

                dr.Close()
                cmd.Dispose()
                conn.Close()
            End Using

            Return status
        End Function

        Public Function DeleteUser(ByVal username As String) Implements IUser.DeleteUser
            Dim status = ""
            Using conn As New SqlConnection(strConn)
                Dim strSql As String = "DECLARE	@return_value int
                EXEC	@return_value = [dbo].[DeleteUser]
		                @username
                SELECT	'Return Value' = @return_value"
                Dim cmd As New SqlCommand(strSql, conn)
                cmd.Parameters.AddWithValue("@username", username)
                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    status = dr("Status")
                End If

                dr.Close()
                cmd.Dispose()
                conn.Close()
            End Using

            Return status
        End Function


    End Class
End Namespace