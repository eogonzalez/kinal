Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class ModelProductos
    Implements INotifyPropertyChanged, ICommand
    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum
    Private _Tipo As TipoMantenimiento
    Private DBInventarios As New InventarioContext
    Private VentanaAgregarModificarProducto As AgregarModificarProducto
    Private _Instancia As ModelProductos
    Private _ListaProductos As ObservableCollection(Of Productos)
    Private _ListaCategorias As ObservableCollection(Of Categorias)
    Private _ListaTipoEmpaque As ObservableCollection(Of TipoEmpaques)
    Private _Descripcion As String
    Private _ElementoSeleccionado As Productos
    Private _ElementoCategoria As Categorias
    Private _ElementoTipoEmpaque As TipoEmpaques
    Private _PrecioUnitario As Double = 0.00
    Private _PrecioPorDocena As Double = 0.00
    Private _PrecioPorMayor As Double = 0.00
    Private _Imagen As String = "Default.png"
    Private _DesactivarPrecioUnitario As Boolean = True
    Private _DesactivarPrecioDocena As Boolean = True
    Private _DesactivarPrecioPorMayor As Boolean = True

    Public Property Tipo As TipoMantenimiento
        Get
            Return _Tipo
        End Get
        Set(value As TipoMantenimiento)
            _Tipo = value
        End Set
    End Property

    Public Property ElementoSeleccionado As Productos
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As Productos)
            _ElementoSeleccionado = value
            NotificarCambio("ElementoSeleccionado")
        End Set
    End Property

    Public Property DesactivarPrecioUnitario As Boolean
        Get
            Return _DesactivarPrecioUnitario
        End Get
        Set(value As Boolean)
            _DesactivarPrecioUnitario = value
            NotificarCambio("DesactivarPrecioUnitario")
        End Set
    End Property

    Public Property DesactivarPrecioDocena As Boolean
        Get
            Return _DesactivarPrecioDocena
        End Get
        Set(value As Boolean)
            _DesactivarPrecioDocena = value
            NotificarCambio("DesactivarPrecioDocena")
        End Set
    End Property

    Public Property DesactivarPrecioPorMayor As Boolean
        Get
            Return _DesactivarPrecioPorMayor
        End Get
        Set(value As Boolean)
            _DesactivarPrecioPorMayor = value
            NotificarCambio("DesactivarPrecioPorMayor")
        End Set
    End Property

    Public Property Instancia As ModelProductos
        Get
            Return _Instancia
        End Get
        Set(value As ModelProductos)
            _Instancia = value
        End Set
    End Property

    Public Property Imagen As String
        Get
            Return _Imagen
        End Get
        Set(value As String)
            _Imagen = value
            NotificarCambio("Imagen")
        End Set
    End Property

    Public Property PrecioPorMayor As Double
        Get
            Return _PrecioPorMayor
        End Get
        Set(value As Double)
            _PrecioPorMayor = value
            NotificarCambio("PrecioPorMayor")
        End Set
    End Property

    Public Property PrecioPorDocena As Double
        Get
            Return _PrecioPorDocena
        End Get
        Set(value As Double)
            _PrecioPorDocena = value
            NotificarCambio("PrecioPorDocena")
        End Set
    End Property

    Public Property PrecioUnitario As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(value As Double)
            _PrecioUnitario = value
        End Set
    End Property

    Public Property ElementoTipoEmpaque As TipoEmpaques
        Get
            Return _ElementoTipoEmpaque
        End Get
        Set(value As TipoEmpaques)
            _ElementoTipoEmpaque = value
            NotificarCambio("ElementoTipoEmpaque")
        End Set
    End Property

    Public Property ElementoCategoria As Categorias
        Get
            Return _ElementoCategoria
        End Get
        Set(value As Categorias)
            _ElementoCategoria = value
            NotificarCambio("ElementoCategoria")
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
            NotificarCambio("Descripcion")
        End Set
    End Property

    Public Property ListaCategorias As ObservableCollection(Of Categorias)
        Get
            Return _ListaCategorias
        End Get
        Set(value As ObservableCollection(Of Categorias))
            _ListaCategorias = value
            NotificarCambio("ListaCategorias")
        End Set
    End Property

    Public Property ListaTipoEmpaque As ObservableCollection(Of TipoEmpaques)
        Get
            Return _ListaTipoEmpaque
        End Get
        Set(value As ObservableCollection(Of TipoEmpaques))
            _ListaTipoEmpaque = value
            NotificarCambio("ListaTipoEmpaque")
        End Set
    End Property

    Public Property ListaProductos As ObservableCollection(Of Productos)
        Get
            Return _ListaProductos
        End Get
        Set(value As ObservableCollection(Of Productos))
            _ListaProductos = value
            NotificarCambio("ListaProductos")
        End Set
    End Property

    Public Sub New()
        CargarDatos()
        Instancia = Me
    End Sub

    Public Sub CargarDatos()
        Dim Productos = From P In DBInventarios.Productos Select P Order By P.Descripcion
        ListaProductos = New ObservableCollection(Of Productos)
        For Each Elemento As Productos In Productos
            ListaProductos.Add(Elemento)
        Next
        Dim Categorias = From C In DBInventarios.Categorias Select C Order By C.Descripcion
        ListaCategorias = New ObservableCollection(Of Categorias)
        For Each Elemento In Categorias
            ListaCategorias.Add(Elemento)
        Next
        Dim TipoEmpaques = From T In DBInventarios.TipoEmpaques Select T Order By T.Descripcion
        ListaTipoEmpaque = New ObservableCollection(Of TipoEmpaques)
        For Each Elemento In TipoEmpaques
            ListaTipoEmpaque.Add(Elemento)
        Next
    End Sub

    Public Sub NotificarCambio(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute
        If Parametro.Equals("Agregar") Then
            VentanaAgregarModificarProducto = New AgregarModificarProducto(Instancia)
            VentanaAgregarModificarProducto.ShowDialog()
            Tipo = TipoMantenimiento.AGREGAR
        ElseIf Parametro.Equals("Guardar") Then
            If Tipo = TipoMantenimiento.AGREGAR Then
                DBInventarios.Productos.Add(New Productos With {.Descripcion = Descripcion, .CodigoCategoria = ElementoCategoria.CodigoCategoria, .CodigoTipoEmpaque = ElementoTipoEmpaque.CodigoTipoEmpaque, .Imagen = Imagen, .PrecioUnitario = PrecioUnitario, .PrecioDocena = PrecioPorDocena, .PrecioMayor = PrecioPorMayor, .Existencia = 0})
                DBInventarios.SaveChanges()
                CargarDatos()
                VentanaAgregarModificarProducto.Close()
            ElseIf Tipo = TipoMantenimiento.MODIFICAR Then
                Try
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.Categorias = ElementoCategoria
                    ElementoSeleccionado.TipoEmpaques = ElementoTipoEmpaque
                    ElementoSeleccionado.PrecioDocena = PrecioPorDocena
                    ElementoSeleccionado.PrecioMayor = PrecioPorMayor
                    ElementoSeleccionado.Imagen = Imagen
                    DBInventarios.Entry(ElementoSeleccionado).State = System.Data.Entity.EntityState.Modified
                    DBInventarios.SaveChanges()
                    CargarDatos()
                    VentanaAgregarModificarProducto.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Modificar Categoria")
                End Try
            End If

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                Tipo = TipoMantenimiento.MODIFICAR
                DesactivarPrecioDocena = False
                DesactivarPrecioPorMayor = False
                VentanaAgregarModificarProducto = New AgregarModificarProducto(Instancia)
                Descripcion = ElementoSeleccionado.Descripcion
                Imagen = ElementoSeleccionado.Imagen
                ElementoCategoria = ElementoSeleccionado.Categorias
                ElementoTipoEmpaque = ElementoSeleccionado.TipoEmpaques
                PrecioUnitario = ElementoSeleccionado.PrecioUnitario
                PrecioPorDocena = ElementoSeleccionado.PrecioDocena
                PrecioPorMayor = ElementoSeleccionado.PrecioMayor
                VentanaAgregarModificarProducto.ShowDialog()
            Else
                MsgBox("Debe seleccionar un elemento", MsgBoxStyle.Critical)
            End If

        ElseIf Parametro.Equals("Reporte") Then
            Dim ReporteProductos As New ReporteProductos
            ReporteProductos.ShowDialog()
        End If

    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
