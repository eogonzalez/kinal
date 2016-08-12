Imports Laboratorio_Eder_Gonzalez
Public Class FormularioTelefonico
    'Private _UrlImagen As String

    'Public Property UrlImagen As String
    '    Get
    '        Return _UrlImagen
    '    End Get
    '    Set(value As String)
    '        _UrlImagen = value
    '    End Set
    'End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Compañia As String, ByVal Imagen As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblCompañia.Text = Compañia
        Me.imgTelefonia.Image = Image.FromFile("../../Recursos/" & Imagen)
    End Sub

    Private Sub RbnLocal_CheckedChanged(sender As Object, e As EventArgs) Handles RbnLocal.CheckedChanged
        Me.CmbFranja.Enabled = False
    End Sub

    Private Sub RbnDepto_CheckedChanged(sender As Object, e As EventArgs) Handles RbnDepto.CheckedChanged
        Me.CmbFranja.Enabled = True
        Me.CmbFranja.SelectedIndex = 0
    End Sub

    Private Sub FormularioTelefonico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RbnLocal.Checked = True

        'Me.imgTelefonia.Image = Image.FromFile(UrlImagen)
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim MiLlamada As Llamada = Nothing

        If RbnLocal.Checked Then

            MiLlamada = New LlamadaLocal(TxtNumeroOrigen.Text, TxtNumeroDestino.Text, TxtDuracion.Text, 1)

        ElseIf RbnDepto.Checked Then

            MiLlamada = New LlamadaDepartamental(TxtNumeroOrigen.Text, TxtNumeroDestino.Text, TxtDuracion.Text, CmbFranja.Text)

        End If

        MiLlamada.Compania = lblCompañia.Text
        'Instancia de tipo singleton por que hace referenia al objeto de ventana principal
        'Registro llamada en lista
        My.Forms.VentanaPrincipal.RegistroLlamada.Add(MiLlamada)

        'Registro de llamada al metodo de centralita
        Centralita.RegistrarLlamada(MiLlamada)


        If TypeOf (MiLlamada) Is LlamadaLocal Then
            MsgBox(DirectCast(MiLlamada, LlamadaLocal).ToString, 64, "Registro de llamada")
        ElseIf TypeOf (MiLlamada) Is LlamadaDepartamental Then
            MsgBox(DirectCast(MiLlamada, LlamadaDepartamental).ToString, 64, "Registro de llamada")
        End If

        LimpiarTextos()
    End Sub

    Public Sub LimpiarTextos()
        For Each Elemento As Control In Me.Controls
            If TypeOf (Elemento) Is TextBox Then
                Elemento.Text = ""
            End If
        Next
    End Sub

    Private Sub TxtNumeroOrigen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumeroOrigen.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Chr(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumeroDestino_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumeroDestino.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Chr(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtDuracion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDuracion.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Chr(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumeroOrigen_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNumeroOrigen.Validating
        If Me.TxtNumeroOrigen.Text.Length = 0 Then
            Me.ErrorLlamadas.BlinkRate = 200
            Me.ErrorLlamadas.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            Me.ErrorLlamadas.SetError(Me.TxtNumeroOrigen, "Debe ingresar un numero")
        Else
            ErrorLlamadas.Clear()
        End If
    End Sub

    Private Sub TxtNumeroDestino_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNumeroDestino.Validating
        If Me.TxtNumeroDestino.Text.Length = 0 Then
            Me.ErrorLlamadas.BlinkRate = 200
            Me.ErrorLlamadas.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            Me.ErrorLlamadas.SetError(Me.TxtNumeroDestino, "Debe ingresar un numero")
        Else

        End If
    End Sub

    Private Sub TxtDuracion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDuracion.Validating
        If Me.TxtDuracion.Text.Length = 0 Then
            Me.ErrorLlamadas.BlinkRate = 200
            Me.ErrorLlamadas.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            Me.ErrorLlamadas.SetError(Me.TxtDuracion, "Debe ingresar un numero")
        Else
            ErrorLlamadas.Clear()
        End If
    End Sub
End Class