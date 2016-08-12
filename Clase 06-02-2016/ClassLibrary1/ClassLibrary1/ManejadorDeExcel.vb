Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports Laboratorio_Eder_Gonzalez
Public Class ManejadorDeExcel

#Region "Campos"

    Private _NumeroDeColumnas _
            , _NumeroDeFilas _
            , _InicioColumna _
            , _FinalizaColumna _
            , _IniciaFila _
            , _FinalizaFila As Integer

    Private _NombreHoja _
            , _RutaArchivo _
            , _Servidor _
            , _Usuario _
            , _Password _
            , _BasedeDatos _
            , _Procedimiento _
            , _Instancia _
            , _Puerto _
            , _Columnas As String

#End Region

#Region "Propiedades"

    Public Property NumeroDeColumnas() As Integer
        Get
            Return _NumeroDeColumnas
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _NumeroDeColumnas = value
        End Set
    End Property

    Public Property NumeroDeFilas() As Integer
        Get
            Return _NumeroDeFilas

        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _NumeroDeFilas = value
        End Set
    End Property

    Public Property InicioColumna() As Integer
        Get
            Return _InicioColumna
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _InicioColumna = value
        End Set
    End Property

    Public Property FinalizaColumna() As Integer
        Get
            Return _FinalizaColumna
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _FinalizaColumna = value
        End Set
    End Property

    Public Property IniciaFila() As Integer
        Get
            Return _IniciaFila
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _IniciaFila = value
        End Set
    End Property

    Public Property FinalizaFila() As Integer
        Get
            Return _FinalizaFila
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _FinalizaFila = value
        End Set
    End Property

    'STRING
    Public Property NombreHoja() As String
        Get
            Return _NombreHoja
        End Get
        Set(ByVal value As String)
            _NombreHoja = value
        End Set
    End Property

    Public Property RutaArchivo() As String
        Get
            Return _RutaArchivo
        End Get
        Set(ByVal value As String)
            _RutaArchivo = value
        End Set
    End Property

    Public Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(value As String)
            _Servidor = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public Property BasedeDatos() As String
        Get
            Return _BasedeDatos
        End Get
        Set(value As String)
            _BasedeDatos = value
        End Set
    End Property

    Public Property Procedimiento() As String
        Get
            Return _Procedimiento
        End Get
        Set(value As String)
            _Procedimiento = value
        End Set
    End Property

    Public Property Instancia() As String
        Get
            Return _Instancia
        End Get
        Set(value As String)
            _Instancia = value
        End Set
    End Property

    Public Property Columnas() As String
        Get
            Return _Columnas
        End Get
        Set(value As String)
            _Columnas = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Sub CargarDatosSQL()
        'Referencia al libro de excel
        Dim LibroExcel As New Excel.Application
        'Referencia a la hoja de excel
        Dim HojaExcel As New Excel.Worksheet

        'Conexion a SQLServer
        'Dim Conexion As New SqlClient.SqlConnection("Server = 192.168.102.136\SQLSB;Database=Carga2016;User Id=sabado;Password=guatemala;")
        Dim Conexion As New SqlClient.SqlConnection("Server = " + Servidor + "\" + Instancia + ";Database=" + BasedeDatos + ";User Id=" + Usuario + ";Password=" + Password + ";")

        'Sentencia de SQL
        Dim Sentencia As SqlClient.SqlCommand

        'Variable con referencia a la fila que se iniciara
        Dim Fila As Integer
        Dim Columna As Integer
        'Referencia a columnas
        Dim Columnas As String = "ABCDE"

        'Referencia al archivo
        LibroExcel.Workbooks.Add(RutaArchivo)
        LibroExcel.Worksheets(NombreHoja).Select()
        HojaExcel = LibroExcel.ActiveSheet

        'Sentencia a la base de datos
        Dim SentenciaSQL As String = "dbo.sp_AgregarVenta"



        'Lectura de archivo
        For Fila = IniciaFila To FinalizaFila
            Sentencia = New SqlCommand(SentenciaSQL, Conexion)
            Sentencia.CommandType = CommandType.StoredProcedure

            For Columna = InicioColumna To FinalizaColumna

                Select Case Columna
                    Case 2
                        Dim nit As SqlParameter = Sentencia.Parameters.Add("@nit", SqlDbType.VarChar)
                        nit.Direction = ParameterDirection.Input
                        nit.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value
                    Case 3
                        Dim cliente As SqlParameter = Sentencia.Parameters.Add("@cliente", SqlDbType.VarChar)
                        cliente.Direction = ParameterDirection.Input
                        cliente.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value

                    Case 4
                        Dim fecha As SqlParameter = Sentencia.Parameters.Add("@fecha", SqlDbType.Date)
                        fecha.Direction = ParameterDirection.Input
                        fecha.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value
                    Case 5
                        Dim valor As SqlParameter = Sentencia.Parameters.Add("@valor", SqlDbType.Decimal)
                        valor.Direction = ParameterDirection.Input
                        valor.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value
                End Select

                MsgBox(HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value)
            Next

            Try

                Conexion.Open()
                Sentencia.ExecuteNonQuery()
                Conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally

                Conexion.Close()
            End Try

        Next



    End Sub

    Public Sub CargarDatosMySql()
        'Referencia al libro de excel
        Dim LibroExcel As New Excel.Application
        'Referencia a la hoja de excel
        Dim HojaExcel As New Excel.Worksheet

        'Conexion a MySql
        'Dim conexion As New MySqlConnection("Server=192.168.102.136;Database=Carga2016;Uid=sabado;Pwd=guatemala;")
        Dim conexion As New MySqlConnection("Server=" + Servidor + ";Database=" + BasedeDatos + ";Uid=" + Usuario + ";Pwd=" + Password + ";")

        'Sentencia de MySql
        Dim Sentencia As MySqlCommand

        'Variable con referencia a la fila que se iniciara
        Dim Fila As Integer
        Dim Columna As Integer
        'Referencia a columnas
        Dim Columnas As String = "ABCDE"

        'Referencia al archivo
        LibroExcel.Workbooks.Add(RutaArchivo)
        LibroExcel.Worksheets(NombreHoja).Select()
        HojaExcel = LibroExcel.ActiveSheet

        'Sentencia a la base de datos
        Dim SentenciaMySql As String = "sp_AgregarVenta"



        'Lectura de archivo
        For Fila = IniciaFila To FinalizaFila
            Sentencia = New MySqlCommand(SentenciaMySql, conexion)
            Sentencia.CommandType = CommandType.StoredProcedure

            For Columna = InicioColumna To FinalizaColumna

                Select Case Columna
                    Case 2

                        Dim nit As MySqlParameter = Sentencia.Parameters.Add("?_nit", MySqlDbType.VarChar)
                        nit.Direction = ParameterDirection.Input
                        nit.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value
                    Case 3
                        Dim cliente As MySqlParameter = Sentencia.Parameters.Add("?_cliente", MySqlDbType.VarChar)
                        cliente.Direction = ParameterDirection.Input
                        cliente.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value

                    Case 4
                        Dim fecha As MySqlParameter = Sentencia.Parameters.Add("?_fecha", MySqlDbType.Date)
                        fecha.Direction = ParameterDirection.Input
                        fecha.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value
                    Case 5
                        Dim valor As MySqlParameter = Sentencia.Parameters.Add("?_valor", MySqlDbType.Decimal)
                        valor.Direction = ParameterDirection.Input
                        valor.Value = HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value
                End Select

                MsgBox(HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value)
            Next

            Try

                conexion.Open()
                Sentencia.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally

                conexion.Close()
            End Try

        Next



    End Sub

    Public Function GenerarReporteTelefonico(ByVal Listado As List(Of Llamada)) As Boolean
        Dim Resultado As Boolean = True
        Dim LibroExcel As New Excel.Application
        Dim HojaExcel As New Excel.Worksheet
        Dim Fila As Integer = IniciaFila

        LibroExcel.Workbooks.Add(RutaArchivo)
        Try
            LibroExcel.Worksheets(NombreHoja).select
            HojaExcel = LibroExcel.ActiveSheet

            For Each Elemento As Llamada In Listado
                For Columna As Integer = InicioColumna To FinalizaColumna
                    Select Case Columna
                        Case 1 'No.

                            HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = Fila

                        Case 2 'Numero Origen

                            HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = Elemento.NumeroOrigen

                        Case 3 'Numero Destino

                            HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = Elemento.NumeroDestino

                        Case 4 'Tipo

                            If TypeOf (Elemento) Is LlamadaLocal Then
                                HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = "Local"
                            ElseIf TypeOf (Elemento) Is LlamadaDepartamental Then
                                HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = "Departamental"
                            End If

                        Case 5 'Franja

                            If TypeOf (Elemento) Is LlamadaDepartamental Then
                                HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = DirectCast(Elemento, LlamadaDepartamental).Franja
                            End If

                        Case 6 'Duracion

                            HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = Elemento.Duracion

                        Case 7 'Monto

                            HojaExcel.Range(Mid(Columnas, Columna, 1) & Fila).Value = Elemento.CalcularPrecio
                    End Select
                Next
                Fila = Fila + 1
            Next

            Resultado = True
            LibroExcel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Resultado
    End Function

    Public Sub CargarReporteTelefonico(ByRef Listado As List(Of Llamada))
        Dim Resultado As Boolean = True
        Dim LibroExcel As New Excel.Application
        Dim HojaExcel As New Excel.Worksheet
        Dim Fila As Integer = IniciaFila

        LibroExcel.Workbooks.Add(RutaArchivo)
        Try
            LibroExcel.Worksheets(NombreHoja).select
            HojaExcel = LibroExcel.ActiveSheet

            For Fila = IniciaFila To FinalizaFila
                Dim Registro As Llamada = Nothing

                If String.Compare(HojaExcel.Range("E" & Fila).Value, "Local", True) = 0 Then
                    Registro = New LlamadaLocal
                ElseIf String.Compare(HojaExcel.Range("E" & Fila).Value, "DEPTO", True) = 0 Then
                    Registro = New LlamadaDepartamental
                    DirectCast(Registro, LlamadaDepartamental).Franja = HojaExcel.Range("F" & Fila).Value
                End If
                Registro.NumeroOrigen = HojaExcel.Range("A" & Fila).Value
                Registro.NumeroDestino = HojaExcel.Range("B" & Fila).Value
                Registro.Compania = HojaExcel.Range("C" & Fila).Value
                Registro.Duracion = HojaExcel.Range("D" & Fila).Value
                Listado.Add(Registro)
            Next

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, 16, "Cargar archivo")
        End Try
    End Sub

