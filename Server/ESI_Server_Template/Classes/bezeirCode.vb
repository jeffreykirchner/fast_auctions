Module bezeirCode

    Public Function getValuePoints(b1 As PointF, b2 As PointF, b3 As PointF, b4 As PointF) As String
        Try
            Dim tempS As String = ""

            For i As Double = 0 To maxValue Step 0.1
                Dim tempP As PointF = getValuePoint(b1, b2, b3, b4, Math.Round(i, 1))

                tempS &= Math.Round(tempP.Y, 7) & ","
            Next

            Return tempS
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function

    Public Function getValuePoint(b1 As PointF, b2 As PointF, b3 As PointF, b4 As PointF, v As Double) As PointF
        Try
            Dim pt As New PointF

            Dim tempT As Double = GetBezierT(b1.X, b2.X, b3.X, b4.X, v)

            pt = getBezierPoint(b1, b2, b3, b4, tempT)

            Return pt
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return New PointF(0, 0)
        End Try
    End Function

    Public Function GetBezierT(x1 As Double, x2 As Double, x3 As Double, x4 As Double, X As Double) As Double

        'iterative method
        Dim tempT As Double = 0.5
        Dim tempStepSize As Double = 0.5
        Dim tempStab As Double = (1 - tempT) ^ 3 * x1 + 3 * (1 - tempT) ^ 2 * tempT * x2 + 3 * (1 - tempT) * tempT ^ 2 * x3 + tempT ^ 3 * x4

        Dim tempCount As Double = 0
        Dim tempXPoint As Double = X
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

    Public Function getBezierPoint(b1 As PointF, b2 As PointF, b3 As PointF, b4 As PointF, t As Double) As PointF
        Try
            Dim pt As New PointF

            pt.X = (1 - t) ^ 3 * b1.X + 3 * (1 - t) ^ 2 * t * b2.X + 3 * (1 - t) * t ^ 2 * b3.X + t ^ 3 * b4.X
            pt.Y = (1 - t) ^ 3 * b1.Y + 3 * (1 - t) ^ 2 * t * b2.Y + 3 * (1 - t) * t ^ 2 * b3.Y + t ^ 3 * b4.Y

            Return pt
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
            Return New PointF(0, 0)
        End Try
    End Function


End Module
