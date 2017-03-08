﻿Imports System.Drawing.Drawing2D
Imports System.Threading

Public Class TimeLineUserControl

    'Cycle Thread Prccess Abort Flag
    Dim isThreadContinous As Boolean = True

    'Thread Manual Control Handler
    Dim _event As ManualResetEvent = New ManualResetEvent(True)

    'DataBinding Delegete
    Public Event BeforeBinding As System.EventHandler


    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        'SetStyle(ControlStyles.ResizeRedraw, True)
        'SetStyle(ControlStyles.DoubleBuffer, True)
        'SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.UserMouse, True)
        'SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        'Allow Operate Resouce Btween Two Thread 
        CheckForIllegalCrossThreadCalls = False

    End Sub

    Private Sub TimeLineUserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'Dispose Resouce When Disposed Event Happend
        isThreadContinous = False
        _event.Dispose()
    End Sub

    Private Sub TimeLineUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Not Run in Design Mode
        If Me.DesignMode Then
            Return
        End If
        'Start Thread
        Dim t As Thread = New Thread(AddressOf Work)
        t.Start()
    End Sub

    Private Overloads Sub SuspendLayout()
        'Suspend Thread
        _event.Reset()
    End Sub


    Private Overloads Sub ResumeLayout()
        'Resume Thread
        _event.Set()
    End Sub

    Private Sub Work()
        Try
            While (isThreadContinous)
                'Create a Bitmap
                Dim pic As Bitmap = timeLineCanvas_Paint()

                If pic IsNot Nothing Then
                    'Refresh Canvas
                    timeLineCanvas.Image = pic
                End If

                Thread.Sleep(100)
            End While
        Catch ex As Exception
            Console.WriteLine("thread excaption:{0}", ex.Message)
        End Try
    End Sub

    Private Function timeLineCanvas_Paint() As Bitmap

        'データバンディングしない場合、Nothingを戻す
        If DataSource Is Nothing Then
            Return Nothing
        End If

        'テーブル名を設定しない場合、Nothingを戻す
        If DataSource.Tables(DataMember) Is Nothing Then
            Return Nothing
        End If

        'データが存在しない場合、Nothingを戻す
        If DataSource.Tables(DataMember).Rows.Count = 0 Then
            Return Nothing
        End If

        '描画先とするImageオブジェクトを作成する
        Dim pic As New Bitmap(360, 30 * elementCount + 60)

        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(pic)

        'Penオブジェクトの作成(幅2灰色)
        Dim linePen As New Pen(Color.DarkGray, 2)
        linePen.DashStyle = DashStyle.Dash

        'Brushオブジェクトの作成(半透明、ピンク）
        Dim solidBrush As New SolidBrush(Color.FromArgb(64, Color.LightPink))

        'Fontオブジェクトの作成
        Dim font_title As Font = New Font(Me.Font, FontStyle.Bold)
        Dim font_detial As Font = New Font("MS UI Gothic", 9)

        ' Canvas Middle X Position
        Dim x As Integer = 160

        Try

            'Drawing Title
            g.DrawString(Title, font_title, Brushes.Black, 5, 5)

            'Drawing Time Line
            g.DrawLine(linePen, x + 10, 40, x + 10, pic.Height - 40)

            'Drawing Element Points and Detail Infomations
            For Each r As DataRow In DataSource.Tables.Item("innerTable").Rows
                DrawPointElement(g, solidBrush,
                                 New PointF(x, CType(r.Item("GapDay"), Integer) * 30), font_detial,
                                 String.Format("{0}  入庫 {1}",
                                               CType(r.Item(OperateDateColumn), Date).ToShortDateString,
                                               CType(r.Item(CountColumn), Integer)),
                                 String.Format("在庫  {0}", CType(r.Item(TotalColumn), Integer)),
                                 CType(r.Item(TypeColumn), Boolean))
            Next

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            linePen.Dispose()
            solidBrush.Dispose()
            g.Dispose()
        End Try

        Return pic

    End Function
    ''' <summary>
    ''' Drawing Element at the Point
    ''' </summary>
    ''' <param name="g">Graphicsオブジェクト</param>
    ''' <param name="solidBrush">半透明Brushオブジェクト</param>
    ''' <param name="p">Drawing Position</param>
    ''' <param name="f">Font</param>
    ''' <param name="title">Element Information</param>
    ''' <param name="tips">ToolTips Information</param>
    ''' <param name="isStockIn">入出庫フラグ</param>
    Private Sub DrawPointElement(ByRef g As Graphics, ByRef solidBrush As SolidBrush, p As PointF, f As Font,
                                 title As String, tips As String, Optional isStockIn As Boolean = True)

        'Mouse Location (Covert into Canvas Coordinate System)
        Dim mouse_p As Point = timeLineCanvas.PointToClient(MousePosition)

        'Drawing Area
        Dim elementRegion As RectangleF = New RectangleF(p, New SizeF(20, 20))

        'if Drawing Area contains the Mouse Location
        'Draw the Highlight and the tooltips information.
        If elementRegion.Contains(mouse_p) Then

            'Drawing ToolTips Informations
            g.DrawString(tips, f, Brushes.Red, mouse_p.X + 15, mouse_p.Y + 15)

            'Drawing HightLight
            g.FillEllipse(solidBrush, New RectangleF(p.X - 8, p.Y - 8, 36, 36))
            g.FillEllipse(solidBrush, New RectangleF(p.X - 5, p.Y - 5, 30, 30))
            g.FillEllipse(solidBrush, New RectangleF(p.X - 3, p.Y - 3, 26, 26))

            'Drawing the Edge of Element Point
            If isStockIn Then
                g.FillEllipse(Brushes.LightGreen, New RectangleF(p.X - 2, p.Y - 2, 24, 24))
            Else
                g.FillEllipse(Brushes.Blue, New RectangleF(p.X - 2, p.Y - 2, 24, 24))
            End If

        End If

        'Drawing Element Point and Detial Informations
        If isStockIn Then
            g.FillEllipse(Brushes.LightGreen, elementRegion)
            g.DrawString(title, f, Brushes.Black, p.X + 30, p.Y + 5)
        Else
            g.FillEllipse(Brushes.Blue, elementRegion)
            g.DrawString(title, f, Brushes.Black, p.X - 130, p.Y + 5)
        End If

    End Sub

    Private Sub BeforeDataSetBinding(ByRef ds As DataSet)
        If ds IsNot Nothing Then
            'Resorting by OperatedDate
            Dim dv As DataView = ds.Tables(0).DefaultView
            dv.Sort = String.Format("{0} ASC", OperateDateColumn)

            Dim SortTabel As DataTable = dv.ToTable("innerTable")
            SortTabel.Columns.Add("GapDay", GetType(Integer))
            SortTabel.AcceptChanges()

            ds.Tables.Add(SortTabel)
            ds.AcceptChanges()

            'Calculate the Count of element
            With ds.Tables.Item("innerTable")
                elementCount = caluteElementCount(.Rows)
            End With

            RaiseEvent BeforeBinding(Me, New EventArgs())
        End If
    End Sub

    Private Function caluteElementCount(ByRef rows As DataRowCollection) As Integer
        Dim ret As Integer = 0
        Dim currentDate As Date = Date.MinValue
        For Each r As DataRow In rows
            If currentDate = Date.MinValue Then
                currentDate = CType(r.Item(OperateDateColumn), Date)
                ret = 1
            Else
                Dim days As Integer = caluteDays(currentDate, CType(r.Item(OperateDateColumn), Date))
                If days > 3 Then
                    ret = ret + 3
                ElseIf days = 0 Then
                    ret = ret + 1
                Else
                    ret = ret + days
                End If
                currentDate = CType(r.Item(OperateDateColumn), Date)
            End If
            r.Item("GapDay") = ret
        Next
        Return ret
    End Function

    Private Function caluteDays(fromDate As Object, toDate As Object) As Integer
        Dim tp As TimeSpan = CType(toDate, Date).Subtract(CType(fromDate, Date))
        Return tp.TotalDays
    End Function

    Private Sub scrollPanel_Paint(sender As Object, e As PaintEventArgs) Handles scrollPanel.Paint
        ' Not Run in Design Mode
        If Me.DesignMode Then
            Return
        End If

        If IsDisplayGrid Then
            Dim pic As Bitmap = New Bitmap(scrollPanel.Width, scrollPanel.Height)
            Dim g As Graphics = Graphics.FromImage(pic)
            'Gridを描く
            With pic
                For i = 0 To .Height / 10
                    Dim grid_y As Integer = 10 * (i + 1)
                    g.DrawLine(Pens.LightGray, 0, grid_y, .Width, grid_y)
                Next

                For i = 0 To .Width / 10
                    Dim grid_x As Integer = 10 * (i + 1)
                    g.DrawLine(Pens.LightGray, grid_x, 0, grid_x, .Height)
                Next
            End With

            'Drawing Grid
            timeLineCanvas.SuspendLayout()
            e.Graphics.DrawImage(pic, 0, 0)
            timeLineCanvas.ResumeLayout()
        End If
    End Sub
End Class