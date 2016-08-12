Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class ModelTipoEmpaque
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaTipoEmpaques As ObservableCollection(Of TipoEmpaques)
    Private _ElementoSeleccionado As TipoEmpaques
    Private _Instancia As ModelTipoEmpaque
    Private _Tipo As TipoMantenimiento
    Private _Descripcion As String
    Private VentanaAgregarModificar As AgregarModificarTipoEmpaque

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
            Notificar("Descripcion")
        End Set
    End Property

    Public Property Tipo As TipoMantenimiento
        Get
            Return _Tipo
        End Get
        Set(value As TipoMantenimiento)
            _Tipo = value
        End Set
    End Property

    Public Property ListaTipoEmpaques As ObservableCollection(Of TipoEmpaques)
        Get
            Return _ListaTipoEmpaques
        End Get
        Set(value As ObservableCollection(Of TipoEmpaques))
            _ListaTipoEmpaques = value
            Notificar("ListaTipoEmpaques")
        End Set
    End Property

    Public Property ElementoSeleccionado As TipoEmpaques
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As TipoEmpaques)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelTipoEmpaque
        Get
            Return _Instancia
        End Get
        Set(value As ModelTipoEmpaque)
            _Instancia = value
        End Set
    End Property

    Public Sub New()
        CargarDatos()
        Instancia = Me
    End Sub

    Public Sub Notificar(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub

    Public Sub Eliminar()

        If ElementoSeleccionado IsNot Nothing Then
            Dim Respuesta As MsgBoxResult
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro" & ElementoSeleccionado.Descripcion & "?",
                               MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Tipo de Empaque")

            Try
                    If Respuesta = MsgBoxResult.Yes Then

                    DBInventario.TipoEmpaques.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()

                    End If
                Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Tipo de Empaque")
            End Try

            Else
            MsgBox("Debe seleccionar un elemento", 64, "Eliminar Tipo de Empaque")
        End If
    End Sub

    Public Sub CargarDatos()
        Dim TipoEmpaques = From T In DBInventario.TipoEmpaques
                           Select T Order By T.Descripcion

        ListaTipoEmpaques = New ObservableCollection(Of TipoEmpaques)
        For Each Elemento In TipoEmpaques
            ListaTipoEmpaques.Add(Elemento)
        Next
    End Sub

    Public Sub Agregar(ByVal Elemento As TipoEmpaques)
        Try
            DBInventario.TipoEmpaques.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Tipo de Empaque.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As TipoEmpaques)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Tipo de Empaque")
        End Try
    End Sub


    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(parametro As Object) Implements ICommand.Execute
        If parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarTipoEmpaque(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New TipoEmpaques With {.Descripcion = Descripcion})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Descripcion = Descripcion
                    Modificar(ElementoSeleccionado)

            End Select

            VentanaAgregarModificar.Close()
        ElseIf parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarTipoEmpaque(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion

                VentanaAgregarModificar.ShowDialog()
            Else
                MsgBox("Debe seleccionar un elemento", 64, "Modificar Tipo de Empaque")
            End If
        ElseIf parametro.Equals("Reporte") Then
            Dim ReporteTipoEmpaques As New ReporteTipoEmpaques
            ReporteTipoEmpaques.ShowDialog()

        ElseIf parametro.Equals("Cancelar") Then
            VentanaAgregarModificar.Close()
        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
