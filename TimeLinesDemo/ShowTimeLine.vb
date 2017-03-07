Public Class ShowTimeLine
    'Public Sub New()

    '    ' この呼び出しはデザイナーで必要です。
    '    InitializeComponent()

    '    ' InitializeComponent() 呼び出しの後で初期化を追加します。
    '    Dim label1 As New PictureBox
    '    label1.AutoSize = False
    '    'label1.BorderStyle = BorderStyle.None

    '    label1.Location = New Point(400, 30)
    '    label1.Size = New Size(20, 20)

    '    Me.Controls.Add(label1)

    'End Sub

    Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles Canvas.Paint
        Dim pic As New Bitmap(360, 464)

        '描画先とするImageオブジェクトを作成する

        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(pic)

        'Dim g As Graphics = e.Graphics

        'Penオブジェクトの作成(幅3黒色)
        Dim linePen As New Pen(Color.DarkGray, 2)
        linePen.DashStyle = Drawing2D.DashStyle.Dash


        'Gridを描く
        'With e.ClipRectangle
        '    For i = 0 To e.ClipRectangle.Height / 10
        '        Dim grid_y As Integer = 10 * (i + 1)
        '        g.DrawLine(Pens.LightGray, 0, grid_y, .Width, grid_y)
        '    Next

        '    For i = 0 To e.ClipRectangle.Width / 10
        '        Dim grid_x As Integer = 10 * (i + 1)
        '        g.DrawLine(Pens.LightGray, grid_x, 0, grid_x, .Height)
        '    Next
        'End With

        Dim font_title As Font = New Font("MS UI Gothic", 9, FontStyle.Bold)
        g.DrawString("発注明細№：17-03-5111-00", font_title, Brushes.Black, 5, 5)


        Dim f As Font = New Font("MS UI Gothic", 9)
        Dim x As Integer = 160

        g.DrawLine(linePen, x + 10, 40, x + 10, 430)

        Dim p As Point = Canvas.PointToClient(MousePosition)
        Dim disp_p As New Point(p.X + 15, p.Y + 15)
        If p.X > 160 AndAlso p.X < 180 Then
            Select Case p.Y
                Case 30 To 50
                    g.DrawString("在庫  5,000", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 30 - 5, 30, 30))
                Case 90 To 110
                    g.DrawString("在庫 10,000", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 90 - 5, 30, 30))
                Case 120 To 140
                    g.DrawString("在庫  8,000", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 120 - 5, 30, 30))
                Case 240 To 260
                    g.DrawString("在庫 13,000", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 240 - 5, 30, 30))
                Case 360 To 380
                    g.DrawString("在庫  8,000", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 360 - 5, 30, 30))
                Case 390 To 410
                    g.DrawString("在庫  3,001", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 390 - 5, 30, 30))
                Case 420 To 440
                    g.DrawString("在庫      0", f, Brushes.Red, disp_p)
                    g.FillEllipse(Brushes.LightPink, New RectangleF(x - 5, 420 - 5, 30, 30))
                Case Else
            End Select
        End If

        g.FillEllipse(Brushes.LightGreen, New RectangleF(x, 30, 20, 20))
        g.DrawString("2017.02.15  入庫 5,000", f, Brushes.Black, x + 30, 35)

        g.FillEllipse(Brushes.LightGreen, New RectangleF(x, 90, 20, 20))
        g.DrawString("2017.02.21  入庫 5,000", f, Brushes.Black, x + 30, 95)

        g.FillEllipse(Brushes.Blue, New RectangleF(x, 120, 20, 20))
        g.DrawString("2017.02.23  出庫 2,000", f, Brushes.Black, x - 130, 125)

        g.FillEllipse(Brushes.LightGreen, New RectangleF(x, 240, 20, 20))
        g.DrawString("2017.03.07  入庫 5,000", f, Brushes.Black, x + 30, 245)

        g.FillEllipse(Brushes.Blue, New RectangleF(x, 360, 20, 20))
        g.DrawString("2017.03.23  出庫 5,000", f, Brushes.Black, x - 130, 365)

        g.FillEllipse(Brushes.Blue, New RectangleF(x, 390, 20, 20))
        g.DrawString("2017.03.24  出庫 4,999", f, Brushes.Black, x - 130, 395)

        g.FillEllipse(Brushes.Blue, New RectangleF(x, 420, 20, 20))
        g.DrawString("2017.03.27  出庫 3,001", f, Brushes.Black, x - 130, 425)

        linePen.Dispose()
        g.Dispose()

        'Canvasに表示する
        Canvas.Image = pic
    End Sub

    Private Sub Canvas_Click(sender As Object, e As EventArgs) Handles Canvas.Click
        'Dim p As Point = Canvas.PointToClient(MousePosition)
        'If 160 < p.X < 180 Then
        '    Select Case p.Y
        '        Case 30 To 50
        '            msgTooltip.SetToolTip(Canvas, "在庫 5,000")
        '        Case 90 To 110
        '            msgTooltip.SetToolTip(Canvas, "在庫 10,000")
        '        Case 120 To 140
        '            msgTooltip.SetToolTip(Canvas, "在庫 8,000")
        '        Case 240 To 260
        '        Case 360 To 380
        '        Case 390 To 410
        '        Case 420 To 440
        '        Case Else
        '    End Select
        'End If
    End Sub
End Class
