Public Class VentanaInventario
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DataContext = New ModelInvetarios
    End Sub
End Class
