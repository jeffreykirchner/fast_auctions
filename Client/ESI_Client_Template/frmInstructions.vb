Public Class frmInstructions
    Public startPressed As Boolean = False
    Public numberOfPages As Integer = 10
    Public startPage As Integer = 1
    Public pagesDone(100) As Boolean

    Public movedPoints(4) As Boolean

    Private Sub frmInstructions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'change if actions needed
            'For i As Integer = 1 To numberOfPages
            '    pagesDone(i) = True
            'Next

            startPressed = False
            'currentInstruction = 1
            ' nextInstruction()

            For i As Integer = 1 To 4
                movedPoints(i) = False
            Next

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub nextInstruction()
        Try
            If currentInstruction = numberOfPages Then
                cmdNext.Visible = False
            End If

            If currentInstruction = numberOfPages And Not startPressed Then
                cmdStart.Visible = True
            End If

            Dim folder As String = ""


            RichTextBox1.LoadFile(Application.StartupPath &
               "\Instructions\" & getPageName() & ".rtf")

            variables()

            RichTextBox1.SelectionStart = 1
            RichTextBox1.ScrollToCaret()

            If Not startPressed Then frmClient.AC.sendMessage("INSTRUCTION_PAGE", currentInstruction & ";")
            Text = "Instructions, Page " & currentInstruction - (startPage - 1) & "/" & numberOfPages - (startPage - 1)
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Try

            If Not pagesDone(currentInstruction) Then Exit Sub

            cmdBack.Visible = True

            If currentInstruction = numberOfPages Then Exit Sub

            currentInstruction += 1



            nextInstruction()

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        Try
            cmdStart.Visible = False
            startPressed = True

            Dim outstr As String = ""
            Dim tempC As Integer = 0

            frmClient.AC.sendMessage("FINSHED_INSTRUCTIONS", outstr)
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Try

            cmdNext.Visible = True

            'previous page of instructions

            If currentInstruction = 1 Then
                Exit Sub
            End If

            currentInstruction -= 1

            If currentInstruction = startPage Then cmdBack.Visible = False

            nextInstruction()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub variables()
        Try

            'globals
            RepRTBfield2("groupSize", numberOfPlayers)

            If periodMinBid(1) > 0 Then
                RepRTBfield2("minBidDesc", "You cannot bid below the minimum bid.")
                RepRTBfield2("minBidChange", "The minimum bid, #minBid# in this example, may change from period to period.  It is represented by the horizontal gray line.")
            Else
                RepRTBfield2("minBidChange", " ")
                RepRTBfield2("minBidDesc", " ")
            End If

            RepRTBfield2("minBid", Format(periodMinBid(1), "0.00"))

            RepRTBfield2("minValue", Format(minValue, "0.00"))

            Dim inc As Double = 0.01

            If valueType = "whole" Then
                inc = 1
            Else
                inc = 0.01
            End If

            RepRTBfield2("minValue+bidInc", Format(Math.Round(minValue + inc, 2), "0.00"))
            RepRTBfield2("minValue+bidInc*2", Format(Math.Round(minValue + inc * 2, 2), "0.00"))
            RepRTBfield2("minValue+bidInc*3", Format(Math.Round(minValue + inc * 3, 2), "0.00"))
            RepRTBfield2("maxValue-bidInc*2", Format(Math.Round(maxValue - inc * 2, 2), "0.00"))
            RepRTBfield2("maxValue-bidInc", Format(Math.Round(maxValue - inc, 2), "0.00"))
            RepRTBfield2("maxValue", Format(Math.Round(maxValue, 2), "0.00"))

            RepRTBfield2("valueRange", Format(Math.Round(valueRange, 2), "0.00"))

            RepRTBfield2("tickInterval", Math.Round(slowClockSpeed / 1000, 2))
            RepRTBfield2("amount", slowClockStep)
            RepRTBfield2("exchangerate", exchangeRate)

            If currentPeriod = 1 Then
                RepRTBfield2("changeNotification", " ")
            Else
                RepRTBfield2("changeNotification", "The auction rules have changed." & vbCrLf & vbCrLf)
            End If


            Select Case currentInstruction
                Case 1
                    If Not pagesDone(currentInstruction) Then
                        pagesDone(currentInstruction) = True
                    End If
                Case 2

                    If valueType = "whole" Then
                        RepRTBfield2("example", Format(rand(maxValue, minValue), "0.00"))
                    Else
                        RepRTBfield2("example", Format(Math.Round(rand(maxValue - 1, minValue) + (rand(100, 0) / 100), 2), "0.00"))
                    End If

                    If Not pagesDone(currentInstruction) Then
                        pagesDone(currentInstruction) = True
                    End If
                Case 3
                    If Not pagesDone(currentInstruction) Then
                        pagesDone(currentInstruction) = True
                    End If
                Case 4

                    If Not pagesDone(currentInstruction) Then

                        pagesDone(currentInstruction) = True
                    End If
                Case 5
                    If Not pagesDone(currentInstruction) Then

                        With frmRealTime
                            'bids(1) = New bid
                            'bids(1).fromString({values(1) + 1, "true"}, 0)

                            'finalPrice(1) = values(1) + 1


                            'bids(2) = New bid
                            'bids(2).fromString({values(2) - 1, "true"}, 0)

                            'finalPrice(2) = values(2) - 1

                            pagesDone(currentInstruction) = True

                            'For i As Integer = 1 To 2
                            '    'bid point
                            '    bids(i).bidPt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, values(i)),
                            '                                        .convertToY(bids(i).myBid, 0, valueRange, .yStop - .yStart, 0, .yStart))

                            '    'price point
                            '    bids(i).pricePt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, values(i)),
                            '                                            .convertToY(finalPrice(i), 0, valueRange, .yStop - .yStart, 0, .yStart))

                            '    'value point
                            '    bids(i).valuePt = New PointF(.convertToX(.xStop - .xStart, .xStart, 0, values(i)),
                            '                                            .convertToY(values(i), 0, valueRange, .yStop - .yStart, 0, .yStart))

                            '    bids(i).period = i

                            'Next

                            '  currentPeriod = 3

                            .cmdSubmitFirst.Visible = True
                            .pnlAreYouSure.Visible = False


                            If periodType(currentPeriod) = "Slow First Price" Or periodType(currentPeriod) = "Slow Second Price" Then
                                .txtBid.Text = ""
                                .txtBid.ReadOnly = True
                                .cmdSubmitFirst.Text = "Ready To Go On"

                                .cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                            ElseIf periodType(currentPeriod) = "Slow Dutch" Then

                                .cmdSubmitFirst.Text = "Buy"
                                .cmdSubmitFirst.BackColor = Color.FromArgb(192, 255, 192)
                            ElseIf periodType(currentPeriod) = "Slow English" Then

                                .cmdSubmitFirst.Text = "Do Not Buy"
                                .cmdSubmitFirst.BackColor = Color.FromArgb(255, 192, 192)
                            End If

                        End With

                    End If
                Case 6
                    If Not pagesDone(currentInstruction) Then
                        pagesDone(currentInstruction) = True
                    End If
                Case 7

                Case 8
                    If Not pagesDone(currentInstruction) Then
                        pagesDone(currentInstruction) = True
                    End If
                Case 9


            End Select

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Function RepRTBfield(ByVal sField As String, ByVal sValue As String) As Boolean
        Try
            'when the instructions are loaded into the rich text box control this function will
            'replace the variable place holders with variables.

            If RichTextBox1.Find("#" & sField & "#") = -1 Then
                RichTextBox1.DeselectAll()
                Return False
            End If

            RichTextBox1.SelectedText = sValue

            Return True
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
            Return False
        End Try
    End Function

    Public Sub RepRTBfield2(ByVal sField As String, ByVal sValue As String)
        Try
            Do While (RepRTBfield(sField, sValue))

            Loop
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Public Sub checkQuiz()
        Try

            pagesDone(currentInstruction) = True
            nextInstruction()
            gbQuiz.Visible = False
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub txtQuiz_TextChanged(sender As Object, e As EventArgs) Handles txtQuiz.TextChanged
        Try
            AcceptButton = cmdSubmitQuiz
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub cmdSubmitQuiz_Click(sender As Object, e As EventArgs) Handles cmdSubmitQuiz.Click
        Try
            If txtQuiz.Text.Trim = "" Then Exit Sub
            checkQuiz()
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Public Function getPageName() As String
        Try
            Dim str As String = ""

            If currentInstruction <= 3 Then
                str = "Intro_" & currentInstruction
                'ElseIf currentInstruction = 5 And InStr(periodType(currentPeriod), "Fast") > 0 Then
                '    str = "Fast_5"
            Else
                Select Case periodType(currentPeriod)
                    Case "Slow English"
                        str = "EnglishSlow_" & currentInstruction
                    Case "Slow Dutch"
                        str = "DutchSlow_" & currentInstruction
                    Case "Slow First Price"
                        str = "FirstpriceSlow_" & currentInstruction
                    Case "Slow Second Price"
                        str = "SecondpriceSlow_" & currentInstruction
                    Case "Fast English"
                        str = "EnglishFast_" & currentInstruction
                    Case "Fast Dutch"
                        str = "DutchFast_" & currentInstruction
                    Case "Fast First Price"
                        str = "FirstpriceFast_" & currentInstruction
                    Case "Fast Second Price"
                        str = "SecondpriceFast_" & currentInstruction
                End Select
            End If

            Return str
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
            Return ""
        End Try
    End Function
End Class