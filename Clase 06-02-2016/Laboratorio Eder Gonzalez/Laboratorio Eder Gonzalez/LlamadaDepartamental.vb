Public Class LlamadaDepartamental
    Inherits Llamada

    Private _PrecioUno As Double = 1.25
    Private _PrecioDos As Double = 1.75
    Private _PrecioTres As Double = 2.25
    Private _Franja As Integer

    Public Property PrecioUno As Double
        Get
            Return _PrecioUno
        End Get
        Set(value As Double)
            _PrecioUno = value
        End Set
    End Property

    Public Property PrecioDos As Double
        Get
            Return _PrecioDos
        End Get
        Set(value As Double)
            _PrecioDos = value
        End Set
    End Property

    Public Property PrecioTres As Double
        Get
            Return _PrecioTres
        End Get
        Set(value As Double)
            _PrecioTres = value
        End Set
    End Property

    Public Property Franja As Integer
        Get
            Return _Franja
        End Get
        Set(value As Integer)
            _Franja = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal NumeroOrigen As String, ByVal NumeroDestino As String, ByVal Duracion As Double,
                   ByVal PrecioUno As Double, ByVal PrecioDos As Double, ByVal PrecioTres As Double,
                   ByVal Franja As Integer)
        MyBase.New(NumeroOrigen, NumeroDestino, Duracion)
        Me.PrecioUno = PrecioUno
        Me.PrecioDos = PrecioDos
        Me.PrecioTres = PrecioTres
        Me.Franja = Franja
    End Sub

    Public Sub New(ByVal NumeroOrigen As String, ByVal NumeroDestino As String, ByVal Duracion As Double,
                   ByVal Franja As Integer)
        MyBase.New(NumeroOrigen, NumeroDestino, Duracion)
        Me.Franja = Franja
    End Sub

    Public Overrides Function CalcularPrecio() As Double
        Dim Resultado As Double = 0.00

        If Franja = 1 Then
            Resultado = PrecioUno * Duracion
        ElseIf Franja = 2 Then
            Resultado = PrecioDos * Duracion
        ElseIf Franja = 3 Then
            Resultado = PrecioTres * Duracion
        End If

        Return Resultado
    End Function

    Public Overrides Function tostring() As String
        Dim Resultado As String = String.Empty
        Resultado = "Se registro una llamada departamental " & vbCrLf &
            " Numero Origen: " & NumeroOrigen & vbCrLf &
            " Numero Destino: " & NumeroDestino & vbCrLf &
            " Costo: " & CalcularPrecio() & vbCrLf &
            " Duracion: " & Duracion

        Return Resultado
    End Function

End Class
