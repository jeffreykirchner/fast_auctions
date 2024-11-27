Public Class frmSetup2
    Private Sub frmSetup2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgMain.RowCount = numberOfPeriods

            For i As Integer = 1 To dgMain.RowCount
                Dim msgtokens() As String = getINI(sfile, "periods", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                dgMain(0, i - 1).Value = i

                For j As Integer = 2 To dgMain.ColumnCount
                    If msgtokens.Length > nextToken Then
                        dgMain(j - 1, i - 1).Value = msgtokens(nextToken)
                        nextToken += 1
                    End If

                Next

            Next

            nudMin.Value = getINI(sfile, "gameSettings", "minValue2")
            nudMax.Value = getINI(sfile, "gameSettings", "maxValue2")

            If getINI(sfile, "gameSettings", "valueType2") = "decimal" Then
                cbDecimals.Checked = True
            Else
                cbDecimals.Checked = False
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try

            For i As Integer = 1 To dgMain.RowCount
                Dim str As String = ""

                For j As Integer = 2 To dgMain.ColumnCount
                    str += dgMain(j - 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "periods", CStr(i), str)
            Next

            writeINI(sfile, "gameSettings", "minValue2", nudMin.Value)
            writeINI(sfile, "gameSettings", "maxValue2", nudMax.Value)

            If cbDecimals.Checked Then
                writeINI(sfile, "gameSettings", "valueType2", "decimal")
            Else
                writeINI(sfile, "gameSettings", "valueType2", "whole")
            End If

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyDown_Click(sender As Object, e As EventArgs) Handles cmdCopyDown.Click
        Try
            If dgMain.CurrentCell.ColumnIndex = 0 Then Return

            Cursor = Cursors.WaitCursor

            For i As Integer = dgMain.CurrentCell.RowIndex + 1 To dgMain.RowCount
                dgMain(dgMain.CurrentCell.ColumnIndex, i - 1).Value = dgMain(dgMain.CurrentCell.ColumnIndex, dgMain.CurrentCell.RowIndex).Value
            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandomizeBid_Click(sender As Object, e As EventArgs) Handles cmdRandomizeBid.Click
        Try

            Cursor = Cursors.WaitCursor

            For i As Integer = 1 To dgMain.RowCount

                If Not cbDecimals.Checked Then
                    dgMain(2, i - 1).Value = rand(nudMax.Value, nudMin.Value)
                Else
                    dgMain(2, i - 1).Value = Math.Round(rand(nudMax.Value - 1, nudMin.Value) + (rand(100, 0)) / 100, 2)
                End If

                If dgMain(2, i - 1).Value > nudMax.Value Then
                    dgMain(2, i - 1).Value = nudMax.Value
                End If
            Next

            Cursor = Cursors.Default

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class