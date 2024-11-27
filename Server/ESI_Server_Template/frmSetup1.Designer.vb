<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup1))
        Me.cmdSaveAndClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumberOfPlayers = New System.Windows.Forms.TextBox()
        Me.txtNumberOfPeriods = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPortNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInstructionY = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInstructionX = New System.Windows.Forms.TextBox()
        Me.txtWindowX = New System.Windows.Forms.TextBox()
        Me.txtWindowY = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbShowInstructions = New System.Windows.Forms.CheckBox()
        Me.cbTestMode = New System.Windows.Forms.CheckBox()
        Me.txtValueRange = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHistoryLength = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFastSpeed = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFastClockSpeed = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFastClockStep = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSlowClockStep = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSlowClockSpeed = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdSaveAndClose
        '
        Me.cmdSaveAndClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSaveAndClose.Location = New System.Drawing.Point(78, 508)
        Me.cmdSaveAndClose.Name = "cmdSaveAndClose"
        Me.cmdSaveAndClose.Size = New System.Drawing.Size(276, 31)
        Me.cmdSaveAndClose.TabIndex = 0
        Me.cmdSaveAndClose.Text = "Save and Close"
        Me.cmdSaveAndClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Number of Players (12 Max)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumberOfPlayers
        '
        Me.txtNumberOfPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfPlayers.Location = New System.Drawing.Point(282, 13)
        Me.txtNumberOfPlayers.Name = "txtNumberOfPlayers"
        Me.txtNumberOfPlayers.Size = New System.Drawing.Size(162, 26)
        Me.txtNumberOfPlayers.TabIndex = 2
        Me.txtNumberOfPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumberOfPeriods
        '
        Me.txtNumberOfPeriods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfPeriods.Location = New System.Drawing.Point(282, 45)
        Me.txtNumberOfPeriods.Name = "txtNumberOfPeriods"
        Me.txtNumberOfPeriods.Size = New System.Drawing.Size(162, 26)
        Me.txtNumberOfPeriods.TabIndex = 4
        Me.txtNumberOfPeriods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Number of Periods (1000 max)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPortNumber
        '
        Me.txtPortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPortNumber.Location = New System.Drawing.Point(282, 77)
        Me.txtPortNumber.Name = "txtPortNumber"
        Me.txtPortNumber.Size = New System.Drawing.Size(162, 26)
        Me.txtPortNumber.TabIndex = 6
        Me.txtPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(264, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Port # (Requires restart)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInstructionY
        '
        Me.txtInstructionY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructionY.Location = New System.Drawing.Point(390, 109)
        Me.txtInstructionY.Name = "txtInstructionY"
        Me.txtInstructionY.Size = New System.Drawing.Size(54, 26)
        Me.txtInstructionY.TabIndex = 8
        Me.txtInstructionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(264, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Instruction Start Position"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(365, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Y"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(275, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 23)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "X"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInstructionX
        '
        Me.txtInstructionX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructionX.Location = New System.Drawing.Point(300, 108)
        Me.txtInstructionX.Name = "txtInstructionX"
        Me.txtInstructionX.Size = New System.Drawing.Size(54, 26)
        Me.txtInstructionX.TabIndex = 10
        Me.txtInstructionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWindowX
        '
        Me.txtWindowX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowX.Location = New System.Drawing.Point(300, 140)
        Me.txtWindowX.Name = "txtWindowX"
        Me.txtWindowX.Size = New System.Drawing.Size(54, 26)
        Me.txtWindowX.TabIndex = 15
        Me.txtWindowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWindowY
        '
        Me.txtWindowY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowY.Location = New System.Drawing.Point(390, 141)
        Me.txtWindowY.Name = "txtWindowY"
        Me.txtWindowY.Size = New System.Drawing.Size(54, 26)
        Me.txtWindowY.TabIndex = 13
        Me.txtWindowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(275, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 23)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "X"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(365, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Y"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(264, 23)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Main Window Start Position"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbShowInstructions
        '
        Me.cbShowInstructions.AutoSize = True
        Me.cbShowInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowInstructions.Location = New System.Drawing.Point(263, 461)
        Me.cbShowInstructions.Name = "cbShowInstructions"
        Me.cbShowInstructions.Size = New System.Drawing.Size(172, 24)
        Me.cbShowInstructions.TabIndex = 17
        Me.cbShowInstructions.Text = "Show Instructions"
        Me.cbShowInstructions.UseVisualStyleBackColor = True
        '
        'cbTestMode
        '
        Me.cbTestMode.AutoSize = True
        Me.cbTestMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTestMode.Location = New System.Drawing.Point(36, 461)
        Me.cbTestMode.Name = "cbTestMode"
        Me.cbTestMode.Size = New System.Drawing.Size(112, 24)
        Me.cbTestMode.TabIndex = 20
        Me.cbTestMode.Text = "Test Mode"
        Me.cbTestMode.UseVisualStyleBackColor = True
        '
        'txtValueRange
        '
        Me.txtValueRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueRange.Location = New System.Drawing.Point(282, 173)
        Me.txtValueRange.Name = "txtValueRange"
        Me.txtValueRange.Size = New System.Drawing.Size(162, 26)
        Me.txtValueRange.TabIndex = 22
        Me.txtValueRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 175)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(264, 23)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Value Display Range, 0 to"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHistoryLength
        '
        Me.txtHistoryLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoryLength.Location = New System.Drawing.Point(282, 205)
        Me.txtHistoryLength.Name = "txtHistoryLength"
        Me.txtHistoryLength.Size = New System.Drawing.Size(162, 26)
        Me.txtHistoryLength.TabIndex = 24
        Me.txtHistoryLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 207)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(264, 23)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "History Look Back (Periods)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFastSpeed
        '
        Me.txtFastSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFastSpeed.Location = New System.Drawing.Point(282, 237)
        Me.txtFastSpeed.Name = "txtFastSpeed"
        Me.txtFastSpeed.Size = New System.Drawing.Size(162, 26)
        Me.txtFastSpeed.TabIndex = 26
        Me.txtFastSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 239)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(264, 23)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Fast First/Second Rate (ms)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFastClockSpeed
        '
        Me.txtFastClockSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFastClockSpeed.Location = New System.Drawing.Point(282, 269)
        Me.txtFastClockSpeed.Name = "txtFastClockSpeed"
        Me.txtFastClockSpeed.Size = New System.Drawing.Size(162, 26)
        Me.txtFastClockSpeed.TabIndex = 28
        Me.txtFastClockSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 271)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(264, 23)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Fast Clock Tick Rate (ms)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFastClockStep
        '
        Me.txtFastClockStep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFastClockStep.Location = New System.Drawing.Point(282, 301)
        Me.txtFastClockStep.Name = "txtFastClockStep"
        Me.txtFastClockStep.Size = New System.Drawing.Size(162, 26)
        Me.txtFastClockStep.TabIndex = 30
        Me.txtFastClockStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 303)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 23)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Fast Clock Tick Size"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSlowClockStep
        '
        Me.txtSlowClockStep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlowClockStep.Location = New System.Drawing.Point(282, 365)
        Me.txtSlowClockStep.Name = "txtSlowClockStep"
        Me.txtSlowClockStep.Size = New System.Drawing.Size(162, 26)
        Me.txtSlowClockStep.TabIndex = 34
        Me.txtSlowClockStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 367)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(264, 23)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Slow Clock Tick Size"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSlowClockSpeed
        '
        Me.txtSlowClockSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlowClockSpeed.Location = New System.Drawing.Point(282, 333)
        Me.txtSlowClockSpeed.Name = "txtSlowClockSpeed"
        Me.txtSlowClockSpeed.Size = New System.Drawing.Size(162, 26)
        Me.txtSlowClockSpeed.TabIndex = 32
        Me.txtSlowClockSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 335)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(264, 23)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Slow Clock Tick Rate (ms)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSetup1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 551)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtSlowClockStep)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSlowClockSpeed)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtFastClockStep)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFastClockSpeed)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtFastSpeed)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtHistoryLength)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtValueRange)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbTestMode)
        Me.Controls.Add(Me.cbShowInstructions)
        Me.Controls.Add(Me.txtWindowX)
        Me.Controls.Add(Me.txtWindowY)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtInstructionX)
        Me.Controls.Add(Me.txtInstructionY)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPortNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumberOfPeriods)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumberOfPlayers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSaveAndClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSetup1"
        Me.Text = "Game Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSaveAndClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumberOfPlayers As TextBox
    Friend WithEvents txtNumberOfPeriods As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPortNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInstructionY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtInstructionX As TextBox
    Friend WithEvents txtWindowX As TextBox
    Friend WithEvents txtWindowY As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cbShowInstructions As CheckBox
    Friend WithEvents cbTestMode As CheckBox
    Friend WithEvents txtValueRange As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtHistoryLength As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFastSpeed As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFastClockSpeed As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFastClockStep As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSlowClockStep As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtSlowClockSpeed As TextBox
    Friend WithEvents Label16 As Label
End Class
