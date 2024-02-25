Imports System
Imports AFBO
Imports DAL
Imports DAL.AnonForum

Module Program
    Sub Main()
        'Dim dal As New UserAuthDAL()
        ''list all user
        'Dim users As List(Of UserAuth) = dal.GetAll()
        'For Each user In users
        '    Console.WriteLine($"ID number {user.UserID} with username {user.Username.Trim()} and nickname {user.Nickname}")
        'Next
        ''create new user
        'Dim newUser As New UserAuth()
        'newUser.Username = "qwe12345"
        'newUser.Email = "qwe12@gmail.com"
        'newUser.Password = "123"
        'newUser.Nickname = "qwe"
        'Dim createuser = dal.CreateUser(newUser)
        'Console.WriteLine(createuser)
        ''login with new user
        'Dim userlogin = dal.UserLogin(newUser.Username, " ", newUser.Password)
        'Console.WriteLine($"You logged in as {userlogin.Username}")
        ''list all user after new user added
        'Dim listUsers As List(Of UserAuth) = dal.GetAll()
        'For Each user In listUsers
        '    Console.WriteLine($"ID number {user.UserID} with username {user.Username.Trim()} and nickname {user.Nickname}")
        'Next
        ''delete new user
        'Dim deleteuser = dal.DeleteUser(newUser.Username)
        'Console.WriteLine(deleteuser)

        Dim dal As New PostDAL()
        'list all posts
        Dim posts As List(Of Post) = dal.GetAllPost()
        For Each post In posts
            Console.WriteLine($"Post {post.PostID} posted by {post.Username.Trim()} with title '{post.Title.ToUpper}' the content is")
            Console.WriteLine($"{post.PostText}")
            Console.WriteLine($"Posted on {post.TimeStamp} with total likes {post.TotalLikes} and total dislikes {post.TotalDislikes}")
            Console.WriteLine("------------------------------------------------------")
        Next
        'new post
        Dim newPost As New Post()
        newPost.UserID = 1
        newPost.Title = "asdsadsa"
        newPost.PostText = "asdasdcsacxvzvasfsakjkfsajkfas"
        newPost.PostCategoryID = 1
        Dim createpost = dal.CreatePost(newPost)
        Console.WriteLine("########")
        Console.WriteLine(createpost)
        Console.WriteLine("########")
        'new list all posts
        Dim newPosts As List(Of Post) = dal.GetAllPost()
        For Each post In newPosts
            Console.WriteLine($"Post {post.PostID} posted by {post.Username.Trim()} with title '{post.Title.ToUpper}' the content is")
            Console.WriteLine($"{post.PostText}")
            Console.WriteLine($"Posted on {post.TimeStamp} with total likes {post.TotalLikes} and total dislikes {post.TotalDislikes}")
            Console.WriteLine("------------------------------------------------------")
        Next
        'delete new user
        Dim deletepost = dal.DeletePost(newPost.Title, newPost.UserID)
        Console.WriteLine("#########")
        Console.WriteLine(deletepost)
        Console.WriteLine("#########")

    End Sub

End Module
