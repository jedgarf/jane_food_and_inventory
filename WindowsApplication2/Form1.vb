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

End Class
