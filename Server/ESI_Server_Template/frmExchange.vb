Public Class frmExchange
    Private Sub frmExchange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgMain.RowCount = numberOfPlayers

            For i As Integer = 1 To dgMain.RowCount
                Dim tempS As String = getINI(sfile, "exchangeRate", CStr(i))

                dgMain(0, i - 1).Value = i

                If tempS.Length >= 1 Then
                    dgMain(1, i - 1).Value = tempS
                End If
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyDown_Click(sender As Object, e As EventArgs) Handles cmdCopyDown.Click
        Try
            For i As Integer = dgMain.CurrentCell.RowIndex + 1 To dgMain.RowCount
                dgMain(1, i - 1).Value = dgMain(1, dgMain.CurrentCell.RowIndex).Value
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try

            For i As Integer = 1 To dgMain.RowCount
                writeINI(sfile, "exchangeRate", CStr(i), dgMain(1, i - 1).Value)
            Next

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class