Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class ModelTelefonoProveedores
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaTelefonoProveedores As ObservableCollection(Of TelefonoProveedor)
    Private _ElementoSeleccionado As TelefonoProveedor
    Private _Instancia As ModelTelefonoProveedores
    Private _Tipo As TipoMantenimiento
    Private _NumeroTelefono As Integer
    Private _Descripcion As String
    Private _ElementoProveedor As Proveedores
    Private _ListaProveedores As ObservableCollection(Of Proveedores)
    Private VentanaAgregarModificar As AgregarModificarTelefonoProveedor

    Public Property ListaTelefonoProveedores As ObservableCollection(Of TelefonoProveedor)
        Get
            Return _ListaTelefonoProveedores
        End Get
        Set(value As ObservableCollection(Of TelefonoProveedor))
            _ListaTelefonoProveedores = value
            Notificar("ListaTelefonoProveedores")
        End Set
    End Property

    Public Property ElementoSeleccionado As TelefonoProveedor
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As TelefonoProveedor)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelTelefonoProveedores
        Get
            Return _Instancia
        End Get
        Set(value As ModelTelefonoProveedores)
            _Instancia = value
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

    Public Property NumeroTelefono As Integer
        Get
            Return _NumeroTelefono
        End Get
        Set(value As Integer)
            _NumeroTelefono = value
            Notificar("NumeroTelefono")
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
            Notificar("Descripcion")
        End Set
    End Property

    Public Property ElementoProveedor As Proveedores
        Get
            Return _ElementoProveedor
        End Get
        Set(value As Proveedores)
            _ElementoProveedor = value
            Notificar("ElementoProveedor")
        End Set
    End Property

    Public Property ListaProveedores As ObservableCollection(Of Proveedores)
        Get
            Return _ListaProveedores
        End Get
        Set(value As ObservableCollection(Of Proveedores))
            _ListaProveedores = value
            Notificar("ListaProvedores")
        End Set
    End Property

    Public Sub New()
        CargarDatos()
        Instancia = Me
    End Sub

    Public Sub Notificar(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub

    Public Sub CargarDatos()
        Dim TelefonoProveedores = From T In DBInventario.TelefonoProveedor
                                  Select T Order By T.CodigoProveedor

        ListaTelefonoProveedores = New ObservableCollection(Of TelefonoProveedor)
        For Each Elemento In TelefonoProveedores
            ListaTelefonoProveedores.Add(Elemento)
        Next

        Dim Proveedores = From C In DBInventario.Proveedores
                          Select C Order By C.RazonSocial
        ListaProveedores = New ObservableCollection(Of Proveedores)
        For Each Elemento In Proveedores
            ListaProveedores.Add(Elemento)
        Next
    End Sub

    Public Sub Eliminar()
        If ElementoSeleccionado IsNot Nothing Then
            Dim Respuesta As MsgBoxResult
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.NumeroTelefono & " ?",
                                MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Numero de Proveedor")

            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.TelefonoProveedor.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Telefono de Provedor")
            End Try
        Else
            MsgBox("Debe selecionar un elemento ", 64, "Eliminar Telefono de Provedor")
        End If
    End Sub

    Public Sub Agregar(ByVal Elemento As TelefonoProveedor)
        Try
            DBInventario.TelefonoProveedor.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Telefono Proveedor.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As TelefonoProveedor)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Telefono Proveedor")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute

        If Parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf Parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarTelefonoProveedor(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf Parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New TelefonoProveedor With {.CodigoProveedor = ElementoProveedor.CodigoProveedor, .Descripcion = Descripcion, .NumeroTelefono = NumeroTelefono})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Proveedores = ElementoProveedor
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.NumeroTelefono = NumeroTelefono
                    Modificar(ElementoSeleccionado)
                    CargarDatos()
                    VentanaAgregarModificar.Close()
            End Select
            VentanaAgregarModificar.Close()

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarTelefonoProveedor(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion
                ElementoProveedor = ElementoSeleccionado.Proveedores
                NumeroTelefono = ElementoSeleccionado.NumeroTelefono

                VentanaAgregarModificar.ShowDialog()

            Else
                MsgBox("Debe selecionar un elemento ", 64, "Modificar Numero Proveedor")
            End If
        ElseIf Parametro.Equals("Cancelar") Then
            VentanaAgregarModificar.Close()
        ElseIf Parametro.Equals("Reporte") Then

        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
