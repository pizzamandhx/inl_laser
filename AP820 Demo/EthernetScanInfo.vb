Imports System.Runtime.InteropServices

Public Module EthernetScanInfo

    <StructLayout(LayoutKind.Sequential)> Public Structure ScanInfoStruct
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=16)> Public SerialNumber As String
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=128)> Public FirmwareVersion As String
        Public BeginningOfMeasuringRange As UInteger
        Public MeasuringRange As UInteger
        Public ScanRangeBeginning As UInteger
        Public ScanRangeEnd As UInteger
        Public MaxZLinearized As UInteger
        Public MaxXLinearized As UInteger
        Public MaxZNonLinearized As UInteger
        Public MaxXNonLinearized As UInteger
        Public NumZPixels As UInteger
        Public NumXPixels As UInteger
        Public ScannerTemperature As UInteger
        Public OperatingSecondsCounter As UInteger
        Public PowerCycleCounter As UInteger
        Public Fifo As UInteger
        Public PositionEncoder As UInteger
        Public PositionEncoderDirection As UInteger
        Public Protocol As UInteger
        Public Linearization As UInteger
        Public CameraMode As UInteger
        Public ProfileMode As UInteger
        Public ScannerMode As UInteger
        Public ShutterTimeManual As Integer
        Public ShutterTimeAuto As Integer
        Public PixelReadOutStart As UInteger
        Public PixelReadOutEnd As UInteger
        Public VideoGain As UInteger
        Public LaserIntensityThreshold As UInteger
        Public LaserTargetValue As UInteger
        Public PeakWidthLimit As UInteger
        Public PeakThreshold As UInteger
        Public Synchronization As UInteger
        Public ProtocolVersion As UInteger
        Public ShutterControl As UInteger
        Public Linearization2 As Integer
        Public Speed As UInteger
        Public FPGAVersion As UInteger
        Public DigitalInput As UInteger
        Public LaserValueOfProfile As UInteger
    End Structure

End Module
