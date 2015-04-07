Imports System.IO
Imports System.String
Imports System.Collections.Generic

Public Class Biomass
    Private width As Double
    Private avgWidth As Double
    Private maxWidth As Double

    Private height As Double
    Private avgHeight As Double
    Private maxHeight As Double

    Private length As Double
    Private avgLength As Double
    Private maxLength As Double

    Private volume As Double
    Private avgVolume As Double
    Private maxVolume As Double

    Private leftEdgeLoc As Point
    Private rightEdgeLoc As Point
    Private topEdgeLoc As Point
    Private botEdgeLoc As Point

    Private data As New LinkedList(Of Point)
    Private complete As Boolean

    Private beyondLeft As Boolean
    Private beyondRight As Boolean

    Public Sub New(ByVal left As Point)
        Dim t_point As New Point
        width = 0
        avgWidth = 0
        maxWidth = 0

        height = 0
        avgHeight = 0
        maxHeight = 0

        length = 0
        avgLength = 0
        maxLength = 0

        volume = 0
        avgVolume = 0
        maxVolume = 0

        leftEdgeLoc = left
        rightEdgeLoc = t_point
        topEdgeLoc = t_point
        botEdgeLoc = t_point

        beyondLeft = False
        beyondRight = False

        Try
            data.AddLast(left)
        Catch ex As System.NullReferenceException
            MsgBox("Error: " + ex.Message)
        End Try
        complete = False
    End Sub

    Sub New()
        Dim t_point As New Point
        width = 0
        avgWidth = 0
        maxWidth = 0

        height = 0
        avgHeight = 0
        maxHeight = 0

        length = 0
        avgLength = 0
        maxLength = 0

        volume = 0
        avgVolume = 0
        maxVolume = 0

        leftEdgeLoc = t_point
        rightEdgeLoc = t_point
        topEdgeLoc = t_point
        botEdgeLoc = t_point

        beyondLeft = False
        beyondRight = False
    End Sub

    Public Sub addPoint(ByVal a As Point)
        data.AddLast(a)
    End Sub


    Private Function getWidth() As Integer 'Returns width of the current slice'
        Return width
    End Function
    Private Function setWidth() As Integer 'Take the pointer left and rightedgeloc and subtract the data from where they are pointing
        'width = scan(rightEdgeLoc) - scan(leftEdgeLoc)
        'if width <= 0 BALEETED
    End Function
    Private Function getHeight() As Integer 'Returns height of current data point in object'
        Return height
    End Function
    Private Function setHeight() As Integer ''Allen
    End Function
    Private Function getLength() As Integer 'Returns '
        Return length
    End Function
    Private Function setLength() As Integer ''Jon
    End Function
    Private Function getVolume() As Integer ''
        Return volume
    End Function
    Private Function setVolume() As Integer ''ME   May not be used because these only deal with one slice
        'volume = width * length * height
    End Function



    Private Function getAvgWidth() As Integer 'Returns the average width'
        Return getAvgWidth
    End Function
    Private Function setAvgWidth() As Integer ''Jon
    End Function
    Private Function getAvgHeight() As Integer ''
        Return avgHeight
    End Function
    Private Function setAvgHeight() As Integer ''Allen
    End Function
    Private Function getAvgLength() As Integer ''
        Return avgLength
    End Function
    Private Function setAvgLength() As Integer ''Jon

    End Function
    Private Function getAvgVolume() As Integer ''
        Return avgVolume
    End Function
    Private Function setAvgVolume() As Integer ''ME Takes the average width, lenght, and height and gives you an average volume from that.
        'avgVolume = avgWidth * avgHeight * avgLenght
    End Function



    Private Function getMaxWidth() As Double 'Returs the Max Width'
        Return getMaxWidth
    End Function
    Private Function setMaxWidth() As Double 'Takes left edge and right edge to calculate the width'     Allen
    End Function
    Private Function getMaxHeight() As Double 'Returns Max Height'
        Return maxHeight
    End Function
    Private Function setMaxHeight() As Double 'Takes the Max Z coordinate and takes the highest of the object and stores it'    ME
        'if getHeight() > maxHeight
        '   maxHeight == getHeight()
    End Function
    Private Function getMaxLength() As Double 'Returns Max length'
        Return maxLength
    End Function
    Private Function setMaxLength() As Double 'Uses the encoder data and finds the Longest part of the object and stores it'  Jon
    End Function
    Private Function getMaxVolume() As Double 'Returns the Max Volume'
        Return maxVolume
    End Function
    Private Function setMaxVolume() As Double 'Compute the volume using Max Height, Max Length, and Max Width every time this runs  Allen
    End Function


    Private Function getLeftEdge() As Point 'Returns array of the left edge location
        Return leftEdgeLoc
    End Function
    Private Function setLeftEdge() As Integer  'Finds the first measurement of the object and stores it into the leftEdgeLoc variable of one single scan
        Dim j As Integer
        Dim i As Integer
        Dim k As Integer

        'For loop that loops through the single scan of data to find the left edge of the object.
        j = 1
        k = 1
        For i = k To 580 'Array of data of a single scan

            ''''''Once we find that the Z data is higher than the conveyor belt, store that point. That is the left edge.
            'If (zDataPoint > ConveyorHeight && zDataPoint - 1 == Conveyor Height && Intensity >=250)
            'Set leftEdgeLoc to the first point where it is true, and then return
            '
            ' 
            'On subsequent loops through the scan of data always find the first edge (which may not be the first edge)
        Next i
        'Return all the LeftEdge's of every object for that scan
    End Function
    Private Function getRightEdge() As Point 'Returns array of the right edge location'
        Return rightEdgeLoc
    End Function
    Private Function setRightEdge() As Integer 'Finds the end of the object (the right side) and stores it into the rightEdgeLoc variable of one single scan'
        Dim j As Integer
        Dim i As Integer
        Dim k As Integer

        'For loop that loops through the single scan of data to find the right edge of the object.
        j = 1
        k = 1
        For i = 1 To BLOCKSIZE 'Array of data of a single scan

            ''''''Once we find that the Z data is equal to the conveyor belt and the zDataPoint before that point is higher than the conveyor
            ''''''then store that point. That is the right edge.
            'If (zDataPoint == ConveyorHeight && zDataPoint - 1 > Conveyor Height  && Intensity >=250)
            'Store xDataPoint and continue through the rest of the data to find the other right edges of other objects
        Next i
        'Return all the RightEdges of every object for that scan

    End Function

    'Private Function setRightEdge() As Integer
    'End Function

    'Combines 2 biomass objects into one
    Public Shared Operator +(ByVal mass1 As Biomass, ByVal mass2 As Biomass)
        'Dim i As Integer

        'Dim size As Integer = mass2.data.Count - 1
        'For i = 0 To size
        'mass1.data.AddLast(mass2.data(i))
        'mass1.data.Concat(mass2.data)
        'Next i
        For Each item As Point In mass2.data
            mass1.data.AddLast(item)
        Next

        mass2.data.Clear()
        Return mass1
    End Operator

End Class
