Imports System.ComponentModel

Public Class FormularioInicioSesion

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    'Private Shared Instancia As FormularioInicioSesion = Nothing

    'Public Shared Function getInstancia() As FormularioInicioSesion
    '    If Instancia Is Nothing Then
    '        Instancia = New FormularioInicioSesion
    '    End If
    '    Return Instancia
    'End Function

    'Private Sub New()
    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    'End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Me.TxtUsuario.Text = "kinal" And Me.TxtPassword.Text = "kinal" Then
            My.Forms.VentanaPrincipal.MenuAcercaDe.Visible = True
            My.Forms.VentanaPrincipal.MenuTelefonias.Visible = True
            Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FormularioInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub formularioiniciosesion_closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '    Instancia = Nothing
    'End Sub

End Class
