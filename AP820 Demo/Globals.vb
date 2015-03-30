Module Globals
    Public AP820Laser1 As New AP820Class
    Public AP820Laser2 As New AP820Class
    Public frmSecondLaser As New SecondLaserForm
    Public Filename As String
    Public ValidInFileNameFlag As Boolean
    Public ValidOutFileNameFlag As Boolean
    Public SendToFileFlag As Boolean
    Public Const BLOCKSIZE = 579
    Public Const STEPSIZE As double = 0.0000226 `
End Module
