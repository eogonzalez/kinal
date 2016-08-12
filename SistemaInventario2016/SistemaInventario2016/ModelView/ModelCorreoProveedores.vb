Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class ModelCorreoProveedores
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaCorreoProveedores As ObservableCollection(Of EmailProveedor)
    Private _ElementoSeleccionado As EmailProveedor
    Private _Instancia As ModelCorreoProveedores
    Private _Tipo As TipoMantenimiento
    Private _Email As String
    Private _Descripcion As String
    Private _ElementoProveedor As Proveedores
    Private _ListaProveedores As ObservableCollection(Of Proveedores)
    Private VentanaAgregarModificar As AgregarModificarCorreoProveedor

    Public Property ListaCorreoProveedores As ObservableCollection(Of EmailProveedor)
        Get
            Return _ListaCorreoProveedores
        End Get
        Set(value As ObservableCollection(Of EmailProveedor))
            _ListaCorreoProveedores = value
            Notificar("ListaCorreoProveedores")
        End Set
    End Property

    Public Property ElementoSeleccionado As EmailProveedor
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As EmailProveedor)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelCorreoProveedores
        Get
            Return _Instancia
        End Get
        Set(value As ModelCorreoProveedores)
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

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
            Notificar("Email")
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
        Dim CorreoProveedores = From C In DBInventario.EmailProveedor
                                Select C Order By C.CodigoProveedor
        ListaCorreoProveedores = New ObservableCollection(Of EmailProveedor)
        For Each Elemento In CorreoProveedores
            ListaCorreoProveedores.Add(Elemento)
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
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.Email & " ?",
                                MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Correo de Proveedor")

            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.EmailProveedor.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Correo de Proveedor")
            End Try
        Else
            MsgBox("Debe selecionar un elemento ", 64, "Eliminar Correo de Proveedor")
        End If
    End Sub

    Public Sub Agregar(ByVal Elemento As EmailProveedor)
        Try
            DBInventario.EmailProveedor.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Correo Proveedor.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As EmailProveedor)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Correo Proveedor")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute
        If Parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf Parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarCorreoProveedor(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf Parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New EmailProveedor With {.CodigoProveedor = ElementoProveedor.CodigoProveedor, .Descripcion = Descripcion, .Email = Email})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Proveedores = ElementoProveedor
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.Email = Email
                    Modificar(ElementoSeleccionado)
                    CargarDatos()
                    VentanaAgregarModificar.Close()
            End Select
            VentanaAgregarModificar.Close()

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarCorreoProveedor(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion
                ElementoProveedor = ElementoSeleccionado.Proveedores
                Email = ElementoSeleccionado.Email

                VentanaAgregarModificar.ShowDialog()

            Else
                MsgBox("Debe selecionar un elemento ", 64, "Modificar Correo Proveedor")
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
