Imports Laboratorio_Eder_Gonzalez
Imports ControlDeClases
Imports System.Xml.Serialization
Imports System.IO
Public Class VentanaPrincipal
    Private _RegistroLlamada As New List(Of Llamada)

    Public Property RegistroLlamada As List(Of Llamada)
        Get
            Return _RegistroLlamada
        End Get
        Set(value As List(Of Llamada))
            _RegistroLlamada = value
        End Set
    End Property

    Private Sub VentanaPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Lector As New StreamReader("RegistroLlamadas")
        'Dim Serializacion As New XmlSerializer(GetType(List(Of Llamada)))
        'RegistroLlamada = Serializacion.Deserialize(Lector)
        'Lector.Close()
    End Sub

    Private Sub VentanaPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Try

        '    Dim Serializacion As New XmlSerializer(GetType(List(Of Llamada)))
        '    Dim Escritor As New StreamWriter("RegistroLlamadas")
        '    Serializacion.Serialize(Escritor, RegistroLlamada)
        '    Escritor.Close()

        'Catch ex As Exception
        '    MsgBox("Error al serializar la lista", 16, "Registro de llamadas")
        'End Try
    End Sub

    Private Sub IniciarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementoIniciarSesion.Click

        'Dim IniciarSesion As New FormularioInicioSesion
        'IniciarSesion.MdiParent = Me
        'IniciarSesion.Show()

        'FormularioInicioSesion.getInstancia.MdiParent = Me
        'FormularioInicioSesion.getInstancia.Show()

        My.Forms.FormularioInicioSesion.MdiParent = Me
        My.Forms.FormularioInicioSesion.Show()


    End Sub

    Private Sub ElementoAutor_Click(sender As Object, e As EventArgs) Handles ElementoAutor.Click
        My.Forms.FormularioAcercaDe.MdiParent = Me
        My.Forms.FormularioAcercaDe.Show()
    End Sub

    Private Sub ElementoCerrar_Click(sender As Object, e As EventArgs) Handles ElementoCerrar.Click
        MenuAcercaDe.Visible = False
        MenuTelefonias.Visible = False
    End Sub

    Private Sub ElementoClaro_Click(sender As Object, e As EventArgs) Handles ElementoClaro.Click
        Dim LlamadaClaro As New FormularioTelefonico("Claro", "claro.png")
        LlamadaClaro.MdiParent = Me
        LlamadaClaro.Show()
    End Sub

    Private Sub ElementoTigo_Click(sender As Object, e As EventArgs) Handles ElementoTigo.Click
        Dim LlamadaTigo As New FormularioTelefonico("Tipo", "tigo.png")
        LlamadaTigo.MdiParent = Me
        LlamadaTigo.Show()
    End Sub

    Private Sub ElementoMovistar_Click(sender As Object, e As EventArgs) Handles ElementoMovistar.Click
        Dim LlamadaMovistar As New FormularioTelefonico("Movistar", "movistar.png")
        LlamadaMovistar.MdiParent = Me
        LlamadaMovistar.Show()
    End Sub

    Private Sub ElementoGenerarReporte_Click(sender As Object, e As EventArgs) Handles ElementoGenerarReporte.Click
        If Me.RegistroLlamada.Count > 0 Then
            Dim GenerarReporte As New ManejadorDeExcel(3, "C:/Reporte/Reporte.xlsx", "Reporte", 1, 7, "ABCDEFG")
            GenerarReporte.GenerarReporteTelefonico(Me.RegistroLlamada)
        Else
            MsgBox("No existe registros de llamadas", MsgBoxStyle.Critical, "Control de llamadas")
        End If

    End Sub

    Private Sub ElementoCargarReporte_Click(sender As Object, e As EventArgs) Handles ElementoCargarReporte.Click
        Me.OFDExcel.ShowDialog()

        If Me.OFDExcel.FileName.Length = 0 Then
            MsgBox("Debe seleccionar un archivo valido", 16, "Carga Archivo")
        Else
            Dim CargarReporte As New ManejadorDeExcel(2, 22, Me.OFDExcel.FileName, "ReporteLlamadas")
            CargarReporte.CargarReporteTelefonico(Me.RegistroLlamada)
            MsgBox("Registro realizado con exito", 64, "Cargar Archivo")
        End If

    End Sub
End Class
