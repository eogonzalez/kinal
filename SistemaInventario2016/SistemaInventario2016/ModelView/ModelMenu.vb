Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports SistemaInventario2016

Public Class ModelMenu
    Implements ICommand
    Private _Instancia As ModelMenu
    Public Sub New()
        Me.Instancia = Me
    End Sub
    Public Property Instancia As ModelMenu
        Get
            Return _Instancia
        End Get
        Set(value As ModelMenu)
            _Instancia = value
        End Set
    End Property

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If parameter.Equals("Categorias") Then
            Dim VentanaCategoria As New VentanaCategorias
            VentanaCategoria.ShowDialog()
        ElseIf parameter.Equals("Proveedores") Then
            Dim VentanaProveedores As New VentanaProveedores
            VentanaProveedores.ShowDialog()
        ElseIf parameter.Equals("Clientes") Then
            Dim VentanaClientes As New VentanaClientes
            VentanaClientes.ShowDialog()
        ElseIf parameter.Equals("Compras") Then
            Dim VentanaCompras As New VentanaCompras
            VentanaCompras.ShowDialog()
        ElseIf parameter.Equals("Productos") Then
            Dim VentanaProductos As New VentanaProductos
            VentanaProductos.ShowDialog()
        ElseIf parameter.Equals("TipoEmpaque") Then
            Dim VentanaTipoEmpaque As New VentanaTipoEmpaque
            VentanaTipoEmpaque.ShowDialog()
        ElseIf parameter.Equals("TelefonoClientes") Then
            Dim VentanaTelefonoClientes As New VentanaTelefonoClientes
            VentanaTelefonoClientes.ShowDialog()
        ElseIf parameter.Equals("EmailClientes") Then
            Dim VentanaCorreoClientes As New VentanaCorreoClientes
            VentanaCorreoClientes.ShowDialog()
        ElseIf parameter.Equals("DireccionClientes") Then
            Dim VentanaDireccionClientes As New VentanaDireccionClientes
            VentanaDireccionClientes.ShowDialog()
        ElseIf parameter.Equals("TelefonoProveedores") Then
            Dim VentanaTelefonoProveedores As New VentanaTelefonoProveedores
            VentanaTelefonoProveedores.ShowDialog()
        ElseIf parameter.Equals("EmailProveedores") Then
            Dim VentanaCorreoProveedores As New VentanaCorreoProveedores
            VentanaCorreoProveedores.ShowDialog()
        ElseIf parameter.Equals("DireccionProveedores") Then
            Dim VentanaDireccionProveedores As New VentanaDireccionProveedores
            VentanaDireccionProveedores.ShowDialog()
        ElseIf parameter.Equals("Parametros") Then
            Dim VentanaParametros As New VentanaParametros
            VentanaParametros.ShowDialog()
        ElseIf parameter.Equals("Inventarios") Then
            Dim VentanaInventarios As New VentanaInventario
            VentanaInventarios.ShowDialog()
        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
