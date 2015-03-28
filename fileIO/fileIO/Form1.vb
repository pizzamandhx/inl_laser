Imports System
Imports System.IO
Imports System.Text
Imports System.String

Public Class fileIO
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Const BLOCKSIZE = 579
        'Dim path1 As String = "C:\Users\Sean\Documents\GitHub\inl_laser\fileIO\iotest.txt"
        Dim path2 As String = "C:\Users\Sean\Documents\GitHub\inl_laser\fileIO\junkout.txt"
        Dim path1 As String = "C:\Users\Sean\Documents\GitHub\inl_laser\fileIO\Knife Block (continuous with encoder).txt"
        'Dim path1 As String = "C:\Users\Sean\Documents\GitHub\inl_laser\fileIO\junkin.txt"
        Dim encoder As String = ""
        Dim i As Integer
        Dim j As Integer
        Dim y As Integer
        'declare linked list of Biomass objects
        Dim slice(BLOCKSIZE) As Point
        Dim curPoint As String = ""
        Dim loc(2) As Integer
        Dim out As String = ""
        Dim counter As Integer

        'In
        Using sr As StreamReader = File.OpenText(path1)
            Do While sr.Peek >= 0
                encoder = sr.ReadLine
                If encoder <> "" Then
                    i = encoder.IndexOf("Counts") + 8 'DO NOT CHANGE THIS NUMBER 8! THE ALGORITHM ONLY WORKS IF THE STRING BEING PARSED IS BUILT A CERTAIN WAY
                    y = Convert.ToInt32(encoder.Substring(i, encoder.Length - i))

                    For i = 0 To BLOCKSIZE
                        curPoint = sr.ReadLine
                        loc(2) = curPoint.Length
                        counter = 0
                        For j = 0 To loc(2) - 1
                            If (curPoint(j) = Chr(9)) Then
                                loc(counter) = j
                                counter += 1
                            End If
                        Next
                        slice(i).x = Convert.ToDouble(curPoint.Substring(0, loc(0)))
                        slice(i).z = Convert.ToDouble(curPoint.Substring(loc(0) + 1, ((loc(1) - loc(0)) - 1)))
                        slice(i).i = Convert.ToInt32(curPoint.Substring(loc(1) + 1, ((loc(2) - loc(1)) - 1)))
                        slice(i).y = y
                    Next
                End If

                For i = 0 To BLOCKSIZE
                    'Algorithm:
                    'step 1: detect left edge, toss points that match conveyor belt
                    'step 2: if left edge, make new Biomass object *** IF not continuing Object
                    'step 3: add points to Biomass object until right edge detected *** If no right edge found delete biomass Object
                    Dim lEdgeDetected As Boolean = False
                    counter = 0
                    Do Until lEdgeDetected
                        If slice(counter).i > 250 && slice(counter+1)
                            counter += 1
                    Loop

                Next
                'step 4: write biomass object to file to... wherever *** Once object has ended? (FindBotEdge found)

            Loop
        End Using
        'RichTextBox1.Text = cheese
        For i = 0 To slice.Length - 1
            out += Convert.ToString(slice(i).x) + "," + Convert.ToString(slice(i).y) + "," + Convert.ToString(slice(i).z) + "," + Convert.ToString(slice(i).i) + "," + vbCrLf
        Next
        'Out
        Using srw As New StreamWriter(path2)
            srw.Write(out)
        End Using

    End Sub
End Class

Public Structure Point
    Dim x As Double
    Dim y As Double
    Dim z As Double
    Dim i As Integer
End Structure
