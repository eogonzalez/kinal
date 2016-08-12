<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioTelefonico
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNumeroOrigen = New System.Windows.Forms.TextBox()
        Me.TxtNumeroDestino = New System.Windows.Forms.TextBox()
        Me.TxtDuracion = New System.Windows.Forms.TextBox()
        Me.RbnLocal = New System.Windows.Forms.RadioButton()
        Me.RbnDepto = New System.Windows.Forms.RadioButton()
        Me.CmbFranja = New System.Windows.Forms.ComboBox()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.imgTelefonia = New System.Windows.Forms.PictureBox()
        Me.lblCompañia = New System.Windows.Forms.Label()
        Me.ErrorLlamadas = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.imgTelefonia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorLlamadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero Origen:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero Destino:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Duración:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tipo llamada:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Franja:"
        '
        'TxtNumeroOrigen
        '
        Me.TxtNumeroOrigen.Location = New System.Drawing.Point(113, 74)
        Me.TxtNumeroOrigen.Name = "TxtNumeroOrigen"
        Me.TxtNumeroOrigen.Size = New System.Drawing.Size(151, 20)
        Me.TxtNumeroOrigen.TabIndex = 5
        '
        'TxtNumeroDestino
        '
        Me.TxtNumeroDestino.Location = New System.Drawing.Point(113, 109)
        Me.TxtNumeroDestino.Name = "TxtNumeroDestino"
        Me.TxtNumeroDestino.Size = New System.Drawing.Size(151, 20)
        Me.TxtNumeroDestino.TabIndex = 6
        '
        'TxtDuracion
        '
        Me.TxtDuracion.Location = New System.Drawing.Point(113, 136)
        Me.TxtDuracion.Name = "TxtDuracion"
        Me.TxtDuracion.Size = New System.Drawing.Size(151, 20)
        Me.TxtDuracion.TabIndex = 7
        '
        'RbnLocal
        '
        Me.RbnLocal.AutoSize = True
        Me.RbnLocal.Location = New System.Drawing.Point(113, 163)
        Me.RbnLocal.Name = "RbnLocal"
        Me.RbnLocal.Size = New System.Drawing.Size(51, 17)
        Me.RbnLocal.TabIndex = 10
        Me.RbnLocal.TabStop = True
        Me.RbnLocal.Text = "Local"
        Me.RbnLocal.UseVisualStyleBackColor = True
        '
        'RbnDepto
        '
        Me.RbnDepto.AutoSize = True
        Me.RbnDepto.Location = New System.Drawing.Point(210, 163)
        Me.RbnDepto.Name = "RbnDepto"
        Me.RbnDepto.Size = New System.Drawing.Size(54, 17)
        Me.RbnDepto.TabIndex = 11
        Me.RbnDepto.TabStop = True
        Me.RbnDepto.Text = "Depto"
        Me.RbnDepto.UseVisualStyleBackColor = True
        '
        'CmbFranja
        '
        Me.CmbFranja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFranja.Enabled = False
        Me.CmbFranja.FormattingEnabled = True
        Me.CmbFranja.Items.AddRange(New Object() {"Seleccionar", "1", "2", "3"})
        Me.CmbFranja.Location = New System.Drawing.Point(113, 187)
        Me.CmbFranja.Name = "CmbFranja"
        Me.CmbFranja.Size = New System.Drawing.Size(151, 21)
        Me.CmbFranja.TabIndex = 12
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(189, 227)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 13
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'imgTelefonia
        '
        Me.imgTelefonia.Location = New System.Drawing.Point(15, 12)
        Me.imgTelefonia.Name = "imgTelefonia"
        Me.imgTelefonia.Size = New System.Drawing.Size(83, 50)
        Me.imgTelefonia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgTelefonia.TabIndex = 14
        Me.imgTelefonia.TabStop = False
        '
        'lblCompañia
        '
        Me.lblCompañia.AutoSize = True
        Me.lblCompañia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompañia.Location = New System.Drawing.Point(113, 33)
        Me.lblCompañia.Name = "lblCompañia"
        Me.lblCompañia.Size = New System.Drawing.Size(84, 18)
        Me.lblCompañia.TabIndex = 15
        Me.lblCompañia.Text = "Compañia"
        '
        'ErrorLlamadas
        '
        Me.ErrorLlamadas.ContainerControl = Me
        '
        'FormularioTelefonico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 256)
        Me.Controls.Add(Me.lblCompañia)
        Me.Controls.Add(Me.imgTelefonia)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.CmbFranja)
        Me.Controls.Add(Me.RbnDepto)
        Me.Controls.Add(Me.RbnLocal)
        Me.Controls.Add(Me.TxtDuracion)
        Me.Controls.Add(Me.TxtNumeroDestino)
        Me.Controls.Add(Me.TxtNumeroOrigen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormularioTelefonico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormularioTelefonico"
        CType(Me.imgTelefonia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorLlamadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNumeroOrigen As TextBox
    Friend WithEvents TxtNumeroDestino As TextBox
    Friend WithEvents TxtDuracion As TextBox
    Friend WithEvents RbnLocal As RadioButton
    Friend WithEvents RbnDepto As RadioButton
    Friend WithEvents CmbFranja As ComboBox
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents imgTelefonia As PictureBox
    Friend WithEvents lblCompañia As Label
    Friend WithEvents ErrorLlamadas As ErrorProvider
End Class
