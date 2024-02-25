Imports AFBO

Public Interface IPost
    Function AddNewPost(post As Post)
    Function GetAllPost() As List(Of Post)
    Function DeletePost(title As String, userID As Integer)
End Interface
