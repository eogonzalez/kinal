Imports ControlDeClases
Imports Microsoft.Win32

Class MainWindow

    Private Sub menuItemIniciarSesion_Click(sender As Object, e As RoutedEventArgs) Handles menuItemIniciarSesion.Click
        Dim modal = New FormularioInicioSesion(Me)
        modal.ShowDialog()
    End Sub

    Private Sub menuItemCerrar_Click(sender As Object, e As RoutedEventArgs) Handles menuItemCerrar.Click
        Close()
    End Sub

    Private Sub VentanaPrincipal_Loaded(sender As Object, e As RoutedEventArgs) Handles VentanaPrincipal.Loaded
        'If Not Module1.itemAcercade Then
        '    menutelefonias.Visibility = Visibility.Hidden
        'End If

        'If Not Module1.itemTelefonias Then
        '    menuacercade.Visibility = Visibility.Hidden
        'End If

        Module1.CambiarstatusMenu()

    End Sub

    Private Sub itemClaro_Click(sender As Object, e As RoutedEventArgs) Handles itemClaro.Click
        Dim logo As New BitmapImage
        logo.BeginInit()
        logo.UriSource = New Uri("../Recursos/claro.png", UriKind.RelativeOrAbsolute)
        logo.EndInit()
        Dim LlamadaClaro As New FormularioTelefonico("Claro", logo)

        LlamadaClaro.Show()

    End Sub

    Private Sub itemTigo_Click(sender As Object, e As RoutedEventArgs) Handles itemTigo.Click
        Dim logo As New BitmapImage
        logo.BeginInit()
        logo.UriSource = New Uri("../Recursos/tigo.png", UriKind.RelativeOrAbsolute)
        logo.EndInit()
        Dim LlamadaTigo As New FormularioTelefonico("Tigo", logo)
        LlamadaTigo.Show()
    End Sub

    Private Sub itemMovistar_Click(sender As Object, e As RoutedEventArgs) Handles itemMovistar.Click
        Dim logo As New BitmapImage
        logo.BeginInit()
        logo.UriSource = New Uri("../Recursos/movistar.png", UriKind.RelativeOrAbsolute)
        logo.EndInit()
        Dim LlamadaMovistar As New FormularioTelefonico("Movistar", logo)
        LlamadaMovistar.Show()
    End Sub

    Private Sub itemGenerarReporte_Click(sender As Object, e As RoutedEventArgs) Handles itemGenerarReporte.Click

        If Module1.RegistroLlamada.Count > 0 Then
            Dim GenerarReporte As New ManejadorDeExcel(3, "C:/Reporte/Reporte.xlsx", "Reporte", 1, 7, "ABCDEFG")
            GenerarReporte.GenerarReporteTelefonico(Module1.RegistroLlamada)
        Else
            MsgBox("No existe registros de llamadas", MsgBoxStyle.Critical, "Control de llamadas")
        End If
    End Sub

    Private Sub itemCargarReporte_Click(sender As Object, e As RoutedEventArgs) Handles itemCargarReporte.Click
        Dim OFDExcel = New OpenFileDialog()

        OFDExcel.ShowDialog()


        If OFDExcel.FileName.Length = 0 Then
            MsgBox("Debe seleccionar un archivo valido", 16, "Carga Archivo")
        Else
            Dim CargarReporte As New ManejadorDeExcel(2, 22, OFDExcel.FileName, "ReporteLlamadas")
            CargarReporte.CargarReporteTelefonico(Module1.RegistroLlamada)
            MsgBox("Registro realizado con exito", 64, "Cargar Archivo")
        End If
    End Sub

    Private Sub menuacercade_Click(sender As Object, e As RoutedEventArgs) Handles menuacercade.Click
        Dim Acercade = New FormularioAcercade
        Acercade.Show()

    End Sub
End Class
