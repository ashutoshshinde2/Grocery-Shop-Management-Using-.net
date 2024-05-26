Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ash As Integer = 0
        If TextBox1.Text = "" Then
            ErrorProvider1.SetError(TextBox1, "Enter the UserName")

        Else
            ErrorProvider1.SetError(TextBox1, "")
            ash = ash + 1
        End If
        If TextBox2.Text = "" Then
            ErrorProvider2.SetError(TextBox2, "Enter the Password")
        Else
            ErrorProvider2.SetError(TextBox2, "")
            ash = ash + 1
        End If
        If ash = 2 Then
            Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
            MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
            Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.logindb where uname='" & TextBox1.Text & "' And pass='" & TextBox2.Text & "'"
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            Dim a As String
            a = REader.Read
            If a = "True" Then
                    Panel3.Show()
                    Timer1.Start()
                check()
            Else
                MsgBox("Enter valid uname or Pass", MsgBoxStyle.Critical)
            End If
            MyConn.Close()

        Catch ex As Exception
        End Try
        End If
    End Sub
    Private Sub check()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.logindb where uname='" & TextBox1.Text & "'"
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            While REader.Read
                Dim s = REader.GetString("type")
                If s = "admin" Then
                    Form2.Label26.Text = s
                Else

                    Form2.TabControl1.TabPages.Remove(Form2.TabPage3)
                    Form2.TabControl1.TabPages.Remove(Form2.TabPage4)
                    Form2.TabControl1.TabPages.Remove(Form2.TabPage8)
                    Form2.Label26.Text = s
                End If
                Exit While
            End While
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Show()
        Panel3.Hide()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Form2.Show()
        Me.Hide()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form2.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class
