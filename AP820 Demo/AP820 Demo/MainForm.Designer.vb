<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnGetVersion = New System.Windows.Forms.Button
        Me.txtVersion = New System.Windows.Forms.TextBox
        Me.btnGetInfo = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtImageNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtImageNumber2 = New System.Windows.Forms.TextBox
        Me.lstEthernetScanInfo = New System.Windows.Forms.ListBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnGetInfoFromData = New System.Windows.Forms.Button
        Me.lstInfoFromDataBuffer = New System.Windows.Forms.ListBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnShowSecondLaserForm = New System.Windows.Forms.Button
        Me.chkSendToFile = New System.Windows.Forms.CheckBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.txtData = New System.Windows.Forms.TextBox
        Me.lblVersion = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.gbScansWithEncoder = New System.Windows.Forms.GroupBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.bthGetContinuousWithEnc = New System.Windows.Forms.Button
        Me.btnGetContinuousHardwareTriggeredWithEncoder = New System.Windows.Forms.Button
        Me.btnStopEncoder = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtEncoderPos = New System.Windows.Forms.TextBox
        Me.btnResetEncoder = New System.Windows.Forms.Button
        Me.gbLaserParams = New System.Windows.Forms.GroupBox
        Me.txtMinZ = New System.Windows.Forms.TextBox
        Me.txtMaxZ = New System.Windows.Forms.TextBox
        Me.btnSetMaxForZRange = New System.Windows.Forms.Button
        Me.btnSetMinForZRange = New System.Windows.Forms.Button
        Me.btnTurnOffALF = New System.Windows.Forms.Button
        Me.btnTurnOffLaser = New System.Windows.Forms.Button
        Me.btnTurnOnALF = New System.Windows.Forms.Button
        Me.btnTurnOnLaser = New System.Windows.Forms.Button
        Me.gbConnect = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnGetStatus = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.btnDisconnect = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.gpGetInfo = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.gbTriggerMode = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnContinuousMode = New System.Windows.Forms.Button
        Me.btnTriggerMode = New System.Windows.Forms.Button
        Me.gbContinuousModeScans = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSampleRate = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDropped = New System.Windows.Forms.TextBox
        Me.btnGetContinuousOptimized = New System.Windows.Forms.Button
        Me.btnStopContinuous = New System.Windows.Forms.Button
        Me.btnGetContinuousScans = New System.Windows.Forms.Button
        Me.btnSingleScan = New System.Windows.Forms.Button
        Me.btnGetInterleaved = New System.Windows.Forms.Button
        Me.gbTriggerModeScans = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.btnSendSoftwareTrigger = New System.Windows.Forms.Button
        Me.btnGetContinuousHardwareTriggeredScans = New System.Windows.Forms.Button
        Me.lblDataReceived = New System.Windows.Forms.Label
        Me.lblWaitingForTrigger = New System.Windows.Forms.Label
        Me.btnStopTrigger = New System.Windows.Forms.Button
        Me.btnSingleHardwareTrigger = New System.Windows.Forms.Button
        Me.btnSendTrigger = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.gbThickness = New System.Windows.Forms.GroupBox
        Me.btnGetGapScans = New System.Windows.Forms.Button
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.txtRightEdge = New System.Windows.Forms.TextBox
        Me.txtLeftEdge = New System.Windows.Forms.TextBox
        Me.btnStopContinuousRealWorldExampleScans = New System.Windows.Forms.Button
        Me.btnGetWidthContinuously = New System.Windows.Forms.Button
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtUpdateCount = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtThreshold = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.gbPeakCalc = New System.Windows.Forms.GroupBox
        Me.btnGetPeakScans = New System.Windows.Forms.Button
        Me.btnStopPeakScans = New System.Windows.Forms.Button
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtPeakPos = New System.Windows.Forms.TextBox
        Me.txtPeak = New System.Windows.Forms.TextBox
        Me.btnHoleDiameterMeasurement = New System.Windows.Forms.Button
        Me.GraphControl1 = New AP820_Demo.GraphControl
        Me.gbScansWithEncoder.SuspendLayout()
        Me.gbLaserParams.SuspendLayout()
        Me.gbConnect.SuspendLayout()
        Me.gpGetInfo.SuspendLayout()
        Me.gbTriggerMode.SuspendLayout()
        Me.gbContinuousModeScans.SuspendLayout()
        Me.gbTriggerModeScans.SuspendLayout()
        Me.gbThickness.SuspendLayout()
        Me.gbPeakCalc.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGetVersion
        '
        Me.btnGetVersion.Location = New System.Drawing.Point(1142, 53)
        Me.btnGetVersion.Name = "btnGetVersion"
        Me.btnGetVersion.Size = New System.Drawing.Size(178, 28)
        Me.btnGetVersion.TabIndex = 6
        Me.btnGetVersion.Text = "Get DLL Version"
        Me.btnGetVersion.UseVisualStyleBackColor = True
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(1217, 86)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(124, 20)
        Me.txtVersion.TabIndex = 7
        '
        'btnGetInfo
        '
        Me.btnGetInfo.Location = New System.Drawing.Point(6, 56)
        Me.btnGetInfo.Name = "btnGetInfo"
        Me.btnGetInfo.Size = New System.Drawing.Size(178, 28)
        Me.btnGetInfo.TabIndex = 14
        Me.btnGetInfo.Text = "Get Info"
        Me.btnGetInfo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1120, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "DLL Version:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(26, 373)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 36)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "First Image Number:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImageNumber
        '
        Me.txtImageNumber.Location = New System.Drawing.Point(93, 382)
        Me.txtImageNumber.Name = "txtImageNumber"
        Me.txtImageNumber.ReadOnly = True
        Me.txtImageNumber.Size = New System.Drawing.Size(124, 20)
        Me.txtImageNumber.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(220, 365)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 53)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Second Image Number for Interleaved Scans:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImageNumber2
        '
        Me.txtImageNumber2.Location = New System.Drawing.Point(329, 382)
        Me.txtImageNumber2.Name = "txtImageNumber2"
        Me.txtImageNumber2.ReadOnly = True
        Me.txtImageNumber2.Size = New System.Drawing.Size(124, 20)
        Me.txtImageNumber2.TabIndex = 30
        '
        'lstEthernetScanInfo
        '
        Me.lstEthernetScanInfo.FormattingEnabled = True
        Me.lstEthernetScanInfo.Location = New System.Drawing.Point(460, 125)
        Me.lstEthernetScanInfo.Name = "lstEthernetScanInfo"
        Me.lstEthernetScanInfo.Size = New System.Drawing.Size(233, 550)
        Me.lstEthernetScanInfo.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(459, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Ethernet Scan Info:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(936, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Data:"
        '
        'btnGetInfoFromData
        '
        Me.btnGetInfoFromData.Location = New System.Drawing.Point(221, 56)
        Me.btnGetInfoFromData.Name = "btnGetInfoFromData"
        Me.btnGetInfoFromData.Size = New System.Drawing.Size(178, 28)
        Me.btnGetInfoFromData.TabIndex = 46
        Me.btnGetInfoFromData.Text = "Get Info From Data Buffer"
        Me.btnGetInfoFromData.UseVisualStyleBackColor = True
        '
        'lstInfoFromDataBuffer
        '
        Me.lstInfoFromDataBuffer.FormattingEnabled = True
        Me.lstInfoFromDataBuffer.Location = New System.Drawing.Point(698, 125)
        Me.lstInfoFromDataBuffer.Name = "lstInfoFromDataBuffer"
        Me.lstInfoFromDataBuffer.Size = New System.Drawing.Size(233, 550)
        Me.lstInfoFromDataBuffer.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(695, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Info From Data Buffer:"
        '
        'btnShowSecondLaserForm
        '
        Me.btnShowSecondLaserForm.Location = New System.Drawing.Point(1116, 945)
        Me.btnShowSecondLaserForm.Name = "btnShowSecondLaserForm"
        Me.btnShowSecondLaserForm.Size = New System.Drawing.Size(178, 28)
        Me.btnShowSecondLaserForm.TabIndex = 59
        Me.btnShowSecondLaserForm.Text = "Show Second Laser Form"
        Me.btnShowSecondLaserForm.UseVisualStyleBackColor = True
        '
        'chkSendToFile
        '
        Me.chkSendToFile.AutoSize = True
        Me.chkSendToFile.Location = New System.Drawing.Point(538, 9)
        Me.chkSendToFile.Name = "chkSendToFile"
        Me.chkSendToFile.Size = New System.Drawing.Size(82, 17)
        Me.chkSendToFile.TabIndex = 60
        Me.chkSendToFile.Text = "Send to File"
        Me.chkSendToFile.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(538, 32)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(563, 20)
        Me.txtFileName.TabIndex = 61
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(471, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 36)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "File Name:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(538, 58)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(178, 28)
        Me.btnBrowse.TabIndex = 63
        Me.btnBrowse.Text = "Select File Name"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(937, 125)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.ReadOnly = True
        Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtData.Size = New System.Drawing.Size(165, 550)
        Me.txtData.TabIndex = 64
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(1214, 15)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(73, 13)
        Me.lblVersion.TabIndex = 65
        Me.lblVersion.Text = "v. 1.0.130411"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1029, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Intensity"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1001, 109)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "Z"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(951, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "X"
        '
        'gbScansWithEncoder
        '
        Me.gbScansWithEncoder.Controls.Add(Me.Label23)
        Me.gbScansWithEncoder.Controls.Add(Me.bthGetContinuousWithEnc)
        Me.gbScansWithEncoder.Controls.Add(Me.btnGetContinuousHardwareTriggeredWithEncoder)
        Me.gbScansWithEncoder.Controls.Add(Me.btnStopEncoder)
        Me.gbScansWithEncoder.Controls.Add(Me.Label11)
        Me.gbScansWithEncoder.Controls.Add(Me.txtEncoderPos)
        Me.gbScansWithEncoder.Controls.Add(Me.btnResetEncoder)
        Me.gbScansWithEncoder.Location = New System.Drawing.Point(20, 646)
        Me.gbScansWithEncoder.Name = "gbScansWithEncoder"
        Me.gbScansWithEncoder.Size = New System.Drawing.Size(434, 135)
        Me.gbScansWithEncoder.TabIndex = 89
        Me.gbScansWithEncoder.TabStop = False
        Me.gbScansWithEncoder.Text = "Scans with an Encoder"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(7, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(192, 13)
        Me.Label23.TabIndex = 89
        Me.Label23.Text = "Read encoder position with each scan."
        '
        'bthGetContinuousWithEnc
        '
        Me.bthGetContinuousWithEnc.Location = New System.Drawing.Point(8, 34)
        Me.bthGetContinuousWithEnc.Name = "bthGetContinuousWithEnc"
        Me.bthGetContinuousWithEnc.Size = New System.Drawing.Size(233, 28)
        Me.bthGetContinuousWithEnc.TabIndex = 88
        Me.bthGetContinuousWithEnc.Text = "Get Continuous Scans with Encoder"
        Me.bthGetContinuousWithEnc.UseVisualStyleBackColor = True
        '
        'btnGetContinuousHardwareTriggeredWithEncoder
        '
        Me.btnGetContinuousHardwareTriggeredWithEncoder.Location = New System.Drawing.Point(9, 68)
        Me.btnGetContinuousHardwareTriggeredWithEncoder.Name = "btnGetContinuousHardwareTriggeredWithEncoder"
        Me.btnGetContinuousHardwareTriggeredWithEncoder.Size = New System.Drawing.Size(233, 28)
        Me.btnGetContinuousHardwareTriggeredWithEncoder.TabIndex = 87
        Me.btnGetContinuousHardwareTriggeredWithEncoder.Text = "Get Continuous Triggered with Encoder"
        Me.btnGetContinuousHardwareTriggeredWithEncoder.UseVisualStyleBackColor = True
        '
        'btnStopEncoder
        '
        Me.btnStopEncoder.Location = New System.Drawing.Point(246, 34)
        Me.btnStopEncoder.Name = "btnStopEncoder"
        Me.btnStopEncoder.Size = New System.Drawing.Size(178, 28)
        Me.btnStopEncoder.TabIndex = 86
        Me.btnStopEncoder.Text = "Stop Scans with Encoder"
        Me.btnStopEncoder.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(248, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 36)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Encoder Position:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEncoderPos
        '
        Me.txtEncoderPos.Location = New System.Drawing.Point(312, 70)
        Me.txtEncoderPos.Name = "txtEncoderPos"
        Me.txtEncoderPos.ReadOnly = True
        Me.txtEncoderPos.Size = New System.Drawing.Size(74, 20)
        Me.txtEncoderPos.TabIndex = 58
        '
        'btnResetEncoder
        '
        Me.btnResetEncoder.Location = New System.Drawing.Point(246, 96)
        Me.btnResetEncoder.Name = "btnResetEncoder"
        Me.btnResetEncoder.Size = New System.Drawing.Size(178, 28)
        Me.btnResetEncoder.TabIndex = 57
        Me.btnResetEncoder.Text = "Reset Encoder"
        Me.btnResetEncoder.UseVisualStyleBackColor = True
        '
        'gbLaserParams
        '
        Me.gbLaserParams.Controls.Add(Me.txtMinZ)
        Me.gbLaserParams.Controls.Add(Me.txtMaxZ)
        Me.gbLaserParams.Controls.Add(Me.btnSetMaxForZRange)
        Me.gbLaserParams.Controls.Add(Me.btnSetMinForZRange)
        Me.gbLaserParams.Controls.Add(Me.btnTurnOffALF)
        Me.gbLaserParams.Controls.Add(Me.btnTurnOffLaser)
        Me.gbLaserParams.Controls.Add(Me.btnTurnOnALF)
        Me.gbLaserParams.Controls.Add(Me.btnTurnOnLaser)
        Me.gbLaserParams.Location = New System.Drawing.Point(1108, 125)
        Me.gbLaserParams.Name = "gbLaserParams"
        Me.gbLaserParams.Size = New System.Drawing.Size(253, 234)
        Me.gbLaserParams.TabIndex = 90
        Me.gbLaserParams.TabStop = False
        Me.gbLaserParams.Text = "Laser Control Parameters"
        '
        'txtMinZ
        '
        Me.txtMinZ.Location = New System.Drawing.Point(204, 167)
        Me.txtMinZ.Name = "txtMinZ"
        Me.txtMinZ.Size = New System.Drawing.Size(43, 20)
        Me.txtMinZ.TabIndex = 58
        Me.txtMinZ.Text = "0.0"
        '
        'txtMaxZ
        '
        Me.txtMaxZ.Location = New System.Drawing.Point(204, 201)
        Me.txtMaxZ.Name = "txtMaxZ"
        Me.txtMaxZ.Size = New System.Drawing.Size(43, 20)
        Me.txtMaxZ.TabIndex = 57
        Me.txtMaxZ.Text = "0.0"
        '
        'btnSetMaxForZRange
        '
        Me.btnSetMaxForZRange.Location = New System.Drawing.Point(6, 196)
        Me.btnSetMaxForZRange.Name = "btnSetMaxForZRange"
        Me.btnSetMaxForZRange.Size = New System.Drawing.Size(178, 28)
        Me.btnSetMaxForZRange.TabIndex = 56
        Me.btnSetMaxForZRange.Text = "Set Maximum for Z Range"
        Me.btnSetMaxForZRange.UseVisualStyleBackColor = True
        '
        'btnSetMinForZRange
        '
        Me.btnSetMinForZRange.Location = New System.Drawing.Point(6, 162)
        Me.btnSetMinForZRange.Name = "btnSetMinForZRange"
        Me.btnSetMinForZRange.Size = New System.Drawing.Size(178, 28)
        Me.btnSetMinForZRange.TabIndex = 55
        Me.btnSetMinForZRange.Text = "Set Minimum for Z Range"
        Me.btnSetMinForZRange.UseVisualStyleBackColor = True
        '
        'btnTurnOffALF
        '
        Me.btnTurnOffALF.Location = New System.Drawing.Point(6, 124)
        Me.btnTurnOffALF.Name = "btnTurnOffALF"
        Me.btnTurnOffALF.Size = New System.Drawing.Size(178, 28)
        Me.btnTurnOffALF.TabIndex = 48
        Me.btnTurnOffALF.Text = "Turn Off Ambient Light Filter"
        Me.btnTurnOffALF.UseVisualStyleBackColor = True
        '
        'btnTurnOffLaser
        '
        Me.btnTurnOffLaser.Location = New System.Drawing.Point(6, 53)
        Me.btnTurnOffLaser.Name = "btnTurnOffLaser"
        Me.btnTurnOffLaser.Size = New System.Drawing.Size(178, 28)
        Me.btnTurnOffLaser.TabIndex = 47
        Me.btnTurnOffLaser.Text = "Turn Off Laser"
        Me.btnTurnOffLaser.UseVisualStyleBackColor = True
        '
        'btnTurnOnALF
        '
        Me.btnTurnOnALF.Location = New System.Drawing.Point(6, 90)
        Me.btnTurnOnALF.Name = "btnTurnOnALF"
        Me.btnTurnOnALF.Size = New System.Drawing.Size(178, 28)
        Me.btnTurnOnALF.TabIndex = 46
        Me.btnTurnOnALF.Text = "Turn On Ambient Light Filter"
        Me.btnTurnOnALF.UseVisualStyleBackColor = True
        '
        'btnTurnOnLaser
        '
        Me.btnTurnOnLaser.Location = New System.Drawing.Point(6, 19)
        Me.btnTurnOnLaser.Name = "btnTurnOnLaser"
        Me.btnTurnOnLaser.Size = New System.Drawing.Size(178, 28)
        Me.btnTurnOnLaser.TabIndex = 45
        Me.btnTurnOnLaser.Text = "Turn On Laser"
        Me.btnTurnOnLaser.UseVisualStyleBackColor = True
        '
        'gbConnect
        '
        Me.gbConnect.Controls.Add(Me.Label17)
        Me.gbConnect.Controls.Add(Me.btnGetStatus)
        Me.gbConnect.Controls.Add(Me.Label6)
        Me.gbConnect.Controls.Add(Me.txtStatus)
        Me.gbConnect.Controls.Add(Me.btnDisconnect)
        Me.gbConnect.Controls.Add(Me.Label2)
        Me.gbConnect.Controls.Add(Me.txtPort)
        Me.gbConnect.Controls.Add(Me.Label1)
        Me.gbConnect.Controls.Add(Me.txtIPAddress)
        Me.gbConnect.Controls.Add(Me.btnConnect)
        Me.gbConnect.Location = New System.Drawing.Point(19, 9)
        Me.gbConnect.Name = "gbConnect"
        Me.gbConnect.Size = New System.Drawing.Size(434, 162)
        Me.gbConnect.TabIndex = 91
        Me.gbConnect.TabStop = False
        Me.gbConnect.Text = "Connect with Laser"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(13, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(382, 26)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Step 1:  Call the Connect function, and call GetConnectStatus to ensure that Conn" & _
            "ect succeeded."
        '
        'btnGetStatus
        '
        Me.btnGetStatus.Location = New System.Drawing.Point(9, 118)
        Me.btnGetStatus.Name = "btnGetStatus"
        Me.btnGetStatus.Size = New System.Drawing.Size(178, 28)
        Me.btnGetStatus.TabIndex = 34
        Me.btnGetStatus.Text = "Get Connection Status"
        Me.btnGetStatus.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(211, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 36)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Connection Status:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(278, 123)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(124, 20)
        Me.txtStatus.TabIndex = 32
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(224, 48)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(178, 28)
        Me.btnDisconnect.TabIndex = 31
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Port:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(278, 86)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(124, 20)
        Me.txtPort.TabIndex = 29
        Me.txtPort.Text = "3000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "IP Address:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(84, 90)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(100, 20)
        Me.txtIPAddress.TabIndex = 27
        Me.txtIPAddress.Text = "192.168.123.222"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(9, 48)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(178, 28)
        Me.btnConnect.TabIndex = 26
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'gpGetInfo
        '
        Me.gpGetInfo.Controls.Add(Me.Label18)
        Me.gpGetInfo.Controls.Add(Me.btnGetInfoFromData)
        Me.gpGetInfo.Controls.Add(Me.btnGetInfo)
        Me.gpGetInfo.Location = New System.Drawing.Point(20, 177)
        Me.gpGetInfo.Name = "gpGetInfo"
        Me.gpGetInfo.Size = New System.Drawing.Size(433, 94)
        Me.gpGetInfo.TabIndex = 92
        Me.gpGetInfo.TabStop = False
        Me.gpGetInfo.Text = "Get Laser Parameters"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(14, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(371, 34)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Step 2:  Call the GetInfo function to get parameters from the laser required in c" & _
            "alculations, and to ensure the laser has the desired settings."
        '
        'gbTriggerMode
        '
        Me.gbTriggerMode.Controls.Add(Me.Label19)
        Me.gbTriggerMode.Controls.Add(Me.btnContinuousMode)
        Me.gbTriggerMode.Controls.Add(Me.btnTriggerMode)
        Me.gbTriggerMode.Location = New System.Drawing.Point(19, 277)
        Me.gbTriggerMode.Name = "gbTriggerMode"
        Me.gbTriggerMode.Size = New System.Drawing.Size(435, 82)
        Me.gbTriggerMode.TabIndex = 93
        Me.gbTriggerMode.TabStop = False
        Me.gbTriggerMode.Text = "Trigger or Continuous mode"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(15, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(231, 22)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Step 3:  Put laser in trigger mode, if desired."
        '
        'btnContinuousMode
        '
        Me.btnContinuousMode.Location = New System.Drawing.Point(224, 41)
        Me.btnContinuousMode.Name = "btnContinuousMode"
        Me.btnContinuousMode.Size = New System.Drawing.Size(178, 28)
        Me.btnContinuousMode.TabIndex = 19
        Me.btnContinuousMode.Text = "Put in Continuous Mode"
        Me.btnContinuousMode.UseVisualStyleBackColor = True
        '
        'btnTriggerMode
        '
        Me.btnTriggerMode.Location = New System.Drawing.Point(7, 41)
        Me.btnTriggerMode.Name = "btnTriggerMode"
        Me.btnTriggerMode.Size = New System.Drawing.Size(178, 28)
        Me.btnTriggerMode.TabIndex = 18
        Me.btnTriggerMode.Text = "Put in Trigger Mode"
        Me.btnTriggerMode.UseVisualStyleBackColor = True
        '
        'gbContinuousModeScans
        '
        Me.gbContinuousModeScans.Controls.Add(Me.Label22)
        Me.gbContinuousModeScans.Controls.Add(Me.Label21)
        Me.gbContinuousModeScans.Controls.Add(Me.Label20)
        Me.gbContinuousModeScans.Controls.Add(Me.Label16)
        Me.gbContinuousModeScans.Controls.Add(Me.txtSampleRate)
        Me.gbContinuousModeScans.Controls.Add(Me.Label9)
        Me.gbContinuousModeScans.Controls.Add(Me.txtDropped)
        Me.gbContinuousModeScans.Controls.Add(Me.btnGetContinuousOptimized)
        Me.gbContinuousModeScans.Controls.Add(Me.btnStopContinuous)
        Me.gbContinuousModeScans.Controls.Add(Me.btnGetContinuousScans)
        Me.gbContinuousModeScans.Controls.Add(Me.btnSingleScan)
        Me.gbContinuousModeScans.Controls.Add(Me.btnGetInterleaved)
        Me.gbContinuousModeScans.Location = New System.Drawing.Point(21, 421)
        Me.gbContinuousModeScans.Name = "gbContinuousModeScans"
        Me.gbContinuousModeScans.Size = New System.Drawing.Size(434, 219)
        Me.gbContinuousModeScans.TabIndex = 94
        Me.gbContinuousModeScans.TabStop = False
        Me.gbContinuousModeScans.Text = "Get Scans in Continuous Mode"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 131)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(289, 13)
        Me.Label22.TabIndex = 99
        Me.Label22.Text = "or, optimize for speed, eliminating graphing or string displays."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 68)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(140, 13)
        Me.Label21.TabIndex = 98
        Me.Label21.Text = "or, acquire scans in a loop..."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(269, 13)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Simply get the latest scan, or interleaved pair of scans..."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(225, 196)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 13)
        Me.Label16.TabIndex = 96
        Me.Label16.Text = "Effective Sample Rate:"
        '
        'txtSampleRate
        '
        Me.txtSampleRate.Location = New System.Drawing.Point(344, 193)
        Me.txtSampleRate.Name = "txtSampleRate"
        Me.txtSampleRate.ReadOnly = True
        Me.txtSampleRate.Size = New System.Drawing.Size(58, 20)
        Me.txtSampleRate.TabIndex = 95
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(277, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 36)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Dropped Scans:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDropped
        '
        Me.txtDropped.Location = New System.Drawing.Point(344, 161)
        Me.txtDropped.Name = "txtDropped"
        Me.txtDropped.ReadOnly = True
        Me.txtDropped.Size = New System.Drawing.Size(58, 20)
        Me.txtDropped.TabIndex = 93
        '
        'btnGetContinuousOptimized
        '
        Me.btnGetContinuousOptimized.Location = New System.Drawing.Point(9, 156)
        Me.btnGetContinuousOptimized.Name = "btnGetContinuousOptimized"
        Me.btnGetContinuousOptimized.Size = New System.Drawing.Size(233, 28)
        Me.btnGetContinuousOptimized.TabIndex = 92
        Me.btnGetContinuousOptimized.Text = "Get Continuous Scans Optimized for Speed"
        Me.btnGetContinuousOptimized.UseVisualStyleBackColor = True
        '
        'btnStopContinuous
        '
        Me.btnStopContinuous.Location = New System.Drawing.Point(224, 88)
        Me.btnStopContinuous.Name = "btnStopContinuous"
        Me.btnStopContinuous.Size = New System.Drawing.Size(178, 28)
        Me.btnStopContinuous.TabIndex = 91
        Me.btnStopContinuous.Text = "Stop Continuous Scans"
        Me.btnStopContinuous.UseVisualStyleBackColor = True
        '
        'btnGetContinuousScans
        '
        Me.btnGetContinuousScans.Location = New System.Drawing.Point(9, 88)
        Me.btnGetContinuousScans.Name = "btnGetContinuousScans"
        Me.btnGetContinuousScans.Size = New System.Drawing.Size(178, 28)
        Me.btnGetContinuousScans.TabIndex = 90
        Me.btnGetContinuousScans.Text = "Get Continuous Scans"
        Me.btnGetContinuousScans.UseVisualStyleBackColor = True
        '
        'btnSingleScan
        '
        Me.btnSingleScan.Location = New System.Drawing.Point(8, 32)
        Me.btnSingleScan.Name = "btnSingleScan"
        Me.btnSingleScan.Size = New System.Drawing.Size(178, 28)
        Me.btnSingleScan.TabIndex = 89
        Me.btnSingleScan.Text = "Get Single Scan"
        Me.btnSingleScan.UseVisualStyleBackColor = True
        '
        'btnGetInterleaved
        '
        Me.btnGetInterleaved.Location = New System.Drawing.Point(224, 32)
        Me.btnGetInterleaved.Name = "btnGetInterleaved"
        Me.btnGetInterleaved.Size = New System.Drawing.Size(178, 28)
        Me.btnGetInterleaved.TabIndex = 88
        Me.btnGetInterleaved.Text = "Get Interleaved Scan"
        Me.btnGetInterleaved.UseVisualStyleBackColor = True
        '
        'gbTriggerModeScans
        '
        Me.gbTriggerModeScans.Controls.Add(Me.Label25)
        Me.gbTriggerModeScans.Controls.Add(Me.Label24)
        Me.gbTriggerModeScans.Controls.Add(Me.btnSendSoftwareTrigger)
        Me.gbTriggerModeScans.Controls.Add(Me.btnGetContinuousHardwareTriggeredScans)
        Me.gbTriggerModeScans.Controls.Add(Me.lblDataReceived)
        Me.gbTriggerModeScans.Controls.Add(Me.lblWaitingForTrigger)
        Me.gbTriggerModeScans.Controls.Add(Me.btnStopTrigger)
        Me.gbTriggerModeScans.Controls.Add(Me.btnSingleHardwareTrigger)
        Me.gbTriggerModeScans.Controls.Add(Me.btnSendTrigger)
        Me.gbTriggerModeScans.Location = New System.Drawing.Point(20, 790)
        Me.gbTriggerModeScans.Name = "gbTriggerModeScans"
        Me.gbTriggerModeScans.Size = New System.Drawing.Size(435, 183)
        Me.gbTriggerModeScans.TabIndex = 95
        Me.gbTriggerModeScans.TabStop = False
        Me.gbTriggerModeScans.Text = "Get Scans in Trigger Mode"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(10, 132)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(136, 13)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Get scan with every trigger."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(295, 13)
        Me.Label24.TabIndex = 58
        Me.Label24.Text = "Get scan when the next trigger occurs, software or hardware."
        '
        'btnSendSoftwareTrigger
        '
        Me.btnSendSoftwareTrigger.Location = New System.Drawing.Point(228, 42)
        Me.btnSendSoftwareTrigger.Name = "btnSendSoftwareTrigger"
        Me.btnSendSoftwareTrigger.Size = New System.Drawing.Size(178, 28)
        Me.btnSendSoftwareTrigger.TabIndex = 57
        Me.btnSendSoftwareTrigger.Text = "Generate Software Trigger"
        Me.btnSendSoftwareTrigger.UseVisualStyleBackColor = True
        '
        'btnGetContinuousHardwareTriggeredScans
        '
        Me.btnGetContinuousHardwareTriggeredScans.Location = New System.Drawing.Point(12, 148)
        Me.btnGetContinuousHardwareTriggeredScans.Name = "btnGetContinuousHardwareTriggeredScans"
        Me.btnGetContinuousHardwareTriggeredScans.Size = New System.Drawing.Size(233, 28)
        Me.btnGetContinuousHardwareTriggeredScans.TabIndex = 56
        Me.btnGetContinuousHardwareTriggeredScans.Text = "Get Continuous Hardware-Triggered Scans"
        Me.btnGetContinuousHardwareTriggeredScans.UseVisualStyleBackColor = True
        '
        'lblDataReceived
        '
        Me.lblDataReceived.AutoSize = True
        Me.lblDataReceived.Location = New System.Drawing.Point(19, 76)
        Me.lblDataReceived.Name = "lblDataReceived"
        Me.lblDataReceived.Size = New System.Drawing.Size(79, 13)
        Me.lblDataReceived.TabIndex = 55
        Me.lblDataReceived.Text = "Data Received"
        Me.lblDataReceived.Visible = False
        '
        'lblWaitingForTrigger
        '
        Me.lblWaitingForTrigger.AutoSize = True
        Me.lblWaitingForTrigger.ForeColor = System.Drawing.Color.Red
        Me.lblWaitingForTrigger.Location = New System.Drawing.Point(19, 76)
        Me.lblWaitingForTrigger.Name = "lblWaitingForTrigger"
        Me.lblWaitingForTrigger.Size = New System.Drawing.Size(152, 13)
        Me.lblWaitingForTrigger.TabIndex = 54
        Me.lblWaitingForTrigger.Text = "Waiting for Hardware Trigger..."
        Me.lblWaitingForTrigger.Visible = False
        '
        'btnStopTrigger
        '
        Me.btnStopTrigger.Location = New System.Drawing.Point(228, 92)
        Me.btnStopTrigger.Name = "btnStopTrigger"
        Me.btnStopTrigger.Size = New System.Drawing.Size(178, 28)
        Me.btnStopTrigger.TabIndex = 53
        Me.btnStopTrigger.Text = "Stop Hardware-Triggered Scan"
        Me.btnStopTrigger.UseVisualStyleBackColor = True
        '
        'btnSingleHardwareTrigger
        '
        Me.btnSingleHardwareTrigger.Location = New System.Drawing.Point(13, 92)
        Me.btnSingleHardwareTrigger.Name = "btnSingleHardwareTrigger"
        Me.btnSingleHardwareTrigger.Size = New System.Drawing.Size(178, 28)
        Me.btnSingleHardwareTrigger.TabIndex = 52
        Me.btnSingleHardwareTrigger.Text = "Get Hardware-Triggered Scan"
        Me.btnSingleHardwareTrigger.UseVisualStyleBackColor = True
        '
        'btnSendTrigger
        '
        Me.btnSendTrigger.Location = New System.Drawing.Point(12, 42)
        Me.btnSendTrigger.Name = "btnSendTrigger"
        Me.btnSendTrigger.Size = New System.Drawing.Size(178, 28)
        Me.btnSendTrigger.TabIndex = 51
        Me.btnSendTrigger.Text = "Get Software Triggered Scan"
        Me.btnSendTrigger.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(626, 10)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(315, 13)
        Me.Label26.TabIndex = 96
        Me.Label26.Text = "When checked, all scan functions will stream to the indicated file."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1113, 929)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 13)
        Me.Label27.TabIndex = 97
        Me.Label27.Text = "Multiple Laser Scans"
        '
        'gbThickness
        '
        Me.gbThickness.Controls.Add(Me.btnGetGapScans)
        Me.gbThickness.Controls.Add(Me.Label33)
        Me.gbThickness.Controls.Add(Me.Label32)
        Me.gbThickness.Controls.Add(Me.Label31)
        Me.gbThickness.Controls.Add(Me.txtWidth)
        Me.gbThickness.Controls.Add(Me.txtRightEdge)
        Me.gbThickness.Controls.Add(Me.txtLeftEdge)
        Me.gbThickness.Controls.Add(Me.btnStopContinuousRealWorldExampleScans)
        Me.gbThickness.Controls.Add(Me.btnGetWidthContinuously)
        Me.gbThickness.Controls.Add(Me.Label30)
        Me.gbThickness.Controls.Add(Me.Label29)
        Me.gbThickness.Controls.Add(Me.txtUpdateCount)
        Me.gbThickness.Controls.Add(Me.Label28)
        Me.gbThickness.Controls.Add(Me.txtThreshold)
        Me.gbThickness.Location = New System.Drawing.Point(1110, 398)
        Me.gbThickness.Name = "gbThickness"
        Me.gbThickness.Size = New System.Drawing.Size(253, 289)
        Me.gbThickness.TabIndex = 98
        Me.gbThickness.TabStop = False
        Me.gbThickness.Text = "Width / Gap Measurement"
        '
        'btnGetGapScans
        '
        Me.btnGetGapScans.Location = New System.Drawing.Point(26, 128)
        Me.btnGetGapScans.Name = "btnGetGapScans"
        Me.btnGetGapScans.Size = New System.Drawing.Size(178, 28)
        Me.btnGetGapScans.TabIndex = 100
        Me.btnGetGapScans.Text = "Get Gap Continuously"
        Me.btnGetGapScans.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(67, 260)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(73, 13)
        Me.Label33.TabIndex = 99
        Me.Label33.Text = "Gap or Width:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(77, 231)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(63, 13)
        Me.Label32.TabIndex = 98
        Me.Label32.Text = "Right Edge:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(84, 203)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 97
        Me.Label31.Text = "Left Edge:"
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(146, 257)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.ReadOnly = True
        Me.txtWidth.Size = New System.Drawing.Size(58, 20)
        Me.txtWidth.TabIndex = 96
        '
        'txtRightEdge
        '
        Me.txtRightEdge.Location = New System.Drawing.Point(146, 228)
        Me.txtRightEdge.Name = "txtRightEdge"
        Me.txtRightEdge.ReadOnly = True
        Me.txtRightEdge.Size = New System.Drawing.Size(58, 20)
        Me.txtRightEdge.TabIndex = 95
        '
        'txtLeftEdge
        '
        Me.txtLeftEdge.Location = New System.Drawing.Point(146, 200)
        Me.txtLeftEdge.Name = "txtLeftEdge"
        Me.txtLeftEdge.ReadOnly = True
        Me.txtLeftEdge.Size = New System.Drawing.Size(58, 20)
        Me.txtLeftEdge.TabIndex = 94
        '
        'btnStopContinuousRealWorldExampleScans
        '
        Me.btnStopContinuousRealWorldExampleScans.Location = New System.Drawing.Point(26, 163)
        Me.btnStopContinuousRealWorldExampleScans.Name = "btnStopContinuousRealWorldExampleScans"
        Me.btnStopContinuousRealWorldExampleScans.Size = New System.Drawing.Size(178, 28)
        Me.btnStopContinuousRealWorldExampleScans.TabIndex = 92
        Me.btnStopContinuousRealWorldExampleScans.Text = "Stop Continuous Scans"
        Me.btnStopContinuousRealWorldExampleScans.UseVisualStyleBackColor = True
        '
        'btnGetWidthContinuously
        '
        Me.btnGetWidthContinuously.Location = New System.Drawing.Point(26, 94)
        Me.btnGetWidthContinuously.Name = "btnGetWidthContinuously"
        Me.btnGetWidthContinuously.Size = New System.Drawing.Size(178, 28)
        Me.btnGetWidthContinuously.TabIndex = 91
        Me.btnGetWidthContinuously.Text = "Get Width Continuously"
        Me.btnGetWidthContinuously.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(193, 66)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 13)
        Me.Label30.TabIndex = 6
        Me.Label30.Text = "ms"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 66)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(115, 13)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Delay Between Scans:"
        '
        'txtUpdateCount
        '
        Me.txtUpdateCount.Location = New System.Drawing.Point(129, 63)
        Me.txtUpdateCount.Name = "txtUpdateCount"
        Me.txtUpdateCount.Size = New System.Drawing.Size(57, 20)
        Me.txtUpdateCount.TabIndex = 4
        Me.txtUpdateCount.Text = "300"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(24, 20)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(99, 39)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Height Threshold for Gap/Width Measurements:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtThreshold
        '
        Me.txtThreshold.Location = New System.Drawing.Point(129, 36)
        Me.txtThreshold.Name = "txtThreshold"
        Me.txtThreshold.Size = New System.Drawing.Size(57, 20)
        Me.txtThreshold.TabIndex = 2
        Me.txtThreshold.Text = "1.0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(1120, 382)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(127, 13)
        Me.Label34.TabIndex = 99
        Me.Label34.Text = "Real World Examples"
        '
        'gbPeakCalc
        '
        Me.gbPeakCalc.Controls.Add(Me.btnGetPeakScans)
        Me.gbPeakCalc.Controls.Add(Me.btnStopPeakScans)
        Me.gbPeakCalc.Controls.Add(Me.Label36)
        Me.gbPeakCalc.Controls.Add(Me.Label35)
        Me.gbPeakCalc.Controls.Add(Me.txtPeakPos)
        Me.gbPeakCalc.Controls.Add(Me.txtPeak)
        Me.gbPeakCalc.Location = New System.Drawing.Point(1114, 707)
        Me.gbPeakCalc.Name = "gbPeakCalc"
        Me.gbPeakCalc.Size = New System.Drawing.Size(247, 177)
        Me.gbPeakCalc.TabIndex = 100
        Me.gbPeakCalc.TabStop = False
        Me.gbPeakCalc.Text = "Peak Calculation"
        '
        'btnGetPeakScans
        '
        Me.btnGetPeakScans.Location = New System.Drawing.Point(28, 19)
        Me.btnGetPeakScans.Name = "btnGetPeakScans"
        Me.btnGetPeakScans.Size = New System.Drawing.Size(178, 28)
        Me.btnGetPeakScans.TabIndex = 101
        Me.btnGetPeakScans.Text = "Get Peak Height and Position "
        Me.btnGetPeakScans.UseVisualStyleBackColor = True
        '
        'btnStopPeakScans
        '
        Me.btnStopPeakScans.Location = New System.Drawing.Point(28, 53)
        Me.btnStopPeakScans.Name = "btnStopPeakScans"
        Me.btnStopPeakScans.Size = New System.Drawing.Size(178, 28)
        Me.btnStopPeakScans.TabIndex = 100
        Me.btnStopPeakScans.Text = "Stop Continuous Scans"
        Me.btnStopPeakScans.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(58, 154)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(75, 13)
        Me.Label36.TabIndex = 99
        Me.Label36.Text = "Peak Position:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(100, 128)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(35, 13)
        Me.Label35.TabIndex = 98
        Me.Label35.Text = "Peak:"
        '
        'txtPeakPos
        '
        Me.txtPeakPos.Location = New System.Drawing.Point(142, 151)
        Me.txtPeakPos.Name = "txtPeakPos"
        Me.txtPeakPos.ReadOnly = True
        Me.txtPeakPos.Size = New System.Drawing.Size(58, 20)
        Me.txtPeakPos.TabIndex = 96
        '
        'txtPeak
        '
        Me.txtPeak.Location = New System.Drawing.Point(142, 125)
        Me.txtPeak.Name = "txtPeak"
        Me.txtPeak.ReadOnly = True
        Me.txtPeak.Size = New System.Drawing.Size(58, 20)
        Me.txtPeak.TabIndex = 95
        '
        'btnHoleDiameterMeasurement
        '
        Me.btnHoleDiameterMeasurement.Location = New System.Drawing.Point(1142, 890)
        Me.btnHoleDiameterMeasurement.Name = "btnHoleDiameterMeasurement"
        Me.btnHoleDiameterMeasurement.Size = New System.Drawing.Size(178, 28)
        Me.btnHoleDiameterMeasurement.TabIndex = 102
        Me.btnHoleDiameterMeasurement.Text = "Hole Diameter Measurement"
        Me.btnHoleDiameterMeasurement.UseVisualStyleBackColor = True
        '
        'GraphControl1
        '
        Me.GraphControl1.Location = New System.Drawing.Point(461, 681)
        Me.GraphControl1.Name = "GraphControl1"
        Me.GraphControl1.Size = New System.Drawing.Size(643, 292)
        Me.GraphControl1.TabIndex = 88
        Me.GraphControl1.Text = "GraphControl1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1366, 980)
        Me.Controls.Add(Me.btnHoleDiameterMeasurement)
        Me.Controls.Add(Me.gbPeakCalc)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.gbThickness)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.gbTriggerModeScans)
        Me.Controls.Add(Me.gbContinuousModeScans)
        Me.Controls.Add(Me.gbTriggerMode)
        Me.Controls.Add(Me.gpGetInfo)
        Me.Controls.Add(Me.gbConnect)
        Me.Controls.Add(Me.gbLaserParams)
        Me.Controls.Add(Me.gbScansWithEncoder)
        Me.Controls.Add(Me.GraphControl1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.chkSendToFile)
        Me.Controls.Add(Me.btnShowSecondLaserForm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lstInfoFromDataBuffer)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lstEthernetScanInfo)
        Me.Controls.Add(Me.txtImageNumber2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtImageNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.btnGetVersion)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acuity AP820 Quick-Start Code Development and Scanner Training Kit"
        Me.gbScansWithEncoder.ResumeLayout(False)
        Me.gbScansWithEncoder.PerformLayout()
        Me.gbLaserParams.ResumeLayout(False)
        Me.gbLaserParams.PerformLayout()
        Me.gbConnect.ResumeLayout(False)
        Me.gbConnect.PerformLayout()
        Me.gpGetInfo.ResumeLayout(False)
        Me.gbTriggerMode.ResumeLayout(False)
        Me.gbContinuousModeScans.ResumeLayout(False)
        Me.gbContinuousModeScans.PerformLayout()
        Me.gbTriggerModeScans.ResumeLayout(False)
        Me.gbTriggerModeScans.PerformLayout()
        Me.gbThickness.ResumeLayout(False)
        Me.gbThickness.PerformLayout()
        Me.gbPeakCalc.ResumeLayout(False)
        Me.gbPeakCalc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGetVersion As System.Windows.Forms.Button
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents btnGetInfo As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImageNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtImageNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents lstEthernetScanInfo As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGetInfoFromData As System.Windows.Forms.Button
    Friend WithEvents lstInfoFromDataBuffer As System.Windows.Forms.ListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnShowSecondLaserForm As System.Windows.Forms.Button
    Friend WithEvents chkSendToFile As System.Windows.Forms.CheckBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GraphControl1 As AP820_Demo.GraphControl
    Friend WithEvents gbScansWithEncoder As System.Windows.Forms.GroupBox
    Friend WithEvents bthGetContinuousWithEnc As System.Windows.Forms.Button
    Friend WithEvents btnGetContinuousHardwareTriggeredWithEncoder As System.Windows.Forms.Button
    Friend WithEvents btnStopEncoder As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEncoderPos As System.Windows.Forms.TextBox
    Friend WithEvents btnResetEncoder As System.Windows.Forms.Button
    Friend WithEvents gbLaserParams As System.Windows.Forms.GroupBox
    Friend WithEvents txtMinZ As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxZ As System.Windows.Forms.TextBox
    Friend WithEvents btnSetMaxForZRange As System.Windows.Forms.Button
    Friend WithEvents btnSetMinForZRange As System.Windows.Forms.Button
    Friend WithEvents btnTurnOffALF As System.Windows.Forms.Button
    Friend WithEvents btnTurnOffLaser As System.Windows.Forms.Button
    Friend WithEvents btnTurnOnALF As System.Windows.Forms.Button
    Friend WithEvents btnTurnOnLaser As System.Windows.Forms.Button
    Friend WithEvents gbConnect As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnGetStatus As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents gpGetInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gbTriggerMode As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnContinuousMode As System.Windows.Forms.Button
    Friend WithEvents btnTriggerMode As System.Windows.Forms.Button
    Friend WithEvents gbContinuousModeScans As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSampleRate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDropped As System.Windows.Forms.TextBox
    Friend WithEvents btnGetContinuousOptimized As System.Windows.Forms.Button
    Friend WithEvents btnStopContinuous As System.Windows.Forms.Button
    Friend WithEvents btnGetContinuousScans As System.Windows.Forms.Button
    Friend WithEvents btnSingleScan As System.Windows.Forms.Button
    Friend WithEvents btnGetInterleaved As System.Windows.Forms.Button
    Friend WithEvents gbTriggerModeScans As System.Windows.Forms.GroupBox
    Friend WithEvents btnSendSoftwareTrigger As System.Windows.Forms.Button
    Friend WithEvents btnGetContinuousHardwareTriggeredScans As System.Windows.Forms.Button
    Friend WithEvents lblDataReceived As System.Windows.Forms.Label
    Friend WithEvents lblWaitingForTrigger As System.Windows.Forms.Label
    Friend WithEvents btnStopTrigger As System.Windows.Forms.Button
    Friend WithEvents btnSingleHardwareTrigger As System.Windows.Forms.Button
    Friend WithEvents btnSendTrigger As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents gbThickness As System.Windows.Forms.GroupBox
    Friend WithEvents txtUpdateCount As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtThreshold As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtRightEdge As System.Windows.Forms.TextBox
    Friend WithEvents txtLeftEdge As System.Windows.Forms.TextBox
    Friend WithEvents btnStopContinuousRealWorldExampleScans As System.Windows.Forms.Button
    Friend WithEvents btnGetWidthContinuously As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents btnGetGapScans As System.Windows.Forms.Button
    Friend WithEvents gbPeakCalc As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetPeakScans As System.Windows.Forms.Button
    Friend WithEvents btnStopPeakScans As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtPeakPos As System.Windows.Forms.TextBox
    Friend WithEvents txtPeak As System.Windows.Forms.TextBox
    Friend WithEvents btnHoleDiameterMeasurement As System.Windows.Forms.Button

End Class
