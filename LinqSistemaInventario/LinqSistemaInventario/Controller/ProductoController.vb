Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports LinqSistemaInventario

Public Class ProductoController
    Implements IMantenimiento
    Dim DBInventarios As New SistemaInventarioContext
    Public Sub New()
    End Sub
    Private Shared Instancia As ProductoController = Nothing

    Public Shared Function GetInstancia() As ProductoController
        If Instancia Is Nothing Then
            Instancia = New ProductoController
        End If
        Return Instancia
    End Function


    Public Sub Agregar() Implements IMantenimiento.Agregar

        Dim CodigoCategoria As String = String.Empty
        Dim CodigoTipoEmpaque As String = String.Empty

        Console.WriteLine("Lista de categorias:")
        CategoriaController.GetInstancia().Listar()
        Console.WriteLine("Escriba el ID de la categoria====>")
        CodigoCategoria = Console.ReadLine()
        'Dim CategoriaSeleccionado = From C In DBInventarios.Categorias
        '                            Where C.CodigoCategoria = CodigoCategoria
        '                            Select C
        Dim CategoriaSeleccionado As Categorias = DBInventarios.Categorias.Find(Convert.ToInt32(CodigoCategoria))

        Console.Clear()
        Console.WriteLine("Lista de Tipos de empaque")
        TipoEmpaqueController.GetInstancia.Listar()
        Console.WriteLine("Escriba el ID de la categoria====>")
        CodigoTipoEmpaque = Console.ReadLine()
        Dim TipoEmpaqueSeleccionado As TipoEmpaques = DBInventarios.TipoEmpaques.Find(Convert.ToInt32(CodigoTipoEmpaque))
        Console.Clear()

        Dim NuevoProducto As New Productos
        Console.WriteLine("Ingrese una descripcion: ")
        NuevoProducto.Descripcion = Console.ReadLine
        NuevoProducto.PrecioUnitario = 0.00
        NuevoProducto.Existencia = 0
        NuevoProducto.Imagen = "Imagen.png"
        NuevoProducto.Categorias = CategoriaSeleccionado
        NuevoProducto.TipoEmpaques = TipoEmpaqueSeleccionado

        DBInventarios.Productos.Add(NuevoProducto)
        DBInventarios.SaveChanges()
        Console.WriteLine("Registro alamacenado!!!")
        Console.ReadLine()

    End Sub

    Public Sub Buscar(id As String) Implements IMantenimiento.Buscar
        Throw New NotImplementedException()
    End Sub

    Public Sub Buscar(Id As Integer) Implements IMantenimiento.Buscar
        Dim Producto As Productos = DBInventarios.Productos.Find(Id)

        Console.WriteLine("{0} -Descripcion: {1} -Categoria: {2} -Precio/U: {3} -Existencia {4} -Empaque: {5}",
                          Producto.CodigoProducto,
                          Producto.Descripcion,
                          Producto.Categorias.Descripcion,
                          Producto.PrecioUnitario,
                          Producto.Existencia,
                          Producto.TipoEmpaques.Descripcion)
        Console.ReadLine()
    End Sub

    Public Sub Eliminar() Implements IMantenimiento.Eliminar
        Console.Clear()
        Dim CodigoProducto As Integer = 0
        Dim Opcion As String = "N"

        Console.WriteLine("Lista de Productos")
        Listar()
        Console.WriteLine("Ingrese el ID a eliminar=====>")
        CodigoProducto = Console.ReadLine

        Dim Producto As Productos = DBInventarios.Productos.Find(CodigoProducto)
        Console.WriteLine("Esta seguro de Eliminar el Producto (S/N)")

        If Opcion = "S" Then
            DBInventarios.Productos.Remove(Producto)
            Console.WriteLine("Registro Eliminado")
            Console.ReadLine()
        End If

    End Sub

    Public Sub Listar() Implements IMantenimiento.Listar
        Dim Productos = From P In DBInventarios.Productos Order By P.CodigoProducto
                        Select P

        Console.Clear()
        Console.WriteLine("Lista de Productos")
        For Each Producto In Productos
            Console.WriteLine("{0} -Descripcion: {1} -Categoria: {2} -Precio/U: {3} -Existencia {4} -Empaque: {5}",
                              Producto.CodigoProducto,
                              Producto.Descripcion,
                              Producto.Categorias.Descripcion,
                              Producto.PrecioUnitario,
                              Producto.Existencia,
                              Producto.TipoEmpaques.Descripcion)
        Next
        Console.ReadLine()

    End Sub

    Public Sub Modificar() Implements IMantenimiento.Modificar
        Dim NuevaDescripcion As String = String.Empty
        Dim CodigoProducto As Integer = 0

        Console.Clear()
        Console.WriteLine("Lista de productos")
        Listar()
        Console.WriteLine("*Nota: Solo se puede modificar la descripcion")
        Console.WriteLine("Ingrese el ID del producto a modificar")
        CodigoProducto = Console.ReadLine
        Dim Producto As Productos = DBInventarios.Productos.Find(CodigoProducto)
        Console.WriteLine("Ingrese la nueva descripcion:")
        NuevaDescripcion = Console.ReadLine
        Producto.Descripcion = NuevaDescripcion

        DBInventarios.Entry(Producto).State = Entity.EntityState.Modified
        DBInventarios.SaveChanges()
        Console.WriteLine("Registro actualizado!!")
        Console.ReadLine()

    End Sub
End Class
