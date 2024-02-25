Imports [Interface]
Imports AFBO
Imports System.Data.SqlClient

Public Class PostDAL
    Private ReadOnly strConn As String
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        strConn = "Server=.\BSISqlExpress;Database=AnonForum;Trusted_Connection=True;"
        conn = New SqlConnection(strConn)
    End Sub

    Public Function GetAllPost() As List(Of Post)
        Dim Posts As New List(Of Post)
        Try
            Dim strSql = "select * from Posts p
                            join UserAuth ua
                            on p.UserID = ua.UserID"

            conn = New SqlConnection(strConn)
            cmd = New SqlCommand(strSql, conn)
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read
                    Dim post As New Post With {
                        .UserID = CInt(dr("UserID")),
                        .PostID = dr("PostID").ToString(),
                        .Title = dr("Title").ToString(),
                        .PostText = dr("PostText").ToString(),
                        .TimeStamp = dr("TimeStamp").ToString(),
                        .PostCategoryID = CInt(dr("PostCategoryID")),
                        .TotalLikes = CInt(dr("TotalLikes")),
                        .TotalDislikes = CInt(dr("TotalDislikes")),
                        .Username = dr("Username").ToString()
                    }
                    Posts.Add(post)
                End While
            End If
            dr.Close()

            Return Posts
        Catch ex As Exception
            Throw
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Function

    Public Function CreatePost(post As Post)
        Dim status = ""
        Using conn As New SqlConnection(strConn)
            Dim strSql As String = "DECLARE	@return_value int
                EXEC	@return_value = [dbo].[NewPost]
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
