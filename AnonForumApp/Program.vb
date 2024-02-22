Imports System
Imports DAL.AnonForum

Module Program
    Sub Main()
        Dim dal As New UserAuthDAL()
        Dim users = dal.GetAll()
        For Each user In users
            Console.WriteLine($"ID number {user.UserID} with username {user.Username.Trim()} and nickname {user.Nickname}")
        Next
        Dim username As String = "qwe12345"
        Dim email As String = "qwe12@gmail.com"
        Dim password As String = "123"
        Dim nickname As String = "qwe"
        Dim createuser = dal.CreateUser(username, email, password, nickname)
        Console.WriteLine(createuser)
        Dim userlogin = dal.UserLogin(username, " ", password)
        Console.WriteLine($"You logged in as {userlogin.Username}")
        Dim deleteuser = dal.DeleteUser(username)
        Console.WriteLine(deleteuser)
    End Sub
End Module
