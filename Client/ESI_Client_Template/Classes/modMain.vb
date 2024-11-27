


Module modMain
    Public frmClient As New frmMain
    Public sfile As String
    Public myIPAddress As String
    Public myPortNumber As Integer
    Public inumber As Integer
    Public clientClosing As Boolean = False

    Public messageCounter As Integer = 0
    Public playerMessageCounter(100) As Integer

    Public numberOfPlayers As Integer
    Public numberOfPeriods As Integer
    Public portNumber As Integer
    Public instructionX As Integer
    Public instructionY As Integer
    Public windowX As Integer
    Public windowY As Integer
    Public showInstructions As Boolean
    Public currentInstruction As Integer
    Public testMode As Boolean
    Public exchangeRate As Integer

    Public currentPeriod As Integer

    Public valueRange As Integer
    Public historyLength As Integer

    Public minValue As Integer
    Public maxValue As Integer
    Public valueType As String
    Public fastSpeed As Integer

    Public fastClockSpeed As Integer
    Public fastClockStep As Double

    Public slowClockSpeed As Integer
    Public slowClockStep As Double

    Public values(1000) As Double

    Public periodType(1000) As String
    Public periodMinBid(1000) As Double         'lowest bid allowed
    Public bids(1000) As bid
    Public finalPrice(1000) As Double

    Public currentClockPrice As Double
    Public currentClockBid As Double

    Public Sub main()
        sfile = Application.StartupPath & "\client.ini"

        AppEventLog_Init()
        appEventLog_Write("Begin")

        Application.EnableVisualStyles()
        Application.Run(frmClient)

        appEventLog_Write("End")
        AppEventLog_Close()
    End Sub

    Public Sub takeMessage(str As String)
        Try

            Dim tempa() As String = {"<SEP>"}
            Dim msgtokens() As String = str.Split(tempa, StringSplitOptions.None)

            Dim id As String = msgtokens(0)
            Dim message As String = msgtokens(1)

            Select Case id
                Case "SHOW_NAME"
                    takeShowName(message)
                Case "RESET"
                    takeReset(message)
                Case "END_EARLY"
                    takeEndEarly(msgtokens(1))
                Case "FINISHED_INSTRUCTIONS"
                    takeFinishedInstructions(message)
                Case "INVALID_CONNECTION"
                    takeInvalidConnection(message)
                Case "BEGIN"
                    takeBegin(message)
                Case "01"
                    takeStartNextPeriod(message)
                Case "02"
                    takePeriodResultsSlow(message)
                Case "03"
                    takePeriodResultsFast(message)
                Case "04"
                    takeClockPriceUpdate(message)
                Case "05"
                    takeStartClock(message)
                Case "07"

                Case "08"

                Case "09"

                Case "10"

            End Select

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeInvalidConnection(str As String)
        Try
            With frmClient
                .AC_ConnectionError()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeBegin(str As String)
        Try
            With frmClient
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                numberOfPlayers = msgtokens(nextToken)
                nextToken += 1

                numberOfPeriods = msgtokens(nextToken)
                nextToken += 1

                portNumber = msgtokens(nextToken)
                nextToken += 1

                instructionX = msgtokens(nextToken)
                nextToken += 1

                instructionY = msgtokens(nextToken)
                nextToken += 1

                windowX = msgtokens(nextToken)
                nextToken += 1

                windowY = msgtokens(nextToken)
                nextToken += 1

                showInstructions = msgtokens(nextToken)
                nextToken += 1

                inumber = msgtokens(nextToken)
                nextToken += 1

                testMode = msgtokens(nextToken)
                nextToken += 1

                exchangeRate = msgtokens(nextToken)
                nextToken += 1

                valueRange = msgtokens(nextToken)
                nextToken += 1

                minValue = msgtokens(nextToken)
                nextToken += 1

                maxValue = msgtokens(nextToken)
                nextToken += 1

                valueType = msgtokens(nextToken)
                nextToken += 1

                historyLength = msgtokens(nextToken)
                nextToken += 1

                fastSpeed = msgtokens(nextToken)
                nextToken += 1

                fastClockSpeed = msgtokens(nextToken)
                nextToken += 1

                fastClockStep = msgtokens(nextToken)
                nextToken += 1

                slowClockSpeed = msgtokens(nextToken)
                nextToken += 1

                slowClockStep = msgtokens(nextToken)
                nextToken += 1

                For i As Integer = 1 To numberOfPeriods
                    values(i) = msgtokens(nextToken)
                    nextToken += 1

                    periodType(i) = msgtokens(nextToken)
                    nextToken += 1

                    periodMinBid(i) = msgtokens(nextToken)
                    nextToken += 1
                Next

                For i As Integer = 1 To numberOfPlayers
                    playerMessageCounter(i) = 0
                Next

                .Text = "Client " & inumber

                currentPeriod = 1

                frmRealTime.Show()
                frmClient.Hide()

                If showInstructions Then
                    frmInstructions.Show()

                    My.Forms.frmInstructions.Location = New Point(instructionX, instructionY)
                    My.Forms.frmRealTime.Location = New Point(windowX, windowY)

                    My.Forms.frmInstructions.numberOfPages = 6
                    My.Forms.frmInstructions.startPage = 1
                    currentInstruction = 1
                    My.Forms.frmInstructions.nextInstruction()

                    My.Forms.frmInstructions.pagesDone(1) = True

                    For i As Integer = 2 To 6
                        My.Forms.frmInstructions.pagesDone(i) = False
                    Next
                End If

                If testMode Then
                    .Timer1.Enabled = True
                    frmTestMode.Show()
                End If

                With frmRealTime
                    If showInstructions Then
                        .setupScreen()
                    Else
                        .setupScreenTest()
                    End If

                    .setupScreen2()
                    .checkChangeOfRegime()
                    .Timer1.Enabled = True
                    .txtEarnings.Text = FormatCurrency(0)
                    .txtPeriod.Text = currentPeriod
                    .txtValue.Text = Format(values(currentPeriod), "0.00")
                    .Text = "Client " & inumber
                    .Timer2.Interval = fastSpeed
                End With

                appEventLog_Write("Client ID: " & inumber)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeReset(str As String)
        Try
            closeClient()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEndEarly(ByVal sinstr As String)
        Try
            'end experiment early
            Dim msgtokens() As String
            msgtokens = sinstr.Split(";")

            numberOfPeriods = msgtokens(0)
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub closeClient()
        Try
            With frmClient
                .Timer1.Enabled = False
                clientClosing = True

                .bwSocket.CancelAsync()
                .AC.close()

                '.Close()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            frmClient.Close()
        End Try
    End Sub

    Public Sub takeStartNextPeriod(str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            currentPeriod = msgtokens(nextToken)
            nextToken += 1

            showInstructions = msgtokens(nextToken)
            nextToken += 1

            Dim periodStartTime As DateTime = DateTime.Parse(msgtokens(nextToken))
            nextToken += 1

            currentClockPrice = -1

            With frmRealTime
                .txtBid.Text = ""
                .txtBid.ReadOnly = False
                .txtValue.Text = Format(values(currentPeriod), "0.00")
                .cmdSubmitFirst.Visible = True
                .cmdSubmitFirst.Text = "Submit"
                .cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                .setupScreen2()
                .checkChangeOfRegime()

                .txtPeriod.Text = currentPeriod

                .disableScreen = False

                If InStr(periodType(currentPeriod), "Fast") > 0 Then

                    'start timer for fast first second price auctions
                    If (InStr(periodType(currentPeriod), "First") Or InStr(periodType(currentPeriod), "Second")) And
                        periodType(currentPeriod - 1) = periodType(currentPeriod) Then

                        .Timer2.Enabled = True
                        .cmdSubmitFirst.Visible = False
                    End If
                End If

                'clear history if different price
                If (InStr(periodType(currentPeriod), "First") And Not InStr(periodType(currentPeriod - 1), "First")) Or
                   (InStr(periodType(currentPeriod), "Second") And Not InStr(periodType(currentPeriod - 1), "Second")) Or
                   (InStr(periodType(currentPeriod), "English") And Not InStr(periodType(currentPeriod - 1), "English")) Or
                   (InStr(periodType(currentPeriod), "Dutch") And Not InStr(periodType(currentPeriod - 1), "Dutch")) Then

                    For i As Integer = 1 To currentPeriod - 1
                        bids(i) = Nothing
                    Next

                End If

                If showInstructions Then

                    Dim tempFound As Boolean = False

                    For i As Integer = 1 To currentPeriod - 1
                        If periodType(i) = periodType(currentPeriod) Then tempFound = True
                    Next

                    If InStr(periodType(currentPeriod), "Fast") > 0 Then
                        If tempFound Then
                            My.Forms.frmInstructions.numberOfPages = 9
                            My.Forms.frmInstructions.startPage = 9
                            currentInstruction = 9
                        Else
                            My.Forms.frmInstructions.numberOfPages = 8
                            My.Forms.frmInstructions.startPage = 7
                            currentInstruction = 7
                        End If
                    Else
                        My.Forms.frmInstructions.numberOfPages = 6
                        My.Forms.frmInstructions.startPage = 4
                        currentInstruction = 4
                    End If

                    frmInstructions.Show()
                    My.Forms.frmInstructions.nextInstruction()

                    .setupScreen()
                    .checkChangeOfRegime()

                    My.Forms.frmInstructions.Location = New Point(instructionX, instructionY)
                    My.Forms.frmRealTime.Location = New Point(windowX, windowY)
                Else
                    startClientSideEnglishDutch(periodStartTime)
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeShowName(str As String)
        Try
            With frmNames
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                .Show()

                .lblEarnings.Text = "Your Earnings Are: " & FormatCurrency(msgtokens(nextToken), -1, TriState.UseDefault, TriState.False)
                nextToken += 1

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeFinishedInstructions(str As String)
        Try
            With frmRealTime
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                currentPeriod = msgtokens(nextToken)
                nextToken += 1

                Dim periodStartTime As DateTime = DateTime.Parse(msgtokens(nextToken))
                nextToken += 1

                'For i As Integer = currentPeriod To currentPeriod + 5
                '    bids(i) = Nothing
                'Next

                frmInstructions.Close()
                showInstructions = False

                .setupScreen2()
                .checkChangeOfRegime()

                startClientSideEnglishDutch(periodStartTime)

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takePeriodResults(str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            With frmRealTime

                bids(currentPeriod) = New bid
                bids(currentPeriod).fromString(msgtokens, nextToken)

                finalPrice(currentPeriod) = msgtokens(nextToken)
                nextToken += 1

                .txtEarnings.Text = FormatCurrency(CDbl(msgtokens(nextToken)),,, False)
                nextToken += 1

                If bids(currentPeriod).myBid <> -1 Then .txtBid.Text = Format(bids(currentPeriod).myBid, "0.00")


                'bid point
                bids(currentPeriod).bidPt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, values(currentPeriod)),
                                                       .convertToY(bids(currentPeriod).myBid, 0, valueRange, .yStop - .yStart, 0, .yStart))

                'price point
                bids(currentPeriod).pricePt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, values(currentPeriod)),
                                                         .convertToY(finalPrice(currentPeriod), 0, valueRange, .yStop - .yStart, 0, .yStart))

                'value point
                bids(currentPeriod).valuePt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, values(currentPeriod)),
                                                         .convertToY(values(currentPeriod), 0, valueRange, .yStop - .yStart, 0, .yStart))

                bids(currentPeriod).period = currentPeriod
                currentClockPrice = finalPrice(currentPeriod)

                If InStr(periodType(currentPeriod), "English") > 0 Then
                    If bids(currentPeriod).won Then currentClockBid = finalPrice(currentPeriod)
                Else
                    currentClockBid = finalPrice(currentPeriod)
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takePeriodResultsFast(str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            takePeriodResults(str)

            With frmRealTime

                If .bwTimer2.IsBusy Then
                    .doAfterComplete = "periodResultsFast"
                    .doAfterCompleteMsgtokens = str
                    .exitTimer2 = True
                Else
                    takePeriodResultsFast2(str)
                End If


            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takePeriodResultsFast2(str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            takePeriodResults(str)

            With frmRealTime

                .cmdSubmitFirst.Text = "Ready To Go On"
                .lblMayLoseMoney.Visible = False

                'wait for momement before returning reponse to server
                Threading.Thread.Sleep(rand(50, 20))
                .cmdSubmitAction()

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takePeriodResultsSlow(str As String)
        Try
            With frmRealTime
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                If .bwTimer2.IsBusy Then

                    .doAfterComplete = "periodResultsSlow"
                    .doAfterCompleteMsgtokens = str
                    .exitTimer2 = True
                Else
                    takePeriodResultsSlow2(str)
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takePeriodResultsSlow2(str As String)
        Try
            With frmRealTime
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                takePeriodResults(str)

                With frmRealTime
                    .cmdSubmitFirst.Visible = True
                    .lblMayLoseMoney.Visible = False
                    .pnlAreYouSure.Visible = False

                    .AcceptButton = .cmdSubmitFirst

                    .valuePoint = New PointF(-1, -1)
                    .cmdSubmitFirst.Text = "Ready To Go On"
                    .cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)

                    .refreshLblMayLoseMoney()
                End With

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeClockPriceUpdate(str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            With frmRealTime

                currentClockPrice = msgtokens(nextToken)
                nextToken += 1

                currentClockBid = msgtokens(nextToken)
                nextToken += 1

                ' If InStr(periodType(currentPeriod), "Slow") > 0 Then

                If InStr(periodType(currentPeriod), "English") Then

                    If currentClockBid > currentClockPrice Then
                        currentClockBid = currentClockPrice
                    End If
                ElseIf InStr(periodType(currentPeriod), "Dutch") Then

                    If currentClockPrice > currentClockBid Then
                        currentClockBid = currentClockPrice
                    End If
                End If
                ' End If

                If InStr(periodType(currentPeriod), "Slow") > 0 Then
                    .txtBid.Text = Format(currentClockBid, "0.00")

                    .refreshScreenSlow()
                Else
                    If .txtBid.Text <> "" And Not .disableScreen Then
                        If InStr(periodType(currentPeriod), "English") Then
                            If currentClockPrice >= CDbl(.txtBid.Text) Then
                                'Threading.Thread.Sleep(25)
                                .cmdSubmitAction()
                                .disableScreen = True
                            End If
                        ElseIf InStr(periodType(currentPeriod), "Dutch") Then
                            If currentClockPrice <= CDbl(.txtBid.Text) Then
                                ' Threading.Thread.Sleep(25)
                                .cmdSubmitAction()
                                .disableScreen = True
                            End If
                        End If
                    End If

                    .refreshScreenFast()
                End If


            End With

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeStartClock(str As String)
        Try
            With frmRealTime
                .setupScreen2()

                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim periodStartTime As DateTime = DateTime.Parse(msgtokens(nextToken))
                nextToken += 1

                startClientSideEnglishDutch(periodStartTime)
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub startClientSideEnglishDutch(periodStartTime As DateTime)
        Try
            With frmRealTime
                If .cmdSubmitFirst.Visible And .cmdSubmitFirst.Text = "Ready" Then Exit Sub
                'client side clock
                If InStr(periodType(currentPeriod), "English") > 0 Or
                   InStr(periodType(currentPeriod), "Dutch") > 0 Then

                    If InStr(periodType(currentPeriod), "English") > 0 Then
                        currentClockPrice = 0
                    ElseIf InStr(periodType(currentPeriod), "Dutch") > 0 Then
                        currentClockPrice = valueRange
                    End If

                    .exitTimer2 = False


                    .periodStartTime = Now           'use now vs server time in case system clocks are off.
                    .runCount = 0

                    If Not .bwTimer2.IsBusy Then .bwTimer2.RunWorkerAsync()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub
End Module
