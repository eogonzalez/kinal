Public Class AgregarModificarProveedor
    Public Sub New(ByVal Model As ModelProveedores)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DataContext = Model
    End Sub
End Class
