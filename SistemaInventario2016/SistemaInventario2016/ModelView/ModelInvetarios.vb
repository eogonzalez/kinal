Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class ModelInvetarios
    Implements INotifyPropertyChanged, ICommand
    Enum _TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum
    Private DBInventario As New InventarioContext
    Private _ListaInventarios As Collection(Of Inventarios)
    Private _ElementoSeleccionado As Inventarios
    Private _Instancia As ModelInvetarios
    Private _Tipo As _TipoMantenimiento
    Private _Salidas As Integer
    Private _Entradas As Integer
    Private _Fecha As Date
    Private _Precio As Double
    Private _ElementoTipoRegistro As TipoRegistros
    Private _ElementoProducto As Productos
    Private VentanaAgregarModificar As AgregarModificarInventario
    Private _ListaTipoRegistros As Collection(Of TipoRegistros)
    Private _ListaProductos As Collection(Of Productos)
    Private _ListaDetalleProductos As Collection(Of Productos)

#Region "Propiedades"
    Public Property ListaDetalleProductos As Collection(Of Productos)
        Get
            Return _ListaDetalleProductos
        End Get
        Set(value As Collection(Of Productos))
            _ListaDetalleProductos = value
            Notificar("ListaDetalleProductos")
        End Set
    End Property
    Public Property ElementoProducto As Productos
        Get
            Return _ElementoProducto
        End Get
        Set(value As Productos)
            _ElementoProducto = value
            Notificar("ElementoProducto")
        End Set
    End Property
    Public Property ElementoTipoRegistro As TipoRegistros
        Get
            Return _ElementoTipoRegistro
        End Get
        Set(value As TipoRegistros)
            _ElementoTipoRegistro = value
            Notificar("ElementoTipoRegistro")
        End Set
    End Property
    Public Property Tipo As _TipoMantenimiento
        Get
            Return _Tipo
        End Get
        Set(value As _TipoMantenimiento)
            _Tipo = value
        End Set
    End Property
    Public Property ElementoSeleccionado As Inventarios
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As Inventarios)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
            CargarDetalles()
        End Set
    End Property
    Public Property Instancia As ModelInvetarios
        Get
            Return _Instancia
        End Get
        Set(value As ModelInvetarios)
            _Instancia = value
        End Set
    End Property
    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
            Notificar("Fecha")
        End Set
    End Property
    Public Property Precio As Double
        Get
            Return _Precio
        End Get
        Set(value As Double)
            _Precio = value
            Notificar("Precio")
        End Set
    End Property
    Public Property Entradas As Double
        Get
            Return _Entradas
        End Get
        Set(value As Double)
            _Entradas = value
            Notificar("Entradas")
        End Set
    End Property
    Public Property Salidas As Double
        Get
            Return _Salidas
        End Get
        Set(value As Double)
            _Salidas = value
            Notificar("Salidas")
        End Set
    End Property
    Public Property ListaTipoRegistros As Collection(Of TipoRegistros)
        Get
            Return _ListaTipoRegistros
        End Get
        Set(value As Collection(Of TipoRegistros))
            _ListaTipoRegistros = value
            Notificar("ListaTipoRegistros")
        End Set
    End Property
    Public Property ListaProductos As Collection(Of Productos)
        Get
            Return _ListaProductos
        End Get
        Set(value As Collection(Of Productos))
            _ListaProductos = value
            Notificar("ListaProductos")
        End Set
    End Property
    Public Property ListaInventarios As Collection(Of Inventarios)
        Get
            Return _ListaInventarios
        End Get
        Set(value As Collection(Of Inventarios))
            _ListaInventarios = value
            Notificar("ListaInventarios")
        End Set
    End Property
#End Region
    Public Sub New()
        CargarDatos()
        Instancia = Me
    End Sub
