<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentanaPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.UsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoIniciarSesion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTelefonias = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoClaro = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoTigo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoMovistar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoGenerarReporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoAutor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementoCargarReporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.OFDExcel = New System.Windows.Forms.OpenFileDialog()
        Me.MenuPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPrincipal
        '
        Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuarioToolStripMenuItem, Me.MenuTelefonias, Me.MenuAcercaDe})
        Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrincipal.Name = "MenuPrincipal"
        Me.MenuPrincipal.Size = New System.Drawing.Size(292, 24)
        Me.MenuPrincipal.TabIndex = 1
        Me.MenuPrincipal.Text = "MenuStrip1"
        '
        'UsuarioToolStripMenuItem
        '
        Me.UsuarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ElementoIniciarSesion, Me.ElementoCerrar})
        Me.UsuarioToolStripMenuItem.Name = "UsuarioToolStripMenuItem"
        Me.UsuarioToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.UsuarioToolStripMenuItem.Text = "Usuario"
        '
        'ElementoIniciarSesion
        '
        Me.ElementoIniciarSesion.Name = "ElementoIniciarSesion"
        Me.ElementoIniciarSesion.Size = New System.Drawing.Size(152, 22)
        Me.ElementoIniciarSesion.Text = "Iniciar Sesión"
        '
        'ElementoCerrar
        '
        Me.ElementoCerrar.Name = "ElementoCerrar"
        Me.ElementoCerrar.Size = New System.Drawing.Size(152, 22)
        Me.ElementoCerrar.Text = "Cerrar "
        '
        'MenuTelefonias
        '
        Me.MenuTelefonias.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ElementoClaro, Me.ElementoTigo, Me.ElementoMovistar, Me.ElementoGenerarReporte, Me.ElementoCargarReporte})
        Me.MenuTelefonias.Name = "MenuTelefonias"
        Me.MenuTelefonias.Size = New System.Drawing.Size(68, 20)
        Me.MenuTelefonias.Text = "Telefonias"
        Me.MenuTelefonias.Visible = False
        '
        'ElementoClaro
        '
        Me.ElementoClaro.Name = "ElementoClaro"
        Me.ElementoClaro.Size = New System.Drawing.Size(155, 22)
        Me.ElementoClaro.Text = "Claro"
        '
        'ElementoTigo
        '
        Me.ElementoTigo.Name = "ElementoTigo"
        Me.ElementoTigo.Size = New System.Drawing.Size(155, 22)
        Me.ElementoTigo.Text = "Tigo"
        '
        'ElementoMovistar
        '
        Me.ElementoMovistar.Name = "ElementoMovistar"
        Me.ElementoMovistar.Size = New System.Drawing.Size(155, 22)
        Me.ElementoMovistar.Text = "Movistar"
        '
        'ElementoGenerarReporte
        '
        Me.ElementoGenerarReporte.Name = "ElementoGenerarReporte"
        Me.ElementoGenerarReporte.Size = New System.Drawing.Size(155, 22)
        Me.ElementoGenerarReporte.Text = "Generar Reporte"
        '
        'MenuAcercaDe
        '
        Me.MenuAcercaDe.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ElementoAutor})
        Me.MenuAcercaDe.Name = "MenuAcercaDe"
        Me.MenuAcercaDe.Size = New System.Drawing.Size(67, 20)
        Me.MenuAcercaDe.Text = "Acerca de"
        Me.MenuAcercaDe.Visible = False
        '
        'ElementoAutor
        '
        Me.ElementoAutor.Name = "ElementoAutor"
        Me.ElementoAutor.Size = New System.Drawing.Size(101, 22)
        Me.ElementoAutor.Text = "Autor"
        '
        'ElementoCargarReporte
        '
        Me.ElementoCargarReporte.Name = "ElementoCargarReporte"
        Me.ElementoCargarReporte.Size = New System.Drawing.Size(155, 22)
        Me.ElementoCargarReporte.Text = "Cargar Reporte"
        '
        'OFDExcel
        '
        Me.OFDExcel.FileName = "OpenFileDialog1"
        '
        'VentanaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.MenuPrincipal)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuPrincipal
        Me.Name = "VentanaPrincipal"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuPrincipal.ResumeLayout(False)
        Me.MenuPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuPrincipal As MenuStrip
    Friend WithEvents UsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElementoIniciarSesion As ToolStripMenuItem
    Friend WithEvents ElementoCerrar As ToolStripMenuItem
    Friend WithEvents MenuTelefonias As ToolStripMenuItem
    Friend WithEvents ElementoClaro As ToolStripMenuItem
    Friend WithEvents ElementoTigo As ToolStripMenuItem
    Friend WithEvents ElementoMovistar As ToolStripMenuItem
    Friend WithEvents MenuAcercaDe As ToolStripMenuItem
    Friend WithEvents ElementoAutor As ToolStripMenuItem
    Friend WithEvents ElementoGenerarReporte As ToolStripMenuItem
    Friend WithEvents ElementoCargarReporte As ToolStripMenuItem
    Friend WithEvents OFDExcel As OpenFileDialog
End Class
