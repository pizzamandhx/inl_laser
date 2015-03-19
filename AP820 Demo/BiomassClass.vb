Public Class BiomassClass
    Private width As Double
    Private avgWidth As Double
    Private maxWidth As Double

    Private height As Double
    Private avgHeight As Double
    Private maxHeight As Double

    Private length As Double
    Private avgLength As Double
    Private maxLength As Double
    'hello world
    Private volume As Double
    Private avgVolume As Double
    Private maxVolume As Double

    Private leftEdgeLoc As Double
    Private rightEdgeLoc As Double
    Private Function getWidth() As Integer 'Returns width of the current slice'
    End Function
    Private Function setWidth() As Integer ''
    End Function
    Private Function getHeight() As Integer 'Returns height of current data point in object'
    End Function
    Private Function setHeight() As Integer ''
    End Function
    Private Function getLength() As Integer 'Returns '
    End Function
    Private Function setLength() As Integer ''
    End Function
    Private Function getVolume() As Integer ''
    End Function
    Private Function setVolume() As Integer ''
    End Function



    Private Function getAvgWidth() As Integer 'Returns the average width'
    End Function
    Private Function setAvgWidth() As Integer ''
    End Function
    Private Function getAvgHeight() As Integer ''
    End Function
    Private Function setAvgHeight() As Integer ''
    End Function
    Private Function getAvgLength() As Integer ''
    End Function
    Private Function setAvgLength() As Integer ''
    End Function
    Private Function getAvgVolume() As Integer ''
    End Function
    Private Function setAvgVolume() As Integer ''
    End Function



    Private Function getMaxWidth() As Double 'Returs the Max Width'
    End Function
    Private Function setMaxWidth() As Double 'Takes left edge and right edge to calculate the width'
    End Function
    Private Function getMaxHeight() As Double 'Returns Max Height'
    End Function
    Private Function setMaxHeight() As Double 'Takes the Max Z coordinate and takes the highest of the object and stores it'
    End Function
    Private Function getMaxLength() As Double 'Returns Max length'
    End Function
    Private Function setMaxLength() As Double 'Uses the encoder data and finds the Longest part of the object and stores it'
    End Function
    Private Function getMaxVolume() As Double 'Returns the Max Volume'
    End Function
    Private Function setMaxVolume() As Double 'Compute the volume using Max Height, Max Length, and Max Width every time this runs
    End Function


    Private Function getLeftEdge() As Integer 'Returns the left edge location
    End Function
    Private Function setLeftEdge() As Integer  'Finds the first measurement of the object and stores it into the leftEdgeLoc variable'
    End Function
    Private Function getRightEdge() As Integer 'Returns the right edge location'
    End Function
    Private Function setRightEdge() As Integer 'Finds the end of the object (the right side) and stores it into the rightEdgeLoc variable'
    End Function
    Private Function mergeBiomass() As Integer 'Combines 2 "seperate" that when connected by a scan merges the right object into the left object'
    End Function
    'Private Function setRightEdge() As Integer
    'End Function

End Class
