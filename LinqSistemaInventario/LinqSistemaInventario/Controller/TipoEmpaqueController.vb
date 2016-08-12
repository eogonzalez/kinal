Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports LinqSistemaInventario

Public Class TipoEmpaqueController
    Implements IMantenimiento
    Dim DBInventarios As New SistemaInventarioContext

    Public Sub New()
    End Sub
    Private Shared Instancia As TipoEmpaqueController = Nothing

    Public Shared Function GetInstancia() As TipoEmpaqueController
        If Instancia Is Nothing Then
            Instancia = New TipoEmpaqueController
        End If
        Return Instancia
    End Function

    Public Sub Agregar() Implements IMantenimiento.Agregar

        Dim NuevoTipoEmpaque As New TipoEmpaques

        Console.WriteLine("Ingrese una descripcion: ")
        NuevoTipoEmpaque.Descripcion = Console.ReadLine
        DBInventarios.TipoEmpaques.Add(NuevoTipoEmpaque)
        DBInventarios.SaveChanges()
        Console.WriteLine("Registro almacenado!!!")
        Console.ReadLine()

    End Sub

    Public Sub Buscar(id As String) Implements IMantenimiento.Buscar
        Throw New NotImplementedException()
    End Sub

    Public Sub Buscar(Id As Integer) Implements IMantenimiento.Buscar
        Dim TipoEmpaque As TipoEmpaques = DBInventarios.TipoEmpaques.Find(Id)

        Console.WriteLine("{0} - {1}", TipoEmpaque.CodigoTipoEmpaque, TipoEmpaque.Descripcion)
        Console.ReadLine()

    End Sub

    Public Sub Eliminar() Implements IMantenimiento.Eliminar

        Console.Clear()
        Dim CodigoTipoEmpaque As Integer = 0
        Dim Opcion As String = "N"

        Console.WriteLine("Lista de Tipos de Empaque")
        Listar()
        Console.WriteLine("Ingrese el ID a eliminar======>")
        CodigoTipoEmpaque = Console.ReadLine

        Dim TipoEmpaque As TipoEmpaques = DBInventarios.TipoEmpaques.Find(CodigoTipoEmpaque)
        Console.WriteLine("Esta seguro de Eliminar el Tipo de Empaque (S/N)")

        If Opcion = "S" Then
            DBInventarios.TipoEmpaques.Remove(TipoEmpaque)
            Console.WriteLine("Registro Eliminado")
            Console.ReadLine()
        End If

    End Sub

    Public Sub Listar() Implements IMantenimiento.Listar
        Dim TiposDeEmpaque = From TE In DBInventarios.TipoEmpaques
                             Order By TE.Descripcion Select TE

        For Each TipoEmpaque In TiposDeEmpaque
            Console.WriteLine("{0} - ", TipoEmpaque.CodigoTipoEmpaque, TipoEmpaque.Descripcion)
        Next
        Console.ReadLine()

    End Sub

    Public Sub Modificar() Implements IMantenimiento.Modificar
        Dim NuevaDescripcion As String = String.Empty
        Dim CodigoTipoEmpaque As Integer = 0

        Console.Clear()
        Console.WriteLine("Lista de Tipos de Empaques")
        Listar()
        Console.WriteLine("*Nota: Solo se puede modificar la descripcion")
        Console.WriteLine("Ingrese el ID del tipo de empaque a modificar")
        CodigoTipoEmpaque = Console.ReadLine()
        Dim TipoEmpaque As TipoEmpaques = DBInventarios.TipoEmpaques.Find(CodigoTipoEmpaque)
        Console.WriteLine("Inrese la nueva descripcion:")
        NuevaDescripcion = Console.ReadLine()
        TipoEmpaque.Descripcion = NuevaDescripcion

        DBInventarios.Entry(TipoEmpaque).State = Entity.EntityState.Modified
        DBInventarios.SaveChanges()
        Console.WriteLine("Registro actualizado!!")
        Console.ReadLine()

    End Sub
End Class
