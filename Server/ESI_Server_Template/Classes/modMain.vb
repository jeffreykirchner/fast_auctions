Imports System.IO

Module modMain
    Public frmServer As New frmMain
    Public sfile As String

    Public clientCount As Integer = 0        'number of connected clients

    Public tempTime As String                'time stamp at start of experiment

    Public playerlist(1000) As player

    Public numberOfPlayers As Integer
    Public numberOfPeriods As Integer
    Public portNumber As Integer
    Public instructionX As Integer
    Public instructionY As Integer
    Public windowX As Integer
    Public windowY As Integer
    Public showInstructions As Boolean
    Public testMode As Boolean
    Public filename As String                        'location of data file

    Public currentPeriod As Integer

    Public periodComplete(1000) As Boolean

    'data files
    Public summaryDf As StreamWriter             'second price data file

    Public checkin As Integer = 0

    Public minValue As Integer
    Public maxValue As Integer
    Public valueType As String
    Public valueRange As Integer
    Public historyLength As Integer

    Public fastSpeed As Integer
    Public fastClockSpeed As Integer
    Public fastClockStep As Double
    Public slowClockSpeed As Integer
    Public slowClockStep As Double

    Public periodType(1000) As String           'type of treatment to be run
    Public periodMinBid(1000) As Double         'lowest bid allowed

    Public finalPrice(1000) As Double
    Public currentClockPrice As Double
    Public clockStatus As String

    Public Sub main()
        Try
            sfile = Application.StartupPath & "\server.ini"

            AppEventLog_Init()
            appEventLog_Write("Load")

            loadParameters()

            Application.EnableVisualStyles()
            Application.Run(frmServer)

            appEventLog_Write("Exit")
            AppEventLog_Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadParameters()
        Try

            numberOfPlayers = getINI(sfile, "gameSettings", "numberOfPlayers")
            numberOfPeriods = getINI(sfile, "gameSettings", "numberOfPeriods")
            portNumber = getINI(sfile, "gameSettings", "port")
            instructionX = getINI(sfile, "gameSettings", "instructionX")
            instructionY = getINI(sfile, "gameSettings", "instructionY")
            windowX = getINI(sfile, "gameSettings", "windowX")
            windowY = getINI(sfile, "gameSettings", "windowY")
            showInstructions = getINI(sfile, "gameSettings", "showInstructions")
            testMode = getINI(sfile, "gameSettings", "testMode")

            valueRange = getINI(sfile, "gameSettings", "valueRange")
            minValue = getINI(sfile, "gameSettings", "minValue")
            maxValue = getINI(sfile, "gameSettings", "maxValue")
            valueType = getINI(sfile, "gameSettings", "valueType")

            historyLength = getINI(sfile, "gameSettings", "historyLength")

            fastSpeed = getINI(sfile, "gameSettings", "fastSpeed")
            fastClockSpeed = getINI(sfile, "gameSettings", "fastClockSpeed")
            fastClockStep = getINI(sfile, "gameSettings", "fastClockStep")
            slowClockSpeed = getINI(sfile, "gameSettings", "slowClockSpeed")
            slowClockStep = getINI(sfile, "gameSettings", "slowClockStep")

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeMessage(sinstr() As String)
        Try
            With frmServer
                Dim index As Integer = sinstr(0)
                Dim str As String = sinstr(1)

                Dim tempa(2) As String
                tempa(1) = "<SEP>"
                tempa(2) = "<EOF>"
                Dim msgtokens() As String = str.Split(tempa, 3, StringSplitOptions.None)

                Dim id As String = msgtokens(0)
                Dim message As String = msgtokens(1)

                Select Case id
                    Case "COMPUTER_NAME"
                        takeRemoteComputerName(index, message)
                    Case "SUBJECT_NAME"
                        takeName(index, message)
                    Case "FINSHED_INSTRUCTIONS"
                        takeFinishedInstructions(index, message)
                    Case "INSTRUCTION_PAGE"
                        takeInstructionPage(index, message)
                    Case "01"
                        takeBid(index, message)
                    Case "02"
                        takeReadyToGoOn(index, message)
                    Case "03"
                        takeStartClock(index, message)
                    Case "04"

                    Case "05"

                    Case "06"
                    Case "07"
                    Case "08"
                    Case "09"
                    Case "10"

                End Select
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeRemoteComputerName(index As Integer, str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            playerlist(index).sp.remoteComputerName = msgtokens(nextToken)
            nextToken += 1
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub takeError(index As Integer, str As String)
        Try
            With frmServer
                .txtError.AppendText(index & ": " & str & vbCrLf)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub startNextPeriod()
        Try
            With frmServer

                If currentPeriod = numberOfPeriods Then
                    'end game
                    checkin = 0

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendShowName()
                    Next
                Else
                    currentPeriod += 1
                    Dim periodStartTime As DateTime = Now

                    If InStr(periodType(currentPeriod), "English") > 0 Or InStr(periodType(currentPeriod), "Dutch") > 0 Then
                        setupClockBids(periodStartTime)
                    Else
                        clockStatus = "takeBids"
                    End If

                    For i As Integer = 1 To numberOfPlayers

                        If showInstructions And periodType(currentPeriod - 1) <> periodType(currentPeriod) Then
                            .dgMain(2, i - 1).Value = "Reading Instructions"
                        Else
                            If InStr(periodType(currentPeriod), "English") > 0 Or InStr(periodType(currentPeriod), "Dutch") > 0 Then
                                If periodType(currentPeriod - 1) <> periodType(currentPeriod) Then
                                    .dgMain(2, i - 1).Value = "Pressing Ready"
                                Else
                                    .dgMain(2, i - 1).Value = "Playing"
                                End If
                            Else
                                .dgMain(2, i - 1).Value = "Playing"
                            End If
                        End If

                        playerlist(i).sendStartNextPeriod(periodStartTime)
                    Next

                End If

                .updatePeriodDisplay()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeName(index As Integer, str As String)
        Try
            With frmServer

                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                playerlist(index).name = msgtokens(nextToken).Replace(",", "<COMMA>")
                nextToken += 1

                playerlist(index).studentID = msgtokens(nextToken).Replace(",", "<COMMA>")
                nextToken += 1

                .dgMain(1, index - 1).Value = playerlist(index).name

                checkin += 1

                If checkin = numberOfPlayers Then
                    checkin = 0

                    'summary price data

                    summaryDf.WriteLine(",")
                    summaryDf.WriteLine("Number,Name,Student ID,Earnings")

                    For i As Integer = 1 To numberOfPlayers
                        Dim outstr As String = ""

                        outstr = playerlist(i).inumber & ","
                        outstr &= playerlist(i).name & ","
                        outstr &= playerlist(i).studentID & ","
                        outstr &= FormatCurrency(Math.Round(playerlist(i).earnings / playerlist(i).exchangeRate, 2),,, False) & ","

                        summaryDf.WriteLine(outstr)
                    Next

                    summaryDf.Close()
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeReadyToGoOn(index As Integer, str As String)
        Try
            With frmServer

                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                takeBezierResult(index, msgtokens, nextToken)

                If .dgMain.RowCount < index Then Exit Sub

                .dgMain(2, index - 1).Value = "Waiting"

                playerlist(index).readyToGoOnPress = True

                '.waitCounter = 0

                checkin = 0
                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).readyToGoOnPress Then checkin += 1
                Next

                If checkin = numberOfPlayers Then
                    checkin = 0
                    writeSummaryData()
                    startNextPeriod()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub takeFinishedInstructions(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                ' checkin += 1

                .dgMain(2, index - 1).Value = "Waiting"

                Dim found As Boolean = False

                For i As Integer = 1 To numberOfPlayers
                    If .dgMain(2, i - 1).Value <> "Waiting" Then
                        found = True
                    End If
                Next

                If Not found Then

                    MessageBox.Show("Start Experiment?", "Start", MessageBoxButtons.OK, MessageBoxIcon.Question)

                    checkin = 0

                    Dim periodStart As DateTime = Now

                    For i As Integer = 1 To numberOfPlayers

                        If InStr(periodType(currentPeriod), "English") > 0 Or InStr(periodType(currentPeriod), "Dutch") > 0 Then
                            .dgMain(2, i - 1).Value = "Press Ready"
                        Else
                            .dgMain(2, i - 1).Value = "Playing"
                        End If

                        playerlist(i).sendFinishedInstructions(periodStart)
                    Next
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeInstructionPage(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempPage As Integer = msgtokens(nextToken)
                nextToken += 1

                .dgMain(2, index - 1).Value = "Page " & tempPage
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupPlayers()
        Try
            For i As Integer = 1 To numberOfPeriods
                Dim msgtokens() As String = getINI(sfile, "players", i).Split(";")
                Dim nextToken As Integer = 0

                For j As Integer = 1 To numberOfPlayers
                    playerlist(j).values(i) = msgtokens(nextToken)
                    nextToken += 1
                Next
            Next

            For i As Integer = 1 To numberOfPeriods
                Dim msgtokens() As String = getINI(sfile, "periods", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                periodType(i) = msgtokens(nextToken)
                nextToken += 1

                periodMinBid(i) = msgtokens(nextToken)
                nextToken += 1
            Next
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeBid(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                If periodComplete(currentPeriod) Then
                    Exit Sub
                End If

                If .dgMain.RowCount = 0 Then Exit Sub
                .dgMain(2, index - 1).Value = "Waiting"

                If playerlist(index).bids(currentPeriod).bidSubmited Then
                    Dim a As Integer = 1
                End If

                playerlist(index).bids(currentPeriod) = New bid(CDbl(msgtokens(nextToken)), index, currentPeriod, True)
                nextToken += 1

                'bezier points
                For i As Integer = 1 To 4
                    Dim tempX As Double = msgtokens(nextToken)
                    nextToken += 1

                    Dim tempY As Double = msgtokens(nextToken)
                    nextToken += 1

                    playerlist(index).bezeirPointsSubmit(i, currentPeriod) = New PointF(tempX, tempY)
                Next

                Dim stopCondition As Boolean = False
                Dim tempC As Integer = 0

                If InStr(periodType(currentPeriod), "English") > 0 Then

                    'check for normal stop
                    For i As Integer = 1 To numberOfPlayers
                        If playerlist(i).bids(currentPeriod).bidSubmited And playerlist(i).bids(currentPeriod).myBid <> valueRange + 1 Then
                            tempC += 1
                        End If
                    Next

                    If tempC >= numberOfPlayers - 1 Then stopCondition = True

                    'check for reached max value
                    If Not stopCondition Then

                        tempC = 0

                        For i As Integer = 1 To numberOfPlayers
                            If playerlist(i).bids(currentPeriod).bidSubmited Then
                                tempC += 1
                            End If
                        Next

                        If tempC = numberOfPlayers Then stopCondition = True
                    End If

                ElseIf InStr(periodType(currentPeriod), "Dutch") > 0 Then

                    'check for normal stop, with one bid
                    For i As Integer = 1 To numberOfPlayers
                        If playerlist(i).bids(currentPeriod).bidSubmited And playerlist(i).bids(currentPeriod).myBid <> -1 Then
                            tempC += 1
                        End If
                    Next

                    If tempC >= 1 Then stopCondition = True

                    'check for zero reached
                    If Not stopCondition Then
                        tempC = 0
                        For i As Integer = 1 To numberOfPlayers
                            If playerlist(i).bids(currentPeriod).bidSubmited Then
                                tempC += 1
                            End If
                        Next

                        If tempC = numberOfPlayers Then stopCondition = True
                    End If
                Else
                    'sealed bid, every one submits
                    For i As Integer = 1 To numberOfPlayers
                        If playerlist(i).bids(currentPeriod).bidSubmited Then
                            tempC += 1
                        End If
                    Next

                    If tempC = numberOfPlayers Then stopCondition = True
                End If

                If stopCondition Then
                    .Timer2.Enabled = True
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupClockBids(periodStartTime As DateTime)
        Try
            With frmServer

                If InStr(periodType(currentPeriod), "English") > 0 Then

                    currentClockPrice = 0

                    ' .Timer2.Enabled = True
                    clockStatus = "running"

                    'For i As Integer = 1 To numberOfPlayers
                    '    playerlist(i).sendClockPriceUpdate()
                    'Next
                ElseIf InStr(periodType(currentPeriod), "Dutch") > 0 Then
                    currentClockPrice = valueRange

                    '  .Timer2.Enabled = True
                    clockStatus = "running"

                    'For i As Integer = 1 To numberOfPlayers
                    '    playerlist(i).sendClockPriceUpdate()
                    'Next
                End If


                'If InStr(periodType(currentPeriod), "Fast") > 0 Then
                '    .Timer2.Interval = fastClockSpeed
                'Else
                '    .Timer2.Interval = slowClockSpeed
                'End If

                If currentPeriod > 1 Then
                    If periodType(currentPeriod) = periodType(currentPeriod - 1) Then
                        ' .Timer2.Enabled = True

                        'Do While .bwTimer2.IsBusy
                        '    Threading.Thread.Sleep(10)
                        'Loop

                        .startTimer2(periodStartTime)
                    End If
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub


    Public Sub calcFirstOrSecondPriceResults()
        Try
            With frmServer
                Dim tempList(100) As player
                Dim tempBidSubmitedCount As Integer = 0

                'sort submited bids
                For i As Integer = 1 To numberOfPlayers
                    Dim tempSpot As Integer

                    'find spot
                    For j As Integer = 1 To numberOfPlayers

                        tempBidSubmitedCount += 1

                        If tempList(j) IsNot Nothing Then
                            If playerlist(i).bids(currentPeriod).myBid >= tempList(j).bids(currentPeriod).myBid Then
                                tempSpot = j
                                Exit For
                            End If
                        Else
                            tempSpot = j
                            Exit For
                        End If
                    Next

                    'insert bid
                    If tempList(tempSpot) IsNot Nothing Then
                        For j As Integer = numberOfPlayers To tempSpot + 1 Step -1
                            If tempList(j - 1) IsNot Nothing Then
                                tempList(j) = tempList(j - 1)
                            End If
                        Next
                    End If

                    tempList(tempSpot) = playerlist(i)
                Next

                'handle random
                Dim count As Integer = 1
                For i As Integer = 2 To numberOfPlayers
                    If tempList(1).bids(currentPeriod).myBid = tempList(i).bids(currentPeriod).myBid Then
                        count += 1
                    End If
                Next

                Dim winner As Integer = tempList(rand(count, 1)).inumber


                If periodType(currentPeriod) = "Slow Dutch" Then
                    'check that slow Dutch did not hit zero
                    If playerlist(winner).bids(currentPeriod).myBid = -1 Then
                        winner = -1
                    End If
                ElseIf periodType(currentPeriod) = "Slow English" Then

                    'if any bids reached the top then pay top price
                    For i As Integer = 1 To numberOfPlayers
                        If playerlist(i).bids(currentPeriod).myBid > valueRange Then
                            playerlist(i).bids(currentPeriod).myBid = valueRange
                        End If
                    Next
                End If

                For i As Integer = 1 To numberOfPlayers

                    If i = winner Then
                        playerlist(i).bids(currentPeriod).won = True
                    Else
                        playerlist(i).bids(currentPeriod).won = False
                    End If
                Next

                If winner = -1 Then
                    'no winner, price hit zero
                    finalPrice(currentPeriod) = 0
                Else
                    Select Case periodType(currentPeriod)

                        Case "Fast First Price", "Slow First Price", "Slow Dutch", "Fast Dutch"
                            finalPrice(currentPeriod) = playerlist(winner).bids(currentPeriod).myBid
                        Case "Fast Second Price", "Slow Second Price", "Fast English", "Slow English"
                            If numberOfPlayers > 1 Then
                                finalPrice(currentPeriod) = tempList(2).bids(currentPeriod).myBid
                            Else
                                finalPrice(currentPeriod) = playerlist(winner).bids(currentPeriod).myBid
                            End If
                    End Select


                    'earnings
                    playerlist(winner).earnings += playerlist(winner).values(currentPeriod) - finalPrice(currentPeriod)

                    playerlist(winner).bids(currentPeriod).updatePricePt(playerlist(winner).values(currentPeriod))
                End If


                currentClockPrice = finalPrice(currentPeriod)
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub writeSummaryData()
        Try
            With frmServer

                For i As Integer = 1 To numberOfPlayers
                    Dim outstr As String = ""

                    outstr = currentPeriod & ","
                    outstr &= periodType(currentPeriod) & ","
                    outstr &= i & ","

                    If InStr(periodType(currentPeriod), "English") > 0 Then
                        If playerlist(i).bids(currentPeriod).won Then
                            outstr &= "-1" & ","
                        Else
                            outstr &= playerlist(i).bids(currentPeriod).myBid & ","
                        End If
                    ElseIf InStr(periodType(currentPeriod), "Dutch") > 0 Then
                        If playerlist(i).bids(currentPeriod).won Then
                            outstr &= playerlist(i).bids(currentPeriod).myBid & ","
                        Else
                            outstr &= "-1" & ","
                        End If
                    Else
                            outstr &= playerlist(i).bids(currentPeriod).myBid & ","
                    End If

                    outstr &= playerlist(i).bids(currentPeriod).won & ","
                    outstr &= playerlist(i).values(currentPeriod) & ","
                    outstr &= finalPrice(currentPeriod) & ","

                    If playerlist(i).bids(currentPeriod).won Then
                        outstr &= playerlist(i).values(currentPeriod) - finalPrice(currentPeriod) & ","
                    Else
                        outstr &= "0" & ","
                    End If

                    For j As Integer = 1 To 4
                        outstr &= playerlist(i).bezeirPointsSubmit(j, currentPeriod).X & ","
                        outstr &= playerlist(i).bezeirPointsSubmit(j, currentPeriod).Y & ","
                    Next

                    For j As Integer = 1 To 4
                        outstr &= playerlist(i).bezeirPointsResults(j, currentPeriod).X & ","
                        outstr &= playerlist(i).bezeirPointsResults(j, currentPeriod).Y & ","
                    Next

                    outstr &= playerlist(i).resultBids(currentPeriod) & ","

                    If playerlist(i).bezeirPointsResults(1, currentPeriod).X <> -1 Then
                        outstr &= getValuePoints(playerlist(i).bezeirPointsResults(1, currentPeriod),
                                             playerlist(i).bezeirPointsResults(2, currentPeriod),
                                             playerlist(i).bezeirPointsResults(3, currentPeriod),
                                             playerlist(i).bezeirPointsResults(4, currentPeriod))
                    End If

                    summaryDf.WriteLine(outstr)

                    'update server earnings
                    .dgMain(3, i - 1).Value = FormatCurrency(Math.Round(playerlist(i).earnings / playerlist(i).exchangeRate, 2),,, False)
                Next

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeStartClock(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                .dgMain(2, index - 1).Value = "Waiting"

                Dim found As Boolean = False

                For i As Integer = 1 To numberOfPlayers
                    If .dgMain(2, i - 1).Value <> "Waiting" Then
                        found = True
                    End If
                Next

                If Not found Then

                    Dim periodStartTime As DateTime = Now

                    For i As Integer = 1 To numberOfPlayers
                        .dgMain(2, i - 1).Value = "Playing"
                        playerlist(i).sendStartClock(periodStartTime)
                    Next

                    '  .Timer2.Enabled = True
                    .startTimer2(periodStartTime)

                End If
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeBezierResult(index As Integer, msgtokens() As String, ByRef nextToken As Integer)
        Try

            'bezier points
            For i As Integer = 1 To 4
                Dim tempX As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempY As Double = msgtokens(nextToken)
                nextToken += 1

                playerlist(index).bezeirPointsResults(i, currentPeriod) = New PointF(tempX, tempY)
            Next

            playerlist(index).resultBids(currentPeriod) = msgtokens(nextToken)
            nextToken += 1

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub


End Module
