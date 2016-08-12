Public Class FormularioInicioSesion
    Private _Ventana As MainWindow
    Public Property Ventana As MainWindow
        Get
            Return _Ventana
        End Get
        Set(value As MainWindow)
            _Ventana = value
        End Set
    End Property

    Public Sub New(ByVal Ventana As MainWindow)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Ventana = Ventana
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As RoutedEventArgs) Handles btnAceptar.Click
        If txtBxUsuario.Text = "kinal" And txtContraseña.Password = "kinal" Then
            Me.Ventana.menutelefonias.Visibility = Visibility.Visible
            Me.Ventana.menuacercade.Visibility = Visibility.Visible
            Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class
