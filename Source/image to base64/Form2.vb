Public Class Form2
    Dim f1 As Form1 = Form1.f1

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "JPG"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cb1 As String = ComboBox1.Text
            If cb1 = "JPG" Then
                f1.format = Imaging.ImageFormat.Jpeg
            ElseIf cb1 = "PNG" Then
                f1.format = Imaging.ImageFormat.Png
            ElseIf cb1 = "GIF" Then
                f1.format = Imaging.ImageFormat.Gif
            End If
        Catch ex As Exception
            f1.MsgErro(ex.ToString)
            Process.Start("http://supreme.tipotuff.com/p/contato.html")
        End Try
        Me.Close()
    End Sub
End Class