﻿'Const BLOCKSIZE = 579
Public Class Point
    Private xVal As Double
    Private yVal As Double
    Private zVal As Double
    Private iVal As Integer
    Public Property x As Double
        Get
            Return xVal
        End Get
        Set(ByVal value As Double)
            xVal = value
        End Set
    End Property

    Public Property y As Double
        Get
            Return yVal
        End Get
        Set(ByVal value As Double)
            yVal = value
        End Set
    End Property

    Public Property z As Double
        Get
            Return zVal
        End Get
        Set(ByVal value As Double)
            zVal = value
        End Set
    End Property

    Public Property i As Integer
        Get
            Return iVal
        End Get
        Set(ByVal value As Integer)
            iVal = value
        End Set
    End Property
    Sub New()
        x = 0
        y = 0
        z = 0
        i = 0
    End Sub

    Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Integer)
        x = a
        y = b
        z = c
        i = d
    End Sub

End Class