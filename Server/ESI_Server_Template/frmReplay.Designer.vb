<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReplay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReplay))
        Me.cmdPauseData = New System.Windows.Forms.Button()
        Me.cmdLoadData = New System.Windows.Forms.Button()
        Me.tbData = New System.Windows.Forms.TrackBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdPlayData = New System.Windows.Forms.Button()
        Me.nudSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.tbData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPauseData
        '
        Me.cmdPauseData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPauseData.Image = CType(resources.GetObject("cmdPauseData.Image"), System.Drawing.Image)
        Me.cmdPauseData.Location = New System.Drawing.Point(62, 12)
        Me.cmdPauseData.Name = "cmdPauseData"
        Me.cmdPauseData.Size = New System.Drawing.Size(44, 39)
        Me.cmdPauseData.TabIndex = 66
        Me.cmdPauseData.UseVisualStyleBackColor = True
        '
        'cmdLoadData
        '
        Me.cmdLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoadData.Image = CType(resources.GetObject("cmdLoadData.Image"), System.Drawing.Image)
        Me.cmdLoadData.Location = New System.Drawing.Point(12, 12)
        Me.cmdLoadData.Name = "cmdLoadData"
        Me.cmdLoadData.Size = New System.Drawing.Size(44, 38)
        Me.cmdLoadData.TabIndex = 64
        Me.cmdLoadData.UseVisualStyleBackColor = True
        '
        'tbData
        '
        Me.tbData.LargeChange = 1
        Me.tbData.Location = New System.Drawing.Point(112, 11)
        Me.tbData.Minimum = 1
        Me.tbData.Name = "tbData"
        Me.tbData.Size = New System.Drawing.Size(447, 45)
        Me.tbData.TabIndex = 65
        Me.tbData.TickFrequency = 10
        Me.tbData.Value = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'cmdPlayData
        '
        Me.cmdPlayData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPlayData.Image = CType(resources.GetObject("cmdPlayData.Image"), System.Drawing.Image)
        Me.cmdPlayData.Location = New System.Drawing.Point(79, -16)
        Me.cmdPlayData.Name = "cmdPlayData"
        Me.cmdPlayData.Size = New System.Drawing.Size(44, 38)
        Me.cmdPlayData.TabIndex = 67
        Me.cmdPlayData.UseVisualStyleBackColor = True
        Me.cmdPlayData.Visible = False
        '
        'nudSpeed
        '
        Me.nudSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSpeed.Location = New System.Drawing.Point(575, 21)
        Me.nudSpeed.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSpeed.Name = "nudSpeed"
        Me.nudSpeed.Size = New System.Drawing.Size(44, 31)
        Me.nudSpeed.TabIndex = 68
        Me.nudSpeed.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(577, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Speed"
        '
        'frmReplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 60)
        Me.Controls.Add(Me.nudSpeed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdPlayData)
        Me.Controls.Add(Me.cmdPauseData)
        Me.Controls.Add(Me.cmdLoadData)
        Me.Controls.Add(Me.tbData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReplay"
        Me.Text = "Replay"
        CType(Me.tbData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdPauseData As Button
    Friend WithEvents cmdLoadData As Button
    Friend WithEvents tbData As TrackBar
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmdPlayData As Button
    Friend WithEvents nudSpeed As NumericUpDown
    Friend WithEvents Label1 As Label
End Class
