Imports System.Drawing.Drawing2D

Public Class frmReplay

    Public replaySummaryDf() As String

    Private Sub cmdLoadData_Click(sender As Object, e As EventArgs) Handles cmdLoadData.Click
        Try
            With frmServer
                Dim sinstr As String = ""

                OpenFileDialog1.FileName = ""
                OpenFileDialog1.Filter = "Data Files (*.csv)|*.csv"
                OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath & "\DataFiles"

                OpenFileDialog1.ShowDialog()

                If OpenFileDialog1.FileName = "" Then
                    Exit Sub
                End If

                sinstr = OpenFileDialog1.FileName

                'load data
                Dim d(2) As String
                d(0) = "Summary_Data_"
                d(1) = "Parameters_"

                Dim msgtokens2() As String = OpenFileDialog1.FileName.Split(d, StringSplitOptions.RemoveEmptyEntries)

                Dim tempFileName As String = ""

                tempFileName = msgtokens2(0) & "Summary_Data_" & msgtokens2(1)
                replaySummaryDf = My.Computer.FileSystem.ReadAllText(tempFileName).Split(vbCrLf)

                tempFileName = msgtokens2(0) & "Parameters_" & msgtokens2(1)
                FileCopy(tempFileName, sfile)

                loadParameters()

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i) Is Nothing Then playerlist(i) = New player

                    playerlist(i).inumber = i

                    playerlist(i).p_curve = New Pen(getMyColor(i), 3)
                    .setTriangleEndCap(playerlist(i).p_curve)

                    playerlist(i).p_Profit = New Pen(getMyColor(i), 5)
                    .setTriangleEndCap(playerlist(i).p_Profit)

                    playerlist(i).p2_dash = New Pen(getMyColor(i), 2)
                    .setTriangleEndCap(playerlist(i).p2_dash)
                    playerlist(i).p2_dash.DashStyle = DashStyle.Dash
                Next

                setupPlayers()

                .setUpLossArea()

                'load bids

                Dim tempC As Integer = 1
                For i As Integer = 1 To numberOfPeriods
                    For j As Integer = 1 To numberOfPlayers
                        Dim msgtokens() As String = replaySummaryDf(tempC).Split(",")
                        Dim nextToken As Integer = 3

                        If msgtokens.Length <= 1 Then Exit For

                        playerlist(j).bids(i) = New bid(msgtokens(nextToken), j, i, True)
                        playerlist(j).bids(i).period = i
                        nextToken += 1

                        playerlist(j).bids(i).won = msgtokens(nextToken)
                        nextToken += 1

                        playerlist(j).bids(i).value = msgtokens(nextToken)
                        nextToken += 1

                        finalPrice(i) = msgtokens(nextToken)
                        nextToken += 1

                        nextToken += 1

                        For k As Integer = 1 To 4
                            playerlist(j).bezeirPointsSubmit(k, i) = New PointF(msgtokens(nextToken), msgtokens(nextToken + 1))
                            nextToken += 2
                        Next 'point

                        For k As Integer = 1 To 4
                            playerlist(j).bezeirPointsResults(k, i) = New PointF(msgtokens(nextToken), msgtokens(nextToken + 1))
                            nextToken += 2
                        Next 'point

                        playerlist(j).resultBids(i) = msgtokens(nextToken)
                        nextToken += 1

                        If playerlist(j).bids(i).won Then
                            playerlist(j).bids(i).updatePricePt(playerlist(j).values(i))
                        End If

                        tempC += 1
                    Next 'player
                Next 'period

                currentPeriod = 1
                tbData.Maximum = numberOfPeriods
                cmdPlayData.Visible = False
                cmdPauseData.Visible = True
                Timer1.Enabled = True
                .Timer1.Enabled = True
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdPauseData_Click(sender As Object, e As EventArgs) Handles cmdPauseData.Click
        Try
            Timer1.Enabled = False
            cmdPauseData.Visible = False
            cmdPlayData.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPlayData_Click(sender As Object, e As EventArgs) Handles cmdPlayData.Click
        Try
            If tbData.Value <> tbData.Maximum Then
                Timer1.Enabled = True
                cmdPlayData.Visible = False
                cmdPauseData.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbData_Scroll(sender As Object, e As EventArgs) Handles tbData.Scroll
        Try
            updateScreen()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub updateScreen()
        Try
            With frmServer
                currentPeriod = tbData.Value

                .txtTreatment.Text = periodType(currentPeriod)
                .txtPeriod1.Text = currentPeriod
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            If tbData.Value + 1 <= tbData.Maximum Then tbData.Value += 1

            updateScreen()

            If tbData.Value = tbData.Maximum Then
                Timer1.Enabled = False
                cmdPauseData.Visible = False
                cmdPlayData.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmReplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmdPlayData.Location = cmdPauseData.Location
        Catch ex As Exception

        End Try
    End Sub

    Private Sub nudSpeed_ValueChanged(sender As Object, e As EventArgs) Handles nudSpeed.ValueChanged
        Try
            Select Case nudSpeed.Value
                Case 1
                    Timer1.Interval = 1000
                Case 2
                    Timer1.Interval = 500
                Case 3
                    Timer1.Interval = 250
                Case 4
                    Timer1.Interval = 125
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class