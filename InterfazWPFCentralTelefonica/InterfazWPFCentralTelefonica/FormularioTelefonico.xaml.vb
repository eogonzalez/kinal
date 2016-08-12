Imports InterfazWPFCentralTelefonica
Imports Laboratorio_Eder_Gonzalez
Public Class FormularioTelefonico

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Compañia As String, ByVal Imagen As BitmapImage)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblCompañia.Content = Compañia
        imgCompania.Source = Imagen
        rbtLocal.IsChecked = True
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As RoutedEventArgs) Handles btnRegistrar.Click
        Dim MiLlamada As Llamada = Nothing

        If rbtLocal.IsChecked Then
            MiLlamada = New LlamadaLocal(txtNumeroOrigen.Text, txtNumeroDestino.Text, txtDuracion.Text, 1)
        ElseIf rbtDepto.IsChecked Then
            MiLlamada = New LlamadaDepartamental(txtNumeroOrigen.Text, txtNumeroDestino.Text, txtDuracion.Text, cmbFranja.Text)
        End If

        MiLlamada.Compania = lblCompañia.Content

        Module1.RegistroLlamada.Add(MiLlamada)

        Centralita.RegistrarLlamada(MiLlamada)

        If TypeOf (MiLlamada) Is LlamadaLocal Then
            MsgBox(DirectCast(MiLlamada, LlamadaLocal).ToString, 64, "Registro de llamada")
        ElseIf TypeOf (MiLlamada) Is LlamadaDepartamental Then
            MsgBox(DirectCast(MiLlamada, LlamadaDepartamental).ToString, 64, "Registro de llamada")
        End If

        LimpiarTextos()

    End Sub

    Public Sub LimpiarTextos()
        txtDuracion.Text = ""
        txtNumeroDestino.Text = ""
        txtNumeroOrigen.Text = ""
    End Sub

    Private Sub rbtLocal_Checked(sender As Object, e As RoutedEventArgs) Handles rbtLocal.Checked
        cmbFranja.IsEnabled = False
    End Sub

    Private Sub rbtDepto_Checked(sender As Object, e As RoutedEventArgs) Handles rbtDepto.Checked
        cmbFranja.IsEnabled = True
        cmbFranja.SelectedIndex = 0
    End Sub

End Class
