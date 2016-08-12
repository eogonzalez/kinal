Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports SistemaInventario2016
Public Class ModelClientes
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventarios As New InventarioContext
    Private _ListaClientes As ObservableCollection(Of Clientes)
    Private _ElementoSeleccionado As Clientes
    Private _Instancia As ModelClientes
    Private _Tipo As TipoMantenimiento
    Private _Nombre As String
    Private _DPI As String
    Private _NIT As String
    Private VentanaAgregarModificar As AgregarModificarClientes

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
            NotificarCambios("Nombre")
        End Set
    End Property

    Public Property DPI As String
        Get
            Return _DPI
        End Get
        Set(value As String)
            _DPI = value
            NotificarCambios("DPI")
        End Set
    End Property

    Public Property NIT As String
        Get
            Return _NIT
        End Get
        Set(value As String)
            _NIT = value
            NotificarCambios("NIT")
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

    Public Property ListaClientes As ObservableCollection(Of Clientes)
        Get
            Return _ListaClientes
        End Get
        Set(value As ObservableCollection(Of Clientes))
            _ListaClientes = value
            NotificarCambios("ListaClientes")
        End Set
    End Property

    Public Property ElementoSeleccionado As Clientes
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As Clientes)
            _ElementoSeleccionado = value
            NotificarCambios("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelClientes
        Get
            Return _Instancia
        End Get
        Set(value As ModelClientes)
            _Instancia = value
        End Set
    End Property

    Public Sub New()
        CargarDatos()
        Instancia = Me
    End Sub

    Public Sub NotificarCambios(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub

    Public Sub Eliminar()
        If ElementoSeleccionado IsNot Nothing Then
            Dim Respuesta As MsgBoxResult
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro " & ElementoSeleccionado.Nombre & "?",
                               MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Clientes")

            Try
                If Respuesta = MsgBoxResult.Yes Then

                    DBInventarios.Clientes.Remove(ElementoSeleccionado)
                    DBInventarios.SaveChanges()
                    CargarDatos()

                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Clientes")
            End Try

        Else
            MsgBox("Debe seleccionar un elemento", 64, "Eliminar clientes")
        End If

    End Sub

    Public Sub CargarDatos()
        'Consulta de datos a la tabla clientes
        Dim Clientes = From C In DBInventarios.Clientes
                       Select C Order By C.CodigoCliente
        'Instanciar la coleccion
        ListaClientes = New ObservableCollection(Of Clientes)
        'Llena la lista de clientes
        For Each Elemento In Clientes
            ListaClientes.Add(Elemento)
        Next

    End Sub

    Public Sub Agregar(ByVal Elemento As Clientes)
        Try
            DBInventarios.Clientes.Add(Elemento)
            DBInventarios.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Clientes.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As Clientes)
        Try
            DBInventarios.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventarios.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Clientes")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(parametro As Object) Implements ICommand.Execute
        If parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarClientes(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New Clientes With {.Nombre = Nombre, .DPI = DPI, .NIT = NIT})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Nombre = Nombre
                    ElementoSeleccionado.DPI = DPI
                    ElementoSeleccionado.NIT = NIT
                    Modificar(ElementoSeleccionado)

            End Select

            VentanaAgregarModificar.Close()
        ElseIf parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarClientes(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Nombre = ElementoSeleccionado.Nombre
                DPI = ElementoSeleccionado.DPI
                NIT = ElementoSeleccionado.NIT

                VentanaAgregarModificar.ShowDialog()
            Else
                MsgBox("Debe seleccionar un elemento", 64, "Modificar Clientes")
            End If
        ElseIf parametro.Equals("Cancelar") Then
            VentanaAgregarModificar.Close()
        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
