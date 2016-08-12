Imports Laboratorio_Eder_Gonzalez
Module Module1
    Private _RegistroLlamada As New List(Of Llamada)
    Private _itemTelefonias As Boolean = False
    Private _itemAcercade As Boolean = False

    Public Property RegistroLlamada As List(Of Llamada)
        Get
            Return _RegistroLlamada
        End Get
        Set(value As List(Of Llamada))
            _RegistroLlamada = value
        End Set
    End Property

    Public Property itemTelefonias As Boolean
        Get
            Return _itemTelefonias
        End Get
        Set(value As Boolean)
            _itemTelefonias = value
        End Set
    End Property

    Public Property itemAcercade As Boolean
        Get
            Return _itemAcercade
        End Get
        Set(value As Boolean)
            _itemAcercade = value
        End Set
    End Property

    Public Sub CambiarstatusMenu()
        If Not itemAcercade Then
            My.Windows.MainWindow.menuacercade.Visibility = Visibility.Hidden
        Else
            My.Windows.MainWindow.menuacercade.Visibility = Visibility.Visible
        End If

        If Not itemTelefonias Then
            My.Windows.MainWindow.menutelefonias.Visibility = Visibility.Hidden
        Else
            My.Windows.MainWindow.menutelefonias.Visibility = Visibility.Visible
        End If


    End Sub

End Module
