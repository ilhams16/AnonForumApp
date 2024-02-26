﻿Imports AFBO

Public Interface IUser
    Function AddNewUser(user As UserAuth)
    Function GetAllUser() As List(Of UserAuth)
    Function UserLogin(username As String, email As String, password As String) As UserAuth
    Function EditNickname(username As String, Nickname As String)
    Function DeleteUser(username As String)
End Interface
