use ventas2016i156g


CREATE TABLE [Clientes](
	[CodigoCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nit] [varchar](64) NOT NULL,
	[Nombre] [varchar](128) NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [Direcciones](
	[CodigoCliente] [int] NOT NULL,
	[Direccion] [varchar](128) NULL
) ON [PRIMARY]

GO

CREATE TABLE [Emails](
	[CodigoCliente] [int] NOT NULL,
	[Email] [varchar](128) NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Telefonos](
	[CodigoCliente] [int] NOT NULL,
	[Telefono] [varchar](128) NOT NULL
) ON [PRIMARY]

GO

-- Modificaciones a la base de datos
alter table clientes add primary key (CodigoCliente);
alter table direcciones add CodigoDireccion int identity(1,1) primary key;
alter table Telefonos add codigoTelefono int identity(1,1) primary key;
alter table Emails add CodigoEmail int identity(1,1) primary key;

--Relaciones entre tablas
ALTER TABLE Telefonos
Add Constraint FK_Telefonos_Cliente Foreign key (CodigoCliente) references Clientes(CodigoCliente);


ALTER TABLE Direcciones
Add Constraint FK_Direcciones_Cliente Foreign key (CodigoCliente) references Clientes(CodigoCliente);


ALTER TABLE Emails
Add Constraint FK_Emails_Cliente Foreign key (CodigoCliente) references Clientes(CodigoCliente);

