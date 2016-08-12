CREATE Procedure [dbo].[sp_ModificarCategoria]
@CodigoCategoria int, @Descripcion as varchar(128)
as
	update Categorias
	set Descripcion = @Descripcion
	where CodigoCategoria = @CodigoCategoria



GO


Create Procedure [dbo].[sp_EliminarCategoria]
@CodigoCategoria int
as
	Delete from Categorias
	where CodigoCategoria = @CodigoCategoria


GO

create procedure [dbo].[sp_ConsultarProductos] 
as
 select productos.CodigoProducto, 
	Productos.descripcion,
	productos.PrecioUnitario,
	productos.PrecioDocena,
	productos.PrecioMayor,
	productos.existencia,
	productos.imagen,
	productos.codigoCategoria,
	categorias.descripcion,
	productos.codigoTipoEmpaque,
	TipoEmpaques.Descripcion
	from Productos inner join Categorias on Productos.codigoCategoria = categorias.codigoCategoria
	inner join tipoEmpaques on productos.CodigoTipoEmpaque = tipoEmpaques.codigoTipoEmpaque 

GO

create procedure [dbo].[sp_ConsultarFacturas]
as
select Facturas.CodigoFactura as Codigo, Facturas.Numerofactura as 'Numero Factura',
Facturas.Serie, Facturas.Fechafactura as 'Fecha', Facturas.CodigoCliente as 'Cliente', 
Clientes.Nombre, Facturas.Total
from Facturas inner join clientes on Facturas.CodigoCliente = Clientes.CodigoCliente
order by Facturas.FechaFactura, Facturas.NumeroFactura, clientes.Nombre



GO

Create procedure [dbo].[sp_ConsultarCategorias]
as
	select categorias.descripcion from categorias


GO

create procedure [dbo].[sp_AgregarProducto] @Descripcion varchar(128),
	@PrecioUnitario decimal(10,2), @Existencia int,
	@Imagen varchar(64), @CodigoCategoria int, @CodigoTipoEmpaque int
as
	insert into productos (descripcion,precioUnitario,existencia,imagen,codigoCategoria,codigotipoEmpaque) 
	values (@Descripcion,@PrecioUnitario,@Existencia,@Imagen,@CodigoCategoria,@codigoTipoEmpaque)


GO

Create Procedure [dbo].[sp_AgregaCategoria]
@Descripcion as varchar(128)
as
	INSERT INTO CATEGORIAS(Descripcion)
	VALUES (@Descripcion)

GO
