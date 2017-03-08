<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeLineUserControl
    Inherits System.Windows.Forms.UserControl

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.scrollPanel = New System.Windows.Forms.Panel()
        Me.timeLineCanvas = New System.Windows.Forms.PictureBox()
        Me.scrollPanel.SuspendLayout()
        CType(Me.timeLineCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scrollPanel
        '
        Me.scrollPanel.AutoScroll = True
        Me.scrollPanel.BackColor = System.Drawing.Color.White
        Me.scrollPanel.Controls.Add(Me.timeLineCanvas)
        Me.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scrollPanel.Location = New System.Drawing.Point(0, 0)
        Me.scrollPanel.Name = "scrollPanel"
        Me.scrollPanel.Size = New System.Drawing.Size(360, 460)
        Me.scrollPanel.TabIndex = 0
        '
        'timeLineCanvas
        '
        Me.timeLineCanvas.BackColor = System.Drawing.Color.Transparent
        Me.timeLineCanvas.InitialImage = Nothing
        Me.timeLineCanvas.Location = New System.Drawing.Point(0, 0)
        Me.timeLineCanvas.Name = "timeLineCanvas"
        Me.timeLineCanvas.Size = New System.Drawing.Size(360, 460)
        Me.timeLineCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.timeLineCanvas.TabIndex = 0
        Me.timeLineCanvas.TabStop = False
        '
        'TimeLineUserControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.Controls.Add(Me.scrollPanel)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(360, 460)
        Me.Name = "TimeLineUserControl"
        Me.Size = New System.Drawing.Size(360, 460)
        Me.scrollPanel.ResumeLayout(False)
        Me.scrollPanel.PerformLayout()
        CType(Me.timeLineCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scrollPanel As Panel
    Friend WithEvents timeLineCanvas As PictureBox
End Class
