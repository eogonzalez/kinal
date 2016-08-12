Public Class Centralita
    Private Shared _Acumulador As Double
    Private Shared _Contador As Integer

    Public Shared Function GetTotalLlamadas() As Integer
        Return _Contador
    End Function

    Public Shared Function GetTotalFacturacion() As Double
        Return _Acumulador
    End Function

    Public Shared Sub RegistrarLlamada(ByVal Registro As Llamada)
        _Contador = _Contador + 1
        _Acumulador = _Acumulador + Registro.CalcularPrecio()
    End Sub



End Class
