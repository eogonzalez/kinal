Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class ModelCorreoClientes
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventario As New InventarioContext
    Private _ListaCorreoClientes As ObservableCollection(Of EmailClientes)
    Private _ElementoSeleccionado As EmailClientes
    Private _Instancia As ModelCorreoClientes
    Private _Tipo As TipoMantenimiento
    Private _Email As String
    Private _Descripcion As String
    Private _ElementoCliente As Clientes
    Private _ListaClientes As ObservableCollection(Of Clientes)
    Private VentanaAgregarModificar As AgregarModificarCorreoClientes

    Public Property ListaCorreoClientes As ObservableCollection(Of EmailClientes)
        Get
            Return _ListaCorreoClientes
        End Get
        Set(value As ObservableCollection(Of EmailClientes))
            _ListaCorreoClientes = value
            Notificar("ListaCorreoClientes")
        End Set
    End Property

    Public Property ElementoSeleccionado As EmailClientes
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As EmailClientes)
            _ElementoSeleccionado = value
            Notificar("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelCorreoClientes
        Get
            Return _Instancia
        End Get
        Set(value As ModelCorreoClientes)
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
        Dim CorreoClientes = From C In DBInventario.EmailClientes
                             Select C Order By C.CodigoCliente
        ListaCorreoClientes = New ObservableCollection(Of EmailClientes)
        For Each Elemento In CorreoClientes
            ListaCorreoClientes.Add(Elemento)
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
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.Email & " ?",
                                MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Correo de Cliente")

            Try
                If Respuesta = MsgBoxResult.Yes Then
                    DBInventario.EmailClientes.Remove(ElementoSeleccionado)
                    DBInventario.SaveChanges()
                    CargarDatos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Correo de Cliente")
            End Try
        Else
            MsgBox("Debe selecionar un elemento ", 64, "Eliminar Correo de Cliente")
        End If
    End Sub

    Public Sub Agregar(ByVal Elemento As EmailClientes)
        Try
            DBInventario.EmailClientes.Add(Elemento)
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Correo Cliente.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As EmailClientes)
        Try
            DBInventario.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventario.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Correo Cliente")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(Parametro As Object) Implements ICommand.Execute
        If Parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf Parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarCorreoClientes(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf Parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New EmailClientes With {.CodigoCliente = ElementoCliente.CodigoCliente, .Descripcion = Descripcion, .Email = Email})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Clientes = ElementoCliente
                    ElementoSeleccionado.Descripcion = Descripcion
                    ElementoSeleccionado.Email = Email
                    Modificar(ElementoSeleccionado)
                    CargarDatos()
                    VentanaAgregarModificar.Close()
            End Select
            VentanaAgregarModificar.Close()

        ElseIf Parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarCorreoClientes(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion
                ElementoCliente = ElementoSeleccionado.Clientes
                Email = ElementoSeleccionado.Email

                VentanaAgregarModificar.ShowDialog()

            Else
                MsgBox("Debe selecionar un elemento ", 64, "Modificar Correo Cliente")
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
