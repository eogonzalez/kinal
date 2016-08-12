Public Class AgregarModificarInventario
    Public Sub New(ByVal Model As ModelInvetarios)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DataContext = Model
    End Sub
End Class
