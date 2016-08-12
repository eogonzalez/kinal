Public Class LlamadaLocal
    Inherits Llamada

    Private _Precio As Double = 1.0

    Public Property Precio As Double
        Get
            Return _Precio
        End Get
        Set(value As Double)
            _Precio = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal NumeroOrigen As String, ByVal NumeroDestino As String, ByVal Duracion As Double, ByVal Precio As Double)
        MyBase.New(NumeroOrigen, NumeroDestino, Duracion)
        Me.Precio = Precio
    End Sub

    Public Overrides Function CalcularPrecio() As Double
        Dim Resultado As Double = 0.00
        Resultado = Precio * Duracion
        Return Resultado
    End Function

    Public Overrides Function tostring() As String
        Dim Resultado As String = String.Empty
        Resultado = "Se registro una llamada local " & vbCrLf &
            " Numero Origen: " & NumeroOrigen & vbCrLf &
            " Numero Destino: " & NumeroDestino & vbCrLf &
            " Costo: " & CalcularPrecio() & vbCrLf &
            " Duracion: " & Duracion

        Return Resultado
    End Function

End Class
