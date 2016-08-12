create procedure sp_AgregarInventario
	@CodigoTipoRegistro int,
	@Salidas int,
	@Entradas int,
	@CodigoProduto int,
	@Precio decimal (10,2),
	@Fecha date
as
	insert into Inventarios values(@CodigoTipoRegistro, @Salidas, 
	@Entradas, @CodigoProducto, @Precio, @Fecha)

create trigger tr_RegistrarCompra on DetalleCompra for insert
as 
begin
	declare @NumeroDocumento int
	declare @CodigoTipoRegistro int
	declare @Salidas int
	declare @Entradas int
	declare @CodigoProduto int
	declare @Precio decimal (10,2)
	declare @Fecha date
	
	set @NumeroDocumento = (select NumeroDocumento from inserted)
	set @CodigoTipoRegistro = 2
	set @salidas = 0
	set @Entradas = (select cantidad from inserted)
	set @CodigoProducto = (select CodigoProducto from inserted)
	set @Precio = (select Precio from inserted)
	set @Fecha = getdate()


	execute sp_AgregarInventario(@CodigoTipoRegistro,@Salidas,
	@Entradas,@CodigoProduto,@Precio,
	@Fecha)
	
	update compras set TotalCompra = TotalCompra + (@Entradas*@Precio)
	where NumeroDocumento = @NumeroDocumento
end

create procedure sp_AgregarCompra 
	@NumeroDocumento int,
	@Fecha date, 
	@CodigoProveedor int,
	@TotalCompra decimal(10,2)
as
	insert into Compras values (@NumeroDocumento, @Fecha, 
		@CodigoProveedor, @TotalCompra)
		
create procedure sp_AgregarDetalleCompra
	@NumeroDocumento int,
	@CodigoProducto int,
	@Cantidad int,
	@Precio decimal(10,2)
as
	INSERT into detallecompra values (@NumeroDocumento, 
		@CodigoProducto, @Cantidad, @Precio, @Cantidad*@Precio)
