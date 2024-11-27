

Public Class player

    Public sp As New socketPlayer
    Public inumber As Integer
    Public name As String
    Public studentID As String

    Public exchangeRate As Integer

    Public values(1000) As Double
    Public bids(1000) As bid

    Public earnings As Double

    Public readyToGoOnPress As Boolean

    Public bezeirPointsSubmit(4, 1000) As PointF
    Public bezeirPointsResults(4, 1000) As PointF
    Public resultBids(1000) As Double

    Public Sub sendMessage(index As String, message As String)
        Try
            If sp Is Nothing Then Exit Sub

            sp.send(index, message)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendreset()
        Try
            Dim outstr As String = ""

            sendMessage("RESET", outstr)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendShowName()
        Try
            Dim str As String = ""

            str &= Math.Round(earnings / exchangeRate, 2) & ";"

            sendMessage("SHOW_NAME", str)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendEndEarly()
        Try
            'end experiment early

            With frmServer
                Dim outstr As String

                outstr = numberOfPeriods & ";"
                sendMessage("END_EARLY", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendInvalidConnection()
        Try
            sendMessage("INVALID_CONNECTION", "")
        Catch ex As Exception
            appEventLog_Write("error SendInvalidConnection:", ex)
        End Try
    End Sub

    Public Sub sendBegin(str As String)
        Try
            earnings = 0
            exchangeRate = getINI(sfile, "exchangeRate", CStr(inumber))

            For i As Integer = 1 To numberOfPeriods
                For j As Integer = 1 To 4
                    bezeirPointsResults(j, i) = New Point(-1, -1)
                    bezeirPointsSubmit(j, i) = New Point(-1, -1)
                Next
            Next

            Dim outstr As String = str

            outstr &= numberOfPlayers & ";"
            outstr &= numberOfPeriods & ";"
            outstr &= portNumber & ";"
            outstr &= instructionX & ";"
            outstr &= instructionY & ";"
            outstr &= windowX & ";"
            outstr &= windowY & ";"
            outstr &= showInstructions & ";"
            outstr &= inumber & ";"
            outstr &= testMode & ";"
            outstr &= exchangeRate & ";"

            outstr &= valueRange & ";"
            outstr &= minValue & ";"
            outstr &= maxValue & ";"
            outstr &= valueType & ";"
            outstr &= historyLength & ";"

            outstr &= fastSpeed & ";"
            outstr &= fastClockSpeed & ";"
            outstr &= fastClockStep & ";"
            outstr &= slowClockSpeed & ";"
            outstr &= slowClockStep & ";"

            For i As Integer = 1 To numberOfPeriods
                outstr &= values(i) & ";"
                outstr &= periodType(i) & ";"
                outstr &= periodMinBid(i) & ";"
            Next

            readyToGoOnPress = False

            sendMessage("BEGIN", outstr)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendStartNextPeriod(periodStartTime As DateTime)
        Try
            readyToGoOnPress = False

            Dim tempShowInstructions As Boolean = False
            If showInstructions Then
                If periodType(currentPeriod) <> periodType(currentPeriod - 1) Then
                    tempShowInstructions = True
                End If
            End If

            Dim outstr As String = ""

            outstr = currentPeriod & ";"
            outstr &= tempShowInstructions & ";"
            outstr &= periodStartTime.ToString() & ";"

            sendMessage("01", outstr)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendPeriodResultsSlow()
        Try
            Dim outstr As String = ""

            outstr = bids(currentPeriod).convertToString
            outstr &= finalPrice(currentPeriod) & ";"
            outstr &= Math.Round(earnings / exchangeRate, 2) & ";"

            sendMessage("02", outstr)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendPeriodResultsFast()
        Try
            Dim outstr As String = ""

            outstr = bids(currentPeriod).convertToString
            outstr &= finalPrice(currentPeriod) & ";"
            outstr &= Math.Round(earnings / exchangeRate, 2) & ";"

            sendMessage("03", outstr)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendFinishedInstructions(periodStartTime As DateTime)
        Try
            With frmServer
                Dim outstr As String = ""

                outstr = currentPeriod & ";"
                outstr &= periodStartTime.ToString() & ";"

                sendMessage("FINISHED_INSTRUCTIONS", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendClockPriceUpdate()
        Try
            Dim outstr As String = ""

            outstr = currentClockPrice & ";"
            outstr &= bids(currentPeriod).myBid & ";"

            ' sendMessage("04", outstr)
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendStartClock(periodStartTime As DateTime)
        Try
            Dim outstr As String = ""

            outstr = periodStartTime.ToString() + ";"

            sendMessage("05", outstr)
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub


    'the bid Curve
    Public p_curve As Pen
    Public p_Profit As Pen
    Public p2_dash As Pen
    Public bezeir1 As PointF
    Public bezeir2 As PointF
    Public bezeir3 As PointF
    Public bezeir4 As PointF
    Public Sub drawCurve(ByVal g As Graphics, period As Integer, ptsList(,) As PointF)
        Try
            With frmServer
                If period = 0 Then Exit Sub


                If ptsList(1, period).X = -1 Then Exit Sub

                bezeir1 = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, ptsList(1, period).X),
                                     .convertToY(ptsList(1, period).Y, 0, valueRange, .yStop - .yStart, 0, .yStart))

                bezeir2 = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, ptsList(2, period).X),
                                     .convertToY(ptsList(2, period).Y, 0, valueRange, .yStop - .yStart, 0, .yStart))

                bezeir3 = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, ptsList(3, period).X),
                                     .convertToY(ptsList(3, period).Y, 0, valueRange, .yStop - .yStart, 0, .yStart))

                bezeir4 = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, ptsList(4, period).X),
                                     .convertToY(ptsList(4, period).Y, 0, valueRange, .yStop - .yStart, 0, .yStart))

                g.DrawBezier(p_curve, bezeir1, bezeir2, bezeir3, bezeir4)



                If InStr(periodType(period), "English") > 0 Then
                    If Not bids(period).won Then
                        g.FillEllipse(New SolidBrush(getMyColor(inumber)),
                                  New Rectangle(.convertToX(.xStop - .xStart, .xStart, 0, values(period)) - 5,
                                                .convertToY(bids(period).myBid, 0, valueRange, .yStop - .yStart, 0, .yStart) - 5,
                                                10, 10))
                    End If
                ElseIf InStr(periodType(period), "Dutch") > 0 Then
                    If bids(period).won Then
                        g.FillEllipse(New SolidBrush(getMyColor(inumber)),
                                  New Rectangle(.convertToX(.xStop - .xStart, .xStart, 0, values(period)) - 5,
                                                .convertToY(bids(period).myBid, 0, valueRange, .yStop - .yStart, 0, .yStart) - 5,
                                                10, 10))
                    End If
                Else

                    g.FillEllipse(New SolidBrush(getMyColor(inumber)),
                                  New Rectangle(.convertToX(.xStop - .xStart, .xStart, 0, values(period)) - 5,
                                                .convertToY(bids(period).myBid, 0, valueRange, .yStop - .yStart, 0, .yStart) - 5,
                                                10, 10))
                End If



            End With

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawWinner(ByVal g As Graphics, period As Integer)
        Try
            With frmServer
                If period = 0 Then Exit Sub

                If bids(period).won Then

                    ' g.FillEllipse(Brushes.Black, New Rectangle(Math.Round(tempBidPt.X) - 8, Math.Round(tempBidPt.Y) - 8, 16, 16))
                    g.DrawLine(p_Profit, CInt(Math.Round(bids(period).pricePt.X)),
                                        CInt(Math.Round(bids(period).pricePt.Y)),
                                        CInt(Math.Round(bids(period).valuePt.X)),
                                        CInt(Math.Round(bids(period).valuePt.Y)))

                    .drawX(g,
                           p_curve,
                           New Point(Math.Round(bids(period).pricePt.X), Math.Round(bids(period).pricePt.Y)),
                           6)

                    g.FillEllipse(Brushes.Black, New Rectangle(Math.Round(bids(period).pricePt.X) - 3, Math.Round(bids(period).pricePt.Y) - 3, 6, 6))

                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawValue(g As Graphics, period As Integer)
        Try
            With frmServer
                Dim valueX As Integer = Math.Round(.convertToX(.xStop - .xStart, .xStart, 0, values(period)))
                g.DrawLine(p2_dash,
                   valueX,
                   .yStart,
                   valueX,
                  .yStop)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

End Class
