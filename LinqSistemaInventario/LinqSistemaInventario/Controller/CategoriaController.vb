Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports LinqSistemaInventario

Public Class CategoriaController
    Implements IMantenimiento
    Dim DBInventarios As New SistemaInventarioContext

    Public Sub New()
    End Sub
    Private Shared Instancia As CategoriaController = Nothing

    Public Shared Function GetInstancia() As CategoriaController
        If Instancia Is Nothing Then
            Instancia = New CategoriaController
        End If
        Return Instancia
    End Function

    Public Sub Agregar() Implements IMantenimiento.Agregar
        Dim NuevaCategoria As New Categorias

        Console.WriteLine("Ingrese una descripcion: ")
        NuevaCategoria.Descripcion = Console.ReadLine
        DBInventarios.Categorias.Add(NuevaCategoria)
        DBInventarios.SaveChanges()
        Console.WriteLine("Registro almacenado!!!")
        Console.ReadLine()

    End Sub

    Public Sub Buscar(id As String) Implements IMantenimiento.Buscar
        Throw New NotImplementedException()
    End Sub

    Public Sub Buscar(Id As Integer) Implements IMantenimiento.Buscar
        Dim Categoria As Categorias = DBInventarios.Categorias.Find(Id)

        Console.WriteLine("{0} - {1}", Categoria.CodigoCategoria, Categoria.Descripcion)
        Console.ReadLine()
    End Sub

    Public Sub Eliminar() Implements IMantenimiento.Eliminar

        Console.Clear()
        Dim CodigoCategoria As Integer = 0
        Dim Opcion As String = "N"

        Console.WriteLine("Lista de Categorias")
        Listar()
        Console.WriteLine("Ingrese el ID a eliminar======>")
        CodigoCategoria = Console.ReadLine

        Dim Categoria As Categorias = DBInventarios.Categorias.Find(CodigoCategoria)
        Console.WriteLine("Esta seguro de Eliminar Categoria (S/N)")

        If Opcion = "S" Then
            DBInventarios.Categorias.Remove(Categoria)
            Console.WriteLine("Registro Eliminado")
            Console.ReadLine()
        End If

    End Sub

    Public Sub Listar() Implements IMantenimiento.Listar
        Dim Categorias = From C In DBInventarios.Categorias Order By C.Descripcion
                         Select C

        For Each Categoria In Categorias
            Console.WriteLine("{0} - {1}", Categoria.CodigoCategoria, Categoria.Descripcion)
        Next
        Console.ReadLine()

    End Sub

    Public Sub Modificar() Implements IMantenimiento.Modificar
        Dim NuevaDescripcion As String = String.Empty
        Dim CodigoCategoria As Integer = 0

        Console.Clear()
        Console.WriteLine("Lista de Categorias")
        Listar()
        Console.WriteLine("*Nota: Solo se puede modificar la descripcion")
        Console.WriteLine("Ingrese el ID de la categoria a modificar")
        CodigoCategoria = Console.ReadLine()
        Dim Categoria As Categorias = DBInventarios.Categorias.Find(CodigoCategoria)
        Console.WriteLine("Inrese la nueva descripcion:")
        NuevaDescripcion = Console.ReadLine()
        Categoria.Descripcion = NuevaDescripcion

        DBInventarios.Entry(Categoria).State = Entity.EntityState.Modified
        DBInventarios.SaveChanges()
        Console.WriteLine("Registro actualizado!!")
        Console.ReadLine()
    End Sub
End Class
