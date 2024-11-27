Module modDrawing
    Public Function getMyColor(ByVal index As Integer) As Drawing.Color
        Try
            'appEventLog_Write("get color")


            Select Case index
                Case 1
                    Return Drawing.Color.Crimson
                Case 2
                    Return Drawing.Color.Teal
                Case 3
                    Return Drawing.Color.Purple
                Case 4
                    Return Drawing.Color.Sienna
                Case 5
                    Return Drawing.Color.Pink
                Case 6
                    Return Drawing.Color.Gray
                Case 7
                    Return Drawing.Color.Khaki
                Case 8
                    Return Drawing.Color.Olive
                Case 9
                    Return Drawing.Color.Orchid
                Case 10
                    Return Drawing.Color.Blue
                Case 11
                    Return Drawing.Color.Red
                Case 12
                    Return Drawing.Color.Green

            End Select


        Catch ex As Exception
            appEventLog_Write("error getMyColor:", ex)
        End Try
    End Function

    Public Function getMyColorName(ByVal index As Integer) As String
        Try
            'appEventLog_Write("get color")

            Select Case index
                Case 1
                    Return "Crimson"
                Case 2
                    Return "Teal"
                Case 3
                    Return "Purple"
                Case 4
                    Return "Brown"
                Case 5
                    Return "Pink"
                Case 6
                    Return "Gray"
                Case 7
                    Return "Khaki"
                Case 8
                    Return "Olive"
                Case 9
                    Return "Orchid"
                Case 10
                    Return "Blue"
                Case 11
                    Return "Red"
                Case 12
                    Return "Green"

            End Select

            Return ""
        Catch ex As Exception
            Return ""
            appEventLog_Write("error getMyColor:", ex)
        End Try
    End Function
End Module
