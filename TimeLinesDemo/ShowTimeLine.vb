Public Class ShowTimeLine

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
        dt.Columns.Add("OperateType", GetType(Boolean))

        ds.Tables.Add(dt)

        Dim r As DataRow

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 15), 5000, 5000, True}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 21), 5000, 10000, True}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 2, 23), 2000, 8000, False}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 7), 5000, 13000, True}
        dt.Rows.Add(r)

        'r = dt.NewRow
        'r.ItemArray = New Object() {New Date(2017, 3, 7), 5000, 13000, True}
        'dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 23), 5000, 8000, False}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 24), 4999, 3001, False}
        dt.Rows.Add(r)

        r = dt.NewRow
        r.ItemArray = New Object() {New Date(2017, 3, 25), 3001, 0, False}
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
End Class
