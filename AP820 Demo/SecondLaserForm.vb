Imports System.Threading
Imports System.Threading.Thread

Public Class SecondLaserForm
    Private StopFlag As Boolean
    Private XArray2Holder(580) As UInteger
    Private ZArray2Holder(580) As UInteger
    Private IArray2Holder(580) As UInteger
    Private ImageNumber21Holder, ImageNumber22Holder As Byte
    Private ResultHolder As Boolean
    Private Mut As New Mutex

    Private Sub SecondLaserForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        ' Note: AP820Laser2 is an instance of the AP820Laser class.  It is instantiated in Globals.vb
        ' See comments at the top of MainForm.vb for an overview of the program structure.

        AP820Laser2.Connect(txtIPAddress.Text, txtPort.Text)
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        AP820Laser2.Disconnect()
    End Sub

    Private Sub btnGetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStatus.Click
        Dim Status As UInteger

        ' For documentation, see the button of the same name on MainForm.vb

        Status = AP820Laser2.GetStatus
        Select Case Status
            Case 0
                txtStatus.Text = "Disconnected"
            Case 1
                txtStatus.Text = "Disconnecting"
            Case 2
                txtStatus.Text = "Connecting"
            Case 3
                txtStatus.Text = "Connected"
        End Select

    End Sub

    Private Sub btnGetInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfo.Click
        Dim Result As Boolean

        ' For documentation, see the button of the same name on MainForm.vb
        lstEthernetScanInfo.Items.Clear()

        Result = AP820Laser2.GetInfo()
        If Result Then
            lstEthernetScanInfo.Items.Add("Serial Number: " + AP820Laser2.ScanInfo.SerialNumber)
            lstEthernetScanInfo.Items.Add("Firmware Version: " + AP820Laser2.ScanInfo.FirmwareVersion)
            lstEthernetScanInfo.Items.Add("Beginning of Measuring Range: " + AP820Laser2.ScanInfo.BeginningOfMeasuringRange.ToString)
            lstEthernetScanInfo.Items.Add("Measuring Range: " + AP820Laser2.ScanInfo.MeasuringRange.ToString)
            lstEthernetScanInfo.Items.Add("Scan Range Beginning: " + AP820Laser2.ScanInfo.ScanRangeBeginning.ToString)
            lstEthernetScanInfo.Items.Add("Scan Range End: " + AP820Laser2.ScanInfo.ScanRangeEnd.ToString)
            lstEthernetScanInfo.Items.Add("Max Z Linearized: " + AP820Laser2.ScanInfo.MaxZLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Max X Linearized: " + AP820Laser2.ScanInfo.MaxXLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Max Z Non-Linearized: " + AP820Laser2.ScanInfo.MaxZNonLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Max X Non-Linearized: " + AP820Laser2.ScanInfo.MaxXNonLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Number of Z Pixels: " + AP820Laser2.ScanInfo.NumZPixels.ToString)
            lstEthernetScanInfo.Items.Add("Number of X Pixels: " + AP820Laser2.ScanInfo.NumXPixels.ToString)
            lstEthernetScanInfo.Items.Add("Scanner Temperature: " + AP820Laser2.ScanInfo.ScannerTemperature.ToString)
            lstEthernetScanInfo.Items.Add("Operating Seconds Counter: " + AP820Laser2.ScanInfo.OperatingSecondsCounter.ToString)
            lstEthernetScanInfo.Items.Add("Power Cycle Counter: " + AP820Laser2.ScanInfo.PowerCycleCounter.ToString)
            lstEthernetScanInfo.Items.Add("Fifo: " + AP820Laser2.ScanInfo.Fifo.ToString)
            lstEthernetScanInfo.Items.Add("Position Encoder: " + AP820Laser2.ScanInfo.PositionEncoder.ToString)
            lstEthernetScanInfo.Items.Add("Position Encoder Direction: " + AP820Laser2.ScanInfo.PositionEncoderDirection.ToString)
            lstEthernetScanInfo.Items.Add("Protocol: " + AP820Laser2.ScanInfo.Protocol.ToString)
            lstEthernetScanInfo.Items.Add("Linearization: " + AP820Laser2.ScanInfo.Linearization.ToString)
            lstEthernetScanInfo.Items.Add("Camera Mode: " + AP820Laser2.ScanInfo.CameraMode.ToString)
            lstEthernetScanInfo.Items.Add("Profile Mode: " + AP820Laser2.ScanInfo.ProfileMode.ToString)
            lstEthernetScanInfo.Items.Add("Scanner Mode: " + AP820Laser2.ScanInfo.ScannerMode.ToString)
            lstEthernetScanInfo.Items.Add("Shutter Time Manual: " + AP820Laser2.ScanInfo.ShutterTimeManual.ToString)
            lstEthernetScanInfo.Items.Add("Shutter Time Auto: " + AP820Laser2.ScanInfo.ShutterTimeAuto.ToString)
            lstEthernetScanInfo.Items.Add("Pixel Readout Start: " + AP820Laser2.ScanInfo.PixelReadOutStart.ToString)
            lstEthernetScanInfo.Items.Add("Pixel Readout End: " + AP820Laser2.ScanInfo.PixelReadOutEnd.ToString)
            lstEthernetScanInfo.Items.Add("Video Gain: " + AP820Laser2.ScanInfo.VideoGain.ToString)
            lstEthernetScanInfo.Items.Add("Linear Intesity Threshold: " + AP820Laser2.ScanInfo.LaserIntensityThreshold.ToString)
            lstEthernetScanInfo.Items.Add("Laser Target Value: " + AP820Laser2.ScanInfo.LaserTargetValue.ToString)
            lstEthernetScanInfo.Items.Add("Peak Width Limit: " + AP820Laser2.ScanInfo.PeakWidthLimit.ToString)
            lstEthernetScanInfo.Items.Add("Peak Threshold: " + AP820Laser2.ScanInfo.PeakThreshold.ToString)
            lstEthernetScanInfo.Items.Add("Synchronization: " + AP820Laser2.ScanInfo.Synchronization.ToString)
            lstEthernetScanInfo.Items.Add("Protocol Version: " + AP820Laser2.ScanInfo.ProtocolVersion.ToString)
            lstEthernetScanInfo.Items.Add("Shutter Control: " + AP820Laser2.ScanInfo.ShutterControl.ToString)
            lstEthernetScanInfo.Items.Add("Linearization 2: " + AP820Laser2.ScanInfo.Linearization2.ToString)
            lstEthernetScanInfo.Items.Add("Speed: " + AP820Laser2.ScanInfo.Speed.ToString)
            lstEthernetScanInfo.Items.Add("FPGA Version: " + AP820Laser2.ScanInfo.FPGAVersion.ToString)
            lstEthernetScanInfo.Items.Add("Digital Input: " + AP820Laser2.ScanInfo.DigitalInput.ToString)
            lstEthernetScanInfo.Items.Add("Laser Value of Profile: " + AP820Laser2.ScanInfo.LaserValueOfProfile.ToString)
        End If

    End Sub

    Private Function SendSoftwareTrigger() As UInteger
        Dim Buffer(1) As Byte

        Buffer(0) = &H1D 'bit 7 is 0, bits 6 to 0 indicate address 29
        Buffer(1) = 0 'Can be anything

        Return AP820Laser2.WriteData(Buffer, 1)
    End Function

    Private Sub btnGetInfoFromData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfoFromData.Click

        ' For documentation, see the button of the same name on MainForm.vb

        Dim Buffer(3500) As Byte
        Dim Result As Boolean
        Dim TCPPort As UInt16
        Dim EncoderPosition As Integer
        Dim EncoderDirection As Byte
        Dim Temperature As Integer
        Dim StatusRegister As Byte
        Dim FirmwareVersion As Single
        Dim OperatingTime As Integer
        Dim SwitchOnCount As Integer
        Dim HorizontalPixels, VerticalPixels As Integer
        Dim ExposureControl As Integer
        Dim MinZ, MaxZ As Integer
        Dim Amplification As Integer

        lstInfoFromDataBuffer.Items.Clear()

        SendSoftwareTrigger()
        Result = AP820Laser2.GetDataRaw(Buffer)

        If Result Then
            lstInfoFromDataBuffer.Items.Add("Default MAC Address: " + Buffer(0).ToString("X2") + ":" + Buffer(1).ToString("X2") + ":" _
                     + Buffer(2).ToString("X2") + ":" + Buffer(3).ToString("X2") + ":" + Buffer(4).ToString("X2") + ":" + Buffer(5).ToString("X2"))
            lstInfoFromDataBuffer.Items.Add("Default Gateway: " + Buffer(10).ToString("D3") + "." + Buffer(11).ToString("D3") + "." _
                     + Buffer(12).ToString("D3") + "." + Buffer(13).ToString("D3"))
            lstInfoFromDataBuffer.Items.Add("Default Subnet Mask: " + Buffer(14).ToString("D3") + "." + Buffer(15).ToString("D3") + "." _
                    + Buffer(16).ToString("D3") + "." + Buffer(17).ToString("D3"))
            lstInfoFromDataBuffer.Items.Add("Default IP Address: " + Buffer(18).ToString("D3") + "." + Buffer(19).ToString("D3") + "." _
                   + Buffer(20).ToString("D3") + "." + Buffer(21).ToString("D3"))
            TCPPort = Buffer(23)
            TCPPort = (TCPPort << 8) + Buffer(22)
            lstInfoFromDataBuffer.Items.Add("Default TCP Port: " + TCPPort.ToString("D4"))
            lstInfoFromDataBuffer.Items.Add("Working MAC Address: " + Buffer(26).ToString("X2") + ":" + Buffer(27).ToString("X2") + ":" _
                     + Buffer(28).ToString("X2") + ":" + Buffer(29).ToString("X2") + ":" + Buffer(30).ToString("X2") + ":" + Buffer(31).ToString("X2"))
            lstInfoFromDataBuffer.Items.Add("Working Gateway: " + Buffer(36).ToString("D3") + "." + Buffer(37).ToString("D3") + "." _
                     + Buffer(38).ToString("D3") + "." + Buffer(39).ToString("D3"))
            lstInfoFromDataBuffer.Items.Add("Working Subnet Mask: " + Buffer(40).ToString("D3") + "." + Buffer(41).ToString("D3") + "." _
                    + Buffer(42).ToString("D3") + "." + Buffer(43).ToString("D3"))
            lstInfoFromDataBuffer.Items.Add("Working IP Address: " + Buffer(44).ToString("D3") + "." + Buffer(45).ToString("D3") + "." _
                   + Buffer(46).ToString("D3") + "." + Buffer(47).ToString("D3"))
            TCPPort = Buffer(49)
            TCPPort = (TCPPort << 8) + Buffer(48)
            lstInfoFromDataBuffer.Items.Add("Working TCP Port: " + TCPPort.ToString("D4"))
            lstInfoFromDataBuffer.Items.Add("Image Number: " + Buffer(62).ToString())

            EncoderPosition = Buffer(1528) And &H3F
            EncoderPosition = (EncoderPosition << 7) + (Buffer(1527) And &H7F)
            EncoderPosition = (EncoderPosition << 7) + (Buffer(1526) And &H7F)
            EncoderPosition = (EncoderPosition << 7) + (Buffer(1525) And &H7F)
            'Bit 27 is sign bit
            If (EncoderPosition And &H800000) = &H800000 Then
                'This is a negative number
                'Get 1's complement
                EncoderPosition = (Not EncoderPosition) And &H7FFFFF
                'Get 2's complement
                EncoderPosition = EncoderPosition + 1
                'flip sign
                EncoderPosition = EncoderPosition * (-1)
            End If
            lstInfoFromDataBuffer.Items.Add("Encoder Position: " + EncoderPosition.ToString)

            EncoderDirection = Buffer(1528) And &H40
            If EncoderDirection = &H40 Then
                lstInfoFromDataBuffer.Items.Add("Encoder Direction: Decreasing")
            Else
                lstInfoFromDataBuffer.Items.Add("Encoder Direction: Increasing")
            End If

            'Register of Functions
            ExposureControl = Buffer(1530 + 1) And &H7
            ExposureControl = (ExposureControl << 3) + (Buffer(1530) And &H7F)
            lstInfoFromDataBuffer.Items.Add("Exposure Control: " + ExposureControl.ToString)

            MinZ = ((Buffer(1530 + 4) And &H7F) * 8)
            lstInfoFromDataBuffer.Items.Add("Field of View Min Z: " + MinZ.ToString)

            MaxZ = ((Buffer(1530 + 5) And &H7F) * 8)
            lstInfoFromDataBuffer.Items.Add("Field of View Max Z: " + MaxZ.ToString)

            Amplification = Buffer(1530 + 7) And &H7
            Amplification = (Amplification << 3) + (Buffer(1530 + 6) And &H7F)
            lstInfoFromDataBuffer.Items.Add("Amplification: " + Amplification.ToString("X3"))

            StatusRegister = Buffer(1530 + 11) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("AGC (Amplification Control): On")
            Else
                lstInfoFromDataBuffer.Items.Add("AGC (Amplification Control): Off")
            End If

            StatusRegister = Buffer(1530 + 12) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Laser On/Off: Off")
            Else
                lstInfoFromDataBuffer.Items.Add("Laser On/Off: On")
            End If

            StatusRegister = Buffer(1530 + 13) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Ambient Light Filter: On")
            Else
                lstInfoFromDataBuffer.Items.Add("Ambient Light Filter: Off")
            End If

            StatusRegister = Buffer(1530 + 15) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Sychronization Mode: Alternate")
            Else
                lstInfoFromDataBuffer.Items.Add("Sychronization Mode: Simultaneous")
            End If

            StatusRegister = Buffer(1530 + 16) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Output Mode: Grey Scale")
            Else
                lstInfoFromDataBuffer.Items.Add("Output Mode: Profile Data")
            End If

            StatusRegister = Buffer(1530 + 20) And &H8
            If StatusRegister = &H8 Then
                lstInfoFromDataBuffer.Items.Add("Measurement Control: Triggered")
            Else
                lstInfoFromDataBuffer.Items.Add("Measurement Control: Continuous")
            End If

            StatusRegister = Buffer(1530 + 21) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Exposure Control: Manual")
            Else
                lstInfoFromDataBuffer.Items.Add("Exposure Control: Automatic")
            End If

            StatusRegister = Buffer(1530 + 22) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Linearization: On")
            Else
                lstInfoFromDataBuffer.Items.Add("Linearization: Off")
            End If

            'Register of Functions end

            Temperature = Buffer(1562) And &H7F
            If ((Buffer(1562) And &H80) = &H80) Then
                Temperature = Temperature - 128
            End If
            lstInfoFromDataBuffer.Items.Add("Temperature: " + Temperature.ToString)

            StatusRegister = Buffer(1563) And &H1
            If StatusRegister = &H1 Then
                lstInfoFromDataBuffer.Items.Add("Profile Data: Linear")
            Else
                lstInfoFromDataBuffer.Items.Add("Profile Data: Non-Linear")
            End If

            StatusRegister = Buffer(1563) And &H2
            If StatusRegister = &H2 Then
                lstInfoFromDataBuffer.Items.Add("Register Condtion: Changed")
            Else
                lstInfoFromDataBuffer.Items.Add("Register Condtion: After Reset")
            End If

            StatusRegister = Buffer(1563) And &H4
            If StatusRegister = &H4 Then
                lstInfoFromDataBuffer.Items.Add("Transmission Format: Profile Data")
            Else
                lstInfoFromDataBuffer.Items.Add("Transmission Format: Grey Scale")
            End If

            StatusRegister = Buffer(1563) And &H8
            If StatusRegister = &H8 Then
                lstInfoFromDataBuffer.Items.Add("Laser On/Off: Off")
            Else
                lstInfoFromDataBuffer.Items.Add("Laser On/Off: On")
            End If

            StatusRegister = Buffer(1563) And &H16
            If StatusRegister = &H16 Then
                lstInfoFromDataBuffer.Items.Add("Measurement Control: Triggered")
            Else
                lstInfoFromDataBuffer.Items.Add("Measurement Control: Continuous")
            End If

            StatusRegister = Buffer(1563) And &H32
            If StatusRegister = &H32 Then
                lstInfoFromDataBuffer.Items.Add("Laser Control: Manual")
            Else
                lstInfoFromDataBuffer.Items.Add("Laser Control: Automatic")
            End If

            FirmwareVersion = (Buffer(1564) / 10) + (Buffer(1576) / 100)
            lstInfoFromDataBuffer.Items.Add("Firmware Version: " + FirmwareVersion.ToString("0.00"))

            OperatingTime = Buffer(1570) And &H7F
            OperatingTime = (OperatingTime << 7) + (Buffer(1569) And &H7F)
            OperatingTime = (OperatingTime << 7) + (Buffer(1568) And &H7F)
            OperatingTime = (OperatingTime << 7) + (Buffer(1567) And &H7F)
            OperatingTime = (OperatingTime << 7) + (Buffer(1566) And &H7F)
            OperatingTime = OperatingTime / 4
            lstInfoFromDataBuffer.Items.Add("Operating Time (s): " + OperatingTime.ToString)

            SwitchOnCount = Buffer(1573) And &H7
            SwitchOnCount = (SwitchOnCount << 7) + (Buffer(1572) And &H7F)
            SwitchOnCount = (SwitchOnCount << 7) + (Buffer(1571) And &H7F)
            lstInfoFromDataBuffer.Items.Add("Switch On Count: " + SwitchOnCount.ToString)

            HorizontalPixels = Buffer(2041)
            HorizontalPixels = (HorizontalPixels << 8) + (Buffer(2042))
            lstInfoFromDataBuffer.Items.Add("Horizontal Pixels: " + HorizontalPixels.ToString)

            VerticalPixels = Buffer(2043)
            VerticalPixels = (VerticalPixels << 8) + (Buffer(2044))
            lstInfoFromDataBuffer.Items.Add("Vertical Pixels: " + VerticalPixels.ToString)

        End If

    End Sub

    Private Sub btnSingleScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSingleScan.Click

        ' For documentation, see the button of the same name on MainForm.vb

        Dim XArray(290) As UInteger
        Dim ZArray(290) As UInteger
        Dim IArray(290) As UInteger
        Dim ImageNumber As Byte
        Dim Result As Boolean
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim StrWriter As New System.IO.StringWriter(StrBldr)

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser2.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser2.ScanInfo.MeasuringRange * 0.1) / 4096)
        Result = AP820Laser2.GetData(XArray, ZArray, IArray, ImageNumber)
        If Result Then
            txtImageNumber.Text = ImageNumber.ToString
            StrBldr.Length = 0
            For I = 0 To AP820Laser2.ScanInfo.NumXPixels - 1
                XValue = XArray(I) * XScaler
                ZValue = ZArray(I) * ZScaler
                StrWriter.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
            Next
            txtData.Text = StrWriter.ToString
        Else
            txtImageNumber.Text = "Error"
        End If
        StrWriter.Close()

    End Sub

    Private Sub btnGetInterleaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInterleaved.Click

        ' For documentation, see the button of the same name on MainForm.vb

        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim StrWriter As New System.IO.StringWriter(StrBldr)

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser2.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser2.ScanInfo.MeasuringRange * 0.1) / 4096)
        Result = AP820Laser2.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

        If Result Then
            txtImageNumber.Text = ImageNumber1.ToString
            txtImageNumber2.Text = ImageNumber2.ToString
            StrBldr.Length = 0
            For I = 0 To 2 * (AP820Laser2.ScanInfo.NumXPixels) - 1
                XValue = XArray(I) * XScaler
                ZValue = ZArray(I) * ZScaler
                StrWriter.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
            Next
            txtData.Text = StrWriter.ToString
        Else
            txtImageNumber.Text = "Error"
            txtImageNumber2.Text = "Error"
        End If
        StrWriter.Close()

    End Sub

    Private Function SetLaserMeasurementControlMode(ByVal SampleContinuously As Boolean) As UInteger

        ' For documentation, see the button of the same name on MainForm.vb

        Dim Buffer(1) As Byte

        Buffer(0) = &H14 'bit 7 is 0, bits 6 to 0 indicate address 20
        If SampleContinuously Then
            'continuous mode
            Buffer(1) = &H80 'bit 7 is 0, bit 3 is 0
        Else
            'trigger mode
            Buffer(1) = &H88 'bit 7 is 1, bit 3 is 1
        End If
        Return AP820Laser2.WriteData(Buffer, 2)
    End Function

    Private Sub btnTriggerMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTriggerMode.Click

        ' For documentation, see the button of the same name on MainForm.vb

        SetLaserMeasurementControlMode(False)
        SendSoftwareTrigger()
    End Sub

    Private Sub btnContinuousMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuousMode.Click
        ' For documentation, see the button of the same name on MainForm.vb
        SetLaserMeasurementControlMode(True)
    End Sub

    Private Sub btnSimultaneous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimultaneous.Click
        Dim Buffer(1) As Byte
        Dim BytesWritten As UInteger

        ' See Section 9.7 of the User's Manual for a discussion of two laser Synchnonization Modes

        'Note, this function operates on Laser 1 and sets it up so that it generates a trigger on Laser 2 at the same time it is
        'triggered. When the Simultaneous Mode is utilized, the laser lines of both lasers are on at the same time, which may not
        'always be desirable (such as when the lasers are "looking at" each other.  See the next function, for an alternating
        'triggering method.

        Buffer(0) = 15 'bit 7 is 0, bits 6 to 0 will add to 15
        Buffer(1) = &H80 'bit 7 is 1, bit 0 is 0
        BytesWritten = AP820Laser1.WriteData(Buffer, 2)
    End Sub

    Private Sub btnAlternate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlternate.Click
        Dim Buffer(1) As Byte
        Dim BytesWritten As UInteger

        ' See Section 9.7 of the User's Manual for a discussion of two laser Synchnonization Modes

        'Note, this function operates on Laser 1 and sets it up so that it generates a trigger on Laser 2 in between successive
        'triggers on Laser 1.  In this way, the laser lines for the two lasers are never on at the same time, which is advantageour
        'if the two lasers are "looking" towards each other, as in two laser thickness measurement.

        'Note, this function operates on Laser 1
        Buffer(0) = 15 'bit 7 is 0, bits 6 to 0 will add to 15
        Buffer(1) = &H81 'bit 7 is 1, bit 0 is 1
        BytesWritten = AP820Laser1.WriteData(Buffer, 2)
    End Sub

    Private Sub FillList(ByVal ListData As String)
        txtData.Text = ListData
    End Sub

    Private Sub UpdateImageCount(ByVal ImageNumber11 As UInteger, ByVal ImageNumber12 As UInteger, ByVal ImageNumber21 As UInteger, ByVal ImageNumber22 As UInteger)
        txtImageNumber.Text = ImageNumber11.ToString
        If ImageNumber12 > 0 Then
            txtImageNumber2.Text = ImageNumber12.ToString
        Else
            txtImageNumber2.Text = "-"
        End If
        txtLaser1ImageNumber.Text = ImageNumber21.ToString
        If ImageNumber22 > 0 Then
            txtLaser1ImageNumber2.Text = ImageNumber22.ToString
        Else
            txtLaser1ImageNumber2.Text = "-"
        End If
    End Sub

    Private Sub ShowDroppedScans(ByVal NumberOfDroppedScans1 As Integer, ByVal NumberOfDroppedScans2 As Integer)
        txtDropped.Text = NumberOfDroppedScans1.ToString
        txtDropped2.Text = NumberOfDroppedScans2.ToString
    End Sub

    Delegate Sub FillListDelegate(ByVal ListData As String)
    Delegate Sub UpdateImageCountDelegate(ByVal ImageNumber11 As UInteger, ByVal ImageNumber12 As UInteger, ByVal ImageNumber21 As UInteger, ByVal ImageNumber22 As UInteger)
    Delegate Sub ShowDroppedScansDelegate(ByVal NumberOfDroppedScans1 As Integer, ByVal NumberOfDroppedScans2 As Integer)

    
 
    
    
    Private Sub btnGetContinuousSyncScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousSyncScans.Click
        StopFlag = False
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousSynchronous)
    End Sub

    Private Sub AcquireContinuousSynchronous(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim XArray2(580) As UInteger
        Dim ZArray2(580) As UInteger
        Dim IArray2(580) As UInteger
        Dim ImageNumber11, ImageNumber12, ImageNumber21, ImageNumber22 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim XValue2, ZValue2, XScaler2, ZScaler2 As Single
        Dim I As Integer
        Dim Result1, Result2 As Boolean
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim StrWriter As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = SendToFileFlag And ValidFileNameFlag

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)
        XScaler2 = ((AP820Laser2.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler2 = ((AP820Laser2.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        Do While StopFlag = False

            ' Note: We are not doing anything really new here, other than the fact that we are acquiring scans
            ' from two lasers rather than one.  

            ' Note: It is imporant to get the first scan from each laser prior to requesting the second scan from either laser.

            Result2 = AP820Laser2.GetFirstInterleavedScan(XArray2, ZArray2, IArray2, ImageNumber21)
            Result1 = AP820Laser1.GetFirstInterleavedScan(XArray, ZArray, IArray, ImageNumber11)
            If Result1 And Result2 Then
                Result2 = AP820Laser2.GetSecondInterleavedScan(XArray2, ZArray2, IArray2, ImageNumber21, ImageNumber22)
                Result1 = AP820Laser1.GetSecondInterleavedScan(XArray, ZArray, IArray, ImageNumber11, ImageNumber12)
            End If

            If Result1 And Result2 Then
                Me.Invoke(UpdateImageCountDel, ImageNumber11, ImageNumber12, ImageNumber21, ImageNumber22)
                StrBldr.Length = 0
                If SendToFile Then
                    StrWriter.WriteLine("Image Numbers, " + ImageNumber11.ToString + ", " + ImageNumber12.ToString + ", " + ImageNumber21.ToString + ", " + ImageNumber22.ToString)
                End If
                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    XValue2 = XArray2(I) * XScaler2
                    ZValue2 = ZArray2(I) * ZScaler2
                    StrWriter.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString + Chr(9) + XValue2.ToString("0.0000") + Chr(9) + ZValue2.ToString("0.0000") + Chr(9) + IArray2(I).ToString)
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(StrWriter.ToString)
                End If
                Me.Invoke(FillListDel, StrWriter.ToString)
            Else
                Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0), CUInt(0), CUInt(0))
            End If
        Loop
        StrWriter.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnStopContinuous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopContinuous.Click
        StopFlag = True
    End Sub

    Private Sub btnGetContinuousSyncScansOptimized_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousSyncScansOptimized.Click
        StopFlag = False

        ' In order to optimize speed, the second thread below simply acquires data from the second laser, and makes
        ' it available for use in the first thread.

        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousSynchronousOptimizedForSpeed)
        ThreadPool.QueueUserWorkItem(AddressOf AcquireSecondLaserSimultaneously)
    End Sub

    Private Sub AcquireContinuousSynchronousOptimizedForSpeed(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim XArray2(580) As UInteger
        Dim ZArray2(580) As UInteger
        Dim IArray2(580) As UInteger
        Dim ImageNumber11, ImageNumber12, ImageNumber21, ImageNumber22 As Byte
        Dim NumberOfDroppedScans1, NumberOfDroppedScans2 As Integer
        Dim NextImageNumber1, NextImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim XValue2, ZValue2, XScaler2, ZScaler2 As Single
        Dim I As Integer
        Dim Result1 As Boolean
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim ShowDroppedScansDel As New ShowDroppedScansDelegate(AddressOf ShowDroppedScans)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim StrWriter As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = SendToFileFlag And ValidFileNameFlag

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)
        XScaler2 = ((AP820Laser2.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler2 = ((AP820Laser2.ScanInfo.MeasuringRange * 0.1) / 4096)

        NumberOfDroppedScans1 = 0
        NextImageNumber1 = 255
        NumberOfDroppedScans2 = 0
        NextImageNumber2 = 255
        Me.Invoke(ShowDroppedScansDel, NumberOfDroppedScans1, NumberOfDroppedScans2)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        Do While StopFlag = False

            ' Get interleaved data from Laser 1 by calling the GetInterleavedData function from THIS thread.

            Result1 = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber11, ImageNumber12)

            ' The following Mutex causes this thread to synchronize with the thread which acquires data from the second laser.
            Mut.WaitOne()

            ' Now we have data available from the second laser which has put the data into the following three global data holders

            XArray2 = XArray2Holder
            ZArray2 = ZArray2Holder
            IArray2 = IArray2Holder
            ImageNumber21 = ImageNumber21Holder
            ImageNumber22 = ImageNumber22Holder

            ' Now that we are synchronized and have the data from both lasers, we can release the Mutex

            Mut.ReleaseMutex()

            ' The rest of this code is similar to the non-optimized two laser data collection function code, except that
            ' since we are optimizing, we don't update certain on-screen text displays

            If Result1 And ResultHolder Then
                Me.Invoke(UpdateImageCountDel, ImageNumber11, ImageNumber12, ImageNumber21, ImageNumber22)
                StrBldr.Length = 0
                If SendToFile Then
                    StrWriter.WriteLine("Image Numbers, " + ImageNumber11.ToString + ", " + ImageNumber12.ToString + ", " + ImageNumber21.ToString + ", " + ImageNumber22.ToString)
                End If
                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    XValue2 = XArray2(I) * XScaler2
                    ZValue2 = ZArray2(I) * ZScaler2
                    If SendToFile Then
                        StrWriter.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString + Chr(9) + XValue2.ToString("0.0000") + Chr(9) + ZValue2.ToString("0.0000") + Chr(9) + IArray2(I).ToString)
                    End If
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(StrWriter.ToString)
                End If
            End If
            If NextImageNumber1 <> 255 Then
                If ImageNumber11 <> NextImageNumber1 Then
                    NumberOfDroppedScans1 = NumberOfDroppedScans1 + 1
                    Me.Invoke(ShowDroppedScansDel, NumberOfDroppedScans1, NumberOfDroppedScans2)
                End If
            End If
            NextImageNumber1 = ImageNumber12 + 1
            If NextImageNumber1 > 253 Then
                NextImageNumber1 = 0
            End If
            If NextImageNumber2 <> 255 Then
                If ImageNumber21 <> NextImageNumber2 Then
                    NumberOfDroppedScans2 = NumberOfDroppedScans2 + 1
                    Me.Invoke(ShowDroppedScansDel, NumberOfDroppedScans1, NumberOfDroppedScans2)
                End If
            End If
            If AP820Laser2.ScanInfo.ScannerMode = 1 Then
                'Trigger mode
                NextImageNumber2 = 1
            Else
                'Continuous mode
                NextImageNumber2 = ImageNumber22 + 1
                If NextImageNumber2 > 253 Then
                    NextImageNumber2 = 0
                End If
            End If
        Loop

        StrWriter.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub AcquireSecondLaserSimultaneously(ByVal StateInfo As Object)
        Dim XArray2(580) As UInteger
        Dim ZArray2(580) As UInteger
        Dim IArray2(580) As UInteger
        Dim ImageNumber21 As Byte
        Dim ImageNumber22 As Byte

        ' This routine (which runs in its own thread), simply gets data from the 2nd laser and makes it available to 
        ' the thread acquiring data from the first laser.  The Mutex forces the two threads to synchronize

        Do While StopFlag = False
            ResultHolder = AP820Laser2.GetInterleavedData(XArray2, ZArray2, IArray2, ImageNumber21, ImageNumber22)

            ' This Mutex waits until the first laser also has data
            Mut.WaitOne()

            ' Now that both lasers have data, we put the laser 2 data into the global data holders so that the
            ' laser 1 thread can have access to it.

            XArray2Holder = XArray2
            ZArray2Holder = ZArray2
            IArray2Holder = IArray2
            ImageNumber21Holder = ImageNumber21
            ImageNumber22Holder = ImageNumber22
            Mut.ReleaseMutex()
        Loop

    End Sub

    Private Sub btnGetContinuousSyncScansNonInterleaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousSyncScansNonInterleaved.Click
        StopFlag = False
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousSynchronousNonInterleaved)
    End Sub

    Private Sub AcquireContinuousSynchronousNonInterleaved(ByVal StateInfo As Object)

        ' This routine is similar to the routine which acquires continuous interleaved data,
        ' except that it call the GetData function, not the GetInterleavedData function.

        ' The advantage of this routine is that it can operate in Simultaneous Synchronization mode more
        ' efficiently, with the result that it does not drop any scans.

        Dim XArray(290) As UInteger
        Dim ZArray(290) As UInteger
        Dim IArray(290) As UInteger
        Dim XArray2(290) As UInteger
        Dim ZArray2(290) As UInteger
        Dim IArray2(290) As UInteger
        Dim ImageNumber11, ImageNumber21 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim XValue2, ZValue2, XScaler2, ZScaler2 As Single
        Dim I As Integer
        Dim Result1, Result2 As Boolean
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim StrWriter As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = SendToFileFlag And ValidFileNameFlag

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)
        XScaler2 = ((AP820Laser2.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler2 = ((AP820Laser2.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        Do While StopFlag = False

            Result2 = AP820Laser2.GetData(XArray2, ZArray2, IArray2, ImageNumber21)
            Result1 = AP820Laser1.GetData(XArray, ZArray, IArray, ImageNumber11)

            If ImageNumber11 And ImageNumber21 Then
                Me.Invoke(UpdateImageCountDel, ImageNumber11, CUInt(0), ImageNumber21, CUInt(0))
                StrBldr.Length = 0
                If SendToFile Then
                    StrWriter.WriteLine("Image Numbers, " + ImageNumber11.ToString + ", " + ImageNumber21.ToString)
                End If
                For I = 0 To AP820Laser1.ScanInfo.NumXPixels - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    XValue2 = XArray2(I) * XScaler2
                    ZValue2 = ZArray2(I) * ZScaler2
                    StrWriter.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString + Chr(9) + XValue2.ToString("0.0000") + Chr(9) + ZValue2.ToString("0.0000") + Chr(9) + IArray2(I).ToString)
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(StrWriter.ToString)
                End If
                Me.Invoke(FillListDel, StrWriter.ToString)
            Else
                Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0), CUInt(0), CUInt(0))
            End If
        Loop
        StrWriter.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label27.Click

    End Sub
End Class