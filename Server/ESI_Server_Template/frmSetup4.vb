Public Class frmSetup4
    Private Sub frmSetup4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtUpper_TextChanged(sender As Object, e As EventArgs) Handles txtUpper.TextAlignChanged
        Try
            If txtUpper.Text = "" Then Exit Sub

            If Not validateInt(txtUpper.Text, 4, False, False) Then
                txtUpper.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtLower_TextChanged(sender As Object, e As EventArgs) Handles txtLower.TextAlignChanged
        Try
            If txtLower.Text = "" Then Exit Sub

            If Not validateInt(txtLower.Text, 4, False, False) Then
                txtLower.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandom_Click(sender As Object, e As EventArgs) Handles cmdRandom.Click
        Try
            For i As Integer = 1 To dgMain.RowCount
                For j As Integer = 2 To dgMain.ColumnCount
                    dgMain(j - 1, i - 1).Value = rand(CInt(txtUpper.Text), CInt(txtLower.Text))
                Next
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class