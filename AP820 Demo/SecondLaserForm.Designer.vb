<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecondLaserForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecondLaserForm))
        Me.btnGetStatus = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.btnDisconnect = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.lstInfoFromDataBuffer = New System.Windows.Forms.ListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lstEthernetScanInfo = New System.Windows.Forms.ListBox
        Me.btnGetInfoFromData = New System.Windows.Forms.Button
        Me.btnGetInfo = New System.Windows.Forms.Button
        Me.txtImageNumber2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtImageNumber = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSingleScan = New System.Windows.Forms.Button
        Me.btnGetInterleaved = New System.Windows.Forms.Button
        Me.btnContinuousMode = New System.Windows.Forms.Button
        Me.btnTriggerMode = New System.Windows.Forms.Button
        Me.btnSimultaneous = New System.Windows.Forms.Button
        Me.btnAlternate = New System.Windows.Forms.Button
        Me.btnGetContinuousSyncScans = New System.Windows.Forms.Button
        Me.btnStopContinuous = New System.Windows.Forms.Button
        Me.txtLaser1ImageNumber = New System.Windows.Forms.TextBox
        Me.txtLaser1ImageNumber2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnGetContinuousSyncScansOptimized = New System.Windows.Forms.Button
        Me.txtDropped = New System.Windows.Forms.TextBox
        Me.txtDropped2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtData = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.btnGetContinuousSyncScansNonInterleaved = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnGetStatus
        '
        Me.btnGetStatus.Location = New System.Drawing.Point(21, 129)
        Me.btnGetStatus.Name = "btnGetStatus"
        Me.btnGetStatus.Size = New System.Drawing.Size(178, 28)
        Me.btnGetStatus.TabIndex = 34
        Me.btnGetStatus.Text = "Get Connection Status"
        Me.btnGetStatus.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(223, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 36)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Connection Status:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(290, 134)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(124, 20)
        Me.txtStatus.TabIndex = 32
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(235, 66)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(178, 28)
        Me.btnDisconnect.TabIndex = 31
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(242, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Port:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(288, 100)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(124, 20)
        Me.txtPort.TabIndex = 29
        Me.txtPort.Text = "3001"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "IP Address:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(97, 100)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(100, 20)
        Me.txtIPAddress.TabIndex = 27
        Me.txtIPAddress.Text = "192.168.123.225"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(20, 66)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(178, 28)
        Me.btnConnect.TabIndex = 26
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(679, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Info From Data Buffer:"
        '
        'lstInfoFromDataBuffer
        '
        Me.lstInfoFromDataBuffer.FormattingEnabled = True
        Me.lstInfoFromDataBuffer.Location = New System.Drawing.Point(682, 45)
        Me.lstInfoFromDataBuffer.Name = "lstInfoFromDataBuffer"
        Me.lstInfoFromDataBuffer.Size = New System.Drawing.Size(233, 550)
        Me.lstInfoFromDataBuffer.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(918, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Data:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(440, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Ethernet Scan Info:"
        '
        'lstEthernetScanInfo
        '
        Me.lstEthernetScanInfo.FormattingEnabled = True
        Me.lstEthernetScanInfo.Location = New System.Drawing.Point(443, 45)
        Me.lstEthernetScanInfo.Name = "lstEthernetScanInfo"
        Me.lstEthernetScanInfo.Size = New System.Drawing.Size(233, 550)
        Me.lstEthernetScanInfo.TabIndex = 50
        '
        'btnGetInfoFromData
        '
        Me.btnGetInfoFromData.Location = New System.Drawing.Point(235, 186)
        Me.btnGetInfoFromData.Name = "btnGetInfoFromData"
        Me.btnGetInfoFromData.Size = New System.Drawing.Size(178, 28)
        Me.btnGetInfoFromData.TabIndex = 56
        Me.btnGetInfoFromData.Text = "Get Info From Data Buffer"
        Me.btnGetInfoFromData.UseVisualStyleBackColor = True
        '
        'btnGetInfo
        '
        Me.btnGetInfo.Location = New System.Drawing.Point(22, 186)
        Me.btnGetInfo.Name = "btnGetInfo"
        Me.btnGetInfo.Size = New System.Drawing.Size(178, 28)
        Me.btnGetInfo.TabIndex = 55
        Me.btnGetInfo.Text = "Get Info"
        Me.btnGetInfo.UseVisualStyleBackColor = True
        '
        'txtImageNumber2
        '
        Me.txtImageNumber2.Location = New System.Drawing.Point(291, 252)
        Me.txtImageNumber2.Name = "txtImageNumber2"
        Me.txtImageNumber2.ReadOnly = True
        Me.txtImageNumber2.Size = New System.Drawing.Size(124, 20)
        Me.txtImageNumber2.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(205, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 45)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Laser 2, Second Image Number:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImageNumber
        '
        Me.txtImageNumber.Location = New System.Drawing.Point(75, 252)
        Me.txtImageNumber.Name = "txtImageNumber"
        Me.txtImageNumber.ReadOnly = True
        Me.txtImageNumber.Size = New System.Drawing.Size(124, 20)
        Me.txtImageNumber.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(-3, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 45)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Laser 2, First Image Number:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSingleScan
        '
        Me.btnSingleScan.Location = New System.Drawing.Point(20, 291)
        Me.btnSingleScan.Name = "btnSingleScan"
        Me.btnSingleScan.Size = New System.Drawing.Size(178, 28)
        Me.btnSingleScan.TabIndex = 58
        Me.btnSingleScan.Text = "Get Single Scan"
        Me.btnSingleScan.UseVisualStyleBackColor = True
        '
        'btnGetInterleaved
        '
        Me.btnGetInterleaved.Location = New System.Drawing.Point(235, 291)
        Me.btnGetInterleaved.Name = "btnGetInterleaved"
        Me.btnGetInterleaved.Size = New System.Drawing.Size(178, 28)
        Me.btnGetInterleaved.TabIndex = 57
        Me.btnGetInterleaved.Text = "Get Interleaved Scan"
        Me.btnGetInterleaved.UseVisualStyleBackColor = True
        '
        'btnContinuousMode
        '
        Me.btnContinuousMode.Location = New System.Drawing.Point(235, 368)
        Me.btnContinuousMode.Name = "btnContinuousMode"
        Me.btnContinuousMode.Size = New System.Drawing.Size(178, 28)
        Me.btnContinuousMode.TabIndex = 64
        Me.btnContinuousMode.Text = "Put in Continuous Mode"
        Me.btnContinuousMode.UseVisualStyleBackColor = True
        '
        'btnTriggerMode
        '
        Me.btnTriggerMode.Location = New System.Drawing.Point(20, 368)
        Me.btnTriggerMode.Name = "btnTriggerMode"
        Me.btnTriggerMode.Size = New System.Drawing.Size(178, 28)
        Me.btnTriggerMode.TabIndex = 63
        Me.btnTriggerMode.Text = "Put in Trigger Mode"
        Me.btnTriggerMode.UseVisualStyleBackColor = True
        '
        'btnSimultaneous
        '
        Me.btnSimultaneous.Location = New System.Drawing.Point(22, 474)
        Me.btnSimultaneous.Name = "btnSimultaneous"
        Me.btnSimultaneous.Size = New System.Drawing.Size(178, 28)
        Me.btnSimultaneous.TabIndex = 65
        Me.btnSimultaneous.Text = "Set Laser 1 to Simultaneous Mode"
        Me.btnSimultaneous.UseVisualStyleBackColor = True
        '
        'btnAlternate
        '
        Me.btnAlternate.Location = New System.Drawing.Point(237, 474)
        Me.btnAlternate.Name = "btnAlternate"
        Me.btnAlternate.Size = New System.Drawing.Size(178, 28)
        Me.btnAlternate.TabIndex = 66
        Me.btnAlternate.Text = "Set Laser 1 to Alternate Mode"
        Me.btnAlternate.UseVisualStyleBackColor = True
        '
        'btnGetContinuousSyncScans
        '
        Me.btnGetContinuousSyncScans.Location = New System.Drawing.Point(11, 615)
        Me.btnGetContinuousSyncScans.Name = "btnGetContinuousSyncScans"
        Me.btnGetContinuousSyncScans.Size = New System.Drawing.Size(229, 28)
        Me.btnGetContinuousSyncScans.TabIndex = 67
        Me.btnGetContinuousSyncScans.Text = "Get Continuous Synch Scans Interleaved"
        Me.btnGetContinuousSyncScans.UseVisualStyleBackColor = True
        '
        'btnStopContinuous
        '
        Me.btnStopContinuous.Location = New System.Drawing.Point(246, 615)
        Me.btnStopContinuous.Name = "btnStopContinuous"
        Me.btnStopContinuous.Size = New System.Drawing.Size(178, 28)
        Me.btnStopContinuous.TabIndex = 68
        Me.btnStopContinuous.Text = "Stop Continuous Scans"
        Me.btnStopContinuous.UseVisualStyleBackColor = True
        '
        'txtLaser1ImageNumber
        '
        Me.txtLaser1ImageNumber.Location = New System.Drawing.Point(89, 541)
        Me.txtLaser1ImageNumber.Name = "txtLaser1ImageNumber"
        Me.txtLaser1ImageNumber.ReadOnly = True
        Me.txtLaser1ImageNumber.Size = New System.Drawing.Size(124, 20)
        Me.txtLaser1ImageNumber.TabIndex = 69
        '
        'txtLaser1ImageNumber2
        '
        Me.txtLaser1ImageNumber2.Location = New System.Drawing.Point(305, 541)
        Me.txtLaser1ImageNumber2.Name = "txtLaser1ImageNumber2"
        Me.txtLaser1ImageNumber2.ReadOnly = True
        Me.txtLaser1ImageNumber2.Size = New System.Drawing.Size(124, 20)
        Me.txtLaser1ImageNumber2.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 532)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 36)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Laser 1 Image Number:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(222, 532)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 36)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Laser 1 Image Number:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGetContinuousSyncScansOptimized
        '
        Me.btnGetContinuousSyncScansOptimized.Location = New System.Drawing.Point(11, 675)
        Me.btnGetContinuousSyncScansOptimized.Name = "btnGetContinuousSyncScansOptimized"
        Me.btnGetContinuousSyncScansOptimized.Size = New System.Drawing.Size(229, 28)
        Me.btnGetContinuousSyncScansOptimized.TabIndex = 73
        Me.btnGetContinuousSyncScansOptimized.Text = "Get Continuous Synch Scans Interleaved"
        Me.btnGetContinuousSyncScansOptimized.UseVisualStyleBackColor = True
        '
        'txtDropped
        '
        Me.txtDropped.Location = New System.Drawing.Point(366, 654)
        Me.txtDropped.Name = "txtDropped"
        Me.txtDropped.ReadOnly = True
        Me.txtDropped.Size = New System.Drawing.Size(58, 20)
        Me.txtDropped.TabIndex = 74
        '
        'txtDropped2
        '
        Me.txtDropped2.Location = New System.Drawing.Point(366, 694)
        Me.txtDropped2.Name = "txtDropped2"
        Me.txtDropped2.ReadOnly = True
        Me.txtDropped2.Size = New System.Drawing.Size(58, 20)
        Me.txtDropped2.TabIndex = 75
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(273, 646)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 36)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Laser 1 Dropped Scans:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(273, 685)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 36)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "Laser 2 Dropped Scans:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(921, 46)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.ReadOnly = True
        Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtData.Size = New System.Drawing.Size(325, 550)
        Me.txtData.TabIndex = 78
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(937, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 79
        Me.Label13.Text = "X"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(987, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "Z"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1019, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "Intensity"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(1155, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "Intensity"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1123, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(14, 13)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "Z"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1073, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(14, 13)
        Me.Label18.TabIndex = 82
        Me.Label18.Text = "X"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(37, 7)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(377, 56)
        Me.Label19.TabIndex = 85
        Me.Label19.Text = resources.GetString("Label19.Text")
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(19, 161)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(377, 22)
        Me.Label20.TabIndex = 86
        Me.Label20.Text = "Then call the GetInfo function for the second lasers parameters."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(19, 228)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(249, 13)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "Then, you can acquire scans from the second laser"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 322)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(402, 43)
        Me.Label22.TabIndex = 88
        Me.Label22.Text = resources.GetString("Label22.Text")
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 438)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(396, 33)
        Me.Label23.TabIndex = 89
        Me.Label23.Text = "Set Laser 1 to Simultaneous or Alternate mode so that buttons below can acquire d" & _
            "ata from both" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(22, 505)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(391, 13)
        Me.Label24.TabIndex = 90
        Me.Label24.Text = "Done properly in continuous mode, Laser 1 and Laser 2 image numbers will match"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 659)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(230, 13)
        Me.Label25.TabIndex = 91
        Me.Label25.Text = "Optimized for speed, with no string manipulation"
        '
        'btnGetContinuousSyncScansNonInterleaved
        '
        Me.btnGetContinuousSyncScansNonInterleaved.Location = New System.Drawing.Point(450, 615)
        Me.btnGetContinuousSyncScansNonInterleaved.Name = "btnGetContinuousSyncScansNonInterleaved"
        Me.btnGetContinuousSyncScansNonInterleaved.Size = New System.Drawing.Size(237, 28)
        Me.btnGetContinuousSyncScansNonInterleaved.TabIndex = 92
        Me.btnGetContinuousSyncScansNonInterleaved.Text = "Get Continuous Synch Scans Non-Interleaved"
        Me.btnGetContinuousSyncScansNonInterleaved.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(25, 568)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(380, 45)
        Me.Label26.TabIndex = 93
        Me.Label26.Text = "Note:  Continuous Interleaved Scans work better in Alternate mode than in Simulta" & _
            "neous mode.  In Simultaneous mode, use Non-Interleaved Synchronous Scans."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(22, 403)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(409, 26)
        Me.Label27.TabIndex = 94
        Me.Label27.Text = "Examples for Synchronization of Laser 2 with Laser 1 measurements appear below:"
        '
        'SecondLaserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1269, 726)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.btnGetContinuousSyncScansNonInterleaved)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDropped2)
        Me.Controls.Add(Me.txtDropped)
        Me.Controls.Add(Me.btnGetContinuousSyncScansOptimized)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLaser1ImageNumber2)
        Me.Controls.Add(Me.txtLaser1ImageNumber)
        Me.Controls.Add(Me.btnStopContinuous)
        Me.Controls.Add(Me.btnGetContinuousSyncScans)
        Me.Controls.Add(Me.btnAlternate)
        Me.Controls.Add(Me.btnSimultaneous)
        Me.Controls.Add(Me.btnContinuousMode)
        Me.Controls.Add(Me.btnTriggerMode)
        Me.Controls.Add(Me.txtImageNumber2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtImageNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSingleScan)
        Me.Controls.Add(Me.btnGetInterleaved)
        Me.Controls.Add(Me.btnGetInfoFromData)
        Me.Controls.Add(Me.btnGetInfo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lstInfoFromDataBuffer)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lstEthernetScanInfo)
        Me.Controls.Add(Me.btnGetStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.btnConnect)
        Me.Name = "SecondLaserForm"
        Me.Text = "Acuity AP820 Quick-Start Code Development and Scanner Training Kit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGetStatus As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lstInfoFromDataBuffer As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lstEthernetScanInfo As System.Windows.Forms.ListBox
    Friend WithEvents btnGetInfoFromData As System.Windows.Forms.Button
    Friend WithEvents btnGetInfo As System.Windows.Forms.Button
    Friend WithEvents txtImageNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtImageNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSingleScan As System.Windows.Forms.Button
    Friend WithEvents btnGetInterleaved As System.Windows.Forms.Button
    Friend WithEvents btnContinuousMode As System.Windows.Forms.Button
    Friend WithEvents btnTriggerMode As System.Windows.Forms.Button
    Friend WithEvents btnSimultaneous As System.Windows.Forms.Button
    Friend WithEvents btnAlternate As System.Windows.Forms.Button
    Friend WithEvents btnGetContinuousSyncScans As System.Windows.Forms.Button
    Friend WithEvents btnStopContinuous As System.Windows.Forms.Button
    Friend WithEvents txtLaser1ImageNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtLaser1ImageNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnGetContinuousSyncScansOptimized As System.Windows.Forms.Button
    Friend WithEvents txtDropped As System.Windows.Forms.TextBox
    Friend WithEvents txtDropped2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnGetContinuousSyncScansNonInterleaved As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