#End Region

#Region "Constructores"

    Public Sub New(ByVal IniciaFila As Integer, ByVal FinalizaFila As Integer, ByVal RutaArchivo As String, ByVal NombreHoja As String)
        Me.IniciaFila = IniciaFila
        Me.FinalizaFila = FinalizaFila
        Me.RutaArchivo = RutaArchivo
        Me.NombreHoja = NombreHoja
    End Sub


    Public Sub New(ByVal IniciaFila As Integer, ByVal RutaArchivo As String, ByVal NombreHoja As String, ByVal InicioColumna As Integer,
                   ByVal FinalizaColumna As Integer, ByVal Columnas As String)
        Me.IniciaFila = IniciaFila
        Me.RutaArchivo = RutaArchivo
        Me.NombreHoja = NombreHoja
        Me.InicioColumna = InicioColumna
        Me.FinalizaColumna = FinalizaColumna
        Me.Columnas = Columnas
    End Sub

    Public Sub New(ByVal Servidor As String, ByVal Usuario As String,
                   ByVal Password As String, ByVal BasedeDatos As String, ByVal Procedimiento As String)
        Me.Servidor = Servidor
        Me.Usuario = Usuario
        Me.Password = Password
        Me.BasedeDatos = BasedeDatos
        Me.Procedimiento = Procedimiento

    End Sub

    Public Sub New(ByVal Servidor As String, ByVal Usuario As String, ByVal Password As String,
                   ByVal BasedeDatos As String, ByVal Procedimiento As String, ByVal Instancia As String)
        Me.Servidor = Servidor
        Me.Usuario = Usuario
        Me.Password = Password
        Me.BasedeDatos = BasedeDatos
        Me.Procedimiento = Procedimiento
        Me.Instancia = Instancia

    End Sub

#End Region

End Class
