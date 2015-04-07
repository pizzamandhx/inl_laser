Public Class Point
    Private vol As Double
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

    Public Property volume As Integer
        Get
            Return vol
        End Get
        Set(value As Integer)
            vol = value
        End Set
    End Property
    Sub New()
        x = 0
        y = 0
        z = 0
        i = 0
        volume = 0
    End Sub

    'make sure conveyor height is accounted for with z in the function
    Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Integer)
        xVal = a
        yVal = b
        zVal = c
        calcVolume()
        iVal = d
    End Sub

    Public Sub calcVolume()
        vol = xVal * (yVal * STEPSIZE) * zVal
    End Sub


End Class
