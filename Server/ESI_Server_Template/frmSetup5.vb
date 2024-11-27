Public Class frmSetup5

    Dim tempC As Integer = 0

    Private Sub frmSetup5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandomValues_Click(sender As Object, e As EventArgs) Handles cmdRandomValues.Click
        Try
            For i As Integer = 1 To tempC
                dg1(1, i - 1).Value = rand(CInt(txtValueMax.Text), CInt(txtValueMin.Text))
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandomSignals_Click(sender As Object, e As EventArgs) Handles cmdRandomValues.Click
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

End Class