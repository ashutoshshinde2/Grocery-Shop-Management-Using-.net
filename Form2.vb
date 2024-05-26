Imports MySql.Data.MySqlClient
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Show()
        Me.Hide()
        Timer1.Start()
        ComboBox2.Enabled = False
        lo_item()
        load_tab()
        lo_acc()
        hist()
    End Sub
    Private Sub his()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Dim sad As New MySqlDataAdapter
        Dim dbs As New DataTable
        Dim ds As New BindingSource
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.history1 where BillInvoice='" & Label3.Text & "'"
            COMMAND = New MySqlCommand(q1, MyConn)
            sad.SelectCommand = COMMAND
            sad.Fill(dbs)
            ds.DataSource = dbs
            DataGridView4.DataSource = ds
            sad.Update(dbs)
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub hist()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Dim sad As New MySqlDataAdapter
        Dim dbs As New DataTable
        Dim ds As New BindingSource
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.history1 "
            COMMAND = New MySqlCommand(q1, MyConn)
            sad.SelectCommand = COMMAND
            sad.Fill(dbs)
            ds.DataSource = dbs
            DataGridView5.DataSource = ds
            sad.Update(dbs)
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub lo_item()
        ComboBox4.Items.Clear()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select itemname from grodb.item "
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            Dim a As String
            a = REader.Read
            While REader.Read
                Dim s = REader.GetString("itemname")
                ComboBox4.Items.Add(s)
            End While
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub lo_acc()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Dim sad As New MySqlDataAdapter
        Dim dbs As New DataTable
        Dim ds As New BindingSource
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.logindb where id>0"
            COMMAND = New MySqlCommand(q1, MyConn)
            sad.SelectCommand = COMMAND
            sad.Fill(dbs)
            ds.DataSource = dbs
            DataGridView3.DataSource = ds
            sad.Update(dbs)
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub load_tab()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Dim sad As New MySqlDataAdapter
        Dim dbs As New DataTable
        Dim ds As New BindingSource
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.item where itemid >100"
            COMMAND = New MySqlCommand(q1, MyConn)
            sad.SelectCommand = COMMAND
            sad.Fill(dbs)
            ds.DataSource = dbs
            DataGridView2.DataSource = ds
            sad.Update(dbs)
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select name from grodb.logindb where uname='" & Form1.TextBox1.Text & "'"
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            While REader.Read
                Dim s = REader.GetString("name")
                Label3.Text = s
                Exit While
            End While
            MyConn.Close()
        Catch ex As Exception
        End Try
        his()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Form1.Panel1.Show()
        Form1.Panel3.Hide()
        Me.Hide()
        Form1.TextBox1.Text = ""
        Form1.TextBox2.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        TextBox6.Enabled = False
        TextBox5.Enabled = False
        Button2.Enabled = False
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select itemname from grodb.item "
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            Dim a As String
            a = REader.Read
            While REader.Read
                Dim s = REader.GetString("itemname")
                ComboBox2.Items.Add(s)
            End While
            ComboBox3.Enabled = False
            MyConn.Close()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox5.Text = "0"
        ComboBox3.Enabled = True
        ComboBox3.Items.Clear()
        Dim ash As String = ComboBox2.Text
        Dim MyConn1 As New MySqlConnection
        Dim COMMAND1 As MySqlCommand
        Dim REader1 As MySqlDataReader
        MyConn1.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn1.Open()
            Dim q2 As String

            q2 = "Select * from grodb.item where itemname='" & ash & "'"
            COMMAND1 = New MySqlCommand(q2, MyConn1)
            REader1 = COMMAND1.ExecuteReader
            Dim a1 As String
            a1 = REader1.Read

            Dim s = REader1.GetString("unit")
            If (s = "kg") Then
                Label11.Text = "In KG "
                ComboBox3.Items.Add(1)
                ComboBox3.Items.Add(2)
                ComboBox3.Items.Add(3)
                ComboBox3.Items.Add(5)
                ComboBox3.Items.Add(10)
            Else
                Label11.Text = "In Pic "
                ComboBox3.Items.Add(1)
                ComboBox3.Items.Add(2)
                ComboBox3.Items.Add(3)
                ComboBox3.Items.Add(4)
                ComboBox3.Items.Add(5)
            End If

            MyConn1.Close()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Button2.Enabled = True
        Dim ash As String = ComboBox2.Text
        Dim MyConn1 As New MySqlConnection
        Dim COMMAND1 As MySqlCommand
        Dim REader1 As MySqlDataReader
        MyConn1.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn1.Open()
            Dim q2 As String

            q2 = "Select * from grodb.item where itemname='" & ash & "'"
            COMMAND1 = New MySqlCommand(q2, MyConn1)
            REader1 = COMMAND1.ExecuteReader
            Dim a1 As String
            a1 = REader1.Read
            Dim pr As Integer = REader1.GetInt64("Prise")
            TextBox5.Text = pr * Val(ComboBox3.Text)
            TextBox6.Text = pr
            MyConn1.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label24.Text = Val(Label24.Text) + Val(TextBox5.Text)
        DataGridView1.Rows.Add(Label13.Text, ComboBox2.Text, ComboBox3.Text, TextBox6.Text, TextBox5.Text)
        Label13.Text = Label13.Text + 1
        Button2.Enabled = False
        TextBox6.Text = ""
        TextBox5.Text = ""
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label13.Text = 1
        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()
        ComboBox2.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.RemoveAt(Val(TextBox7.Text) - 1)
    End Sub
    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select * from grodb.item "
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            Dim a As String
            a = REader.Read
            While REader.Read
                Dim s = REader.GetString("itemname")
                ComboBox4.Items.Add(s)
            End While
            ComboBox3.Enabled = False
            MyConn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ash As String = ComboBox4.Text
        Dim MyConn1 As New MySqlConnection
        Dim COMMAND1 As MySqlCommand
        Dim REader1 As MySqlDataReader
        MyConn1.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn1.Open()
            Dim q2 As String

            q2 = "delete from grodb.item where itemname='" & ash & "'"
            COMMAND1 = New MySqlCommand(q2, MyConn1)
            REader1 = COMMAND1.ExecuteReader
            Dim a1 As String
            a1 = REader1.Read

        Catch ex As Exception
        End Try
        ComboBox4.Items.Clear()
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "Select itemname from grodb.item "
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            ComboBox4.Items.Clear()
            Dim a As String
            a = REader.Read
            While REader.Read
                Dim s = REader.GetString("itemname")
                ComboBox4.Items.Add(s)
            End While
            MyConn.Close()
        Catch ex As Exception
        End Try

        load_tab()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim y As Integer = 0

        If IsNumeric(TextBox8.Text) Then
            ErrorProvider1.SetError(TextBox8, "")
            y = y + 1
        Else
            ErrorProvider1.SetError(TextBox8, "Enter number")
        End If
        If TextBox9.Text = "" Then
            ErrorProvider2.SetError(TextBox9, "Enter Item Name ")
        Else
            y = y + 1
            ErrorProvider1.SetError(TextBox9, "")
        End If
        If IsNumeric(TextBox10.Text) Then
            y = y + 1
            ErrorProvider1.SetError(TextBox10, "")
        Else
            ErrorProvider1.SetError(TextBox10, "Enter MRP in Number")

        End If
        If y = 3 Then
            Dim MyConn As New MySqlConnection
            Dim COMMAND As MySqlCommand
            Dim REader As MySqlDataReader
            MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
            Try
                MyConn.Open()
                Dim q1 As String
                q1 = "insert into grodb.item values(" & TextBox8.Text & ",'" & TextBox9.Text & "'," & TextBox10.Text & ",'" & Label22.Text & "')"
                COMMAND = New MySqlCommand(q1, MyConn)
                REader = COMMAND.ExecuteReader
                MsgBox("Element added Sucessfully")
                MyConn.Close()
            Catch ex As MySqlException
                MsgBox("Element id is present")
            End Try
            lo_item()
            load_tab()
        End If

    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label22.Text = RadioButton1.Text
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label22.Text = RadioButton2.Text
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Process.Start("https://www.google.com/maps/place/Shree+Ganesh+Kirana/@19.5420983,75.3847673,16.51z/data=!4m5!3m4!1s0x0:0xf760295d3b8d2710!8m2!3d19.5432448!4d75.3797346")
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim REader As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;user id=root;password=Ashu@13;database=grodb"
        Try
            MyConn.Open()
            Dim q1 As String
            q1 = "insert into grodb.history1 values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & Label24.Text & "','" & Label3.Text & "','" & Label26.Text & "','" & Label1.Text & "')"
            COMMAND = New MySqlCommand(q1, MyConn)
            REader = COMMAND.ExecuteReader
            MsgBox("Element Added")
            MyConn.Close()
        Catch ex As MySqlException
            MsgBox("Element Not added")
        End Try
        his()
        hist()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToString()
    End Sub
End Class