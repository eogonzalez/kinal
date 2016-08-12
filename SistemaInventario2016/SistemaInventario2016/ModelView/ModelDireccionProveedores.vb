Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class ModelDireccionProveedores
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaDireccionProveedores As ObservableCollection(Of DireccionProveedor)
    Private _ElementoSeleccionado As DireccionProveedor
    Private _Instancia As ModelDireccionProveedores
    Private _Tipo As TipoMantenimiento
    Private _Direccion As String
    Private _Descripcion As String
    Private _ElementoProveedor As Proveedores
    Private _ListaProveedores As ObservableCollection(Of Proveedores)
    Private VentanaAgregarModificar As AgregarModificarDireccionProveedor

    Public Property ListaDireccionProveedores As ObservableCollection(Of DireccionProveedor)
        Get
            Return _ListaDireccionProveedores
        End Get
        Set(value As ObservableCollection(Of DireccionProveedor))
            _ListaDireccionProveedores = value
            Notificar("ListaDireccionProveedores")
        End Set
    End Property

    Public Property ElementoSeleccionado As DireccionProveedor
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As DireccionProveedor)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelDireccionProveedores
        Get
            Return _Instancia
        End Get
        Set(value As ModelDireccionProveedores)
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

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
            Notificar("Direccion")
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
            Notificar("ListaProveedores")
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
        Dim DireccionProveedores = From C In DBInventario.DireccionProveedor
                                   Select C Order By C.CodigoProveedor
        ListaDireccionProveedores = New ObservableCollection(Of DireccionProveedor)
        For Each Elemento In DireccionProveedores
            ListaDireccionProveedores.Add(Elemento)
        Next

        Dim Proveedores = From A In DBInventario.Proveedores
                          Select A Order By A.RazonSocial

        ListaProveedores = New ObservableCollection(Of Proveedores)
        For Each Elemento In Proveedores
            ListaProveedores.Add(Elemento)
        Next
    End Sub

    Public Sub Eliminar()
        If ElementoSeleccionado IsNot Nothing Then
            Dim Respuesta As MsgBoxResult
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.Direccion & " ?",
                                MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Direccion de Proveedor")

            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.DireccionProveedor.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Direccion de Proveedor")
            End Try
        Else
            MsgBox("Debe selecionar un elemento ", 64, "Eliminar Direccion de Proveedor")
        End If
    End Sub

    Public Sub Agregar(ByVal Elemento As DireccionProveedor)
        Try
            DBInventario.DireccionProveedor.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Direccion Proveedor.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As DireccionProveedor)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Direccion Proveedor")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute
        If Parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf Parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarDireccionProveedor(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf Parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New DireccionProveedor With {.CodigoProveedor = ElementoProveedor.CodigoProveedor, .Descripcion = Descripcion, .Direccion = Direccion})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Proveedores = ElementoProveedor
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.Direccion = Direccion
                    Modificar(ElementoSeleccionado)
                    CargarDatos()
                    VentanaAgregarModificar.Close()
            End Select
            VentanaAgregarModificar.Close()

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarDireccionProveedor(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion
                ElementoProveedor = ElementoSeleccionado.Proveedores
                Direccion = ElementoSeleccionado.Direccion

                VentanaAgregarModificar.ShowDialog()

            Else
                MsgBox("Debe selecionar un elemento ", 64, "Modificar Direccion Proveedor")
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
