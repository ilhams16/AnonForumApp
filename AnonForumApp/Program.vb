Imports System
Imports AFBO
Imports DAL.AnonForum

Module Program
    Sub Main()
        Dim dal As New UserAuthDAL()
        'list all user
        Dim users As List(Of UserAuth) = dal.GetAll()
        For Each user In users
            Console.WriteLine($"ID number {user.UserID} with username {user.Username.Trim()} and nickname {user.Nickname}")
        Next
        'create new user
        Dim newUser As New UserAuth()
        newUser.Username = "qwe12345"
        newUser.Email = "qwe12@gmail.com"
        newUser.Password = "123"
        newUser.Nickname = "qwe"
        Dim createuser = dal.CreateUser(newUser)
        Console.WriteLine(createuser)
        'login with new user
        Dim userlogin = dal.UserLogin(newUser.Username, " ", newUser.Password)
        Console.WriteLine($"You logged in as {userlogin.Username}")
        'list all user after new user added
        Dim listUsers As List(Of UserAuth) = dal.GetAll()
        For Each user In listUsers
            Console.WriteLine($"ID number {user.UserID} with username {user.Username.Trim()} and nickname {user.Nickname}")
        Next
        'delete new user
        Dim deleteuser = dal.DeleteUser(newUser.Username)
        Console.WriteLine(deleteuser)
    End Sub
End Module
