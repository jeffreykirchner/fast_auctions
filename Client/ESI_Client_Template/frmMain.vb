Public Class frmMain
    Public WithEvents AC As synchronousClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim commandLine As String = Command()

            If commandLine <> "" Then
                writeINI(sfile, "Settings", "ip", commandLine)
            End If

            'connect
            myIPAddress = getINI(sfile, "Settings", "ip")
            myPortNumber = getINI(sfile, "Settings", "port")

            AC = New synchronousClient

            AC.connect()

            AC.sendMessage("COMPUTER_NAME", My.Computer.Name)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub AC_connected() Handles AC.connected
        Try
            bwSocket.RunWorkerAsync()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub AC_ConnectionError() Handles AC.connectionError
        Try

            If bwSocket.IsBusy Then
                bwSocket.CancelAsync()
            Else
                showConnectionBox()
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub showConnectionBox()
        Try
            If AC.client.Connected Then
                AC.close()
            End If

            AC = New synchronousClient

            frmConnect.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub AC_messageReceived(ByVal e As String) Handles AC.messageReceived
        Try
            setTakeMessage(e)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    'receive socket messages
    Private Sub bwSocket_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSocket.DoWork
        Try
            Dim go As Boolean = True

            Do While go
                If bwSocket.CancellationPending Then go = False
                If go Then AC.Receive()
            Loop

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub bwSocket_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSocket.RunWorkerCompleted
        If Not clientClosing Then
            showConnectionBox()
        Else
            Close()
        End If
    End Sub

    Delegate Sub setTakeMessageCallback(text As String)

    Public Sub setTakeMessage(ByVal text As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If txtMain.InvokeRequired Then
            Dim d As New setTakeMessageCallback(AddressOf setTakeMessage)
            Me.Invoke(d, New Object() {text})
        Else
            takeMessage(text)
        End If
    End Sub

    Public testModeTargetBid As Double = -1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            If showInstructions Then
                With My.Forms.frmInstructions

                    If currentInstruction = 7 And Not My.Forms.frmInstructions.pagesDone(7) Then
                        For i As Integer = 2 To 4
                            My.Forms.frmInstructions.movedPoints(i) = True
                        Next

                        My.Forms.frmInstructions.pagesDone(7) = True
                    End If

                    If .cmdStart.Visible Then .cmdStart.PerformClick()

                    If .startPressed Then Exit Sub

                    If .gbQuiz.Visible Then .cmdSubmitQuiz.PerformClick()
                    If .cmdNext.Visible Then .cmdNext.PerformClick()
                End With

            ElseIf My.Forms.frmNames.Visible Then
                With frmNames
                    .txtName.Text = "Instruction Robot " & inumber
                    .txtIDNumber.Text = rand(100000, 1)
                    .cmdSubmit.PerformClick()

                    Timer1.Enabled = False
                End With
            Else
                With frmRealTime
                    If InStr(periodType(currentPeriod), "Slow") > 0 Then

                        If .pnlAreYouSure.Visible Then

                            Dim n As Integer = rand(100, 1)

                            If n >= 90 Then
                                .cmdNo.PerformClick()
                            Else
                                .cmdSubmit.PerformClick()
                            End If

                            Exit Sub
                        End If

                        If .cmdSubmitFirst.Visible Then

                            If .cmdSubmitFirst.Text = "Ready To Go On" Or .cmdSubmitFirst.Text = "Ready" Then
                                testModeTargetBid = -1
                                .cmdSubmitFirst.PerformClick()
                                Exit Sub
                            End If

                            If testModeTargetBid = -1 Or testModeTargetBid > valueRange Then
                                'testModeTargetBid = rand(Math.Min(values(currentPeriod) + 2, valueRange),
                                '                        Math.Max(values(currentPeriod) - 2, 0)) + (rand(99, 0) / 100)

                                testModeTargetBid = values(currentPeriod)
                            End If

                            If InStr(periodType(currentPeriod), "English") > 0 Then

                                If .cmdSubmitFirst.Visible = True And currentClockPrice >= testModeTargetBid Then
                                    .cmdSubmitFirst.PerformClick()
                                End If
                            ElseIf InStr(periodType(currentPeriod), "Dutch") Then

                                If .cmdSubmitFirst.Visible = True And currentClockPrice <= testModeTargetBid Then
                                    .cmdSubmitFirst.PerformClick()
                                End If
                            Else
                                If .txtBid.Text = "" And .txtBid.ReadOnly = False Then
                                    .txtBid.Text = testModeTargetBid
                                Else
                                    .cmdSubmitFirst.PerformClick()
                                End If

                            End If
                        End If
                    Else
                        If rand(5, 1) = 1 Then
                            Dim tempControlPoint As Integer = rand(4, 2)

                            .controlPointTarget = tempControlPoint

                            Dim tempMagnitude As Integer = 50

                            If tempControlPoint = 4 Then
                                .doMouseMove(New Point(rand(tempMagnitude, -tempMagnitude) + .bezeir4.X, rand(tempMagnitude, -tempMagnitude) + .bezeir4.Y))
                            ElseIf tempControlPoint = 3 Then
                                .doMouseMove(New Point(rand(tempMagnitude, -tempMagnitude) + .bezeir3.X, rand(tempMagnitude, -tempMagnitude) + .bezeir3.Y))
                            ElseIf tempControlPoint = 2 Then
                                .doMouseMove(New Point(rand(tempMagnitude, -tempMagnitude) + .bezeir2.X, rand(tempMagnitude, -tempMagnitude) + .bezeir2.Y))
                            End If

                            .controlPointTarget = -1
                        Else
                            .controlPointTarget = -1
                        End If


                        If .cmdSubmitFirst.Visible Then
                            .cmdSubmitFirst.PerformClick()
                        End If
                    End If
                End With
            End If

            Timer1.Interval = rand(100, 90)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'if ALT+K are pressed kill the client
        'if ALT+Q are pressed bring up connection box
        If e.Alt = True Then
            If CInt(e.KeyValue) = CInt(Keys.K) Then
                If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                closeClient()
            ElseIf CInt(e.KeyValue) = CInt(Keys.Q) Then
                frmConnect.Show()
            End If
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not clientClosing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class
