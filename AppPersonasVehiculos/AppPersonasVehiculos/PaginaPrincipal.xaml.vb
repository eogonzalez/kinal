Class PaginaPrincipal
    Public Sub VentanaVehiculos()
        Dim VentanaPropietariosVehiculos As New PropietarioVehiculos(Me.propietariosListBox.SelectedItem)
        Me.NavigationService.Navigate(VentanaPropietariosVehiculos)

    End Sub

End Class
