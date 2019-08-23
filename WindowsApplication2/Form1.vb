Imports System.Data.SQLite

Public Class Form1
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            cb_food.Enabled = True
            cb_drink.Enabled = True
            nd_food.Enabled = True
            nd_drink.Enabled = True
        Else
            cb_food.Enabled = False
            cb_drink.Enabled = False
            nd_food.Enabled = False
            nd_drink.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim connMakeDB As SQLiteConnection = New SQLiteConnection("PayerDB.sqlite")
        Dim conn = New SQLiteConnection("Data Source=PlayerDB.sqlite;Version3")
        conn.Open()

        Dim sql As String = "CREATE TABLE IF NOT EXIST highScore (name VARCHAR(20), score INT)"
        Dim cmd1 As SQLiteCommand = New SQLiteCommand(sql, conn)

        Try
            cmd1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        '==========================================================================

        sql = "INSERT INTO highScore (name, score) VALUES ('Hello DB', 6000)"
        Dim cmd2 As SQLiteCommand = New SQLiteCommand(sql, conn)
        cmd1.ExecuteNonQuery()

        '==========================================================================

        sql = "SELECT * FROM highScore order by score desc"
        Dim cmd3 As SQLiteCommand = New SQLiteCommand(sql, conn)
        Dim reader As SQLiteDataReader = cmd3.ExecuteReader()

        ListBox1.Items.Clear()

        While (reader.Read())
            ListBox1.Items.Add("Player Name: " & reader("name") & "  Score: " & reader("score"))
        End While
        conn.Close()

    End Sub
End Class
