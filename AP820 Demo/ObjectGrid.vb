'Const BLOCKSIZE = 579
Public Class Point
    'Private x As Double
    'Private y As Double
    'Private z As Double
    'Private i As Integer
    Public Property x As Integer
        Get
            Return x
        End Get
        Set(value As Integer)
            x = value
        End Set
    End Property

    Public Property y As Integer
        Get
            Return y
        End Get
        Set(value As Integer)
            y = value
        End Set
    End Property

    Public Property z As Integer
        Get
            Return z
        End Get
        Set(value As Integer)
            z = value
        End Set
    End Property

    Public Property i As Integer
        Get
            Return i
        End Get
        Set(value As Integer)
            i = value
        End Set
    End Property
    Sub New()
        x = 0
        y = 0
        z = 0
        i = 0
    End Sub

End Class
