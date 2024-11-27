
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frmMain
    ' Dim socketList(100) As synchronousSocketListener

    Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
    Dim ipAddress As IPAddress
    Dim localEndPoint As IPEndPoint

    ' Create a TCP/IP socket.
    Dim listener As New Socket(AddressFamily.InterNetwork,
                               SocketType.Stream,
                               ProtocolType.Tcp)

    'graph
    Public mainScreen As Screen
    Dim yScaleMax As Integer

    Public f16 As New Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Bold)
    Public f12 As New Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
    Public f10 As New Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
    Public f8 As New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold)
    Public f6 As New Font("Microsoft Sans Serif", 6, System.Drawing.FontStyle.Bold)

    Dim p1 As New Pen(Brushes.Black, 3)
    Dim p3_grey As New Pen(Brushes.DimGray, 3)
    Dim p1_greyDash As New Pen(Brushes.DimGray, 1)

    Dim p3_Blue As New Pen(Brushes.CornflowerBlue, 3)
    Dim p3_Black As New Pen(Brushes.Black, 3)
    Public p3_green As New Pen(Brushes.Green, 3)
    Public p3_red As New Pen(Brushes.Crimson, 3)

    Public fmt As New StringFormat 'center alignment
    Public fmt2 As New StringFormat 'right alignment

    Dim tempPathBidGreaterThanValue As New GraphicsPath

    Public xStart As Integer = 40
    Public xStop As Integer
    Public yStart As Integer = 20
    Public yStop As Integer

    Public resetPressed As Boolean = False

    Public timeOfLastRefresh As DateTime = Now

    'Public waitCounter As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i As Integer = 1 To ipHostInfo.AddressList.Count
            If ipHostInfo.AddressList(i - 1).ToString.IndexOf(".") > -1 Then
                ipAddress = ipHostInfo.AddressList(i - 1)

                Exit For
            End If
        Next

        localEndPoint = New IPEndPoint(IPAddress.Any, portNumber)

        listener.Bind(localEndPoint)
        listener.Listen(10)

        bwTakeSocketConnections.RunWorkerAsync()

        lblIpAddress.Text = ipAddress.ToString
        lblLocalHost.Text = SystemInformation.ComputerName
        lblConnectionCount.Text = "0"

        'setup graph
        mainScreen = New Screen(pnlBackGround, New Rectangle(0, 0, pnlBackGround.Width, pnlBackGround.Height))

        fmt.Alignment = StringAlignment.Center
        fmt2.Alignment = StringAlignment.Far

        setTriangleEndCap(p1)
        setTriangleEndCap(p3_grey)
        setTriangleEndCap(p3_green)
        setTriangleEndCap(p3_red)

        p1_greyDash.DashStyle = DashStyle.Dash



        xStop = pnlBackGround.Width - 10
        yStop = pnlBackGround.Height - 30

        'tempPathBidGreaterThanValue.AddLine(xStart, yStop, xStop, yStart)
        'tempPathBidGreaterThanValue.AddLine(xStop, yStart, xStart, yStart)
        'tempPathBidGreaterThanValue.AddLine(xStart, yStart, xStart, yStop)

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

    Private Sub bwTakeSocketConnections_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwTakeSocketConnections.DoWork
        Try
            Dim go As Boolean = True

            Do While go
                Dim tempSocket As Socket = listener.Accept

                clientCount += 1
                playerlist(clientCount) = New player

                playerlist(clientCount).sp.socketHandler = tempSocket

                playerlist(clientCount).sp.startReceive()

                AddHandler playerlist(clientCount).sp.messageReceived, AddressOf setTakeMessage

                playerlist(clientCount).inumber = clientCount
                playerlist(clientCount).sp.inumber = clientCount

                refreshConnectionsLabel()

                If cmdBegin.Enabled = False Then
                    playerlist(clientCount).sendInvalidConnection()
                    clientCount -= 1
                End If

                If resetPressed Then go = False
            Loop
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Private Sub bwTakeSocketConnections_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTakeSocketConnections.RunWorkerCompleted
        Try
            txtMain.Text = ""
            txtError.Text = ""

            resetPressed = False

            For i As Integer = 1 To clientCount
                playerlist(i).sp.stopping = True
                playerlist(i).sp = Nothing
            Next

            clientCount = 0

            listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            listener.Bind(localEndPoint)
            listener.Listen(10)

            bwTakeSocketConnections.RunWorkerAsync()
            refreshConnectionsLabel()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Delegate Sub setTakeMessageCallback(text() As String)

    Public Sub setTakeMessage(ByVal text() As String)

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

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        Try
            Timer1.Enabled = False
            'Timer2.Enabled = False

            resetPressed = True

            For i As Integer = 1 To clientCount
                playerlist(i).sendreset()
            Next

            bwTakeSocketConnections.CancelAsync()
            exitTimer2 = True


            listener.Close()

            If summaryDf IsNot Nothing Then summaryDf.Close()

            cmdBegin.Enabled = True
            cmdLoad.Enabled = True
            cmdExit.Enabled = True
            cmdExchange.Enabled = True

            cmdSetup1.Enabled = True
            cmdSetup2.Enabled = True
            cmdSetup3.Enabled = True
            cmdSetup4.Enabled = True
            cmdSetup5.Enabled = True

            cmdEndEarly.Enabled = False

            cmdReplay.Enabled = True

            frmReplay.Close()

            dgMain.RowCount = 0

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdBegin_Click(sender As Object, e As EventArgs) Handles cmdBegin.Click
        Try
            loadParameters()

            If numberOfPlayers <> clientCount Then
                Exit Sub
            End If

            'define timestamp for recording data
            tempTime = DateTime.Now.Month & "-" & DateTime.Now.Day & "-" & DateTime.Now.Year & "_" & DateTime.Now.Hour &
                     "_" & DateTime.Now.Minute & "_" & DateTime.Now.Second

            Dim str As String

            'save parameters
            filename = "Parameters_" & tempTime & ".csv"
            filename = Application.StartupPath & "\datafiles\" & filename
            writeINI(sfile, "GameSettings", "gameName", "ESI Software2")
            writeINI(sfile, "GameSettings", "gameName", "ESI Software")
            FileCopy(sfile, filename)

            'first data file
            filename = "Summary_Data_" & tempTime & ".csv"
            filename = Application.StartupPath & "\datafiles\" & filename

            summaryDf = File.CreateText(filename)
            str = "Period,Treatment,Player,Bid,Won,Value,Price,Profit," &
                   "SubmitPt1X,SubmitPt1Y,SubmitPt2X,SubmitPt2Y,SubmitPt3X,SubmitPt3Y,SubmitPt4X,SubmitPt4Y," &
                   "ResultPt1X,ResultPt1Y,ResultPt2X,ResultPt2Y,ResultPt3X,ResultPt3Y,ResultPt4X,ResultPt4Y,ResultBid,"

            For i As Double = 0 To maxValue Step 0.1
                str &= "RB_" & Math.Round(i, 1) & ","
            Next

            summaryDf.WriteLine(str)
            summaryDf.AutoFlush = True

            'intialize parameters

            currentPeriod = 1

            dgMain.RowCount = numberOfPlayers

            setupPlayers()

            'load second price values
            For i As Integer = 1 To numberOfPlayers

                dgMain(0, i - 1).Value = i
                dgMain(1, i - 1).Value = playerlist(i).sp.remoteComputerName

                If showInstructions Then
                    dgMain(2, i - 1).Value = "Reading Instructions"
                Else
                    If InStr(periodType(currentPeriod), "English") > 0 Or InStr(periodType(currentPeriod), "Dutch") > 0 Then
                        dgMain(2, i - 1).Value = "Pressing Ready"
                    Else
                        dgMain(2, i - 1).Value = "Playing"
                    End If
                End If

                dgMain(3, i - 1).Value = FormatCurrency(0)

                playerlist(i).p_curve = New Pen(getMyColor(i), 3)
                setTriangleEndCap(playerlist(i).p_curve)

                playerlist(i).p_Profit = New Pen(getMyColor(i), 5)
                setTriangleEndCap(playerlist(i).p_Profit)

                playerlist(i).p2_dash = New Pen(getMyColor(i), 2)
                setTriangleEndCap(playerlist(i).p2_dash)
                playerlist(i).p2_dash.DashStyle = DashStyle.Dash

                For j As Integer = 1 To numberOfPeriods
                    For k As Integer = 1 To numberOfPlayers

                        If InStr(periodType(j), "English") > 0 Then
                            playerlist(k).bids(j) = New bid(valueRange + 1, k, j, False)
                        Else
                            playerlist(k).bids(j) = New bid(-1, k, j, False)
                        End If
                    Next
                Next
            Next

            dgMain.CurrentCell.Selected = False

            checkin = 0
            clockStatus = "takeBids"
            'waitCounter = 0

            Dim outstr As String = ""

            If InStr(periodType(currentPeriod), "English") > 0 Or
               InStr(periodType(currentPeriod), "Dutch") > 0 Then

                setupClockBids(Now)
            End If

            For i As Integer = 1 To numberOfPlayers
                playerlist(i).sendBegin(outstr)
            Next

            For i As Integer = 1 To numberOfPeriods
                periodComplete(i) = False
            Next

            cmdBegin.Enabled = False
            cmdLoad.Enabled = False
            cmdExit.Enabled = False
            cmdExchange.Enabled = False

            cmdSetup1.Enabled = False
            cmdSetup2.Enabled = False
            cmdSetup3.Enabled = False
            cmdSetup4.Enabled = False
            cmdSetup5.Enabled = False

            cmdEndEarly.Enabled = True

            cmdReplay.Enabled = False

            setUpLossArea()

            'calcGridCords()

            'yScaleMax = 100
            Timer1.Enabled = True

            'updatePeriodDisplay()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setUpLossArea()
        Try
            tempPathBidGreaterThanValue = New GraphicsPath
            tempPathBidGreaterThanValue.AddLine(xStart, yStart, xStart, yStop) 'down
            tempPathBidGreaterThanValue.AddLine(xStart, yStop, xStop, CInt(Math.Round(convertToY(maxValue, 0, valueRange, yStop - yStart, 0, yStart))))

            tempPathBidGreaterThanValue.AddLine(xStop, CInt(Math.Round(convertToY(maxValue, 0, valueRange, yStop - yStart, 0, yStart))), xStop, yStart)
            tempPathBidGreaterThanValue.AddLine(xStop, yStart, xStart, yStart)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Delegate Sub setConnectionsLabelCallback(text As String)

    Public Sub setConnectionsLabel(ByVal text As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If lblConnectionCount.InvokeRequired Then
            Dim d As New setConnectionsLabelCallback(AddressOf setConnectionsLabel)
            Me.Invoke(d, New Object() {text})
        Else
            lblConnectionCount.Text = text
        End If
    End Sub

    Public Sub refreshConnectionsLabel()
        Try
            setConnectionsLabel(clientCount)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            'save current parameters to a text file so they can be loaded at a later time

            SaveFileDialog1.FileName = ""
            SaveFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            SaveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            FileCopy(sfile, SaveFileDialog1.FileName)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Try
            Dim tempS As String
            Dim sinstr As String

            'dispaly open file dialog to select file
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath

            OpenFileDialog1.ShowDialog()

            'if filename is not empty then continue with load
            If OpenFileDialog1.FileName = "" Then
                Exit Sub
            End If

            tempS = OpenFileDialog1.FileName

            sinstr = getINI(tempS, "gameSettings", "gameName")

            'check that this is correct type of file to load
            If sinstr <> "ESI Software" Then
                MsgBox("Invalid file", vbExclamation)
                Exit Sub
            End If

            'copy file to be loaded into server.ini
            FileCopy(OpenFileDialog1.FileName, sfile)

            'load new parameters into server
            loadParameters()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup1_Click(sender As Object, e As EventArgs) Handles cmdSetup1.Click
        Try
            frmSetup1.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdExchange_Click(sender As Object, e As EventArgs) Handles cmdExchange.Click
        Try
            frmExchange.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdEndEarly_Click(sender As Object, e As EventArgs) Handles cmdEndEarly.Click
        Try
            cmdEndEarly.Enabled = False

            numberOfPeriods = currentPeriod

            For i As Integer = 1 To numberOfPlayers
                playerlist(i).sendEndEarly()
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup2_Click(sender As Object, e As EventArgs) Handles cmdSetup2.Click
        Try
            Cursor = Cursors.WaitCursor
            frmSetup2.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup3_Click(sender As Object, e As EventArgs) Handles cmdSetup3.Click
        Try
            Cursor = Cursors.WaitCursor
            frmSetup3.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup4_Click(sender As Object, e As EventArgs) Handles cmdSetup4.Click
        Try
            frmSetup4.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dgMain_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgMain.CellMouseClick, dgMain.CellMouseDoubleClick
        Try
            If dgMain.RowCount > 0 Then dgMain.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Try
            If PrintDialog1.ShowDialog = DialogResult.OK Then
                PrintDocument1.Print()
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim i As Integer
            Dim f As New Font("Arial", 8, FontStyle.Bold)
            Dim tempN As Integer

            ' e.Graphics.DrawString(filename, f, Brushes.Black, 10, 10)

            f = New Font("Arial", 15, FontStyle.Bold)

            e.Graphics.DrawString("Name", f, Brushes.Black, 10, 30)
            e.Graphics.DrawString("Earnings", f, Brushes.Black, 400, 30)

            f = New Font("Arial", 12, FontStyle.Bold)

            tempN = 55

            For i = 1 To dgMain.RowCount
                If i Mod 2 = 0 Then
                    e.Graphics.FillRectangle(Brushes.Aqua, 0, tempN, 500, 19)
                End If
                e.Graphics.DrawString(dgMain.Rows(i - 1).Cells(1).Value, f, Brushes.Black, 10, tempN)
                e.Graphics.DrawString(dgMain.Rows(i - 1).Cells(3).Value, f, Brushes.Black, 400, tempN)

                tempN += 20
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    'graph
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim ts As TimeSpan = Now - timeOfLastRefresh

            If ts.Milliseconds <= 90 Then Exit Sub

            refreshScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Dim refreshMissed As Boolean = False
    Public Sub refreshScreen()
        Try

            timeOfLastRefresh = Now

            'mainScreen.erase1()
            'Dim g As Graphics = mainScreen.GetGraphics

            'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            'drawAxis(g, pnlBackGround)
            'drawBidGreaterThanValue(g)
            ''drawWinningBids(g)
            ''drawCurves(g)
            ''drawBids(g)
            'drawClockPrice(g)

            'mainScreen.flip()

            If Not bwRefreshScreen.IsBusy Then
                refreshMissed = False
                bwRefreshScreen.RunWorkerAsync()
            Else
                refreshMissed = True
            End If

            'bwRefreshScreen.RunWorkerAsync()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub bwRefreshScreen_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwRefreshScreen.DoWork
        Try

            mainScreen.erase1()
            Dim g As Graphics = mainScreen.GetGraphics

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            drawAxis(g, pnlBackGround)
            drawBidGreaterThanValue(g)
            drawValues(g)
            drawWinningBids(g)
            drawCurves(g)
            drawBids(g)
            drawWinner(g)
            drawClockPrice(g)

            mainScreen.flip()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Private Sub bwRefreshScreen_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwRefreshScreen.RunWorkerCompleted
        Try
            If refreshMissed Then
                refreshScreen()
            End If
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub drawValues(g As Graphics)
        Try
            For i As Integer = 1 To numberOfPlayers
                playerlist(i).drawValue(g, currentPeriod)
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawCurves(g As Graphics)
        Try
            If Not InStr(periodType(currentPeriod), "Fast") > 0 Then Exit Sub
            If Not cbCurves.Checked Then Exit Sub

            For i As Integer = 1 To numberOfPlayers
                If cmdBegin.Enabled Then
                    If playerlist(i).bezeirPointsSubmit(1, currentPeriod).X <> -1 Then
                        playerlist(i).drawCurve(g, currentPeriod, playerlist(i).bezeirPointsSubmit)
                    Else
                        playerlist(i).drawCurve(g, currentPeriod, playerlist(i).bezeirPointsResults)
                    End If

                Else
                    If playerlist(i).bezeirPointsSubmit(1, currentPeriod - 1).X <> -1 Then
                        playerlist(i).drawCurve(g, currentPeriod - 1, playerlist(i).bezeirPointsSubmit)
                    Else
                        playerlist(i).drawCurve(g, currentPeriod - 1, playerlist(i).bezeirPointsResults)
                    End If
                End If

            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawWinner(g As Graphics)
        Try

            For i As Integer = 1 To numberOfPlayers
                If cmdBegin.Enabled Then
                    playerlist(i).drawWinner(g, currentPeriod)
                Else
                    playerlist(i).drawWinner(g, currentPeriod - 1)
                End If

            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub capPen(ByRef p As Pen)
        Try
            p.EndCap = LineCap.Triangle
            p.StartCap = LineCap.Triangle
            p.Alignment = PenAlignment.Center
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function convertToX(ByVal tempWidth As Integer, ByVal xOffest As Integer, ByVal markerWidth As Integer, tempValue As Double) As Double
        Try

            Dim tempT As Double = tempWidth / maxValue
            Dim tempV As Double = tempValue

            Return (tempT * tempV + xOffest - markerWidth / 2)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

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

    Public Sub drawWinningBids(g As Graphics)
        Try

            If Not cbHistory.Checked Then Exit Sub

            Dim tempC As Integer = 0

            For i As Integer = currentPeriod To 1 Step -1
                For j As Integer = 1 To numberOfPlayers
                    If playerlist(j).bids(i) IsNot Nothing Then
                        If playerlist(j).bids(i).won Then
                            playerlist(j).bids(i).draw(g)
                        End If
                    End If
                Next

                tempC += 1
                Dim tempV As Integer = GetTextBoxText()
                If tempC = tempV Then
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            appEventLog_Write("error convertY:", ex)
        End Try
    End Sub

    Private Delegate Function GetTBInvoker() As Integer

    Private Function GetTextBoxText() As Integer
        Dim text As Integer

        If Me.tbHistory.InvokeRequired Then
            text = CStr(Me.tbHistory.Invoke(New GetTBInvoker(AddressOf GetTextBoxText)))
        Else
            text = Me.tbHistory.Value
        End If

        Return text
    End Function

    Public Sub drawBids(g As Graphics)
        Try

            For j As Integer = 1 To numberOfPlayers
                If playerlist(j).bids(currentPeriod) IsNot Nothing Then
                    playerlist(j).bids(currentPeriod).draw(g)
                End If
            Next

        Catch ex As Exception
            appEventLog_Write("error convertY:", ex)
        End Try
    End Sub

    Public Sub drawClockPrice(g As Graphics)
        Try
            If cmdBegin.Enabled Then Exit Sub

            If Not InStr(periodType(currentPeriod), "English") > 0 And
               Not InStr(periodType(currentPeriod), "Dutch") > 0 Then

                Exit Sub
            End If

            If currentClockPrice = -1 Then Exit Sub

            Dim tempY As Integer = convertToY(currentClockPrice, 0, valueRange, yStop - yStart, 0, yStart)

            g.DrawLine(p3_grey, xStart, tempY, xStop, tempY)

            If InStr(periodType(currentPeriod), "English") > 0 Then
                g.DrawString("Price = " & Format(currentClockPrice, "0.00"), f16, Brushes.DimGray, New Point(xStop, tempY - 25), fmt2)
            Else
                g.DrawString("Price = " & Format(currentClockPrice, "0.00"), f16, Brushes.DimGray, New Point(xStop, tempY), fmt2)
            End If

            ' Dim ts As TimeSpan = Now - periodStartTime
            'g.DrawString("Elapsed Time: " & ts.TotalSeconds, f10, Brushes.Black, New Point(tempX, tempY + 18), fmt2)
            g.DrawString("Price=6 Seconds: " & priceE6.TotalSeconds, f10, Brushes.Black, New Point(tempX, tempY + 20), fmt2)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawBidGreaterThanValue(g As Graphics)
        Try

            g.FillPath(New SolidBrush(Color.FromArgb(50, Color.Crimson)), tempPathBidGreaterThanValue)

            'g.TranslateTransform(xStart + 100, yStart + 100)
            'g.RotateTransform(-45)

            'g.DrawString("Bid > Value", f16, Brushes.Crimson, 0, -25, fmt)

            'g.ResetTransform()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawAxis(ByVal g As Graphics, pnlBackGround As Panel)
        Try

            'axis
            g.DrawLine(p1, xStart, yStart, xStart, pnlBackGround.Height - 30)
            g.DrawLine(p1, xStart, yStop, xStop, yStop)


            tempP = valueRange
            tempPIncrement = 1 '(nudScale.Value - sellQuantity) / gridCount

            For i As Integer = 1 To valueRange
                'bid ticks
                tempY = convertToY(i, 0, valueRange, yStop - yStart, 0, yStart)
                g.DrawLine(p1, xStart - 5, CInt(tempY), xStart, CInt(tempY))
                g.DrawString(i, f12, Brushes.Black, xStart - 5, tempY - 7, fmt2)

                '  tempY += tempYIncrement
                '   tempP -= tempPIncrement
            Next

            For i As Integer = 1 To maxValue
                tempX = convertToX(xStop - xStart, xStart, 0, i)
                g.DrawLine(p1, CInt(tempX), CInt(yStop), CInt(tempX), CInt(yStop + 5))
                g.DrawString(CStr(i), f12, Brushes.Black, tempX + 5, yStop + 5, fmt2)
                '  tempX += tempXIncrement
            Next

            g.TranslateTransform(0, pnlBackGround.Height)
            g.DrawString("Value ->", f10, Brushes.DarkGray, 0, -25)
            g.RotateTransform(-90)
            g.DrawString("Bid ->", f10, Brushes.DarkGray, 30, 0)
            g.ResetTransform()


            'draw key
            Dim tempN As Integer = xStart + 5
            For i As Integer = 1 To numberOfPlayers
                g.FillRectangle(New SolidBrush(getMyColor(i)), New Rectangle(tempN, 2, 16, 16))
                g.DrawString(i, f10, Brushes.DarkGray, tempN + 8, 3, fmt)

                tempN += 20
            Next
        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub

    'Dim gridCount As Integer
    'Dim xGrid(100) As Integer
    'Dim yGrid(100) As Integer
    Dim tempY As Double
    Dim tempYIncrement As Double
    Dim tempX As Double
    Dim tempXIncrement As Double
    Dim tempP As Double
    Dim tempPIncrement As Double


    Public Function convertX(ByVal tempWidth As Integer, ByVal xOffest As Integer, ByVal markerWidth As Integer, tempTime As Integer, periodLength As Double) As Double
        Try
            periodLength += 1

            Dim tempT As Double = tempWidth / periodLength
            Dim tempV As Double = tempTime

            Return (tempT * tempV + xOffest - markerWidth / 2)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Function convertY(ByVal p As Double, ByVal graphMin As Integer, ByVal graphMax As Integer,
                         ByVal tempHeight As Integer, ByVal markerWidth As Integer, ByVal yOffset As Integer) As Double
        Try

            Dim tempD As Double

            If p > graphMax Then p = graphMax 'check off scale high

            tempD = p - graphMin

            tempD = tempD / (graphMax - graphMin)
            tempD = tempHeight * (1 - tempD) + yOffset

            convertY = tempD - markerWidth / 2  'adjust for width of marker

        Catch ex As Exception
            appEventLog_Write("error convertY:", ex)
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

    Private Sub cmdSetup5_Click(sender As Object, e As EventArgs) Handles cmdSetup5.Click
        Try
            frmSetup5.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        Try

            'If InStr(periodType(currentPeriod), "English") > 0 Then
            '    If InStr(periodType(currentPeriod), "Fast") > 0 Then
            '        currentClockPrice += fastClockStep
            '    Else
            '        currentClockPrice += slowClockStep
            '    End If
            'Else
            '    If InStr(periodType(currentPeriod), "Fast") > 0 Then
            '        currentClockPrice -= fastClockStep
            '    Else
            '        currentClockPrice -= slowClockStep
            '    End If
            'End If

            'currentClockPrice = Math.Round(currentClockPrice, 2)

            'checkClockEnd()

            'refreshScreen()

            ' End While
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub doTimer2(pulseCount As Integer)
        Try

            If InStr(periodType(currentPeriod), "English") > 0 Then
                If InStr(periodType(currentPeriod), "Fast") > 0 Then
                    currentClockPrice += fastClockStep * pulseCount
                Else
                    currentClockPrice += slowClockStep * pulseCount
                End If

                If currentClockPrice > valueRange Then currentClockPrice = maxValue
            Else
                If InStr(periodType(currentPeriod), "Fast") > 0 Then
                    currentClockPrice -= fastClockStep * pulseCount
                Else
                    currentClockPrice -= slowClockStep * pulseCount
                End If

                If currentClockPrice < 0 Then currentClockPrice = 0

            End If

            currentClockPrice = Math.Round(currentClockPrice, 2)

            '  If InStr(periodType(currentPeriod), "Slow") > 0 Then
            ' checkClockEnd()
            '  Else
            If currentClockPrice = valueRange Or
               currentClockPrice = 0 Or
               currentClockPrice < periodMinBid(currentPeriod) Then

                If currentClockPrice < periodMinBid(currentPeriod) Then currentClockPrice = periodMinBid(currentPeriod)

                If bwTimer2.IsBusy Then bwTimer2.CancelAsync()
                exitTimer2 = True
            End If
            ' End If

            If currentClockPrice = 6 Then
                priceE6 = Now - periodStartTime
            End If

            refreshScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub checkClockEnd()
        Try
            'check not reached the edge of range
            'If InStr(periodType(currentPeriod), "Slow") > 0 Then
            '    If InStr(periodType(currentPeriod), "English") > 0 Then
            '        If currentClockPrice >= valueRange Then
            '            For i As Integer = 1 To numberOfPlayers
            '                If playerlist(i).bids(currentPeriod).myBid > valueRange Then playerlist(i).bids(currentPeriod).myBid = valueRange
            '            Next
            '        End If
            '    Else
            '        If currentClockPrice <= 0 Then
            '            For i As Integer = 1 To numberOfPlayers
            '                If playerlist(i).bids(currentPeriod).myBid < 0 Then playerlist(i).bids(currentPeriod).myBid = 0
            '            Next
            '        End If
            '    End If
            'End If

            If bwTimer2.IsBusy Then bwTimer2.CancelAsync()
            exitTimer2 = True

            checkin = 0
            clockStatus = "stop"

            calcFirstOrSecondPriceResults()

            If InStr(periodType(currentPeriod), "English") > 0 Then

                '    If tempC >= numberOfPlayers - 1 Then
                '  Timer2.Enabled = False

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).bids(currentPeriod).won = True Then

                        If currentClockPrice < valueRange Then
                            playerlist(i).bids(currentPeriod).myBid = finalPrice(currentPeriod)
                        Else
                            playerlist(i).bids(currentPeriod).myBid = valueRange
                        End If
                    Else
                        ' playerlist(i).bids(currentPeriod).myBid = valueRange + 1
                    End If
                Next

                '  clockEnd()

                'Else
                '    For i As Integer = 1 To numberOfPlayers
                '        playerlist(i).sendClockPriceUpdate()
                '    Next
                'End If
            Else
                '   If tempC >= 1 Then
                ''Timer2.Enabled = False
                'If bwTimer2.IsBusy Then bwTimer2.CancelAsync()
                'exitTimer2 = True

                'checkin = 0
                'clockStatus = "stop"

                'calcFirstOrSecondPriceResults()

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).bids(currentPeriod).won = True Then

                        If currentClockPrice > periodMinBid(currentPeriod) Then
                            playerlist(i).bids(currentPeriod).myBid = finalPrice(currentPeriod)
                        Else
                            playerlist(i).bids(currentPeriod).myBid = 0
                        End If
                    Else
                        'playerlist(i).bids(currentPeriod).myBid = -1
                    End If
                Next



                'Else
                '    For i As Integer = 1 To numberOfPlayers
                '        playerlist(i).sendClockPriceUpdate()
                '    Next
                'End If
            End If

            clockEnd()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub clockEnd()
        Try
            With frmServer

                If InStr(periodType(currentPeriod), "Slow") Then

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendPeriodResultsSlow()

                        .dgMain(2, i - 1).Value = "Reviewing Results"
                    Next
                Else

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendPeriodResultsFast()
                    Next
                End If

                ' writeSummaryData()

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub updatePeriodDisplay()
        Try
            txtPeriod1.Text = currentPeriod
            txtTreatment.Text = periodType(currentPeriod)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawX(g As Graphics, p As Pen, centerPt As Point, width As Integer)
        Try
            g.DrawLine(p, centerPt.X - width, centerPt.Y - width, centerPt.X + width, centerPt.Y + width)
            g.DrawLine(p, centerPt.X + width, centerPt.Y - width, centerPt.X - width, centerPt.Y + width)
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub startTimer2(periodStartTime As DateTime)
        Try
            'Timer2.Enabled = True

            exitTimer2 = False
            runCount = 0
            Me.periodStartTime = periodStartTime

            If Not bwTimer2.IsBusy Then bwTimer2.RunWorkerAsync()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public periodStartTime As Date
    Public exitTimer2 As Boolean = False
    Public runCount As Double
    Public priceE6 As TimeSpan

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
                End If

                Threading.Thread.Sleep(5)
            End While

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub bwTimer2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTimer2.RunWorkerCompleted
        Try
            If Not exitTimer2 Then bwTimer2.RunWorkerAsync()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Delegate Sub setTimer2Callback(text As Integer)

    Public Sub setTimer2(ByVal text As Integer)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If txtMain.InvokeRequired Then
            Dim d As New setTimer2Callback(AddressOf setTimer2)
            Me.Invoke(d, New Object() {text})
        Else
            doTimer2(text)
        End If
    End Sub

    Private Sub cmdReplay_Click(sender As Object, e As EventArgs) Handles cmdReplay.Click
        Try

            frmReplay.Show()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub tbHistory_Scroll(sender As Object, e As EventArgs) Handles tbHistory.Scroll
        Try

            cbHistory.Text = "History (" & tbHistory.Value & ")"

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub Timer2_Tick_1(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try

            'If waitCounter = 0 Then
            '    waitCounter += 1
            '    Exit Sub
            'End If

            Timer2.Enabled = False
            If periodComplete(currentPeriod) Then Exit Sub
            periodComplete(currentPeriod) = True

            'if clock is running do not continue
            If InStr(periodType(currentPeriod), "English") > 0 Or InStr(periodType(currentPeriod), "Dutch") > 0 Then
                checkClockEnd()
            Else
                If InStr(periodType(currentPeriod), "Fast") > 0 Then

                    calcFirstOrSecondPriceResults()

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendPeriodResultsFast()
                        dgMain(2, i - 1).Value = "Playing"
                    Next
                Else
                    calcFirstOrSecondPriceResults()

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendPeriodResultsSlow()
                        dgMain(2, i - 1).Value = "Reviewing Results"
                    Next
                End If
            End If


        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub
End Class
