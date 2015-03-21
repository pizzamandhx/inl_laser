Imports System.Runtime.InteropServices
Imports System.Text

'junk comment
'junk comment 2
'junk comment 3
'junk comment 4
Public Class AP820Class
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_Connect(ByVal IPAddr As String, ByVal Port As String, ByVal Timeout As UInteger) As IntPtr
    End Function
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_Disconnect(ByVal pScanner As IntPtr) As UInteger
    End Function
    <DllImport("EthernetScanner.dll")> _
    Private Shared Sub EthernetScanner_GetConnectStatus(ByVal pScanner As IntPtr, ByRef Status As UInteger)
    End Sub
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_GetInfoRaw(ByVal pScanner As IntPtr, ByVal Buffer As Byte(), ByVal BufferSize As UInteger, ByVal Timeout As UInteger) As Boolean
    End Function
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_GetInfo(ByVal pScanner As IntPtr, ByRef ScanInfo As ScanInfoStruct, ByVal ScanInfoSize As UInteger, ByVal Timeout As UInteger) As UInteger
    End Function
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_WriteData(ByVal pScanner As IntPtr, ByVal Buffer As Byte(), ByVal Buffersize As UInteger) As UInteger
    End Function
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_GetVersion(<MarshalAs(UnmanagedType.LPStr), Out()> ByVal Version As StringBuilder, ByVal Length As UInteger) As UInteger
    End Function
    <DllImport("EthernetScanner.dll")> _
    Private Shared Function EthernetScanner_GetScanRawData(ByVal pScanner As IntPtr, ByVal Buffer As Byte(), ByVal BufferSize As UInteger, ByVal ScanProfileMode As UInteger, ByVal Timeout As UInteger) As Boolean
    End Function

    Private pScanner As IntPtr = Nothing
    Private Status As UInteger
    Public ScanInfo As ScanInfoStruct

    Public Function Connect(ByVal IPAddr As String, ByVal Port As String) As Boolean

        ' For detailed discussion, refer to Section 12.4 of the User's Manual
        pScanner = EthernetScanner_Connect(IPAddr, Port, 5000)
        If (pScanner <> Nothing) Then
            Connect = True

        Else
            Connect = False
        End If
    End Function

    Public Function Disconnect() As Boolean

        ' For detailed discussion, refer to Section 12.4 of the User's Manual
        Dim Result As UInteger

        Result = EthernetScanner_Disconnect(pScanner)
        pScanner = Nothing
    End Function

    Public Function GetStatus() As UInteger

        ' For detailed discussion, refer to Section 12.4 of the User's Manual
        EthernetScanner_GetConnectStatus(pScanner, Status)
        Return Status
    End Function


    Public Function WriteData(ByVal Buffer As Byte(), ByVal Buffersize As UInteger) As UInteger

        ' For detailed discussion, refer to Section 12.8 of the User's Manual
        Return EthernetScanner_WriteData(pScanner, Buffer, Buffersize)
    End Function


    Public Function GetData(ByVal XArray() As UInteger, ByVal ZArray() As UInteger, ByVal IArray() As UInteger, ByRef ImageNumber As Byte) As Boolean

        ' For detailed discussion, refer to Section 12.6.1 of the User's Manual
        Dim Buffer(3500) As Byte
        Dim Result As Boolean
        Dim I As Integer

        'Size of the arrays passed to this function should be 290
        'Call EthernetScanner_GetScanRawData

        ' For detailed discussion of the following function, refer to Section 12.6 of the User's Manual
        Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)
        'If everthing went OK, stuff the results in the arrays
        If Result Then
            'Get the image number
            ImageNumber = Buffer(62)
            For I = 0 To 289
                '            Lower 7 bits of X                       Higher 7 bits of X
                XArray(I) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
                '            Lower 7 bits of Z                           Higher 7 bits of Z
                ZArray(I) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
                'Intensity
                IArray(I) = CUInt(Buffer(66 + (I * 5) + 4))
            Next

        End If
        Return Result

    End Function

    Public Function GetDataRaw(ByVal Buffer() As Byte) As Boolean
        Dim Result As Boolean

        ' For detailed discussion of the following function, refer to Section 12.6 of the User's Manual
        Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)
        Return Result

    End Function

    Public Function GetFirstInterleavedScan(ByVal XArray() As UInteger, ByVal ZArray() As UInteger, ByVal IArray() As UInteger, ByRef Count1 As Byte) As Boolean
        Dim Buffer(3500) As Byte
        Dim Result As Boolean
        Dim I As Integer
        Dim ImageNumber, HalfImageNumber As Byte
        Dim LoopCounter As Integer

        'This function and GetSecondInterleavedScan splits the job of getting two interleaved scans in half to allow
        'for two lasers to work synchronously.  If one had to wait for the other to get both scans, it would fall behind 

        'Size of the arrays passed to this function should be 580

        'Call Ethernet_GetScanRawData until we get an odd image count
        LoopCounter = 0
        Do
            ' For detailed discussion of the following function, refer to Section 12.6 of the User's Manual
            Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)

            If Result Then
                'Get the Image Number
                ImageNumber = Buffer(62)
                Count1 = Buffer(62)
                HalfImageNumber = ImageNumber / 2
            Else
                Return False
            End If

            LoopCounter += 1
            If LoopCounter > 2 Then
                Return False
            End If
        Loop Until (ImageNumber <> HalfImageNumber * 2)

        'Got the first scan, stuff it into EVEN numbers of the array
        For I = 0 To 289
            '            Lower 7 bits of X                       Higher 7 bits of X
            XArray(I * 2) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
            '            Lower 7 bits of Z                           Higher 7 bits of Z
            ZArray(I * 2) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
            'Intensity
            IArray(I * 2) = CUInt(Buffer(66 + (I * 5) + 4))
        Next
        Return Result

    End Function

    Public Function GetSecondInterleavedScan(ByVal XArray() As UInteger, ByVal ZArray() As UInteger, ByVal IArray() As UInteger, ByRef Count1 As Byte, ByRef Count2 As Byte) As Boolean
        Dim Buffer(3500) As Byte
        Dim Result As Boolean
        Dim I As Integer
        Dim SecondImageNumber As Byte

        'This function and GetSecondInterleavedScan splits the job of getting two interleaved scans in half to allow
        'for two lasers to work synchronously.  If one had to wait for the other to get both scans, it would fall behind 

        'Size of the arrays passed to this function should be 580

        'Call Ethernet_GetScanRawData again

        ' For detailed discussion of the following function, refer to Section 12.6 of the User's Manual
        Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)

        If Result Then
            'check that the image number is correct
            SecondImageNumber = Buffer(62)
            Count2 = Buffer(62)
            If SecondImageNumber = Count1 + 1 Then
                'Got the second scan, stuff it into ODD number of the array
                For I = 0 To 289
                    '            Lower 7 bits of X                       Higher 7 bits of X
                    XArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
                    '            Lower 7 bits of Z                           Higher 7 bits of Z
                    ZArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
                    'Intensity
                    IArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5) + 4))
                Next
            Else
                'something went wrong!
                Return False
            End If
        Else
            Return False
        End If
        Return Result

    End Function

    Public Overloads Function GetInterleavedData(ByVal XArray() As UInteger, ByVal Zarray() As UInteger, ByVal IArray() As UInteger, ByRef Count1 As Byte, ByRef Count2 As Byte) As Boolean
        Dim Buffer(3500) As Byte
        Dim Result As Boolean
        Dim I As Integer
        Dim ImageNumber, HalfImageNumber, SecondImageNumber As Byte
        Dim LoopCounter As Integer

        'Size of the arrays passed to this function should be 580

        'Call Ethernet_GetScanRawData until we get an odd image count
        'LoopCounter = 0
        Do
            ' For detailed discussion of the following function, refer to Section 12.6 of the User's Manual
            Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)

            If Result Then
                'Get the Image Number
                ImageNumber = Buffer(62)
                Count1 = Buffer(62)
                HalfImageNumber = ImageNumber / 2
            Else
                Return False
            End If

            LoopCounter += 1
            If LoopCounter > 2 Then
                Return False
            End If
        Loop Until (ImageNumber <> HalfImageNumber * 2)

        'Got the first scan, stuff it into EVEN numbers of the array
        For I = 0 To 289
            '            Lower 7 bits of X                       Higher 7 bits of X
            XArray(I * 2) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
            '            Lower 7 bits of Z                           Higher 7 bits of Z
            Zarray(I * 2) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
            'Intensity
            IArray(I * 2) = CUInt(Buffer(66 + (I * 5) + 4))
        Next

        'Call Ethernet_GetScanRawData again
        Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)

        If Result Then
            'check that the image number is correct
            SecondImageNumber = Buffer(62)
            Count2 = Buffer(62)
            If SecondImageNumber = ImageNumber + 1 Then
                'Got the second scan, stuff it into ODD number of the array
                For I = 0 To 289
                    '            Lower 7 bits of X                       Higher 7 bits of X
                    XArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
                    '            Lower 7 bits of Z                           Higher 7 bits of Z
                    Zarray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
                    'Intensity
                    IArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5) + 4))
                Next
            Else
                'something went wrong!
                Return False
            End If
        Else
            Return False
        End If
        Return Result

    End Function

    Public Overloads Function GetInterleavedData(ByVal XArray() As UInteger, ByVal Zarray() As UInteger, ByVal IArray() As UInteger, ByRef Count1 As Byte, ByRef Count2 As Byte, ByVal EncoderBuf() As Byte) As Boolean
        Dim Buffer(3500) As Byte
        Dim Result As Boolean
        Dim I As Integer
        Dim ImageNumber, HalfImageNumber, SecondImageNumber As Byte
        Dim LoopCounter As Integer

        'Size of the arrays passed to this function should be 580

        'Call Ethernet_GetScanRawData until we get an odd image count
        'LoopCounter = 0
        Do
            ' For detailed discussion of the following function, refer to Section 12.6 of the User's Manual
            Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)

            If Result Then
                'Get the Image Number
                ImageNumber = Buffer(62)
                Count1 = Buffer(62)
                HalfImageNumber = ImageNumber / 2
            Else
                Return False
            End If

            LoopCounter += 1
            If LoopCounter > 2 Then
                Return False
            End If
        Loop Until (ImageNumber <> HalfImageNumber * 2)

        'Got the first scan, stuff it into EVEN numbers of the array
        For I = 0 To 289
            '            Lower 7 bits of X                       Higher 7 bits of X
            XArray(I * 2) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
            '            Lower 7 bits of Z                           Higher 7 bits of Z
            Zarray(I * 2) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
            'Intensity
            IArray(I * 2) = CUInt(Buffer(66 + (I * 5) + 4))
        Next

        'Load the encoder array
        For I = 0 To 3
            EncoderBuf(I) = Buffer(1525 + I)
        Next

        'Call Ethernet_GetScanRawData again
        Result = EthernetScanner_GetScanRawData(pScanner, Buffer, 3500, 0, 500)

        If Result Then
            'check that the image number is correct
            SecondImageNumber = Buffer(62)
            Count2 = Buffer(62)
            If SecondImageNumber = ImageNumber + 1 Then
                'Got the second scan, stuff it into ODD number of the array
                For I = 0 To 289
                    '            Lower 7 bits of X                       Higher 7 bits of X
                    XArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5)) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 1) And &H7F) << 7)
                    '            Lower 7 bits of Z                           Higher 7 bits of Z
                    Zarray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5) + 2) And &H7F) Or CUInt((Buffer(66 + (I * 5) + 3) And &H7F) << 7)
                    'Intensity
                    IArray(I * 2 + 1) = CUInt(Buffer(66 + (I * 5) + 4))
                Next
            Else
                'something went wrong!
                Return False
            End If
        Else
            Return False
        End If
        Return Result

    End Function

    Public Function GetInfo() As Boolean
        'Call this function before acquiring data so that the ScanInfo structure will contain the correct parameters.

        ' For detailed discussion of the following function, refer to Section 12.5 of the User's Manual
        Return EthernetScanner_GetInfo(pScanner, ScanInfo, 296, 500)
    End Function

    Public Function GetInfoRaw(ByVal Buffer As Byte(), ByVal BufferSize As UInteger) As Boolean
        ' Note: This function is included in the class for completeness, however it is preferable
        ' to use the GetInfo function which returns the data in a pre-defined structure (see above).
        Return EthernetScanner_GetInfoRaw(pScanner, Buffer, BufferSize, 500)
    End Function


    Public Function GetVersion() As String

        ' For detailed discussion of the following function, refer to Section 12.2 of the User's Manual
        'Buffer must be at least 256 bytes long
        Dim VersionBuffer As New System.Text.StringBuilder(256)
        Dim Result As UInteger

        Result = EthernetScanner_GetVersion(VersionBuffer, 256)
        'This function returns the length of the Version String on success
        'or -1 on Error
        If Result > -1 Then
            Return VersionBuffer.ToString
        Else
            Return "Error"
        End If
    End Function

End Class
