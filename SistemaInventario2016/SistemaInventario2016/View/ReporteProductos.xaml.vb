Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports System.IO

Public Class ReporteProductos
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MostrarReporte()

    End Sub

    Public Sub MostrarReporte()
        Dim Documento As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Ruta As String = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..")) & "\Reportes\ReporteDeProductos.rpt"

        Documento.Load(Ruta)
        VistaProductos.ViewerCore.ReportSource = Documento


    End Sub
End Class
