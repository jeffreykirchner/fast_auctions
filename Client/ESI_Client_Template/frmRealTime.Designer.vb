<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRealTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRealTime))
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEarnings = New System.Windows.Forms.TextBox()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.gbBid = New System.Windows.Forms.GroupBox()
        Me.pnlAreYouSure = New System.Windows.Forms.Panel()
        Me.cmdNo = New System.Windows.Forms.Button()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.lblAreYouSure = New System.Windows.Forms.Label()
        Me.cmdSubmitFirst = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblBid = New System.Windows.Forms.Label()
        Me.txtBid = New System.Windows.Forms.TextBox()
        Me.lblMayLoseMoney = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bwTimer2 = New System.ComponentModel.BackgroundWorker()
        Me.pnlRight.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbBid.SuspendLayout()
        Me.pnlAreYouSure.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRight
        '
        Me.pnlRight.BackColor = System.Drawing.Color.White
        Me.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRight.Controls.Add(Me.pnlLeft)
        Me.pnlRight.Location = New System.Drawing.Point(12, 12)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(1206, 600)
        Me.pnlRight.TabIndex = 65
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.White
        Me.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeft.Location = New System.Drawing.Point(3, 540)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(63, 55)
        Me.pnlLeft.TabIndex = 64
        Me.pnlLeft.Visible = False
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEarnings)
        Me.GroupBox1.Controls.Add(Me.txtPeriod)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1043, 618)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 127)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'txtEarnings
        '
        Me.txtEarnings.BackColor = System.Drawing.Color.White
        Me.txtEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEarnings.Location = New System.Drawing.Point(52, 90)
        Me.txtEarnings.Name = "txtEarnings"
        Me.txtEarnings.ReadOnly = True
        Me.txtEarnings.Size = New System.Drawing.Size(80, 26)
        Me.txtEarnings.TabIndex = 71
        Me.txtEarnings.TabStop = False
        Me.txtEarnings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.Color.White
        Me.txtPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.Location = New System.Drawing.Point(52, 38)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.ReadOnly = True
        Me.txtPeriod.Size = New System.Drawing.Size(80, 26)
        Me.txtPeriod.TabIndex = 70
        Me.txtPeriod.TabStop = False
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Earnings"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Period"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'gbBid
        '
        Me.gbBid.Controls.Add(Me.pnlAreYouSure)
        Me.gbBid.Controls.Add(Me.cmdSubmitFirst)
        Me.gbBid.Controls.Add(Me.Label5)
        Me.gbBid.Controls.Add(Me.txtValue)
        Me.gbBid.Controls.Add(Me.lblBid)
        Me.gbBid.Controls.Add(Me.txtBid)
        Me.gbBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBid.Location = New System.Drawing.Point(12, 618)
        Me.gbBid.Name = "gbBid"
        Me.gbBid.Size = New System.Drawing.Size(435, 127)
        Me.gbBid.TabIndex = 70
        Me.gbBid.TabStop = False
        Me.gbBid.Text = "Bid Submission"
        '
        'pnlAreYouSure
        '
        Me.pnlAreYouSure.Controls.Add(Me.cmdNo)
        Me.pnlAreYouSure.Controls.Add(Me.cmdSubmit)
        Me.pnlAreYouSure.Controls.Add(Me.lblAreYouSure)
        Me.pnlAreYouSure.Location = New System.Drawing.Point(220, 58)
        Me.pnlAreYouSure.Name = "pnlAreYouSure"
        Me.pnlAreYouSure.Size = New System.Drawing.Size(201, 63)
        Me.pnlAreYouSure.TabIndex = 78
        Me.pnlAreYouSure.Visible = False
        '
        'cmdNo
        '
        Me.cmdNo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNo.Location = New System.Drawing.Point(103, 24)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.Size = New System.Drawing.Size(94, 34)
        Me.cmdNo.TabIndex = 77
        Me.cmdNo.Text = "No"
        Me.cmdNo.UseVisualStyleBackColor = False
        '
        'cmdSubmit
        '
        Me.cmdSubmit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(3, 24)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(94, 34)
        Me.cmdSubmit.TabIndex = 76
        Me.cmdSubmit.Text = "Yes"
        Me.cmdSubmit.UseVisualStyleBackColor = False
        '
        'lblAreYouSure
        '
        Me.lblAreYouSure.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreYouSure.Location = New System.Drawing.Point(3, 3)
        Me.lblAreYouSure.Name = "lblAreYouSure"
        Me.lblAreYouSure.Size = New System.Drawing.Size(194, 20)
        Me.lblAreYouSure.TabIndex = 78
        Me.lblAreYouSure.Text = "Are You Sure?"
        Me.lblAreYouSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSubmitFirst
        '
        Me.cmdSubmitFirst.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdSubmitFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmitFirst.Location = New System.Drawing.Point(220, 15)
        Me.cmdSubmitFirst.Name = "cmdSubmitFirst"
        Me.cmdSubmitFirst.Size = New System.Drawing.Size(201, 40)
        Me.cmdSubmitFirst.TabIndex = 77
        Me.cmdSubmitFirst.Text = "Submit"
        Me.cmdSubmitFirst.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 22)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Value"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValue
        '
        Me.txtValue.BackColor = System.Drawing.Color.White
        Me.txtValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValue.Location = New System.Drawing.Point(109, 26)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.ReadOnly = True
        Me.txtValue.Size = New System.Drawing.Size(100, 29)
        Me.txtValue.TabIndex = 2
        Me.txtValue.TabStop = False
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBid
        '
        Me.lblBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBid.Location = New System.Drawing.Point(11, 68)
        Me.lblBid.Name = "lblBid"
        Me.lblBid.Size = New System.Drawing.Size(92, 53)
        Me.lblBid.TabIndex = 1
        Me.lblBid.Text = "My Bid" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to Buy"
        Me.lblBid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBid
        '
        Me.txtBid.BackColor = System.Drawing.Color.White
        Me.txtBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBid.Location = New System.Drawing.Point(109, 79)
        Me.txtBid.Name = "txtBid"
        Me.txtBid.Size = New System.Drawing.Size(100, 29)
        Me.txtBid.TabIndex = 0
        Me.txtBid.TabStop = False
        Me.txtBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMayLoseMoney
        '
        Me.lblMayLoseMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMayLoseMoney.ForeColor = System.Drawing.Color.Crimson
        Me.lblMayLoseMoney.Location = New System.Drawing.Point(453, 628)
        Me.lblMayLoseMoney.Name = "lblMayLoseMoney"
        Me.lblMayLoseMoney.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.lblMayLoseMoney.Size = New System.Drawing.Size(218, 111)
        Me.lblMayLoseMoney.TabIndex = 73
        Me.lblMayLoseMoney.Text = "You May Lose Money At This Price"
        Me.lblMayLoseMoney.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblMayLoseMoney.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(676, 618)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(361, 127)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Info"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(25, 93)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(24, 24)
        Me.Panel6.TabIndex = 84
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(54, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(290, 18)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "No Line: You Did Not Win the Auction"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel5.BackgroundImage = Global.ESI_Client_Template.My.Resources.Resources.red
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(25, 58)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(24, 24)
        Me.Panel5.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(54, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 18)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Your Loss"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel4.BackgroundImage = Global.ESI_Client_Template.My.Resources.Resources.green
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Location = New System.Drawing.Point(25, 23)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(24, 24)
        Me.Panel4.TabIndex = 80
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(54, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 18)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Your Profit"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3.BackgroundImage = Global.ESI_Client_Template.My.Resources.Resources.bid
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(195, 23)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(24, 24)
        Me.Panel3.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(224, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 18)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "My Bid to Buy"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.BackgroundImage = Global.ESI_Client_Template.My.Resources.Resources.x1
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(195, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(24, 24)
        Me.Panel1.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(224, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 18)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Price"
        '
        'bwTimer2
        '
        Me.bwTimer2.WorkerSupportsCancellation = True
        '
        'frmRealTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 750)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblMayLoseMoney)
        Me.Controls.Add(Me.gbBid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlRight)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRealTime"
        Me.Text = "Client"
        Me.pnlRight.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbBid.ResumeLayout(False)
        Me.gbBid.PerformLayout()
        Me.pnlAreYouSure.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlRight As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtEarnings As TextBox
    Friend WithEvents txtPeriod As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents gbBid As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtValue As TextBox
    Friend WithEvents lblBid As Label
    Friend WithEvents txtBid As TextBox
    Friend WithEvents lblMayLoseMoney As Label
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlAreYouSure As Panel
    Friend WithEvents cmdNo As Button
    Friend WithEvents cmdSubmit As Button
    Friend WithEvents lblAreYouSure As Label
    Friend WithEvents cmdSubmitFirst As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents bwTimer2 As System.ComponentModel.BackgroundWorker
End Class
