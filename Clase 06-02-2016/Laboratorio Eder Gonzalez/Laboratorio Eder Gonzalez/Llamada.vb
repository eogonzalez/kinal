Public MustInherit Class Llamada
    Private _NumeroOrigen As String
    Private _NumeroDestino As String
    Private _Duracion As Double
    Private _Compania As String

    Public Property NumeroOrigen As String
        Get
            Return _NumeroOrigen
        End Get
        Set(value As String)
            _NumeroOrigen = value
        End Set
    End Property

    Public Property NumeroDestino As String
        Get
            Return _NumeroDestino
        End Get
        Set(value As String)
            _NumeroDestino = value
        End Set
    End Property

    Public Property Duracion As Double
        Get
            Return _Duracion
        End Get
        Set(value As Double)
            _Duracion = value
        End Set
    End Property

    Public Property Compania As String
        Get
            Return _Compania
        End Get
        Set(value As String)
            _Compania = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal NumeroOrigen As String, ByVal NumeroDestino As String, ByVal Duracion As Double)
        Me.NumeroOrigen = NumeroOrigen
        Me.NumeroDestino = NumeroDestino
        Me.Duracion = Duracion
    End Sub

    Public Sub New(NumeroOrigen As String, NumeroDestino As String, Duracion As Double, ByVal Compania As String)
        Me.NumeroOrigen = NumeroOrigen
        Me.NumeroDestino = NumeroDestino
        Me.Duracion = Duracion
        Me.Compania = Compania
    End Sub

    Public MustOverride Function CalcularPrecio() As Double

End Class
