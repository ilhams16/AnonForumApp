Imports AFBO

Public Interface IUser
    Function AddNewUser(user As UserAuth)
    Function GetAllUser() As List(Of UserAuth)
    Function UserLogin(username As String, email As String, password As String) As UserAuth
    Function DeleteUser(username As String)
End Interface
