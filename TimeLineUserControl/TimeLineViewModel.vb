Partial Public Class TimeLineUserControl

    Private strTitle As String

    Private ds As DataSet
    Private strTableName As String
    Private strOperateDate As String
    Private strCount As String
    Private strTotal As String
    Private strType As String

    Private elementCount As Integer
    Private bool_IsDisplayGrid As Boolean

    Const GapDayColumn As String = "GapDay"

    Private snapStackInTotalCount As Integer = 0
    Private snapStackOutTotalCount As Integer = 0
    Private snapTotalCountInWarehouse As Integer = 0

    Public Property DataSource As DataSet
        Get
            Return ds
        End Get
        Set(value As DataSet)
            BeforeDataSetBinding(value)
            ds = value
        End Set
    End Property

    Public Property DataMember As String
        Get
            Return strTableName
        End Get
        Set(value As String)
            strTableName = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return strTitle
        End Get
        Set(value As String)
            strTitle = value
        End Set
    End Property

    Public Property OperateDateColumn As String
        Get
            Return strOperateDate
        End Get
        Set(value As String)
            strOperateDate = value
        End Set
    End Property

    Public Property CountColumn As String
        Get
            Return strCount
        End Get
        Set(value As String)
            strCount = value
        End Set
    End Property

    Public Property TotalColumn As String
        Get
            Return strTotal
        End Get
        Set(value As String)
            strTotal = value
        End Set
    End Property

    Public Property TypeColumn As String
        Get
            Return strType
        End Get
        Set(value As String)
            strType = value
        End Set
    End Property

    Public Property IsDisplayGrid As Boolean
        Get
            Return bool_IsDisplayGrid
        End Get
        Set(value As Boolean)
            bool_IsDisplayGrid = value
        End Set
    End Property

    Public Function GetLengthofLine() As Integer
        Return 30 * elementCount + 60
    End Function
End Class
