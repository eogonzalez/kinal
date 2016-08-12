--DROP TRIGGER tgr_ActualizarTotalDelete
--GO

CREATE TRIGGER tgr_ActualizarTotalDelete ON DetalleFactura FOR INSERT,DELETE
AS
BEGIN
	DECLARE @SubTotal DECIMAL(10,2)
	DECLARE @Total DECIMAL(10,2)
	DECLARE @CodigoFactura int

	IF EXISTS(SELECT * FROM Inserted ) 
		begin

			SET @CodigoFactura = (SELECT codigoFactura from INSERTED)
			SET @SubTotal = (SELECT	INSERTED.precio * INSERTED.cantidad from INSERTED)
			SET @Total = (SELECT Facturas.Total FROM	Facturas WHERE	Facturas.CodigoFactura = @CodigoFactura)
			SET @Total = @Total+@SubTotal
		END
	ELSE IF EXISTS(SELECT  * FROM DELETED)
		BEGIN
			SET @CodigoFactura = (SELECT codigoFactura from DELETED)
			SET @SubTotal = (SELECT	DELETED.precio * DELETED.cantidad from DELETED)
			SET @Total = (SELECT Facturas.Total FROM	Facturas WHERE	Facturas.CodigoFactura = @CodigoFactura)
			SET @Total = @Total-@SubTotal
		END
	
	UPDATE Facturas SET Facturas.Total = @Total WHERE Facturas.CodigoFactura = @CodigoFactura
		
END	

SELECT * FROM Facturas 
SELECT * FROM DetalleFactura 
SELECT * FROM Clientes 

SELECT *
 FROM Productos p