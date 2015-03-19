Imports System.Drawing

Public Class GraphControl
    Private GraphLeft, GraphTop, GraphWidth, GraphHeight As Integer
    Private MaxTop, MinTop As Integer
    Private MinX, MaxX, MinY, MaxY, XRange, YRange As Integer
    Private XArray(), YArray(), OldXArray(1000), OldYArray(1000) As UInteger
    Private NumberOfPoints, OldNumberOfPoints As Integer
    Private ScaleXMin, ScaleXMax, ScaleYMin, ScaleYMax, ScaleXRange, ScaleYRange As Single
    Private MouseX, MouseY As Single
    Public TipString, OldTipString As String

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()

        GraphLeft = 70
        GraphTop = 20
        GraphWidth = (System.Math.Round(((Me.Width - GraphLeft - 20) / 10)) * 10) - 1
        GraphHeight = (System.Math.Round(((Me.Height - GraphTop - 50) / 10)) * 10) - 1
        MinX = 0
        MinY = 0
        MaxX = 100
        MaxY = 100
        NumberOfPoints = 0

    End Sub

    Public Sub SetLimits(ByVal MinimumX As Single, ByVal MaximumX As Single, ByVal MinimumY As Single, ByVal MaximumY As Single)
        MinX = MinimumX
        MaxX = MaximumX
        MinY = MinimumY
        MaxY = MaximumY
        XRange = MaxX - MinX
        YRange = MaxY - MinY


    End Sub

    Public Sub SetScale(ByVal MinimumX As Single, ByVal MaximumX As Single, ByVal MinimumY As Single, ByVal MaximumY As Single)
        Dim g As Graphics
        Dim ScaleSpace As Integer = 40

        ScaleXMin = MinimumX
        ScaleXMax = MaximumX
        ScaleYMin = MinimumY
        ScaleYMax = MaximumY
        ScaleXRange = MaximumX - MinimumX
        ScaleYRange = MaximumY - MinimumY


        If ScaleXRange > 0 Then
            GraphWidth = (System.Math.Round(((Me.Width - GraphLeft - 20) / ScaleXRange)) * ScaleXRange) - 1
            GraphHeight = Me.Height
            Do While GraphHeight > Me.Height - GraphTop - 40
                ScaleSpace += 10
                GraphHeight = (System.Math.Round(((Me.Height - GraphTop - ScaleSpace) / ScaleYRange)) * ScaleYRange) - 1
            Loop
            g = Me.CreateGraphics
            DrawOuterBox(g)
            DrawGraphBox(g)
            DrawXLabel(g)
            DrawYLabel(g)
            DrawXTicks(g)
            DrawYTicks(g)
            DrawXScale(g)
            DrawYScale(g)
            DrawXGridlines(g)
            DrawYGridlines(g)
            g.Dispose()
        End If

    End Sub

    Public Sub DrawXTicks(ByVal g As Graphics)
        Dim TickSpacing, StepSize As Single
        Dim I As Integer
        Dim p As Pen
        Dim XPos, YPos As Integer

        If ScaleXRange <> 0 Then
            TickSpacing = GraphWidth / ScaleXRange
            StepSize = 1
            Do While GraphWidth / TickSpacing > 10
                TickSpacing = TickSpacing * 2
                StepSize = StepSize * 2
            Loop
            p = New Pen(Color.Black)
            YPos = GraphTop + GraphHeight
            XPos = GraphLeft - 1

            For I = 0 To ScaleXRange Step StepSize
                g.DrawLine(p, XPos, YPos, XPos, YPos + 10)
                XPos = XPos + TickSpacing
            Next
            p.Dispose()
        End If

    End Sub

    Public Sub DrawYTicks(ByVal g As Graphics)
        Dim TickSpacing, StepSize As Integer
        Dim I As Integer
        Dim p As Pen
        Dim XPos, YPos As Integer

        If ScaleYRange <> 0 Then
            TickSpacing = GraphHeight / ScaleYRange
            StepSize = 1
            Do While GraphHeight / TickSpacing > 5
                TickSpacing = TickSpacing * 2
                StepSize = StepSize * 2
            Loop
            p = New Pen(Color.Black)
            YPos = GraphTop + GraphHeight
            XPos = GraphLeft
            For I = 0 To ScaleYRange Step StepSize
                g.DrawLine(p, XPos, YPos, XPos - 10, YPos)
                YPos = YPos - TickSpacing
            Next
        End If

    End Sub

    Public Sub DrawXScale(ByVal g As Graphics)
        Dim TickSpacing, StepSize As Integer
        Dim I As Integer
        Dim XPos, YPos As Integer
        Dim Str As String
        Dim b As SolidBrush
        Dim sz As SizeF

        If ScaleXRange <> 0 Then
            b = New SolidBrush(Color.Black)
            TickSpacing = (GraphWidth + 1) / ScaleXRange
            StepSize = 1
            Do While GraphWidth / TickSpacing > 10
                TickSpacing = TickSpacing * 2
                StepSize = StepSize * 2
            Loop
            For I = 0 To ScaleXRange Step StepSize
                Str = (I * ScaleXRange / ((GraphWidth + 1) / TickSpacing * StepSize)).ToString("0.0")
                sz = g.MeasureString(Str, Me.Font)
                YPos = GraphTop + GraphHeight + sz.Height
                XPos = GraphLeft + (I * TickSpacing / StepSize) - sz.Width / 2
                g.DrawString(Str, Me.Font, b, XPos, YPos)
            Next
            b.Dispose()
        End If

    End Sub

    Public Sub DrawYScale(ByVal g As Graphics)
        Dim TickSpacing, StepSize As Integer
        Dim I As Integer
        Dim XPos, YPos As Integer
        Dim Str As String
        Dim b As SolidBrush
        Dim sz As SizeF

        If ScaleYRange <> 0 Then
            b = New SolidBrush(Color.Black)
            TickSpacing = (GraphHeight + 1) / ScaleYRange
            StepSize = 1
            Do While (GraphHeight + 1) / TickSpacing > 5
                TickSpacing = TickSpacing * 2
                StepSize = StepSize * 2
            Loop
            For I = 0 To ScaleYRange Step StepSize
                Str = (I * ScaleYRange / ((GraphHeight + 1) / TickSpacing * StepSize)).ToString("0.0")
                sz = g.MeasureString(Str, Me.Font)
                YPos = GraphTop + GraphHeight - (I * TickSpacing / StepSize) - (sz.Height / 2)
                XPos = GraphLeft - sz.Width - 10
                g.DrawString(Str, Me.Font, b, XPos, YPos)
            Next
            b.Dispose()
        End If

    End Sub

    Public Sub DrawXGridlines(ByVal g As Graphics)
        Dim TickSpacing, StepSize As Integer
        Dim I As Integer
        Dim p As Pen
        Dim XPos, YPos As Integer

        If ScaleXRange <> 0 Then
            TickSpacing = (GraphWidth + 1) / ScaleXRange
            StepSize = 1
            Do While GraphWidth / TickSpacing > 10
                TickSpacing = TickSpacing * 2
                StepSize = StepSize * 2
            Loop
            p = New Pen(Color.Green)
            YPos = GraphTop
            XPos = GraphLeft - 1 + TickSpacing

            For I = 1 To ScaleXRange - StepSize Step StepSize
                g.DrawLine(p, XPos, YPos, XPos, YPos + GraphHeight - 1)
                XPos = XPos + TickSpacing
            Next
            p.Dispose()
        End If

    End Sub

    Public Sub DrawYGridlines(ByVal g As Graphics)
        Dim TickSpacing, StepSize As Integer
        Dim I As Integer
        Dim p As Pen
        Dim XPos, YPos As Integer

        If ScaleYRange <> 0 Then
            TickSpacing = (GraphHeight + 1) / ScaleYRange
            StepSize = 1
            Do While GraphHeight / TickSpacing > 5
                TickSpacing = TickSpacing * 2
                StepSize = StepSize * 2
            Loop
            p = New Pen(Color.Green)
            YPos = GraphTop + GraphHeight - TickSpacing
            XPos = GraphLeft + GraphWidth - 1
            For I = 1 To ScaleYRange - StepSize Step StepSize
                g.DrawLine(p, XPos, YPos, XPos - GraphWidth, YPos)
                YPos = YPos - TickSpacing
            Next
        End If

    End Sub

    Public Sub PlotArrays(ByVal X() As UInteger, ByVal Y() As UInteger, ByVal Length As Integer)
        Dim g As Graphics

        g = Me.CreateGraphics

        UnPlot(g)
        DrawXGridlines(g)
        DrawYGridlines(g)

        NumberOfPoints = Length
        XArray = X
        YArray = Y

        Plot(g)

        OldNumberOfPoints = NumberOfPoints

        XArray.CopyTo(OldXArray, 0)
        YArray.CopyTo(OldYArray, 0)

        g.Dispose()

    End Sub

    Public Sub DrawTipString()
        Dim g As Graphics
        Dim b As SolidBrush
        Dim XPos, YPos As Integer
        Dim sz As SizeF

        g = Me.CreateGraphics
        b = New SolidBrush(Drawing.SystemColors.Control)
        sz = g.MeasureString("A", Me.Font)
        XPos = GraphLeft
        YPos = Me.Height - sz.Height - 5
        g.DrawString(OldTipString, Me.Font, b, XPos, YPos)
        b.Color = Color.Black
        g.DrawString(TipString, Me.Font, b, XPos, YPos)
        b.Dispose()
        g.Dispose()

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        MouseX = ((e.X - GraphLeft) / GraphWidth) * ScaleXMax
        MouseY = ScaleYMax - (((e.Y - GraphTop) / GraphHeight) * ScaleYMax)
        OldTipString = TipString
        If MouseX >= 0 And MouseX <= ScaleXMax And MouseY >= 0 And MouseY <= ScaleYMax And ScaleXMax > 0 Then
            TipString = MouseX.ToString("0.000") + ", " + MouseY.ToString("0.000")
        Else
            TipString = ""
        End If
        DrawTipString()

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics

        MyBase.OnPaint(e)
        g = e.Graphics

        DrawOuterBox(g)
        DrawGraphBox(g)
        DrawXLabel(g)
        DrawYLabel(g)
        DrawXTicks(g)
        DrawYTicks(g)
        DrawXScale(g)
        DrawYScale(g)
        DrawXGridlines(g)
        DrawYGridlines(g)
        Plot(g)

        g.Dispose()

    End Sub

    Private Sub DrawXLabel(ByVal g As Graphics)
        Dim b As SolidBrush
        Dim XPos, YPos As Integer
        Dim sz As SizeF

        b = New SolidBrush(Color.Black)
        sz = g.MeasureString("X (mm)", Me.Font)
        XPos = GraphLeft + (GraphWidth / 2) - (sz.Width / 2)
        YPos = Me.Height - sz.Height - 5
        g.DrawString("X (mm)", Me.Font, b, XPos, YPos)
        b.Dispose()
    End Sub

    Private Sub DrawYLabel(ByVal g As Graphics)
        Dim b As SolidBrush
        Dim XPos, YPos As Integer
        Dim sz As SizeF

        b = New SolidBrush(Color.Black)
        sz = g.MeasureString("Z (mm)", Me.Font)
        XPos = 2
        YPos = GraphTop + (GraphHeight / 2) - (sz.Height / 2)
        g.DrawString("Z (mm)", Me.Font, b, XPos, YPos)
        b.Dispose()
    End Sub

    Private Sub UnPlot(ByVal g As Graphics)
        Dim I As Integer
        Dim b As SolidBrush
        Dim Left, Top As Integer

        b = New SolidBrush(Color.LightBlue)
        For I = 0 To OldNumberOfPoints - 1
            Left = GraphLeft + (OldXArray(I) / XRange) * GraphWidth
            Top = GraphTop + GraphHeight - ((OldYArray(I) / YRange) * GraphHeight)
            g.FillRectangle(b, Left, Top, 1, 1)
        Next

        b.Dispose()
    End Sub

    Private Sub Plot(ByVal g As Graphics)
        Dim I As Integer
        Dim b As SolidBrush
        Dim Left, Top As Integer

        If YRange = 0 Or XRange = 0 Then Exit Sub

        b = New SolidBrush(Color.Black)
        For I = 0 To NumberOfPoints - 1
            Left = GraphLeft + (XArray(I) / XRange) * GraphWidth
            Top = GraphTop + GraphHeight - ((YArray(I) / YRange) * GraphHeight)
            g.FillRectangle(b, Left, Top, 1, 1)
        Next

        b.Dispose()
    End Sub

    Private Sub DrawGraphBox(ByVal g As Graphics)
        Dim b As SolidBrush
        Dim p As Pen

        b = New SolidBrush(Color.LightBlue)
        p = New Pen(Color.Black)


        g.FillRectangle(b, GraphLeft, GraphTop, GraphWidth, GraphHeight)
        g.DrawRectangle(p, GraphLeft - 1, GraphTop - 1, GraphWidth + 1, GraphHeight + 1)

        b.Dispose()

    End Sub

    Private Sub DrawOuterBox(ByVal g As Graphics)
        Dim b As SolidBrush
        Dim p As Pen

        b = New SolidBrush(Drawing.SystemColors.Control)
        p = New Pen(Color.Black)


        g.FillRectangle(b, 0, 0, Me.Width, Me.Height)
        g.DrawRectangle(p, 0, 0, Me.Width - 1, Me.Height - 1)

        b.Dispose()
    End Sub

End Class
