Imports System
Imports System.Threading
Imports System.Threading.Thread
Imports System.Collections.Generic
Imports System.IO
'Imports System.Text
'Imports System.String

' ================= Important Comments on program structure ===========================

' The AP820Laser class is defined in AP820Class.vb, and directly calls functions
' in EthernetScanner.dll.  AP820Laser1 and AP820Laser2 are two instances of the 
' AP820Laser class and are instantiated in Globals.vb

' The Main Form contains user interface objects which setup, acquire, and display
' data from the first (AP820Laser1) of the two potential lasers supported by the 
' application.  The SecondLaserForm has user interface objects and code which is
' utilized when simultaneous measurements are required from two separate lasers.

' The methodology demonstrated in the SecondLaserForm can be easily extended by 
' analogy to develop code to simultaneously acquire data from three or more lasers,
' if desired.


' =====================================================================================



' ========= Important Comments on program documentation and internal comments =========

' Although well documented, this application assumes familiarity with the AP820 User's
' Manual, and, in particular with Secion 12 which is titled "Programming Using Windows
' DLL Calls"

' Where appropriate, comments within this application refer to the specific sections
' of the manual where additional detail and clarification may be found.  It is highly
' recommended that this application be used "hand-in-hand" with Section 12 of the
' User's Manual.

' =====================================================================================

'    ***************** See IMPORTANT program notes above ******************************

