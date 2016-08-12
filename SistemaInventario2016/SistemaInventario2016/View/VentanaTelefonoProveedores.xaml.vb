Public Class VentanaTelefonoProveedores
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DataContext = New ModelTelefonoProveedores

    End Sub
End Class
