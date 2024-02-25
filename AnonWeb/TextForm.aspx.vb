Public Class TextForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Label1.Text = "Hello " + txtUserName.Text + " your password is " + txtPassword.Text
    End Sub
End Class