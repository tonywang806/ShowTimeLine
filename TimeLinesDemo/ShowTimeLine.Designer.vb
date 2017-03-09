<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ShowTimeLine
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShowTimeLine))
        Me.C1Chart1 = New C1.Win.C1Chart.C1Chart()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TimeLineUserControl1 = New TimeLineUserControl.TimeLineUserControl()
        CType(Me.C1Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Chart1
        '
        Me.C1Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Chart1.Location = New System.Drawing.Point(3, 3)
        Me.C1Chart1.Name = "C1Chart1"
        Me.C1Chart1.PropBag = resources.GetString("C1Chart1.PropBag")
        Me.C1Chart1.Size = New System.Drawing.Size(894, 600)
        Me.C1Chart1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.C1Chart1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(368, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 606.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(900, 606)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 365.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TimeLineUserControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1271, 612)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TimeLineUserControl1
        '
        Me.TimeLineUserControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TimeLineUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimeLineUserControl1.CountColumn = Nothing
        Me.TimeLineUserControl1.DataMember = ""
        Me.TimeLineUserControl1.DataSource = Nothing
        Me.TimeLineUserControl1.IsDisplayGrid = False
        Me.TimeLineUserControl1.Location = New System.Drawing.Point(0, 0)
        Me.TimeLineUserControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TimeLineUserControl1.MinimumSize = New System.Drawing.Size(365, 465)
        Me.TimeLineUserControl1.Name = "TimeLineUserControl1"
        Me.TimeLineUserControl1.OperateDateColumn = Nothing
        Me.TimeLineUserControl1.Size = New System.Drawing.Size(365, 612)
        Me.TimeLineUserControl1.TabIndex = 1
        Me.TimeLineUserControl1.Title = Nothing
        Me.TimeLineUserControl1.TotalColumn = Nothing
        Me.TimeLineUserControl1.TypeColumn = Nothing
        '
        'ShowTimeLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1271, 612)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ShowTimeLine"
        Me.Text = "在庫物量変化モニター"
        CType(Me.C1Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimeLineUserControl1 As TimeLineUserControl.TimeLineUserControl
    Friend WithEvents C1Chart1 As C1.Win.C1Chart.C1Chart
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
