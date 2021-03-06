﻿Public Class ShowTimeLine

    Private Sub ShowTimeLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeLineUserControl1.SuspendLayout()
        TimeLineUserControl1.Title = "発注明細：17-03-5111-00"

        Dim ds As New DataSet

#Region "DataSet Initialize"
        Dim dt As New DataTable("WarehouseStatusTable")

        'dt.Columns.Add("OperateDate", GetType(Date), "Stock in or Stcok out Date")
        'dt.Columns.Add("Count", GetType(Integer), "Goods Count")
        'dt.Columns.Add("Total", GetType(Integer), "Stocked Goods Total Count")
        'dt.Columns.Add("OperateType", GetType(Boolean), "Stocked Type[true=stock in  false=stock out]")

        dt.Columns.Add("OperateDate", GetType(Date))
        dt.Columns.Add("Count", GetType(Integer))
        dt.Columns.Add("Total", GetType(Integer))
        dt.Columns.Add("OperateType", GetType(Integer))  '0:入庫　1：出庫　10：発注日　11：納期

        ds.Tables.Add(dt)

        Dim r As DataRow

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 13), 10000, 0, 10}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 15), 5000, 5000, 0}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 21), 5000, 10000, 0}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 23), 2000, 8000, 1}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 24), 10000, 0, 11}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 7), 5000, 13000, 0}
        dt.Rows.Add(r)

        'r = dt.NewRow
        'r.ItemArray = New Object() {New Date(2017, 3, 7), 5000, 13000, True}
        'dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 23), 5000, 8000, 1}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 24), 4999, 3001, 1}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 25), 3001, 0, 1}
        dt.Rows.Add(r)

        ds.AcceptChanges()
#End Region

        With ds.Tables(0)
            TimeLineUserControl1.DataMember = .TableName
            TimeLineUserControl1.OperateDateColumn = .Columns.Item(0).ColumnName
            TimeLineUserControl1.CountColumn = .Columns.Item(1).ColumnName
            TimeLineUserControl1.TotalColumn = .Columns.Item(2).ColumnName
            TimeLineUserControl1.TypeColumn = .Columns.Item(3).ColumnName
        End With

        TimeLineUserControl1.DataSource = ds
        TimeLineUserControl1.ResumeLayout()
    End Sub

    Private Sub C1Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles C1Chart1.MouseMove

        C1Chart1.SuspendLayout()

        With New Rectangle(C1Chart1.ChartArea.PlotArea.Location, C1Chart1.ChartArea.PlotArea.Size)
            If .Contains(e.Location) Then
                C1Chart1.Refresh()

                Dim g As Graphics = C1Chart1.CreateGraphics
                Dim p As Pen = New Pen(Brushes.Red, 2)
                p.DashStyle = Drawing2D.DashStyle.Dash

                Dim sf As StringFormat = New StringFormat()
                sf.Alignment = StringAlignment.Far


                g.DrawLine(p, .X, e.Y, .X + .Width, e.Y)
                g.DrawLine(p, e.X, .Y, e.X, .Y + .Height)

                g.DrawString(Math.Floor((((e.X - .X) / .Width) * 10)).ToString, C1Chart1.Font, Brushes.Red, e.X, .Y + .Height - 10)
                g.DrawString(CalculateGoodsCount(e.Y, .Y, .Height).ToString(), C1Chart1.Font, Brushes.Red, .X + 10, e.Y)
            End If
        End With

        C1Chart1.ResumeLayout()
    End Sub

    Private Function CalculateGoodsCount(mouseLocationY As Double, canvasLocationY As Double, canvasHeight As Double) As Integer
        Dim scaleRate As Double = 1 - (mouseLocationY - canvasLocationY) / canvasHeight
        Dim count As Integer = Math.Floor(scaleRate * 18000)
        Return (Math.Floor(count / 100)) * 100
    End Function
End Class
