Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports SistemaInventario2016

Public Class ModelCategorias
    Implements INotifyPropertyChanged, ICommand

    Enum TipoMantenimiento
        AGREGAR
        MODIFICAR
    End Enum

    Private DBInventarios As New InventarioContext
    Private _ListaCategorias As ObservableCollection(Of Categorias)
    Private _ElementoSeleccionado As Categorias
    Private _Instancia As ModelCategorias
    Private _Tipo As TipoMantenimiento
    Private _Descripcion As String
    Private VentanaAgregarModificar As AgregarModificarCategoria

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
            NotificarCambios("Descripcion")
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

    Public Property ListaCategorias As ObservableCollection(Of Categorias)
        Get
            Return _ListaCategorias
        End Get
        Set(value As ObservableCollection(Of Categorias))
            _ListaCategorias = value
            NotificarCambios("ListaCategorias")
        End Set
    End Property

    Public Property ElementoSeleccionado As Categorias
        Get
            Return _ElementoSeleccionado
        End Get
        Set(value As Categorias)
            _ElementoSeleccionado = value
            NotificarCambios("ElementoSeleccionado")
        End Set
    End Property

    Public Property Instancia As ModelCategorias
        Get
            Return _Instancia
        End Get
        Set(value As ModelCategorias)
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
            Respuesta = MsgBox("Esta seguro que desea eliminar el registro" & ElementoSeleccionado.Descripcion & "?",
                               MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Categoria")

            Try
                If Respuesta = MsgBoxResult.Yes Then

                    DBInventarios.Categorias.Remove(ElementoSeleccionado)
                    DBInventarios.SaveChanges()
                    CargarDatos()

                End If
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Eliminar Categoria")
            End Try

        Else
            MsgBox("Debe seleccionar un elemento", 64, "Eliminar categoria")
        End If

    End Sub

    Public Sub CargarDatos()
        'Consulta de datos a la tabla Categorias
        Dim Categorias = From C In DBInventarios.Categorias
                         Select C Order By C.Descripcion
        'Instanciar la coleccion
        ListaCategorias = New ObservableCollection(Of Categorias)
        'Llena la lista de categorias
        For Each Elemento In Categorias
            ListaCategorias.Add(Elemento)
        Next

    End Sub

    Public Sub Agregar(ByVal Elemento As Categorias)
        Try
            DBInventarios.Categorias.Add(Elemento)
            DBInventarios.SaveChanges()
            CargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Agregar Categoria.")
        End Try
    End Sub

    Public Sub Modificar(ByVal Elemento As Categorias)
        Try
            DBInventarios.Entry(Elemento).State = System.Data.Entity.EntityState.Modified
            DBInventarios.SaveChanges()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Modificar Categoria")
        End Try
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Execute(parametro As Object) Implements ICommand.Execute

        If parametro.Equals("Eliminar") Then
            Eliminar()
        ElseIf parametro.Equals("Agregar") Then
            VentanaAgregarModificar = New AgregarModificarCategoria(Instancia)
            Tipo = TipoMantenimiento.AGREGAR
            VentanaAgregarModificar.ShowDialog()

        ElseIf parametro.Equals("Guardar") Then
            Select Case Tipo
                Case TipoMantenimiento.AGREGAR
                    Agregar(New Categorias With {.Descripcion = Descripcion})
                Case TipoMantenimiento.MODIFICAR
                    ElementoSeleccionado.Descripcion = Descripcion
                    Modificar(ElementoSeleccionado)

            End Select

            VentanaAgregarModificar.Close()
        ElseIf parametro.Equals("Modificar") Then
            If ElementoSeleccionado IsNot Nothing Then
                VentanaAgregarModificar = New AgregarModificarCategoria(Instancia)
                Tipo = TipoMantenimiento.MODIFICAR
                Descripcion = ElementoSeleccionado.Descripcion

                VentanaAgregarModificar.ShowDialog()
            Else
                MsgBox("Debe seleccionar un elemento", 64, "Modificar categoria")
            End If
        ElseIf parametro.Equals("Reporte") Then
            Dim ReporteCategorias As New ReporteCategorias
            ReporteCategorias.ShowDialog()
        ElseIf parametro.Equals("Cancelar") Then
            VentanaAgregarModificar.Close()
        End If

    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

End Class
