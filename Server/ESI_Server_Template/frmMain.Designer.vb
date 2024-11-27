<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bwTakeSocketConnections = New System.ComponentModel.BackgroundWorker()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdBegin = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.dgMain = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.cmdSetup5 = New System.Windows.Forms.Button()
        Me.cmdSetup4 = New System.Windows.Forms.Button()
        Me.cmdSetup3 = New System.Windows.Forms.Button()
        Me.cmdSetup2 = New System.Windows.Forms.Button()
        Me.cmdExchange = New System.Windows.Forms.Button()
        Me.cmdSetup1 = New System.Windows.Forms.Button()
        Me.cmdEndEarly = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblConnectionCount = New System.Windows.Forms.Label()
        Me.lblLocalHost = New System.Windows.Forms.Label()
        Me.lblIpAddress = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tbHistory = New System.Windows.Forms.TrackBar()
        Me.cmdReplay = New System.Windows.Forms.Button()
        Me.cbHistory = New System.Windows.Forms.CheckBox()
        Me.cbCurves = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTreatment = New System.Windows.Forms.TextBox()
        Me.pnlBackGround = New System.Windows.Forms.Panel()
        Me.txtPeriod1 = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtError = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMain = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.bwTimer2 = New System.ComponentModel.BackgroundWorker()
        Me.bwRefreshScreen = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbControl.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tbHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'bwTakeSocketConnections
        '
        Me.bwTakeSocketConnections.WorkerSupportsCancellation = True
        '
        'cmdReset
        '
        Me.cmdReset.Image = CType(resources.GetObject("cmdReset.Image"), System.Drawing.Image)
        Me.cmdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReset.Location = New System.Drawing.Point(6, 81)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(145, 59)
        Me.cmdReset.TabIndex = 1
        Me.cmdReset.Text = "          Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdBegin
        '
        Me.cmdBegin.Image = CType(resources.GetObject("cmdBegin.Image"), System.Drawing.Image)
        Me.cmdBegin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBegin.Location = New System.Drawing.Point(6, 16)
        Me.cmdBegin.Name = "cmdBegin"
        Me.cmdBegin.Size = New System.Drawing.Size(145, 59)
        Me.cmdBegin.TabIndex = 2
        Me.cmdBegin.Text = "          Begin"
        Me.cmdBegin.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1164, 857)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.cmdPrint)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.lbl2)
        Me.TabPage1.Controls.Add(Me.dgMain)
        Me.TabPage1.Controls.Add(Me.gbControl)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1156, 828)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        '
        'cmdPrint
        '
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(547, 782)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(79, 33)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print "
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(821, 779)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(324, 44)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Designed By: Cary Deck, Jeffrey Kirchner and Bart Wilson."
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.Location = New System.Drawing.Point(6, 791)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(234, 16)
        Me.lbl2.TabIndex = 11
        Me.lbl2.Text = "Programmed By: Jeffrey Kirchner"
        '
        'dgMain
        '
        Me.dgMain.AllowUserToAddRows = False
        Me.dgMain.AllowUserToDeleteRows = False
        Me.dgMain.AllowUserToResizeColumns = False
        Me.dgMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMain.ColumnHeadersHeight = 26
        Me.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgMain.Location = New System.Drawing.Point(6, 165)
        Me.dgMain.Name = "dgMain"
        Me.dgMain.ReadOnly = True
        Me.dgMain.RowHeadersVisible = False
        Me.dgMain.Size = New System.Drawing.Size(1142, 611)
        Me.dgMain.TabIndex = 10
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 50
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 600
        '
        'Column3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.HeaderText = "Status"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 275
        '
        'Column4
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column4.HeaderText = "Earnings"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 110
        '
        'gbControl
        '
        Me.gbControl.Controls.Add(Me.cmdSetup5)
        Me.gbControl.Controls.Add(Me.cmdSetup4)
        Me.gbControl.Controls.Add(Me.cmdSetup3)
        Me.gbControl.Controls.Add(Me.cmdSetup2)
        Me.gbControl.Controls.Add(Me.cmdExchange)
        Me.gbControl.Controls.Add(Me.cmdSetup1)
        Me.gbControl.Controls.Add(Me.cmdEndEarly)
        Me.gbControl.Controls.Add(Me.cmdExit)
        Me.gbControl.Controls.Add(Me.cmdLoad)
        Me.gbControl.Controls.Add(Me.cmdSave)
        Me.gbControl.Controls.Add(Me.cmdReset)
        Me.gbControl.Controls.Add(Me.cmdBegin)
        Me.gbControl.Location = New System.Drawing.Point(239, 6)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(909, 153)
        Me.gbControl.TabIndex = 9
        Me.gbControl.TabStop = False
        Me.gbControl.Text = "Control"
        '
        'cmdSetup5
        '
        Me.cmdSetup5.Image = CType(resources.GetObject("cmdSetup5.Image"), System.Drawing.Image)
        Me.cmdSetup5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSetup5.Location = New System.Drawing.Point(610, 81)
        Me.cmdSetup5.Name = "cmdSetup5"
        Me.cmdSetup5.Size = New System.Drawing.Size(145, 59)
        Me.cmdSetup5.TabIndex = 13
        Me.cmdSetup5.Text = "            Game  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "            Setup 3"
        Me.cmdSetup5.UseVisualStyleBackColor = True
        Me.cmdSetup5.Visible = False
        '
        'cmdSetup4
        '
        Me.cmdSetup4.Image = CType(resources.GetObject("cmdSetup4.Image"), System.Drawing.Image)
        Me.cmdSetup4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSetup4.Location = New System.Drawing.Point(459, 81)
        Me.cmdSetup4.Name = "cmdSetup4"
        Me.cmdSetup4.Size = New System.Drawing.Size(145, 59)
        Me.cmdSetup4.TabIndex = 12
        Me.cmdSetup4.Text = "           Game " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           Setup 3"
        Me.cmdSetup4.UseVisualStyleBackColor = True
        Me.cmdSetup4.Visible = False
        '
        'cmdSetup3
        '
        Me.cmdSetup3.Image = CType(resources.GetObject("cmdSetup3.Image"), System.Drawing.Image)
        Me.cmdSetup3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSetup3.Location = New System.Drawing.Point(459, 14)
        Me.cmdSetup3.Name = "cmdSetup3"
        Me.cmdSetup3.Size = New System.Drawing.Size(145, 59)
        Me.cmdSetup3.TabIndex = 11
        Me.cmdSetup3.Text = "           Player" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           Setup"
        Me.cmdSetup3.UseVisualStyleBackColor = True
        '
        'cmdSetup2
        '
        Me.cmdSetup2.Image = CType(resources.GetObject("cmdSetup2.Image"), System.Drawing.Image)
        Me.cmdSetup2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSetup2.Location = New System.Drawing.Point(308, 81)
        Me.cmdSetup2.Name = "cmdSetup2"
        Me.cmdSetup2.Size = New System.Drawing.Size(145, 59)
        Me.cmdSetup2.TabIndex = 10
        Me.cmdSetup2.Text = "           Period" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           Setup"
        Me.cmdSetup2.UseVisualStyleBackColor = True
        '
        'cmdExchange
        '
        Me.cmdExchange.Image = CType(resources.GetObject("cmdExchange.Image"), System.Drawing.Image)
        Me.cmdExchange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExchange.Location = New System.Drawing.Point(610, 14)
        Me.cmdExchange.Name = "cmdExchange"
        Me.cmdExchange.Size = New System.Drawing.Size(145, 59)
        Me.cmdExchange.TabIndex = 9
        Me.cmdExchange.Text = "             Exchange" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "             Rate"
        Me.cmdExchange.UseVisualStyleBackColor = True
        '
        'cmdSetup1
        '
        Me.cmdSetup1.Image = CType(resources.GetObject("cmdSetup1.Image"), System.Drawing.Image)
        Me.cmdSetup1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSetup1.Location = New System.Drawing.Point(308, 14)
        Me.cmdSetup1.Name = "cmdSetup1"
        Me.cmdSetup1.Size = New System.Drawing.Size(145, 59)
        Me.cmdSetup1.TabIndex = 8
        Me.cmdSetup1.Text = "           Game" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           Setup"
        Me.cmdSetup1.UseVisualStyleBackColor = True
        '
        'cmdEndEarly
        '
        Me.cmdEndEarly.Enabled = False
        Me.cmdEndEarly.Image = CType(resources.GetObject("cmdEndEarly.Image"), System.Drawing.Image)
        Me.cmdEndEarly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEndEarly.Location = New System.Drawing.Point(761, 14)
        Me.cmdEndEarly.Name = "cmdEndEarly"
        Me.cmdEndEarly.Size = New System.Drawing.Size(145, 59)
        Me.cmdEndEarly.TabIndex = 7
        Me.cmdEndEarly.Text = "          End" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "          Early"
        Me.cmdEndEarly.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(761, 81)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(145, 59)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "       Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.Image = CType(resources.GetObject("cmdLoad.Image"), System.Drawing.Image)
        Me.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLoad.Location = New System.Drawing.Point(157, 81)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(145, 59)
        Me.cmdLoad.TabIndex = 5
        Me.cmdLoad.Text = "          Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(157, 16)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(145, 59)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "           Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblConnectionCount)
        Me.GroupBox1.Controls.Add(Me.lblLocalHost)
        Me.GroupBox1.Controls.Add(Me.lblIpAddress)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbl1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 140)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'lblConnectionCount
        '
        Me.lblConnectionCount.BackColor = System.Drawing.Color.Transparent
        Me.lblConnectionCount.Location = New System.Drawing.Point(107, 90)
        Me.lblConnectionCount.Name = "lblConnectionCount"
        Me.lblConnectionCount.Size = New System.Drawing.Size(120, 18)
        Me.lblConnectionCount.TabIndex = 5
        Me.lblConnectionCount.Text = "000"
        Me.lblConnectionCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLocalHost
        '
        Me.lblLocalHost.BackColor = System.Drawing.Color.Transparent
        Me.lblLocalHost.Location = New System.Drawing.Point(107, 62)
        Me.lblLocalHost.Name = "lblLocalHost"
        Me.lblLocalHost.Size = New System.Drawing.Size(120, 18)
        Me.lblLocalHost.TabIndex = 4
        Me.lblLocalHost.Text = "Localhost"
        Me.lblLocalHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIpAddress
        '
        Me.lblIpAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblIpAddress.Location = New System.Drawing.Point(107, 34)
        Me.lblIpAddress.Name = "lblIpAddress"
        Me.lblIpAddress.Size = New System.Drawing.Size(120, 18)
        Me.lblIpAddress.TabIndex = 3
        Me.lblIpAddress.Text = "888.888.888.888"
        Me.lblIpAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Connections:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Host:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl1
        '
        Me.lbl1.Location = New System.Drawing.Point(7, 34)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(98, 18)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "IP Address:"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.tbHistory)
        Me.TabPage2.Controls.Add(Me.cmdReplay)
        Me.TabPage2.Controls.Add(Me.cbHistory)
        Me.TabPage2.Controls.Add(Me.cbCurves)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtTreatment)
        Me.TabPage2.Controls.Add(Me.pnlBackGround)
        Me.TabPage2.Controls.Add(Me.txtPeriod1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1156, 828)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Status"
        '
        'tbHistory
        '
        Me.tbHistory.Location = New System.Drawing.Point(329, 797)
        Me.tbHistory.Maximum = 100
        Me.tbHistory.Minimum = 1
        Me.tbHistory.Name = "tbHistory"
        Me.tbHistory.Size = New System.Drawing.Size(176, 45)
        Me.tbHistory.TabIndex = 57
        Me.tbHistory.TickFrequency = 5
        Me.tbHistory.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.tbHistory.Value = 10
        '
        'cmdReplay
        '
        Me.cmdReplay.Location = New System.Drawing.Point(22, 797)
        Me.cmdReplay.Name = "cmdReplay"
        Me.cmdReplay.Size = New System.Drawing.Size(81, 25)
        Me.cmdReplay.TabIndex = 56
        Me.cmdReplay.Text = "Replay"
        Me.cmdReplay.UseVisualStyleBackColor = True
        '
        'cbHistory
        '
        Me.cbHistory.AutoSize = True
        Me.cbHistory.Location = New System.Drawing.Point(217, 800)
        Me.cbHistory.Name = "cbHistory"
        Me.cbHistory.Size = New System.Drawing.Size(106, 20)
        Me.cbHistory.TabIndex = 55
        Me.cbHistory.Text = "History (10)"
        Me.cbHistory.UseVisualStyleBackColor = True
        '
        'cbCurves
        '
        Me.cbCurves.AutoSize = True
        Me.cbCurves.Location = New System.Drawing.Point(136, 800)
        Me.cbCurves.Name = "cbCurves"
        Me.cbCurves.Size = New System.Drawing.Size(75, 20)
        Me.cbCurves.TabIndex = 54
        Me.cbCurves.Text = "Curves"
        Me.cbCurves.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(787, 801)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Treatment"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1023, 801)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 16)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Period:"
        '
        'txtTreatment
        '
        Me.txtTreatment.BackColor = System.Drawing.Color.White
        Me.txtTreatment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTreatment.Location = New System.Drawing.Point(868, 798)
        Me.txtTreatment.Name = "txtTreatment"
        Me.txtTreatment.ReadOnly = True
        Me.txtTreatment.Size = New System.Drawing.Size(147, 22)
        Me.txtTreatment.TabIndex = 52
        Me.txtTreatment.Text = "-"
        Me.txtTreatment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnlBackGround
        '
        Me.pnlBackGround.BackColor = System.Drawing.Color.White
        Me.pnlBackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBackGround.Location = New System.Drawing.Point(6, 6)
        Me.pnlBackGround.Name = "pnlBackGround"
        Me.pnlBackGround.Size = New System.Drawing.Size(1142, 786)
        Me.pnlBackGround.TabIndex = 50
        '
        'txtPeriod1
        '
        Me.txtPeriod1.BackColor = System.Drawing.Color.White
        Me.txtPeriod1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod1.Location = New System.Drawing.Point(1084, 798)
        Me.txtPeriod1.Name = "txtPeriod1"
        Me.txtPeriod1.ReadOnly = True
        Me.txtPeriod1.Size = New System.Drawing.Size(64, 22)
        Me.txtPeriod1.TabIndex = 49
        Me.txtPeriod1.Text = "1"
        Me.txtPeriod1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.txtError)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.txtMain)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1156, 828)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Messages"
        '
        'txtError
        '
        Me.txtError.BackColor = System.Drawing.Color.White
        Me.txtError.Location = New System.Drawing.Point(658, 32)
        Me.txtError.Multiline = True
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtError.Size = New System.Drawing.Size(492, 790)
        Me.txtError.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(663, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Errors"
        '
        'txtMain
        '
        Me.txtMain.BackColor = System.Drawing.Color.White
        Me.txtMain.Location = New System.Drawing.Point(6, 32)
        Me.txtMain.Multiline = True
        Me.txtMain.Name = "txtMain"
        Me.txtMain.ReadOnly = True
        Me.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMain.Size = New System.Drawing.Size(646, 790)
        Me.txtMain.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Messages"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'Timer1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'bwTimer2
        '
        Me.bwTimer2.WorkerSupportsCancellation = True
        '
        'bwRefreshScreen
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 878)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Server"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbControl.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tbHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bwTakeSocketConnections As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdReset As Button
    Friend WithEvents cmdBegin As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgMain As DataGridView
    Friend WithEvents gbControl As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lblConnectionCount As Label
    Friend WithEvents lblLocalHost As Label
    Friend WithEvents lblIpAddress As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl1 As Label
    Friend WithEvents cmdEndEarly As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdLoad As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdSetup1 As Button
    Friend WithEvents cmdExchange As Button
    Friend WithEvents cmdSetup2 As Button
    Friend WithEvents cmdSetup3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl2 As Label
    Friend WithEvents cmdSetup4 As Button
    Friend WithEvents cmdPrint As Button
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label9 As Label
    Friend WithEvents pnlBackGround As Panel
    Friend WithEvents txtPeriod1 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents txtError As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMain As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents cmdSetup5 As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTreatment As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents bwTimer2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbCurves As CheckBox
    Friend WithEvents cbHistory As CheckBox
    Friend WithEvents bwRefreshScreen As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdReplay As Button
    Friend WithEvents tbHistory As TrackBar
End Class
