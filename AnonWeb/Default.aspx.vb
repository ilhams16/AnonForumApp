Public Class DefaultAnonPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = DateTime.Now.ToString("T")
    End Sub
    Protected Sub Button_Click(sender As Object, e As System.EventArgs)
        Label1.Text = "Tombol Ditekan"
    End Sub

End Class