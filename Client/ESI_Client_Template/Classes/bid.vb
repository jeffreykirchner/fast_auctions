Imports System.Drawing.Drawing2D

Public Class bid
    Public myBid As Double
    Public bidPt As PointF
    Public pricePt As PointF
    Public valuePt As PointF
    Public won As Boolean
    Public period As Integer

    Dim pGreen As New Pen(Color.Green, 5)
    Dim pRed As New Pen(Color.Crimson, 5)

    Public Sub New()

        pGreen.Alignment = PenAlignment.Center
        pRed.Alignment = PenAlignment.Center

        pRed.EndCap = LineCap.Triangle
        pGreen.EndCap = LineCap.Triangle
    End Sub

    Public Sub draw(g As Graphics)
        Try
            With frmRealTime

                'If myBid <= 0 Then Return

                Dim historyAlpha As Integer = 255 - (currentPeriod - period) * (200 / historyLength)
                If historyAlpha < 0 Then Exit Sub

                Dim tempPGreen As Pen = pGreen.Clone
                tempPGreen.Color = Color.FromArgb(historyAlpha, pGreen.Color)

                Dim tempP3_Green As Pen = .p3_green.Clone
                tempP3_Green.Color = Color.FromArgb(historyAlpha, .p3_green.Color)

                Dim tempPRed As Pen = pRed.Clone
                tempPRed.Color = Color.FromArgb(historyAlpha, pRed.Color)

                Dim tempP3_Red As Pen = .p3_red.Clone
                tempP3_Red.Color = Color.FromArgb(historyAlpha, .p3_red.Color)

                Dim tempP3_Grey As Pen = .p3_grey.Clone
                tempP3_Grey.Color = Color.FromArgb(historyAlpha, .p3_grey.Color)

                If won Then

                    If finalPrice(period) <= values(period) Then
                        'gain
                        g.DrawLine(tempPGreen,
                                   CInt(Math.Round(pricePt.X)),
                                   CInt(Math.Round(pricePt.Y)),
                                   CInt(Math.Round(valuePt.X)),
                                   CInt(Math.Round(valuePt.Y)))

                        .drawX(g, tempP3_Green, New Point(Math.Round(pricePt.X), Math.Round(pricePt.Y)), 6)
                    Else
                        'loss
                        g.DrawLine(tempPRed, CInt(Math.Round(pricePt.X)), CInt(Math.Round(pricePt.Y)), CInt(Math.Round(valuePt.X)), CInt(Math.Round(valuePt.Y)))

                        .drawX(g, tempP3_Red, New Point(Math.Round(pricePt.X), Math.Round(pricePt.Y)), 6)
                    End If

                Else
                    'price
                    .drawX(g, tempP3_Grey, New Point(Math.Round(pricePt.X), Math.Round(pricePt.Y)), 6)
                End If

                'bid

                If Not won Or (won And InStr(periodType(period), "English") = 0) Then
                    If myBid >= 0 And myBid <= valueRange Then

                        g.FillEllipse(New SolidBrush(Color.FromArgb(historyAlpha, Color.Black)),
                                      New Rectangle(Math.Round(bidPt.X) - 5, Math.Round(bidPt.Y) - 5, 10, 10))

                    End If
                End If


            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub fromString(msgtokens() As String, ByRef nextToken As Integer)
        Try

            myBid = msgtokens(nextToken)
            nextToken += 1

            won = msgtokens(nextToken)
            nextToken += 1
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class
