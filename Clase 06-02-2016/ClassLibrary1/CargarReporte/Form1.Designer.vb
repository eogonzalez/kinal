<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnCargarArchivo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumeroColumnas = New System.Windows.Forms.TextBox()
        Me.txtNumeroDeFilas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInicioColumna = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFinalizaFilas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreHoja = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFinalizaColumna = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIniciaFila = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnRutaArchivo = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'btnCargarArchivo
        '
        Me.btnCargarArchivo.Location = New System.Drawing.Point(296, 318)
        Me.btnCargarArchivo.Name = "btnCargarArchivo"
        Me.btnCargarArchivo.Size = New System.Drawing.Size(172, 43)
        Me.btnCargarArchivo.TabIndex = 9
        Me.btnCargarArchivo.Text = "Cargar Archivo"
        Me.btnCargarArchivo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero de Columnas:"
        '
        'txtNumeroColumnas
        '
        Me.txtNumeroColumnas.Location = New System.Drawing.Point(149, 50)
        Me.txtNumeroColumnas.Name = "txtNumeroColumnas"
        Me.txtNumeroColumnas.Size = New System.Drawing.Size(53, 20)
        Me.txtNumeroColumnas.TabIndex = 0
        '
        'txtNumeroDeFilas
        '
        Me.txtNumeroDeFilas.Location = New System.Drawing.Point(149, 76)
        Me.txtNumeroDeFilas.Name = "txtNumeroDeFilas"
        Me.txtNumeroDeFilas.Size = New System.Drawing.Size(53, 20)
        Me.txtNumeroDeFilas.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Numero de Filas:"
        '
        'txtInicioColumna
        '
        Me.txtInicioColumna.Location = New System.Drawing.Point(149, 102)
        Me.txtInicioColumna.Name = "txtInicioColumna"
        Me.txtInicioColumna.Size = New System.Drawing.Size(53, 20)
        Me.txtInicioColumna.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Inicia Columna:"
        '
        'txtFinalizaFilas
        '
        Me.txtFinalizaFilas.Location = New System.Drawing.Point(149, 128)
        Me.txtFinalizaFilas.Name = "txtFinalizaFilas"
        Me.txtFinalizaFilas.Size = New System.Drawing.Size(53, 20)
        Me.txtFinalizaFilas.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Finaliza las Filas:"
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Enabled = False
        Me.txtRutaArchivo.Location = New System.Drawing.Point(149, 232)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.Size = New System.Drawing.Size(180, 20)
        Me.txtRutaArchivo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Ruta del Archivo:"
        '
        'txtNombreHoja
        '
        Me.txtNombreHoja.Location = New System.Drawing.Point(149, 206)
        Me.txtNombreHoja.Name = "txtNombreHoja"
        Me.txtNombreHoja.Size = New System.Drawing.Size(180, 20)
        Me.txtNombreHoja.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Nombre de Hoja:"
        '
        'txtFinalizaColumna
        '
        Me.txtFinalizaColumna.Location = New System.Drawing.Point(149, 180)
        Me.txtFinalizaColumna.Name = "txtFinalizaColumna"
        Me.txtFinalizaColumna.Size = New System.Drawing.Size(53, 20)
        Me.txtFinalizaColumna.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Finaliza las Columnas:"
        '
        'txtIniciaFila
        '
        Me.txtIniciaFila.Location = New System.Drawing.Point(149, 154)
        Me.txtIniciaFila.Name = "txtIniciaFila"
        Me.txtIniciaFila.Size = New System.Drawing.Size(53, 20)
        Me.txtIniciaFila.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Inicia Fila:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnRutaArchivo
        '
        Me.btnRutaArchivo.Location = New System.Drawing.Point(335, 230)
        Me.btnRutaArchivo.Name = "btnRutaArchivo"
        Me.btnRutaArchivo.Size = New System.Drawing.Size(75, 23)
        Me.btnRutaArchivo.TabIndex = 8
        Me.btnRutaArchivo.Text = "..."
        Me.btnRutaArchivo.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 373)
        Me.Controls.Add(Me.btnRutaArchivo)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombreHoja)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFinalizaColumna)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIniciaFila)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFinalizaFilas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInicioColumna)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumeroDeFilas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumeroColumnas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCargarArchivo)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCargarArchivo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumeroColumnas As TextBox
    Friend WithEvents txtNumeroDeFilas As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtInicioColumna As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFinalizaFilas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRutaArchivo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNombreHoja As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFinalizaColumna As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtIniciaFila As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnRutaArchivo As Button
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
End Class
