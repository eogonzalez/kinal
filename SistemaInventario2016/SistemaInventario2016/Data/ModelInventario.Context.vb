﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class InventarioContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=InventarioContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Categorias() As DbSet(Of Categorias)
    Public Overridable Property Clientes() As DbSet(Of Clientes)
    Public Overridable Property Compras() As DbSet(Of Compras)
    Public Overridable Property DetalleCompra() As DbSet(Of DetalleCompra)
    Public Overridable Property DetalleFactura() As DbSet(Of DetalleFactura)
    Public Overridable Property DireccionClientes() As DbSet(Of DireccionClientes)
    Public Overridable Property DireccionProveedor() As DbSet(Of DireccionProveedor)
    Public Overridable Property EmailClientes() As DbSet(Of EmailClientes)
    Public Overridable Property EmailProveedor() As DbSet(Of EmailProveedor)
    Public Overridable Property Facturas() As DbSet(Of Facturas)
    Public Overridable Property Inventarios() As DbSet(Of Inventarios)
    Public Overridable Property Parametros() As DbSet(Of Parametros)
    Public Overridable Property Productos() As DbSet(Of Productos)
    Public Overridable Property Proveedores() As DbSet(Of Proveedores)
    Public Overridable Property sysdiagrams() As DbSet(Of sysdiagrams)
    Public Overridable Property TelefonoClientes() As DbSet(Of TelefonoClientes)
    Public Overridable Property TelefonoProveedor() As DbSet(Of TelefonoProveedor)
    Public Overridable Property TipoEmpaques() As DbSet(Of TipoEmpaques)
    Public Overridable Property TipoRegistros() As DbSet(Of TipoRegistros)

    Public Overridable Function sp_AgregaCategoria(descripcion As String) As Integer
        Dim descripcionParameter As ObjectParameter = If(descripcion IsNot Nothing, New ObjectParameter("Descripcion", descripcion), New ObjectParameter("Descripcion", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_AgregaCategoria", descripcionParameter)
    End Function

    Public Overridable Function sp_AgregarCompra(numeroDocumento As Nullable(Of Integer), fecha As Nullable(Of Date), codigoProveedor As Nullable(Of Integer), totalCompra As Nullable(Of Decimal)) As Integer
        Dim numeroDocumentoParameter As ObjectParameter = If(numeroDocumento.HasValue, New ObjectParameter("NumeroDocumento", numeroDocumento), New ObjectParameter("NumeroDocumento", GetType(Integer)))

        Dim fechaParameter As ObjectParameter = If(fecha.HasValue, New ObjectParameter("Fecha", fecha), New ObjectParameter("Fecha", GetType(Date)))

        Dim codigoProveedorParameter As ObjectParameter = If(codigoProveedor.HasValue, New ObjectParameter("CodigoProveedor", codigoProveedor), New ObjectParameter("CodigoProveedor", GetType(Integer)))

        Dim totalCompraParameter As ObjectParameter = If(totalCompra.HasValue, New ObjectParameter("TotalCompra", totalCompra), New ObjectParameter("TotalCompra", GetType(Decimal)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_AgregarCompra", numeroDocumentoParameter, fechaParameter, codigoProveedorParameter, totalCompraParameter)
    End Function

    Public Overridable Function sp_AgregarDetalleCompra(numeroDocumento As Nullable(Of Integer), codigoProducto As Nullable(Of Integer), cantidad As Nullable(Of Integer), precio As Nullable(Of Decimal)) As Integer
        Dim numeroDocumentoParameter As ObjectParameter = If(numeroDocumento.HasValue, New ObjectParameter("NumeroDocumento", numeroDocumento), New ObjectParameter("NumeroDocumento", GetType(Integer)))

        Dim codigoProductoParameter As ObjectParameter = If(codigoProducto.HasValue, New ObjectParameter("CodigoProducto", codigoProducto), New ObjectParameter("CodigoProducto", GetType(Integer)))

        Dim cantidadParameter As ObjectParameter = If(cantidad.HasValue, New ObjectParameter("Cantidad", cantidad), New ObjectParameter("Cantidad", GetType(Integer)))

        Dim precioParameter As ObjectParameter = If(precio.HasValue, New ObjectParameter("Precio", precio), New ObjectParameter("Precio", GetType(Decimal)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_AgregarDetalleCompra", numeroDocumentoParameter, codigoProductoParameter, cantidadParameter, precioParameter)
    End Function

    Public Overridable Function sp_AgregarInventario(codigoTipoRegistro As Nullable(Of Integer), salidas As Nullable(Of Integer), entradas As Nullable(Of Integer), codigoProducto As Nullable(Of Integer), precio As Nullable(Of Decimal), fecha As Nullable(Of Date)) As Integer
        Dim codigoTipoRegistroParameter As ObjectParameter = If(codigoTipoRegistro.HasValue, New ObjectParameter("CodigoTipoRegistro", codigoTipoRegistro), New ObjectParameter("CodigoTipoRegistro", GetType(Integer)))

        Dim salidasParameter As ObjectParameter = If(salidas.HasValue, New ObjectParameter("Salidas", salidas), New ObjectParameter("Salidas", GetType(Integer)))

        Dim entradasParameter As ObjectParameter = If(entradas.HasValue, New ObjectParameter("Entradas", entradas), New ObjectParameter("Entradas", GetType(Integer)))

        Dim codigoProductoParameter As ObjectParameter = If(codigoProducto.HasValue, New ObjectParameter("CodigoProducto", codigoProducto), New ObjectParameter("CodigoProducto", GetType(Integer)))

        Dim precioParameter As ObjectParameter = If(precio.HasValue, New ObjectParameter("Precio", precio), New ObjectParameter("Precio", GetType(Decimal)))

        Dim fechaParameter As ObjectParameter = If(fecha.HasValue, New ObjectParameter("Fecha", fecha), New ObjectParameter("Fecha", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_AgregarInventario", codigoTipoRegistroParameter, salidasParameter, entradasParameter, codigoProductoParameter, precioParameter, fechaParameter)
    End Function

    Public Overridable Function sp_AgregarProducto(descripcion As String, precioUnitario As Nullable(Of Decimal), existencia As Nullable(Of Integer), imagen As String, codigoCategoria As Nullable(Of Integer), codigoTipoEmpaque As Nullable(Of Integer)) As Integer
        Dim descripcionParameter As ObjectParameter = If(descripcion IsNot Nothing, New ObjectParameter("Descripcion", descripcion), New ObjectParameter("Descripcion", GetType(String)))

        Dim precioUnitarioParameter As ObjectParameter = If(precioUnitario.HasValue, New ObjectParameter("PrecioUnitario", precioUnitario), New ObjectParameter("PrecioUnitario", GetType(Decimal)))

        Dim existenciaParameter As ObjectParameter = If(existencia.HasValue, New ObjectParameter("Existencia", existencia), New ObjectParameter("Existencia", GetType(Integer)))

        Dim imagenParameter As ObjectParameter = If(imagen IsNot Nothing, New ObjectParameter("Imagen", imagen), New ObjectParameter("Imagen", GetType(String)))

        Dim codigoCategoriaParameter As ObjectParameter = If(codigoCategoria.HasValue, New ObjectParameter("CodigoCategoria", codigoCategoria), New ObjectParameter("CodigoCategoria", GetType(Integer)))

        Dim codigoTipoEmpaqueParameter As ObjectParameter = If(codigoTipoEmpaque.HasValue, New ObjectParameter("CodigoTipoEmpaque", codigoTipoEmpaque), New ObjectParameter("CodigoTipoEmpaque", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_AgregarProducto", descripcionParameter, precioUnitarioParameter, existenciaParameter, imagenParameter, codigoCategoriaParameter, codigoTipoEmpaqueParameter)
    End Function

    Public Overridable Function sp_alterdiagram(diagramname As String, owner_id As Nullable(Of Integer), version As Nullable(Of Integer), definition As Byte()) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Dim versionParameter As ObjectParameter = If(version.HasValue, New ObjectParameter("version", version), New ObjectParameter("version", GetType(Integer)))

        Dim definitionParameter As ObjectParameter = If(definition IsNot Nothing, New ObjectParameter("definition", definition), New ObjectParameter("definition", GetType(Byte())))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter)
    End Function

    Public Overridable Function sp_ConsultarCategorias() As ObjectResult(Of String)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("sp_ConsultarCategorias")
    End Function

    Public Overridable Function sp_ConsultarFacturas() As ObjectResult(Of sp_ConsultarFacturas_Result)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ConsultarFacturas_Result)("sp_ConsultarFacturas")
    End Function

    Public Overridable Function sp_ConsultarProductos() As ObjectResult(Of sp_ConsultarProductos_Result)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ConsultarProductos_Result)("sp_ConsultarProductos")
    End Function

    Public Overridable Function sp_creatediagram(diagramname As String, owner_id As Nullable(Of Integer), version As Nullable(Of Integer), definition As Byte()) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Dim versionParameter As ObjectParameter = If(version.HasValue, New ObjectParameter("version", version), New ObjectParameter("version", GetType(Integer)))

        Dim definitionParameter As ObjectParameter = If(definition IsNot Nothing, New ObjectParameter("definition", definition), New ObjectParameter("definition", GetType(Byte())))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter)
    End Function

    Public Overridable Function sp_dropdiagram(diagramname As String, owner_id As Nullable(Of Integer)) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter)
    End Function

    Public Overridable Function sp_EliminarCategoria(codigoCategoria As Nullable(Of Integer)) As Integer
        Dim codigoCategoriaParameter As ObjectParameter = If(codigoCategoria.HasValue, New ObjectParameter("CodigoCategoria", codigoCategoria), New ObjectParameter("CodigoCategoria", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_EliminarCategoria", codigoCategoriaParameter)
    End Function

    Public Overridable Function sp_helpdiagramdefinition(diagramname As String, owner_id As Nullable(Of Integer)) As ObjectResult(Of sp_helpdiagramdefinition_Result)
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_helpdiagramdefinition_Result)("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter)
    End Function

    Public Overridable Function sp_helpdiagrams(diagramname As String, owner_id As Nullable(Of Integer)) As ObjectResult(Of sp_helpdiagrams_Result)
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_helpdiagrams_Result)("sp_helpdiagrams", diagramnameParameter, owner_idParameter)
    End Function

    Public Overridable Function sp_ModificarCategoria(codigoCategoria As Nullable(Of Integer), descripcion As String) As Integer
        Dim codigoCategoriaParameter As ObjectParameter = If(codigoCategoria.HasValue, New ObjectParameter("CodigoCategoria", codigoCategoria), New ObjectParameter("CodigoCategoria", GetType(Integer)))

        Dim descripcionParameter As ObjectParameter = If(descripcion IsNot Nothing, New ObjectParameter("Descripcion", descripcion), New ObjectParameter("Descripcion", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_ModificarCategoria", codigoCategoriaParameter, descripcionParameter)
    End Function

    Public Overridable Function sp_renamediagram(diagramname As String, owner_id As Nullable(Of Integer), new_diagramname As String) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Dim new_diagramnameParameter As ObjectParameter = If(new_diagramname IsNot Nothing, New ObjectParameter("new_diagramname", new_diagramname), New ObjectParameter("new_diagramname", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter)
    End Function

    Public Overridable Function sp_upgraddiagrams() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_upgraddiagrams")
    End Function

End Class
