Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1
    Dim ms As New MemoryStream
    Dim ms2 As New MemoryStream

    Public f1 As Form1
    Public format As ImageFormat

    Public Sub New()

        InitializeComponent()
        f1 = Me
        b = False
    End Sub

    Dim filter As String = "JPEG|*.jpg|PNG|*.png|GIF|*.gif"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Focus()
        Dim op As New OpenFileDialog
        op.Filter = filter
        If op.ShowDialog = DialogResult.OK Then
            Try
                PictureBox1.Image = Image.FromFile(op.FileName)
                Label1.Visible = True
            Catch exME As OutOfMemoryException
                MessageBox.Show(Me, "Parece que o arquivo não tem formato de imagem", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MsgErro(ex.ToString)
                Process.Start("http://supreme.tipotuff.com/p/contato.html")
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Focus()

        Dim sv As New SaveFileDialog
        sv.Filter = "TXT|*.txt"
        If sv.ShowDialog = DialogResult.OK Then
            Try

                Dim f2 As New Form2
                f2.ShowDialog(Me)
                ms = New MemoryStream
                PictureBox1.Image.Save(ms, format)
                File.WriteAllText(sv.FileName, Convert.ToBase64String(ms.GetBuffer()))

            Catch ex As Exception
                MsgErro(ex.ToString)
                Process.Start("http://supreme.tipotuff.com/p/contato.html")
            End Try
        End If

    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox1.Focus()
        Dim op As New OpenFileDialog
        op.Filter = "TXT|*.txt"
        If op.ShowDialog = DialogResult.OK Then
            Try
                ms2 = New MemoryStream(Convert.FromBase64String(File.ReadAllText(op.FileName)))
                PictureBox2.Image = Image.FromStream(ms2)
                Label2.Visible = True
            Catch exAR As ArgumentException
                MessageBox.Show(Me, "Arquivo provavelmente vazio", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch exFm As FormatException
                MessageBox.Show(Me, "As informações do arquivo não estão em base64 ou não são imagem.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MsgErro(ex.ToString)
                Process.Start("http://supreme.tipotuff.com/p/contato.html")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Focus()
        Dim sv As New SaveFileDialog
        sv.Filter = filter
        If sv.ShowDialog = DialogResult.OK Then
            Try
                PictureBox2.Image.Save(sv.FileName)
            Catch ex As Exception
                MsgErro(ex.ToString)
                Process.Start("http://supreme.tipotuff.com/p/contato.html")
            End Try
        End If
    End Sub

    Public Sub MsgErro(ByVal ex As String)
        MessageBox.Show("Contate: http://supreme.tipotuff.com/p/contato.html" & vbNewLine & vbNewLine & ex, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call lbs()
    End Sub
    Private Sub lbs()
        Label1.Parent = PictureBox1
        Label1.Location = New Size(3, 3)
        Label2.Parent = PictureBox2
        Label2.Location = New Size(3, 3)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.Focus()
        Timer1.Enabled = False
    End Sub

    Dim s As String
    Dim b As Boolean
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Try

            If b = True Then
                Return
            End If
            If e.KeyCode = Keys.NumPad0 Or e.KeyCode = Keys.D0 Then
                s = s & "0"
                If s.Length >= 50 Then
                    MsgBox("?")
                    Me.FormBorderStyle = FormBorderStyle.Sizable
                    b = True

                End If
            End If

            If e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Then
                s = s & "1"
            End If

        Catch : End Try

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            RichTextBox1.Text = RichTextBox1.Text & "01"
            If RichTextBox1.Text.Length >= 240 Then
                Timer2.Enabled = False
            End If
        Catch : End Try
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.Width >= 500 Then
            Timer2.Enabled = True
        End If

    End Sub
End Class
