Imports MahApps.Metro.Controls
Partial Public Class Menu
    Inherits MetroWindow

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DataContext = New ModelMenu()
    End Sub

End Class
