Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class ModelProveedores
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        Agregar
        Modificar
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaProveedores As ObservableCollection(Of Proveedores)
    Private _ElementoSeleccionado As Proveedores
    Private VentanaAgregarModificar As AgregarModificarProveedor
    Private _Tipo As TipoMantenimiento
    Private _Instancia As ModelProveedores
    Private _Nit As String
    Private _RazonSocial As String
    Private _PaginaWeb As String
    Private _ContactoPrincipal As String

    Public Property ContactoPrincipal As String
        Get
            Return _ContactoPrincipal
        End Get
        Set(value As String)
            _ContactoPrincipal = value
            Notificar("ContactoPrincipal")
        End Set
    End Property
    Public Property PaginaWeb As String
        Get
            Return _PaginaWeb
        End Get
        Set(value As String)
            _PaginaWeb = value
            Notificar("PaginaWeb")
        End Set
    End Property

    Public Property RazonSocial As String
        Get
            Return _RazonSocial
        End Get
        Set(value As String)
            _RazonSocial = value
            Notificar("RazonSocial")
        End Set
    End Property

    Public Property Nit As String
        Get
            Return _Nit
        End Get
        Set(value As String)
            _Nit = value
            Notificar("Nit")
        End Set
    End Property

    Public Property Instancia As ModelProveedores
        Get
            Return _Instancia
        End Get
        Set(value As ModelProveedores)
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

    Public Property ListaProveedores As ObservableCollection(Of Proveedores)
        Get
            Return _ListaProveedores
        End Get
        Set(value As ObservableCollection(Of Proveedores))
            _ListaProveedores = value
            Notificar("ListaProveedores")
        End Set
    End Property

    Public Property ElementoSeleccionado As Proveedores
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As Proveedores)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionando")
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
        Dim Proveedores = From T In DBInventario.Proveedores Select T Order By T.CodigoProveedor

        ListaProveedores = New ObservableCollection(Of Proveedores)
        For Each Elemento In Proveedores
            ListaProveedores.Add(Elemento)
        Next
    End Sub

    Public Sub Eliminar()
        Dim respuesta As MsgBoxResult

        If ElementoSeleccionado IsNot Nothing Then
            respuesta = MsgBox("Esta seguro que desea eliminar el registro" & ElementoSeleccionado.CodigoProveedor & "?",
                           MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Proveedor")

            Try
                If respuesta = 6 Then
                    DBInventario.Proveedores.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Proveedor")
            End Try
        Else
            MsgBox("Debe seleccionar un elemento", 64, "Eliminar Proveedor")
        End If
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If parameter.Equals("Eliminar") Then
            Eliminar()
        ElseIf parameter.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarProveedor(Instancia)
            Tipo = TipoMantenimiento.Agregar
            VentanaAgregarModificar.ShowDialog()
        ElseIf parameter.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.Agregar
                    Agregar(New Proveedores With {.NIT = Nit, .RazonSocial = RazonSocial, .PaginaWeb = PaginaWeb _
                                                    , .ContactoPrincipal = ContactoPrincipal})

                    VentanaAgregarModificar.Close()
                    Nit = Nothing
                    RazonSocial = Nothing
                    PaginaWeb = Nothing
                    ContactoPrincipal = Nothing
            End Select
        End If

    End Sub

    Public Sub Agregar(ByVal Elemento As Proveedores)
        Try
            DBInventario.Proveedores.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Proveedor")
        End Try
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