#Region "Procedimientos"
    Public Sub CargarDetalles()
        Dim Producto = From P In DBInventario.Productos Select P Where P.CodigoProducto = ElementoSeleccionado.CodigoProducto
        ListaDetalleProductos = New ObservableCollection(Of Productos)
        For Each Elemento In Producto
            ListaDetalleProductos.Add(Elemento)
        Next
    End Sub
    Public Sub Eliminar()
        Dim Respuesta As MsgBoxResult
        If ElementoSeleccionado IsNot Nothing Then
            Respuesta = MsgBox("¿Esta seguro de eliminar el registro " & ElementoSeleccionado.Correlativo & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                               " Eliminar Inventarios")
            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.Inventarios.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 48, "Eliminar Inventarios")
            End Try
        Else
            MsgBox("Debe seleccionar un elemento", 64, "Eliminar Inventarios")
        End If
    End Sub
    Public Sub Agregar(ByVal Elemento As Inventarios)
        Try
            DBInventario.Inventarios.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Inventarios")
        End Try
    End Sub
    Public Sub Modificar(ByVal Elemento As Inventarios)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Inventarios")
        End Try
    End Sub
    Public Sub Notificar(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub
    Public Sub CargarDatos()
        Dim Inventarios = From I In DBInventario.Inventarios Select I Order By I.Correlativo
        ListaInventarios = New ObservableCollection(Of Inventarios)
        For Each Elemento As Inventarios In Inventarios
            ListaInventarios.Add(Elemento)
        Next
        Dim TipoRegistros = From T In DBInventario.TipoRegistros Select T Order By T.CodigoTipoRegistro
        ListaTipoRegistros = New ObservableCollection(Of TipoRegistros)
        For Each Elemento In TipoRegistros
            ListaTipoRegistros.Add(Elemento)
        Next
        Dim Productos = From P In DBInventario.Productos Select P Order By P.CodigoProducto
        ListaProductos = New ObservableCollection(Of Productos)
        For Each Elemento In Productos
            ListaProductos.Add(Elemento)
        Next
    End Sub
#End Region
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If parameter.Equals("Eliminar") Then
            Eliminar()
        ElseIf parameter.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarInventario(Instancia)
            VentanaAgregarModificar.ShowDialog()
            Tipo = _TipoMantenimiento.AGREGAR
        ElseIf parameter.Equals("Guardar") Then
            If Tipo = _TipoMantenimiento.AGREGAR Then
                DBInventario.Inventarios.Add(New Inventarios With {.CodigoTipoRegistro = ElementoTipoRegistro.CodigoTipoRegistro, .CodigoProducto = ElementoProducto.CodigoProducto, .Salidas = Salidas, .Entradas = Entradas, .Precio = Precio, .Fecha = Fecha})
                DBInventario.SaveChanges()
                CargarDatos()
                VentanaAgregarModificar.Close()
            ElseIf Tipo = _TipoMantenimiento.MODIFICAR Then
                Try
                    ElementoSeleccionado.Productos = ElementoProducto
                    ElementoSeleccionado.TipoRegistros = ElementoTipoRegistro
                    ElementoSeleccionado.Salidas = Salidas
                    ElementoSeleccionado.Entradas = Entradas
                    ElementoSeleccionado.Precio = Precio
                    ElementoSeleccionado.Fecha = Fecha
                    DBInventario.Entry(ElementoSeleccionado).State = System.Data.Entity.EntityState.Modified
                    DBInventario.SaveChanges()
                    CargarDatos()
                    VentanaAgregarModificar.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Modificar Inventarios")
                End Try
            End If
        ElseIf parameter.Equals("Cancelar") Then
            VentanaAgregarModificar.Close()
        ElseIf parameter.Equals("Modificar") Then
            Tipo = _TipoMantenimiento.MODIFICAR
            VentanaAgregarModificar = New AgregarModificarInventario(Instancia)
            ElementoProducto = ElementoSeleccionado.Productos
            ElementoTipoRegistro = ElementoSeleccionado.TipoRegistros
            Salidas = ElementoSeleccionado.Salidas
            Entradas = ElementoSeleccionado.Entradas
            Precio = ElementoSeleccionado.Precio
            Fecha = ElementoSeleccionado.Fecha
            VentanaAgregarModificar.ShowDialog()
        ElseIf parameter.Equals("Reporte") Then

        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
