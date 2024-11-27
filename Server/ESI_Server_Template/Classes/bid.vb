Imports System.Drawing.Drawing2D

Public Class bid
    Public myBid As Double
    Public bidPt As PointF
    Public won As Boolean
    Public pricePt As PointF
    Public valuePt As PointF
    Public period As Integer
    Public playerId As Integer
    Public value As Double

    Public bidSubmited As Boolean

    Dim pGreen As New Pen(Color.Green, 5)
    Dim pRed As New Pen(Color.Crimson, 5)

    Public Sub New(myBid As Double, playerId As Integer, period As Integer, bidSubmited As Boolean)
        With frmServer
            Me.myBid = myBid
            Me.playerId = playerId
            Me.period = period
            Me.bidSubmited = bidSubmited

            value = playerlist(playerId).values(period)

            'bid point
            bidPt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, value),
                               .convertToY(myBid, 0, valueRange, .yStop - .yStart, 0, .yStart))

            'value point
            valuePt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, value),
                                 .convertToY(value, 0, valueRange, .yStop - .yStart, 0, .yStart))

            .capPen(pGreen)
            .capPen(pRed)

            pGreen.Color = getMyColor(playerId)
            pRed.Color = getMyColor(playerId)
        End With
    End Sub

    Public Sub updatePricePt(value As Double)
        Try
            With frmServer
                pricePt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, value),
                                     .convertToY(finalPrice(period), 0, valueRange, .yStop - .yStart, 0, .yStart))
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub draw(g As Graphics)
        Try
            With frmServer
                Dim tempBidPt As PointF
                If InStr(periodType(period), "English") > 0 And won Then
                    tempBidPt = pricePt
                Else
                    tempBidPt = bidPt
                End If


                If won And .cbHistory.Checked Then

                    If finalPrice(period) <= value Then
                        'gain
                        ' g.DrawLine(pGreen, CInt(Math.Round(pricePt.X)), CInt(Math.Round(pricePt.Y)), CInt(Math.Round(valuePt.X)), CInt(Math.Round(valuePt.Y)))

                        .drawX(g, playerlist(playerId).p_curve, New Point(Math.Round(pricePt.X), Math.Round(pricePt.Y)), 3)
                    Else
                        'loss
                        '   g.DrawLine(pRed, CInt(Math.Round(pricePt.X)), CInt(Math.Round(pricePt.Y)), CInt(Math.Round(valuePt.X)), CInt(Math.Round(valuePt.Y)))

                        .drawX(g, playerlist(playerId).p_curve, New Point(Math.Round(pricePt.X), Math.Round(pricePt.Y)), 3)
                    End If

                    'If myBid >= 0 And myBid <= valueRange Then
                    '    If period = currentPeriod - 1 Then

                    '        ' g.FillEllipse(Brushes.Black, New Rectangle(Math.Round(tempBidPt.X) - 8, Math.Round(tempBidPt.Y) - 8, 16, 16))
                    '        g.DrawLine(pGreen, CInt(Math.Round(pricePt.X)), CInt(Math.Round(pricePt.Y)), CInt(Math.Round(valuePt.X)), CInt(Math.Round(valuePt.Y)))

                    '    End If
                    'End If
                Else
                    If myBid >= 0 And myBid <= valueRange And Not won Then
                        g.FillEllipse(Brushes.DimGray, New Rectangle(Math.Round(tempBidPt.X) - 8, Math.Round(tempBidPt.Y) - 8, 16, 16))
                        g.FillEllipse(New SolidBrush(getMyColor(playerId)), New Rectangle(Math.Round(tempBidPt.X) - 4, Math.Round(tempBidPt.Y) - 4, 8, 8))
                        g.DrawEllipse(Pens.Black, New Rectangle(Math.Round(tempBidPt.X) - 4, Math.Round(tempBidPt.Y) - 4, 8, 8))
                    End If
                End If


                'If myBid >= 0 And myBid <= valueRange Then
                '    g.FillEllipse(Brushes.DimGray, New Rectangle(Math.Round(tempBidPt.X) - 8, Math.Round(tempBidPt.Y) - 8, 16, 16))
                '    g.FillEllipse(Brushes.Black, New Rectangle(Math.Round(tempBidPt.X) - 4, Math.Round(tempBidPt.Y) - 4, 8, 8))
                'End If

                If myBid >= 0 And myBid <= valueRange Then
                    If InStr(periodType(currentPeriod), "Slow") > 0 Then



                        'g.FillEllipse(Brushes.Black, New Rectangle(Math.Round(tempBidPt.X) - 5, Math.Round(tempBidPt.Y) - 5, 10, 10))
                        'g.DrawString(playerId, .f6, Brushes.White, Math.Round(tempBidPt.X), Math.Round(tempBidPt.Y) - 4, .fmt)


                        'g.DrawString(playerId, .f16, Brushes.Black, bidPt.X, bidPt.Y, .fmt)


                    End If
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function convertToString() As String
        Try
            Dim outstr As String = ""

            outstr &= myBid & ";"
            outstr &= won & ";"

            Return outstr
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function
End Class
