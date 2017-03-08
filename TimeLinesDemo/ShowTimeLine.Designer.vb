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
        Me.TimeLineUserControl1 = New TimeLineUserControl.TimeLineUserControl()
        Me.SuspendLayout()
        '
        'TimeLineUserControl1
        '
        Me.TimeLineUserControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TimeLineUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimeLineUserControl1.CountColumn = Nothing
        Me.TimeLineUserControl1.DataMember = ""
        Me.TimeLineUserControl1.DataSource = Nothing
        Me.TimeLineUserControl1.IsDisplayGrid = True
        Me.TimeLineUserControl1.Location = New System.Drawing.Point(9, 9)
        Me.TimeLineUserControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TimeLineUserControl1.MinimumSize = New System.Drawing.Size(365, 465)
        Me.TimeLineUserControl1.Name = "TimeLineUserControl1"
        Me.TimeLineUserControl1.OperateDateColumn = Nothing
        Me.TimeLineUserControl1.Size = New System.Drawing.Size(365, 594)
        Me.TimeLineUserControl1.TabIndex = 1
        Me.TimeLineUserControl1.Title = Nothing
        Me.TimeLineUserControl1.TotalColumn = Nothing
        Me.TimeLineUserControl1.TypeColumn = Nothing
        '
        'ShowTimeLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 612)
        Me.Controls.Add(Me.TimeLineUserControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ShowTimeLine"
        Me.Text = "ShowTimeLines"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimeLineUserControl1 As TimeLineUserControl.TimeLineUserControl
End Class