Public Class Form1
    'Stuff Happens
    'more stuff happens
    'lobsters
    Private StopFlag As Boolean
    Private HeightThreshold As Single
    Private UpdateCounts As Integer
    Private GapMode As Boolean
    ' Dim btnBrowseOuput As Control
    ' Private slice(BLOCKSIZE) As Point

    '****************************************************************************************************************
    'Our code begins here
    '****************************************************************************************************************
    Private Sub btnProcessData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessData.Click
        Dim samples As LinkedList(Of Biomass)
        Dim j As Integer
        Dim i As Integer
        Dim k As Integer
        Dim slice(BLOCKSIZE) As Point

        slice = fileIn(Convert.ToString(inFileName.Text)) 'Open the file, start reading slices
        fileOut(Convert.ToString(outFileName.Text), slice)

        'For loop that scans a single slice of data to find the left edge of the object.
        j = 0
        k = 0
        'For i = k To BLOCKSIZE 'size is 580 (0 to 579)

        '    ''''''Once we find that the Z data is higher than the conveyor belt, store that point. That is the left edge.
        '    'If (zDataPoint > ConveyorHeight && zDataPoint - 1 == Conveyor Height && Intensity >=250)
        '    'Set leftEdgeLoc to the first point where it is true, and then return
        '    '
        '    ' 
        '    'On subsequent loops through the scan of data always find the first edge (which may not be the first edge)
        'Next i
        'Return all the LeftEdge's of every object for that scan
    End Sub

    Private Function fileIn(ByVal fileName As String) As Point()
        Dim encoder As String = ""
        Dim curPoint As String = ""
        Dim loc(2) As Integer
        Dim out As String = ""
        Dim counter As Integer
        Dim i As Integer
        Dim j As Integer
        Dim y As Integer
        Dim slice(BLOCKSIZE) As Point
        Dim sr As StreamReader

        'In
        If fileName <> "" Then
            sr = File.OpenText(fileName)
            Do While sr.Peek >= 0
                encoder = sr.ReadLine
                If encoder <> "" Then
                    'DO NOT CHANGE THE NUMBER 8 BELOW! THE ALGORITHM ONLY WORKS IF THE STRING BEING PARSED IS BUILT A CERTAIN WAY!
                    i = encoder.IndexOf("Counts") + 8
                    y = Convert.ToInt32(encoder.Substring(i, encoder.Length - i))

                    For i = 0 To BLOCKSIZE
                        curPoint = sr.ReadLine
                        loc(2) = curPoint.Length
                        counter = 0
                        For j = 0 To loc(2) - 1
                            If (curPoint(j) = Chr(9)) Then 'This checks for tabs, 44 is commas
                                loc(counter) = j
                                counter += 1
                            End If
                        Next j
                        slice(i).x = Convert.ToDouble(curPoint.Substring(0, loc(0)))
                        slice(i).z = Convert.ToDouble(curPoint.Substring(loc(0) + 1, ((loc(1) - loc(0)) - 1)))
                        slice(i).i = Convert.ToInt32(curPoint.Substring(loc(1) + 1, ((loc(2) - loc(1)) - 1)))
                        slice(i).y = y
                    Next i
                End If
                Return slice

                For i = 0 To BLOCKSIZE
                    'Algorithm:
                    'step 1: detect left edge, toss points that match conveyor belt
                    'step 2: if left edge, make new Biomass object *** IF not continuing Object
                    'step 3: add points to Biomass object until right edge detected *** If no right edge found delete biomass Object
                    Dim lEdgeDetected As Boolean = False
                    counter = 0
                    'Do Until lEdgeDetected
                    '    If slice(counter).i > 250 && slice(counter+1)
                    '        counter += 1
                    'Loop

                Next
                'step 4: write biomass object to file to... wherever *** Once object has ended? (FindBotEdge found)

            Loop
        Else
            MsgBox("No input filename specified!", MsgBoxStyle.Exclamation)
        End If
    End Function

    Private Function fileOut(ByVal fileName As String, ByVal val() As Point)
        Dim curPoint As String = ""
        'Dim i As Integer

        'In
        If fileName <> "" Then
            For i = 0 To BLOCKSIZE
                curPoint = ""
                curPoint += Convert.ToString(val(i).x) + "," + Convert.ToString(val(i).y) + "," + Convert.ToString(val(i).z) + "," + Convert.ToString(val(i).i) + vbCrLf
                File.AppendAllText(fileName, curPoint)
            Next i
        Else
            MsgBox("No input filename specified!", MsgBoxStyle.Exclamation)
        End If
    End Function

    '****************************************************************************************************************
    'Acuity code begins here
    '****************************************************************************************************************
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        ' Note: AP820Laser1 is an instance of the AP820Laser class.  It is instantiated in Globals.vb
        ' See comments at the top of MainForm.vb for an important overview of the program structure and 
        ' associated documentation.

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        AP820Laser1.Connect(txtIPAddress.Text, txtPort.Text)
        getStatus()
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        ' See AP820Class.vb for the lower level DLL function which this calls
        AP820Laser1.Disconnect()
        getStatus()
    End Sub

    Private Sub btnGetVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetVersion.Click
        ' See AP820Class.vb for the lower level DLL function which this calls
        txtVersion.Text = AP820Laser1.GetVersion
    End Sub


    Private Function SetLaserMeasurementControlMode(ByVal SampleContinuously As Boolean) As UInteger
        ' See Section 12.8.1 of the User's Manual for a discussion of Trigger Mode vs Continuous Mode
        Dim Buffer(1) As Byte

        Buffer(0) = &H14 'bit 7 is 0, bits 6 to 0 indicate address 20
        If SampleContinuously Then
            'continuous mode
            Buffer(1) = &H80 'bit 7 is 0, bit 3 is 0
        Else
            'trigger mode
            Buffer(1) = &H88 'bit 7 is 1, bit 3 is 1
        End If

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        Return AP820Laser1.WriteData(Buffer, 2)
    End Function

    Private Function SendSoftwareTrigger() As UInteger
        ' See Section 12.8.1 of the User's Manual for a discussion of software triggering.
        Dim Buffer(1) As Byte

        Buffer(0) = &H1D 'bit 7 is 0, bits 6 to 0 indicate address 29
        Buffer(1) = 0 'Can be anything

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        Return AP820Laser1.WriteData(Buffer, 1)
    End Function

    Private Sub btnTurnOnLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurnOnLaser.Click
        ' See Section 12.8.1 of the User's Manual for a discussion of turning the laser on or off.
        Dim Buffer(1) As Byte
        Dim BytesWritten As UInteger

        Buffer(0) = 12 'bit 7 is 0, bits 6 to 0 will add to 12
        Buffer(1) = &H81 'bit 7 is 1, bit 0 is 1

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        BytesWritten = AP820Laser1.WriteData(Buffer, 2)
    End Sub

    Private Sub btnTurnOffLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurnOffLaser.Click
        ' See Section 12.8.1 of the User's Manual for a discussion of turning the laser on or off.
        Dim Buffer(1) As Byte
        Dim BytesWritten As UInteger

        Buffer(0) = 12 'bit 7 is 0, bits 6 to 0 will add to 12
        Buffer(1) = 128 'bit 7 is 1, bit 0 is 0

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        BytesWritten = AP820Laser1.WriteData(Buffer, 2)
    End Sub

    Private Sub btnGetInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfo.Click
        Dim Result As Boolean

        lstEthernetScanInfo.Items.Clear()

        'Call the GetInfo function before acquiring data, because this sets up the ScanInfo structure in the AP820Laser class
        'so you will have access to required parameters for calculations, like AP620Class.ScanInfo.MeasuringRange, for example

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        Result = AP820Laser1.GetInfo()

        ' ========= Any application specific code using data returned by GetInfo would be inserted here =======




        ' ========= The following code simply displays the information returned by GetInfo ====================
        If Result Then
            lstEthernetScanInfo.Items.Add("Serial Number: " + AP820Laser1.ScanInfo.SerialNumber)
            lstEthernetScanInfo.Items.Add("Firmware Version: " + AP820Laser1.ScanInfo.FirmwareVersion)
            lstEthernetScanInfo.Items.Add("Beginning of Measuring Range: " + AP820Laser1.ScanInfo.BeginningOfMeasuringRange.ToString)
            lstEthernetScanInfo.Items.Add("Measuring Range: " + AP820Laser1.ScanInfo.MeasuringRange.ToString)
            txtMaxZ.Text = (AP820Laser1.ScanInfo.MeasuringRange / 10).ToString("#0.0")
            lstEthernetScanInfo.Items.Add("Scan Range Beginning: " + AP820Laser1.ScanInfo.ScanRangeBeginning.ToString)
            lstEthernetScanInfo.Items.Add("Scan Range End: " + AP820Laser1.ScanInfo.ScanRangeEnd.ToString)
            lstEthernetScanInfo.Items.Add("Max Z Linearized: " + AP820Laser1.ScanInfo.MaxZLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Max X Linearized: " + AP820Laser1.ScanInfo.MaxXLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Max Z Non-Linearized: " + AP820Laser1.ScanInfo.MaxZNonLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Max X Non-Linearized: " + AP820Laser1.ScanInfo.MaxXNonLinearized.ToString)
            lstEthernetScanInfo.Items.Add("Number of Z Pixels: " + AP820Laser1.ScanInfo.NumZPixels.ToString)
            lstEthernetScanInfo.Items.Add("Number of X Pixels: " + AP820Laser1.ScanInfo.NumXPixels.ToString)
            lstEthernetScanInfo.Items.Add("Scanner Temperature: " + AP820Laser1.ScanInfo.ScannerTemperature.ToString)
            lstEthernetScanInfo.Items.Add("Operating Seconds Counter: " + AP820Laser1.ScanInfo.OperatingSecondsCounter.ToString)
            lstEthernetScanInfo.Items.Add("Power Cycle Counter: " + AP820Laser1.ScanInfo.PowerCycleCounter.ToString)
            lstEthernetScanInfo.Items.Add("Fifo: " + AP820Laser1.ScanInfo.Fifo.ToString)
            lstEthernetScanInfo.Items.Add("Position Encoder: " + AP820Laser1.ScanInfo.PositionEncoder.ToString)
            lstEthernetScanInfo.Items.Add("Position Encoder Direction: " + AP820Laser1.ScanInfo.PositionEncoderDirection.ToString)
            lstEthernetScanInfo.Items.Add("Protocol: " + AP820Laser1.ScanInfo.Protocol.ToString)
            lstEthernetScanInfo.Items.Add("Linearization: " + AP820Laser1.ScanInfo.Linearization.ToString)
            lstEthernetScanInfo.Items.Add("Camera Mode: " + AP820Laser1.ScanInfo.CameraMode.ToString)
            lstEthernetScanInfo.Items.Add("Profile Mode: " + AP820Laser1.ScanInfo.ProfileMode.ToString)
            lstEthernetScanInfo.Items.Add("Scanner Mode: " + AP820Laser1.ScanInfo.ScannerMode.ToString)
            lstEthernetScanInfo.Items.Add("Shutter Time Manual: " + AP820Laser1.ScanInfo.ShutterTimeManual.ToString)
            lstEthernetScanInfo.Items.Add("Shutter Time Auto: " + AP820Laser1.ScanInfo.ShutterTimeAuto.ToString)
            lstEthernetScanInfo.Items.Add("Pixel Readout Start: " + AP820Laser1.ScanInfo.PixelReadOutStart.ToString)
            lstEthernetScanInfo.Items.Add("Pixel Readout End: " + AP820Laser1.ScanInfo.PixelReadOutEnd.ToString)
            lstEthernetScanInfo.Items.Add("Video Gain: " + AP820Laser1.ScanInfo.VideoGain.ToString)
            lstEthernetScanInfo.Items.Add("Linear Intesity Threshold: " + AP820Laser1.ScanInfo.LaserIntensityThreshold.ToString)
            lstEthernetScanInfo.Items.Add("Laser Target Value: " + AP820Laser1.ScanInfo.LaserTargetValue.ToString)
            lstEthernetScanInfo.Items.Add("Peak Width Limit: " + AP820Laser1.ScanInfo.PeakWidthLimit.ToString)
            lstEthernetScanInfo.Items.Add("Peak Threshold: " + AP820Laser1.ScanInfo.PeakThreshold.ToString)
            lstEthernetScanInfo.Items.Add("Synchronization: " + AP820Laser1.ScanInfo.Synchronization.ToString)
            lstEthernetScanInfo.Items.Add("Protocol Version: " + AP820Laser1.ScanInfo.ProtocolVersion.ToString)
            lstEthernetScanInfo.Items.Add("Shutter Control: " + AP820Laser1.ScanInfo.ShutterControl.ToString)
            lstEthernetScanInfo.Items.Add("Linearization 2: " + AP820Laser1.ScanInfo.Linearization2.ToString)
            lstEthernetScanInfo.Items.Add("Speed: " + AP820Laser1.ScanInfo.Speed.ToString)
            lstEthernetScanInfo.Items.Add("FPGA Version: " + AP820Laser1.ScanInfo.FPGAVersion.ToString)
            lstEthernetScanInfo.Items.Add("Digital Input: " + AP820Laser1.ScanInfo.DigitalInput.ToString)
            lstEthernetScanInfo.Items.Add("Laser Value of Profile: " + AP820Laser1.ScanInfo.LaserValueOfProfile.ToString)
        End If

        'GraphControl1.SetLimits(0, 4096, 0, 4096)
        'GraphControl1.SetScale(0, AP820Laser1.ScanInfo.ScanRangeEnd / 10, 0, AP820Laser1.ScanInfo.MeasuringRange / 10)
        GraphControl1.SetLimits(0, 4096, 0, 4096 * (10 / (AP820Laser1.ScanInfo.MeasuringRange / 10)))
        GraphControl1.SetScale(0, AP820Laser1.ScanInfo.ScanRangeEnd / 10, 0, 10)

    End Sub

    Private Sub btnSingleScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSingleScan.Click
        Dim XArray(290) As UInteger
        Dim ZArray(290) As UInteger
        Dim IArray(290) As UInteger
        Dim ImageNumber As Byte
        Dim Result As Boolean
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'This is the simplest example.  It gets the lastest, single scan from the laser, scales
        'the data, displays it, and ends.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Following is not laser related, but simply sets up file output, if the "Send to File" checkbox is checked
        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        'Get the latest scan

        ' See AP820Class.vb for the details of the AP820.GetData function

        Result = AP820Laser1.GetData(XArray, ZArray, IArray, ImageNumber)
        If Result Then

            ' If Result is True, we now have raw, unscaled data

            ' ===== Any application specific code using data returned by GetData would be inserted here =======




            ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

            txtImageNumber.Text = ImageNumber.ToString
            StrBldr.Length = 0
            If SendToFile Then
                strw.WriteLine("Image Number, " + ImageNumber.ToString)
            End If
            'scale data in mm
            For I = 0 To AP820Laser1.ScanInfo.NumXPixels - 1
                XValue = XArray(I) * XScaler
                ZValue = ZArray(I) * ZScaler
                strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
            Next
            If SendToFile Then
                StreamWtr.WriteLine(strw.ToString)
            End If
            'show results
            txtData.Text = strw.ToString
            GraphControl1.PlotArrays(XArray, ZArray, 290)

        Else
            txtImageNumber.Text = "Error"
        End If
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnGetInterleaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInterleaved.Click
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'This is the same simple example as the GetSingleScan function, except that this calls GetInterleavedData
        'which returns two interleaved scans and put them in order.
        'Get the data, scale and display it, then quit.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        'Get the lastest 2 interleaved scans

        ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function

        Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

        If Result Then

            ' If Result is True, we now have raw, unscaled data

            ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




            ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

            ' Note: We display the image numbers of the two interleaved scans, which should be sequential
            txtImageNumber.Text = ImageNumber1.ToString
            txtImageNumber2.Text = ImageNumber2.ToString
            StrBldr.Length = 0
            If SendToFile Then
                strw.WriteLine("Image Number, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString)
            End If
            'Scale data to mm
            For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                XValue = XArray(I) * XScaler
                ZValue = ZArray(I) * ZScaler

                'this line prints tabs, and is designed for streaming to a .txt
                'strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString + Chr(9))

                'this line prints commas, and is designed for streaming to a .csv
                strw.WriteLine(XValue.ToString("0.0000") + Chr(44) + ZValue.ToString("0.0000") + Chr(44) + IArray(I).ToString + Chr(44))
            Next
            If SendToFile Then
                StreamWtr.WriteLine(strw.ToString)
            End If
            'Display data
            txtData.Text = strw.ToString
            GraphControl1.PlotArrays(XArray, ZArray, 580)
        Else
            txtImageNumber.Text = "Error"
            txtImageNumber2.Text = "Error"
        End If
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnSendTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTrigger.Click
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'This function is meant to be called in trigger mode, to show how software triggering works.
        'When the laser is in trigger mode, it does 2 interleaved scans, numbered 1 and 2, and the
        'Image numbers do not go beyond 1 and 2
        'This is the same as GetInterleavedScan, except that it calls SendSoftwareTrigger() first
        'or no data will be returned in trigger mode.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        'Trigger a laser scan.
        'The laser actually does 2 interleaved scans when triggered in trigger mode, numbered 1 and 2
        SendSoftwareTrigger()
        'Get the lastest 2 interleaved scans

        ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
        Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

        If Result Then



            ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




            ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===


            txtImageNumber.Text = ImageNumber1.ToString
            txtImageNumber2.Text = ImageNumber2.ToString
            StrBldr.Length = 0
            If SendToFile Then
                strw.WriteLine("Image Number, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString)
            End If
            For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                XValue = XArray(I) * XScaler
                ZValue = ZArray(I) * ZScaler
                strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
            Next
            If SendToFile Then
                StreamWtr.WriteLine(strw.ToString)
            End If
            txtData.Text = strw.ToString
            GraphControl1.PlotArrays(XArray, ZArray, 580)
        Else
            txtImageNumber.Text = "Error"
            txtImageNumber2.Text = "Error"
        End If
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub FillList(ByVal ListData As String)
        'This function is meant to be called by a delegate in another thread
        txtData.Text = ListData
    End Sub

    Private Sub UpdateImageCount(ByVal ImageNumber1 As UInteger, ByVal ImageNumber2 As UInteger)
        'This function is meant to be called by a delegate in another thread
        If ImageNumber1 > 0 Then
            txtImageNumber.Text = ImageNumber1.ToString
            txtImageNumber2.Text = ImageNumber2.ToString
        Else
            txtImageNumber.Text = "Error"
            txtImageNumber2.Text = "Error"
        End If
    End Sub

    Private Sub ShowTriggerStatus(ByVal Status As Integer)
        'This function is meant to be called by a delegate in another thread
        Select Case Status
            Case 0
                lblWaitingForTrigger.Visible = False
                lblDataReceived.Visible = False
            Case 1
                lblWaitingForTrigger.Visible = True
                lblDataReceived.Visible = False
            Case 2
                lblWaitingForTrigger.Visible = False
                lblDataReceived.Visible = True
        End Select
    End Sub

    Private Sub ShowDroppedScans(ByVal NumberOfDroppedScans As Integer)
        'This function is meant to be called by a delegate in another thread
        txtDropped.Text = NumberOfDroppedScans.ToString
    End Sub

    Private Sub ShowEncoderCounts(ByVal EncoderCounts As Integer)
        'This function is meant to be called by a delegate in another thread
        txtEncoderPos.Text = EncoderCounts.ToString
    End Sub

    Private Sub ShowSampleRate(ByVal SampleRate As Single)
        'This function is meant to be called by a delegate in another thread
        txtSampleRate.Text = SampleRate.ToString("0.00")
    End Sub
    Private Sub PlotData(ByVal XArray() As UInteger, ByVal ZArray() As UInteger, ByVal Length As Integer)
        'This function is meant to be called by a delegate in another thread
        GraphControl1.PlotArrays(XArray, ZArray, Length)
    End Sub

    Private Sub ShowWidthCalculation(ByVal LeftEdge As Single, ByVal RightEdge As Single, ByVal WidthCalc As Single)
        'This function is meant to be called by a delegate in another thread
        If WidthCalc <> (-1) Then
            txtLeftEdge.Text = LeftEdge.ToString("0.00")
            txtRightEdge.Text = RightEdge.ToString("0.00")
            txtWidth.Text = WidthCalc.ToString("0.00")
        Else
            If LeftEdge <> (-1) Then
                txtLeftEdge.Text = LeftEdge.ToString("0.00")
            Else
                txtLeftEdge.Text = "-"
            End If
            txtRightEdge.Text = "-"
            txtWidth.Text = "-"
        End If
    End Sub

    Private Sub ShowPeakCalculation(ByVal Peak As Single, ByVal PeakPosition As Single)
        If Peak <> -1 Then
            txtPeak.Text = Peak.ToString("0.00")
            txtPeakPos.Text = PeakPosition.ToString("0.00")
        Else
            txtPeak.Text = "-"
            txtPeakPos.Text = "-"
        End If
    End Sub

    'Delegates required so that other threads can update displays on the main panel
    Delegate Sub FillListDelegate(ByVal ListData As String)
    Delegate Sub UpdateImageCountDelegate(ByVal ImageNumber1 As UInteger, ByVal ImageNumber2 As UInteger)
    Delegate Sub ShowTriggerStatusDelegate(ByVal Status As Integer)
    Delegate Sub ShowDroppedScansDelegate(ByVal NumberOfDroppedScans As Integer)
    Delegate Sub ShowEncoderCountsDelegate(ByVal EncoderCounts As Integer)
    Delegate Sub ShowSampleRateDelegate(ByVal SampleRate As Single)
    Delegate Sub PlotDataDelegate(ByVal XArray() As UInteger, ByVal ZArray() As UInteger, ByVal Length As Integer)
    Delegate Sub ShowWidthCalculationDelgate(ByVal LeftEdge As Single, ByVal RightEdge As Single, ByVal WidthCalc As Single)
    Delegate Sub ShowPeakCalculationDelegate(ByVal Peak As Single, ByVal PeakPosition As Single)









    Private Sub AcquireContinuousForPeakCalculation(ByVal StateInfo As Object)
        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Static Dim ZArrayReferencedToFarEndOfLaserRange(580) As UInteger
        Static Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim MaxHeightSoFar, XPositionOfPeak As Single
        Dim UpdateCounter As Integer

        ' Following two delegates are required because you cannot access an on screen display from other than the thread
        ' which created them.

        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim ShowPeakCalculationDel As New ShowPeakCalculationDelegate(AddressOf ShowPeakCalculation)

        'Intended to run in its own thread
        'Stop button aborts this function

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Update counter is used in determining how often to display calculated width on the screen.
        UpdateCounter = 0
        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            ' If we have successfully acquired an interleaved scan, then we analyze the data
            If Result Then

                ' Initialize the MaxHeightSoFarf to -1, because a positive value will later be
                ' used to show that we have valid results to display

                MaxHeightSoFar = -1

                ' Do twice number of pixels because we are interleaving scans

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1

                    'for this application, we will display distances from the far end of the laser z range
                    'thus, for example, for objects on a table, the graph will look like the profile of
                    'the object.

                    ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)

                    'see if this is a legitimate measurement based on the intensity > 10

                    If (IArray(I) > 10) Then
                        'Valid intensity, so look to see if the current point is higher than the threshold,
                        'if so, it can be a candidate for the peak.
                        If ZValue > HeightThreshold Then
                            If ZValue > MaxHeightSoFar Then
                                MaxHeightSoFar = ZValue
                                XPositionOfPeak = XArray(I) * XScaler
                            End If
                        End If
                    End If
                Next

                ' Following just takes the Zarray which was measured from the close end of the laser range
                ' and calculates the Z distances from the far end of the laser range, so that they are ready
                ' for plotting.

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    If ZArray(I) <= 4096 Then
                        ZArrayReferencedToFarEndOfLaserRange(I) = 4096 - ZArray(I)
                    Else
                        ZArrayReferencedToFarEndOfLaserRange(I) = ZArray(I)
                    End If
                Next

                ' Update counter determines how often we display width on screen
                UpdateCounter += 1

                'If UpdateCounter >= UpdateCounts Then
                ' Update the graph and show the left and right edge positions and width.
                Me.Invoke(PlotDataDel, XArray, ZArrayReferencedToFarEndOfLaserRange, 580)
                Me.Invoke(ShowPeakCalculationDel, MaxHeightSoFar, XPositionOfPeak)
                UpdateCounter = 0
                Sleep(UpdateCounts)
                ' End If
            Else
                ' Following will show -1 if don't get a valid width calculation
                Me.Invoke(ShowPeakCalculationDel, -1, -1)
            End If
        Loop
    End Sub




    Private Sub btnTriggerMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTriggerMode.Click
        ' Setting the LaserMeasurementControlMode to False disables continuous scanning and sets the laser to
        ' trogger mode which requires either a software or a hardware trigger.

        SetLaserMeasurementControlMode(False)

        ' Next command actually sends a software trigger because the laser actually ignores the first
        ' software or hardware trigger it sees after being set to Trigger Mode
        SendSoftwareTrigger()
    End Sub

    Private Sub btnContinuousMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuousMode.Click
        ' Setting the LaserMeasurementControlMode to True enables continuous scanning.
        SetLaserMeasurementControlMode(True)
    End Sub

    Private Sub btnGetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStatus.Click
        getStatus()
    End Sub

    Private Sub getStatus() Handles btnConnect.MouseMove
        Dim Status As UInteger
        ' See AP820Class.vb for the lower level DLL function which the following function calls

        Status = AP820Laser1.GetStatus
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


    Private Sub btnSingleHardwareTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSingleHardwareTrigger.Click
        StopFlag = False
        ' We acquire data in a dedicated thread, because the acquisition code is in
        ' a tight loop waiting for AP820Laser1.GetInterleavedData to return a True, indicating
        ' that data has been returned from the trigger.
        ThreadPool.QueueUserWorkItem(AddressOf AcquireWhenTriggered)
    End Sub

    Private Sub AcquireWhenTriggered(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim ShowTriggerStatusDel As New ShowTriggerStatusDelegate(AddressOf ShowTriggerStatus)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'Intended to run in its own thread
        'This functin is intended to be called in trigger mode.  GetInterleavedScan will return false until
        'a trigger is detected.  This trigger will cause the laser to acquire 2 interleaved scans numbered
        '1 and 2
        'Stop button aborts this function

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)
        Me.Invoke(ShowTriggerStatusDel, 1)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        ' IMPORTANT NOTE: We simply continue looping until we have some data to read back or someone has hit
        ' the Stop Hardware Triggered Scan Button.

        ' Since the laser responds identically when it receives a software trigger or a hardware trigger
        ' we can hit the Generate Software Trigger button to simulate the arrival of a true hardware
        ' trigger

        Do While Result = False And StopFlag = False
            'Wait for a trigger. GetInterleavedData will return a false until it gets valid image numbers.
            'The laser actually does 2 interleaved scans when triggered in trigger mode, numbered 1 and 2

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)
        Loop

        If Not StopFlag Then
            If Result Then


                ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




                ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

                Me.Invoke(UpdateImageCountDel, ImageNumber1, ImageNumber2)
                StrBldr.Length = 0
                If SendToFile Then
                    strw.WriteLine("Image Numbers, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString)
                End If
                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(strw.ToString)
                End If
                Me.Invoke(FillListDel, strw.ToString)
                Me.Invoke(ShowTriggerStatusDel, 2)
                Me.Invoke(PlotDataDel, XArray, ZArray, 580)
            Else
                Me.Invoke(UpdateImageCountDel, 0, 0)
                Me.Invoke(ShowTriggerStatusDel, 2)
            End If
        Else
            Me.Invoke(ShowTriggerStatusDel, 2)
        End If
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnStopTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopTrigger.Click
        StopFlag = True
    End Sub

    Private Sub btnGetContinuousHardwareTriggeredScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousHardwareTriggeredScans.Click

        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.

        StopFlag = False
        ' Start the thread, calling the subroutine whose code follows shortly. 
        ThreadPool.QueueUserWorkItem(AddressOf AcquireWhenTriggeredContinuous)
    End Sub

    Private Sub AcquireWhenTriggeredContinuous(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'Intended to run in its own thread
        'Stop button aborts this function

        ' IMPORTANT NOTE: 
        'This function is similar to AcquireWhenTriggered, but does not end after one trigger, but
        'simply begins looking for the next data set to be returned by AP820Laser1.GetInterleavedData
        'which indicates that a new trigger has come in.  

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        Do While StopFlag = False

            Result = False
            Do While Result = False And StopFlag = False
                'Wait for a trigger. GetInterleavedData will return a false until it gets valid image numbers.
                'The laser actually does 2 interleaved scans when triggered in trigger mode, numbered 1 and 2

                ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
                Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)
            Loop

            If Not StopFlag Then
                If Result Then

                    ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




                    ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

                    Me.Invoke(UpdateImageCountDel, ImageNumber1, ImageNumber2)
                    StrBldr.Length = 0
                    If SendToFile Then
                        strw.WriteLine("Image Numbers, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString)
                    End If
                    For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                        XValue = XArray(I) * XScaler
                        ZValue = ZArray(I) * ZScaler
                        strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
                    Next
                    If SendToFile Then
                        StreamWtr.WriteLine(strw.ToString)
                    End If
                    Me.Invoke(FillListDel, strw.ToString)
                    Me.Invoke(PlotDataDel, XArray, ZArray, 580)
                Else
                    Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0))
                End If
            End If
        Loop
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnGetContinuousScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousScans.Click

        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.
        ' We acquire scans in a loop, and stop the loop when a button click sets the StopFlag to True

        ' Initialize the StopFlag to False, so that the loop can begin scanning
        StopFlag = False
        ' Start the thread, calling the subroutine AcquireContinuous whose code follows shortly.
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuous)
    End Sub


    Private Sub AcquireContinuous(ByVal StateInfo As Object)
        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'Intended to run in its own thread
        'Stop button aborts this function
        'This function is intended to run in continuous (non-triggered mode)
        'Similar to GetInterleavedScan, but does not quit after one scan.  Instead, it runs continuously
        'until the stop button is pressed.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Following is not laser related, but simply sets up file output, if the "Send to File" checkbox is checked
        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        ' Simply get and analyze data in a loop, stopping when a button click sets the StopFlag to True

        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            If Result Then

                ' If Result is True, we now have raw, unscaled data

                ' ===== Any application specific code using data returned by GetData would be inserted here =======




                ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

                ' Since threads are not allowed to update displays generated by other threads (like the main 
                ' thread) we have to use a delegate (such as UpdateImageCountDel) to update the image counter
                ' on the main screen.

                Me.Invoke(UpdateImageCountDel, ImageNumber1, ImageNumber2)
                StrBldr.Length = 0
                If SendToFile Then
                    strw.WriteLine("Image Numbers, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString)
                End If
                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(strw.ToString)
                End If

                ' Similarly, we use delegates to write the data to the main screen and to plot it
                Me.Invoke(FillListDel, strw.ToString)
                Me.Invoke(PlotDataDel, XArray, ZArray, 580)
            Else
                ' If acquisition failed for some reason, we come here and write error msg to the screen
                ' again, using the UpdateImageCountDel delegate.
                Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0))
            End If
        Loop
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub AcquireContinuousWithZRangeDetermination(ByVal StateInfo As Object)
        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag
        Dim MaxObservedZ As Single
        Dim MinObservedZ As Single
        Dim ShowPeakCalculationDel As New ShowPeakCalculationDelegate(AddressOf ShowPeakCalculation)


        'Intended to run in its own thread
        'Stop button aborts this function
        'This function is intended to run in continuous (non-triggered mode)
        'Similar to GetInterleavedScan, but does not quit after one scan.  Instead, it runs continuously
        'until the stop button is pressed.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)


        ' Simply get and analyze data in a loop, stopping when a button click sets the StopFlag to True

        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            If Result Then

                ' If Result is True, we now have raw, unscaled data

                ' ===== Any application specific code using data returned by GetData would be inserted here =======


                ' Initialize max and min prior to analyzing data from the current scan.
                ' Anytime a value is observed larger than MaxObservedZ, we'll set
                ' MaxObservedZ to this new value.  Similarly anytime a value is observed smaller 
                ' than the MinObservedZ, we'll set MinObservedZ to this new value.

                ' At the end of each scan, we'll display these values in previously utilized
                ' on-screen numerical displays.

                MaxObservedZ = -1000
                MinObservedZ = 1000


                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    ' Only consider valid measurements. User Intensity > 10 as the criterion
                    If IArray(I) > 10 Then
                        XValue = XArray(I) * XScaler
                        ZValue = ZArray(I) * ZScaler
                        If ZValue > MaxObservedZ Then
                            MaxObservedZ = ZValue
                        End If
                        If ZValue < MinObservedZ Then
                            MinObservedZ = ZValue
                        End If
                    End If

                Next


                ' Rather than define a new delegate, we'll simply use one designed
                ' previously for the Peak determination routine.

                Me.Invoke(ShowPeakCalculationDel, MaxObservedZ, MinObservedZ)

                Me.Invoke(PlotDataDel, XArray, ZArray, 580)
            Else
                ' If acquisition failed for some reason, we come here and write error msg to the screen
                ' again, using the UpdateImageCountDel delegate.
                Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0))
            End If
        Loop


    End Sub

    Private Sub btnStopContinuous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopContinuous.Click
        StopFlag = True
    End Sub

    Private Sub btnGetContinuousOptimized_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousOptimized.Click
        StopFlag = False
        ' Start a dedicated thread to allow the main thread to be responsive to user
        ' interface activities. See next subtroutine for code for this new thread.
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousOptimizedForSpeed)
    End Sub


    Private Sub AcquireContinuousOptimizedForSpeed(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2, NextImageNumber As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim NumberOfDroppedScans As Integer
        Dim Result As Boolean
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim ShowDroppedScansDel As New ShowDroppedScansDelegate(AddressOf ShowDroppedScans)
        Dim ShowSampleRateDel As New ShowSampleRateDelegate(AddressOf ShowSampleRate)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag
        Dim StartTime, EndTime As DateTime
        Dim NumberOfSamples As UInteger
        Dim SampleRate As Single

        'Important Note: The difference between this function and the regular AcuireContinuous function is that
        'this one does not update the main text display or the plots.  Therefore, it gets around the loop fast enough to keep up
        'with the laser.  Most modern PCs should also be able to stream to file without dropping scans.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)
        NumberOfDroppedScans = 0
        NextImageNumber = 255
        Me.Invoke(ShowDroppedScansDel, NumberOfDroppedScans)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        NumberOfSamples = 0
        StartTime = Now
        Do While StopFlag = False

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            If Result Then

                ' If Result is True, we now have raw, unscaled data

                ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




                ' ===== The following code simply updates a minimal number of on-screen displays, and writes to file if desired ===

                ' Note: We display the image numbers of the two interleaved scans, which should be sequential

                Me.Invoke(UpdateImageCountDel, ImageNumber1, ImageNumber2)
                StrBldr.Length = 0
                If SendToFile Then
                    strw.WriteLine("Image Numbers, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString)
                End If
                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    If SendToFile Then
                        strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
                    End If
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(strw.ToString)
                End If
            Else
                Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0))
            End If
            If NextImageNumber <> 255 Then
                If ImageNumber1 <> NextImageNumber Then
                    NumberOfDroppedScans = NumberOfDroppedScans + 1
                    Me.Invoke(ShowDroppedScansDel, NumberOfDroppedScans)
                End If
            End If
            NextImageNumber = ImageNumber2 + 1
            If NextImageNumber > 253 Then
                NextImageNumber = 0
            End If
            NumberOfSamples = NumberOfSamples + 1
        Loop
        EndTime = Now
        SampleRate = NumberOfSamples / (EndTime - StartTime).TotalSeconds
        Me.Invoke(ShowSampleRateDel, SampleRate)
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnTurnOnAmbientLightFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurnOnALF.Click
        Dim Buffer(1) As Byte
        Dim BytesWritten As UInteger

        ' Methodology utilized is identical to that used to turn the laser on or off.  See Section 12.8.1 of the User's Manual
        Buffer(0) = 13 'bit 7 is 0, bits 6 to 0 will add to 13
        Buffer(1) = &H81 'bit 7 is 1, bit 0 is 1
        BytesWritten = AP820Laser1.WriteData(Buffer, 2)
    End Sub

    Private Sub btnTurnOffAmbientLightFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurnOffALF.Click
        Dim Buffer(1) As Byte
        Dim BytesWritten As UInteger


        ' Methodology utilized is identical to that used to turn the laser on or off.  See Section 12.8.1 of the User's ManualBuffer(0) = 13 'bit 7 is 0, bits 6 to 0 will add to 13
        Buffer(0) = 13 'bit 7 is 0, bits 6 to 0 will add to 13
        Buffer(1) = &H80 'bit 7 is 1, bit 0 is 0
        BytesWritten = AP820Laser1.WriteData(Buffer, 2)
    End Sub

    Private Sub btnGetInfoFromData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfoFromData.Click
        ' Bookmark

        ' Important Note: Certain AP820 parameters and settings (such as the field of view) can only be read 
        ' back from the laser by triggering a measurement and reading back the settings which are returned with
        ' the acquired data. So here we trigger a scan, but focus on reading back and displaying the laser 
        ' settings.

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

        ' See AP820Class.vb for the lower level DLL function which the following function calls

        Result = AP820Laser1.GetDataRaw(Buffer)

        If Result Then

            ' If Result is True, we now have data

            ' ========= Any application specific code using data returned by GetDataRaw would be inserted here =======
            '
            ' For example, one might wish to determine the current field of view to set up graph scaling prior
            ' to actually acuiring data.


            ' ========= The following code simply displays the information returned by GetDataRaw ====================



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
            Amplification = (Amplification << 7) + (Buffer(1530 + 6) And &H7F)
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

    Private Sub btnResetEncoder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetEncoder.Click
        Dim Buffer(1) As Byte

        ' This function simply sets the encoder counts to zero.

        Buffer(0) = &HE 'bit 7 is 0, bits 6 to 0 indicate address 14
        Buffer(1) = 0 'Can be anything

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        AP820Laser1.WriteData(Buffer, 1)
        txtEncoderPos.Text = "0"
    End Sub

    Private Sub btnSendSoftwareTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendSoftwareTrigger.Click

        ' Important Notes:
        ' 1. Sending a software trigger only triggers the scan.  To get the data, one must call the
        '    GetInterleavedData function.
        ' 2. It is important to note that the laser itself responds identically when one sends a software
        '    trigger or when one sends a hardware trigger via the Synch In line.  Thus, we can use this
        '    function to substitute for a hardware trigger when demonstrating the use of the
        '    Get Hardware Triggered Scan button.

        SendSoftwareTrigger()
    End Sub

    Private Sub btnSetMaxForZRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetMaxForZRange.Click
        Dim MaxVal As Single
        Dim Pixels As Integer

        ' See Section 12.8.2 of the User's Manual for a discussion of limiting the Z range of the laser.
        MaxVal = Val(txtMaxZ.Text)
        If MaxVal > 0 And MaxVal <= (AP820Laser1.ScanInfo.MeasuringRange * 0.1) Then
            'convert to pixels
            Pixels = AP820Laser1.ScanInfo.NumZPixels * (MaxVal / (AP820Laser1.ScanInfo.MeasuringRange * 0.1))
            SetMaxForZRange(Pixels)
        End If
    End Sub

    Private Function SetMaxForZRange(ByVal Pixels As UInteger) As UInteger
        Dim Buffer(1) As Byte
        Dim PixelArg As Byte

        Buffer(0) = &H5 'bit 7 is 0, bits 6 to 0 are 5
        'generate the arguement for the correct number of pixels
        'which is one eighth the number of pixels
        PixelArg = CByte(Pixels / 8)
        Buffer(1) = &H80 Or PixelArg 'put a 1 in bit 7 and number of pixels in bits 6-0

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        Return AP820Laser1.WriteData(Buffer, 2)

    End Function


    Private Sub btnSetMinForZRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetMinForZRange.Click
        Dim MinVal As Single
        Dim Pixels As Integer

        ' See Section 12.8.2 of the User's Manual for a discussion of limiting the Z range of the laser.
        MinVal = Val(txtMinZ.Text)
        If MinVal >= 0 And MinVal <= (AP820Laser1.ScanInfo.MeasuringRange * 0.1) Then
            'convert to pixels
            Pixels = AP820Laser1.ScanInfo.NumZPixels * (MinVal / (AP820Laser1.ScanInfo.MeasuringRange * 0.1))
            SetMinForZRange(Pixels)
        End If
    End Sub


    Private Function SetMinForZRange(ByVal Pixels As UInteger) As UInteger
        Dim Buffer(1) As Byte
        Dim PixelArg As Byte

        Buffer(0) = &H4 'bit 7 is 0, bits 6 to 0 are 4
        'generate the arguement for the correct number of pixels
        'which is one eighth the number of pixels
        PixelArg = CByte(Pixels / 8)
        Buffer(1) = &H80 Or PixelArg 'put a 1 in bit 7 and number of pixels in bits 6-0

        ' See AP820Class.vb for the lower level DLL function which the following function calls
        Return AP820Laser1.WriteData(Buffer, 2)

    End Function

    Private Sub bthGetContinuousWithEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bthGetContinuousWithEnc.Click

        'IMPORTANT INSTRUCTIONS FOR WIRING ENCODER
        ' 1. Insure that encoder power supply is no greater than 5 VDC
        ' 2. Connect A phase to Digital Input 1
        ' 3. Connect B phase to Digital Input 2
        ' 4. Connect encoder ground to laser power ground

        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.

        StopFlag = False
        ' Start the thread, calling the subroutine whose code follows shortly.
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousWithEncoder)
    End Sub

    Private Sub AcquireContinuousWithEncoder(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim EncoderBuf(3) As Byte
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim EncoderCounts As Integer
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim ShowEncoderCountsDel As New ShowEncoderCountsDelegate(AddressOf ShowEncoderCounts)
        Dim StrBldr As New System.Text.StringBuilder(4096)
        Dim strw As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'Intended to run in its own thread
        'Stop button aborts this function
        'Intended to run in continuous mode, similar to AcquireContinuous, calls an overloaded version
        'of GetInterleavedData that extracts the encoder count from the data buffer.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        Do While StopFlag = False

            'Call the overloaded GetInterleavedData that also returns the encoder results.

            'IMPORTANT NOTE: A single encoder measurement is made for the entire interleaved scan.

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2, EncoderBuf)

            If Result Then
                Me.Invoke(UpdateImageCountDel, ImageNumber1, ImageNumber2)
                'Convert encoder data to encoder counts.
                'See Section 7.2 of the User's Manual which describes how this number is formatted
                EncoderCounts = EncoderBuf(3) And &H3F
                EncoderCounts = (EncoderCounts << 7) + (EncoderBuf(2) And &H7F)
                EncoderCounts = (EncoderCounts << 7) + (EncoderBuf(1) And &H7F)
                EncoderCounts = (EncoderCounts << 7) + (EncoderBuf(0) And &H7F)
                'Bit 27 is sign bit
                If (EncoderCounts And &H800000) = &H800000 Then
                    'This is a negative number
                    'Get 1's complement
                    EncoderCounts = (Not EncoderCounts) And &H7FFFFF
                    'Get 2's complement
                    EncoderCounts = EncoderCounts + 1
                    'flip sign
                    EncoderCounts = EncoderCounts * (-1)
                End If

                ' Now that we have decoded the encoder position for the scan, we can proceed.

                ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




                ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

                ' Following delegate simply displays the encoder position for the current scan on the screen.

                Me.Invoke(ShowEncoderCountsDel, EncoderCounts)
                StrBldr.Length = 0
                If SendToFile Then
                    strw.WriteLine("Image Numbers, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString + " Encoder Counts, " + EncoderCounts.ToString)
                End If
                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler
                    ZValue = ZArray(I) * ZScaler
                    strw.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
                Next
                If SendToFile Then
                    StreamWtr.WriteLine(strw.ToString)
                End If
                Me.Invoke(FillListDel, strw.ToString)
                Me.Invoke(PlotDataDel, XArray, ZArray, 580)
            Else
                Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0))
            End If
        Loop
        strw.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub

    Private Sub btnGetContinuousHardwareTriggeredWithEncoder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContinuousHardwareTriggeredWithEncoder.Click

        'IMPORTANT INSTRUCTIONS FOR WIRING ENCODER SO THAT IT GENERATES HARDWARE TRIGGERS.

        ' 1. Insure that encoder power supply is no greater than 5 VDC
        ' 2. Connect A phase to Digital Input 1
        ' 3. Connect B phase to Digital Input 2
        ' 4. Connect encoder ground to laser power ground.
        ' 5. Connect either the A phase or the B phase to Synch In so that the hardware trigger
        '    will be generated by the selected phase.

        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.

        StopFlag = False
        ' Start the thread, calling the subroutine whose code follows shortly.
        ThreadPool.QueueUserWorkItem(AddressOf AcquireWhenTriggeredContinuousWithEncoder)
    End Sub

    Private Sub AcquireWhenTriggeredContinuousWithEncoder(ByVal StateInfo As Object)
        Dim XArray(580) As UInteger
        Dim ZArray(580) As UInteger
        Dim IArray(580) As UInteger
        Dim EncoderBuf(3) As Byte
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim EncoderCounts As Integer
        Dim FillListDel As New FillListDelegate(AddressOf FillList)
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim UpdateImageCountDel As New UpdateImageCountDelegate(AddressOf UpdateImageCount)
        Dim ShowEncoderCountsDel As New ShowEncoderCountsDelegate(AddressOf ShowEncoderCounts)
        Dim StrBldr As New System.Text.StringBuilder(128)
        Dim StrWtr As New System.IO.StringWriter(StrBldr)
        Dim StreamWtr As System.IO.StreamWriter = Nothing
        Dim SendToFile As Boolean = chkSendToFile.Checked And ValidOutFileNameFlag

        'Intended to run in its own thread
        'Stop button aborts this function
        'Intended to run in trigger mode, similar to AcquireContinuousWithTrigger, calls an overloaded version
        'of GetInterleavedData that extracts the encoder count from the data buffer.

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        If SendToFile Then
            StreamWtr = New System.IO.StreamWriter(Filename)
        End If

        Do While StopFlag = False

            Result = False
            Do While Result = False And StopFlag = False
                'Wait for a trigger, then get the interleaved data
                'One trigger generates 2 interleaved scans.

                ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
                Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2, EncoderBuf)
            Loop

            If Not StopFlag Then
                If Result Then
                    Me.Invoke(UpdateImageCountDel, ImageNumber1, ImageNumber2)
                    EncoderCounts = EncoderBuf(3) And &H3F
                    EncoderCounts = (EncoderCounts << 7) + (EncoderBuf(2) And &H7F)
                    EncoderCounts = (EncoderCounts << 7) + (EncoderBuf(1) And &H7F)
                    EncoderCounts = (EncoderCounts << 7) + (EncoderBuf(0) And &H7F)
                    'Bit 27 is sign bit
                    If (EncoderCounts And &H800000) = &H800000 Then
                        'This is a negative number
                        'Get 1's complement
                        EncoderCounts = (Not EncoderCounts) And &H7FFFFF
                        'Get 2's complement
                        EncoderCounts = EncoderCounts + 1
                        'flip sign
                        EncoderCounts = EncoderCounts * (-1)
                    End If

                    ' Now that we have decoded the encoder position for the scan, we can proceed.

                    ' ===== Any application specific code using data returned by GetInterleavedData would be inserted here =======




                    ' ===== The following code simply scales & plots the data, updates screen displays, and writes to file if desired ===

                    ' Following delegate simply displays the encoder position for the current scan on the screen.

                    Me.Invoke(ShowEncoderCountsDel, EncoderCounts)
                    StrBldr.Length = 0
                    If SendToFile Then
                        StrWtr.WriteLine("Image Numbers, " + ImageNumber1.ToString + ", " + ImageNumber2.ToString + " Encoder Counts, " + EncoderCounts.ToString)
                    End If
                    For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                        XValue = XArray(I) * XScaler
                        ZValue = ZArray(I) * ZScaler
                        StrWtr.WriteLine(XValue.ToString("0.0000") + Chr(9) + ZValue.ToString("0.0000") + Chr(9) + IArray(I).ToString)
                    Next
                    If SendToFile Then
                        StreamWtr.WriteLine(StrWtr.ToString)
                    End If
                    Me.Invoke(FillListDel, StrWtr.ToString)
                    Me.Invoke(PlotDataDel, XArray, ZArray, 580)
                Else
                    Me.Invoke(UpdateImageCountDel, CUInt(0), CUInt(0))
                End If
            End If
        Loop
        StrWtr.Close()
        If SendToFile Then
            StreamWtr.Close()
        End If

    End Sub


    Private Sub btnShowSecondLaserForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowSecondLaserForm.Click
        frmSecondLaser.Show()
    End Sub

    Private Sub btnBrowseInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseInput.Click
        'OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.InitialDirectory = "C:\Users\Sean\Documents\GitHub\inl_laser\fileIO"
        OpenFileDialog1.FileName = ""
        'OpenFileDialog1.Filter = "Text files (*.txt) | *.txt"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv" '|All files (*.*)|*.*"
        OpenFileDialog1.CheckFileExists = False
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.ValidateNames = True
        OpenFileDialog1.Title = "Select Input File"

        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                ValidInFileNameFlag = True
                inFileName.Text = OpenFileDialog1.FileName
                Filename = OpenFileDialog1.FileName
            Else
                ValidInFileNameFlag = False
                inFileName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ValidInFileNameFlag = False
            inFileName.Text = ""
        End Try
    End Sub
    Private Sub btnBrowseOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseOutput.Click
        'OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog2.InitialDirectory = "C:\Users\Sean\Documents\GitHub\inl_laser\fileIO"
        OpenFileDialog2.FileName = ""
        'OpenFileDialog1.Filter = "Text files (*.txt) | *.txt"
        OpenFileDialog2.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv" '|All files (*.*)|*.*"
        OpenFileDialog2.CheckFileExists = False
        OpenFileDialog2.Multiselect = False
        OpenFileDialog2.ValidateNames = True
        OpenFileDialog2.Title = "Select Output file"

        Try
            If OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
                ValidOutFileNameFlag = True
                outFileName.Text = OpenFileDialog2.FileName
                Filename = OpenFileDialog2.FileName
            Else
                ValidOutFileNameFlag = False
                outFileName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ValidOutFileNameFlag = False
            outFileName.Text = ""
        End Try
    End Sub

    Private Sub chkSendToFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSendToFile.CheckedChanged
        SendToFileFlag = chkSendToFile.Checked
    End Sub

    Private Sub btnStopEncoder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopEncoder.Click
        StopFlag = True
    End Sub

    Private Sub btnGetWidthContinuously_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetWidthContinuously.Click

        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.
        ' We acquire scans in a loop, and stop the loop when a button click sets the StopFlag to True

        ' Initialize the StopFlag to False, so that the loop can begin scanning
        StopFlag = False
        HeightThreshold = Val(txtThreshold.Text)
        UpdateCounts = Val(txtUpdateCount.Text)
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousForWidthCalculation)
    End Sub


    Private Sub AcquireContinuousForWidthCalculation(ByVal StateInfo As Object)
        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Static Dim ZArrayReferencedToFarEndOfLaserRange(580) As UInteger
        Static Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim ShowWidthCalculationDel As New ShowWidthCalculationDelgate(AddressOf ShowWidthCalculation)
        Dim LeftEdge, RightEdge, WidthCalc As Single
        Dim LeftEdgeFound As Boolean
        Dim UpdateCounter As Integer

        'Intended to run in its own thread
        'Stop button aborts this function

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Update counter is used in determining how often to display calculated width on the screen.
        UpdateCounter = 0
        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            ' If we have successfully acquired an interleaved scan, then we analyze the data
            If Result Then

                ' Initialize the width result to -1, because a positive value will later be
                ' used to show that we have valid results to display

                WidthCalc = -1

                LeftEdgeFound = False
                ' We'll set this true when found because can't calc the width until have left edge

                ' Do twice number of pixels because we are interleaving scans

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler

                    'for this application example, we will display distances from the far end of the laser Z range
                    'thus, for example, for objects on a table, the graph will look like the profile of
                    'the object.  So take the Z values returned by the laser and adjust them so they
                    'report distances from the far end of the laser's Z range.

                    ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)
                    'see if this is a legitimate measurement based on the intensity > 10

                    If (IArray(I) > 10) Then
                        'Valid intensity, so look for the left edge by seeing if target is closer than threshold
                        If ZValue > HeightThreshold Then
                            LeftEdgeFound = True
                            LeftEdge = XValue
                            Exit For
                        End If
                    End If
                Next

                ' If we found left edge, then now look for right edge by starting at right end of data and
                ' moving left until find first point closer than threshold

                If LeftEdgeFound Then
                    For I = 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1 To 0 Step -1
                        XValue = XArray(I) * XScaler
                        ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)
                        'see if this is a legitimate measurement based on the intensity
                        If (IArray(I) > 10) Then
                            'looking for right edge
                            If ZValue > HeightThreshold Then
                                RightEdge = XValue
                                WidthCalc = RightEdge - LeftEdge
                                Exit For
                            End If
                        End If
                    Next
                End If

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    If ZArray(I) <= 4096 Then
                        ZArrayReferencedToFarEndOfLaserRange(I) = 4096 - ZArray(I)
                    Else
                        ZArrayReferencedToFarEndOfLaserRange(I) = ZArray(I)
                    End If
                Next

                ' Update counter determines how often we display width on screen
                UpdateCounter += 1


                'If UpdateCounter >= UpdateCounts Then
                ' Update the graph and show the left and right edge positions and width.
                Me.Invoke(PlotDataDel, XArray, ZArrayReferencedToFarEndOfLaserRange, 580)
                Me.Invoke(ShowWidthCalculationDel, LeftEdge, RightEdge, WidthCalc)
                UpdateCounter = 0
                Sleep(UpdateCounts)
                ' End If
            Else
                ' Following will show -1 if don't get a valid width calculation
                Me.Invoke(ShowWidthCalculationDel, -1, -1, -1)
            End If
        Loop
    End Sub

    Private Sub btnStopContinuousRealWorldExampleScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopContinuousRealWorldExampleScans.Click
        StopFlag = True
    End Sub

    Private Sub txtThreshold_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtThreshold.TextChanged
        HeightThreshold = Val(txtThreshold.Text)
    End Sub

    Private Sub txtUpdateCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpdateCount.TextChanged
        UpdateCounts = Val(txtUpdateCount.Text)
    End Sub

    Private Sub btnGetGapScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetGapScans.Click
        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.
        ' We acquire scans in a loop, and stop the loop when a button click sets the StopFlag to True

        ' Initialize the StopFlag to False, so that the loop can begin scanning 
        StopFlag = False
        HeightThreshold = Val(txtThreshold.Text)
        UpdateCounts = Val(txtUpdateCount.Text)
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousForGapCalculation)
    End Sub

    Private Sub AcquireContinuousForGapCalculation(ByVal StateInfo As Object)
        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Static Dim ZArrayReferencedToFarEndOfLaserRange(580) As UInteger
        Static Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim LeftEdge, RightEdge, GapCalc As Single
        Dim LeftEdgeFound As Boolean
        Dim UpdateCounter As Integer

        ' Following two "Delegates" are required because you cannot access on screen displays from within the thread which didn't create them
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim ShowWidthCalculationDel As New ShowWidthCalculationDelgate(AddressOf ShowWidthCalculation)


        'Intended to run in its own thread
        'Stop button aborts this function

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Update counter is used in determining how often to display calculated width on the screen.
        UpdateCounter = 0
        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            ' If we have successfully acquired an interleaved scan, then we analyze the data
            If Result Then

                ' Initialize the GapCalc result to -1, because a positive value will later be
                ' used to show that we have valid results to display

                GapCalc = -1

                LeftEdgeFound = False
                ' We'll set this true when found because can't calc the width until have left edge

                ' Do twice number of pixels because we are interleaving scans

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler

                    'for this application example, we will display distances from the far end of the laser Z range
                    'thus, for example, for objects on a table, the graph will look like the profile of
                    'the object.  So take the Z values returned by the laser and adjust them so they
                    'report distances from the far end of the laser's Z range.

                    ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)
                    'see if this is a legitimate measurement based on the intensity > 10

                    If (IArray(I) > 10) Then
                        'Valid intensity, so look for the left edge by seeing if target is closer than threshold
                        If ZValue < HeightThreshold Then
                            LeftEdgeFound = True
                            LeftEdge = XValue
                            Exit For
                        End If
                    End If
                Next

                ' If we found left edge, then now look for right edge by starting at right end of data and
                ' moving left until find first point closer than threshold

                If LeftEdgeFound Then
                    For I = 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1 To 0 Step -1
                        XValue = XArray(I) * XScaler
                        ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)
                        'see if this is a legitimate measurement based on the intensity
                        If (IArray(I) > 10) Then
                            'looking for right edge
                            If ZValue < HeightThreshold Then
                                RightEdge = XValue
                                GapCalc = RightEdge - LeftEdge
                                Exit For
                            End If
                        End If
                    Next
                End If

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    If ZArray(I) <= 4096 Then
                        ZArrayReferencedToFarEndOfLaserRange(I) = 4096 - ZArray(I)
                    Else
                        ZArrayReferencedToFarEndOfLaserRange(I) = ZArray(I)
                    End If
                Next

                ' Update counter determines how often we display width on screen
                UpdateCounter += 1


                'If UpdateCounter >= UpdateCounts Then
                ' Update the graph and show the left and right edge positions and width.
                Me.Invoke(PlotDataDel, XArray, ZArrayReferencedToFarEndOfLaserRange, 580)
                Me.Invoke(ShowWidthCalculationDel, LeftEdge, RightEdge, GapCalc)
                UpdateCounter = 0
                Sleep(UpdateCounts)
                ' End If
            Else
                ' Following will show -1 if don't get a valid width calculation
                Me.Invoke(ShowWidthCalculationDel, -1, -1, -1)
            End If
        Loop
    End Sub


    Private Sub btnGetPeakScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPeakScans.Click
        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.
        ' We acquire scans in a loop, and stop the loop when a button click sets the StopFlag to True

        ' Initialize the StopFlag to False, so that the loop can begin scanning 
        StopFlag = False
        HeightThreshold = Val(txtThreshold.Text)
        UpdateCounts = Val(txtUpdateCount.Text)
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousForPeakCalculationOfSeparateObjects)
    End Sub

    Private Sub AcquireContinuousForPeakCalculationOfSeparateObjects(ByVal StateInfo As Object)
        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Static Dim ZArrayReferencedToFarEndOfLaserRange(580) As UInteger
        Static Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim MaxHeightSoFar, XPositionOfPeak As Single
        Dim UpdateCounter As Integer
        ' When we see the following as true, we know we are starting measurements of a new object
        Dim AllPointsBelowThresholdHeightInCurrentScan As Boolean

        ' Following two delegates are required because you cannot access an on screen display from other than the thread
        ' which created them.

        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim ShowPeakCalculationDel As New ShowPeakCalculationDelegate(AddressOf ShowPeakCalculation)

        'Intended to run in its own thread
        'Stop button aborts this function

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Initialize the MaxHeightSoFarf to -1, because a positive value will later be
        ' used to show that we have valid results to display

        MaxHeightSoFar = -1

        ' Update counter is used in determining how often to display calculated width on the screen.
        UpdateCounter = 0
        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            ' If we have successfully acquired an interleaved scan, then we analyze the data
            If Result Then

                ' Begin processing the points assuming that no points are above the threshold height
                ' Will set this true when we see a point above threshold, and therefore have a candidate
                ' for the peak.

                AllPointsBelowThresholdHeightInCurrentScan = True

                ' Do twice number of pixels because we are interleaving scans

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1


                    'for this application example, we will display distances from the far end of the laser Z range
                    'thus, for example, for objects on a table, the graph will look like the profile of
                    'the object.  So take the Z values returned by the laser and adjust them so they
                    'report distances from the far end of the laser's Z range.

                    ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)

                    'see if this is a legitimate measurement based on the intensity > 10

                    If (IArray(I) > 10) Then
                        'Valid intensity, so look to see if the current point is higher than the threshold,
                        'if so, it can be a candidate for the peak.
                        If ZValue > HeightThreshold Then
                            ' Now have at least one point above the threshold height, so set following to false
                            AllPointsBelowThresholdHeightInCurrentScan = False
                            If ZValue > MaxHeightSoFar Then
                                ' replace previous canditate for max height with the current value.
                                MaxHeightSoFar = ZValue
                                XPositionOfPeak = XArray(I) * XScaler
                            End If
                        End If
                    End If
                Next

                ' If we are here, we have looped through all points in the current scan.
                ' And if all of these points were below threshold, we either haven't reached the first object,
                ' or we are between objects.  In either case, we want to reset the MaxHeightSoFar to -1, so that
                ' we're starting next object from scratch.

                If AllPointsBelowThresholdHeightInCurrentScan = True Then
                    MaxHeightSoFar = -1
                End If


                ' Following just takes the Zarray which was measured from the close end of the laser range
                ' and calculates the Z distances from the far end of the laser range, so that they are ready
                ' for plotting.

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    If ZArray(I) <= 4096 Then
                        ZArrayReferencedToFarEndOfLaserRange(I) = 4096 - ZArray(I)
                    Else
                        ZArrayReferencedToFarEndOfLaserRange(I) = ZArray(I)
                    End If
                Next

                ' Update counter determines how often we display width on screen
                UpdateCounter += 1

                'If UpdateCounter >= UpdateCounts Then
                ' Update the graph and show the left and right edge positions and width.
                Me.Invoke(PlotDataDel, XArray, ZArrayReferencedToFarEndOfLaserRange, 580)
                Me.Invoke(ShowPeakCalculationDel, MaxHeightSoFar, XPositionOfPeak)
                UpdateCounter = 0
                Sleep(UpdateCounts)
                ' End If
            Else
                ' Following will show -1 if don't get a valid width calculation
                Me.Invoke(ShowPeakCalculationDel, -1, -1)
            End If
        Loop
    End Sub

    Private Sub btnStopPeakScans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopPeakScans.Click
        StopFlag = True
    End Sub

    Private Sub btnHoleDiameterMeasurement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoleDiameterMeasurement.Click

        ' Note: For Continuous scanning, we put the acquisition code in its own thread, so that the main thread
        ' will still be responsive to user interface events.
        ' We acquire scans in a loop, and stop the loop when a button click sets the StopFlag to True

        ' Initialize the StopFlag to False, so that the loop can begin scanning 
        StopFlag = False
        HeightThreshold = Val(txtThreshold.Text)
        UpdateCounts = Val(txtUpdateCount.Text)
        ThreadPool.QueueUserWorkItem(AddressOf AcquireContinuousForHoleDiameterCalculation)
    End Sub

    Private Sub AcquireContinuousForHoleDiameterCalculation(ByVal StateInfo As Object)
        ' Note: This methodology is incomplete because because of camera angle doesn't always
        ' allow proper viewing of the hole.  It demonstrates the general principle, but more coding
        ' is required to generate a robust, reliable routine.

        Static Dim XArray(580) As UInteger
        Static Dim ZArray(580) As UInteger
        Static Dim ZArrayReferencedToFarEndOfLaserRange(580) As UInteger
        Static Dim IArray(580) As UInteger
        Dim ImageNumber1, ImageNumber2 As Byte
        Dim XValue, ZValue, XScaler, ZScaler As Single
        Dim I As Integer
        Dim Result As Boolean
        Dim LeftEdge, RightEdge, GapCalc As Single
        Dim LeftEdgeFound As Boolean
        Dim UpdateCounter As Integer

        ' When the following variable is false, then we've started to see some of the hole
        ' When it is true, then we are either before the first hole or between holes, and
        ' We discard any previous estimate of the hole diameter and start from scratch.

        Dim GapNotYetDetected As Boolean
        Dim MaxGapSoFar As Single

        ' Following two "Delegates" are required because you cannot access on screen displays from within the thread which didn't create them
        Dim PlotDataDel As New PlotDataDelegate(AddressOf PlotData)
        Dim ShowWidthCalculationDel As New ShowWidthCalculationDelgate(AddressOf ShowWidthCalculation)


        'Intended to run in its own thread
        'Stop button aborts this function

        'To convert from raw data to mm, 
        'Xmm = (Xraw * (ScanRangeEnd * 0.1)/ 4096)
        'Zmm = (Zraw * (MeasuringRange * 0.1)/ 4096)
        XScaler = ((AP820Laser1.ScanInfo.ScanRangeEnd * 0.1) / 4096)
        ZScaler = ((AP820Laser1.ScanInfo.MeasuringRange * 0.1) / 4096)

        ' Initialize the gap result to -1, because a positive value will later be
        ' used to show that we have valid results to display. MaxGapSoFar will continuously record
        ' the largest value of gap seen for this hole.

        GapCalc = -1
        MaxGapSoFar = -1

        ' Update counter is used in determining how often to display calculated width on the screen.
        UpdateCounter = 0

        Do While StopFlag = False

            'Get the latest available interleaved scans

            ' See AP820Class.vb for the details of the AP820Laser.GetInterleavedData function
            Result = AP820Laser1.GetInterleavedData(XArray, ZArray, IArray, ImageNumber1, ImageNumber2)

            ' If we have successfully acquired an interleaved scan, then we analyze the data
            If Result Then

                ' Start out with assumption that there is no gap in the current scan
                GapNotYetDetected = True

                LeftEdgeFound = False
                ' We'll set this true when found because can't calc the width until have left edge

                ' Do twice number of pixels because we are interleaving scans

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    XValue = XArray(I) * XScaler

                    'for this application example, we will display distances from the far end of the laser Z range
                    'thus, for example, for objects on a table, the graph will look like the profile of
                    'the object.  So take the Z values returned by the laser and adjust them so they
                    'report distances from the far end of the laser's Z range.

                    ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)
                    'see if this is a legitimate measurement based on the intensi.ty > 10

                    If (IArray(I) > 10) Then
                        'Valid intensity, so look for the left edge by seeing if target is closer than threshold
                        If ZValue < HeightThreshold Then
                            LeftEdgeFound = True
                            LeftEdge = XValue
                            Exit For
                        End If
                    End If
                Next

                ' If we found left edge, then now look for right edge by starting at right end of data and
                ' moving left until find first point closer than threshold

                If LeftEdgeFound Then
                    For I = 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1 To 0 Step -1
                        XValue = XArray(I) * XScaler
                        ZValue = (AP820Laser1.ScanInfo.MeasuringRange / 10) - (ZArray(I) * ZScaler)
                        'see if this is a legitimate measurement based on the intensity
                        If (IArray(I) > 10) Then
                            'looking for right edge
                            If ZValue < HeightThreshold Then
                                ' If here, we've see some evidence of a gap
                                GapNotYetDetected = False
                                RightEdge = XValue
                                GapCalc = RightEdge - LeftEdge
                                If GapCalc > MaxGapSoFar Then
                                    MaxGapSoFar = GapCalc
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If

                If GapNotYetDetected = True Then
                    ' We've either not started the first hole or are between holes, so in either
                    ' case we need to start fresh and discard any previously calculated gaps
                    GapCalc = -1
                    MaxGapSoFar = -1
                End If

                For I = 0 To 2 * (AP820Laser1.ScanInfo.NumXPixels) - 1
                    If ZArray(I) <= 4096 Then
                        ZArrayReferencedToFarEndOfLaserRange(I) = 4096 - ZArray(I)
                    Else
                        ZArrayReferencedToFarEndOfLaserRange(I) = ZArray(I)
                    End If
                Next

                ' Update counter determines how often we display width on screen
                UpdateCounter += 1


                'If UpdateCounter >= UpdateCounts Then
                ' Update the graph and show the left and right edge positions and width.
                Me.Invoke(PlotDataDel, XArray, ZArrayReferencedToFarEndOfLaserRange, 580)
                Me.Invoke(ShowWidthCalculationDel, LeftEdge, RightEdge, MaxGapSoFar)
                UpdateCounter = 0
                Sleep(UpdateCounts)
                ' End If
            Else
                ' Following will show -1 if don't get a valid width calculation
                Me.Invoke(ShowWidthCalculationDel, -1, -1, -1)
            End If
        Loop
    End Sub

    Private Sub lblVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVersion.Click

    End Sub

    
    Private Sub OpenFileDialog2_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk

    End Sub
End Class
