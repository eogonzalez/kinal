USE [master]
GO
/****** Object:  Database [Inventario2016I147G_1]    Script Date: 11/06/2016 09:50:50 a.m. ******/
CREATE DATABASE [Inventario2016I147G_1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventario2016I147G_1', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Inventario2016I147G_1.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inventario2016I147G_1_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Inventario2016I147G_1_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Inventario2016I147G_1] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventario2016I147G_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventario2016I147G_1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Inventario2016I147G_1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventario2016I147G_1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventario2016I147G_1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Inventario2016I147G_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventario2016I147G_1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Inventario2016I147G_1] SET  MULTI_USER 
GO
ALTER DATABASE [Inventario2016I147G_1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventario2016I147G_1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventario2016I147G_1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventario2016I147G_1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Inventario2016I147G_1]
GO
/****** Object:  UserDefinedFunction [dbo].[CalcularPrecioCosto]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[CalcularPrecioCosto](@Precio decimal(10,2))
returns decimal(10,2)
as
begin
	declare @PrecioCosto decimal(10,2)
	declare @Utilidad decimal (5,2)
	set @Utilidad = (select utilidad from parametros) + 1
	set @PrecioCosto = @Precio / @Utilidad
	return @PrecioCosto
end
GO
/****** Object:  UserDefinedFunction [dbo].[CalcularPrecioUnitario]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[CalcularPrecioUnitario](@PrecioCosto decimal(10,2))
returns decimal(10,2)
as
begin
	Declare @NuevoPrecio decimal(10,2)
	Declare @Iva decimal(5,2)
	Declare @Utilidad decimal(5,2)
	set @Iva = (select iva from parametros) + 1
	set @Utilidad = (select utilidad from parametros)
	set @NuevoPrecio =  ((@PrecioCosto/@Iva) + ((@PrecioCosto/@Iva) * @Utilidad)) * @iva 
	return @NuevoPrecio
end
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[CodigoCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[CodigoCliente] [int] IDENTITY(1,1) NOT NULL,
	[NIT] [varchar](128) NOT NULL,
	[DPI] [varchar](128) NULL,
	[Nombre] [varchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[NumeroDocumento] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[CodigoProveedor] [int] NULL,
	[TotalCompra] [numeric](10, 2) NULL CONSTRAINT [DF__Compras__TotalCo__10566F31]  DEFAULT ((0.00)),
 CONSTRAINT [PK__Compras__A4202589726D2661] PRIMARY KEY CLUSTERED 
(
	[NumeroDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[CodigoDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[NumeroDocumento] [int] NOT NULL,
	[CodigoProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [numeric](10, 2) NULL DEFAULT ((0.00)),
	[SubTotal] [numeric](10, 2) NULL DEFAULT ((0.00)),
PRIMARY KEY CLUSTERED 
(
	[CodigoDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[CodigoFacturaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[CodigoFactura] [int] NOT NULL,
	[CodigoProducto] [int] NULL,
	[Precio] [numeric](10, 2) NULL,
	[Cantidad] [int] NULL,
	[SubTotal] [numeric](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoFacturaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DireccionClientes]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DireccionClientes](
	[CodigoDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [varchar](128) NOT NULL,
	[Descripcion] [varchar](128) NULL,
	[CodigoCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DireccionProveedor]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DireccionProveedor](
	[CodigoDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [varchar](128) NOT NULL,
	[Descripcion] [varchar](128) NULL,
	[CodigoProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailClientes]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailClientes](
	[CodigoEmail] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Descripcion] [varchar](128) NULL,
	[CodigoCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailProveedor]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailProveedor](
	[CodigoEmail] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Descripcion] [varchar](128) NULL,
	[CodigoProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facturas](
	[CodigoFactura] [int] IDENTITY(1,1) NOT NULL,
	[NumeroFactura] [int] NOT NULL,
	[Serie] [varchar](50) NOT NULL,
	[FechaFactura] [datetime] NULL,
	[CodigoCliente] [int] NULL,
	[Total] [numeric](10, 2) NULL DEFAULT ((0.00)),
PRIMARY KEY CLUSTERED 
(
	[CodigoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[Correlativo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoTipoRegistro] [int] NULL,
	[Salidas] [int] NULL DEFAULT ((0)),
	[Entradas] [int] NULL DEFAULT ((0)),
	[CodigoProducto] [int] NULL,
	[Precio] [numeric](10, 2) NULL DEFAULT ((0.00)),
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Correlativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[idParametro] [int] IDENTITY(1,1) NOT NULL,
	[iva] [decimal](5, 2) NULL,
	[utilidad] [decimal](5, 2) NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[idParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[CodigoProducto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](128) NOT NULL,
	[PrecioUnitario] [numeric](10, 2) NULL DEFAULT ((0.00)),
	[PrecioDocena] [numeric](10, 2) NULL DEFAULT ((0.00)),
	[PrecioMayor] [numeric](10, 2) NULL DEFAULT ((0.00)),
	[Existencia] [int] NULL,
	[Imagen] [varchar](128) NULL DEFAULT ('imagen.png'),
	[CodigoCategoria] [int] NOT NULL,
	[CodigoTipoEmpaque] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedores](
	[CodigoProveedor] [int] IDENTITY(1,1) NOT NULL,
	[NIT] [varchar](128) NOT NULL,
	[RazonSocial] [varchar](128) NULL,
	[PaginaWeb] [varchar](128) NULL,
	[ContactoPrincipal] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TelefonoClientes]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TelefonoClientes](
	[CodigoTelefono] [int] IDENTITY(1,1) NOT NULL,
	[NumeroTelefono] [varchar](128) NOT NULL,
	[Descripcion] [varchar](128) NULL,
	[CodigoCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TelefonoProveedor]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TelefonoProveedor](
	[CodigoTelefono] [int] IDENTITY(1,1) NOT NULL,
	[NumeroTelefono] [varchar](128) NOT NULL,
	[Descripcion] [varchar](128) NULL,
	[CodigoProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoEmpaques]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoEmpaques](
	[CodigoTipoEmpaque] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoTipoEmpaque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoRegistros]    Script Date: 11/06/2016 09:50:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoRegistros](
	[CodigoTipoRegistro] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoTipoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([CodigoCategoria], [Descripcion]) VALUES (1, N'Herrerias')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Descripcion]) VALUES (3, N'Jueguetes')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Descripcion]) VALUES (4, N'Joyas')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Descripcion]) VALUES (5, N'Adornos')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Descripcion]) VALUES (6, N'Ferreteria')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([CodigoCliente], [NIT], [DPI], [Nombre]) VALUES (1, N'3894140-6', N'248439012010101', N'Juan Perez')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
INSERT [dbo].[Compras] ([NumeroDocumento], [Fecha], [CodigoProveedor], [TotalCompra]) VALUES (223344, CAST(N'2016-03-16 00:00:00.000' AS DateTime), 1, CAST(2000.00 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[DetalleCompra] ON 

INSERT [dbo].[DetalleCompra] ([CodigoDetalleCompra], [NumeroDocumento], [CodigoProducto], [Cantidad], [Precio], [SubTotal]) VALUES (1, 223344, 3, 100, CAST(20.00 AS Numeric(10, 2)), CAST(2000.00 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[DetalleCompra] OFF
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([CodigoFactura], [NumeroFactura], [Serie], [FechaFactura], [CodigoCliente], [Total]) VALUES (1, 200, N'A', CAST(N'2016-01-01 00:00:00.000' AS DateTime), 1, CAST(0.00 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[Facturas] OFF
SET IDENTITY_INSERT [dbo].[Inventarios] ON 

INSERT [dbo].[Inventarios] ([Correlativo], [CodigoTipoRegistro], [Salidas], [Entradas], [CodigoProducto], [Precio], [Fecha]) VALUES (1, 2, 0, 200, 1, CAST(10.00 AS Numeric(10, 2)), CAST(N'2015-08-13 00:00:00.000' AS DateTime))
INSERT [dbo].[Inventarios] ([Correlativo], [CodigoTipoRegistro], [Salidas], [Entradas], [CodigoProducto], [Precio], [Fecha]) VALUES (2, 2, 0, 100, 1, CAST(12.00 AS Numeric(10, 2)), CAST(N'2016-08-13 00:00:00.000' AS DateTime))
INSERT [dbo].[Inventarios] ([Correlativo], [CodigoTipoRegistro], [Salidas], [Entradas], [CodigoProducto], [Precio], [Fecha]) VALUES (3, 2, 0, 100, 3, CAST(20.00 AS Numeric(10, 2)), CAST(N'2016-06-11 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Inventarios] OFF
SET IDENTITY_INSERT [dbo].[Parametros] ON 

INSERT [dbo].[Parametros] ([idParametro], [iva], [utilidad]) VALUES (1, CAST(0.12 AS Decimal(5, 2)), CAST(0.30 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Parametros] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([CodigoProducto], [Descripcion], [PrecioUnitario], [PrecioDocena], [PrecioMayor], [Existencia], [Imagen], [CodigoCategoria], [CodigoTipoEmpaque]) VALUES (1, N'Martillo Dopler', CAST(13.87 AS Numeric(10, 2)), CAST(0.00 AS Numeric(10, 2)), CAST(0.00 AS Numeric(10, 2)), 300, N'martillo.png', 6, 4)
INSERT [dbo].[Productos] ([CodigoProducto], [Descripcion], [PrecioUnitario], [PrecioDocena], [PrecioMayor], [Existencia], [Imagen], [CodigoCategoria], [CodigoTipoEmpaque]) VALUES (3, N'Anillos Pleky', CAST(26.00 AS Numeric(10, 2)), CAST(0.00 AS Numeric(10, 2)), CAST(0.00 AS Numeric(10, 2)), 100, N'anillo.png', 4, 4)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([CodigoProveedor], [NIT], [RazonSocial], [PaginaWeb], [ContactoPrincipal]) VALUES (1, N'3894140-6', N'Corporacion Monte Perdido', N'www.corpo.com', N'Juan Perez')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
SET IDENTITY_INSERT [dbo].[TipoEmpaques] ON 

INSERT [dbo].[TipoEmpaques] ([CodigoTipoEmpaque], [Descripcion]) VALUES (1, N'Caja de 12 unidas')
INSERT [dbo].[TipoEmpaques] ([CodigoTipoEmpaque], [Descripcion]) VALUES (2, N'Empaque plastico')
INSERT [dbo].[TipoEmpaques] ([CodigoTipoEmpaque], [Descripcion]) VALUES (3, N'Caja de 24 unidades')
INSERT [dbo].[TipoEmpaques] ([CodigoTipoEmpaque], [Descripcion]) VALUES (4, N'Unitario')
SET IDENTITY_INSERT [dbo].[TipoEmpaques] OFF
SET IDENTITY_INSERT [dbo].[TipoRegistros] ON 

INSERT [dbo].[TipoRegistros] ([CodigoTipoRegistro], [Descripcion]) VALUES (1, N'Ventas')
INSERT [dbo].[TipoRegistros] ([CodigoTipoRegistro], [Descripcion]) VALUES (2, N'Compras')
SET IDENTITY_INSERT [dbo].[TipoRegistros] OFF
ALTER TABLE [dbo].[DetalleFactura] ADD  DEFAULT ((0.00)) FOR [Precio]
GO
ALTER TABLE [dbo].[DetalleFactura] ADD  DEFAULT ((0.00)) FOR [SubTotal]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_CompraProveedor] FOREIGN KEY([CodigoProveedor])
REFERENCES [dbo].[Proveedores] ([CodigoProveedor])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_CompraProveedor]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_CompraProductos] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_CompraProductos]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Compra] FOREIGN KEY([NumeroDocumento])
REFERENCES [dbo].[Compras] ([NumeroDocumento])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Compra]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([CodigoFactura])
REFERENCES [dbo].[Facturas] ([CodigoFactura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_FacturaProductos] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_FacturaProductos]
GO
ALTER TABLE [dbo].[DireccionClientes]  WITH CHECK ADD  CONSTRAINT [FK_DireccionCliente] FOREIGN KEY([CodigoCliente])
REFERENCES [dbo].[Clientes] ([CodigoCliente])
GO
ALTER TABLE [dbo].[DireccionClientes] CHECK CONSTRAINT [FK_DireccionCliente]
GO
ALTER TABLE [dbo].[DireccionProveedor]  WITH CHECK ADD  CONSTRAINT [FK_DireccionProveedor] FOREIGN KEY([CodigoProveedor])
REFERENCES [dbo].[Proveedores] ([CodigoProveedor])
GO
ALTER TABLE [dbo].[DireccionProveedor] CHECK CONSTRAINT [FK_DireccionProveedor]
GO
ALTER TABLE [dbo].[EmailClientes]  WITH CHECK ADD  CONSTRAINT [FK_EmailCliente] FOREIGN KEY([CodigoCliente])
REFERENCES [dbo].[Clientes] ([CodigoCliente])
GO
ALTER TABLE [dbo].[EmailClientes] CHECK CONSTRAINT [FK_EmailCliente]
GO
ALTER TABLE [dbo].[EmailProveedor]  WITH CHECK ADD  CONSTRAINT [FK_EmailProveedor] FOREIGN KEY([CodigoProveedor])
REFERENCES [dbo].[Proveedores] ([CodigoProveedor])
GO
ALTER TABLE [dbo].[EmailProveedor] CHECK CONSTRAINT [FK_EmailProveedor]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_FacturaCliente] FOREIGN KEY([CodigoCliente])
REFERENCES [dbo].[Clientes] ([CodigoCliente])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_FacturaCliente]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_InventarioProductos] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_InventarioProductos]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_TipoRegistro_Inventario] FOREIGN KEY([CodigoTipoRegistro])
REFERENCES [dbo].[TipoRegistros] ([CodigoTipoRegistro])
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_TipoRegistro_Inventario]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_ProductosCategoria] FOREIGN KEY([CodigoCategoria])
REFERENCES [dbo].[Categorias] ([CodigoCategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_ProductosCategoria]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_ProductosTipoEmpaque] FOREIGN KEY([CodigoTipoEmpaque])
REFERENCES [dbo].[TipoEmpaques] ([CodigoTipoEmpaque])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_ProductosTipoEmpaque]
GO
ALTER TABLE [dbo].[TelefonoClientes]  WITH CHECK ADD  CONSTRAINT [FK_TelefonoCliente] FOREIGN KEY([CodigoCliente])
REFERENCES [dbo].[Clientes] ([CodigoCliente])
GO
ALTER TABLE [dbo].[TelefonoClientes] CHECK CONSTRAINT [FK_TelefonoCliente]
GO
ALTER TABLE [dbo].[TelefonoProveedor]  WITH CHECK ADD  CONSTRAINT [FK_TelefonoProveedor] FOREIGN KEY([CodigoProveedor])
REFERENCES [dbo].[Proveedores] ([CodigoProveedor])
GO
ALTER TABLE [dbo].[TelefonoProveedor] CHECK CONSTRAINT [FK_TelefonoProveedor]
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregaCategoria]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_AgregaCategoria]
@Descripcion as varchar(128)
as
	INSERT INTO CATEGORIAS(Descripcion)
	VALUES (@Descripcion)

--select * from categorias

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarCompra]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AgregarCompra] @NumeroDocumento int,
	@Fecha Date, @CodigoProveedor int, @TotalCompra decimal (10,2)
as
	insert into Compras values (@NumeroDocumento,@Fecha,
		@CodigoProveedor,@TotalCompra)
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarDetalleCompra]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AgregarDetalleCompra] @NumeroDocumento int,
	@CodigoProducto int, @Cantidad int, @Precio decimal(10,2)
as
	insert into detallecompra values (@NumeroDocumento,
		@CodigoProducto,@Cantidad,@Precio,@Cantidad * @Precio)

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarInventario]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AgregarInventario] 
	@CodigoTipoRegistro int,
	@Salidas int,
	@Entradas int,
	@CodigoProducto int,
	@Precio decimal(10,2),
	@Fecha date
as
	insert into Inventarios values(@CodigoTipoRegistro,@Salidas,
		@Entradas,@CodigoProducto,@Precio,@Fecha)

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarProducto]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AgregarProducto] @Descripcion varchar(128),
	@PrecioUnitario decimal(10,2), @Existencia int,
	@Imagen varchar(64), @CodigoCategoria int, @CodigoTipoEmpaque int
as
	insert into productos (descripcion,precioUnitario,existencia,imagen,codigoCategoria,codigotipoEmpaque) 
	values (@Descripcion,@PrecioUnitario,@Existencia,@Imagen,@CodigoCategoria,@codigoTipoEmpaque)

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarCategorias]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[sp_ConsultarCategorias]
as
	select categorias.descripcion from categorias

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarFacturas]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarFacturas]
as
select Facturas.CodigoFactura as Codigo, Facturas.Numerofactura as 'Numero Factura',
Facturas.Serie, Facturas.Fechafactura as 'Fecha', Facturas.CodigoCliente as 'Cliente', 
Clientes.Nombre, Facturas.Total
from Facturas inner join clientes on Facturas.CodigoCliente = Clientes.CodigoCliente
order by Facturas.FechaFactura, Facturas.NumeroFactura, clientes.Nombre


GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarProductos]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_EliminarCategoria]
@CodigoCategoria int
as
	Delete from Categorias
	where CodigoCategoria = @CodigoCategoria

GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarCategoria]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ModificarCategoria]
@CodigoCategoria int, @Descripcion as varchar(128)
as
	update Categorias
	set Descripcion = @Descripcion
	where CodigoCategoria = @CodigoCategoria


GO
/****** Object:  Trigger [dbo].[tr_RegistrarCompra]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[tr_RegistrarCompra] on [dbo].[DetalleCompra] for insert 
as
begin
	declare @NumeroDocumento int
	declare @CodigoTipoRegistro int
	declare @Salidas int
	declare @Entradas int
	declare @CodigoProducto int
	declare @Precio decimal(10,2)
	declare @Fecha date
	set @NumeroDocumento = (select NumeroDocumento from inserted)
	set  @CodigoTipoRegistro = 2
	set @Salidas = 0
	set @Entradas = (select Cantidad from inserted)
	set @CodigoProducto = (select CodigoProducto from inserted)
	set @Precio = (select Precio from inserted)
	set @Fecha = getdate()
	execute sp_AgregarInventario @CodigoTipoRegistro,@Salidas,@Entradas,@CodigoProducto,@Precio,@Fecha
	update compras set TotalCompra = TotalCompra + 
		(@Entradas * @precio) where NumeroDocumento = @NumeroDocumento
end
GO
/****** Object:  Trigger [dbo].[tgr_ActualizarTotal]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[tgr_ActualizarTotal] on [dbo].[DetalleFactura] for insert,delete
as 
begin
	Declare @SubTotal decimal(10,2)
	Declare @Total decimal(10,2)
	declare @CodigoFactura int
	if exists(select * from inserted) 
		begin
			set @CodigoFactura = (select codigoFactura from inserted)
			set @Subtotal = (select inserted.precio * inserted.cantidad from inserted)
			set @Total = (select facturas.total from facturas where facturas.codigoFactura = @CodigoFactura)
			set @Total = @Total + @Subtotal
		end
	 else if exists(select * from deleted)
		begin
			set @CodigoFactura = (select codigoFactura from deleted)
			set @Subtotal = (select deleted.precio * deleted.cantidad from deleted)
			set @Total = (select facturas.total from facturas where facturas.codigoFactura = @CodigoFactura)
			set @Total = @Total - @Subtotal
		end	
	update facturas set facturas.total = @Total where facturas.codigoFactura = @CodigoFactura
end

GO
/****** Object:  Trigger [dbo].[tr_RegistrarInventarioCompra]    Script Date: 11/06/2016 09:50:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[tr_RegistrarInventarioCompra] on [dbo].[Inventarios]
for insert
as
begin
	declare @TipoRegistro int
	declare @Cantidad int
	declare @PrecioUnitario decimal(10,2)
	declare @CodigoProducto int
	declare @Total decimal(10,2)
	declare @PrecioProducto decimal(10,2)
	declare @Existencias int
	set @TipoRegistro = (select Inserted.codigoTipoRegistro from inserted)
	set @CodigoProducto = (select inserted.CodigoProducto from inserted)
	set @PrecioUnitario = (select inserted.precio from inserted)
	set @PrecioProducto = (select productos.PrecioUnitario from Productos where Productos.CodigoProducto = @CodigoProducto)
	set @Existencias = (select Productos.existencia from productos where productos.codigoProducto = @CodigoProducto)
	if @TipoRegistro = 2
	begin
		set @Cantidad = (select inserted.entradas from inserted)
		set @Total = @Existencias * dbo.CalcularPrecioCosto(@PrecioProducto)
		set @Existencias = @Existencias + @Cantidad
		set @PrecioUnitario = ((@Cantidad * @PrecioUnitario) + @Total)/@Existencias
		update productos set existencia = @Existencias, 
			PrecioUnitario = dbo.CalcularPrecioUnitario(@PrecioUnitario) 
				where CodigoProducto = @CodigoProducto
	end
end

GO
USE [master]
GO
ALTER DATABASE [Inventario2016I147G_1] SET  READ_WRITE 
GO
