Imports System.Drawing.Drawing2D

Public Class frmRealTime
    Public mainScreenL As Screen
    Public mainScreenR As Screen

    'drawing variables
    Public f1 As New Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Bold)
    Public f2 As New Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
    Public f10 As New Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
    Public f3 As New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold)
    Public f4 As New Font("Microsoft Sans Serif", 6, System.Drawing.FontStyle.Bold)

    Public p1 As New Pen(Brushes.Black, 3)
    Public p2_dash As New Pen(Brushes.Black, 2)
    Public p3_grey As New Pen(Brushes.DimGray, 3)

    Public p1_greyDash As New Pen(Brushes.DimGray, 1)
    Public p2_greyDash As New Pen(Brushes.DimGray, 2)
    Public p3_green As New Pen(Brushes.Green, 3)
    Public p3_red As New Pen(Brushes.Crimson, 3)

    Public p3_Blue As New Pen(Brushes.CornflowerBlue, 3)
    Public p3_Black As New Pen(Brushes.Black, 3)

    Public fmt As New StringFormat 'center alignment
    Public fmt2 As New StringFormat 'right alignment

    Dim tempY As Double
    Dim tempYIncrement As Double
    Dim tempX As Double
    Dim tempXIncrement As Double
    Dim tempP As Double
    Dim tempPIncrement As Double
    Dim gridCount As Integer = 10
    Public xStart As Integer = 40
    Public xStop As Integer     'defined in load
    Public yStart As Integer = 20
    Public yStop As Integer     'defined in load
    Dim controlPointWidth As Integer = 14

    Public bezeir1 As PointF
    Public bezeir2 As PointF
    Public bezeir3 As PointF
    Public bezeir4 As PointF

    Public closePoint As PointF = New PointF(-1, -1)
    Public valuePoint As PointF = New PointF(-1, -1)
    Public controlPointTarget As Integer = -1

    Dim tempPathBidGreaterThanValue As New GraphicsPath

    Dim readyToGoOnFlasher As Integer = 1
    Public disableScreen As Boolean = False
    Public timeOfLastRefresh As DateTime = Now


    Private Sub frmRealTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mainScreenL = New Screen(pnlLeft, New Rectangle(0, 0, pnlLeft.Width, pnlLeft.Height))
            mainScreenR = New Screen(pnlRight, New Rectangle(0, 0, pnlRight.Width, pnlRight.Height))
            fmt.Alignment = StringAlignment.Center
            fmt2.Alignment = StringAlignment.Far

            setTriangleEndCap(p1)
            setTriangleEndCap(p2_dash)
            setTriangleEndCap(p3_grey)
            setTriangleEndCap(p3_green)
            setTriangleEndCap(p3_red)
            setTriangleEndCap(p2_greyDash)

            Dim gp As New GraphicsPath

            gp.AddLine(0, 0, -3, -5)
            gp.AddLine(-3, -5, 3, -5)
            gp.AddLine(3, -5, 0, 0)

            Dim clc As New CustomLineCap(gp, Nothing)

            p2_dash.DashStyle = DashStyle.Dash
            p2_dash.CustomEndCap = clc

            p1_greyDash.DashStyle = DashStyle.Dash

            p2_greyDash.DashStyle = DashStyle.Dash


            xStop = pnlRight.Width - 10
            yStop = pnlRight.Height - 30

            tempPathBidGreaterThanValue.AddLine(xStart, yStart, xStart, yStop) 'down
            tempPathBidGreaterThanValue.AddLine(xStart, yStop, xStop, CInt(Math.Round(convertToY(maxValue, 0, valueRange, yStop - yStart, 0, yStart))))

            tempPathBidGreaterThanValue.AddLine(xStop, CInt(Math.Round(convertToY(maxValue, 0, valueRange, yStop - yStart, 0, yStart))), xStop, yStart)
            tempPathBidGreaterThanValue.AddLine(xStop, yStart, xStart, yStart)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setTriangleEndCap(ByRef p As Pen)
        Try
            p.EndCap = LineCap.Triangle
            p.StartCap = LineCap.Triangle
            p.Alignment = PenAlignment.Center
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawAxis(ByVal g As Graphics, pnlBackGround As Panel)
        Try


            'grid
            'For i As Integer = 1 To gridCount
            '    g.DrawLine(Pens.LightGray, 50, yGrid(i), pnlBackGround.Width - 10, yGrid(i))
            'Next

            'For i As Integer = 1 To numberOfPeriods
            '    g.DrawLine(Pens.LightGray, xGrid(i), 5, xGrid(i), pnlBackGround.Height - 30)
            'Next

            'axis
            g.DrawLine(p1, xStart, yStart, xStart, pnlBackGround.Height - 30)
            g.DrawLine(p1, xStart, yStop, xStop, yStop)

            'bid ticks
            '   tempY = yStart
            '   tempYIncrement = (yStop) / valueRange

            tempP = valueRange
            tempPIncrement = 1 '(nudScale.Value - sellQuantity) / gridCount

            For i As Integer = 1 To valueRange
                'bid ticks
                tempY = convertToY(i, 0, valueRange, yStop - yStart, 0, yStart)
                g.DrawLine(p1, xStart - 5, CInt(tempY), xStart, CInt(tempY))
                g.DrawString(i, f2, Brushes.Black, xStart - 5, tempY - 7, fmt2)

                '  tempY += tempYIncrement
                ' tempP -= tempPIncrement
            Next

            'value ticks
            '  tempXIncrement = (xStop - xStart) / valueRange
            '   tempX = xStart + tempXIncrement
            For i As Integer = 1 To maxValue
                tempX = convertToX(xStop - xStart, xStart, 0, i)
                g.DrawLine(p1, CInt(tempX), CInt(yStop), CInt(tempX), CInt(yStop + 5))
                g.DrawString(CStr(i), f2, Brushes.Black, tempX + 5, yStop + 5, fmt2)
                tempX += tempXIncrement
            Next

            g.TranslateTransform(0, pnlBackGround.Height)
            g.DrawString("Value ->", f10, Brushes.DarkGray, 0, -25)
            g.RotateTransform(-90)
            g.DrawString("Bid ->", f10, Brushes.DarkGray, 30, 0)
            g.ResetTransform()

            'g.TranslateTransform(pnlBackGround.Width / 2, pnlBackGround.Height - 15)
            'g.DrawString("Period", f3, Brushes.DarkGray, 0, 0)
            'g.ResetTransform()

        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub

    Public Sub drawCurve(ByVal g As Graphics, pnlBackGround As Panel)
        Try
            g.DrawBezier(p3_Blue, bezeir1, bezeir2, bezeir3, bezeir4)

            ' setupScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawControlPoints(ByVal g As Graphics, pnlBackGround As Panel)
        Try

            g.DrawLine(p1_greyDash, bezeir1, bezeir2)
            g.DrawLine(p1_greyDash, bezeir3, bezeir4)

            'control points
            drawControlPoint(g, bezeir2)
            drawControlPoint(g, bezeir3)
            drawControlPoint(g, bezeir4)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawControlPoint(g As Graphics, p As PointF)
        Try
            g.FillRectangle(Brushes.CornflowerBlue, New Rectangle(p.X - controlPointWidth / 2,
                                                       p.Y - controlPointWidth / 2,
                                                       controlPointWidth,
                                                       controlPointWidth))

            g.DrawRectangle(Pens.Black, New Rectangle(p.X - controlPointWidth / 2,
                                                    p.Y - controlPointWidth / 2,
                                                    controlPointWidth,
                                                    controlPointWidth))

            'g.FillEllipse(Brushes.CornflowerBlue, New Rectangle(p.X - controlPointWidth / 2,
            '                                           p.Y - controlPointWidth / 2,
            '                                           controlPointWidth,
            '                                           controlPointWidth))

            'g.DrawEllipse(Pens.Black, New Rectangle(p.X - controlPointWidth / 2,
            '                                        p.Y - controlPointWidth / 2,
            '                                        controlPointWidth,
            '                                        controlPointWidth))

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub drawBidGreaterThanValue(g As Graphics)
        Try


            g.FillPath(New SolidBrush(Color.FromArgb(50, Color.Crimson)), tempPathBidGreaterThanValue)

            g.TranslateTransform(xStart + 110, yStart + 50)
            'g.RotateTransform(-25)

            g.DrawString("You may lose money" & vbCrLf & "in this area.", f2, Brushes.Crimson, 0, -25, fmt)

            g.ResetTransform()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawMinBid(g As Graphics)
        Try
            If periodMinBid(currentPeriod) = 0 Then Return

            Dim tempY As Integer = Math.Round(convertToY(periodMinBid(currentPeriod), 0, valueRange, yStop - yStart, 0, yStart))

            g.DrawLine(p2_greyDash, xStart, tempY, xStop, tempY)
            g.DrawString("Minimum Bid: " & Format(periodMinBid(currentPeriod), "0.00"), f2, Brushes.Gray, New Point(xStop, tempY - 20), fmt2)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Dim tempValue As Double
    Dim tempBid As Double
    Public Sub drawBidValue(g As Graphics, pt As PointF, b As Brush, p As Pen)
        Try
            'value
            Dim valueX As Integer = Math.Round(convertToX(xStop - xStart, xStart, 0, values(currentPeriod)))
            g.DrawLine(p2_dash,
                       valueX,
                       yStart,
                       valueX,
                       yStop)

            If xStop - valueX < 50 Then
                g.DrawString("Value", f2, Brushes.Black, valueX, yStart - 19, fmt2)
            Else
                g.DrawString("Value", f2, Brushes.Black, valueX, yStart - 19, fmt)
            End If


            If pt.X = -1 Then Exit Sub

            tempValue = convertFromX(xStop - xStart, xStart, 0, pt.X)
            tempBid = convertFromY(pt.Y, 0, valueRange, yStop - yStart, 0, yStart)
            If tempBid > maxValue Then tempBid = maxValue


            'old right angle display
            'If Math.Round(tempBid, 2) > Math.Round(tempValue, 2) Then
            '    g.FillEllipse(Brushes.Crimson, New Rectangle(pt.X - 3, pt.Y - 3, 6, 6))
            '    g.DrawLine(Pens.Crimson, pt.X, pt.Y, xStart, pt.Y)

            '    g.DrawLine(Pens.Crimson, pt.X, pt.Y, pt.X, CInt(convertToY(tempValue, 0, valueRange, yStop - yStart, 0, yStart)))
            '    g.DrawLine(p, pt.X, CInt(convertToY(tempValue, 0, valueRange, yStop - yStart, 0, yStart)), pt.X, yStop)
            'Else
            '    g.DrawLine(p, pt.X, pt.Y, xStart, pt.Y)
            '    g.DrawLine(p, pt.X, pt.Y, pt.X, yStop)

            '    g.FillEllipse(b, New Rectangle(pt.X - 3, pt.Y - 3, 6, 6))
            'End If

            g.FillEllipse(b, New Rectangle(Math.Round(pt.X) - 8, Math.Round(pt.Y) - 8, 16, 16))
            g.FillEllipse(Brushes.White, New Rectangle(Math.Round(pt.X) - 3, Math.Round(pt.Y) - 3, 6, 6))

            tempBid = Math.Round(tempBid, 2)
            tempValue = Math.Round(tempValue, 2)

            'g.DrawString("Value = " & Format(tempValue, "0.00") & vbCrLf & "Bid = " & Format(tempBid, "0.00"),
            '           f2,
            '           Brushes.DimGray,
            '           (pt.X - xStart) / 5 * 4 + 1, pt.Y - 18,
            '           fmt)

            'g.DrawString("Value = " & Format(tempValue, "0.00") & vbCrLf & "Bid = " & Format(tempBid, "0.00"),
            '            f2,
            '            b,
            '            (pt.X - xStart) / 5 * 4, pt.Y - 18,
            '            fmt)


            If InStr(periodType(currentPeriod), "Fast") > 0 Then
                txtBid.Text = Format(Math.Round(tempBid, 2), "0.00")
            End If


        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawHistory(g As Graphics)
        Try
            Dim tempC As Integer = 0
            For i As Integer = currentPeriod + 1 To 1 Step -1

                If bids(i) IsNot Nothing Then
                    '  If bids(i).won Then
                    tempC += 1
                    bids(i).draw(g)
                    '  End If
                End If

                If tempC = historyLength Then Exit For
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawClockPrice(g As Graphics)
        Try

            If Not InStr(periodType(currentPeriod), "English") > 0 And
               Not InStr(periodType(currentPeriod), "Dutch") > 0 Then

                Exit Sub
            End If

            'If currentClockPrice >= 0 Then Exit Sub
            If currentClockPrice = -1 Then Exit Sub

            Dim tempY As Integer = convertToY(currentClockPrice, 0, valueRange, yStop - yStart, 0, yStart)
            Dim tempX As Integer = convertToX(xStop - xStart, xStart, 0, values(currentPeriod))

            ' g.DrawLine(p3_grey, xStart, tempY, xStop, tempY)

            If tempX < xStop - 150 Then
                g.DrawString("Price = " & Format(currentClockPrice, "0.00"), f1, Brushes.DimGray, New Point(tempX + 10, tempY - 12))

                If disableScreen And InStr(periodType(currentPeriod), "English") > 0 Then
                    g.DrawString("Out",
                                 f1,
                                 Brushes.DimGray,
                                 convertToX(xStop - xStart, xStart, 0, values(currentPeriod)) - 10,
                                 convertToY(currentClockBid, 0, valueRange, yStop - yStart, 0, yStart) - 12, fmt2)
                End If
            Else
                g.DrawString("Price = " & Format(currentClockPrice, "0.00"), f1, Brushes.DimGray, New Point(tempX - 15, tempY - 12), fmt2)

                If disableScreen And InStr(periodType(currentPeriod), "English") > 0 Then
                    g.DrawString("Out",
                                 f1,
                                 Brushes.DimGray,
                                 convertToX(xStop - xStart, xStart, 0, values(currentPeriod)) + 10,
                                 convertToY(currentClockBid, 0, valueRange, yStop - yStart, 0, yStart) - 12)
                End If
            End If

            'follow price
            g.FillEllipse(Brushes.DimGray, New Rectangle(tempX - 5,
                                                         tempY - 5,
                                                         10,
                                                         10))

            'test code
            ' Dim ts As TimeSpan = Now - periodStartTime
            ' g.DrawString("Elapsed Time: " & ts.TotalSeconds, f10, Brushes.Black, New Point(tempX, tempY + 15))
            'g.DrawString("Price=6: " & priceE6.TotalSeconds, f10, Brushes.Black, New Point(tempX, tempY + 30))

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            Dim ts As TimeSpan = Now - timeOfLastRefresh

            If ts.Milliseconds <= 90 Then Exit Sub

            Select Case periodType(currentPeriod)
                Case "Slow English"
                    refreshScreenSlow()
                Case "Slow Dutch"
                    refreshScreenSlow()
                Case "Slow First Price"
                    refreshScreenSlow()
                Case "Slow Second Price"
                    refreshScreenSlow()
                Case "Fast English"
                    refreshScreenFast()
                Case "Fast Dutch"
                    refreshScreenFast()
                Case "Fast First Price"
                    refreshScreenFast()
                Case "Fast Second Price"
                    refreshScreenFast()
            End Select

            If readyToGoOnFlasher = 1 Then
                readyToGoOnFlasher = 0
            Else
                readyToGoOnFlasher = 1
            End If

            If InStr(cmdSubmitFirst.Text, "Ready") Then
                If readyToGoOnFlasher = 1 Then
                    cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                Else
                    cmdSubmitFirst.BackColor = SystemColors.Control
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub refreshScreenSlow()
        Try
            timeOfLastRefresh = Now

            'rightScreen
            If mainScreenR Is Nothing Then Exit Sub

            mainScreenR.erase1()
            Dim g2 As Graphics = mainScreenR.GetGraphics

            g2.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            drawBidGreaterThanValue(g2)
            drawAxis(g2, pnlRight)
            drawMinBid(g2)
            ' drawCurve(g2, pnlRight)
            '  drawBidValue(g2, closePoint, Brushes.Black, Pens.Black)

            drawBidValue(g2, valuePoint, Brushes.Black, Pens.Black)
            drawHistory(g2)

            drawClockPrice(g2)


            '   drawControlPoints(g2, pnlRight)

            mainScreenR.flip()

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub refreshScreenFast()
        Try
            timeOfLastRefresh = Now
            'left screen
            'mainScreenL.erase1()
            'Dim g As Graphics = mainScreenL.GetGraphics

            'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            'drawAxis(g, pnlLeft)

            'mainScreenL.flip()

            'rightScreen
            If mainScreenR Is Nothing Then Exit Sub
            mainScreenR.erase1()
            Dim g2 As Graphics = mainScreenR.GetGraphics

            g2.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            drawBidGreaterThanValue(g2)
            drawAxis(g2, pnlRight)

            drawHistory(g2)
            drawCurve(g2, pnlRight)
            '  drawBidValue(g2, closePoint, Brushes.Black, Pens.Black)

            drawClockPrice(g2)
            drawBidValue(g2, valuePoint, Brushes.Black, Pens.Black)

            drawControlPoints(g2, pnlRight)

            mainScreenR.flip()

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setupScreenTest()
        Try

            ' Dim tempStartY As Integer = rand(maxValue, minValue)

            bezeir1 = New Point(convertToX(xStop - xStart, xStart, 0, 0),
                                convertToY(0, 0, valueRange, yStop - yStart, 0, yStart))

            bezeir2 = bezeir1


            bezeir3 = New Point(Math.Ceiling(convertToX(xStop - xStart, xStart, 0, maxValue)),
                                Math.Ceiling(convertToY(maxValue, 0, valueRange, yStop - yStart, 0, yStart)))

            bezeir4 = bezeir3

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupScreen()
        Try

            Dim tempStartY As Integer = rand(maxValue, minValue)

            bezeir1 = New Point(convertToX(xStop - xStart, xStart, 0, 0),
                                convertToY(0, 0, valueRange, yStop - yStart, 0, yStart))

            bezeir2 = New Point(convertToX(xStop - xStart, xStart, 0, rand(maxValue - 1, minValue)),
                                convertToY(rand(tempStartY, minValue), 0, valueRange, yStop - yStart, 0, yStart))


            Do

                bezeir3 = New Point(convertToX(xStop - xStart, xStart, 0, rand(maxValue - 1, minValue)),
                                convertToY(rand(tempStartY, minValue), 0, valueRange, yStop - yStart, 0, yStart))
            Loop While bezeir2 = bezeir3

            Do
                bezeir4 = New Point(convertToX(xStop - xStart, xStart, 0, maxValue),
                                convertToY(tempStartY, 0, valueRange, yStop - yStart, 0, yStart))
            Loop While bezeir2 = bezeir4 Or bezeir3 = bezeir4

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupScreen2()
        Try
            pnlLeft.Visible = False
            pnlAreYouSure.Visible = False
            lblMayLoseMoney.Visible = False

            Select Case periodType(currentPeriod)
                Case "Slow English"
                    txtBid.ReadOnly = True
                    txtBid.Text = "0.00"
                    cmdSubmitFirst.Text = "Do Not Buy"
                    cmdSubmitFirst.Visible = True
                    cmdSubmitFirst.BackColor = Color.FromArgb(255, 192, 192)
                Case "Slow Dutch"
                    txtBid.ReadOnly = True
                    txtBid.Text = Format(valueRange, "0.00")
                    cmdSubmitFirst.Text = "Buy"
                    cmdSubmitFirst.Visible = True
                    cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                Case "Slow First Price"
                    txtBid.ReadOnly = False
                    cmdSubmitFirst.Text = "Submit"
                    cmdSubmitFirst.Visible = True
                    cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                Case "Slow Second Price"
                    txtBid.ReadOnly = False
                    cmdSubmitFirst.Text = "Submit"
                    cmdSubmitFirst.Visible = True
                    cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                Case "Fast English"
                    txtBid.ReadOnly = True
                    cmdSubmitFirst.Visible = False
                    cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                    cmdSubmitFirst.Text = "Submit"
                Case "Fast Dutch"
                    txtBid.ReadOnly = True
                    cmdSubmitFirst.Visible = False
                    cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                    cmdSubmitFirst.Text = "Submit"
                Case "Fast First Price"
                    txtBid.ReadOnly = True
                    cmdSubmitFirst.Text = "Submit"
                Case "Fast Second Price"
                    txtBid.ReadOnly = True
                    cmdSubmitFirst.Text = "Submit"
            End Select




        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupScreen3()
        Try

            Select Case periodType(currentPeriod)
                Case "Slow English"
                    txtBid.ReadOnly = True
                Case "Slow Dutch"
                    txtBid.ReadOnly = True
                Case "Slow First Price"
                    txtBid.ReadOnly = False
                    cmdSubmitFirst.Text = "Submit"
                Case "Slow Second Price"
                    txtBid.ReadOnly = False
                    cmdSubmitFirst.Text = "Submit"
                Case "Fast English"
                    txtBid.ReadOnly = True
                    cmdSubmitFirst.Visible = False
                Case "Fast Dutch"
                    txtBid.ReadOnly = True
                    cmdSubmitFirst.Visible = False
                Case "Fast First Price"
                    txtBid.ReadOnly = True
                Case "Fast Second Price"
                    txtBid.ReadOnly = True
            End Select
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub checkChangeOfRegime()
        Try
            If InStr(periodType(currentPeriod), "Slow") > 0 Then
                valuePoint = New PointF(-1, -1)
            Else
                setupValuePoint()
            End If

            currentClockPrice = -1

            If (InStr(periodType(currentPeriod), "English") Or InStr(periodType(currentPeriod), "Dutch")) And Not showInstructions Then
                If currentPeriod > 1 Then
                    If periodType(currentPeriod - 1) <> periodType(currentPeriod) Then
                        cmdSubmitFirst.Visible = True
                        cmdSubmitFirst.Text = "Ready"
                        Color.FromArgb(192, 255, 192)
                    End If
                Else
                    cmdSubmitFirst.Visible = True
                    cmdSubmitFirst.Text = "Ready"
                    Color.FromArgb(192, 255, 192)
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupValuePoint()
        Try
            valuePoint = getValuePoint()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Function convertToY(ByVal p As Double, ByVal graphMin As Integer, ByVal graphMax As Integer,
                        ByVal tempHeight As Integer, ByVal markerWidth As Integer, ByVal yOffset As Integer) As Double
        Try

            Dim tempD As Double

            If p > graphMax Then p = graphMax 'check off scale high

            tempD = p - graphMin

            tempD = tempD / (graphMax - graphMin)
            tempD = tempHeight * (1 - tempD) + yOffset

            Return tempD - markerWidth / 2  'adjust for width of marker

        Catch ex As Exception
            appEventLog_Write("error convertY:", ex)
            Return 0
        End Try
    End Function

    Public Function convertFromY(ByVal p As Double, ByVal graphMin As Integer, ByVal graphMax As Integer,
                        ByVal tempHeight As Integer, ByVal markerWidth As Integer, ByVal yOffset As Integer) As Double
        Try

            Dim tempD As Double

            tempD = (-2 * p * graphMax + 2 * p * graphMin - graphMax * markerWidth + graphMin * markerWidth + 2 * graphMax * tempHeight + 2 * graphMax * yOffset - 2 * graphMin * yOffset) / (2 * tempHeight)

            Return tempD

        Catch ex As Exception
            appEventLog_Write("error convertY:", ex)
            Return 0
        End Try
    End Function

    Public Function convertToX(ByVal tempWidth As Integer, ByVal xOffest As Integer, ByVal markerWidth As Integer, tempValue As Double) As Double
        Try

            Dim tempT As Double = CDbl(tempWidth) / CDbl(maxValue)
            Dim tempV As Double = tempValue

            Return (tempT * tempV + CDbl(xOffest) - CDbl(markerWidth) / 2)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Function convertFromX(ByVal tempWidth As Integer, ByVal xOffest As Integer, ByVal markerWidth As Integer, tempValue As Double) As Double
        Try

            Return (maxValue * (2 * tempValue + markerWidth - 2 * xOffest)) / (2 * tempWidth)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function


    Dim controlPointTargetNudge As Integer = -1
    Dim fudgeFactor As Integer = 10
    Private Sub pnlRight_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlRight.MouseDown
        Try

            If InStr(periodType(currentPeriod), "Slow") > 0 Then Exit Sub

            If isOverControlPoint(New Rectangle(bezeir2.X - controlPointWidth / 2 - fudgeFactor / 2,
                                                bezeir2.Y - controlPointWidth / 2 - fudgeFactor / 2,
                                                controlPointWidth + fudgeFactor,
                                                controlPointWidth + fudgeFactor), e.Location) Then
                controlPointTarget = 2
                controlPointTargetNudge = 2

                Cursor = Cursors.SizeAll

                If My.Forms.frmInstructions.Visible Then
                    My.Forms.frmInstructions.movedPoints(2) = True

                    My.Forms.frmInstructions.pagesDone(7) = True
                    For i As Integer = 2 To 4
                        If Not My.Forms.frmInstructions.movedPoints(i) Then My.Forms.frmInstructions.pagesDone(7) = False
                    Next
                End If

            ElseIf isOverControlPoint(New Rectangle(bezeir3.X - controlPointWidth / 2 - fudgeFactor / 2,
                                                    bezeir3.Y - controlPointWidth / 2 - fudgeFactor / 2,
                                                    controlPointWidth + fudgeFactor,
                                                    controlPointWidth + fudgeFactor), e.Location) Then
                controlPointTarget = 3
                controlPointTargetNudge = 3

                Cursor = Cursors.SizeAll

                If My.Forms.frmInstructions.Visible Then
                    My.Forms.frmInstructions.movedPoints(3) = True

                    My.Forms.frmInstructions.pagesDone(7) = True
                    For i As Integer = 2 To 4
                        If Not My.Forms.frmInstructions.movedPoints(i) Then My.Forms.frmInstructions.pagesDone(7) = False
                    Next
                End If

            ElseIf isOverControlPoint(New Rectangle(bezeir4.X - controlPointWidth / 2 - fudgeFactor / 2,
                                                             bezeir4.Y - controlPointWidth / 2 - fudgeFactor / 2,
                                                             controlPointWidth + fudgeFactor,
                                                             controlPointWidth + fudgeFactor), e.Location) Then
                controlPointTarget = 4
                controlPointTargetNudge = 4

                Cursor = Cursors.SizeNS

                If My.Forms.frmInstructions.Visible Then
                    My.Forms.frmInstructions.movedPoints(4) = True

                    My.Forms.frmInstructions.pagesDone(7) = True
                    For i As Integer = 2 To 4
                        If Not My.Forms.frmInstructions.movedPoints(i) Then My.Forms.frmInstructions.pagesDone(7) = False
                    Next
                End If
            Else
                controlPointTarget = -1
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub pnlRight_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlRight.MouseUp
        Try
            controlPointTarget = -1
            Cursor = Cursors.Default
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub pnlRight_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlRight.MouseMove
        Try
            ' If disableScreen Then Exit Sub
            doMouseMove(e.Location)

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub doMouseMove(pt As Point)
        Try

            'closest point on curve to mouse
            '  closePoint = getclosestPoint(pt)

            Dim p As PointF
            p = pt

            Dim tempYStart As Double = Math.Round(convertToY(maxValue, 0, valueRange, yStop - yStart, 0, yStart), 6)

            If p.X < xStart Then p.X = xStart
            If p.X > xStop Then p.X = xStop

            If p.Y < tempYStart Then p.Y = tempYStart
            If p.Y > yStop Then p.Y = yStop

            If controlPointTarget = -1 Then
                Exit Sub
            ElseIf controlPointTarget = 2 Then
                bezeir2 = p
            ElseIf controlPointTarget = 3 Then
                bezeir3 = p
            ElseIf controlPointTarget = 4 Then
                bezeir4.Y = p.Y
            End If

            'control point must be less than end point
            If bezeir2.Y < bezeir4.Y Then bezeir2.Y = bezeir4.Y
            If bezeir3.Y < bezeir4.Y Then bezeir3.Y = bezeir4.Y

            valuePoint = getValuePoint()

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Function isOverControlPoint(rect As Rectangle, pt As Point) As Boolean
        Try

            If rect.X <= pt.X And rect.X + rect.Width >= pt.X And
               rect.Y <= pt.Y And rect.Y + rect.Height >= pt.Y Then

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Function

    Public Function getBezierPoint(t As Double) As PointF
        Try
            Dim pt As New PointF

            pt.X = (1 - t) ^ 3 * bezeir1.X + 3 * (1 - t) ^ 2 * t * bezeir2.X + 3 * (1 - t) * t ^ 2 * bezeir3.X + t ^ 3 * bezeir4.X
            pt.Y = (1 - t) ^ 3 * bezeir1.Y + 3 * (1 - t) ^ 2 * t * bezeir2.Y + 3 * (1 - t) * t ^ 2 * bezeir3.Y + t ^ 3 * bezeir4.Y

            Return pt
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
            Return New PointF(0, 0)
        End Try
    End Function

    Public Function getclosestPoint(mousePt As Point) As PointF
        Try
            Dim tempD As Double = 1000
            Dim pt As New PointF(-1, -1)


            'If mousePt.X >= xStart And mousePt.X <= xStop And mousePt.Y >= yStart And mousePt.Y <= yStop Then
            '    Dim tempT As Double = GetBezierT(mousePt.X)

            '    If Not Double.IsNaN(tempT) Then
            '        pt = getBezierPoint(tempT)

            '        If GetDistance(pt, mousePt) > 20 Then
            '            pt = New Point(-1, -1)
            '        End If
            '    End If
            'End If

            Dim tempPt As PointF
            Dim tempD2 As Double
            For i As Double = 0 To 1000
                tempPt = getBezierPoint(i / 1000)
                tempD2 = GetDistance(mousePt, tempPt)
                If tempD2 < tempD And tempD2 <= 15 Then
                    pt = tempPt
                    tempD = GetDistance(mousePt, tempPt)
                End If
            Next

            Return pt
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
            Return New PointF(0, 0)
        End Try
    End Function

    Public Function getValuePoint() As PointF
        Try
            Dim pt As New PointF

            Dim tempT As Double = GetBezierT(values(currentPeriod))

            pt = getBezierPoint(tempT)

            Return pt
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return New PointF(0, 0)
        End Try
    End Function

    Public Function GetDistance(ByVal startPoint As PointF, ByVal endPoint As PointF) As Integer
        Return Math.Sqrt((Math.Abs(endPoint.X - startPoint.X) ^ 2) +
                         (Math.Abs(endPoint.Y - startPoint.Y) ^ 2))
    End Function

    Public Function GetBezierT(X As Double) As Double

        Dim x1 As Double = bezeir1.X
        Dim x2 As Double = bezeir2.X
        Dim x3 As Double = bezeir3.X
        Dim x4 As Double = bezeir4.X

        'Dim tempD As Double  '-((x1 - 2 * x2 + x3) / (-x1 + 3 * x2 - 3 * x3 + x4)) - (2 ^ (1 / 3) * (-9 * x2 ^ 2 + 9 * x1 * x3 + 9 * x2 * x3 - 9 * x3 ^ 2 - 9 * x1 * x4 + 9 * x2 * x4)) / (3 * (-x1 + 3 * x2 - 3 * x3 + x4) * (27 * X * x1 ^ 2 - 162 * X * x1 * x2 + 243 * X * x2 ^ 2 - 54 * x2 ^ 3 + 162 * X * x1 * x3 - 486 * X * x2 * x3 + 81 * x1 * x2 * x3 + 81 * x2 ^ 2 * x3 + 243 * X * x3 ^ 2 - 162 * x1 * x3 ^ 2 + 81 * x2 * x3 ^ 2 - 54 * x3 ^ 3 - 54 * X * x1 * x4 - 27 * x1 ^ 2 * x4 + 162 * X * x2 * x4 + 81 * x1 * x2 * x4 - 162 * x2 ^ 2 * x4 - 162 * X * x3 * x4 + 81 * x1 * x3 * x4 + 81 * x2 * x3 * x4 + 27 * X * x4 ^ 2 - 27 * x1 * x4 ^ 2 + Math.Sqrt(4 * (-9 * x2 ^ 2 + 9 * x1 * x3 + 9 * x2 * x3 - 9 * x3 ^ 2 - 9 * x1 * x4 + 9 * x2 * x4) ^ 3 + (27 * X * x1 ^ 2 - 162 * X * x1 * x2 + 243 * X * x2 ^ 2 - 54 * x2 ^ 3 + 162 * X * x1 * x3 - 486 * X * x2 * x3 + 81 * x1 * x2 * x3 + 81 * x2 ^ 2 * x3 + 243 * X * x3 ^ 2 - 162 * x1 * x3 ^ 2 + 81 * x2 * x3 ^ 2 - 54 * x3 ^ 3 - 54 * X * x1 * x4 - 27 * x1 ^ 2 * x4 + 162 * X * x2 * x4 + 81 * x1 * x2 * x4 - 162 * x2 ^ 2 * x4 - 162 * X * x3 * x4 + 81 * x1 * x3 * x4 + 81 * x2 * x3 * x4 + 27 * X * x4 ^ 2 - 27 * x1 * x4 ^ 2) ^ 2)) ^ (1 / 3)) + (27 * X * x1 ^ 2 - 162 * X * x1 * x2 + 243 * X * x2 ^ 2 - 54 * x2 ^ 3 + 162 * X * x1 * x3 - 486 * X * x2 * x3 + 81 * x1 * x2 * x3 + 81 * x2 ^ 2 * x3 + 243 * X * x3 ^ 2 - 162 * x1 * x3 ^ 2 + 81 * x2 * x3 ^ 2 - 54 * x3 ^ 3 - 54 * X * x1 * x4 - 27 * x1 ^ 2 * x4 + 162 * X * x2 * x4 + 81 * x1 * x2 * x4 - 162 * x2 ^ 2 * x4 - 162 * X * x3 * x4 + 81 * x1 * x3 * x4 + 81 * x2 * x3 * x4 + 27 * X * x4 ^ 2 - 27 * x1 * x4 ^ 2 + Math.Sqrt(4 * (-9 * x2 ^ 2 + 9 * x1 * x3 + 9 * x2 * x3 - 9 * x3 ^ 2 - 9 * x1 * x4 + 9 * x2 * x4) ^ 3 + (27 * X * x1 ^ 2 - 162 * X * x1 * x2 + 243 * X * x2 ^ 2 - 54 * x2 ^ 3 + 162 * X * x1 * x3 - 486 * X * x2 * x3 + 81 * x1 * x2 * x3 + 81 * x2 ^ 2 * x3 + 243 * X * x3 ^ 2 - 162 * x1 * x3 ^ 2 + 81 * x2 * x3 ^ 2 - 54 * x3 ^ 3 - 54 * X * x1 * x4 - 27 * x1 ^ 2 * x4 + 162 * X * x2 * x4 + 81 * x1 * x2 * x4 - 162 * x2 ^ 2 * x4 - 162 * X * x3 * x4 + 81 * x1 * x3 * x4 + 81 * x2 * x3 * x4 + 27 * X * x4 ^ 2 - 27 * x1 * x4 ^ 2) ^ 2)) ^ (1 / 3) / (3 * 2 ^ (1 / 3) * (-x1 + 3 * x2 - 3 * x3 + x4))

        'tempD = (x1 - 2 * x2 + x3) / (x1 - 3 * x2 + 3 * x3 - x4) - (2 ^ (1 / 3) * (-9 * x2 ^ 2 + 9 * x1 * x3 + 9 * x2 * x3 - 9 * x3 ^ 2 - 9 * x1 * x4 + 9 * x2 * x4)) / (3 * (x1 - 3 * x2 + 3 * x3 - x4) * (-27 * X * x1 ^ 2 + 162 * X * x1 * x2 - 243 * X * x2 ^ 2 + 54 * x2 ^ 3 - 162 * X * x1 * x3 + 486 * X * x2 * x3 - 81 * x1 * x2 * x3 - 81 * x2 ^ 2 * x3 - 243 * X * x3 ^ 2 + 162 * x1 * x3 ^ 2 - 81 * x2 * x3 ^ 2 + 54 * x3 ^ 3 + 54 * X * x1 * x4 + 27 * x1 ^ 2 * x4 - 162 * X * x2 * x4 - 81 * x1 * x2 * x4 + 162 * x2 ^ 2 * x4 + 162 * X * x3 * x4 - 81 * x1 * x3 * x4 - 81 * x2 * x3 * x4 - 27 * X * x4 ^ 2 + 27 * x1 * x4 ^ 2 + Math.Sqrt(4 * (-9 * x2 ^ 2 + 9 * x1 * x3 + 9 * x2 * x3 - 9 * x3 ^ 2 - 9 * x1 * x4 + 9 * x2 * x4) ^ 3 + (-27 * X * x1 ^ 2 + 162 * X * x1 * x2 - 243 * X * x2 ^ 2 + 54 * x2 ^ 3 - 162 * X * x1 * x3 + 486 * X * x2 * x3 - 81 * x1 * x2 * x3 - 81 * x2 ^ 2 * x3 - 243 * X * x3 ^ 2 + 162 * x1 * x3 ^ 2 - 81 * x2 * x3 ^ 2 + 54 * x3 ^ 3 + 54 * X * x1 * x4 + 27 * x1 ^ 2 * x4 - 162 * X * x2 * x4 - 81 * x1 * x2 * x4 + 162 * x2 ^ 2 * x4 + 162 * X * x3 * x4 - 81 * x1 * x3 * x4 - 81 * x2 * x3 * x4 - 27 * X * x4 ^ 2 + 27 * x1 * x4 ^ 2) ^ 2)) ^ (1 / 3)) + (-27 * X * x1 ^ 2 + 162 * X * x1 * x2 - 243 * X * x2 ^ 2 + 54 * x2 ^ 3 - 162 * X * x1 * x3 + 486 * X * x2 * x3 - 81 * x1 * x2 * x3 - 81 * x2 ^ 2 * x3 - 243 * X * x3 ^ 2 + 162 * x1 * x3 ^ 2 - 81 * x2 * x3 ^ 2 + 54 * x3 ^ 3 + 54 * X * x1 * x4 + 27 * x1 ^ 2 * x4 - 162 * X * x2 * x4 - 81 * x1 * x2 * x4 + 162 * x2 ^ 2 * x4 + 162 * X * x3 * x4 - 81 * x1 * x3 * x4 - 81 * x2 * x3 * x4 - 27 * X * x4 ^ 2 + 27 * x1 * x4 ^ 2 + Math.Sqrt(4 * (-9 * x2 ^ 2 + 9 * x1 * x3 + 9 * x2 * x3 - 9 * x3 ^ 2 - 9 * x1 * x4 + 9 * x2 * x4) ^ 3 + (-27 * X * x1 ^ 2 + 162 * X * x1 * x2 - 243 * X * x2 ^ 2 + 54 * x2 ^ 3 - 162 * X * x1 * x3 + 486 * X * x2 * x3 - 81 * x1 * x2 * x3 - 81 * x2 ^ 2 * x3 - 243 * X * x3 ^ 2 + 162 * x1 * x3 ^ 2 - 81 * x2 * x3 ^ 2 + 54 * x3 ^ 3 + 54 * X * x1 * x4 + 27 * x1 ^ 2 * x4 - 162 * X * x2 * x4 - 81 * x1 * x2 * x4 + 162 * x2 ^ 2 * x4 + 162 * X * x3 * x4 - 81 * x1 * x3 * x4 - 81 * x2 * x3 * x4 - 27 * X * x4 ^ 2 + 27 * x1 * x4 ^ 2) ^ 2)) ^ (1 / 3) / (3 * 2 ^ (1 / 3) * (x1 - 3 * x2 + 3 * x3 - x4))
        ' tempD = -x1 + (3 * x1 - 3 * x2) * X + (-3 * x1 + 6 * x2 - 3 * x3) * X ^ 2 + (x1 - 3 * x2 + 3 * x3 - x4) * X ^ 3

        ' tempD = (4 * x2 - 2 * x3 + (2 * 2 ^ (1 / 3) * (x2 ^ 2 + x3 ^ 2 - x2 * (x3 + x4))) / (X * (3 * x2 - 3 * x3 + x4) ^ 2 - (2 * x2 - x3) * (x2 ^ 2 - x2 * x3 - 2 * x3 ^ 2 + 3 * x2 * x4) + Math.Sqrt(X ^ 2 * (3 * x2 - 3 * x3 + x4) ^ 2 - 2 * X * (2 * x2 - x3) * (x2 ^ 2 - x2 * x3 - 2 * x3 ^ 2 + 3 * x2 * x4) + x2 ^ 2 * (-3 * x3 ^ 2 + 4 * x2 * x4)) * Math.Abs(3 * x2 - 3 * x3 + x4)) ^ (1 / 3) + 2 ^ (2 / 3) * (X * (3 * x2 - 3 * x3 + x4) ^ 2 - (2 * x2 - x3) * (x2 ^ 2 - x2 * x3 - 2 * x3 ^ 2 + 3 * x2 * x4) + Math.Sqrt(X ^ 2 * (3 * x2 - 3 * x3 + x4) ^ 2 - 2 * X * (2 * x2 - x3) * (x2 ^ 2 - x2 * x3 - 2 * x3 ^ 2 + 3 * x2 * x4) + x2 ^ 2 * (-3 * x3 ^ 2 + 4 * x2 * x4)) * Math.Abs(3 * x2 - 3 * x3 + x4)) ^ (1 / 3)) / (2 * (3 * x2 - 3 * x3 + x4))
        'If Double.IsNaN(tempD) Or tempD > 1 Or tempD < 0 Then
        '    tempD = (-x1 + (3 * x1 - 3 * x2) * X + (-3 * x1 + 6 * x2 - 3 * x3) * X ^ 2 + (x1 - 3 * x2 + 3 * x3 - x4) * X ^ 3) ^ (1 / 2)
        'End If

        'If Double.IsNaN(tempD) Or tempD > 1 Or tempD < 0 Then
        '    tempD = (-x1 + (3 * x1 - 3 * x2) * X + (-3 * x1 + 6 * x2 - 3 * x3) * X ^ 2 + (x1 - 3 * x2 + 3 * x3 - x4) * X ^ 3) ^ (1 / 3)
        'End If

        'iterative method
        Dim tempT As Double = 0.5
        Dim tempStepSize As Double = 0.5
        Dim tempStab As Double = (1 - tempT) ^ 3 * x1 + 3 * (1 - tempT) ^ 2 * tempT * x2 + 3 * (1 - tempT) * tempT ^ 2 * x3 + tempT ^ 3 * x4

        Dim tempCount As Double = 0
        Dim tempXPoint As Double = convertToX(xStop - xStart, xStart, 0, X)
        tempXPoint = Math.Round(tempXPoint, 7)

        While (Math.Round(tempStab, 7) <> tempXPoint)
            tempStepSize /= 2

            If tempStab > tempXPoint Then
                tempT -= tempStepSize
            Else
                tempT += tempStepSize
            End If

            tempStab = (1 - tempT) ^ 3 * x1 + 3 * (1 - tempT) ^ 2 * tempT * x2 + 3 * (1 - tempT) * tempT ^ 2 * x3 + tempT ^ 3 * x4

            If tempCount > 1000 Then
                Exit While
            End If
            tempCount += 1
        End While

        Return tempT
    End Function

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try

            cmdSubmitAction()

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub cmdSubmitAction()
        Try

            If showInstructions Then Exit Sub

            Dim str As String = ""

            If showInstructions Then

            Else
                If cmdSubmitFirst.Text = "Ready" Then
                    cmdSubmitFirst.Visible = False

                    frmClient.AC.sendMessage("03", str)
                ElseIf cmdSubmitFirst.Text <> "Ready To Go On" Then

                    If txtBid.Text = "" Then Exit Sub



                    sendBid(CDbl(txtBid.Text))

                Else
                    cmdSubmitFirst.Visible = False

                    str &= getBezierString()

                    frmClient.AC.sendMessage("02", str)
                End If
            End If

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub sendBid(bid As Double)
        Try
            Dim str As String = ""

            cmdSubmitFirst.Visible = False
            pnlAreYouSure.Visible = False
            txtBid.ReadOnly = True
            lblMayLoseMoney.Visible = False
            disableScreen = True

            str &= bid & ";"
            str &= getBezierString()

            If InStr(periodType(currentPeriod), "Dutch") > 0 Then
                exitTimer2 = True
            End If

            frmClient.AC.sendMessage("01", Str)
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Function getBezierString() As String
        Try
            Dim str As String = "-1;-1;-1;-1;-1;-1;-1;-1;-1;"

            If InStr(periodType(currentPeriod), "Fast") > 0 Then

                'grid condinates
                str = Math.Round(convertFromX(xStop - xStart, xStart, 0, bezeir1.X), 2) & ";"
                str &= Math.Round(convertFromY(bezeir1.Y, 0, valueRange, yStop - yStart, 0, yStart), 2) & ";"

                str &= Math.Round(convertFromX(xStop - xStart, xStart, 0, bezeir2.X), 2) & ";"
                str &= Math.Round(convertFromY(bezeir2.Y, 0, valueRange, yStop - yStart, 0, yStart), 2) & ";"

                str &= Math.Round(convertFromX(xStop - xStart, xStart, 0, bezeir3.X), 2) & ";"
                str &= Math.Round(convertFromY(bezeir3.Y, 0, valueRange, yStop - yStart, 0, yStart), 2) & ";"

                str &= Math.Round(convertFromX(xStop - xStart, xStart, 0, bezeir4.X), 2) & ";"
                str &= Math.Round(convertFromY(bezeir4.Y, 0, valueRange, yStop - yStart, 0, yStart), 2) & ";"

                str &= txtBid.Text & ";"

            End If

            Return str
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
            Return ""
        End Try
    End Function

    Private Sub txtBid_TextChanged(sender As Object, e As EventArgs) Handles txtBid.TextChanged
        Try
            If InStr(periodType(currentPeriod), "Fast") > 0 Then
                Exit Sub
            End If

            If txtBid.Text = "" Then
                valuePoint = New PointF(-1, -1)
                lblMayLoseMoney.Visible = False
                Exit Sub
            End If

            If Not validateInt(txtBid.Text, 5, True, False) Then
                txtBid.Text = ""
                valuePoint = New PointF(-1, -1)
            Else
                If CDbl(txtBid.Text) > valueRange Then
                    txtBid.Text = ""
                    valuePoint = New PointF(-1, -1)
                Else
                    valuePoint = New PointF(convertToX(xStop - xStart, xStart, 0, values(currentPeriod)),
                                      convertToY(CDbl(txtBid.Text), 0, valueRange, yStop - yStart, 0, yStart))
                End If
            End If

            showHideLoseMoney()

            Me.AcceptButton = cmdSubmitFirst
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub showHideLoseMoney()
        Try
            If txtBid.Text <> "" Then

                If (periodType(currentPeriod) = "Slow English" And cmdSubmitFirst.Visible) Or
                   periodType(currentPeriod) = "Fast English" Or
                   pnlAreYouSure.Visible Then

                    If CDbl(txtBid.Text) > values(currentPeriod) Then

                        lblMayLoseMoney.Visible = True
                        refreshLblMayLoseMoney()
                    Else
                        lblMayLoseMoney.Visible = False
                    End If
                End If
            Else
                lblMayLoseMoney.Visible = False
            End If
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try

            '    If cmdSubmit.Visible = False Then Exit Sub
            Timer2.Enabled = False
            cmdSubmitAction()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdSubmitFirst_Click(sender As Object, e As EventArgs) Handles cmdSubmitFirst.Click
        Try

            If cmdSubmitFirst.Text = "Ready To Go On" Then

                If showInstructions Then
                    cmdSubmitFirst.Visible = False
                Else
                    cmdSubmitAction()
                End If

            ElseIf cmdSubmitFirst.Text = "Ready" Then
                cmdSubmitAction()
            ElseIf InStr(periodType(currentPeriod), "English") Or InStr(periodType(currentPeriod), "Fast") Then
                cmdSubmitAction()
            Else
                If txtBid.Text = "" Then Exit Sub

                'check min bid
                If CDbl(txtBid.Text) < periodMinBid(currentPeriod) Then
                    lblMayLoseMoney.Visible = True
                    lblMayLoseMoney.ForeColor = Color.Crimson
                    If InStr(periodType(currentPeriod), "English") Or InStr(periodType(currentPeriod), "Dutch") Then
                        lblMayLoseMoney.Text = "You cannot buy below " & Format(periodMinBid(currentPeriod), "0.00") & "."
                    Else
                        lblMayLoseMoney.Text = "You cannot bid below " & Format(periodMinBid(currentPeriod), "0.00") & "."
                    End If

                    Exit Sub
                End If

                pnlAreYouSure.Visible = True
                cmdSubmitFirst.Visible = False
                txtBid.ReadOnly = True
                Me.AcceptButton = cmdSubmit

                showHideLoseMoney()

                If InStr(periodType(currentPeriod), "Fast") > 0 Then
                    disableScreen = True
                End If
            End If



        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdNo_Click(sender As Object, e As EventArgs) Handles cmdNo.Click
        Try
            pnlAreYouSure.Visible = False
            setupScreen3()
            cmdSubmitFirst.Visible = True
            lblMayLoseMoney.Visible = False

            If InStr(periodType(currentPeriod), "Fast") > 0 Then
                disableScreen = False
            End If
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub refreshLblMayLoseMoney()
        Try
            If cmdSubmitFirst.Text = "Ready To Go On" Then
                lblMayLoseMoney.Visible = True
                lblMayLoseMoney.ForeColor = Color.Black

                If bids(currentPeriod).won Then
                    lblMayLoseMoney.Text = vbCrLf & "You won the auction."
                Else
                    lblMayLoseMoney.Text = vbCrLf & "You did not win the auction."
                End If
            Else
                lblMayLoseMoney.ForeColor = Color.Crimson

                If txtBid.Text = "" Then
                    lblMayLoseMoney.Text = ""
                    Exit Sub
                End If

                Dim tempP As Double = values(currentPeriod) - CDbl(txtBid.Text)

                tempP = Math.Abs(tempP)

                If InStr(periodType(currentPeriod), "English") > 0 Then
                    lblMayLoseMoney.Text = "You could lose " & Format(tempP, "0.00") & " dollars if you do not exit the auction."
                ElseIf InStr(periodType(currentPeriod), "Dutch") > 0 Or InStr(periodType(currentPeriod), "First") > 0 Then
                    lblMayLoseMoney.Text = "You will lose " & Format(tempP, "0.00") & " dollars if you buy at this price."
                ElseIf InStr(periodType(currentPeriod), "Dutch") > 0 Or InStr(periodType(currentPeriod), "Second") > 0 Then
                    lblMayLoseMoney.Text = "You could lose up " & Format(tempP, "0.00") & " dollars if you win the auction at this price."
                End If
            End If


        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub frmRealTime_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True Then
            If CInt(e.KeyValue) = CInt(Keys.K) Then
                If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                closeClient()
            ElseIf CInt(e.KeyValue) = CInt(Keys.Q) Then
                frmConnect.Show()
            End If
        End If
    End Sub

    'Dim tempKey As Keys

    'Private Sub frmRealTime_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    '    Try
    '        Timer2.Enabled = False

    '    Catch ex As Exception
    '        appEventLog_Write("Error :", ex)
    '    End Try
    'End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    Try
    '        If controlPointTargetNudge = -1 Then Exit Sub

    '        If tempKey = Keys.Up Then
    '            If controlPointTargetNudge = 2 Then
    '                bezeir2.Y -= 0.1
    '            ElseIf controlPointTargetNudge = 3 Then
    '                bezeir3.Y -= 0.1
    '            ElseIf controlPointTargetNudge = 4 Then
    '                bezeir4.Y -= 0.1
    '            End If
    '        ElseIf tempKey = Keys.Down Then
    '            If controlPointTargetNudge = 2 Then
    '                bezeir2.Y += 0.1
    '            ElseIf controlPointTargetNudge = 3 Then
    '                bezeir2.Y += 0.1
    '            ElseIf controlPointTargetNudge = 4 Then
    '                bezeir3.Y += 0.1
    '            End If
    '        ElseIf tempKey = Keys.Left Then
    '            If controlPointTargetNudge = 2 Then
    '                bezeir2.X -= 0.1
    '            ElseIf controlPointTargetNudge = 3 Then
    '                bezeir3.X -= 0.1
    '            ElseIf controlPointTargetNudge = 4 Then
    '                Exit Sub
    '            End If
    '        ElseIf tempKey = Keys.Right Then
    '            If controlPointTargetNudge = 2 Then
    '                bezeir2.X += 0.1
    '            ElseIf controlPointTargetNudge = 3 Then
    '                bezeir3.X += 0.1
    '            ElseIf controlPointTargetNudge = 4 Then
    '                Exit Sub
    '            End If
    '        End If

    '        If bezeir2.X > xStop Then bezeir2.X = xStop
    '        If bezeir3.X > xStop Then bezeir3.X = xStop
    '        If bezeir4.X > xStop Then bezeir4.X = xStop

    '        If bezeir2.X < xStart Then bezeir2.X = xStart
    '        If bezeir3.X < xStart Then bezeir3.X = xStart
    '        If bezeir4.X < xStart Then bezeir4.X = xStart

    '        If bezeir2.Y > yStop Then bezeir2.Y = yStop
    '        If bezeir3.Y > yStop Then bezeir3.Y = yStop
    '        If bezeir4.Y > yStop Then bezeir4.Y = yStop

    '        If bezeir2.Y < yStart Then bezeir2.Y = yStart
    '        If bezeir3.Y < yStart Then bezeir3.Y = yStart
    '        If bezeir4.Y < yStart Then bezeir4.Y = yStart

    '        'control point must be less than end point
    '        If bezeir2.Y < bezeir4.Y Then bezeir2.Y = bezeir4.Y
    '        If bezeir3.Y < bezeir4.Y Then bezeir3.Y = bezeir4.Y

    '        valuePoint = getValuePoint()

    '    Catch ex As Exception
    '        appEventLog_Write("Error :", ex)
    '    End Try
    'End Sub

    'Private Sub frmRealTime_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
    '            tempKey = e.KeyCode
    '            Timer2.Enabled = True
    '        End If
    '    Catch ex As Exception
    '        appEventLog_Write("Error :", ex)
    '    End Try
    'End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keydata As Keys) As Boolean

    '    If keydata = Keys.Right Or keydata = Keys.Left Or keydata = Keys.Up Or keydata = Keys.Down Then
    '        OnKeyDown(New KeyEventArgs(keydata))
    '        ProcessCmdKey = True
    '    Else
    '        ProcessCmdKey = MyBase.ProcessCmdKey(msg, keydata)
    '    End If
    'End Function

    Public Sub drawX(g As Graphics, p As Pen, centerPt As Point, width As Integer)
        Try
            g.DrawLine(p, centerPt.X - width, centerPt.Y - width, centerPt.X + width, centerPt.Y + width)
            g.DrawLine(p, centerPt.X + width, centerPt.Y - width, centerPt.X - width, centerPt.Y + width)
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Dim lastRun As Date = Now
    Public runCount As Double
    Public exitTimer2 As Boolean = False
    Public periodStartTime As Date
    Public priceE6 As TimeSpan
    Public doAfterComplete As String
    Public doAfterCompleteMsgtokens As String

    Dim tempClockSpeed As Integer
    Dim ts As TimeSpan
    Private Sub bwTimer2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwTimer2.DoWork
        Try
            'tempClockSpeed = 0

            If InStr(periodType(currentPeriod), "Fast") > 0 Then
                tempClockSpeed = fastClockSpeed
            Else
                tempClockSpeed = slowClockSpeed
            End If

            While Not exitTimer2

                ts = Now - periodStartTime

                If ts.TotalMilliseconds >= tempClockSpeed + runCount * tempClockSpeed Then

                    'lastRun = Now
                    'runCount += 1

                    Dim pulseCount As Integer = Math.Round((ts.TotalMilliseconds - (tempClockSpeed + runCount * tempClockSpeed)) / tempClockSpeed)

                    runCount += pulseCount

                    If pulseCount > 0 Then setTimer2(pulseCount)

                    If InStr(periodType(currentPeriod), "English") > 0 Then

                            If currentClockPrice >= valueRange Then
                                currentClockPrice = valueRange
                                exitTimer2 = True

                                If cmdSubmitFirst.Visible Or pnlAreYouSure.Visible Then
                                    setSendBid(valueRange + 1)
                                End If
                            End If
                        Else

                            If currentClockPrice <= periodMinBid(currentPeriod) Then
                                currentClockPrice = periodMinBid(currentPeriod)
                                exitTimer2 = True

                                If cmdSubmitFirst.Visible Or pnlAreYouSure.Visible Then
                                    setSendBid(-1)
                                End If
                            End If
                        End If
                    End If

                Threading.Thread.Sleep(5)
            End While
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub bwTimer2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTimer2.RunWorkerCompleted
        Try
            If Not exitTimer2 Then
                bwTimer2.RunWorkerAsync()
            ElseIf doAfterComplete = "periodResultsSlow" Then
                takePeriodResultsSlow2(doAfterCompleteMsgtokens)
            ElseIf doAfterComplete = "periodResultsFast" Then
                takePeriodResultsFast2(doAfterCompleteMsgtokens)
            End If

            doAfterComplete = ""
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Delegate Sub setSendBidCallback(text As Double)

    Public Sub setSendBid(ByVal text As Double)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If txtValue.InvokeRequired Then
            Dim d As New setSendBidCallback(AddressOf setSendBid)
            Me.Invoke(d, New Object() {text})
        Else
            sendBid(text)
        End If
    End Sub

    Delegate Sub setTimer2Callback(text As Integer)

    Public Sub setTimer2(ByVal text As Integer)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If txtValue.InvokeRequired Then
            Dim d As New setTimer2Callback(AddressOf setTimer2)
            Me.Invoke(d, New Object() {text})
        Else
            doTimer2(text)
        End If
    End Sub

    Public Sub doTimer2(pulseCount As Integer)
        Try
            If InStr(periodType(currentPeriod), "English") > 0 Then
                If InStr(periodType(currentPeriod), "Fast") > 0 Then
                    currentClockPrice += fastClockStep * pulseCount
                Else
                    currentClockPrice += slowClockStep * pulseCount
                End If

                If currentClockPrice > valueRange Then
                    currentClockPrice = valueRange
                End If
            Else
                If InStr(periodType(currentPeriod), "Fast") > 0 Then
                    currentClockPrice -= fastClockStep * pulseCount
                Else
                    currentClockPrice -= slowClockStep * pulseCount
                End If

                If currentClockPrice < 0 Then currentClockPrice = 0
            End If

            currentClockPrice = Math.Round(currentClockPrice, 2)

            If currentClockPrice = 6 Then
                priceE6 = Now - periodStartTime
            End If

            takeClockPriceUpdate(currentClockPrice & ";" & currentClockPrice & ";")
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub
End Class