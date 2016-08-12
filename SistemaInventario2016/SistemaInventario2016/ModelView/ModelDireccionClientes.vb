Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class ModelDireccionClientes
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaDireccionClientes As ObservableCollection(Of DireccionClientes)
    Private _ElementoSeleccionado As DireccionClientes
    Private _Instancia As ModelDireccionClientes
    Private _Tipo As TipoMantenimiento
    Private _Direccion As String
    Private _Descripcion As String
    Private _ElementoCliente As Clientes
    Private _ListaClientes As ObservableCollection(Of Clientes)
    Private VentanaAgregarModificar As AgregarModificarDireccionClientes

    Public Property ListaDireccionClientes As ObservableCollection(Of DireccionClientes)
        Get
            Return _ListaDireccionClientes
        End Get
        Set(value As ObservableCollection(Of DireccionClientes))
            _ListaDireccionClientes = value
            Notificar("ListaDireccionClientes")
        End Set
    End Property

    Public Property ElementoSeleccionado As DireccionClientes
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As DireccionClientes)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelDireccionClientes
        Get
            Return _Instancia
        End Get
        Set(value As ModelDireccionClientes)
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

    Public Property ElementoCliente As Clientes
        Get
            Return _ElementoCliente
        End Get
        Set(value As Clientes)
            _ElementoCliente = value
            Notificar("ElementoCliente")
        End Set
    End Property

    Public Property ListaClientes As ObservableCollection(Of Clientes)
        Get
            Return _ListaClientes
        End Get
        Set(value As ObservableCollection(Of Clientes))
            _ListaClientes = value
            Notificar("ListaClientes")
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
        Dim DireccionClientes = From C In DBInventario.DireccionClientes
                                Select C Order By C.CodigoCliente
        ListaDireccionClientes = New ObservableCollection(Of DireccionClientes)
        For Each Elemento In DireccionClientes
            ListaDireccionClientes.Add(Elemento)
        Next

        Dim Clientes = From A In DBInventario.Clientes
                       Select A Order By A.Nombre

        ListaClientes = New ObservableCollection(Of Clientes)
        For Each Elemento In Clientes
            ListaClientes.Add(Elemento)
        Next
    End Sub

    Public Sub Eliminar()
        If ElementoSeleccionado IsNot Nothing Then
            Dim Respuesta As MsgBoxResult
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.Direccion & " ?",
                                MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Direccion de Cliente")

            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.DireccionClientes.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Direccion de Cliente")
            End Try
        Else
            MsgBox("Debe selecionar un elemento ", 64, "Eliminar Direccion de Cliente")
        End If
    End Sub

    Public Sub Agregar(ByVal Elemento As DireccionClientes)
        Try
            DBInventario.DireccionClientes.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Direccion Cliente.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As DireccionClientes)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Direccion Cliente")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute
        If Parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf Parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarDireccionClientes(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf Parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New DireccionClientes With {.CodigoCliente = ElementoCliente.CodigoCliente, .Descripcion = Descripcion, .Direccion = Direccion})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Clientes = ElementoCliente
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.Direccion = Direccion
                    Modificar(ElementoSeleccionado)
                    CargarDatos()
                    VentanaAgregarModificar.Close()
            End Select
            VentanaAgregarModificar.Close()

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarDireccionClientes(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion
                ElementoCliente = ElementoSeleccionado.Clientes
                Direccion = ElementoSeleccionado.Direccion

                VentanaAgregarModificar.ShowDialog()

            Else
                MsgBox("Debe selecionar un elemento ", 64, "Modificar Direccion Cliente")
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
