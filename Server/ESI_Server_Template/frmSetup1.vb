Public Class frmSetup1
    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try
            writeINI(sfile, "gameSettings", "numberOfPlayers", txtNumberOfPlayers.Text)
            writeINI(sfile, "gameSettings", "numberOfPeriods", txtNumberOfPeriods.Text)
            writeINI(sfile, "gameSettings", "port", txtPortNumber.Text)
            writeINI(sfile, "gameSettings", "instructionX", txtInstructionX.Text)
            writeINI(sfile, "gameSettings", "instructionY", txtInstructionY.Text)
            writeINI(sfile, "gameSettings", "windowX", txtWindowX.Text)
            writeINI(sfile, "gameSettings", "windowY", txtWindowY.Text)

            writeINI(sfile, "gameSettings", "showInstructions", cbShowInstructions.Checked)
            writeINI(sfile, "gameSettings", "testMode", cbTestMode.Checked)

            writeINI(sfile, "gameSettings", "valueRange", txtValueRange.Text)
            writeINI(sfile, "gameSettings", "historyLength", txtHistoryLength.Text)

            writeINI(sfile, "gameSettings", "fastSpeed", txtFastSpeed.Text)
            writeINI(sfile, "gameSettings", "fastClockSpeed", txtFastClockSpeed.Text)
            writeINI(sfile, "gameSettings", "fastClockStep", txtFastClockStep.Text)
            writeINI(sfile, "gameSettings", "slowClockSpeed", txtSlowClockSpeed.Text)
            writeINI(sfile, "gameSettings", "slowClockStep", txtSlowClockStep.Text)

            loadParameters()

            Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSetup1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtNumberOfPlayers.Text = getINI(sfile, "gameSettings", "numberOfPlayers")
            txtNumberOfPeriods.Text = getINI(sfile, "gameSettings", "numberOfPeriods")
            txtPortNumber.Text = getINI(sfile, "gameSettings", "port")
            txtInstructionX.Text = getINI(sfile, "gameSettings", "instructionX")
            txtInstructionY.Text = getINI(sfile, "gameSettings", "instructionY")
            txtWindowX.Text = getINI(sfile, "gameSettings", "windowX")
            txtWindowY.Text = getINI(sfile, "gameSettings", "windowY")

            cbShowInstructions.Checked = getINI(sfile, "gameSettings", "showInstructions")
            cbTestMode.Checked = getINI(sfile, "gameSettings", "testMode")

            txtValueRange.Text = getINI(sfile, "gameSettings", "valueRange")
            txtHistoryLength.Text = getINI(sfile, "gameSettings", "historyLength")

            txtFastSpeed.Text = getINI(sfile, "gameSettings", "fastSpeed")
            txtFastClockSpeed.Text = getINI(sfile, "gameSettings", "fastClockSpeed")
            txtFastClockStep.Text = getINI(sfile, "gameSettings", "fastClockStep")
            txtSlowClockSpeed.Text = getINI(sfile, "gameSettings", "slowClockSpeed")
            txtSlowClockStep.Text = getINI(sfile, "gameSettings", "slowClockStep")

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class