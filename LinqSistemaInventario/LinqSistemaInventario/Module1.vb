Module Module1

    Sub Main()
        Menu()
    End Sub

    Public Sub Menu()
        Dim Opcion As String = ""
        Do
            Console.Clear()
            Console.WriteLine("1. Categorias")
            Console.WriteLine("2. Tipo Empaques")
            Console.WriteLine("3. Productos")
            Console.WriteLine("0. Salir")
            Console.WriteLine("Ingrese su opcion =====>")
            Opcion = Console.ReadLine()

            If Opcion = "1" Then
                MenuCategorias()
            ElseIf Opcion = "2" Then
                MenuTipoEmpaques()
            ElseIf Opcion = "3" Then
                MenuProductos()
            End If

        Loop While Opcion <> "0"
    End Sub

    Public Sub MenuProductos()
        Dim Opcion As String = ""
        Do
            Console.Clear()
            Console.WriteLine("1. Agregar")
            Console.WriteLine("2. Eliminar")
            Console.WriteLine("3. Modificar")
            Console.WriteLine("4. Buscar")
            Console.WriteLine("5. Listar")
            Console.WriteLine("0. Salir")
            Opcion = Console.ReadLine()

            If Opcion = "1" Then
                ProductoController.GetInstancia().Agregar()
            ElseIf Opcion = "2" Then
                ProductoController.GetInstancia().Eliminar()
            ElseIf Opcion = "3" Then
                ProductoController.GetInstancia().Modificar()
            ElseIf Opcion = "4" Then
                Dim id As Integer = 0
                Console.Clear()

                Console.WriteLine("Ingrese ID a buscar")
                id = Console.ReadLine()

                ProductoController.GetInstancia().Buscar(id)

            ElseIf Opcion = "5" Then
                ProductoController.GetInstancia().Listar()
            End If

        Loop While Opcion <> "0"
    End Sub

    Public Sub MenuCategorias()
        Dim Opcion As String = ""
        Do
            Console.Clear()
            Console.WriteLine("1. Agregar")
            Console.WriteLine("2. Eliminar")
            Console.WriteLine("3. Modificar")
            Console.WriteLine("4. Buscar")
            Console.WriteLine("5. Listar")
            Console.WriteLine("0. Salir")
            Opcion = Console.ReadLine()

            If Opcion = "1" Then

                CategoriaController.GetInstancia().Agregar()

            ElseIf Opcion = "2" Then

                CategoriaController.GetInstancia().Eliminar()

            ElseIf Opcion = "3" Then

                CategoriaController.GetInstancia().Modificar()

            ElseIf Opcion = "4" Then

                Dim id As Integer = 0
                Console.Clear()

                Console.WriteLine("Ingrese ID a buscar")
                id = Console.ReadLine()

                CategoriaController.GetInstancia().Buscar(id)

            ElseIf Opcion = "5" Then
                CategoriaController.GetInstancia().Listar()

            End If

        Loop While Opcion <> "0"
    End Sub

    Public Sub MenuTipoEmpaques()
        Dim Opcion As String = ""
        Do
            Console.Clear()
            Console.WriteLine("1. Agregar")
            Console.WriteLine("2. Eliminar")
            Console.WriteLine("3. Modificar")
            Console.WriteLine("4. Buscar")
            Console.WriteLine("5. Listar")
            Console.WriteLine("0. Salir")
            Opcion = Console.ReadLine()

            If Opcion = "1" Then
                TipoEmpaqueController.GetInstancia().Agregar()
            ElseIf Opcion = "2" Then
                TipoEmpaqueController.GetInstancia().Eliminar()
            ElseIf Opcion = "3" Then
                TipoEmpaqueController.GetInstancia().Modificar()
            ElseIf Opcion = "4" Then
                Dim id As Integer = 0
                Console.Clear()

                Console.WriteLine("Ingrese ID a buscar")
                id = Console.ReadLine()

                TipoEmpaqueController.GetInstancia().Buscar(id)

            ElseIf Opcion = "5" Then
                TipoEmpaqueController.GetInstancia().Listar()
            End If

        Loop While Opcion <> "0"
    End Sub

End Module
