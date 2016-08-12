Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class ModelCompras
    Implements INotifyPropertyChanged, ICommand
    Enum _TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum
    Private DBInventario As New InventarioContext
    Private _ListaCompras As ObservableCollection(Of Compras)
    Private _ElementoSeleccionado As Compras
    Private _ListaDetalles As Collection(Of DetalleCompra)
    Private _Instancia As ModelCompras
    Private _Tipo As _TipoMantenimiento
    Private _NumeroDocumento As Integer
    Private _Fecha As Date
    Private _TotalCompra As Double
    Private _ElementoProveedor As Proveedores
    Private _ListaProveedor As Collection(Of Proveedores)
    Private VentanaAgregarModificar As AgregarModificarCompras
#Region "Propiedades"
    Public Property ElementoSeleccionado As Compras
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As Compras)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
            CargarDatosDetalleCompras()
        End Set
    End Property
    Public Property ListaProveedor As Collection(Of Proveedores)
        Get
            Return _ListaProveedor
        End Get
        Set(value As Collection(Of Proveedores))
            _ListaProveedor = value
            Notificar("ListaProveedor")
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
    Public Property TotalCompra As Double
        Get
            Return _TotalCompra
        End Get
        Set(value As Double)
            _TotalCompra = value
            Notificar("TotalCompra")
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
    Public Property NumeroDocumento As Integer
        Get
            Return _NumeroDocumento
        End Get
        Set(value As Integer)
            _NumeroDocumento = value
            Notificar("NumeroDocumento")
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
    Public Property Instancia As ModelCompras
        Get
            Return _Instancia
        End Get
        Set(value As ModelCompras)
            _Instancia = value
        End Set
    End Property
    Public Property ListaCompras As ObservableCollection(Of Compras)
        Get
            Return _ListaCompras
        End Get
        Set(value As ObservableCollection(Of Compras))
            _ListaCompras = value
            Notificar("ListaCompras")
        End Set
    End Property
    Public Property ListaDetalle As Collection(Of DetalleCompra)
        Get
            Return _ListaDetalles
        End Get
        Set(value As Collection(Of DetalleCompra))
            _ListaDetalles = value
            Notificar("ListaDetalle")
        End Set
    End Property
#End Region
    Public Sub New()
        CargarDatos()
        Instancia = Me
    End Sub
#Region "Procedimientos"
    Public Sub Eliminar()
        Dim Respuesta As MsgBoxResult
        If ElementoSeleccionado IsNot Nothing Then
            Respuesta = MsgBox("¿Esta seguro de eliminar el registro " & ElementoSeleccionado.NumeroDocumento & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                                   " Eliminar compra")
            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.Compras.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 48, "Eliminar Compras")
            End Try
        Else
            MsgBox("Debe seleccionar un elemento", 64, "Eliminar Compras")
        End If
    End Sub
    Public Sub Agregar(ByVal Elemento As Compras)
        Try
            DBInventario.Compras.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Compras")
        End Try
    End Sub
    Public Sub Modificar(ByVal Elemento As Compras)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Compras")
        End Try
    End Sub
    Public Sub CargarDatosDetalleCompras()
        Dim Datos = From D In DBInventario.DetalleCompra Select D Where D.NumeroDocumento = ElementoSeleccionado.NumeroDocumento
        ListaDetalle = New ObservableCollection(Of DetalleCompra)
        For Each Elemento In Datos
            ListaDetalle.Add(Elemento)
        Next
    End Sub
    Public Sub Notificar(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub
    Public Sub CargarDatos()
        Dim Compras = From C In DBInventario.Compras Select C Order By C.NumeroDocumento
        ListaCompras = New ObservableCollection(Of Compras)
        For Each Elemento As Compras In Compras
            ListaCompras.Add(Elemento)
        Next
        Dim Proveedores = From P In DBInventario.Proveedores Select P Order By P.CodigoProveedor
        ListaProveedor = New ObservableCollection(Of Proveedores)
        For Each Elemento In Proveedores
            ListaProveedor.Add(Elemento)
        Next
    End Sub
#End Region

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If parameter.Equals("Eliminar") Then
            Eliminar()
        ElseIf parameter.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarCompras(Instancia)
            Tipo = _TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()
        ElseIf parameter.Equals("Guardar") Then
            If Tipo = _TipoMantenimiento.AGREGAR Then
                DBInventario.Compras.Add(New Compras With {.NumeroDocumento = NumeroDocumento, .Fecha = Fecha, .CodigoProveedor = ElementoProveedor.CodigoProveedor, .TotalCompra = TotalCompra})
                DBInventario.SaveChanges()
                CargarDatos()
                VentanaAgregarModificar.Close()
            ElseIf Tipo = _TipoMantenimiento.MODIFICAR Then
                Try
                    ElementoSeleccionado.NumeroDocumento = NumeroDocumento
                    ElementoSeleccionado.Fecha = Fecha
                    ElementoSeleccionado.Proveedores = ElementoProveedor
                    ElementoSeleccionado.TotalCompra = TotalCompra
                    DBInventario.Entry(ElementoSeleccionado).State = System.Data.Entity.EntityState.Modified
                    DBInventario.SaveChanges()
                    CargarDatos()
                    VentanaAgregarModificar.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Modificar Compras")
                End Try
            End If
        ElseIf parameter.Equals("Cancelar") Then
            VentanaAgregarModificar.Close()
        ElseIf parameter.Equals("Modificar") Then
            Tipo = _TipoMantenimiento.MODIFICAR
            VentanaAgregarModificar = New AgregarModificarCompras(Instancia)
            NumeroDocumento = ElementoSeleccionado.NumeroDocumento
            Fecha = ElementoSeleccionado.Fecha
            ElementoProveedor = ElementoSeleccionado.Proveedores
            TotalCompra = ElementoSeleccionado.TotalCompra
            VentanaAgregarModificar.ShowDialog()
        ElseIf parameter.Equals("Reporte") Then

        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class