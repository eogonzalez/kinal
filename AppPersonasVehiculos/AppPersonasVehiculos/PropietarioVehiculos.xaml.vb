Class PropietarioVehiculos
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(Propietario As Object)
        'Nos aseguramos que se inicialice
        Me.New()

        Me.DataContext = Propietario
    End Sub
End Class
