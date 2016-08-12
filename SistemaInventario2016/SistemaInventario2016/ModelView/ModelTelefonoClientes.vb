Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class ModelTelefonoClientes
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaTelefonoClientes As ObservableCollection(Of TelefonoClientes)
    Private _ElementoSeleccionado As TelefonoClientes
    Private _Instancia As ModelTelefonoClientes
    Private _Tipo As TipoMantenimiento
    Private _NumeroTelefono As Integer
    Private _Descripcion As String
    Private _ElementoCliente As Clientes
    Private _ListaClientes As ObservableCollection(Of Clientes)
    Private VentanaAgregarModificar As AgregarModificarTelefonoCliente

    Public Property ListaTelefonoClientes As ObservableCollection(Of TelefonoClientes)
        Get
            Return _ListaTelefonoClientes
        End Get
        Set(value As ObservableCollection(Of TelefonoClientes))
            _ListaTelefonoClientes = value
            Notificar("ListaTelefonoClientes")
        End Set
    End Property

    Public Property ElementoSeleccionado As TelefonoClientes
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As TelefonoClientes)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelTelefonoClientes
        Get
            Return _Instancia
        End Get
        Set(value As ModelTelefonoClientes)
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
        Dim TelefonoClientes = From T In DBInventario.TelefonoClientes
                               Select T Order By T.CodigoCliente

        ListaTelefonoClientes = New ObservableCollection(Of TelefonoClientes)
        For Each Elemento In TelefonoClientes
            ListaTelefonoClientes.Add(Elemento)
        Next

        Dim Clientes = From C In DBInventario.Clientes
                       Select C Order By C.Nombre
        ListaClientes = New ObservableCollection(Of Clientes)
        For Each Elemento In Clientes
            ListaClientes.Add(Elemento)
        Next
    End Sub

    Public Sub Eliminar()
        If ElementoSeleccionado IsNot Nothing Then
            Dim Respuesta As MsgBoxResult
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.NumeroTelefono & " ?",
                                MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Numero de Cliente")

            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.TelefonoClientes.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Telefono de Cliente")
            End Try
        Else
            MsgBox("Debe selecionar un elemento ", 64, "Eliminar Telefono de Cliente")
        End If
    End Sub

    Public Sub Agregar(ByVal Elemento As TelefonoClientes)
        Try
            DBInventario.TelefonoClientes.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Telefono Cliente.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As TelefonoClientes)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Telefono Cliente")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute

        If Parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf Parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarTelefonoCliente(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf Parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New TelefonoClientes With {.CodigoCliente = ElementoCliente.CodigoCliente, .Descripcion = Descripcion, .NumeroTelefono = NumeroTelefono})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Clientes = ElementoCliente
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.NumeroTelefono = NumeroTelefono
                    Modificar(ElementoSeleccionado)
                    CargarDatos()
                    VentanaAgregarModificar.Close()
            End Select
            VentanaAgregarModificar.Close()

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarTelefonoCliente(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion
                ElementoCliente = ElementoSeleccionado.Clientes
                NumeroTelefono = ElementoSeleccionado.NumeroTelefono

                VentanaAgregarModificar.ShowDialog()

            Else
                MsgBox("Debe selecionar un elemento ", 64, "Modificar Numero Cliente")
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
