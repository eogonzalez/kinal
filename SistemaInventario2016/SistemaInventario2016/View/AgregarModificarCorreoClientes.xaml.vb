Public Class AgregarModificarCorreoClientes

    Public Sub New(ByVal Modelo As ModelCorreoClientes)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.DataContext = Modelo
    End Sub

End Class
