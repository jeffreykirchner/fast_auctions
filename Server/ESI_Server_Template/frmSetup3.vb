Public Class frmSetup3
    Private Sub frmSetup3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgMain.RowCount = numberOfPeriods

            For i As Integer = 2 To numberOfPlayers
                dgMain.Columns.Add(dgMain.Columns(1).Clone)
                dgMain.Columns(i).HeaderText = "Player " & i & " Value"
            Next

            Dim tempN As Integer = 0
            For i As Integer = 1 To numberOfPeriods
                Dim msgtokens() As String = getINI(sfile, "players", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                dgMain(0, i - 1).Value = i

                For j As Integer = 1 To numberOfPlayers
                    If msgtokens.Length >= j Then
                        dgMain(j, i - 1).Value = msgtokens(j - 1)
                    End If
                Next
            Next

            nudMin.Value = getINI(sfile, "gameSettings", "minValue")
            nudMax.Value = getINI(sfile, "gameSettings", "maxValue")

            If getINI(sfile, "gameSettings", "valueType") = "whole" Then
                rbWhole.Checked = True
            Else
                rbDecimal.Checked = True
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try
            For i As Integer = 1 To dgMain.RowCount
                Dim outstr As String = ""
                For j As Integer = 1 To dgMain.ColumnCount - 1
                    outstr &= dgMain(j, i - 1).Value & ";"
                Next

                writeINI(sfile, "players", CStr(i), outstr)
            Next

            writeINI(sfile, "gameSettings", "minValue", nudMin.Value)
            writeINI(sfile, "gameSettings", "maxValue", nudMax.Value)

            If rbWhole.Checked Then
                writeINI(sfile, "gameSettings", "valueType", "whole")
            Else
                writeINI(sfile, "gameSettings", "valueType", "decimal")
            End If

            Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandom_Click(sender As Object, e As EventArgs) Handles cmdRandom.Click
        Try
            Cursor = Cursors.WaitCursor

            For i As Integer = 1 To dgMain.RowCount
                For j As Integer = 1 To dgMain.ColumnCount - 1

                    If rbWhole.Checked Then
                        dgMain(j, i - 1).Value = rand(nudMax.Value, nudMin.Value)
                    Else
                        dgMain(j, i - 1).Value = Math.Round(rand(nudMax.Value - 1, nudMin.Value) + (rand(100, 0)) / 100, 2)
                    End If

                    If dgMain(j, i - 1).Value > nudMax.Value Then
                        dgMain(j, i - 1).Value = nudMax.Value
                    End If
                Next
            Next

            Cursor = Cursors.Default
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
End Class