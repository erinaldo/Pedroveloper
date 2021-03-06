USE [master]
GO
/****** Object:  Database [BASEDATOS]    Script Date: 16/12/2020 11:23:07:AM ******/
CREATE DATABASE [BASEDATOS]
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BASEDATOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BASEDATOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BASEDATOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BASEDATOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BASEDATOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BASEDATOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BASEDATOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BASEDATOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BASEDATOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BASEDATOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BASEDATOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BASEDATOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BASEDATOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BASEDATOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BASEDATOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BASEDATOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BASEDATOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BASEDATOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BASEDATOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BASEDATOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BASEDATOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BASEDATOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BASEDATOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BASEDATOS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BASEDATOS] SET  MULTI_USER 
GO
ALTER DATABASE [BASEDATOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BASEDATOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BASEDATOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BASEDATOS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BASEDATOS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BASEDATOS', N'ON'
GO
ALTER DATABASE [BASEDATOS] SET QUERY_STORE = OFF
GO
USE [BASEDATOS]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[idDireccion] [int] NOT NULL,
	[idDocumento] [int] NOT NULL,
	[idTelefono] [int] NOT NULL,
	[idCorreo] [int] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Personas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Personas]
as 
select * from Persona
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[idAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[stock_minimo] [numeric](18, 2) NOT NULL,
	[idLocalizacion] [varchar](50) NOT NULL,
	[idDireccion] [int] NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[idAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlmacenDetalle]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlmacenDetalle](
	[idAlmacenDet] [int] IDENTITY(1,1) NOT NULL,
	[idAlmacen] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[stock] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_AlmacenDetalle] PRIMARY KEY CLUSTERED 
(
	[idAlmacenDet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aux_Productos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aux_Productos](
	[idAux] [int] IDENTITY(1,1) NOT NULL,
	[idFactura] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[idDetalleProducto] [int] NOT NULL,
 CONSTRAINT [PK_Aux_Productos] PRIMARY KEY CLUSTERED 
(
	[idAux] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[Id_Caja] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Tema] [varchar](50) NULL,
	[Serial_PC] [varchar](max) NULL,
	[Impresora_Ticket] [varchar](max) NULL,
	[Impresora_A4] [varchar](max) NULL,
	[Estado] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[PuertoBalanza] [varchar](max) NULL,
	[EstadoBalanza] [varchar](50) NULL,
 CONSTRAINT [PK_Caja_1] PRIMARY KEY CLUSTERED 
(
	[Id_Caja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calle]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calle](
	[idCalle] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Calle] PRIMARY KEY CLUSTERED 
(
	[idCalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaProductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProductos](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Departamento] [varchar](50) NULL,
	[idItbis] [int] NULL,
	[idDescuento] [int] NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_CategoriaProductos] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClavesSat]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClavesSat](
	[idClaveSat] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_ClavesSat] PRIMARY KEY CLUSTERED 
(
	[idClaveSat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[idclientev] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[IdentificadorFiscal] [varchar](max) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[idclientev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras](
	[idCompra] [int] IDENTITY(1,1) NOT NULL,
	[idProveedor] [int] NULL,
	[fecha_compra] [datetime] NULL,
	[Numero_de_doc] [varchar](50) NULL,
	[Monto_total] [numeric](18, 2) NULL,
	[Tipo_de_pago] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Comprobante] [varchar](50) NULL,
	[Id_usuario] [int] NULL,
	[Fecha_de_pago] [varchar](50) NULL,
	[ACCION] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Id_caja] [int] NULL,
	[Vuelto] [numeric](18, 2) NULL,
	[TotalPagado] [numeric](18, 2) NULL,
	[Trasferencia_Bancaria] [varchar](50) NULL,
 CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conceptos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conceptos](
	[Id_concepto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_Conceptos] PRIMARY KEY CLUSTERED 
(
	[Id_concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlCobros]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlCobros](
	[IdcontrolCobro] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [numeric](18, 2) NULL,
	[Fecha] [datetime] NULL,
	[Detalle] [varchar](max) NULL,
	[IdCliente] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdCaja] [int] NULL,
	[Comprobante] [varchar](max) NULL,
	[Efectivo] [numeric](18, 2) NULL,
	[Tarjeta] [numeric](18, 2) NULL,
 CONSTRAINT [PK_ControlCobros] PRIMARY KEY CLUSTERED 
(
	[IdcontrolCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlPago]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlPago](
	[idControlPago] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[Detalle] [varchar](50) NULL,
	[Fecha] [datetime] NOT NULL,
	[idProveedor] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idCaja] [int] NOT NULL,
	[Comprobante] [varchar](50) NOT NULL,
	[Efectivo] [numeric](18, 2) NOT NULL,
	[Tarjeta] [numeric](18, 2) NOT NULL,
	[TransferenciaBancaria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ControlPago] PRIMARY KEY CLUSTERED 
(
	[idControlPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorreoBase]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorreoBase](
	[IdCorreo] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[EstadoEnvio] [varchar](50) NULL,
 CONSTRAINT [PK_CorreoBase] PRIMARY KEY CLUSTERED 
(
	[IdCorreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Correos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Correos](
	[idCorreo] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[TipoCorreo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Correos] PRIMARY KEY CLUSTERED 
(
	[idCorreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditoPorCobrar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditoPorCobrar](
	[Id_credito] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Fecha_registro] [datetime] NULL,
	[Fecha_vencimiento] [datetime] NULL,
	[Total] [numeric](18, 2) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Estado] [varchar](max) NULL,
	[Id_caja] [int] NULL,
	[Id_cliente] [int] NULL,
 CONSTRAINT [PK_CreditoPorCobrar] PRIMARY KEY CLUSTERED 
(
	[Id_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditoPorPagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditoPorPagar](
	[Id_credito] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Fecha_registro] [datetime] NULL,
	[Fecha_vencimiento] [date] NULL,
	[Total] [numeric](18, 2) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Estado] [varchar](max) NULL,
	[Id_caja] [int] NULL,
	[Id_Proveedor] [int] NULL,
 CONSTRAINT [PK_CreditoPorPagar] PRIMARY KEY CLUSTERED 
(
	[Id_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatosFiscales]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosFiscales](
	[idDatosFiscales] [int] IDENTITY(1,1) NOT NULL,
	[NombreFiscal] [varchar](50) NOT NULL,
	[infoAdicional] [varchar](50) NOT NULL,
	[RegimenFiscal] [varchar](50) NOT NULL,
	[RNC] [varchar](50) NOT NULL,
	[NoFiscal] [varchar](50) NOT NULL,
	[CodPostal] [varchar](50) NOT NULL,
	[Localidad] [varchar](50) NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[NoInt] [varchar](50) NOT NULL,
	[NoExt] [varchar](50) NOT NULL,
	[CDL] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DatosFiscales] PRIMARY KEY CLUSTERED 
(
	[idDatosFiscales] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuentos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuentos](
	[idDescuento] [int] IDENTITY(1,1) NOT NULL,
	[Descuento] [numeric](18, 2) NOT NULL,
	[TipoDescuento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Descuentos] PRIMARY KEY CLUSTERED 
(
	[idDescuento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_compra](
	[iddetalle_compra] [int] IDENTITY(1,1) NOT NULL,
	[idCompra] [int] NULL,
	[Id_producto] [int] NULL,
	[cantidad] [numeric](18, 2) NULL,
	[preciounitario] [numeric](18, 2) NULL,
	[Moneda] [varchar](50) NULL,
	[Descuento] [numeric](18, 2) NULL,
	[Total_a_pagar]  AS ([preciounitario]*[cantidad]-[Descuento]),
	[Unidad_de_medida] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Codigo] [varchar](50) NULL,
	[Stock] [varchar](50) NULL,
	[Se_vende_a] [varchar](50) NULL,
	[Costo] [numeric](18, 2) NULL,
	[itbis_calculo] [decimal](18, 2) NULL,
	[Itbis]  AS (case when [itbis_calculo]=(0.18) then ([preciounitario]*[cantidad]-[descuento])*(0.18) else ([preciounitario]*[cantidad]-[descuento])*(0.00) end),
 CONSTRAINT [PK_detalle_compra] PRIMARY KEY CLUSTERED 
(
	[iddetalle_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_factura](
	[iddetalle_factura] [int] IDENTITY(1,1) NOT NULL,
	[idFactura] [int] NULL,
	[Id_producto] [int] NULL,
	[cantidad] [numeric](18, 2) NULL,
	[preciounitario] [numeric](18, 2) NULL,
	[Moneda] [varchar](50) NULL,
	[Descuento] [numeric](18, 2) NULL,
	[Total_a_pagar]  AS ([preciounitario]*[cantidad]-[Descuento]),
	[Unidad_de_medida] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Codigo] [varchar](50) NULL,
	[Stock] [varchar](50) NULL,
	[Se_vende_a] [varchar](50) NULL,
	[Costo] [numeric](18, 2) NULL,
	[Ganancia]  AS (([cantidad]*[preciounitario]-[cantidad]*[costo])-[Descuento]),
	[itbis_calculo] [decimal](18, 2) NULL,
	[Itbis]  AS (case when [itbis_calculo]=(0.18) then ([preciounitario]*[cantidad]-[descuento])*(0.18) else ([preciounitario]*[cantidad]-[descuento])*(1.00) end),
 CONSTRAINT [PK_detalle_factura] PRIMARY KEY CLUSTERED 
(
	[iddetalle_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleProducto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleProducto](
	[idDetalleProducto] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[idProveedor] [int] NOT NULL,
	[Localizacion] [varchar](50) NOT NULL,
	[StockMinimo] [numeric](18, 2) NOT NULL,
	[UsoInterno] [varchar](50) NOT NULL,
	[Granel] [varchar](50) NOT NULL,
	[Peso] [varchar](50) NOT NULL,
	[FechaVencimiento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DetalleProducto] PRIMARY KEY CLUSTERED 
(
	[idDetalleProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesPedidos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesPedidos](
	[idDetallePedido] [int] NOT NULL,
	[idPedido] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[PrecioUnidad] [numeric](18, 2) NOT NULL,
	[Cantidad] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_DetallesPedidos] PRIMARY KEY CLUSTERED 
(
	[idDetallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[idDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[idRegion] [int] NOT NULL,
	[idMunicipio] [int] NOT NULL,
	[idSector] [int] NOT NULL,
	[idProvincia] [int] NOT NULL,
	[idCalle] [int] NOT NULL,
	[idCiudad] [int] NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[idDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[idDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[numeracion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[idDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NULL,
	[idHorario] [int] NULL,
	[CuentaBanco] [varchar](50) NULL,
	[Departamento] [varchar](50) NULL,
	[Banco] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](50) NULL,
	[idEmpresa] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPRESA]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPRESA](
	[Id_empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Empresa] [varchar](50) NOT NULL,
	[Logo] [image] NOT NULL,
	[Moneda] [varchar](50) NOT NULL,
	[Modo_de_busqueda] [varchar](50) NOT NULL,
	[Carpeta_para_copias_de_seguridad] [varchar](max) NOT NULL,
	[idCorreo] [int] NOT NULL,
	[Ultima_fecha_de_copia_de_seguridad] [varchar](50) NOT NULL,
	[Ultima_fecha_de_copia_date] [datetime] NOT NULL,
	[Frecuencia_de_copias] [int] NOT NULL,
	[idDireccion] [int] NOT NULL,
	[idDatosFiscales] [int] NOT NULL,
	[idTelefono] [int] NULL,
	[idCelular] [int] NULL,
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[Id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[idclientev] [int] NULL,
	[fecha_factura] [datetime] NULL,
	[Numero_de_doc] [varchar](50) NULL,
	[Monto_total] [numeric](18, 2) NULL,
	[Tipo_de_pago] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Comprobante] [varchar](50) NULL,
	[Id_usuario] [int] NULL,
	[Fecha_de_pago] [varchar](50) NULL,
	[ACCION] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Pago_con] [numeric](18, 2) NULL,
	[Id_caja] [int] NULL,
	[Referencia_tarjeta] [varchar](50) NULL,
	[Vuelto] [numeric](18, 2) NULL,
	[Efectivo] [numeric](18, 2) NULL,
	[Credito] [numeric](18, 2) NULL,
	[Tarjeta] [numeric](18, 2) NULL,
 CONSTRAINT [PK_facturas] PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturasExternas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturasExternas](
	[idControlPago] [int] IDENTITY(1,1) NOT NULL,
	[NumFact] [varchar](50) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[Detalle] [varchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[idProveedor] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idCaja] [int] NOT NULL,
	[Comprobante] [varchar](50) NOT NULL,
	[Efectivo] [numeric](18, 2) NOT NULL,
	[Tarjeta] [numeric](18, 2) NOT NULL,
	[TransferenciaBancaria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FacturasExternas] PRIMARY KEY CLUSTERED 
(
	[idControlPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturasProveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturasProveedores](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[NumFact] [varchar](50) NOT NULL,
	[NumPed] [varchar](50) NOT NULL,
	[FechaPedido] [date] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[Total] [numeric](18, 2) NOT NULL,
	[Tipo] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[idProveedor] [int] NULL,
 CONSTRAINT [PK_FacturasProveedores] PRIMARY KEY CLUSTERED 
(
	[NumFact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gastos_varios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos_varios](
	[Id_gasto] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Nro_documento] [varchar](max) NULL,
	[Tipo_comprobante] [varchar](max) NULL,
	[Importe] [numeric](18, 2) NULL,
	[Descripcion] [varchar](max) NULL,
	[Id_caja] [int] NULL,
	[Id_concepto] [int] NULL,
 CONSTRAINT [PK_Gastos_varios] PRIMARY KEY CLUSTERED 
(
	[Id_gasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialCambios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialCambios](
	[idRegistro] [int] IDENTITY(1,1) NOT NULL,
	[idAccion] [int] NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Fecha] [varchar](50) NOT NULL,
 CONSTRAINT [PK_HistorialCambios] PRIMARY KEY CLUSTERED 
(
	[idRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[idHorario] [int] IDENTITY(1,1) NOT NULL,
	[Entrada] [varchar](50) NOT NULL,
	[Salida] [varchar](50) NOT NULL,
	[TipoHorario] [int] NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[idHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuestos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuestos](
	[idImpuesto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Impuesto] [numeric](18, 2) NULL,
	[Tipo] [varchar](50) NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Impuestos_1] PRIMARY KEY CLUSTERED 
(
	[idImpuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingresos_varios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos_varios](
	[Id_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Nro_comprobante] [varchar](max) NULL,
	[Tipo_comprobante] [varchar](max) NULL,
	[Importe] [numeric](18, 2) NULL,
	[Descripcion] [varchar](max) NULL,
	[Id_caja] [int] NULL,
 CONSTRAINT [PK_Ingresos_varios] PRIMARY KEY CLUSTERED 
(
	[Id_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inicios_de_sesion_por_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inicios_de_sesion_por_caja](
	[Id_inicio_sesion] [int] IDENTITY(1,1) NOT NULL,
	[Id_serial_Pc] [varchar](max) NULL,
	[Id_usuario] [int] NULL,
 CONSTRAINT [PK_Inicios_de_sesion] PRIMARY KEY CLUSTERED 
(
	[Id_inicio_sesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KARDEX]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KARDEX](
	[Id_kardex] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Motivo] [varchar](max) NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[Id_producto] [int] NULL,
	[Id_usuario] [int] NULL,
	[Tipo] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Total]  AS ([Cantidad]*[Costo_unt]),
	[Costo_unt] [numeric](18, 2) NULL,
	[Habia] [numeric](18, 2) NULL,
	[Hay] [numeric](18, 2) NULL,
	[Id_caja] [int] NULL,
 CONSTRAINT [PK_KARDEX] PRIMARY KEY CLUSTERED 
(
	[Id_kardex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaPrecios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaPrecios](
	[idPrecios] [int] IDENTITY(1,1) NOT NULL,
	[idMayoreo] [int] NOT NULL,
	[Precio_1] [numeric](18, 2) NOT NULL,
	[Precio_2] [numeric](18, 2) NOT NULL,
	[Precio_3] [numeric](18, 2) NOT NULL,
	[Precio_4] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ListaPrecios] PRIMARY KEY CLUSTERED 
(
	[idPrecios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localizacion](
	[idLocalizacion] [varchar](50) NOT NULL,
	[Zona] [varchar](50) NOT NULL,
	[NoAnaquel] [varchar](50) NOT NULL,
	[Localizacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Lozalizacion] PRIMARY KEY CLUSTERED 
(
	[idLocalizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MantenimientosVehiculos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MantenimientosVehiculos](
	[idMantenimiento] [int] NOT NULL,
	[idVehiculo] [int] NULL,
	[descripcion] [varchar](50) NULL,
	[fecha] [date] NULL,
	[costo] [numeric](18, 2) NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_MantenimientosVehiculos] PRIMARY KEY CLUSTERED 
(
	[idMantenimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcan]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcan](
	[Id_marca] [int] IDENTITY(1,1) NOT NULL,
	[S] [varchar](max) NULL,
	[F] [varchar](max) NULL,
	[E] [varchar](max) NULL,
	[FA] [varchar](max) NULL,
 CONSTRAINT [PK_Licencias] PRIMARY KEY CLUSTERED 
(
	[Id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[idModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[idModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MOVIMIENTOCAJACIERRE]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIMIENTOCAJACIERRE](
	[idcierrecaja] [int] IDENTITY(1,1) NOT NULL,
	[fechainicio] [datetime] NULL,
	[fechafin] [datetime] NULL,
	[fechacierre] [datetime] NULL,
	[ingresos] [numeric](18, 2) NULL,
	[egresos] [numeric](18, 2) NULL,
	[Saldo_queda_en_caja] [numeric](18, 2) NULL,
	[Id_usuario] [int] NULL,
	[Total_calculado] [numeric](18, 2) NULL,
	[Total_real] [numeric](18, 2) NULL,
	[Estado] [varchar](50) NULL,
	[Diferencia] [numeric](18, 2) NULL,
	[Id_caja] [int] NULL,
 CONSTRAINT [PK_MOVIMIENTOCAJACIERRE] PRIMARY KEY CLUSTERED 
(
	[idcierrecaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipio](
	[idMunicipio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Municipio] PRIMARY KEY CLUSTERED 
(
	[idMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[idIOperacion] [int] IDENTITY(1,1) NOT NULL,
	[Operacion] [varchar](50) NOT NULL,
	[idModulo] [int] NOT NULL,
 CONSTRAINT [PK_Operaciones] PRIMARY KEY CLUSTERED 
(
	[idIOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[idPedido] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idFactura] [int] NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[idVehiculo] [int] NOT NULL,
	[FechaEnvio] [datetime] NOT NULL,
	[Destinatario] [varchar](50) NOT NULL,
	[DireccionDestinatario] [varchar](50) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreciosCompraProveedor]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreciosCompraProveedor](
	[idUltimoPrecio] [int] IDENTITY(1,1) NOT NULL,
	[idProveedor] [int] NULL,
	[idProducto] [int] NULL,
	[PrecioCompra] [numeric](18, 2) NULL,
	[FechaCompra] [datetime] NULL,
 CONSTRAINT [PK_PreciosCompraProveedor] PRIMARY KEY CLUSTERED 
(
	[idUltimoPrecio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[idCategoria] [int] NULL,
	[idPrecios] [int] NULL,
	[Codigo] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Stock] [numeric](18, 2) NULL,
	[PrecioCompra] [numeric](18, 2) NULL,
	[idImpuesto] [int] NULL,
	[idDescuento] [int] NULL,
 CONSTRAINT [PK_Producto1] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[IdentificadorFiscal] [varchar](max) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Saldo] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[idRegion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[idRegion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](70) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rolVSoperacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rolVSoperacion](
	[idRolOperacion] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[idOperacion] [int] NOT NULL,
 CONSTRAINT [PK_rolVSoperacion] PRIMARY KEY CLUSTERED 
(
	[idRolOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[idSector] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[idSector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Serializacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Serializacion](
	[Id_serializacion] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](50) NULL,
	[Cantidad_de_numeros] [varchar](50) NULL,
	[numerofin] [varchar](50) NULL,
	[Destino] [varchar](50) NULL,
	[tipodoc] [varchar](50) NULL,
	[Por_defecto] [varchar](50) NULL,
 CONSTRAINT [PK_Serializacion] PRIMARY KEY CLUSTERED 
(
	[Id_serializacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[idServicio] [int] IDENTITY(1,1) NOT NULL,
	[idCategoria] [int] NOT NULL,
	[idPrecios] [int] NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Servicio] [varchar](50) NOT NULL,
	[Stock] [numeric](18, 2) NOT NULL,
	[PrecioCompra] [numeric](18, 2) NOT NULL,
	[idImpuesto] [int] NOT NULL,
	[idDescuento] [int] NOT NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[idServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[idTelefono] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](50) NOT NULL,
	[idTipoTelefono] [int] NOT NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[idTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id_ticket] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empresa] [int] NULL,
	[Identificador_fiscal] [varchar](max) NULL,
	[Direccion] [varchar](max) NULL,
	[Provincia_Departamento_Pais] [varchar](max) NULL,
	[Nombre_de_Moneda] [varchar](max) NULL,
	[Agradecimiento] [varchar](max) NULL,
	[pagina_Web_Facebook] [varchar](max) NULL,
	[Anuncio] [varchar](max) NULL,
	[Datos_fiscales_de_autorizacion] [varchar](max) NULL,
	[Por_defecto] [varchar](max) NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id_ticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoHorario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoHorario](
	[idTipoHorario] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoHorario_1] PRIMARY KEY CLUSTERED 
(
	[idTipoHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTelefono](
	[idTipoTelefono] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoTelefono] PRIMARY KEY CLUSTERED 
(
	[idTipoTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVehiculo](
	[idTipoVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[capacidad] [varchar](50) NULL,
 CONSTRAINT [PK_TipoVehiculo] PRIMARY KEY CLUSTERED 
(
	[idTipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadesProductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesProductos](
	[idUnidad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[idClaveSat] [int] NOT NULL,
 CONSTRAINT [PK_UnidadesProductos] PRIMARY KEY CLUSTERED 
(
	[idUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadesVSProducto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesVSProducto](
	[idUnidadVenta] [int] NULL,
	[idUnidadCompra] [int] NULL,
	[idProducto] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO2]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO2](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Icono] [image] NOT NULL,
	[Nombre_de_icono] [varchar](max) NOT NULL,
	[idRol] [int] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USUARIO2] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[idVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[idTipoVehiculo] [int] NULL,
	[NPlaca] [varchar](50) NULL,
	[Transmision] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Ano] [int] NULL,
	[Capacidad] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
(
	[idVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasMayoreo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasMayoreo](
	[idMayoreo] [int] IDENTITY(1,1) NOT NULL,
	[Unidades_1] [numeric](18, 2) NOT NULL,
	[Unidades_2] [numeric](18, 2) NOT NULL,
	[Unidades_3] [numeric](18, 2) NOT NULL,
	[Unidades_4] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_VentasMayoreo] PRIMARY KEY CLUSTERED 
(
	[idMayoreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Almacen]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Direccion] FOREIGN KEY([idDireccion])
REFERENCES [dbo].[Direccion] ([idDireccion])
GO
ALTER TABLE [dbo].[Almacen] CHECK CONSTRAINT [FK_Almacen_Direccion]
GO
ALTER TABLE [dbo].[Almacen]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Lozalizacion] FOREIGN KEY([idLocalizacion])
REFERENCES [dbo].[Localizacion] ([idLocalizacion])
GO
ALTER TABLE [dbo].[Almacen] CHECK CONSTRAINT [FK_Almacen_Lozalizacion]
GO
ALTER TABLE [dbo].[AlmacenDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AlmacenDetalle_Almacen] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[Almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[AlmacenDetalle] CHECK CONSTRAINT [FK_AlmacenDetalle_Almacen]
GO
ALTER TABLE [dbo].[AlmacenDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AlmacenDetalle_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[AlmacenDetalle] CHECK CONSTRAINT [FK_AlmacenDetalle_Producto]
GO
ALTER TABLE [dbo].[Aux_Productos]  WITH CHECK ADD  CONSTRAINT [FK_Aux_Productos_detalle_factura] FOREIGN KEY([idDetalleProducto])
REFERENCES [dbo].[detalle_factura] ([iddetalle_factura])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Aux_Productos] CHECK CONSTRAINT [FK_Aux_Productos_detalle_factura]
GO
ALTER TABLE [dbo].[Aux_Productos]  WITH CHECK ADD  CONSTRAINT [FK_Aux_Productos_facturas] FOREIGN KEY([idFactura])
REFERENCES [dbo].[facturas] ([idFactura])
GO
ALTER TABLE [dbo].[Aux_Productos] CHECK CONSTRAINT [FK_Aux_Productos_facturas]
GO
ALTER TABLE [dbo].[Aux_Productos]  WITH CHECK ADD  CONSTRAINT [FK_Aux_Productos_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[Aux_Productos] CHECK CONSTRAINT [FK_Aux_Productos_Producto]
GO
ALTER TABLE [dbo].[CategoriaProductos]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaProductos_Descuentos1] FOREIGN KEY([idDescuento])
REFERENCES [dbo].[Descuentos] ([idDescuento])
GO
ALTER TABLE [dbo].[CategoriaProductos] CHECK CONSTRAINT [FK_CategoriaProductos_Descuentos1]
GO
ALTER TABLE [dbo].[CategoriaProductos]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaProductos_Impuestos] FOREIGN KEY([idItbis])
REFERENCES [dbo].[Impuestos] ([idImpuesto])
GO
ALTER TABLE [dbo].[CategoriaProductos] CHECK CONSTRAINT [FK_CategoriaProductos_Impuestos]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_Caja]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_Proveedores] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_Proveedores]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_USUARIO2] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_USUARIO2]
GO
ALTER TABLE [dbo].[ControlCobros]  WITH CHECK ADD  CONSTRAINT [FK_ControlCobros_Caja] FOREIGN KEY([IdCaja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[ControlCobros] CHECK CONSTRAINT [FK_ControlCobros_Caja]
GO
ALTER TABLE [dbo].[ControlCobros]  WITH CHECK ADD  CONSTRAINT [FK_ControlCobros_clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[clientes] ([idclientev])
GO
ALTER TABLE [dbo].[ControlCobros] CHECK CONSTRAINT [FK_ControlCobros_clientes]
GO
ALTER TABLE [dbo].[ControlCobros]  WITH CHECK ADD  CONSTRAINT [FK_ControlCobros_USUARIO2] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[ControlCobros] CHECK CONSTRAINT [FK_ControlCobros_USUARIO2]
GO
ALTER TABLE [dbo].[ControlPago]  WITH CHECK ADD  CONSTRAINT [FK_ControlPago_Caja] FOREIGN KEY([idCaja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[ControlPago] CHECK CONSTRAINT [FK_ControlPago_Caja]
GO
ALTER TABLE [dbo].[ControlPago]  WITH CHECK ADD  CONSTRAINT [FK_ControlPago_Proveedores] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[ControlPago] CHECK CONSTRAINT [FK_ControlPago_Proveedores]
GO
ALTER TABLE [dbo].[ControlPago]  WITH CHECK ADD  CONSTRAINT [FK_ControlPago_USUARIO2] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[ControlPago] CHECK CONSTRAINT [FK_ControlPago_USUARIO2]
GO
ALTER TABLE [dbo].[CreditoPorCobrar]  WITH CHECK ADD  CONSTRAINT [FK_CreditoPorCobrar_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[CreditoPorCobrar] CHECK CONSTRAINT [FK_CreditoPorCobrar_Caja]
GO
ALTER TABLE [dbo].[CreditoPorCobrar]  WITH CHECK ADD  CONSTRAINT [FK_CreditoPorCobrar_clientes] FOREIGN KEY([Id_cliente])
REFERENCES [dbo].[clientes] ([idclientev])
GO
ALTER TABLE [dbo].[CreditoPorCobrar] CHECK CONSTRAINT [FK_CreditoPorCobrar_clientes]
GO
ALTER TABLE [dbo].[CreditoPorPagar]  WITH CHECK ADD  CONSTRAINT [FK_CreditoPorPagar_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[CreditoPorPagar] CHECK CONSTRAINT [FK_CreditoPorPagar_Caja]
GO
ALTER TABLE [dbo].[CreditoPorPagar]  WITH CHECK ADD  CONSTRAINT [FK_CreditoPorPagar_Proveedores] FOREIGN KEY([Id_Proveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[CreditoPorPagar] CHECK CONSTRAINT [FK_CreditoPorPagar_Proveedores]
GO
ALTER TABLE [dbo].[detalle_compra]  WITH CHECK ADD  CONSTRAINT [FK_detalle_compra_compras] FOREIGN KEY([idCompra])
REFERENCES [dbo].[compras] ([idCompra])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_compra] CHECK CONSTRAINT [FK_detalle_compra_compras]
GO
ALTER TABLE [dbo].[detalle_compra]  WITH CHECK ADD  CONSTRAINT [FK_detalle_compra_Producto1] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[detalle_compra] CHECK CONSTRAINT [FK_detalle_compra_Producto1]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura_facturas] FOREIGN KEY([idFactura])
REFERENCES [dbo].[facturas] ([idFactura])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_detalle_factura_facturas]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura_Producto1] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_detalle_factura_Producto1]
GO
ALTER TABLE [dbo].[DetalleProducto]  WITH CHECK ADD  CONSTRAINT [FK_DetalleProducto_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetalleProducto] CHECK CONSTRAINT [FK_DetalleProducto_Producto]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPedidos_Pedidos] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedidos] ([idPedido])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [FK_DetallesPedidos_Pedidos]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPedidos_Producto1] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [FK_DetallesPedidos_Producto1]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Calle] FOREIGN KEY([idCalle])
REFERENCES [dbo].[Calle] ([idCalle])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Calle]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Ciudad] FOREIGN KEY([idCiudad])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Ciudad]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Municipio1] FOREIGN KEY([idMunicipio])
REFERENCES [dbo].[Municipio] ([idMunicipio])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Municipio1]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Provincia] FOREIGN KEY([idProvincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Provincia]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Region] FOREIGN KEY([idRegion])
REFERENCES [dbo].[Region] ([idRegion])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Region]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Sector1] FOREIGN KEY([idSector])
REFERENCES [dbo].[Sector] ([idSector])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Sector1]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_EMPRESA] FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[EMPRESA] ([Id_empresa])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_EMPRESA]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Horario] FOREIGN KEY([idHorario])
REFERENCES [dbo].[Horario] ([idHorario])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Horario]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Persona]
GO
ALTER TABLE [dbo].[EMPRESA]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESA_Correos] FOREIGN KEY([idCorreo])
REFERENCES [dbo].[Correos] ([idCorreo])
GO
ALTER TABLE [dbo].[EMPRESA] CHECK CONSTRAINT [FK_EMPRESA_Correos]
GO
ALTER TABLE [dbo].[EMPRESA]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESA_DatosFiscales] FOREIGN KEY([idDatosFiscales])
REFERENCES [dbo].[DatosFiscales] ([idDatosFiscales])
GO
ALTER TABLE [dbo].[EMPRESA] CHECK CONSTRAINT [FK_EMPRESA_DatosFiscales]
GO
ALTER TABLE [dbo].[EMPRESA]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESA_Direccion] FOREIGN KEY([idDireccion])
REFERENCES [dbo].[Direccion] ([idDireccion])
GO
ALTER TABLE [dbo].[EMPRESA] CHECK CONSTRAINT [FK_EMPRESA_Direccion]
GO
ALTER TABLE [dbo].[EMPRESA]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESA_Telefono] FOREIGN KEY([idTelefono])
REFERENCES [dbo].[Telefono] ([idTelefono])
GO
ALTER TABLE [dbo].[EMPRESA] CHECK CONSTRAINT [FK_EMPRESA_Telefono]
GO
ALTER TABLE [dbo].[EMPRESA]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESA_Telefono1] FOREIGN KEY([idCelular])
REFERENCES [dbo].[Telefono] ([idTelefono])
GO
ALTER TABLE [dbo].[EMPRESA] CHECK CONSTRAINT [FK_EMPRESA_Telefono1]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [FK_facturas_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [FK_facturas_Caja]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [FK_facturas_clientes] FOREIGN KEY([idclientev])
REFERENCES [dbo].[clientes] ([idclientev])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [FK_facturas_clientes]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [FK_facturas_USUARIO2] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [FK_facturas_USUARIO2]
GO
ALTER TABLE [dbo].[FacturasExternas]  WITH CHECK ADD  CONSTRAINT [FK_FacturasExternas_Caja] FOREIGN KEY([idCaja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[FacturasExternas] CHECK CONSTRAINT [FK_FacturasExternas_Caja]
GO
ALTER TABLE [dbo].[FacturasExternas]  WITH CHECK ADD  CONSTRAINT [FK_FacturasExternas_Proveedores] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[FacturasExternas] CHECK CONSTRAINT [FK_FacturasExternas_Proveedores]
GO
ALTER TABLE [dbo].[FacturasExternas]  WITH CHECK ADD  CONSTRAINT [FK_FacturasExternas_USUARIO2] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[FacturasExternas] CHECK CONSTRAINT [FK_FacturasExternas_USUARIO2]
GO
ALTER TABLE [dbo].[FacturasProveedores]  WITH CHECK ADD  CONSTRAINT [FK_FacturasProveedores_Proveedores] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[FacturasProveedores] CHECK CONSTRAINT [FK_FacturasProveedores_Proveedores]
GO
ALTER TABLE [dbo].[Gastos_varios]  WITH CHECK ADD  CONSTRAINT [FK_Gastos_varios_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[Gastos_varios] CHECK CONSTRAINT [FK_Gastos_varios_Caja]
GO
ALTER TABLE [dbo].[Gastos_varios]  WITH CHECK ADD  CONSTRAINT [FK_Gastos_varios_Conceptos] FOREIGN KEY([Id_concepto])
REFERENCES [dbo].[Conceptos] ([Id_concepto])
GO
ALTER TABLE [dbo].[Gastos_varios] CHECK CONSTRAINT [FK_Gastos_varios_Conceptos]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_Horario_TipoHorario] FOREIGN KEY([TipoHorario])
REFERENCES [dbo].[TipoHorario] ([idTipoHorario])
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_Horario_TipoHorario]
GO
ALTER TABLE [dbo].[Ingresos_varios]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_varios_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[Ingresos_varios] CHECK CONSTRAINT [FK_Ingresos_varios_Caja]
GO
ALTER TABLE [dbo].[Inicios_de_sesion_por_caja]  WITH CHECK ADD  CONSTRAINT [FK_Inicios_de_sesion_por_caja_USUARIO2] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[Inicios_de_sesion_por_caja] CHECK CONSTRAINT [FK_Inicios_de_sesion_por_caja_USUARIO2]
GO
ALTER TABLE [dbo].[KARDEX]  WITH CHECK ADD  CONSTRAINT [FK_KARDEX_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[KARDEX] CHECK CONSTRAINT [FK_KARDEX_Caja]
GO
ALTER TABLE [dbo].[KARDEX]  WITH CHECK ADD  CONSTRAINT [FK_KARDEX_Producto1] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([idProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KARDEX] CHECK CONSTRAINT [FK_KARDEX_Producto1]
GO
ALTER TABLE [dbo].[KARDEX]  WITH CHECK ADD  CONSTRAINT [FK_KARDEX_USUARIO2] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KARDEX] CHECK CONSTRAINT [FK_KARDEX_USUARIO2]
GO
ALTER TABLE [dbo].[ListaPrecios]  WITH CHECK ADD  CONSTRAINT [FK_ListaPrecios_VentasMayoreo] FOREIGN KEY([idMayoreo])
REFERENCES [dbo].[VentasMayoreo] ([idMayoreo])
GO
ALTER TABLE [dbo].[ListaPrecios] CHECK CONSTRAINT [FK_ListaPrecios_VentasMayoreo]
GO
ALTER TABLE [dbo].[MantenimientosVehiculos]  WITH CHECK ADD  CONSTRAINT [FK_MantenimientosVehiculos_Vehiculos] FOREIGN KEY([idVehiculo])
REFERENCES [dbo].[Vehiculos] ([idVehiculo])
GO
ALTER TABLE [dbo].[MantenimientosVehiculos] CHECK CONSTRAINT [FK_MantenimientosVehiculos_Vehiculos]
GO
ALTER TABLE [dbo].[MOVIMIENTOCAJACIERRE]  WITH CHECK ADD  CONSTRAINT [FK_MOVIMIENTOCAJACIERRE_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[MOVIMIENTOCAJACIERRE] CHECK CONSTRAINT [FK_MOVIMIENTOCAJACIERRE_Caja]
GO
ALTER TABLE [dbo].[MOVIMIENTOCAJACIERRE]  WITH CHECK ADD  CONSTRAINT [FK_MOVIMIENTOCAJACIERRE_USUARIO2] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[USUARIO2] ([idUsuario])
GO
ALTER TABLE [dbo].[MOVIMIENTOCAJACIERRE] CHECK CONSTRAINT [FK_MOVIMIENTOCAJACIERRE_USUARIO2]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Modulo1] FOREIGN KEY([idModulo])
REFERENCES [dbo].[Modulo] ([idModulo])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Modulo1]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_clientes] FOREIGN KEY([idCliente])
REFERENCES [dbo].[clientes] ([idclientev])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_clientes]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Empleados] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleados] ([idEmpleado])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Empleados]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_facturas] FOREIGN KEY([idFactura])
REFERENCES [dbo].[facturas] ([idFactura])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_facturas]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Vehiculos] FOREIGN KEY([idVehiculo])
REFERENCES [dbo].[Vehiculos] ([idVehiculo])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Vehiculos]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Correos] FOREIGN KEY([idCorreo])
REFERENCES [dbo].[Correos] ([idCorreo])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Correos]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Direccion] FOREIGN KEY([idDireccion])
REFERENCES [dbo].[Direccion] ([idDireccion])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Direccion]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Documento] FOREIGN KEY([idDocumento])
REFERENCES [dbo].[Documento] ([idDocumento])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Documento]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Telefono] FOREIGN KEY([idTelefono])
REFERENCES [dbo].[Telefono] ([idTelefono])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Telefono]
GO
ALTER TABLE [dbo].[PreciosCompraProveedor]  WITH CHECK ADD  CONSTRAINT [FK_PreciosCompraProveedor_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[PreciosCompraProveedor] CHECK CONSTRAINT [FK_PreciosCompraProveedor_Producto]
GO
ALTER TABLE [dbo].[PreciosCompraProveedor]  WITH CHECK ADD  CONSTRAINT [FK_PreciosCompraProveedor_Proveedores] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[PreciosCompraProveedor] CHECK CONSTRAINT [FK_PreciosCompraProveedor_Proveedores]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProductos] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[CategoriaProductos] ([idCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProductos]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Descuentos] FOREIGN KEY([idDescuento])
REFERENCES [dbo].[Descuentos] ([idDescuento])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Descuentos]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Impuestos] FOREIGN KEY([idImpuesto])
REFERENCES [dbo].[Impuestos] ([idImpuesto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Impuestos]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_ListaPrecios] FOREIGN KEY([idPrecios])
REFERENCES [dbo].[ListaPrecios] ([idPrecios])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_ListaPrecios]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Persona]
GO
ALTER TABLE [dbo].[rolVSoperacion]  WITH CHECK ADD  CONSTRAINT [FK_rolVSoperacion_Operaciones1] FOREIGN KEY([idOperacion])
REFERENCES [dbo].[Operaciones] ([idIOperacion])
GO
ALTER TABLE [dbo].[rolVSoperacion] CHECK CONSTRAINT [FK_rolVSoperacion_Operaciones1]
GO
ALTER TABLE [dbo].[rolVSoperacion]  WITH CHECK ADD  CONSTRAINT [FK_rolVSoperacion_Roles1] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[rolVSoperacion] CHECK CONSTRAINT [FK_rolVSoperacion_Roles1]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FK_Servicios_CategoriaProductos] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[CategoriaProductos] ([idCategoria])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FK_Servicios_CategoriaProductos]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FK_Servicios_Descuentos] FOREIGN KEY([idDescuento])
REFERENCES [dbo].[Descuentos] ([idDescuento])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FK_Servicios_Descuentos]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FK_Servicios_Impuestos] FOREIGN KEY([idImpuesto])
REFERENCES [dbo].[Impuestos] ([idImpuesto])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FK_Servicios_Impuestos]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FK_Servicios_ListaPrecios] FOREIGN KEY([idPrecios])
REFERENCES [dbo].[ListaPrecios] ([idPrecios])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FK_Servicios_ListaPrecios]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_TipoTelefono] FOREIGN KEY([idTipoTelefono])
REFERENCES [dbo].[TipoTelefono] ([idTipoTelefono])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_TipoTelefono]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_EMPRESA] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[EMPRESA] ([Id_empresa])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_EMPRESA]
GO
ALTER TABLE [dbo].[UnidadesProductos]  WITH CHECK ADD  CONSTRAINT [FK_UnidadesProductos_ClavesSat] FOREIGN KEY([idClaveSat])
REFERENCES [dbo].[ClavesSat] ([idClaveSat])
GO
ALTER TABLE [dbo].[UnidadesProductos] CHECK CONSTRAINT [FK_UnidadesProductos_ClavesSat]
GO
ALTER TABLE [dbo].[UnidadesVSProducto]  WITH CHECK ADD  CONSTRAINT [FK_UnidadesVSProducto_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[UnidadesVSProducto] CHECK CONSTRAINT [FK_UnidadesVSProducto_Producto]
GO
ALTER TABLE [dbo].[UnidadesVSProducto]  WITH CHECK ADD  CONSTRAINT [FK_UnidadesVSProducto_UnidadesProductos] FOREIGN KEY([idUnidadVenta])
REFERENCES [dbo].[UnidadesProductos] ([idUnidad])
GO
ALTER TABLE [dbo].[UnidadesVSProducto] CHECK CONSTRAINT [FK_UnidadesVSProducto_UnidadesProductos]
GO
ALTER TABLE [dbo].[UnidadesVSProducto]  WITH CHECK ADD  CONSTRAINT [FK_UnidadesVSProducto_UnidadesProductos1] FOREIGN KEY([idUnidadCompra])
REFERENCES [dbo].[UnidadesProductos] ([idUnidad])
GO
ALTER TABLE [dbo].[UnidadesVSProducto] CHECK CONSTRAINT [FK_UnidadesVSProducto_UnidadesProductos1]
GO
ALTER TABLE [dbo].[USUARIO2]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO2_Empleados] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleados] ([idEmpleado])
GO
ALTER TABLE [dbo].[USUARIO2] CHECK CONSTRAINT [FK_USUARIO2_Empleados]
GO
ALTER TABLE [dbo].[USUARIO2]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO2_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[USUARIO2] CHECK CONSTRAINT [FK_USUARIO2_Roles]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_TipoVehiculo] FOREIGN KEY([idTipoVehiculo])
REFERENCES [dbo].[TipoVehiculo] ([idTipoVehiculo])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_TipoVehiculo]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_serializacion_mas_uno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Actualizar_serializacion_mas_uno] @idserie AS INT
AS
    UPDATE Serializacion
    SET    numerofin = numerofin + 1
    WHERE  Id_serializacion = @idserie

GO
/****** Object:  StoredProcedure [dbo].[Actualizardatosempleado]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Actualizardatosempleado] @idEmpleado INT
AS
    UPDATE Empleados
    SET    Estado = 'ACTIVO'
    WHERE  idEmpleado = @idEmpleado

GO
/****** Object:  StoredProcedure [dbo].[Actualizardatosvehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Actualizardatosvehiculo] @idVehiculo INT
AS
    UPDATE Vehiculos
    SET    Estado = 'ACTIVO'
    WHERE  idVehiculo = @idVehiculo

GO
/****** Object:  StoredProcedure [dbo].[Actualizarestadoempleado]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Actualizarestadoempleado] @idEmpleado AS INT
AS
    UPDATE Empleados
    SET    Estado = 'PROCESANDO ENVIO'
    WHERE  idEmpleado = @idEmpleado

GO
/****** Object:  StoredProcedure [dbo].[Actualizarestadovehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Actualizarestadovehiculo] @idVehiculo AS INT
AS
    UPDATE Vehiculos
    SET    Estado = 'PROCESANDO ENVIO'
    WHERE  idVehiculo = @idVehiculo

GO
/****** Object:  StoredProcedure [dbo].[Aplicar_precio_mayoreo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Aplicar_precio_mayoreo] @idproducto     INT,
                                           @iddetallefactura INT
AS
    DECLARE @preciomayoreo NUMERIC(18, 2)

    SET @preciomayoreo= (SELECT Precio_mayoreo
                         FROM   Producto1
                         WHERE  Producto1.Id_Producto1 = @idproducto)

    IF EXISTS(SELECT Precio_mayoreo,
                     Id_Producto1
              FROM   Producto1
              WHERE  Precio_mayoreo = 0
                     AND Producto1.Id_Producto1 = @idproducto)
      RAISERROR('No se configuro un precio al moyero para este producto',16,1)
    ELSE
      UPDATE detalle_factura
      SET    preciounitario = @preciomayoreo
      WHERE  Id_producto = @idproducto
             AND detalle_factura.iddetalle_factura = @iddetallefactura

GO
/****** Object:  StoredProcedure [dbo].[Aumentar_saldo_a_cliente]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Aumentar_saldo_a_cliente] @idcliente AS INTEGER,
                                                  @Saldo     NUMERIC(18, 2)
AS
    UPDATE clientes
    SET    Saldo = Saldo + @Saldo
    WHERE  idclientev = @idcliente

	

GO
/****** Object:  StoredProcedure [dbo].[Aumentar_saldo_a_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Aumentar_saldo_a_factura] @numFact AS INTEGER,
                                                  @Saldo     NUMERIC(18, 2)
AS
    UPDATE FacturasProveedores
    SET    Saldo = Saldo + @Saldo
    WHERE  NumFact = @numFact
	DELETE FROM FacturasExternas
	WHERE NumFact = @numFact
	

GO
/****** Object:  StoredProcedure [dbo].[Aumentar_saldo_a_proveedor]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Aumentar_saldo_a_proveedor] @idProveedor AS INTEGER,
                                                  @Saldo     NUMERIC(18, 2)
AS
    UPDATE Proveedores
    SET    Saldo = Saldo + @Saldo
    WHERE  IdProveedor = @idProveedor

	

GO
/****** Object:  StoredProcedure [dbo].[Aumentar_Stock]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Aumentar_Stock] @idproducto AS INT,
                                    @cantidad   AS NUMERIC (18, 2)
AS
    UPDATE Producto
    SET    Stock = Stock + @cantidad
    WHERE  idProducto = @idproducto
           AND Stock <= @cantidad

GO
/****** Object:  StoredProcedure [dbo].[Aumentar_stock_en_detalle_de_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Aumentar_stock_en_detalle_de_compra]@Id_Producto1 AS INT,
                                                       @cantidad     AS NUMERIC (18, 2)
AS
    UPDATE detalle_compra
    SET    Stock = Stock + @cantidad
    WHERE  Id_producto = @Id_Producto1 
GO
/****** Object:  StoredProcedure [dbo].[Aumentar_stock_en_detalle_de_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Aumentar_stock_en_detalle_de_cotizacion] @Id_Producto1 AS INT,
                                                            @cantidad     AS NUMERIC (18, 2)
AS
    UPDATE detalle_cotizacion
    SET    Stock = Stock + @cantidad
    WHERE  Id_producto = @Id_Producto1
  

GO
/****** Object:  StoredProcedure [dbo].[Aumentar_stock_en_detalle_de_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Aumentar_stock_en_detalle_de_factura] @idProducto AS INT,
                                                       @cantidad     AS NUMERIC (18, 2)
AS
    UPDATE detalle_factura
    SET    Stock = Stock + @cantidad
    WHERE  Id_producto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[Aumentarstock]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Aumentarstock] @idproducto INT,
                                  @cantidad   NUMERIC(18, 2)
AS
    UPDATE Producto
    SET    Stock = Stock + @cantidad
    WHERE  idProducto = @idproducto
GO
/****** Object:  StoredProcedure [dbo].[Buscar_clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_clientes] @letra VARCHAR(max)
AS
    SELECT idclientev,
           p.nombre,
           d.Descripcion,
           IdentificadorFiscal AS [Identificador Fiscal],
           t.numero,
           Estado,
           Saldo,
		   cc.Correo
    FROM   dbo.clientes
           INNER JOIN Persona AS p
                   ON clientes.idPersona = p.idPersona
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
				   	inner join Correos as CC 
					on P.idCorreo = CC.idCorreo
    WHERE  Nombre + IdentificadorFiscal + numero LIKE '%' + @letra + '%'
           AND Nombre <> 'GENERICO'

GO
/****** Object:  StoredProcedure [dbo].[Buscar_clientes-]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_clientes-] @letra VARCHAR(max)
AS
     SELECT c.idclientev,
           c.idPersona,
           p.nombre              AS Nombre,
           p.apellido            AS Apellido,
           CC.Correo,
           p.fechaNacimiento,
           d.idDireccion,
           d.Descripcion         AS Direccion,
           do.idDocumento,
           do.numeracion         AS Documento,
           do.Tipo               AS TipoDocumento,
           t.idTelefono,
           t.numero              AS Telefono,
           tt.idTipoTelefono,
           tt.descripcion        AS TipoTelefono,
           c.IdentificadorFiscal AS [Identificador Fiscal],
           c.Estado,
           c.Saldo,
		   cc.idCorreo
    FROM   dbo.clientes AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
           INNER JOIN TipoTelefono AS tt
                   ON t.idTipoTelefono = tt.idTipoTelefono
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Documento AS do
                   ON do.idDocumento = p.idDocumento
			inner join Correos as CC 
					on P.idCorreo = CC.idCorreo
    WHERE  Nombre   LIKE '%' + 'j' + '%'
	and c.Estado <> '0' and p.nombre<>'Generico'




GO
/****** Object:  StoredProcedure [dbo].[Buscar_conceptos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_conceptos] @letra VARCHAR(max)
AS
    SELECT Id_concepto,
           Descripcion AS Concepto
    FROM   Conceptos
    WHERE  Descripcion LIKE '%' + @letra + '%'

GO
/****** Object:  StoredProcedure [dbo].[Buscar_id_usuarios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Buscar_id_usuarios] @Nombre_y_Apelllidos VARCHAR(50)
AS
    SELECT *
    FROM   USUARIO2
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
    WHERE  Persona.nombre = @Nombre_y_Apelllidos
    ORDER  BY idUsuario DESC

GO
/****** Object:  StoredProcedure [dbo].[Buscar_movimientos_de_kardex]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_movimientos_de_kardex] @idProducto INT
AS
  BEGIN
      SELECT KARDEX.Fecha,
             Producto.Descripcion,
             KARDEX.Motivo            AS Movimiento,
             KARDEX.Habia,
             KARDEX.Tipo,
             KARDEX.Cantidad,
             KARDEX.Hay,
             Persona.nombre           AS Cajero,
             CategoriaProductos.Descripcion AS Categoria,
             EMPRESA.Nombre_Empresa,
             EMPRESA.Logo
      FROM   dbo.KARDEX
             INNER JOIN Producto
                     ON Producto.idProducto = KARDEX.Id_producto
             INNER JOIN USUARIO2
                     ON USUARIO2.idUsuario = KARDEX.Id_usuario
             INNER JOIN Empleados
                     ON USUARIO2.idEmpleado = Empleados.idEmpleado
             INNER JOIN Persona
                     ON Empleados.idPersona = Persona.idPersona
             CROSS JOIN EMPRESA
             INNER JOIN CategoriaProductos
                     ON Producto.idCategoria = CategoriaProductos.idCategoria
      WHERE  Producto.idProducto = @idProducto
      ORDER  BY KARDEX.Fecha DESC
  END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_movimientos_de_kardex_filtros]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_movimientos_de_kardex_filtros] @fecha      DATE,
                                                          @tipo       VARCHAR(50),
                                                          @Id_usuario INT
AS
  BEGIN
      SELECT KARDEX.Fecha,
             Producto.Descripcion,
             KARDEX.Motivo             AS Movimiento,
             KARDEX.Habia,
             KARDEX.Tipo,
             KARDEX.Cantidad,
             KARDEX.Hay,
             Persona.nombre            AS Usuario,
             CategoriaProductos.Descripcion AS Categoria,
             USUARIO2.idUsuario,
             @fecha                    AS Fecha_consulta,
             @tipo                     AS Tipo_consulta,
             EMPRESA.Nombre_Empresa,
             EMPRESA.Logo
      FROM   dbo.KARDEX
             INNER JOIN Producto
                     ON Producto.idProducto = KARDEX.Id_producto
             INNER JOIN USUARIO2
                     ON USUARIO2.idUsuario = KARDEX.Id_usuario
             INNER JOIN Empleados
                     ON USUARIO2.idEmpleado = Empleados.idEmpleado
             INNER JOIN Persona
                     ON Empleados.idPersona = Persona.idPersona
               INNER JOIN CategoriaProductos
                     ON Producto.idCategoria = CategoriaProductos.idCategoria
             CROSS JOIN EMPRESA
      WHERE  KARDEX.Id_usuario = @Id_usuario
             AND ( KARDEX.Tipo = @tipo
                    OR @tipo = '-Todos-' )
             AND CONVERT(DATE, KARDEX.Fecha) = CONVERT(DATE, @fecha)
  END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_movimientos_de_kardex_filtros_acumulado]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_movimientos_de_kardex_filtros_acumulado] @fecha      DATE,
                                                                   @tipo       VARCHAR(50),
                                                                   @Id_usuario INT
AS
  BEGIN
      SELECT Producto.Descripcion,
             KARDEX.Tipo,
             Sum (KARDEX.Cantidad) Cantidad_Total,
             @fecha                AS fecha,
             Persona.nombre,
             @tipo                 AS Tipo_consultado
      FROM   dbo.KARDEX
             INNER JOIN Producto
                     ON Producto.idProducto = KARDEX.Id_producto
             INNER JOIN USUARIO2
                     ON USUARIO2.idUsuario = KARDEX.Id_usuario
             INNER JOIN Empleados
                     ON USUARIO2.idEmpleado = Empleados.idEmpleado
             INNER JOIN Persona
                     ON Empleados.idPersona = Persona.idPersona
      WHERE  KARDEX.Id_usuario = @Id_usuario
             AND ( KARDEX.Tipo = @tipo
                    OR @tipo = '-Todos-' )
             AND CONVERT(DATE, KARDEX.Fecha) = CONVERT(DATE, @fecha)
      GROUP  BY Producto.Descripcion,
                KARDEX.Tipo,
                Persona.nombre
      ORDER  BY Sum (KARDEX.Cantidad) DESC
  END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_producto_por_descripcion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Buscar_producto_por_descripcion] @letra VARCHAR(50)
AS
  BEGIN
      SELECT TOP 10 Id_Producto1,
                    Codigo,
                    Grupo_de_Productos.Linea AS Grupo,
                    Descripcion,
                    Impuesto,
                    Usa_inventarios,
                    Precio_de_compra         AS PrecioCompra,
                    Precio_mayoreo           AS PrecioMayoreo,
                    Se_vende_a               AS Se_vende_por,
                    Stock_minimo             AS StockMinimo,
                    Fecha_de_vencimiento     AS FechaVencimiento,
                    Stock                    AS StockActual,
                    Precio_de_factura        AS PrecioArticulo,
                    Grupo_de_Productos.Idline,
                    A_partir_de
      FROM   dbo.Producto1
             INNER JOIN Grupo_de_Productos
                     ON Grupo_de_Productos.Idline = Producto1.Id_grupo
      WHERE  ( dbo.Producto1.Descripcion ) + Codigo + Grupo_de_Productos.Linea LIKE '%' + @letra + '%'
      ORDER  BY DBO.Producto1.Descripcion ASC
  END 
GO
/****** Object:  StoredProcedure [dbo].[Buscar_productos_kardex]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Buscar_productos_kardex] @letrab VARCHAR(50)
AS
    SELECT TOP 10 p.idProducto,
                  ( p.Descripcion ) AS Descripcion,
                       p.Stock,
					p.Descripcion,
                    p.PrecioCompra,
                    lp.Precio_1,
                    Codigo,
                    UV.Descripcion              AS UnidadVenta,
                    i.Impuesto as ImpuestoProducto,
					d.Descuento as DescuentoProducto,
					ic.Impuesto as ImpuestoCategoria,
					dc.Descuento as DescuentoCategoria
      FROM   dbo.Producto AS p
             INNER JOIN ListaPrecios AS lp
                     ON p.idPrecios = lp.idPrecios
             INNER JOIN UnidadesVSProducto AS UVP
                     ON UVP.idProducto = p.idProducto
             INNER JOIN UnidadesProductos AS UC
                     ON UVP.idUnidadCompra = UC.idUnidad
             INNER JOIN UnidadesProductos AS UV
                     ON UVP.idUnidadVenta = UV.idUnidad
             INNER JOIN Impuestos AS i
                     ON p.idImpuesto = i.idImpuesto
		     inner join Descuentos as d
					on p.idDescuento = d.idDescuento
					INNER JOIN CategoriaProductos cp
                     ON  p.idCategoria = cp.idCategoria
		     INNER JOIN Impuestos AS IC
			 ON CP.idItbis = IC.idImpuesto
			 INNER JOIN Descuentos AS DC
			 ON CP.idDescuento = DC.idDescuento
             CROSS JOIN EMPRESA AS e
             
			 
    WHERE  ( p.Descripcion
             + Codigo ) LIKE '%' + @letrab + '%'

GO
/****** Object:  StoredProcedure [dbo].[Buscar_productos_oka]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Buscar_productos_oka] @letrab VARCHAR(50)
AS
  BEGIN
      SELECT top 10 p.idProducto,
                    ( p.Descripcion + ' /Precio: ' + e.Moneda + ' '
                      + CONVERT(VARCHAR(50), lp.Precio_1)
                      + ' /Codigo: ' + Codigo ) AS Descripcion,
                    p.Stock,
					p.Descripcion,
                    p.PrecioCompra,
                    lp.Precio_1,
                    Codigo,
                    UV.Descripcion              AS UnidadVenta,
                    i.Impuesto as ImpuestoProducto,
					d.Descuento as DescuentoProducto,
					ic.Impuesto as ImpuestoCategoria,
					dc.Descuento as DescuentoCategoria
      FROM   dbo.Producto AS p
             INNER JOIN ListaPrecios AS lp
                     ON p.idPrecios = lp.idPrecios
             INNER JOIN UnidadesVSProducto AS UVP
                     ON UVP.idProducto = p.idProducto
             INNER JOIN UnidadesProductos AS UC
                     ON UVP.idUnidadCompra = UC.idUnidad
             INNER JOIN UnidadesProductos AS UV
                     ON UVP.idUnidadVenta = UV.idUnidad
             INNER JOIN Impuestos AS i
                     ON p.idImpuesto = i.idImpuesto
		     inner join Descuentos as d
					on p.idDescuento = d.idDescuento
             CROSS JOIN EMPRESA AS e
             INNER JOIN CategoriaProductos cp
                     ON  p.idCategoria = cp.idCategoria
		     INNER JOIN Impuestos AS IC
			 ON CP.idItbis = IC.idImpuesto
			 INNER JOIN Descuentos AS DC
			 ON CP.idDescuento = DC.idDescuento
      WHERE  ( p.Descripcion + ' /Precio: ' + e.Moneda + ' '
               + CONVERT(VARCHAR(50), lp.Precio_1)
               + ' /Codigo: ' + Codigo ) LIKE '%' + @letrab + '%'
  END 
GO
/****** Object:  StoredProcedure [dbo].[Buscar_productos_vencidos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_productos_vencidos] @letra AS VARCHAR(50)
AS
    SELECT Id_Producto1,
           Codigo,
           Descripcion,
           Fecha_de_vencimiento                                          AS F_vencimiento,
           Stock,
           empresa.Nombre_Empresa,
           empresa.Logo,
           Datediff(day, Fecha_de_vencimiento, CONVERT(DATE, Getdate ()))AS [Dias Vencidos]
    FROM   Producto1
           CROSS JOIN EMPRESA
    WHERE  Descripcion + codigo LIKE '%' + @letra + '%'
           AND Fecha_de_vencimiento <> 'NO APLICA'
           AND Fecha_de_vencimiento <= CONVERT(DATE, Getdate ())
    ORDER  BY ( Datediff(day, Fecha_de_vencimiento, CONVERT(DATE, Getdate ())) ) ASC

GO
/****** Object:  StoredProcedure [dbo].[Buscar_proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_proveedores] @letra VARCHAR(max)
AS
    SELECT c.IdProveedor,
           c.idPersona,
           p.nombre              AS Nombre,
           p.apellido            AS Apellido,
           CC.Correo,
           p.fechaNacimiento,
           d.idDireccion,
           d.Descripcion         AS Direccion,
           do.idDocumento,
           do.numeracion         AS Documento,
           do.Tipo               AS TipoDocumento,
           t.idTelefono,
           t.numero              AS Telefono,
           tt.idTipoTelefono,
           tt.descripcion        AS TipoTelefono,
           c.IdentificadorFiscal AS [Identificador Fiscal],
           c.Estado,
           c.Saldo,
		   CC.idCorreo
    FROM   dbo.Proveedores AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
           INNER JOIN TipoTelefono AS tt
                   ON t.idTipoTelefono = tt.idTipoTelefono
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Documento AS do
                   ON do.idDocumento = p.idDocumento
			inner join Correos as CC
			on p.idCorreo = CC.idCorreo
    WHERE  Nombre + IdentificadorFiscal + numero LIKE '%' + @letra + '%'
           AND Nombre <> 'GENERICO'

GO
/****** Object:  StoredProcedure [dbo].[Buscar_proveedores_]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Buscar_proveedores_] @letra VARCHAR(max)
AS
    SELECT IdProveedor,
           p.nombre,
           d.Descripcion,
           IdentificadorFiscal AS [Identificador Fiscal],
           t.numero,
           Estado,
           Saldo,
		   CC.Correo
    FROM   dbo.Proveedores
           INNER JOIN Persona AS p
                   ON Proveedores.idPersona = p.idPersona
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
			inner join Correos as CC
			on P.idCorreo = CC.idCorreo
    WHERE  Nombre + IdentificadorFiscal + numero LIKE '%' + @letra + '%'
           AND Nombre <> 'GENERICO'

GO
/****** Object:  StoredProcedure [dbo].[Buscar_proveedores5]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Buscar_proveedores5] @letra VARCHAR(max)
AS
    SELECT c.IdProveedor,
           c.idPersona,
           p.nombre              AS Nombre
    FROM   dbo.Proveedores AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
    WHERE  Nombre   LIKE '%' + @letra + '%'
           AND Nombre <> 'GENERICO'

GO
/****** Object:  StoredProcedure [dbo].[Buscar_tipo_de_documentos_para_insertar_en_compras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Buscar_tipo_de_documentos_para_insertar_en_compras] @letra VARCHAR(50)
AS
  BEGIN
      SELECT Serializacion.tipodoc             AS COMPROBANTE,
             dbo.Serializacion.Serie,
             dbo.Serializacion.Cantidad_de_numeros,
             dbo.Serializacion.numerofin,
             dbo.Serializacion.Id_serializacion,
             ( dbo.Serializacion.Serie + ' - '
               + dbo.Serializacion.Cantidad_de_numeros
               + dbo.Serializacion.numerofin ) AS serie_completa
      FROM   dbo.Serializacion
      WHERE  Serializacion.tipodoc = @letra
             AND dbo.Serializacion .Destino = 'FACTURAS'
  END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_tipo_de_documentos_para_insertar_en_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_tipo_de_documentos_para_insertar_en_cotizacion] @letra VARCHAR(50)
AS
  BEGIN
      SELECT Serializacion.tipodoc             AS COMPROBANTE,
             dbo.Serializacion.Serie,
             dbo.Serializacion.Cantidad_de_numeros,
             dbo.Serializacion.numerofin,
             dbo.Serializacion.Id_serializacion,
             ( dbo.Serializacion.Serie + ' - '
               + dbo.Serializacion.Cantidad_de_numeros
               + dbo.Serializacion.numerofin ) AS serie_completa
      FROM   dbo.Serializacion
      WHERE  Serializacion.tipodoc = @letra
             AND dbo.Serializacion .Destino = 'COTIZACION'
  END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_tipo_de_documentos_para_insertar_en_facturas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_tipo_de_documentos_para_insertar_en_facturas] @letra VARCHAR(50)
AS
  BEGIN
      SELECT Serializacion.tipodoc             AS COMPROBANTE,
             dbo.Serializacion.Serie,
             dbo.Serializacion.Cantidad_de_numeros,
             dbo.Serializacion.numerofin,
             dbo.Serializacion.Id_serializacion,
             ( dbo.Serializacion.Serie + ' - '
               + dbo.Serializacion.Cantidad_de_numeros
               + dbo.Serializacion.numerofin ) AS serie_completa
      FROM   dbo.Serializacion
      WHERE  Serializacion.tipodoc = @letra
             AND dbo.Serializacion .Destino = 'FACTURAS'
  END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscar_usuario] @letra VARCHAR(50)
AS
    SELECT u.idUsuario,
           u.idEmpleado,
           e.idPersona,
           p.nombre          AS Nombre,
           p.apellido        AS Apellido,
           u.Login,
           u.Password,
           R.Rol,
           u.Nombre_de_icono AS NombreIcono,
           u.Icono,
           u.Estado,
		   p.idCorreo,
		   C.Correo
    FROM   USUARIO2 AS u
           INNER JOIN Empleados AS e
                   ON u.idEmpleado = e.idEmpleado
           INNER JOIN Persona AS p
                   ON e.idPersona = p.idPersona
				   INNER JOIN Roles AS R
				ON u.idRol = R.idRol
				INNER JOIN correos as C
				on p.idCorreo = c.idCorreo
    WHERE  p.nombre + Login LIKE '%' + @letra + '%'
           AND u.Estado = 'ACTIVO'

GO
/****** Object:  StoredProcedure [dbo].[buscar_USUARIO_por_correo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_USUARIO_por_correo]
@log as varchar(50)
as
	select C.Correo from Correos as C
	INNER JOIN Persona as P
	on C.idCorreo = P.idCorreo
	INNER JOIN Empleados AS E
	on P.idPersona = E.idPersona
	INNER JOIN USUARIO2 as U
	on E.idEmpleado = U.idEmpleado
	where U.Login = @log
	
GO
/****** Object:  StoredProcedure [dbo].[BuscarCompras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[BuscarCompras] @busqueda VARCHAR(50)
AS
    SELECT com.idCompra,
           com.fecha_compra                        AS Fecha,
           ( com.Comprobante + ' '
             + com.Numero_de_doc )                     AS Comprobante,
           com.Monto_total,
           UsuN.nombre,
           ( dbo.EMPRESA.Moneda + ' '
             + CONVERT(VARCHAR(50), com.Monto_total) ) AS Total,
           ProvN.nombre                             AS Cliente,
           com.Tipo_de_pago,
           com.Vuelto
    FROM   dbo.compras as com
           INNER JOIN dbo.USUARIO2 as Usu
                   ON com.Id_usuario = Usu.idUsuario
           INNER JOIN dbo.Proveedores as prov
                   ON com.idProveedor = prov.IdProveedor
		   INNER JOIN Empleados AS Emp
                   ON Usu.idEmpleado = Emp.idEmpleado
           INNER JOIN Persona AS ProvN
                   ON prov.idPersona = ProvN.idPersona
           INNER JOIN Persona AS UsuN
                   ON Emp.idPersona = UsuN.idPersona
           CROSS JOIN dbo.EMPRESA
    WHERE  Comprobante + Numero_de_doc LIKE '%' + @busqueda + '%'
           AND com.Monto_total > 0
		   
GO
/****** Object:  StoredProcedure [dbo].[Buscarcomprasporfechas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Buscarcomprasporfechas] @fi DATE,
                                          @ff DATE
AS
    SELECT com.idCompra,
           com.fecha_compra                         AS Fecha,
           ( com.Comprobante + ' '
             + com.Numero_de_doc )                     AS Comprobante,
           com.Monto_total,
           P.nombre as Cajero,
           ( dbo.EMPRESA.Moneda + ' '
             + CONVERT(VARCHAR(50), com.Monto_total) ) AS Total,
           com.Tipo_de_pago,
           com.Vuelto,
		   com.Trasferencia_Bancaria,
		   Persona.nombre as Proveedor
    FROM   dbo.compras as com
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = com.Id_usuario
           INNER JOIN Proveedores
                   ON Proveedores .IdProveedor = com.idProveedor
           INNER JOIN Persona
                   ON Proveedores.idPersona = Persona.idPersona
		   INNER JOIN Empleados AS E
				   ON USUARIO2.idEmpleado = E.idEmpleado
		   INNER JOIN Persona P
			       ON E.idPersona = P.idPersona
           CROSS JOIN dbo.EMPRESA
    WHERE  CONVERT(DATE, com.fecha_compra) >= @fi
           AND CONVERT(DATE, com.fecha_compra) <= @ff
           AND com.Monto_total > 0
GO
/****** Object:  StoredProcedure [dbo].[buscarDescuentos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[buscarDescuentos]
@buscar as varchar(50)
AS
      SELECT 
	  idDescuento,
	  Descuento,
	  TipoDescuento
	  from Descuentos
	  WHERE  Descuento  LIKE '%'  + @buscar + '%' and TipoDescuento <> 'Descuento de Categoria'
GO
/****** Object:  StoredProcedure [dbo].[buscarDescuentosCategoria]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[buscarDescuentosCategoria]
@buscar as varchar(50)
AS
      SELECT 
	  idDescuento,
	  Descuento,
	  TipoDescuento
	  from Descuentos
	  WHERE  Descuento  LIKE '%'  + @buscar + '%' and TipoDescuento = 'Descuento Categoria'
GO
/****** Object:  StoredProcedure [dbo].[buscarDescuentosModulo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[buscarDescuentosModulo] @buscar VARCHAR(50)
AS
  BEGIN
      SELECT idDescuento
			 ,Descuento
			 ,TipoDescuento as TipoDescuento
      FROM   Descuentos
      WHERE  TipoDescuento LIKE '%' + @buscar + '%'
  END
GO
/****** Object:  StoredProcedure [dbo].[Buscardireccion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscardireccion] @letra VARCHAR(50)
AS
    SELECT idDireccion,
           descripcion
    FROM   Direccion
    WHERE  Descripcion LIKE '%' + @letra + '%'
	and Descripcion <> 'Direccion empresarial'

GO
/****** Object:  StoredProcedure [dbo].[Buscarempleado]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscarempleado] @letra VARCHAR(50)
AS
     SELECT c.idEmpleado,
           c.idPersona,
           e.idHorario,
           p.nombre       AS Nombre,
           p.apellido     AS Apellido,
           cc.Correo,
           p.fechaNacimiento,
           d.idDireccion,
           d.Descripcion  AS Direccion,
           do.idDocumento,
           do.numeracion  AS Documento,
           do.Tipo        AS TipoDocumento,
           t.idTelefono,
           t.numero       AS Telefono,
           tt.idTipoTelefono,
           tt.descripcion AS TipoTelefono,
           e.Entrada,
           e.Salida,
           e.TipoHorario  AS idTipoHorario,
           th.Descripcion AS TipoHorario,
           c.CuentaBanco,
           c.Departamento,
           c.Banco,
           c.Icono,
           c.Estado
    FROM   dbo.Empleados AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
           INNER JOIN TipoTelefono AS tt
                   ON t.idTipoTelefono = tt.idTipoTelefono
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Documento AS do
                   ON do.idDocumento = p.idDocumento
           INNER JOIN Horario AS e
                   ON e.idHorario = c.idHorario
           INNER JOIN TipoHorario AS th
                   ON th.idTipoHorario = e.TipoHorario
			inner join Correos as cc
			on p.idCorreo = cc.idCorreo
    WHERE  p.nombre + p.apellido LIKE '%' + @letra + '%'

GO
/****** Object:  StoredProcedure [dbo].[Buscarempleado2]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscarempleado2] @letra VARCHAR(50)
AS
    SELECT c.idEmpleado,
           c.idPersona,
           p.nombre       AS Nombre,
           p.apellido     AS Apellido
    FROM   dbo.Empleados AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
    WHERE  p.nombre + p.apellido LIKE '%' + @letra + '%'
	
GO
/****** Object:  StoredProcedure [dbo].[Buscarempleado3]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Buscarempleado3] @letra VARCHAR(50)
AS
    SELECT c.idEmpleado,
           c.idPersona,
           p.nombre       AS Nombre,
           p.apellido     AS Apellido
    FROM   dbo.Empleados AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
    WHERE  p.nombre + p.apellido LIKE '%' + @letra + '%'
	AND p.nombre = 'Administrador'
GO
/****** Object:  StoredProcedure [dbo].[buscarEmpleadosV]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[buscarEmpleadosV]
@letra as varchar(50)
as
    SELECT e.idEmpleado,
           p.nombre as Nombre,
           e.Departamento,
           e.Estado
    FROM   Empleados AS e
           INNER JOIN Persona AS p
                   ON e.idPersona = p.idPersona
    WHERE  p.nombre + e.Departamento Like '%' + @letra + '%' and Estado = 'ACTIVO'
           AND Departamento = 'Departamento de Envios' AND Estado <> 'PROCESANDO ENVIO'


GO
/****** Object:  StoredProcedure [dbo].[BuscarfactsProveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarfactsProveedores] @idProveedor AS INT
AS
    SELECT F.idFactura AS idFactura,
           F.NumFact   AS NumFactura
    FROM   FacturasProveedores AS F
    WHERE  F.idProveedor = @idProveedor 
GO
/****** Object:  StoredProcedure [dbo].[BuscarFacturas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BuscarFacturas] @busqueda VARCHAR(50)
AS
    SELECT Fact.idFactura,
           Fact.fecha_factura                         AS Fecha,
           ( Fact.Comprobante + ' '
             + Fact.Numero_de_doc )                     AS Comprobante,
           Fact.Monto_total,
           UsuN.nombre,
           Fact.Pago_con,
           ( dbo.EMPRESA.Moneda + ' '
             + CONVERT(VARCHAR(50), Fact.Monto_total) ) AS Total,
           CliN.nombre                             AS Cliente,
           Fact.Tipo_de_pago,
           Fact.Vuelto
    FROM   dbo.facturas as Fact
           INNER JOIN dbo.USUARIO2 as Usu
                   ON Fact.Id_usuario = Usu.idUsuario
           INNER JOIN dbo.clientes as cli
                   ON Fact.idclientev = cli.idclientev
		   INNER JOIN Empleados AS Emp
                   ON Usu.idEmpleado = Emp.idEmpleado
           INNER JOIN Persona AS CliN
                   ON Cli.idPersona = CliN.idPersona
           INNER JOIN Persona AS UsuN
                   ON Emp.idPersona = UsuN.idPersona
           CROSS JOIN dbo.EMPRESA
    WHERE  Comprobante + Numero_de_doc LIKE '%' + @busqueda + '%'
           AND Fact.Monto_total > 0
GO
/****** Object:  StoredProcedure [dbo].[Buscarfacturasporfechas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscarfacturasporfechas] @fi DATE,
                                          @ff DATE
AS
    SELECT Fact.idFactura,
          Fact.fecha_factura                         AS Fecha,
           ( Fact.Comprobante + ' '
             + Fact.Numero_de_doc )                     AS Comprobante,
          Fact.Monto_total,
           UsuN.nombre,
           Fact.Pago_con,
           ( dbo.EMPRESA.Moneda + ' '
             + CONVERT(VARCHAR(50), Fact.Monto_total) ) AS Total,
           Fact.Tipo_de_pago,
           Fact.Vuelto,
		   CliN.nombre as Cliente
    FROM   dbo.facturas as Fact
           INNER JOIN dbo.USUARIO2 as Usu
                   ON Fact.Id_usuario = Usu.idUsuario
           INNER JOIN dbo.clientes as cli
                   ON Fact.idclientev = cli.idclientev
		   INNER JOIN Empleados AS Emp
                   ON Usu.idEmpleado = Emp.idEmpleado
           INNER JOIN Persona AS CliN
                   ON Cli.idPersona = CliN.idPersona
           INNER JOIN Persona AS UsuN
                   ON Emp.idPersona = UsuN.idPersona
           CROSS JOIN dbo.EMPRESA
    WHERE  CONVERT(DATE, Fact.fecha_factura) >= @fi
           AND CONVERT(DATE, Fact.fecha_factura) <= @ff
           AND Fact.Monto_total > 0

GO
/****** Object:  StoredProcedure [dbo].[buscarImpuesto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[buscarImpuesto]
@cadena as varchar(50)
AS
  BEGIN
      SELECT idImpuesto,
             Nombre AS nombre,
			 Impuesto as Itbis,
			 Tipo as Tipo
      FROM   Impuestos
	  WHERE  @Cadena = Nombre and Tipo = 'IVA'
  END
GO
/****** Object:  StoredProcedure [dbo].[buscarImpuestosCategoria]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[buscarImpuestosCategoria]
@buscar as varchar(50)
AS
      SELECT 
	  idImpuesto,
	  Impuesto,
	  Tipo
	  from Impuestos
	  WHERE  Impuesto  LIKE '%'  + @buscar + '%' and Tipo = 'Impuesto Categoria'
GO
/****** Object:  StoredProcedure [dbo].[buscarPreciosCompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[buscarPreciosCompra]
@buscar as varchar(50),
@idProducto as int
AS

      SELECT pr.idProveedor,
             pr.idProducto,
			 Pe.nombre as Nombre,
			 pr.PrecioCompra,
			 pr.FechaCompra as Fecha
      FROM   PreciosCompraProveedor as pr
	  inner join Proveedores as p
	  on pr.IdProveedor = p.IdProveedor
	  inner join Persona as Pe
	  on p.idPersona = Pe.idPersona
	  WHERE  nombre  LIKE '%'  + @buscar + '%' AND idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[buscarProductosProveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buscarProductosProveedores] @letrab VARCHAR(50)
AS
  BEGIN
      SELECT top 3 p.idProducto,
					p.Descripcion
      FROM   dbo.Producto AS p
      WHERE  p.Descripcion LIKE '%' + @letrab + '%'
  END 
GO
/****** Object:  StoredProcedure [dbo].[buscarprodutos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscarprodutos]
@buscar as varchar(50)
AS
    SELECT p.idProducto,
           p.idCategoria,
           p.idPrecios,
           p.Codigo AS Codigo,
           p.Descripcion,
           p.Stock,
           p.PrecioCompra,
           p.idImpuesto,
           p.idDescuento,
		   cp.Descripcion as Categoria,
		   cp.Departamento as DepartamentoCat,
		   lp.idMayoreo,
		   lp.Precio_1 as PrecioVenta,
		   lp.Precio_2,
		   lp.Precio_3,
		   lp.Precio_4,
		   vm.Unidades_1,
		   vm.Unidades_2,
		   vm.Unidades_3,
		   vm.Unidades_4,
		   i.Impuesto as Itbis,
		   d.Descuento as Descuento,
		   UPP.Descripcion AS UnidadCompra,
		   UPP2.Descripcion as UnidadVenta,
		   UP.idUnidadCompra,
		   UP.idUnidadVenta
    FROM   Producto AS p 
	Inner join CategoriaProductos as cp
	on p.idCategoria = cp.idCategoria
	Inner join ListaPrecios as lp
	on p.idPrecios = lp.idPrecios
	Inner joiN VentasMayoreo AS vm
	on lp.idMayoreo = vm.idMayoreo
	inner join Impuestos as i
	on p.idImpuesto = i.idImpuesto
	inner join Descuentos as d
	on p.idDescuento = d.idDescuento
	inner join UnidadesVSProducto as UP
	on UP.idProducto = p.idProducto
	inner join UnidadesProductos as UPP
	on UP.idUnidadCompra = UPP.idUnidad
	inner join UnidadesProductos as UPP2
	ON UP.idUnidadVenta = UPP2.idUnidad
	where p.Descripcion + cp.Descripcion like '%' + @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscartipovehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscartipovehiculo] @letra VARCHAR(50)
AS
    SELECT idTipoVehiculo,
           descripcion,
           capacidad
    FROM   TipoVehiculo
    WHERE  descripcion LIKE '%' + @letra + '%'

GO
/****** Object:  StoredProcedure [dbo].[buscarUnidades]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[buscarUnidades] @buscar VARCHAR(50)
AS
  BEGIN
      SELECT idUnidad
			 ,idClaveSat
			 ,Descripcion as Descripción
      FROM   UnidadesProductos
      WHERE  Descripcion LIKE '%' + @buscar + '%'
  END
GO
/****** Object:  StoredProcedure [dbo].[Buscarvehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Buscarvehiculo] @letra VARCHAR(50)
AS
    SELECT idVehiculo,
           NPlaca AS Placa,
           Transmision,
           Color,
           Marca,
           Modelo,
           Ano,
           Icono,
           Estado
    FROM   Vehiculos
    WHERE  NPlaca LIKE '%' + @letra + '%'
           AND Estado = 'ACTIVO'

GO
/****** Object:  StoredProcedure [dbo].[buscarVehiculosV]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[buscarVehiculosV]
@letra as varchar(50)
AS
    SELECT idVehiculo,
		   Modelo,
           Estado
    FROM   Vehiculos
    WHERE  Estado = 'ACTIVO' OR Estado <> 'PROCESANDO ENVIO'
	AND Modelo like '%' + @letra + '%'
GO
/****** Object:  StoredProcedure [dbo].[Cambio_de_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Cambio_de_caja] @idcaja    INT,
                                   @idFactura INT
AS
    UPDATE facturas
    SET    Id_caja = @idcaja
    WHERE  idFactura = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[cambio_de_CajaCompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[cambio_de_CajaCompra] @idcaja    INT,
                                   @idFactura INT
AS
    UPDATE compras
    SET    Id_caja = @idcaja
    WHERE  idCompra = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[cambio_de_Cajacotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cambio_de_Cajacotizacion] @idcaja    INT,
                                   @idFactura INT
AS
    UPDATE facturas
    SET    Id_caja = @idcaja
    WHERE  idFactura = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[Cerrarcaja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cerrarcaja] @fechafin            AS DATETIME,
                                    @fechacierre         AS DATETIME,
                                    @ingresos            AS NUMERIC(18, 2),
                                    @egresos             AS NUMERIC(18, 2),
                                    @Saldo_queda_en_caja AS NUMERIC(18, 2),
                                    @Id_usuario          AS INT,
                                    @Total_calculado     AS NUMERIC(18, 2),
                                    @Total_real          AS NUMERIC(18, 2),
                                    @Estado              AS VARCHAR(50),
                                    @Diferencia          AS NUMERIC(18, 2),
                                    @Id_caja             AS INT
AS
    UPDATE MOVIMIENTOCAJACIERRE
    SET    fechafin = @fechafin,
           fechacierre = @fechacierre,
           ingresos = @ingresos,
           egresos = @egresos,
           Saldo_queda_en_caja = @Saldo_queda_en_caja,
           Id_usuario = @Id_usuario,
           Total_calculado = @Total_calculado,
           Total_real = @Total_real,
           Estado = @Estado,
           Diferencia = @Diferencia
    WHERE  Id_caja = @Id_caja

GO
/****** Object:  StoredProcedure [dbo].[Confirmar_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Confirmar_compra] 
@idCompra        INT,
                                         @montototal         AS NUMERIC(18, 2),
                                         @Saldo              NUMERIC(18, 2),
                                         @Tipo_de_pago       VARCHAR(50),
                                         @Estado             VARCHAR(50),
                                         @Comprobante        VARCHAR(50),
                                         @Numero_de_doc      VARCHAR(50),
                                         @fecha_compra       DATETIME,
                                         @ACCION             VARCHAR(50),
                                         @Fecha_de_pago      VARCHAR(50),
                                         @idProveedor          INT,
                                         @Vuelto             AS NUMERIC(18, 2),
                                         @TotalPagado         NUMERIC(18, 2),
										 @Transferencia_Bancaria AS VARCHAR(50)
AS
  BEGIN
      IF EXISTS (SELECT Numero_de_doc
                 FROM   compras
                 WHERE  Numero_de_doc = @Numero_de_doc)
        RAISERROR ('Ya existe un Numero de Comprobante con ese Numero y Serie',16,1)
      ELSE
        BEGIN
            UPDATE compras
            SET    Monto_total = @montototal,
                   Saldo = @Saldo,
                   Tipo_de_pago = @Tipo_de_pago,
                   Estado = @Estado,
                   Comprobante = @Comprobante,
                   Numero_de_doc = @Numero_de_doc,
                   fecha_compra = @fecha_compra,
                   ACCION = @ACCION,
                   Fecha_de_pago = @Fecha_de_pago,
                   idProveedor = @idProveedor,
                   Vuelto = @Vuelto,
                   TotalPagado = @TotalPagado,
				   Trasferencia_Bancaria = @Transferencia_Bancaria
            WHERE  idCompra = @idCompra
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Confirmar_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Confirmar_cotizacion] @idcotizacion       INT,
                                              @montototal         AS NUMERIC(18, 2),
                                              @IGV                AS NUMERIC(18, 2),
                                              @Saldo              NUMERIC(18, 2),
                                              @Tipo_de_pago       VARCHAR(50),
                                              @Estado             VARCHAR(50),
                                              @Comprobante        VARCHAR(50),
                                              @Numero_de_doc      VARCHAR(50),
                                              @fecha_factura        DATETIME,
                                              @ACCION             VARCHAR(50),
                                              @Fecha_de_pago      VARCHAR(50),
                                              @idcliente          INT,
                                              @Pago_con           NUMERIC(18, 2),
                                              @Referencia_tarjeta VARCHAR(50),
                                              @Vuelto             AS NUMERIC(18, 2),
                                              @Efectivo           AS NUMERIC(18, 2),
                                              @Credito            NUMERIC(18, 2),
                                              @Tarjeta            NUMERIC(18, 2)
AS
  BEGIN
      IF EXISTS (SELECT Numero_de_doc
                 FROM   Cotizacion
                 WHERE  Numero_de_doc = @Numero_de_doc)
        RAISERROR ('Ya existe un Numero de Comprobante con ese Numero y Serie',16,1)
      ELSE
        BEGIN
            UPDATE Cotizacion
            SET    Monto_total = @montototal,
                   IGV = @IGV,
                   Saldo = @Saldo,
                   Tipo_de_pago = @Tipo_de_pago,
                   Estado = @Estado,
                   Comprobante = @Comprobante,
                   Numero_de_doc = @Numero_de_doc,
                   fecha_cotizacion = @fecha_factura,
                   ACCION = @ACCION,
                   Fecha_de_pago = @Fecha_de_pago,
                   idclientev = @idcliente,
                   Pago_con = @Pago_con,
                   Referencia_tarjeta = @Referencia_tarjeta,
                   Vuelto = @Vuelto,
                   Efectivo = @Efectivo,
                   Credito = @Credito,
                   Tarjeta = @Tarjeta
            WHERE  idcotizacion = @idcotizacion
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Confirmar_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Confirmar_factura] @idFactura          INT,
                                         @montototal         AS NUMERIC(18, 2),
                                         @Saldo              NUMERIC(18, 2),
                                         @Tipo_de_pago       VARCHAR(50),
                                         @Estado             VARCHAR(50),
                                         @Comprobante        VARCHAR(50),
                                         @Numero_de_doc      VARCHAR(50),
                                         @fecha_factura        DATETIME,
                                         @ACCION             VARCHAR(50),
                                         @Fecha_de_pago      VARCHAR(50),
                                         @idcliente          INT,
                                         @Pago_con           NUMERIC(18, 2),
                                         @Referencia_tarjeta VARCHAR(50),
                                         @Vuelto             AS NUMERIC(18, 2),
                                         @Efectivo           AS NUMERIC(18, 2),
                                         @Credito            NUMERIC(18, 2),
                                         @Tarjeta            NUMERIC(18, 2)
AS
  BEGIN
      IF EXISTS (SELECT Numero_de_doc
                 FROM   facturas
                 WHERE  Numero_de_doc = @Numero_de_doc)
        RAISERROR ('Ya existe un Numero de Comprobante con ese Numero y Serie',16,1)
      ELSE
        BEGIN
            UPDATE facturas
            SET    Monto_total = @montototal,
                   Saldo = @Saldo,
                   Tipo_de_pago = @Tipo_de_pago,
                   Estado = @Estado,
                   Comprobante = @Comprobante,
                   Numero_de_doc = @Numero_de_doc,
                   fecha_factura = @fecha_factura,
                   ACCION = @ACCION,
                   Fecha_de_pago = @Fecha_de_pago,
                   idclientev = @idcliente,
                   Pago_con = @Pago_con,
                   Referencia_tarjeta = @Referencia_tarjeta,
                   Vuelto = @Vuelto,
                   Efectivo = @Efectivo,
                   Credito = @Credito,
                   Tarjeta = @Tarjeta
            WHERE  idFactura = @idFactura
			UPDATE detalle_factura
			set Estado = @Estado
			where idFactura = @idFactura
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Contar_productos_vencidos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Contar_productos_vencidos]
AS
    SELECT Count (Producto.idProducto)AS id
    FROM   Producto
	inner join DetalleProducto
	on Producto.idProducto = DetalleProducto.idProveedor
    WHERE  DetalleProducto.FechaVencimiento <> 'NO APLICA'
           AND FechaVencimiento <= CONVERT (DATE, Getdate())

GO
/****** Object:  StoredProcedure [dbo].[Contarcomprasespera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Contarcomprasespera]
AS
    SELECT Count (idCompra)
    FROM   compras
    WHERE  Estado = 'EN ESPERA'
           AND ACCION <> 'COMPRA'

GO
/****** Object:  StoredProcedure [dbo].[Contarcotizacionesespera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Contarcotizacionesespera]
AS
    SELECT Count (idFactura)
    FROM   facturas
    WHERE  Estado = 'EN ESPERA'
           AND ACCION <> 'FACTURA'
GO
/****** Object:  StoredProcedure [dbo].[Contarfacturasespera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Contarfacturasespera]
AS
    SELECT Count (idFactura)
    FROM   facturas
    WHERE  Estado = 'EN ESPERA'
           AND ACCION <> 'COTIZACION'

GO
/****** Object:  StoredProcedure [dbo].[Detallecompradevolucion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Detallecompradevolucion] @iddetalle        INT,
                                           @cantidad         NUMERIC(18, 2)
AS
    UPDATE detalle_compra
    SET    cantidad = cantidad - @cantidad
    WHERE  iddetalle_compra = @iddetalle

    DELETE FROM detalle_compra
    WHERE  iddetalle_compra = @iddetalle
           AND cantidad = 0

GO
/****** Object:  StoredProcedure [dbo].[Detallefacturadevolucion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Detallefacturadevolucion] @iddetalle        INT,
                                           @cantidad         NUMERIC(18, 2)
AS
    UPDATE detalle_factura
    SET    cantidad = cantidad - @cantidad
    WHERE  iddetalle_factura = @iddetalle

    DELETE FROM detalle_factura
    WHERE  iddetalle_factura = @iddetalle
           AND cantidad = 0

GO
/****** Object:  StoredProcedure [dbo].[Disminuir_stock]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Disminuir_stock] @idproducto AS INT,
                                    @cantidad   AS NUMERIC (18, 2)
AS
    UPDATE Producto
    SET    Stock = Stock - @cantidad
    WHERE  idProducto = @idproducto
           AND Stock >= @cantidad

GO
/****** Object:  StoredProcedure [dbo].[Disminuir_stock_en_detalle_de_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Disminuir_stock_en_detalle_de_compra] @Id_Producto1 AS INT,
                                                        @cantidad     AS NUMERIC (18, 2)
AS
    UPDATE detalle_compra
    SET    Stock = Stock - @cantidad
    WHERE  Id_producto = @Id_Producto1
           AND Stock <> 'Ilimitado'

GO
/****** Object:  StoredProcedure [dbo].[Disminuir_stock_en_detalle_de_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Disminuir_stock_en_detalle_de_cotizacion] @Id_Producto1 AS INT,
                                                             @cantidad     AS NUMERIC (18, 2)
AS
    UPDATE detalle_cotizacion
    SET    Stock = Stock - @cantidad
    WHERE  Id_producto = @Id_Producto1
           AND Stock <> 'Ilimitado'

GO
/****** Object:  StoredProcedure [dbo].[Disminuir_stock_en_detalle_de_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Disminuir_stock_en_detalle_de_factura] @Id_Producto1 AS INT,
                                                        @cantidad     AS NUMERIC (18, 2)
AS
    UPDATE detalle_factura
    SET    Stock = Stock - @cantidad
    WHERE  Id_producto = @Id_Producto1
           AND Stock <> 'Ilimitado'

GO
/****** Object:  StoredProcedure [dbo].[Disminuirsaldocliente]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Disminuirsaldocliente] @idcliente INT,
                                          @monto     NUMERIC(18, 2)
AS
    UPDATE clientes
    SET    Saldo = Saldo - @monto
    WHERE  idclientev = @idcliente

GO
/****** Object:  StoredProcedure [dbo].[Disminuirsaldofactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Disminuirsaldofactura] @numFact INT,
                                          @monto     NUMERIC(18, 2)
AS
    UPDATE FacturasProveedores
    SET    Saldo = Saldo - @monto
    WHERE  NumFact = @numFact

GO
/****** Object:  StoredProcedure [dbo].[DisminuirsaldoProveedor]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

create PROC [dbo].[DisminuirsaldoProveedor] @idProveedor INT,
                                          @monto     NUMERIC(18, 2)
AS
    UPDATE Proveedores
    SET    Saldo = Saldo - @monto
    WHERE  IdProveedor = @idProveedor

GO
/****** Object:  StoredProcedure [dbo].[Editar_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_caja] @idcaja      INTEGER,
                                     @descripcion VARCHAR(50)
AS
    IF EXISTS (SELECT Descripcion
               FROM   Caja
               WHERE  ( Descripcion = @descripcion
                        AND Id_Caja <> @idcaja ))
      RAISERROR ('YA EXISTE UN REGISTRO  CON ESTE NOMBRE, POR FAVOR INGRESE DE NUEVO',16,1)
    ELSE
      UPDATE Caja
      SET    Descripcion = @descripcion
      WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Editar_caja_impresoras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_caja_impresoras] @idcaja           INTEGER,
                                                @Impresora_Ticket VARCHAR(max),
                                                @Impresora_A4     VARCHAR(max)
AS
    UPDATE Caja
    SET    Impresora_Ticket = @Impresora_Ticket,
           Impresora_A4 = @Impresora_A4
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Editar_clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_clientes] @idCliente           AS INT,
                                    @idPersona           AS INT,
                                    @IdentificadorFiscal AS VARCHAR(MAX)
AS
    IF EXISTS(SELECT idPersona
              FROM   clientes
              WHERE  idPersona = @idPersona
                     AND idclientev <> @idCliente)
      RAISERROR('Registro ya existente',16,1)
    ELSE
      UPDATE clientes
      SET    idPersona = @idPersona,
             IdentificadorFiscal = @IdentificadorFiscal
      WHERE  idclientev = @idCliente

GO
/****** Object:  StoredProcedure [dbo].[Editar_conceptos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_conceptos] @Id_concepto AS INT,
                                     @Descripcion AS VARCHAR(MAX)
AS
    IF EXISTS(SELECT Descripcion
              FROM   Conceptos
              WHERE  Descripcion = @Descripcion
                     AND Id_concepto <> @Id_concepto)
      RAISERROR('Concepto ya registrado',16,1 )
    ELSE
      UPDATE Conceptos
      SET    Descripcion = @Descripcion
      WHERE  Id_concepto = @Id_concepto

GO
/****** Object:  StoredProcedure [dbo].[editar_correo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editar_correo] 
@idCorreo as int,
@correo as varchar(50)
as
	UPDATE Correos
	set Correo = @correo
	where idCorreo = @idCorreo
GO
/****** Object:  StoredProcedure [dbo].[Editar_correo_base]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_correo_base] @Correo          VARCHAR(max),
                                       @Password        VARCHAR(max),
                                       @Estado_De_envio VARCHAR(50)
AS
    UPDATE CorreoBase
    SET    Correo = @Correo,
           Password = @Password,
           EstadoEnvio = @Estado_De_envio

GO
/****** Object:  StoredProcedure [dbo].[Editar_creditoporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Editar_creditoporpagar] @Id_credito        AS INT,
                                           @Descripcion       AS VARCHAR(MAX),
                                           @Fecha_registro    AS DATETIME,
                                           @Fecha_vencimiento AS DATE,
                                           @Total             AS NUMERIC(18, 2),
                                           @Saldo             AS NUMERIC(18, 2),
                                           @Estado            AS VARCHAR(MAX),
                                           @Id_caja           AS INT,
                                           @Id_Proveedor      AS INT
AS
    UPDATE CreditoPorPagar
    SET    Descripcion = @Descripcion,
           Fecha_registro = @Fecha_registro,
           Fecha_vencimiento = @Fecha_vencimiento,
           Total = @Total,
           Saldo = @Saldo,
           Estado = @Estado,
           Id_caja = @Id_caja,
           Id_Proveedor = @Id_Proveedor
    WHERE  Id_credito = @Id_credito

GO
/****** Object:  StoredProcedure [dbo].[Editar_detalle_compra_cantidad]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_detalle_compra_cantidad] @Id_producto       INT,
                                                  @cantidad          AS NUMERIC(18, 2),
                                                  @Id_compra         AS INT
AS
    
  BEGIN
      UPDATE detalle_compra
      SET    cantidad = @cantidad
      WHERE  detalle_compra.Id_producto = @Id_producto
             AND detalle_compra.idCompra = @Id_compra  
  END

  BEGIN
      IF EXISTS(SELECT cantidad
                FROM   detalle_compra
                WHERE  detalle_compra.idCompra = @Id_compra  
                       AND detalle_compra.Codigo = '0')
        UPDATE detalle_compra
        SET    Codigo = 0
        WHERE  detalle_compra.Codigo = '0'
               AND detalle_compra.idCompra = @Id_compra
  END

GO
/****** Object:  StoredProcedure [dbo].[Editar_detalle_compra_restar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_detalle_compra_restar] @iddetalle_factura   INT,
                                                @cantidad          AS NUMERIC(18, 2),
                                                @Id_producto       int,
                                                @Id_compra          AS INT
AS
  BEGIN
      UPDATE detalle_compra
      SET    cantidad = cantidad - @cantidad
      WHERE  detalle_compra.Id_producto = @Id_producto
             AND detalle_compra.idCompra = @Id_compra 
  END

  BEGIN
      DELETE FROM detalle_compra
      WHERE  detalle_compra.idCompra = @Id_compra 
             AND cantidad <= 0
  END


  BEGIN
      IF EXISTS(SELECT cantidad
                FROM   detalle_compra
                WHERE  detalle_compra .idCompra = @Id_compra
                       AND detalle_compra.Codigo = '0')
        UPDATE detalle_compra
        SET    Codigo = 0
        WHERE  detalle_compra.Codigo = '0'
               AND detalle_compra.idCompra = @Id_compra
  END

GO
/****** Object:  StoredProcedure [dbo].[Editar_detalle_compra_sumar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_detalle_compra_sumar] @Id_producto       INT,
                                               @cantidad          AS NUMERIC(18, 2),
                                               @Id_compra         AS INT
AS
    
  BEGIN
      UPDATE detalle_compra
      SET    cantidad = cantidad + @cantidad
      WHERE  detalle_compra.Id_producto = @Id_producto
             AND detalle_compra.idCompra = @Id_compra
  END

  BEGIN
      IF EXISTS(SELECT cantidad
                FROM   detalle_compra
                WHERE  detalle_compra .idCompra = @Id_compra
                       AND detalle_compra.Codigo = '0')
        UPDATE detalle_compra
        SET    Codigo = 0
        WHERE  detalle_compra.Codigo = '0'
               AND detalle_compra.idCompra = @Id_compra
  END

GO
/****** Object:  StoredProcedure [dbo].[Editar_detalle_factura_restar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_detalle_factura_restar] @iddetalle_factura   INT,
                                                @cantidad          AS NUMERIC(18, 2),
                                                @Id_producto       VARCHAR(50),
                                                @Id_factura          AS INT
AS
  BEGIN
      UPDATE detalle_factura
      SET    cantidad = cantidad - @cantidad
      WHERE  detalle_factura.Id_producto = @Id_producto
             AND detalle_factura.idFactura = @Id_factura
  END

  BEGIN
      DELETE FROM detalle_factura
      WHERE  detalle_factura.idFactura = @Id_factura
             AND cantidad <= 0
  END

  BEGIN
      IF EXISTS(SELECT cantidad
                FROM   detalle_factura
                WHERE  detalle_factura .idFactura = @Id_factura
                       AND detalle_factura.Codigo = '0')
        UPDATE detalle_factura
        SET    Codigo = 0
        WHERE  detalle_factura.Codigo = '0'
               AND detalle_factura.idFactura = @Id_factura
  END

GO
/****** Object:  StoredProcedure [dbo].[Editar_detalle_factura_sumar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_detalle_factura_sumar] @Id_producto       INT,
                                               @cantidad          AS NUMERIC(18, 2),
                                               @Id_factura          AS INT
AS
  BEGIN
      UPDATE detalle_factura
      SET    cantidad = cantidad + @cantidad
      WHERE  detalle_factura.Id_producto = @Id_producto
             AND detalle_factura.idFactura = @Id_factura
  END

  BEGIN
      IF EXISTS(SELECT cantidad
                FROM   detalle_factura
                WHERE  detalle_factura .idFactura = @Id_factura
                       AND detalle_factura.Codigo = '0')
        UPDATE detalle_factura
        SET    Codigo = 0
        WHERE  detalle_factura.Codigo = '0'
               AND detalle_factura.idFactura = @Id_factura
  END

GO
/****** Object:  StoredProcedure [dbo].[Editar_dinero_caja_inicial]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_dinero_caja_inicial] @Id_caja AS INTEGER,
                                               @saldo   NUMERIC(18, 2)
AS
    UPDATE MOVIMIENTOCAJACIERRE
    SET    Saldo_queda_en_caja = @saldo
    WHERE  Id_caja = @Id_caja
           AND Estado = 'CAJA APERTURADA'

GO
/****** Object:  StoredProcedure [dbo].[Editar_eleccion_impresoras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_eleccion_impresoras] @idcaja           INTEGER,
                                                    @Impresora_Ticket VARCHAR(max)
AS
    UPDATE Caja
    SET    Impresora_Ticket = @Impresora_Ticket
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Editar_formato_ticket]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_formato_ticket] @Identificador_fiscal           VARCHAR(max),
                                               @Direccion                      VARCHAR(max),
                                               @Provincia_Departamento_Pais    VARCHAR(max),
                                               @Nombre_de_Moneda               VARCHAR(max),
                                               @Agradecimiento                 VARCHAR(max),
                                               @pagina_Web_Facebook            VARCHAR(max),
                                               @Anuncio                        VARCHAR(max),
                                               @Datos_fiscales_de_autorizacion VARCHAR(max),
                                               @Por_defecto                    VARCHAR(max),
                                               @Nombre_Empresa                 VARCHAR(max),
                                               @Logo                           IMAGE
AS
  BEGIN
      UPDATE Ticket
      SET    Identificador_fiscal = @Identificador_fiscal,
             Direccion = @Direccion,
             Provincia_Departamento_Pais = @Provincia_Departamento_Pais,
             Nombre_de_Moneda = @Nombre_de_Moneda,
             Agradecimiento = @Agradecimiento,
             pagina_Web_Facebook = @pagina_Web_Facebook,
             Anuncio = @Anuncio,
             Datos_fiscales_de_autorizacion = @Datos_fiscales_de_autorizacion,
             Por_defecto = @Por_defecto
  END

BEGIN
    UPDATE EMPRESA
    SET    Nombre_Empresa = @Nombre_Empresa,
           Logo = @Logo
END

GO
/****** Object:  StoredProcedure [dbo].[Editar_gastos_varios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Editar_gastos_varios] @Id_gasto         AS INT,
                                         @Fecha            AS DATETIME,
                                         @Nro_documento    AS VARCHAR(MAX),
                                         @Tipo_comprobante AS VARCHAR(MAX),
                                         @Importe          AS NUMERIC(18, 2),
                                         @Descripcion      AS VARCHAR(MAX),
                                         @Id_caja          AS INT,
                                         @Id_concepto      AS INT
AS
    UPDATE Gastos_varios
    SET    Fecha = @Fecha,
           Nro_documento = @Nro_documento,
           Tipo_comprobante = @Tipo_comprobante,
           Importe = @Importe,
           Descripcion = @Descripcion,
           Id_caja = @Id_caja,
           Id_concepto = @Id_concepto
    WHERE  Id_gasto = @Id_gasto

GO
/****** Object:  StoredProcedure [dbo].[Editar_grupo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_grupo] @id    INT,
                                      @Grupo VARCHAR(50)
AS
    IF EXISTS (SELECT Linea
               FROM   Grupo_de_Productos
               WHERE  Linea = @Grupo
                      AND Idline <> @id)
      RAISERROR ('YA EXISTE UN GRUPO CON ESTE NOMBRE, Ingrese de nuevo',16,1)
    ELSE
      UPDATE Grupo_de_Productos
      SET    Linea = @grupo
      WHERE  Idline = @id

GO
/****** Object:  StoredProcedure [dbo].[Editar_inicio_de_sesion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_inicio_de_sesion] 
@Id_serial_Pc VARCHAR(max),
@id_usuario   INT
AS
    UPDATE Inicios_de_sesion_por_caja
    SET    Id_usuario = @id_usuario
    WHERE  Id_serial_Pc = @Id_serial_Pc
GO
/****** Object:  StoredProcedure [dbo].[Editar_marcan_a]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_marcan_a] @e  VARCHAR(max),
                                         @fa VARCHAR(max),
                                         @f  VARCHAR(max),
                                         @s  VARCHAR(max)
AS
    UPDATE Marcan
    SET    E = @e,
           FA = @fa,
           F = @f
    WHERE  S = @s

GO
/****** Object:  StoredProcedure [dbo].[Editar_producto1]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_producto1] @Id_Producto1         INT,
                                     @Descripcion          VARCHAR(50),
                                     @Imagen               VARCHAR(50),
                                     @Id_grupo             INT,
                                     @Usa_inventarios      VARCHAR(50),
                                     @Stock                VARCHAR(50),
                                     @Precio_de_compra     NUMERIC(18, 2),
                                     @Fecha_de_vencimiento VARCHAR(50),
                                     @Precio_de_factura      NUMERIC(18, 2),
                                     @Codigo               VARCHAR(50),
                                     @Se_vende_a           VARCHAR(50),
                                     @Impuesto             VARCHAR(50),
                                     @Stock_minimo         NUMERIC(18, 2),
                                     @Precio_mayoreo       NUMERIC(18, 2),
                                     @A_partir_de          NUMERIC(18, 2)
AS
    IF EXISTS (SELECT Descripcion
               FROM   Producto1
               WHERE  ( Descripcion = @Descripcion
                        AND Id_Producto1 <> @Id_Producto1 ))
      RAISERROR ('YA EXISTE UN PRODUCTO  CON ESTE NOMBRE, POR FAVOR INGRESE DE NUEVO',16,1)
    ELSE IF EXISTS (SELECT Codigo
               FROM   Producto1
               WHERE  ( Codigo = @Codigo
                        AND Id_Producto1 <> @Id_Producto1 ))
      RAISERROR ('YA EXISTE UN PRODUCTO  CON ESTE CODIGO, POR FAVOR INGRESE DE NUEVO/ SE GENERARA CODIGO AUTOMATICO',16,1)
    ELSE IF EXISTS (SELECT Descripcion,
                      Codigo
               FROM   Producto1
               WHERE  ( Id_Producto1 = @Id_Producto1 ))
      UPDATE Producto1
      SET    Descripcion = @Descripcion,
             Imagen = @Imagen,
             Id_grupo = @Id_grupo,
             Usa_inventarios = @Usa_inventarios,
             Stock = @Stock,
             Precio_de_compra = @Precio_de_compra,
             Fecha_de_vencimiento = @Fecha_de_vencimiento,
             Precio_de_factura = @Precio_de_factura,
             Codigo = @Codigo,
             Se_vende_a = @Se_vende_a,
             Impuesto = @Impuesto,
             Stock_minimo = @Stock_minimo,
             Precio_mayoreo = @Precio_mayoreo,
             A_partir_de = @A_partir_de
      WHERE  id_Producto1 = @Id_Producto1

GO
/****** Object:  StoredProcedure [dbo].[Editar_proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_proveedores] @IdProveedor         AS INT,
                                       @idPersona           AS INT,
                                       @IdentificadorFiscal AS VARCHAR(MAX)
AS
    IF EXISTS(SELECT idPersona
              FROM   Proveedores
              WHERE  idPersona = @idPersona
                     AND IdProveedor <> @IdProveedor)
      RAISERROR('Registro ya existente',16,1)
    ELSE
      UPDATE Proveedores
      SET    idPersona = @idPersona,
             IdentificadorFiscal = @IdentificadorFiscal
      WHERE  IdProveedor = @IdProveedor

GO
/****** Object:  StoredProcedure [dbo].[Editar_serializacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_serializacion] @serie               VARCHAR(50),
                                         @Cantidad_de_numeros AS VARCHAR(50),
                                         @numerofin           AS VARCHAR(50),
                                         @Tipo                AS VARCHAR(50),
                                         @Id_serie            AS INT
AS
    UPDATE Serializacion
    SET    Serie = @serie,
           Cantidad_de_numeros = @Cantidad_de_numeros,
           numerofin = @numerofin,
           tipodoc = @Tipo
    WHERE  Id_serializacion = @Id_serie

GO
/****** Object:  StoredProcedure [dbo].[Editar_serializacion_por_defecto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_serializacion_por_defecto] @Id_serie AS INT
AS
  BEGIN
      UPDATE Serializacion
      SET    Por_defecto = '-'
  END

BEGIN
    UPDATE Serializacion
    SET    Por_defecto = 'SI'
    WHERE  Id_serializacion = @Id_serie
END

GO
/****** Object:  StoredProcedure [dbo].[Editar_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_usuario] @idUsuario       INT,
                                   @idEmpleado      INT,
                                   @Login           VARCHAR(50),
                                   @Password        VARCHAR(50),
                                   @Icono           IMAGE,
                                   @Nombre_de_icono VARCHAR(max),
                                   @idRol             int
AS
    IF EXISTS (SELECT Login,
                      idUsuario
               FROM   USUARIO2
               WHERE  ( ( Login = @login
                           OR ( idEmpleado = @idEmpleado ) )
                        AND idUsuario <> @idUsuario
                        AND Estado = 'ACTIVO' ))
      RAISERROR('YA EXISTE UN USUARIO CON ESE LOGIN O CON ESE ICONO, POR FAVOR INGRESE DE NUEVO',16,1 )
    ELSE
      UPDATE USUARIO2
      SET    idEmpleado = @idEmpleado,
             Password = @Password,
             Icono = @Icono,
             Nombre_de_icono = @Nombre_de_icono,
             idRol = @idRol,
             Login = @Login
      WHERE  idUsuario = @idUsuario

GO
/****** Object:  StoredProcedure [dbo].[Editar_vehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editar_vehiculo] @idVehiculo     INT,
                                    @idTipoVehiculo AS INT,
                                    @NPlaca         VARCHAR(50),
                                    @Transmision    VARCHAR(50),
                                    @Color          VARCHAR(50),
                                    @Marca          VARCHAR(50),
                                    @Modelo         VARCHAR(50),
                                    @Ano            INT,
                                    @Icono          IMAGE
AS
    IF EXISTS(SELECT idVehiculo,
                     NPlaca
              FROM   Vehiculos
              WHERE  ( idVehiculo <> @idVehiculo
                       AND @NPlaca = NPlaca
                       AND Estado = 'ACTIVO' ))
      RAISERROR('YA EXISTE UN VEHICULO CON ESA PLACA, POR FAVOR INGRESE DE NUEVO',16,1)
    ELSE
      UPDATE dbo.Vehiculos
      SET    idTipoVehiculo = @idTipoVehiculo,
             NPlaca = @NPlaca,
             Transmision = @Transmision,
             Color = @Color,
             Marca = @Marca,
             Modelo = @Modelo,
             Ano = @Ano,
             Icono = @Icono
      WHERE  idVehiculo = @idVehiculo

GO
/****** Object:  StoredProcedure [dbo].[editarAlmacen]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editarAlmacen]
@idAlmacen as int,
@almacen as varchar(50),
@stockminimo as numeric(18,2),
@idlocalizacion as int,
@idDireccion as INT
AS
    update Almacen 
	set Descripcion = @almacen, stock_minimo = @stockminimo, idLocalizacion = @idlocalizacion ,idDireccion = @idDireccion
    where idAlmacen = @idAlmacen
GO
/****** Object:  StoredProcedure [dbo].[Editarbascula]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarbascula] @idcaja INT,
                                  @Puerto VARCHAR(max),
                                  @Estado VARCHAR(50)
AS
    UPDATE Caja
    SET    PuertoBalanza = @Puerto,
           EstadoBalanza = @Estado
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Editarcalle]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarcalle] @idCalle     AS INT,
                                @descripcion AS VARCHAR(50)
AS
    UPDATE Calle
    SET    descripcion = @descripcion
    WHERE  idCalle = @idCalle

GO
/****** Object:  StoredProcedure [dbo].[editarCategoria]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editarCategoria] 
@idCategoria as INT,
@descripcion AS VARCHAR(50),
@departamento AS VARCHAR(50),
@idImpuesto as int,
@idDescuento as int

AS
    update CategoriaProductos
    set     Descripcion = @descripcion, departamento = @departamento, idItbis = @idImpuesto, idDescuento = @idDescuento
	where idCategoria = @idCategoria
GO
/****** Object:  StoredProcedure [dbo].[editarCiudad]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editarCiudad] 
@idCiudad as int,
@ciudad as varchar(50)
as
	UPDATE Ciudad
	set ciudad = @ciudad
	where idCiudad = @idCiudad
GO
/****** Object:  StoredProcedure [dbo].[Editarcompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Editarcompra] @idCompra INT,
                                @monto     NUMERIC(18, 2)
AS
    IF @monto <> 0
      UPDATE compras
      SET    Monto_total = @monto
      WHERE  idCompra = @idCompra
    ELSE
      DELETE FROM compras
      WHERE  idCompra = @idCompra

GO
/****** Object:  StoredProcedure [dbo].[editarDatosFiscales]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarDatosFiscales] 
@idDatosFiscales as int,
@NombreFiscal  AS VARCHAR(50),
                                  @infoAdicional AS VARCHAR(50),
                                  @RegimenFiscal AS VARCHAR(50),
                                  @RNC           AS VARCHAR(50),
                                  @NoFiscal      AS VARCHAR(50),
                                  @CodPostal     AS VARCHAR(50),
                                  @Localidad     AS VARCHAR(50),
                                  @Domicilio     AS VARCHAR(50),
                                  @NoInt         AS VARCHAR(50),
                                  @NoExt         AS VARCHAR(50),
                                  @CDL           AS VARCHAR(50),
                                  @Provincia     AS VARCHAR(50),
                                  @Ciudad        AS VARCHAR(50)
AS
    UPDATE DatosFiscales
    SET NombreFiscal = @NombreFiscal,
                 infoAdicional = @infoAdicional,
                 RegimenFiscal = @RegimenFiscal,
                 RNC = @RNC,
                 NoFiscal = @NoFiscal,
                 CodPostal = @CodPostal,
                 Localidad=@Localidad,
                 Domicilio =@Domicilio,
                 NoInt = @NoInt,
                 NoExt = @NoExt,
                 CDL = @CDL,
                 Provincia = @Provincia,
                  Ciudad = @Ciudad 
				  where idDatosFiscales = @idDatosFiscales
GO
/****** Object:  StoredProcedure [dbo].[editarDescuento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarDescuento] @idDescuento AS INT,
                                   @Descuento AS numeric(18,2),@TipoDescuento as varchar(50)
AS
    UPDATE Descuentos
    SET    Descuento = @Descuento, TipoDescuento = @TipoDescuento
    WHERE  idDescuento = @idDescuento

GO
/****** Object:  StoredProcedure [dbo].[editarDescuentoCompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarDescuentoCompra]
@iddetallecompra INT,                          
@Descuento        NUMERIC(18, 2)
AS
    UPDATE detalle_compra
    SET    Descuento = @Descuento
    WHERE  iddetalle_compra = @iddetallecompra

GO
/****** Object:  StoredProcedure [dbo].[editarDescuentoFactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarDescuentoFactura]
@iddetallefactura INT,                          
@Descuento        NUMERIC(18, 2)
AS
    UPDATE detalle_factura
    SET    Descuento = @Descuento
    WHERE  iddetalle_factura = @iddetallefactura

GO
/****** Object:  StoredProcedure [dbo].[EditarDetalleproducto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[EditarDetalleproducto]
  --Empezamos a declara primero los parametros para Productos
  @idDetalleProducto as int,
  @idProducto as int,
  @idProveedor as int,
  @Localizacion as varchar(50),
  @StockMinimo as numeric(18,2),
  @Granel as varchar(50),
  @UsoInterno as varchar(50),
  @Peso as varchar(50),
  @FechaVencimiento as varchar(50)

AS
  --Ahora VALIDAMOS para que no se agregen productos con el mismo nombre y codigo de barras
        BEGIN
            Update  DetalleProducto 
            set       
		
						  idProveedor = @idProveedor ,
						  Localizacion = @Localizacion ,
						  StockMinimo = @StockMinimo,
						  UsoInterno = @UsoInterno ,
						  Granel= @Granel,
						  Peso = @Peso,
						  FechaVencimiento = @FechaVencimiento
						  where idDetalleProducto = @idDetalleProducto
  END
GO
/****** Object:  StoredProcedure [dbo].[Editardireccion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editardireccion] @idDireccion AS INT,
                                    @descripcion AS VARCHAR(50)
AS
    UPDATE Direccion
    SET    descripcion = @descripcion
    WHERE  idDireccion = @idDireccion

GO
/****** Object:  StoredProcedure [dbo].[Editardocumento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editardocumento] @idDocumento   AS INT,
                                    @TipoDocumento AS VARCHAR(50),
                                    @numeracion    AS VARCHAR(50)
AS
    UPDATE Documento
    SET    Tipo = @TipoDocumento,
           numeracion = @numeracion
    WHERE  idDocumento = @idDocumento

GO
/****** Object:  StoredProcedure [dbo].[Editarempleado]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarempleado] @idPersona    AS INT,
                                   @idHorario    AS INT,
                                   @cuentaBanco  VARCHAR(50),
                                   @departamento VARCHAR(max),
                                   @banco        VARCHAR(max),
                                   @icono        IMAGE,
                                   @estado       VARCHAR(50)
AS
    UPDATE Empleados
    SET    idPersona = @idPersona,
           idHorario = @idHorario,
           cuentaBanco = @cuentaBanco,
           departamento = @departamento,
           banco = @banco,
           icono = @icono,
           estado = @estado
    WHERE  idPersona = @idPersona

GO
/****** Object:  StoredProcedure [dbo].[editarEmpresa]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[editarEmpresa]
@idEmpresa AS INT,
@Nombre_Empresa AS VARCHAR(50),
@Logo AS IMAGE,
@Moneda AS VARCHAR(50),
@Modo_de_busqueda AS VARCHAR(50),
@Carpeta_para_copias_de_seguridad AS VARCHAR(max),
@idCorreo AS INT,
@idDireccion AS INT,
@idDatosFiscales AS INT,
@idTelefono AS INT,
@idCelular AS INT
AS
      UPDATE EMPRESA
      SET     
	Nombre_Empresa = @Nombre_Empresa,
	Logo = @Logo,
	Moneda =@Moneda ,
	Modo_de_busqueda =@Modo_de_busqueda,
	Carpeta_para_copias_de_seguridad = @Carpeta_para_copias_de_seguridad,
	idCorreo =@idCorreo,
	idDireccion = @idDireccion,
	idDatosFiscales =@idDatosFiscales,
	idTelefono = @idTelefono,
	idCelular = @idCelular
	where Id_empresa = @idEmpresa
GO
/****** Object:  StoredProcedure [dbo].[Editarfactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarfactura] @idFactura INT,
                                @monto     NUMERIC(18, 2)
AS
    IF @monto <> 0
      UPDATE facturas
      SET    Monto_total = @monto
      WHERE  idFactura = @idFactura
    ELSE
      DELETE FROM facturas
      WHERE  idFactura = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[Editarhorario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarhorario] @idHorario   AS INT,
                                  @HoraEntrada VARCHAR(50),
                                  @HoraSalida  VARCHAR(50),
                                  @TipoHorario AS INT
AS
    UPDATE Horario
    SET    Entrada = @HoraEntrada,
           Salida = @HoraSalida,
           TipoHorario = @TipoHorario
    WHERE  idHorario = @idHorario

GO
/****** Object:  StoredProcedure [dbo].[editarImpuesto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarImpuesto] @idImpuesto     AS INT,
                                   @nombre       AS VARCHAR(50),
                                   @impuesto AS numeric(18,2),
                                   @tipoImpuesto AS VARCHAR(50)
AS
    UPDATE Impuestos
    SET    nombre = @nombre,
           Impuesto = @impuesto,
		   Tipo = @tipoImpuesto
    WHERE  idImpuesto = @idImpuesto

GO
/****** Object:  StoredProcedure [dbo].[editarItbisFactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editarItbisFactura]
@iddetallefactura INT,                          
@Itbis        NUMERIC(18, 2)
AS
    UPDATE detalle_compra
    SET    itbis_calculo = @Itbis
    WHERE  iddetalle_compra = @iddetallefactura

GO
/****** Object:  StoredProcedure [dbo].[editarListaPrecio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[editarListaPrecio]
@idPrecios as int,
@idMayoreo          as int,
@Precio_1 as numeric(18,2),
@Precio_2 as numeric(18,2),
@Precio_3 as numeric(18,2),
@Precio_4 as numeric(18,2)
AS
      Update ListaPrecios
      set     idMayoreo = @idMayoreo,
                  Precio_1 = @Precio_1,
                  Precio_2 = @Precio_2,
                  Precio_3 = @Precio_3,
                  Precio_4= @Precio_4
				  where idPrecios = @idPrecios
GO
/****** Object:  StoredProcedure [dbo].[editarLocalizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[editarLocalizacion] 
@idLocalizacion as int,
@localizacion as varchar(50),
@Anaquel as varchar(50),
@Zona as varchar(50)
AS
    update Localizacion 
    set Zona = @Zona, NoAnaquel = @Anaquel,localizacion = @localizacion
	where idLocalizacion = @idLocalizacion
GO
/****** Object:  StoredProcedure [dbo].[editarMayoreo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarMayoreo]
@idMayoreo as int,
@Unidades_1 as numeric(18,2),
@Unidades_2 as numeric(18,2),
@Unidades_3 as numeric(18,2),
@Unidades_4 as numeric(18,2)
AS
      update VentasMayoreo
      set
                Unidades_1 = @Unidades_1,
                  Unidades_2 = @Unidades_2,
                  Unidades_3= @Unidades_3,
                  Unidades_4 = @Unidades_4
				  where idMayoreo = @idMayoreo
GO
/****** Object:  StoredProcedure [dbo].[Editarmunicipio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarmunicipio] @idMunicipio AS INT,
                                    @descripcion AS VARCHAR(50)
AS
    UPDATE Municipio
    SET    descripcion = @descripcion
    WHERE  idMunicipio = @idMunicipio

GO
/****** Object:  StoredProcedure [dbo].[Editarpersona]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarpersona] @idPersona       AS INT,
                                  @nombre          AS VARCHAR(50),
                                  @apellido        AS VARCHAR(50),
                                  @fechaNacimiento AS DATETIME,
                                  @idDireccion     AS INT,
                                  @idDocumento     AS INT,
                                  @idTelefono      AS INT,
								  @idCorreo  as int
AS
    UPDATE Persona
    SET    nombre = @nombre,
           apellido = @apellido,
           idCorreo = @idCorreo,
           fechaNacimiento = @fechaNacimiento,
           idDireccion = @idDireccion,
           idDocumento = @idDocumento,
           idTelefono = @idTelefono
    WHERE  idPersona = @idPersona

GO
/****** Object:  StoredProcedure [dbo].[Editarpreciocompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Editarpreciocompra] @iddetallecompra INT,
                                      @precio         NUMERIC(18, 2)
AS
    UPDATE detalle_compra
    SET    preciounitario = @precio
    WHERE  iddetalle_compra= @iddetallecompra

GO
/****** Object:  StoredProcedure [dbo].[Editarpreciofactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarpreciofactura] @iddetallefactura INT,
                                      @precio         NUMERIC(18, 2)
AS
    UPDATE detalle_factura
    SET    preciounitario = @precio
    WHERE  iddetalle_factura = @iddetallefactura

GO
/****** Object:  StoredProcedure [dbo].[Editarpreciosproductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarpreciosproductos] @idproducto       INT,
                                           @preciofactura      NUMERIC(18, 2),
                                           @costo            NUMERIC(18, 2),
                                           @preciomayoreo    NUMERIC(18, 2),
                                           @cantidadAgregada NUMERIC(18, 2)
AS
    UPDATE Producto1
    SET    Precio_de_factura = @preciofactura,
           Precio_de_compra = @costo,
           Precio_mayoreo = @preciomayoreo,
           Stock = Stock + @cantidadAgregada
    WHERE  Id_Producto1 = @idproducto
           AND Usa_inventarios = 'SI'

GO
/****** Object:  StoredProcedure [dbo].[Editarpreciosproductoscompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Editarpreciosproductoscompra] @idproducto       INT,
                                           @precioventa      NUMERIC(18, 2),
                                           @costo            NUMERIC(18, 2)
AS
    UPDATE Producto1
    SET    Precio_de_factura = @precioventa,
           Precio_de_compra = @costo
    WHERE  Id_Producto1 = @idproducto
           AND Usa_inventarios = 'SI'

GO
/****** Object:  StoredProcedure [dbo].[Editarproducto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarproducto]
  --Empezamos a declara primero los parametros para Productos
  @idProducto     AS INT,
  @idCategoria    AS INT,
  @Codigo         AS VARCHAR(50),
  @Descripcion    AS VARCHAR(50),
  @Stock          AS NUMERIC(18, 2),
  @PrecioCompra   AS NUMERIC (18, 2),
  @idPrecios      INT,
  @idImpuesto     AS INT,
  @idDescuento    AS INT,

  --Parametros de unidadcompra y unidadventa
  @idUnidadVenta  AS INT,
  @idUnidadCompra AS INT
AS
  --Ahora VALIDAMOS para que no se agregen productos con el mismo nombre y codigo de barras

      
        BEGIN
            UPDATE Producto
            SET    idCategoria = @idCategoria,
                   idPrecios = @idPrecios,
                   Codigo = @Codigo,
                   Descripcion = @Descripcion,
                   Stock = @Stock,
                   PrecioCompra = @PrecioCompra,
                   idImpuesto = @idImpuesto,
                   idDescuento = @idDescuento
            WHERE  idProducto = @idProducto

			update UnidadesVSProducto
			set idUnidadCompra = @idUnidadCompra,
			idUnidadVenta = @idUnidadVenta
			where idProducto = @idProducto
        --Ahora Obtenemos el Id del producto que se acaba de ingresar
        END

GO
/****** Object:  StoredProcedure [dbo].[Editarprovincia]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarprovincia] @idProvincia AS INT,
                                    @descripcion AS VARCHAR(50)
AS
    UPDATE Provincia
    SET    descripcion = @descripcion
    WHERE  idProvincia = @idProvincia

GO
/****** Object:  StoredProcedure [dbo].[Editarregion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarregion] @idRegion    AS INT,
                                 @descripcion AS VARCHAR(50)
AS
    UPDATE Region
    SET    descripcion = @descripcion
    WHERE  idRegion = @idRegion

GO
/****** Object:  StoredProcedure [dbo].[Editarrespaldos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarrespaldos] @Ultima_fecha_de_copia_de_seguridad VARCHAR(50),
                                    @Carpeta_para_copias_de_seguridad   VARCHAR (max),
                                    @Ultima_fecha_de_copia_date         DATETIME,
                                    @Frecuencia_de_copias               INT
AS
    UPDATE EMPRESA
    SET    Ultima_fecha_de_copia_de_seguridad = @Ultima_fecha_de_copia_de_seguridad,
           Carpeta_para_copias_de_seguridad = @Carpeta_para_copias_de_seguridad,
           Ultima_fecha_de_copia_date = @Ultima_fecha_de_copia_date,
           Frecuencia_de_copias = @Frecuencia_de_copias

GO
/****** Object:  StoredProcedure [dbo].[Editarsector]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editarsector] @idSector    AS INT,
                                 @descripcion AS VARCHAR(50)
AS
    UPDATE Sector
    SET    descripcion = @descripcion
    WHERE  idSector = @idSector

GO
/****** Object:  StoredProcedure [dbo].[Editartelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editartelefono] @idTelefono     AS INT,
                                   @Telefono       AS VARCHAR(50),
                                   @idTipoTelefono AS INT
AS
    UPDATE Telefono
    SET    numero = @Telefono,
           idTipoTelefono = @idTipoTelefono
    WHERE  idTelefono = @idTelefono

GO
/****** Object:  StoredProcedure [dbo].[Editartelefono_]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Editartelefono_] @idTelefono     AS INT,
                                   @Telefono       AS VARCHAR(50)
AS
    UPDATE Telefono
    SET    numero = @Telefono
    WHERE  idTelefono = @idTelefono
GO
/****** Object:  StoredProcedure [dbo].[Editartemacaja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editartemacaja] @idcaja INT,
                                   @tema   VARCHAR(50)
AS
    UPDATE Caja
    SET    Tema = @tema
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Editartipohorario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editartipohorario] @idTipoHorario AS INT,
                                      @TipoHorario   AS VARCHAR(50)
AS
    UPDATE TipoHorario
    SET    Descripcion = @TipoHorario
    WHERE  idTipoHorario = @idTipoHorario

GO
/****** Object:  StoredProcedure [dbo].[Editartipotelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editartipotelefono] @idTipoTelefono AS INT,
                                       @TipoTelefono   AS VARCHAR(50)
AS
    UPDATE TipoTelefono
    SET    descripcion = @TipoTelefono
    WHERE  idTipoTelefono = @idTipoTelefono

GO
/****** Object:  StoredProcedure [dbo].[Editartipovehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Editartipovehiculo] @idTipoVehiculo AS INT,
                                       @TipoVehiculo   AS VARCHAR(50),
                                       @capacidad      AS VARCHAR(50)
AS
    UPDATE TipoVehiculo
    SET    descripcion = @TipoVehiculo
    WHERE  idTipoVehiculo = @idTipoVehiculo

GO
/****** Object:  StoredProcedure [dbo].[editarUnidades]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[editarUnidades] @idUnidad     AS INT,
                                   @idClaveSat       AS INT,
                                   @Unidad AS VARCHAR(50)
AS
    UPDATE UnidadesProductos
    SET    Descripcion = @Unidad,
	idClaveSat = @idClaveSat
    WHERE  idUnidad = @idUnidad

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_caja] @idcaja INTEGER
AS
    UPDATE Caja
    SET    Estado = 'Caja Eliminada'
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_clientes] @Idcliente AS INT
AS
    UPDATE clientes
    SET    Estado = 'ELIMINADO'
    WHERE  idclientev = @Idcliente

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Eliminar_compra] @idCompra AS INT
AS
    DELETE FROM compras
    WHERE  idCompra = @idCompra
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_cotizacion] @idcotizacion AS INTEGER
AS
    DELETE FROM detalle_cotizacion
    WHERE  idcotizacion = @idcotizacion

    DELETE FROM Cotizacion
    WHERE  idcotizacion = @idcotizacion

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_creditoporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Eliminar_creditoporpagar] @Id_credito AS INT
AS
    DELETE FROM CreditoPorPagar
    WHERE  Id_credito = @Id_credito

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_detalle_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Eliminar_detalle_compra] @iddetallecompra AS INT

AS
    DELETE detalle_compra
    WHERE  iddetalle_compra = @iddetallecompra
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_detalle_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_detalle_cotizacion] @iddetallecotizacion AS INT
AS
    DELETE detalle_cotizacion
    WHERE  iddetalle_cotizacion = @iddetallecotizacion

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_detalle_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_detalle_factura] @iddetallefactura AS INT
AS
    DELETE detalle_factura
    WHERE  iddetalle_factura = @iddetallefactura

	DELETE Aux_Productos
	where idDetalleProducto = @iddetallefactura
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_empleados]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_empleados] @idEmpleado AS INT
AS
   DELETE FROM Empleados
    WHERE  idEmpleado = @idEmpleado

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_factura] @idFactura AS INTEGER
AS
    DELETE FROM facturas
    WHERE  idFactura = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_gasto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_gasto] @idgasto INTEGER
AS
    DELETE FROM Gastos_varios
    WHERE  Id_gasto = @idgasto

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_ingreso]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_ingreso] @idingreso INTEGER
AS
    DELETE FROM Ingresos_varios
    WHERE  Id_ingreso = @idingreso

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_producto1]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_producto1] @id INT
AS
    DELETE FROM Producto1
    WHERE  Id_Producto1 = @id

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_proveedores] @IdProveedor AS INT
AS
    UPDATE Proveedores
    SET    Estado = 'ELIMINADO'
    WHERE  IdProveedor = @IdProveedor

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_serializacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_serializacion] @id INTEGER
AS
    IF EXISTS (SELECT Destino
               FROM   Serializacion
               WHERE  Destino <> 'OTROS'
                      AND ID_SERIALIZACION = @id)
      RAISERROR ('Este Comprobante no se Eliminara ya que generaria Error',16,1)
    ELSE
      DELETE FROM Serializacion
      WHERE  Id_serializacion = @id
             AND Destino = 'OTROS'

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_usuario] @idusuario INT,
                                     @login     VARCHAR(50)
AS
    IF EXISTS(SELECT login
              FROM   USUARIO2
              WHERE  @login = 'admin')
      RAISERROR('El Usuario *Admin* es Inborrable, si se borraria Eliminarias el Acceso al Sistema de porvida, Accion Denegada',16,1)
    ELSE
      UPDATE USUARIO2
      SET    Estado = 'ELIMINADO'
      WHERE  idUsuario = @idusuario
             AND Login <> 'admin'

GO
/****** Object:  StoredProcedure [dbo].[Eliminar_vehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminar_vehiculo] @idVehiculo AS INT
AS
    UPDATE Vehiculos
    SET    Estado = 'ELIMINADO'
    WHERE  idVehiculo = @idVehiculo

GO
/****** Object:  StoredProcedure [dbo].[eliminarCategoria]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[eliminarCategoria] @idCategoria AS INT
AS
	delete from CategoriaProductos
    WHERE  idCategoria = @idCategoria
GO
/****** Object:  StoredProcedure [dbo].[eliminarCategorias]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[eliminarCategorias]
@id AS INT
AS
    DELETE FROM CategoriaProductos
    WHERE  idCategoria = @id
GO
/****** Object:  StoredProcedure [dbo].[Eliminarcontrolcobro]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminarcontrolcobro] @idcontrol INT
AS
    DELETE FROM ControlCobros
    WHERE  IdcontrolCobro = @idcontrol

GO
/****** Object:  StoredProcedure [dbo].[Eliminarcontrolpago]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Eliminarcontrolpago] @idcontrol INT
AS
    DELETE FROM ControlPago
    WHERE  idControlPago = @idcontrol

GO
/****** Object:  StoredProcedure [dbo].[eliminarDescuento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[eliminarDescuento] @idDescuento AS INT
AS
	delete from Descuentos
    WHERE  idDescuento = @idDescuento
GO
/****** Object:  StoredProcedure [dbo].[Eliminarfactexterna]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Eliminarfactexterna] @idcontrol INT
AS
    DELETE FROM FacturasExternas
    WHERE  idControlPago = @idcontrol
GO
/****** Object:  StoredProcedure [dbo].[eliminarImpuesto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[eliminarImpuesto] @idImpuesto AS INT
AS
    UPDATE Impuestos
	 SET    Estado = 'ELIMINADO'
    WHERE  idImpuesto = @idImpuesto
GO
/****** Object:  StoredProcedure [dbo].[Eliminartipotelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Eliminartipotelefono] @id AS INT
AS
    DELETE FROM TipoTelefono
    WHERE  idTipoTelefono = @id

GO
/****** Object:  StoredProcedure [dbo].[Eliminartipovehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Eliminartipovehiculo] @id AS INT
AS
    DELETE FROM TipoVehiculo
    WHERE  idTipoVehiculo = @id

GO
/****** Object:  StoredProcedure [dbo].[eliminarUnidad]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[eliminarUnidad] @idUnidad AS INT
AS
	delete from UnidadesProductos
    WHERE  idUnidad = @idUnidad
GO
/****** Object:  StoredProcedure [dbo].[Imprimir_inventarios_todos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Imprimir_inventarios_todos]
AS
    SELECT p.Codigo,
           p.Descripcion,
           p.PrecioCompra         AS Costo,
		   lp.Precio_1 AS [Precio_Venta],
           p.Stock,
           d.StockMinimo             AS [Stock_Minimo],
           cp.Descripcion  Categoria,
           p.PrecioCompra * Stock AS Importe,
           EMPRESA.Nombre_Empresa,
           EMPRESA.Logo
    FROM   dbo.Producto as p
	inner join dbo.DetalleProducto as d
	on p.idProducto = d.idProducto
	inner join dbo.ListaPrecios as lp
	on p.idPrecios = lp.idPrecios
	inner join CategoriaProductos as CP
	on p.idCategoria = cp.idCategoria
           CROSS JOIN EMPRESA

GO
/****** Object:  StoredProcedure [dbo].[Ingresar_nombre_a_compra_en_espera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Ingresar_nombre_a_compra_en_espera] @idFactura INT,
                                                      @nombre    VARCHAR(50)
AS
    UPDATE compras
    SET    Comprobante = @nombre,
           Estado = 'EN ESPERA'
    WHERE  idCompra = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[Ingresar_nombre_a_factura_en_espera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Ingresar_nombre_a_factura_en_espera] @idFactura INT,
                                                      @nombre    VARCHAR(50)
AS
    UPDATE facturas
    SET    Comprobante = @nombre,
           Estado = 'EN ESPERA'
    WHERE  idFactura = @idFactura

GO
/****** Object:  StoredProcedure [dbo].[Ingresardatosfiscales]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Ingresardatosfiscales] @NombreFiscal  AS VARCHAR(50),
                                  @infoAdicional AS VARCHAR(50),
                                  @RegimenFiscal AS VARCHAR(50),
                                  @RNC           AS VARCHAR(50),
                                  @NoFiscal      AS VARCHAR(50),
                                  @CodPostal     AS VARCHAR(50),
                                  @Localidad     AS VARCHAR(50),
                                  @Domicilio     AS VARCHAR(50),
                                  @NoInt         AS VARCHAR(50),
                                  @NoExt         AS VARCHAR(50),
                                  @CDL           AS VARCHAR(50),
                                  @Provincia     AS VARCHAR(50),
                                  @Ciudad        AS VARCHAR(50)
AS
    INSERT INTO DatosFiscales
    VALUES     ( @NombreFiscal,
                 @infoAdicional,
                 @RegimenFiscal,
                 @RNC,
                 @NoFiscal,
                 @CodPostal,
                 @Localidad,
                 @Domicilio,
                 @NoInt,
                 @NoExt,
                 @CDL,
                 @Provincia,
                 @Ciudad ) 
GO
/****** Object:  StoredProcedure [dbo].[Insertar_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insertar_caja] @descripcion      VARCHAR(50),
                                       @Tema             VARCHAR(50),
                                       @Serial_PC        VARCHAR(max),
                                       @Impresora_Ticket VARCHAR(max),
                                       @Impresora_A4     VARCHAR(max),
                                       @Tipo             VARCHAR(50)
AS
    DECLARE @PuertoBalanza VARCHAR(max)
    DECLARE @EstadoBalanza VARCHAR(50)

    SET @PuertoBalanza='-'
    SET @EstadoBalanza = 'PENDIENTE'

    IF EXISTS (SELECT Descripcion,
                      Serial_PC
               FROM   Caja
               WHERE  Descripcion = @descripcion
                      AND Serial_PC = @Serial_PC)
      RAISERROR ('Ya Existe una Caja con ese Nombre',16,1)
    ELSE
      DECLARE @Estado AS VARCHAR(50)

    SET @Estado ='RECIEN CREADA'

    INSERT INTO Caja
    VALUES      (@descripcion,
                 @Tema,
                 @Serial_PC,
                 @Impresora_Ticket,
                 @Impresora_A4,
                 @Estado,
                 @Tipo,
                 @PuertoBalanza,
                 @EstadoBalanza )

GO
/****** Object:  StoredProcedure [dbo].[Insertar_calle]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_calle] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Calle
    VALUES     (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_clientes] @idPersona           AS INT,
                                      @IdentificadorFiscal AS VARCHAR(MAX),
                                      @Estado              AS VARCHAR(50),
                                      @Saldo               AS NUMERIC(18, 2)
AS
    IF EXISTS(SELECT idPersona
              FROM   clientes
              WHERE  idPersona = @idPersona)
      RAISERROR('Registro ya existente',16,1)
    ELSE
      INSERT INTO clientes
      VALUES      ( @idPersona,
                    @IdentificadorFiscal,
                    @Estado,
                    @Saldo)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_compras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_compras] @idProveedor          AS INTEGER,
                                   @fecha_compra       AS DATETIME,
                                   @nume_documento     AS VARCHAR(50),
                                   @montototal         AS NUMERIC(18, 2),
                                   @Tipo_de_pago       AS VARCHAR(50),
                                   @estado             AS VARCHAR(50),
                                   @Comprobante        AS VARCHAR(50),
                                   @id_usuario         AS INT,
                                   @Fecha_de_pago      AS VARCHAR(50),
                                   @ACCION             VARCHAR(50),
                                   @Saldo              NUMERIC(18, 2),
                                   @Id_caja            INT,
								   @Transferencia_Bancaria AS VARCHAR(50)
AS
    DECLARE @vuelto NUMERIC(18, 2)
    DECLARE @TotalPagado NUMERIC(18, 2)
    DECLARE @id_numero VARCHAR(50)
    SET @vuelto =0
    SET @id_numero= (SELECT Max(idFactura) + 1
                     FROM   facturas)
    INSERT INTO compras
    VALUES      (@idProveedor,
                 @fecha_compra,
                 @nume_documento,
                 @montototal,
                 @Tipo_de_pago,
                 @estado,
                 @Comprobante + ' ' + @id_numero,
                 @id_usuario,
                 @Fecha_de_pago,
                 @ACCION,
                 @Saldo,
                 @Id_caja,
                 @vuelto,
				 @TotalPagado,
				 @Transferencia_Bancaria)
GO
/****** Object:  StoredProcedure [dbo].[Insertar_conceptos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_conceptos] @Descripcion AS VARCHAR(MAX)
AS
    IF EXISTS(SELECT Descripcion
              FROM   Conceptos
              WHERE  Descripcion = @Descripcion)
      RAISERROR('Concepto ya registrado',16,1 )
    ELSE
      INSERT INTO Conceptos
      VALUES      ( @Descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_controlcobros]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Insertar_controlcobros] @Monto       AS NUMERIC(18, 2),
                                           @Fecha       AS DATETIME,
                                           @Detalle     AS VARCHAR(MAX),
                                           @IdCliente   AS INT,
                                           @IdUsuario   AS INT,
                                           @IdCaja      AS INT,
                                           @Comprobante AS VARCHAR(MAX),
                                           @efectivo    NUMERIC(18, 2),
                                           @tarjeta     NUMERIC(18, 2)
AS
    INSERT INTO ControlCobros
    VALUES      ( @Monto,
                  @Fecha,
                  @Detalle,
                  @IdCliente,
                  @IdUsuario,
                  @IdCaja,
                  @Comprobante,
                  @efectivo,
                  @tarjeta)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_cotizacion] @idcliente          AS INTEGER,
                                        @fecha_factura        AS DATETIME,
                                        @nume_documento     AS VARCHAR(50),
                                        @montototal         AS NUMERIC(18, 2),
                                        @Tipo_de_pago       AS VARCHAR(50),
                                        @estado             AS VARCHAR(50),
                                        @IGV                AS NUMERIC(18, 1),
                                        @Comprobante        AS VARCHAR(50),
                                        @id_usuario         AS INT,
                                        @Fecha_de_pago      AS VARCHAR(50),
                                        @ACCION             VARCHAR(50),
                                        @Saldo              NUMERIC(18, 2),
                                        @Pago_con           NUMERIC(18, 2),
                                        @Porcentaje_IGV     NUMERIC(18, 2),
                                        @Id_caja            INT,
                                        @Referencia_tarjeta VARCHAR(50)
AS
    DECLARE @vuelto NUMERIC(18, 2)
    DECLARE @Efectivo NUMERIC(18, 2)
    DECLARE @id_numero VARCHAR(50)
    DECLARE @Credito NUMERIC(18, 2)
    DECLARE @Tarjeta NUMERIC(18, 2)

    SET @vuelto =0
    SET @Efectivo =0
    SET @id_numero= (SELECT Max(idcotizacion) + 1
                     FROM   Cotizacion)
    SET @Credito =0
    SET @Tarjeta =0

    INSERT INTO Cotizacion
    VALUES      (@idcliente,
                 @fecha_factura,
                 @nume_documento,
                 @montototal,
                 @Tipo_de_pago,
                 @estado,
                 @IGV,
                 @Comprobante + ' ' + @id_numero,
                 @id_usuario,
                 @Fecha_de_pago,
                 @ACCION,
                 @Saldo,
                 @Pago_con,
                 @Porcentaje_IGV,
                 @Id_caja,
                 @Referencia_tarjeta,
                 @vuelto,
                 @Efectivo,
                 @Credito,
                 @Tarjeta )

GO
/****** Object:  StoredProcedure [dbo].[Insertar_creditoporcobrar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_creditoporcobrar] @Descripcion       AS VARCHAR(MAX),
                                              @Fecha_registro    AS DATETIME,
                                              @Fecha_vencimiento AS DATE,
                                              @Total             AS NUMERIC(18, 2),
                                              @Saldo             AS NUMERIC(18, 2),
                                              @Estado            AS VARCHAR(MAX),
                                              @Id_caja           AS INT,
                                              @Id_cliente        AS INT
AS
    INSERT INTO CreditoPorCobrar
    VALUES      ( @Descripcion,
                  @Fecha_registro,
                  @Fecha_vencimiento,
                  @Total,
                  @Saldo,
                  @Estado,
                  @Id_caja,
                  @Id_cliente)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_creditoporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Insertar_creditoporpagar] @Descripcion       AS VARCHAR(MAX),
                                             @Fecha_registro    AS DATETIME,
                                             @Fecha_vencimiento AS DATE,
                                             @Total             AS NUMERIC(18, 2),
                                             @Saldo             AS NUMERIC(18, 2),
                                             @Estado            AS VARCHAR(MAX),
                                             @Id_caja           AS INT,
                                             @Id_Proveedor      AS INT
AS
    INSERT INTO CreditoPorPagar
    VALUES      ( @Descripcion,
                  @Fecha_registro,
                  @Fecha_vencimiento,
                  @Total,
                  @Saldo,
                  @Estado,
                  @Id_caja,
                  @Id_Proveedor)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_detalle_cierre_de_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_detalle_cierre_de_caja] @fechaini       DATETIME,
                                                    @fechafin       DATETIME,
                                                    @fechacierre    DATETIME,
                                                    @ingresos       NUMERIC(18, 2),
                                                    @egresos        NUMERIC(18, 2),
                                                    @saldo          NUMERIC(18, 2),
                                                    @idusuario      INT,
                                                    @totalcaluclado NUMERIC(18, 2),
                                                    @totalreal      NUMERIC(18, 2),
                                                    @estado         AS VARCHAR(50),
                                                    @diferencia     AS NUMERIC(18, 2),
                                                    @id_caja        AS INT
AS
  BEGIN
      IF EXISTS (SELECT Estado
                 FROM   MOVIMIENTOCAJACIERRE
                 WHERE  MOVIMIENTOCAJACIERRE.Estado = 'CAJA APERTURADA'
                        AND Id_caja = @id_caja)
        RAISERROR ('Ya Fue Iniciado el Turno de esta Caja',16,1)
      ELSE
        BEGIN
            INSERT INTO MOVIMIENTOCAJACIERRE
            VALUES      (@fechaini,
                         @fechafin,
                         @fechacierre,
                         @ingresos,
                         @egresos,
                         @saldo,
                         @idusuario,
                         @totalcaluclado,
                         @totalreal,
                         @estado,
                         @diferencia,
                         @id_caja )
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Insertar_detalle_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Insertar_detalle_compra] @idCompra                  AS INTEGER,
                                           @Id_presentacionfraccionada AS INT,
                                           @cantidad                   AS NUMERIC(18, 2),
                                           @preciounitario             AS NUMERIC(18, 2),
                                           @moneda                     AS VARCHAR(50),
										   @Descuento					AS Varchar(50),
                                           @unidades                   AS VARCHAR(50),
                                           @Estado                     AS VARCHAR(50),
                                           @Descripcion                VARCHAR(50),
                                           @Codigo                     VARCHAR(50),
                                           @Stock                      VARCHAR(50),
                                           @Se_vende_a                 VARCHAR(50),
                                           @Costo                      NUMERIC(18, 2),
										   @itbis_calculado					   DECIMAL(18, 2)
AS
  BEGIN
   
      IF EXISTS (SELECT Id_producto,
                        idCompra
                 FROM   detalle_compra
                        INNER JOIN Producto
                                ON Producto.idProducto = detalle_compra.Id_producto
                 WHERE   Producto.idProducto = @Id_presentacionfraccionada
                        AND idCompra = @idCompra)
        UPDATE detalle_compra
        SET    cantidad = cantidad + @cantidad
        WHERE  Id_producto = @Id_presentacionfraccionada
      ELSE
        BEGIN
            INSERT INTO detalle_compra
            VALUES      (@idCompra,
                         @Id_presentacionfraccionada,
                         @cantidad,
                         @preciounitario,
                         @moneda,
						 @Descuento,
                         @unidades,
                         @Estado,
                         @Descripcion,
                         @Codigo,
                         @Stock,
                         @Se_vende_a,
                         @Costo,
						 @itbis_calculado)
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Insertar_detalle_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_detalle_cotizacion] @idcotizacion               AS INTEGER,
                                                @Id_presentacionfraccionada AS INT,
                                                @cantidad                   AS NUMERIC(18, 2),
                                                @preciounitario             AS NUMERIC(18, 2),
                                                @moneda                     AS VARCHAR(50),
                                                @unidades                   AS VARCHAR(50),
                                                @Cantidad_mostrada          AS NUMERIC(18, 2),
                                                @Estado                     AS VARCHAR(50),
                                                @Descripcion                VARCHAR(50),
                                                @Codigo                     VARCHAR(50),
                                                @Stock                      VARCHAR(50),
                                                @Se_vende_a                 VARCHAR(50),
                                                @Usa_inventarios            VARCHAR(50),
                                                @Costo                      NUMERIC(18, 2)
AS
  BEGIN
      IF EXISTS (SELECT Id_producto,
                        idcotizacion
                 FROM   detalle_cotizacion
                        INNER JOIN Producto1
                                ON Producto1.Id_Producto1 = detalle_cotizacion.Id_producto
                 WHERE  Producto1. Id_Producto1 = @Id_presentacionfraccionada
                        AND idcotizacion = @idcotizacion)
        UPDATE detalle_cotizacion
        SET    cantidad = cantidad + @cantidad,
               Cantidad_mostrada = Cantidad_mostrada + @Cantidad_mostrada
        WHERE  Id_producto = @Id_presentacionfraccionada
      ELSE
        BEGIN
            INSERT INTO detalle_cotizacion
            VALUES      (@idcotizacion,
                         @Id_presentacionfraccionada,
                         @cantidad,
                         @preciounitario,
                         @moneda,
                         @unidades,
                         @Cantidad_mostrada,
                         @Estado,
                         @Descripcion,
                         @Codigo,
                         @Stock,
                         @Se_vende_a,
                         @Usa_inventarios,
                         @Costo)
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Insertar_detalle_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Insertar_detalle_factura] @idFactura                  AS INTEGER,
                                           @Id_presentacionfraccionada AS INT,
                                           @cantidad                   AS NUMERIC(18, 2),
                                           @preciounitario             AS NUMERIC(18, 2),
                                           @moneda                     AS VARCHAR(50),
										   @Descuento				   AS Numeric(18,2),
                                           @unidades                   AS VARCHAR(50),
                                           @Estado                     AS VARCHAR(50),
                                           @Descripcion                VARCHAR(50),
                                           @Codigo                     VARCHAR(50),
                                           @Stock                      VARCHAR(50),
                                           @Se_vende_a                 VARCHAR(50),
                                           @Costo                      NUMERIC(18, 2),
										   @itbis_calculado			 DECIMAL(18, 2)
AS
  BEGIN
						Set @cantidad = @cantidad / 2
      IF EXISTS (SELECT Id_producto,
                        idFactura
                 FROM   detalle_factura
                        INNER JOIN Producto
                                ON Producto.idProducto = detalle_factura.Id_producto
                 WHERE  Producto.idProducto = @Id_presentacionfraccionada
                        AND idFactura = @idFactura)

        UPDATE detalle_factura
        SET    cantidad = cantidad + @cantidad
        WHERE  Id_producto = @Id_presentacionfraccionada
      ELSE
        BEGIN
            INSERT INTO detalle_factura
            VALUES      (@idFactura,
                         @Id_presentacionfraccionada,
                         @cantidad,
                         @preciounitario,
                         @moneda,
						 @Descuento,
                         @unidades,
                         @Estado,
                         @Descripcion,
                         @Codigo,
                         @Stock,
                         @Se_vende_a,
                         @Costo,
						 @itbis_calculado)
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Insertar_detalle_factura2]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Insertar_detalle_factura2] @idFactura                  AS INTEGER,
                                           @Id_presentacionfraccionada AS INT,
                                           @cantidad                   AS NUMERIC(18, 2),
                                           @preciounitario             AS NUMERIC(18, 2),
                                           @moneda                     AS VARCHAR(50),
										   @Descuento				   AS Numeric(18,2),
                                           @unidades                   AS VARCHAR(50),
                                           @Estado                     AS VARCHAR(50),
                                           @Descripcion                VARCHAR(50),
                                           @Codigo                     VARCHAR(50),
                                           @Stock                      VARCHAR(50),
                                           @Se_vende_a                 VARCHAR(50),
                                           @Costo                      NUMERIC(18, 2),
										   @itbis_calculado			 DECIMAL(18, 2)
AS
  BEGIN
      IF EXISTS (SELECT Id_producto,
                        idFactura
                 FROM   detalle_factura
                        INNER JOIN Producto
                                ON Producto.idProducto = detalle_factura.Id_producto
                 WHERE  Producto.idProducto = @Id_presentacionfraccionada
                        AND idFactura = @idFactura)

        UPDATE detalle_factura
        SET    cantidad = cantidad + @cantidad
        WHERE  Id_producto = @Id_presentacionfraccionada
      ELSE
        BEGIN
            INSERT INTO detalle_factura
            VALUES      (@idFactura,
                         @Id_presentacionfraccionada,
                         @cantidad,
                         @preciounitario,
                         @moneda,
						 @Descuento,
                         @unidades,
                         @Estado,
                         @Descripcion,
                         @Codigo,
                         @Stock,
                         @Se_vende_a,
                         @Costo,
						 @itbis_calculado)
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Insertar_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_factura] @idcliente          AS INTEGER,
                                   @fecha_factura        AS DATETIME,
                                   @nume_documento     AS VARCHAR(50),
                                   @montototal         AS NUMERIC(18, 2),
                                   @Tipo_de_pago       AS VARCHAR(50),
                                   @estado             AS VARCHAR(50),
                                   @Comprobante        AS VARCHAR(50),
                                   @id_usuario         AS INT,
                                   @Fecha_de_pago      AS VARCHAR(50),
                                   @ACCION             VARCHAR(50),
                                   @Saldo              NUMERIC(18, 2),
                                   @Pago_con           NUMERIC(18, 2),
                                   @Id_caja            INT,
                                   @Referencia_tarjeta VARCHAR(50)
AS
    DECLARE @vuelto NUMERIC(18, 2)
    DECLARE @Efectivo NUMERIC(18, 2)
    DECLARE @id_numero VARCHAR(50)
    DECLARE @Credito NUMERIC(18, 2)
    DECLARE @Tarjeta NUMERIC(18, 2)

    SET @vuelto =0
    SET @Efectivo =0
    SET @id_numero= (SELECT Max(idFactura) + 1
                     FROM   facturas)
    SET @Credito =0
    SET @Tarjeta =0

    INSERT INTO facturas
    VALUES      (@idcliente,
                 @fecha_factura,
                 @nume_documento,
                 @montototal,
                 @Tipo_de_pago,
                 @estado,
                 @Comprobante + ' ' + @id_numero,
                 @id_usuario,
                 @Fecha_de_pago,
                 @ACCION,
                 @Saldo,
                 @Pago_con,
                 @Id_caja,
                 @Referencia_tarjeta,
                 @vuelto,
                 @Efectivo,
                 @Credito,
                 @Tarjeta )

GO
/****** Object:  StoredProcedure [dbo].[Insertar_formato_ticket]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insertar_formato_ticket] @Identificador_fiscal           VARCHAR(max),
                                                 @Direccion                      VARCHAR(max),
                                                 @Provincia_Departamento_Pais    VARCHAR(max),
                                                 @Nombre_de_Moneda               VARCHAR(max),
                                                 @Agradecimiento                 VARCHAR(max),
                                                 @pagina_Web_Facebook            VARCHAR(max),
                                                 @Anuncio                        VARCHAR(max),
                                                 @Datos_fiscales_de_autorizacion VARCHAR(max),
                                                 @Por_defecto                    AS VARCHAR(max)
AS
    DECLARE @Id_Empresa INT = (SELECT Id_empresa
       FROM   EMPRESA)

    INSERT INTO Ticket
    VALUES      ( @Id_Empresa,
                  @Identificador_fiscal,
                  @Direccion,
                  @Provincia_Departamento_Pais,
                  @Nombre_de_Moneda,
                  @Agradecimiento,
                  @pagina_Web_Facebook,
                  @Anuncio,
                  @Datos_fiscales_de_autorizacion,
                  @Por_defecto )

GO
/****** Object:  StoredProcedure [dbo].[Insertar_gastos_varios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Insertar_gastos_varios] @Fecha            AS DATETIME,
                                           @Nro_documento    AS VARCHAR(MAX),
                                           @Tipo_comprobante AS VARCHAR(MAX),
                                           @Importe          AS NUMERIC(18, 2),
                                           @Descripcion      AS VARCHAR(MAX),
                                           @Id_caja          AS INT,
                                           @Id_concepto      AS INT
AS
    INSERT INTO Gastos_varios
    VALUES      ( @Fecha,
                  @Nro_documento,
                  @Tipo_comprobante,
                  @Importe,
                  @Descripcion,
                  @Id_caja,
                  @Id_concepto)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_grupo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insertar_grupo] @Grupo       VARCHAR(50),
                                        @Por_defecto VARCHAR(50)
AS
    IF EXISTS (SELECT Linea
               FROM   Grupo_de_Productos
               WHERE  Linea = @Grupo)
      RAISERROR ('YA EXISTE UN GRUPO CON ESTE NOMBRE, Ingrese de nuevo',16,1)
    ELSE
      INSERT INTO Grupo_de_Productos
      VALUES      (@Grupo,
                   @Por_defecto)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_ingresos_varios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Insertar_ingresos_varios] @Fecha            AS DATETIME,
                                             @Nro_comprobante  AS VARCHAR(MAX),
                                             @Tipo_comprobante AS VARCHAR(MAX),
                                             @Importe          AS NUMERIC(18, 2),
                                             @Descripcion      AS VARCHAR(MAX),
                                             @Id_caja          AS INT
AS
    INSERT INTO Ingresos_varios
    VALUES      ( @Fecha,
                  @Nro_comprobante,
                  @Tipo_comprobante,
                  @Importe,
                  @Descripcion,
                  @Id_caja)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_inicio_de_sesion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_inicio_de_sesion] @Id_serial_Pc VARCHAR(max)
AS
    DECLARE @id_usuario_nuevo AS INT

    SET @id_usuario_nuevo = (SELECT Max(idUsuario)
                             FROM   USUARIO2)

    INSERT INTO Inicios_de_sesion_por_caja
    VALUES      (@Id_serial_Pc,
                 @id_usuario_nuevo )

GO
/****** Object:  StoredProcedure [dbo].[Insertar_kardex_entrada]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_kardex_entrada] @Fecha       DATETIME,
                                            @Motivo      VARCHAR(max),
                                            @Cantidad    AS NUMERIC(18, 2),
                                            @Id_producto INT,
                                            @Id_usuario  AS INT,
                                            @Tipo        AS VARCHAR(50),
                                            @Estado      VARCHAR(50),
                                            @Id_caja     INT
AS
    DECLARE @Hay AS NUMERIC(18, 2)
    DECLARE @Habia AS NUMERIC(18, 2)
    DECLARE @Costo_unt NUMERIC(18, 2)

     SET @Hay = (SELECT Stock
                FROM   Producto
                WHERE  idProducto = @Id_producto)
    SET @Costo_unt=(SELECT PrecioCompra
                    FROM   Producto
                    WHERE  idProducto = @Id_producto)
    SET @Habia = @Hay + @Cantidad

    INSERT INTO KARDEX
    VALUES     ( @Fecha,
                 @Motivo,
                 @Cantidad,
                 @Id_producto,
                 @Id_usuario,
                 @Tipo,
                 @Estado,
                 @Costo_unt,
                 @Habia,
                 @Hay,
                 @Id_caja)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_kardex_salida]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_kardex_salida] @Fecha       DATETIME,
                                           @Motivo      VARCHAR(max),
                                           @Cantidad    AS NUMERIC(18, 2),
                                           @Id_producto INT,
                                           @Id_usuario  AS INT,
                                           @Tipo        AS VARCHAR(50),
                                           @Estado      VARCHAR(50),
                                           @Id_caja     INT
AS
    DECLARE @Hay AS NUMERIC(18, 2)
    DECLARE @Habia AS NUMERIC(18, 2)
    DECLARE @Costo_unt NUMERIC(18, 2)

    SET @Hay = (SELECT Stock
                FROM   Producto
                WHERE  idProducto = @Id_producto)
    SET @Costo_unt=(SELECT PrecioCompra
                    FROM   Producto
                    WHERE  idProducto = @Id_producto)
    SET @Habia = @Hay + @Cantidad

    INSERT INTO KARDEX
    VALUES     ( @Fecha,
                 @Motivo,
                 @Cantidad,
                 @Id_producto,
                 @Id_usuario,
                 @Tipo,
                 @Estado,
                 @Costo_unt,
                 @Habia,
                 @Hay,
                 @Id_caja)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_marcan]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insertar_marcan] @s  VARCHAR(MAX),
                                         @f  VARCHAR(MAX),
                                         @e  VARCHAR(MAX),
                                         @fa VARCHAR(MAX)
AS
    INSERT INTO Marcan
    VALUES      (@s,
                 @f,
                 @e,
                 @fa)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_municipio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_municipio] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Municipio
    VALUES     (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_pedido]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_pedido] @idcliente             INT,
                                    @idFactura             INT,
                                    @idEmpleado            INT,
                                    @idVehiculo            INT,
                                    @FechaEnvio            DATETIME,
                                    @Destinatario          VARCHAR(50),
                                    @DireccionDestinatario VARCHAR(50),
                                    @Estado                VARCHAR(50)
AS
    IF EXISTS(SELECT idFactura
              FROM   Pedidos
              WHERE  idFactura = @idFactura)
      RAISERROR('YA EXISTE UN PEDIDO EN CURSO',16,1)
    ELSE
      INSERT INTO Pedidos
      VALUES     (@idcliente,
                  @idFactura,
                  @idEmpleado,
                  @idVehiculo,
                  @FechaEnvio,
                  @Destinatario,
                  @DireccionDestinatario,
                  @Estado )

GO
/****** Object:  StoredProcedure [dbo].[Insertar_producto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insertar_producto]
  --Empezamos a declara primero los parametros para Productos
  @idCategoria as int,
  @idPrecios as int,
  @Codigo as varchar(50),
  @Descripcion as varchar(50),
  @Stock as numeric(18,2),
  @PrecioCompra as numeric (18,2),
  @idImpuesto as int,
  @idDescuento as int,
  
  --Ahora declaramos los parametros para el Ingreso a Kardex que es donde se controla el Infacturario
  @Fecha                DATETIME,
  @Motivo               VARCHAR(200),
  @Cantidad             AS NUMERIC(18, 0),
  @Id_usuario           AS INT,
  @Tipo                 AS VARCHAR(50),
  @Estado               VARCHAR(50),
  @Id_caja              INT
AS
  --Ahora VALIDAMOS para que no se agregen productos con el mismo nombre y codigo de barras
  BEGIN
      IF EXISTS (SELECT Descripcion,
                        Codigo
                 FROM   Producto
                 WHERE  Descripcion = @Descripcion
                        AND Codigo = @Codigo)
        RAISERROR ('YA EXISTE UN PRODUCTO  CON ESTE NOMBRE/CODIGO, POR FAVOR INGRESE DE NUEVO',16,1)
      ELSE
        BEGIN
            DECLARE @idProducto INT

            INSERT INTO Producto
            VALUES      ( @idCategoria,
  @idPrecios ,
  @Codigo ,
  @Descripcion ,
  @Stock ,
  @PrecioCompra ,
  @idImpuesto,
  @idDescuento)

            --Ahora Obtenemos el Id del producto que se acaba de ingresar
            SELECT @idProducto = Scope_identity()

            --Ahora Obtenemos los datos del producto ingresado para que sean insertados en la Tabla KARDEX
            DECLARE @Hay AS NUMERIC(18, 2)
            DECLARE @Habia AS NUMERIC(18, 2)
            DECLARE @Costo_unt NUMERIC(18, 2)

            SET @Hay = (SELECT Stock
                        FROM   Producto
                        WHERE  Producto.idProducto = @idProducto)
            SET @Costo_unt = (SELECT Producto.PrecioCompra
                              FROM   Producto
                              WHERE  Producto.idProducto = @idProducto)
            SET @Habia = 0
            

            --Ahora en caso si Use infacturarios Entonces Pasamos a Insertar datos en la Tabla Kardex
                  INSERT INTO KARDEX
                  VALUES      ( @Fecha,
                                @Motivo,
                                @Cantidad,
                                @idProducto,
                                @Id_usuario,
                                @Tipo,
                                @Estado,
                                @Costo_unt,
                                @Habia,
                                @Hay,
                                @Id_caja)
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[Insertar_producto_importacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_producto_importacion]
  --Empezamos a declara primero los parametros para Productos
  @Descripcion          VARCHAR(50),
  @Imagen               VARCHAR(50),
  @Usa_inventarios      VARCHAR(50),
  @Stock                VARCHAR(50),
  @Precio_de_compra     NUMERIC(18, 2),
  @Fecha_de_vencimiento VARCHAR(50),
  @Precio_de_factura      NUMERIC(18, 2),
  @Codigo               VARCHAR(50),
  @Se_vende_a           VARCHAR(50),
  @Impuesto             VARCHAR(50),
  @Stock_minimo         NUMERIC(18, 2),
  @Precio_mayoreo       NUMERIC(18, 2),
  @A_partir_de          NUMERIC(18, 2),

  --Ahora declaramos los parametros para el Ingreso a Kardex que es donde se controla el Infacturario
  @Fecha                DATETIME,
  @Motivo               VARCHAR(200),
  @Cantidad             AS NUMERIC(18, 0),
  @Id_usuario           AS INT,
  @Tipo                 AS VARCHAR(50),
  @Estado               VARCHAR(50),
  @Id_caja              INT
AS
    DECLARE @Id_grupo AS INT

    SET @Id_grupo= (SELECT Idline
                    FROM   Grupo_de_Productos
                    WHERE  Grupo_de_Productos.Linea = 'General')

  --Ahora VALIDAMOS para que no se agregen productos con el mismo nombre y codigo de barras
  BEGIN
      IF EXISTS (SELECT Descripcion,
                        Codigo
                 FROM   Producto1
                 WHERE  ( Descripcion = @Descripcion
                          AND Codigo = @Codigo )
                         OR Descripcion = '')
        SELECT TOP 0 *
        FROM   Producto1
      ELSE
        BEGIN
            DECLARE @Id_producto INT

            INSERT INTO Producto1
            VALUES      ( @Descripcion,
                          @Imagen,
                          @Id_grupo,
                          @Usa_inventarios,
                          @Stock,
                          @Precio_de_compra,
                          @Fecha_de_vencimiento,
                          @Precio_de_factura,
                          @Codigo,
                          @Se_vende_a,
                          @Impuesto,
                          @Stock_minimo,
                          @Precio_mayoreo,
                          @A_partir_de )

            --Ahora Obtenemos el Id del producto que se acaba de ingresar
            SELECT @id_producto = Scope_identity()

            --Ahora Obtenemos los datos del producto ingresado para que sean insertados en la Tabla KARDEX
            DECLARE @Hay AS NUMERIC(18, 2)
            DECLARE @Habia AS NUMERIC(18, 2)
            DECLARE @Costo_unt NUMERIC(18, 2)

            SET @Hay = (SELECT Stock
                        FROM   Producto1
                        WHERE  Producto1.Id_Producto1 = @Id_producto
                               AND Producto1.Usa_inventarios = 'SI')
            SET @Costo_unt = (SELECT Producto1.Precio_de_compra
                              FROM   Producto1
                              WHERE  Producto1.Id_Producto1 = @Id_producto
                                     AND Producto1.Usa_inventarios = 'SI')
            SET @Habia = 0
            --Ahora vamos a saber si el Producto Usa_inventarios Infacturarios o no
            SET @Usa_inventarios = (SELECT Usa_inventarios
                                    FROM   Producto1
                                    WHERE  Producto1.Id_Producto1 = @Id_producto
                                           AND Producto1.Usa_inventarios = 'SI')

            --Ahora en caso si Use infacturarios Entonces Pasamos a Insertar datos en la Tabla Kardex
            IF @Usa_inventarios = 'SI'
              BEGIN
                  INSERT INTO KARDEX
                  VALUES      ( @Fecha,
                                @Motivo,
                                @Cantidad,
                                @Id_producto,
                                @Id_usuario,
                                @Tipo,
                                @Estado,
                                @Costo_unt,
                                @Habia,
                                @Hay,
                                @Id_caja)
              END

            BEGIN
                UPDATE Producto1
                SET    Codigo = Id_Producto1
                WHERE  Codigo = 'VACIO@'
            END

            BEGIN
                DELETE FROM Producto1
                WHERE  Descripcion = 'VACIO@'
            END

            BEGIN
                DELETE FROM Producto1
                WHERE  Descripcion = 'Descripcion'
            END
        END
  END

GO
/****** Object:  StoredProcedure [dbo].[Insertar_proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_proveedores] @idPersona           AS INT,
                                         @IdentificadorFiscal AS VARCHAR(MAX),
                                         @Estado              AS VARCHAR(50),
                                         @Saldo               AS NUMERIC(18, 2)
AS
    IF EXISTS(SELECT idPersona
              FROM   Proveedores
              WHERE  idPersona = @idPersona)
      RAISERROR('Registro ya existente',16,1)
    ELSE
      INSERT INTO Proveedores
      VALUES      ( @idPersona,
                    @IdentificadorFiscal,
                    @Estado,
                    @Saldo)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_provincia]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_provincia] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Provincia
    VALUES     (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_region]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_region] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Region
    VALUES     (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_sector]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_sector] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Sector
    VALUES     (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_serializacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insertar_serializacion] @Serie        VARCHAR (50),
                                                @numeroinicio AS VARCHAR (50),
                                                @numerofin    AS VARCHAR (50),
                                                @Destino      AS VARCHAR(50),
                                                @tipodoc      VARCHAR(50),
                                                @Por_defecto  VARCHAR(50)
AS
    IF EXISTS (SELECT tipodoc
               FROM   Serializacion
               WHERE  tipodoc = @tipodoc)
      RAISERROR ('YA EXISTE ESTE COMPROBANTE INGRESE UNO NUEVO',16,1)
    ELSE
      INSERT INTO Serializacion
      VALUES      (@Serie,
                   @numeroinicio,
                   @numerofin,
                   @Destino,
                   @tipodoc,
                   @Por_defecto)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_tipotelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insertar_tipotelefono] @descripcion VARCHAR(50)
AS
    IF EXISTS (SELECT descripcion
               FROM   TipoTelefono
               WHERE  descripcion = @descripcion)
      RAISERROR ('YA EXISTE UN TIPO DE TELEFONO CON ESTE NOMBRE, Ingrese de nuevo',16,1)
    ELSE
      INSERT INTO TipoTelefono
      VALUES      (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[Insertar_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertar_usuario] @idEmpleado      AS INT,
                                     @Login           VARCHAR(50),
                                     @Password        VARCHAR(50),
                                     @Icono           IMAGE,
                                     @Nombre_de_icono VARCHAR(max),
                                     @idRol             int,
                                     @Estado          VARCHAR(50)
AS
    IF EXISTS (SELECT idEmpleado,
                      Login
               FROM   USUARIO2
               WHERE  ( idEmpleado = @idEmpleado
                         OR Login = @Login )
                      AND Estado = 'ACTIVO')
      RAISERROR('YA EXISTE UN USUARIO CON ESE LOGIN O CON ESE EMPLEADO, POR FAVOR INGRESE DE NUEVO',16,1 )
    ELSE
      INSERT INTO USUARIO2
      VALUES     (@idEmpleado,
                  @Login,
                  @Password,
                  @Icono,
                  @Nombre_de_icono,
                  @idRol,
                  @Estado )

GO
/****** Object:  StoredProcedure [dbo].[insertarAlmacen]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarAlmacen] 
@almacen as varchar(50),
@stockminimo as numeric(18,2),
@idlocalizacion as int,
@idDireccion as int
AS
    insert into Almacen 
	values(@almacen, @stockminimo, @idlocalizacion, @idDireccion)
GO
/****** Object:  StoredProcedure [dbo].[insertarCategoria]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[insertarCategoria] 

@idItbis as int,
@idDescuento as int,
@descripcion AS VARCHAR(50),
@departamento AS VARCHAR(50),
@estado AS VARCHAR(50)

AS

IF EXISTS (SELECT Descripcion,
                      Departamento
               FROM   CategoriaProductos
               WHERE  ( Descripcion = @descripcion
                         OR Departamento = @departamento)
                      AND Estado = 'ACTIVO')
      RAISERROR('YA EXISTE UNA CATEGORIA CON ESOS DATOS, POR FAVOR INGRESE DE NUEVO',16,1 )
    ELSE
    INSERT INTO CategoriaProductos
    VALUES     (@descripcion, @departamento, @idItbis, @idDescuento, @estado)
GO
/****** Object:  StoredProcedure [dbo].[insertarCiudad]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarCiudad] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Ciudad
    VALUES     (@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[InsertarClavesSat]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[InsertarClavesSat] 
@clave as varchar(50),
@nombre AS VARCHAR(50),
@descripcion AS VARCHAR(50)

AS
    INSERT INTO ClavesSat
    VALUES     (@clave,@nombre,@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[insertarControlPago]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[insertarControlPago]	   @Monto       AS NUMERIC(18, 2),
                                           @Fecha       AS DATETIME,
                                           @Detalle     AS VARCHAR(50),
                                           @idProveedor   AS INT,
                                           @IdUsuario   AS INT,
                                           @IdCaja      AS INT,
                                           @Comprobante AS VARCHAR(MAX),
                                           @efectivo    NUMERIC(18, 2),
                                           @tarjeta     NUMERIC(18, 2),
										   @TransferenciaBancaria varchar(50)
AS
    INSERT INTO ControlPago
    VALUES      ( @Monto,
                  @Detalle,
                  @Fecha,
                  @idProveedor,
                  @IdUsuario,
                  @IdCaja,
                  @Comprobante,
                  @efectivo,
                  @tarjeta,
				  @TransferenciaBancaria)

GO
/****** Object:  StoredProcedure [dbo].[insertarCorreo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[insertarCorreo] @correo as varchar(50),
@tipocorreo as varchar(50)
AS
      INSERT INTO Correos
      VALUES      (@correo,
                   @tipocorreo
                   )

GO
/****** Object:  StoredProcedure [dbo].[Insertarcorreobase]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertarcorreobase] @Correo          VARCHAR(max),
                                       @Password        VARCHAR(max),
                                       @Estado_De_envio VARCHAR(50)
AS
    INSERT INTO CorreoBase
    VALUES     (@Correo,
                @Password,
                @Estado_De_envio)

GO
/****** Object:  StoredProcedure [dbo].[insertarDatosFiscales]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarDatosFiscales]
@NombreFiscal as varchar(50),
@infoAdicional as varchar(50),
@RegimenFiscal as varchar(50),
@RNC as varchar(50),
@NoFiscal as varchar(50),
@CodPostal as varchar(30),
@Localidad as varchar(50),
@Domicilio as varchar(50),
@NoInt as varchar(50),
@NoExt as varchar(50),
@CDL as varchar(50),
@Provincia as varchar(50),
@Ciudad as varchar(50)
as
insert into DatosFiscales
values(
@NombreFiscal,
@infoAdicional,
@RegimenFiscal,
@RNC,
@NoFiscal,
@CodPostal,
@Localidad,
@Domicilio ,
@NoInt,
@NoExt,
@CDL,
@Provincia,
@Ciudad 
)
GO
/****** Object:  StoredProcedure [dbo].[insertarDescuento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[insertarDescuento] @Descuento AS numeric(18,2),
@TipoDescuento as Varchar(50)
AS
    INSERT INTO Descuentos
    VALUES     (@Descuento,@TipoDescuento )

GO
/****** Object:  StoredProcedure [dbo].[insertarDetalleProducto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[insertarDetalleProducto]
  --Empezamos a declara primero los parametros para Productos
  @idProducto as int,
  @idProveedor as int,
  @Localizacion as varchar(50),
  @StockMinimo as numeric(18,2),
  @Granel as varchar(50),
  @UsoInterno as varchar(50),
  @Peso as varchar(50),
  @FechaVencimiento as varchar(50)

AS
  --Ahora VALIDAMOS para que no se agregen productos con el mismo nombre y codigo de barras
        BEGIN
            INSERT INTO DetalleProducto 
            VALUES      ( @idProducto,
						  @idProveedor ,
						  @Localizacion ,
						  @StockMinimo,
						  @UsoInterno ,
						  @Granel,
						  @Peso,
						  @FechaVencimiento)
  END
GO
/****** Object:  StoredProcedure [dbo].[insertarDireccion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarDireccion]
@Descripcion as varchar(50),
@idRegion as int,
@idMunicipio as int,
@idSector as int,
@idProvincia as int,
@idCalle as int,
@idCiudad as int
as
		insert into Direccion
	values
	(
	@Descripcion,
@idRegion,
@idMunicipio,
@idSector,
@idProvincia,
@idCalle,
@idCiudad
	)

GO
/****** Object:  StoredProcedure [dbo].[Insertardocumento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertardocumento] @TipoDocumento AS VARCHAR(50),
                                      @numeracion    AS VARCHAR(50)
AS
    IF EXISTS(SELECT numeracion
              FROM   Documento
              WHERE  numeracion = @numeracion)
      RAISERROR('ERROR, NUMERACION DE DOCUMENTO EXISTENTE',16,1);

    INSERT INTO Documento
    VALUES     (@TipoDocumento,
                @numeracion)

GO
/****** Object:  StoredProcedure [dbo].[Insertarempleados]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insertarempleados] 
									@idPersona    AS INT,
                                      @idHorario    AS INT,
                                      @cuentaBanco  VARCHAR(50),
                                      @departamento VARCHAR(max),
                                      @banco        VARCHAR(max),
                                      @icono        IMAGE,
                                      @estado       VARCHAR(50),
									  @idEmpresa	as int
AS										
    SET NOCOUNT ON

    IF EXISTS (SELECT idPersona
               FROM   Empleados
               WHERE  idPersona = @idPersona
                      AND estado = 'ACTIVO')
      RAISERROR('YA EXISTE ESTE EMPLEADO, POR FAVOR INGRESE UNO NUEVO',16,1)
    ELSE
      INSERT INTO Empleados
      VALUES     (@idPersona,
                  @idHorario,
                  @cuentaBanco,
                  @departamento,
                  @banco,
                  @icono,
                  @estado,
				  1)

GO
/****** Object:  StoredProcedure [dbo].[insertarEmpresa]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[insertarEmpresa] 
@Nombre_Empresa as varchar(50),
@Logo as image,
@Moneda as varchar(50),
@Modo_de_busqueda as varchar(50),
@Carpeta_para_copias_de_seguridad as varchar(max),
@idCorreo as int,
@Ultima_fecha_de_copia_de_seguridad as varchar(50),
@Ultima_fecha_de_copia_date as datetime,
@Frecuencia_de_copias as int,
@idDireccion as int,
@idDatosFiscales as int,
@idTelefono as int,
@idCelular as int
AS
      INSERT INTO EMPRESA
      VALUES      (@Nombre_Empresa,
@Logo ,
@Moneda ,
@Modo_de_busqueda,
@Carpeta_para_copias_de_seguridad,
@idCorreo,
@Ultima_fecha_de_copia_de_seguridad,
@Ultima_fecha_de_copia_date ,
@Frecuencia_de_copias,
@idDireccion,
@idDatosFiscales,
@idTelefono,
@idCelular)
GO
/****** Object:  StoredProcedure [dbo].[insertarFacturaExterna]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[insertarFacturaExterna]	  
											@NumFact as Varchar(50),
											@Monto       AS NUMERIC(18, 2),
                                           @Fecha       AS DATETIME,
                                           @Detalle     AS VARCHAR(50),
                                           @idProveedor   AS INT,
                                           @IdUsuario   AS INT,
                                           @IdCaja      AS INT,
                                           @Comprobante AS VARCHAR(MAX),
                                           @efectivo    NUMERIC(18, 2),
                                           @tarjeta     NUMERIC(18, 2),
										   @TransferenciaBancaria varchar(50)
AS
    INSERT INTO FacturasExternas
    VALUES      ( 
	@NumFact,
	@Monto,
                  @Detalle,
                  @Fecha,
                  @idProveedor,
                  @IdUsuario,
                  @IdCaja,
                  @Comprobante,
                  @efectivo,
                  @tarjeta,
				  @TransferenciaBancaria)

GO
/****** Object:  StoredProcedure [dbo].[Insertarhorario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertarhorario] @HoraEntrada VARCHAR(50),
                                    @HoraSalida  VARCHAR(50),
                                    @TipoHorario AS INT
AS
    INSERT INTO Horario
    VALUES     (@HoraEntrada,
                @HoraSalida,
                @TipoHorario)

GO
/****** Object:  StoredProcedure [dbo].[insertarImpuestos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[insertarImpuestos]
@nombre as varchar(50),
@impuesto as numeric(18,2),
@tipo as varchar(50)
AS
	if exists(select nombre from Impuestos where Nombre = @nombre)
	raiserror('Este impuesto ya existe, favor nombrelo de otra manera',18,2)
  BEGIN
     insert into Impuestos
	 values (@nombre,@impuesto,@tipo,'ACTIVO')
  END
GO
/****** Object:  StoredProcedure [dbo].[insertarImpuestosCategoria]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[insertarImpuestosCategoria]
@nombre as varchar(50),
@impuesto as numeric(18,2),
@tipo as varchar(50)
AS
	if exists(select nombre from Impuestos where Nombre = @nombre)
	raiserror('Este impuesto ya existe, favor nombrelo de otra manera',18,2)
  BEGIN
     insert into Impuestos
	 values (@nombre,@impuesto,@tipo,'ACTIVO')
  END
GO
/****** Object:  StoredProcedure [dbo].[insertarImpuestosgeneral]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[insertarImpuestosgeneral]
@nombre as varchar(50),
@impuesto as numeric(18,2),
@tipo as varchar(50)
AS
  BEGIN
     insert into Impuestos
	 values (@nombre,@impuesto,@tipo,'ACTIVO')
  END

GO
/****** Object:  StoredProcedure [dbo].[insertarListaPrecio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[insertarListaPrecio]
@idMayoreo          as int,
@Precio_1 as numeric(18,2),
@Precio_2 as numeric(18,2),
@Precio_3 as numeric(18,2),
@Precio_4 as numeric(18,2)
AS
      INSERT INTO ListaPrecios
      VALUES     (@idMayoreo,
                  @Precio_1,
                  @Precio_2,
                  @Precio_3,
                  @Precio_4
				  )
GO
/****** Object:  StoredProcedure [dbo].[insertarMayoreo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[insertarMayoreo]
@Unidades_1 as numeric(18,2),
@Unidades_2 as numeric(18,2),
@Unidades_3 as numeric(18,2),
@Unidades_4 as numeric(18,2)
AS
      INSERT INTO VentasMayoreo
      VALUES     (
                  @Unidades_1,
                  @Unidades_2,
                  @Unidades_3,
                  @Unidades_4
				  )
GO
/****** Object:  StoredProcedure [dbo].[insertarModulos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarModulos]
@Modulo as varchar(50)
as
	insert into Modulo
	values(@Modulo)
GO
/****** Object:  StoredProcedure [dbo].[insertarOperaciones]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarOperaciones]
@idModulo as int,
@Operacion as varchar(50)
as
	insert into Operaciones
	values(@Operacion, @idModulo)
GO
/****** Object:  StoredProcedure [dbo].[Insertarpersona]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertarpersona] @nombre          AS VARCHAR(50),
                                    @apellido        AS VARCHAR(50),
                                    @idCorreo          AS int,
                                    @fechaNacimiento AS DATETIME,
                                    @idDireccion     AS INT,
                                    @idDocumento     AS INT,
                                    @idTelefono      AS INT
AS
      INSERT INTO Persona
      VALUES     (@nombre,
                  @apellido,
                  @fechaNacimiento,
                  @idDireccion,
                  @idDocumento,
                  @idTelefono,
				  @idCorreo)

GO
/****** Object:  StoredProcedure [dbo].[insertarPreciosProveedor]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[insertarPreciosProveedor] @idProveedor AS int,
@idProducto as int,
@PrecioCompra as numeric(18,2),
@FechaCompra as datetime
AS
    INSERT INTO PreciosCompraProveedor
    VALUES     (@idProveedor, @idProducto, @PrecioCompra, @FechaCompra)

GO
/****** Object:  StoredProcedure [dbo].[insertarProducto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[insertarProducto]
  --Empezamos a declara primero los parametros para Productos
  @idCategoria as int,
  @Codigo as varchar(50),
  @Descripcion as varchar(50),
  @Stock as numeric(18,2),
  @PrecioCompra as numeric (18,2),
 @idPrecios INT,
  @idImpuesto as int,
  @idDescuento as int,

  --Parametros de unidadcompra y unidadventa
  @idUnidadVenta as int,
  @idUnidadCompra as int,
  
  --Ahora declaramos los parametros para el Ingreso a Kardex que es donde se controla el Infacturario
  @Fecha                DATETIME,
  @Motivo               VARCHAR(200),
  @Cantidad             AS NUMERIC(18, 0),
  @Id_usuario           AS INT,
  @Tipo                 AS VARCHAR(50),
  @Estado               VARCHAR(50),
  @Id_caja              INT
AS
  --Ahora VALIDAMOS para que no se agregen productos con el mismo nombre y codigo de barras
  BEGIN
      IF EXISTS (SELECT Descripcion,
                        Codigo
                 FROM   Producto
                 WHERE  Descripcion = @Descripcion
                        AND Codigo = @Codigo)
        RAISERROR ('YA EXISTE UN PRODUCTO  CON ESTE NOMBRE/CODIGO, POR FAVOR INGRESE DE NUEVO',16,1)
      ELSE
        BEGIN
            DECLARE @idProducto INT

            INSERT INTO Producto
            VALUES      ( @idCategoria,
  @idPrecios ,
  @Codigo ,
  @Descripcion ,
  @Stock ,
  @PrecioCompra ,
  @idImpuesto,
  @idDescuento)
            --Ahora Obtenemos el Id del producto que se acaba de ingresar
            SELECT @idProducto = Scope_identity()
            --Ahora Obtenemos los datos del producto ingresado para que sean insertados en la Tabla KARDEX
            DECLARE @Hay AS NUMERIC(18, 2)
            DECLARE @Habia AS NUMERIC(18, 2)
            DECLARE @Costo_unt NUMERIC(18, 2)

            SET @Hay = (SELECT Stock
                        FROM   Producto
                        WHERE  Producto.idProducto = @idProducto)
            SET @Costo_unt = (SELECT Producto.PrecioCompra
                              FROM   Producto
                              WHERE  Producto.idProducto = @idProducto)
            SET @Habia = 0
            

            --Ahora en caso si Use infacturarios Entonces Pasamos a Insertar datos en la Tabla Kardex
                  INSERT INTO KARDEX
                  VALUES      ( @Fecha,
                                @Motivo,
                                @Cantidad,
                                @idProducto,
                                @Id_usuario,
                                @Tipo,
                                @Estado,
                                @Costo_unt,
                                @Habia,
                                @Hay,
                                @Id_caja)

		    --Ahora insertamos la unidad de venta y la unidad de compra
					insert into UnidadesVSProducto
					Values	(@idUnidadVenta,
					@idUnidadCompra,
					@idProducto)
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[insertarRol]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[insertarRol] @descripcion AS VARCHAR(50)
AS
    INSERT INTO Roles
    VALUES     (@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[insertarRolVsOperaciones]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarRolVsOperaciones]
@idRol as int,
@idOperacion as int
as
	insert into rolVSoperacion
	values(@idRol,@idOperacion)
GO
/****** Object:  StoredProcedure [dbo].[Insertartelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertartelefono] @Telefono       AS VARCHAR(50),
                                     @idTipoTelefono AS INT
AS
    INSERT INTO Telefono
    VALUES     (@Telefono,
                @idTipoTelefono)

GO
/****** Object:  StoredProcedure [dbo].[Insertartipohorario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertartipohorario] @TipoHorario AS VARCHAR(50)
AS
    INSERT INTO TipoHorario
    VALUES      (@TipoHorario)

GO
/****** Object:  StoredProcedure [dbo].[Insertartipotelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertartipotelefono] @TipoTelefono AS VARCHAR(50)
AS
    IF EXISTS(SELECT descripcion
              FROM   TipoTelefono
              WHERE  descripcion = @TipoTelefono)
      RAISERROR('YA EXISTE ESTE TIPO DE TELEFONO',16,1);

    INSERT INTO TipoTelefono
    VALUES     (@TipoTelefono)

GO
/****** Object:  StoredProcedure [dbo].[Insertartipovehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertartipovehiculo] @TipoVehiculo AS VARCHAR(50),
                                         @capacidad    AS VARCHAR(50)
AS
    IF EXISTS(SELECT descripcion
              FROM   TipoVehiculo
              WHERE  descripcion = @TipoVehiculo)
      RAISERROR('YA EXISTE ESTE TIPO DE VEHICULO',16,1);

    INSERT INTO TipoVehiculo
    VALUES     (@TipoVehiculo,
                @capacidad)

GO
/****** Object:  StoredProcedure [dbo].[insertarUnidad]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[insertarUnidad] 
@descripcion as varchar(50),
@idClaveSAT AS INT

AS
    INSERT INTO UnidadesProductos
    VALUES     (@descripcion,@idClaveSAT)
GO
/****** Object:  StoredProcedure [dbo].[Insertarvehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insertarvehiculo] @idTipoVehiculo AS INT,
                                     @NPlaca         AS VARCHAR(50),
                                     @Transmision    AS VARCHAR(50),
                                     @Color          AS VARCHAR(50),
                                     @Marca          AS VARCHAR(50),
                                     @Modelo         AS VARCHAR(50),
                                     @Ano            AS INT,
                                     @Icono          IMAGE,
                                     @Capacidad      AS VARCHAR(50),
                                     @Estado         AS VARCHAR(50)
AS
    SET NOCOUNT ON;

    IF EXISTS(SELECT NPlaca
              FROM   Vehiculos
              WHERE  NPlaca = @NPlaca
                     AND Estado = 'ACTIVO')
      RAISERROR('Este vehiculo ya existe',16,1)
    ELSE
      INSERT INTO Vehiculos
                  (NPlaca,
                   idTipoVehiculo,
                   Transmision,
                   Color,
                   Marca,
                   Modelo,
                   Ano,
                   Capacidad,
                   Icono,
                   Estado)
      VALUES      (@NPlaca,
                   @idTipoVehiculo,
                   @Transmision,
                   @Color,
                   @Marca,
                   @Modelo,
                   @Ano,
                   @Capacidad,
                   @Icono,
                   @Estado)

GO
/****** Object:  StoredProcedure [dbo].[insertAux]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertAux]
@idProducto as int,
@idDetalleFactura as int,
@idFactura as int
as
	insert into Aux_Productos
	values(@idFactura,@idProducto,@idDetalleFactura)
GO
/****** Object:  StoredProcedure [dbo].[M_facturas_credito_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[M_facturas_credito_por_turno] @idcaja INT,
                                               @fi     DATETIME,
                                               @ff     DATETIME
AS
    SELECT Sum(Credito)
    FROM   facturas
    WHERE  ( fecha_factura >= @fi
             AND fecha_factura <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[M_facturas_tarjeta_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[M_facturas_tarjeta_por_turno] @idcaja INT,
                                               @fi     DATETIME,
                                               @ff     DATETIME
AS
    SELECT Sum(Tarjeta)
    FROM   facturas
    WHERE  ( fecha_factura >= @fi
             AND fecha_factura <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Marcanvencidas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Marcanvencidas] @E VARCHAR(max)
AS
    UPDATE Marcan
    SET    E = @E

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_caja_principal]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_caja_principal]
AS
    IF EXISTS(SELECT MOVIMIENTOCAJACIERRE.Id_caja
              FROM   MOVIMIENTOCAJACIERRE
                     INNER JOIN Caja
                             ON caja.Id_Caja = MOVIMIENTOCAJACIERRE.Id_caja
              WHERE  Caja.tipo = 'PRINCIPAL')
      SELECT Caja.*,
             Usu.nombre,
             Max(MOVIMIENTOCAJACIERRE.idcierrecaja)
      FROM   MOVIMIENTOCAJACIERRE
             INNER JOIN Caja
                     ON caja.Id_Caja = MOVIMIENTOCAJACIERRE.Id_caja
             INNER JOIN USUARIO2
                     ON USUARIO2.idUsuario = MOVIMIENTOCAJACIERRE.Id_usuario
             INNER JOIN Empleados AS Emp
                     ON USUARIO2.idEmpleado = Emp.idEmpleado
             INNER JOIN Persona AS Usu
                     ON Emp.idPersona = Usu.idPersona
      WHERE  Caja.tipo = 'PRINCIPAL'
      GROUP  BY Caja.Serial_PC,
                Caja.Id_Caja,
                Caja.Descripcion,
                Caja.Tema,
                Caja.Impresora_A4,
                Caja.Impresora_Ticket,
                Caja.Estado,
                CAJA.Tipo,
                Usu.nombre,
                Caja.PuertoBalanza,
                Caja.EstadoBalanza
    ELSE
      SELECT Caja.*,
             Usu.nombre
      FROM   Caja
             CROSS JOIN USUARIO2 AS US
             INNER JOIN Empleados AS Emp
                     ON US.idEmpleado = Emp.idEmpleado
             INNER JOIN Persona AS Usu
                     ON Emp.idPersona = Usu.idPersona
      WHERE  tipo = 'PRINCIPAL'
             AND US.Login = 'admin' 
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_caja_remota]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_caja_remota]
AS
    IF EXISTS(SELECT MOVIMIENTOCAJACIERRE.Id_caja
              FROM   MOVIMIENTOCAJACIERRE
                     INNER JOIN Caja
                             ON caja.Id_Caja = MOVIMIENTOCAJACIERRE.Id_caja
              WHERE  Caja.tipo = 'SECUNDARIA')
      SELECT Caja.*,
             Usu.nombre,
             Max(MOVIMIENTOCAJACIERRE.idcierrecaja)
      FROM   MOVIMIENTOCAJACIERRE
             INNER JOIN Caja
                     ON caja.Id_Caja = MOVIMIENTOCAJACIERRE.Id_caja
             INNER JOIN USUARIO2
                     ON USUARIO2.idUsuario = MOVIMIENTOCAJACIERRE.Id_usuario
					 INNER JOIN Empleados AS Emp
                     ON USUARIO2.idEmpleado = Emp.idEmpleado
             INNER JOIN Persona AS Usu
                     ON Emp.idPersona = Usu.idPersona
      WHERE  Caja.tipo = 'SECUNDARIA'
      GROUP  BY Caja.Serial_PC,
                Caja.Id_Caja,
                Caja.Descripcion,
                Caja.Tema,
                Caja.Impresora_A4,
                Caja.Impresora_Ticket,
                Caja.Estado,
                CAJA.Tipo,
                Usu.nombre,
                Caja.PuertoBalanza,
                Caja.EstadoBalanza
    ELSE
      SELECT Caja.*,
	         Usu.nombre
      FROM   Caja
             CROSS JOIN USUARIO2 as Us
			 INNER JOIN Empleados AS Emp
                     ON US.idEmpleado = Emp.idEmpleado
             INNER JOIN Persona AS Usu
                     ON Emp.idPersona = Usu.idPersona
      WHERE  tipo = 'SECUNDARIA'
             AND Us.Login = 'admin' 
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_cajas_por_serial_de_discoduro]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_cajas_por_serial_de_discoduro] @Serial AS VARCHAR(max)
AS
    SELECT Id_Caja,
           Descripcion,
           Impresora_Ticket,
           Impresora_A4,
           Estado,
           Tipo,
           Tema
    FROM   Caja
    WHERE  Serial_PC = @Serial

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_cierre_de_caja_pendiente]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_cierre_de_caja_pendiente] @idcaja INT
AS
    SELECT Id_caja,
           fechainicio,
           Saldo_queda_en_caja AS SaldoInicial
    FROM   MOVIMIENTOCAJACIERRE
    WHERE  Id_caja = @idcaja
           AND Estado = 'CAJA APERTURADA'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_clientes]
AS
    SELECT c.idclientev,
           c.idPersona,
           p.nombre              AS Nombre,
           p.apellido            AS Apellido,
           CC.Correo,
           p.fechaNacimiento,
           d.idDireccion,
           d.Descripcion         AS Direccion,
           do.idDocumento,
           do.numeracion         AS Documento,
           do.Tipo               AS TipoDocumento,
           t.idTelefono,
           t.numero              AS Telefono,
           tt.idTipoTelefono,
           tt.descripcion        AS TipoTelefono,
           c.IdentificadorFiscal AS IdentificadorFiscal,
           c.Estado,
           c.Saldo,
		   cc.idCorreo
    FROM   dbo.clientes AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
           INNER JOIN TipoTelefono AS tt
                   ON t.idTipoTelefono = tt.idTipoTelefono
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Documento AS do
                   ON do.idDocumento = p.idDocumento
			inner join Correos as CC 
					on P.idCorreo = CC.idCorreo
    WHERE  c.Estado <> '0'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_cobros_en_efectivo_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_cobros_en_efectivo_por_turno] @idcaja INT,
                                                         @fi     DATETIME,
                                                         @ff     DATETIME
AS
    SELECT Sum(Efectivo)
    FROM   ControlCobros
    WHERE  ( Fecha >= @fi
             AND Fecha <= @ff )
           AND IdCaja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_cobros_tarjeta_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_cobros_tarjeta_por_turno] @idcaja INT,
                                                     @fi     DATETIME,
                                                     @ff     DATETIME
AS
    SELECT Sum(Tarjeta)
    FROM   ControlCobros
    WHERE  ( Fecha >= @fi
             AND Fecha <= @ff )
           AND IdCaja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_compra_impreso]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Mostrar_compra_impreso] @Id_factura      INT,
                                          @total_en_letras VARCHAR(50)
AS
    DECLARE @Descuento INT

    SET @Descuento = (SELECT Sum (Descuento)
                                  FROM   detalle_compra
                                         INNER JOIN compras
                                                 ON compras.idCompra = detalle_compra.idCompra
                                  WHERE  detalle_compra.idCompra = @Id_factura)

    

    SELECT Det.Descripcion                                    AS Producto,
           Det.cantidad                              AS Cant,
           Det.preciounitario                                 AS P_Unit,
           Det.Total_a_pagar                                  AS Importe,
           EMPRESA.Nombre_Empresa                             AS Empresa,
           EMPRESA.Logo,
           Ticket.*,
           Ven.fecha_compra                                  AS fecha,
           Ven.Monto_total,
           UsuN.nombre                                        AS Usuario,
           Ven.Vuelto,
           EMPRESA.Moneda,
           CliN.Nombre,
           Ven.Tipo_de_pago,
		   @Descuento as Descuento,
		   Descuento as Descuentos,
          -- @cantidad_de_productos                             AS Cantidad_de_productos,
           @total_en_letras                                   AS total_en_letras,
           Ven.Comprobante,
           Ven.Numero_de_doc
    FROM   detalle_compra AS Det
           INNER JOIN compras AS Ven
                   ON DET.idCompra = Ven.idCompra
           INNER JOIN Proveedores AS Cli
                   ON Ven.idProveedor= Cli.IdProveedor
           INNER JOIN usuario2 AS Usu
                   ON Ven.Id_usuario = Usu.idUsuario
           INNER JOIN Empleados AS Emp
                   ON Usu.idEmpleado = Emp.idEmpleado
           INNER JOIN Persona AS CliN
                   ON Cli.idPersona = CliN.idPersona
           INNER JOIN Persona AS UsuN
                   ON Emp.idPersona = UsuN.idPersona
           CROSS JOIN EMPRESA
           CROSS JOIN Ticket
    WHERE  Det.idCompra = @Id_factura
           AND Ven.Monto_total > 0
    ORDER  BY Det.iddetalle_compra DESC 
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_compras_en_espera_con_fecha_y_monto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_compras_en_espera_con_fecha_y_monto]
AS
    SELECT compras.idCompra,
           compras.Comprobante as NumCompra,
           compras.fecha_compra AS Fecha,
           compras.Id_caja,
           compras.ACCION,
		   Persona.nombre AS Proveedor
    FROM   compras
	inner join Proveedores
	on compras.idProveedor = Proveedores.IdProveedor
	inner join Persona
	on Proveedores.idPersona = Persona.idPersona
    WHERE  compras.Estado = 'EN ESPERA'
           AND compras.ACCION <> 'FACTURA' and compras.ACCION <> 'COTIZACION'
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_controlcobros]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Mostrar_controlcobros]
AS
    SELECT *
    FROM   ControlCobros

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_controlcobros_fact]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_controlcobros_fact]
@numFact as int
AS
    SELECT
		FP.idFactura,
		FP.NumFact
	,	F.idControlPago,
           F.Monto,
           F.Detalle,
           F.Fecha,
           F.idProveedor,
           F.idUsuario,
           F.idCaja,
           F.Comprobante,
           F.Efectivo,
           F.Tarjeta,
           F.TransferenciaBancaria
    FROM   FacturasExternas AS F 
    Inner join Proveedores as P
	on F.idProveedor = P.IdProveedor
	Inner join FacturasProveedores as FP
	on P.IdProveedor = FP.idProveedor
	where FP.NumFact = @NumFact
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_cotizaciones_en_espera_con_fecha_y_monto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_cotizaciones_en_espera_con_fecha_y_monto]
AS
    SELECT idFactura,
           Comprobante,
           fecha_factura AS Fecha,
           Id_caja,
           ACCION
    FROM   facturas
    WHERE  Estado = 'EN ESPERA'
           AND ACCION = 'COTIZACION'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_creditoporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROC [dbo].[Mostrar_creditoporpagar]
AS
    SELECT *
    FROM   CreditoPorPagar

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_descripcion_produco_sin_repetir]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_descripcion_produco_sin_repetir] @buscar VARCHAR(50)
AS
  BEGIN
      SELECT TOP 10 Descripcion
      FROM   Producto
      WHERE  Descripcion LIKE '%' + @buscar + '%'
  END

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_empleados]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_empleados]
AS
    SELECT c.idEmpleado,
           c.idPersona,
           e.idHorario,
           p.nombre       AS Nombre,
           p.apellido     AS Apellido,
           cc.Correo,
           p.fechaNacimiento,
           d.idDireccion,
           d.Descripcion  AS Direccion,
           do.idDocumento,
           do.numeracion  AS Documento,
           do.Tipo        AS TipoDocumento,
           t.idTelefono,
           t.numero       AS Telefono,
           tt.idTipoTelefono,
           tt.descripcion AS TipoTelefono,
           e.Entrada,
           e.Salida,
           e.TipoHorario  AS idTipoHorario,
           th.Descripcion AS TipoHorario,
           c.CuentaBanco,
           c.Departamento,
           c.Banco,
           c.Icono,
           c.Estado
    FROM   dbo.Empleados AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
           INNER JOIN TipoTelefono AS tt
                   ON t.idTipoTelefono = tt.idTipoTelefono
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Documento AS do
                   ON do.idDocumento = p.idDocumento
           INNER JOIN Horario AS e
                   ON e.idHorario = c.idHorario
           INNER JOIN TipoHorario AS th
                   ON th.idTipoHorario = e.TipoHorario
			inner join Correos as cc
			on p.idCorreo = cc.idCorreo
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_facturas_en_efectivo_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_facturas_en_efectivo_por_turno] @idcaja INT,
                                                         @fi     DATETIME,
                                                         @ff     DATETIME
AS
    SELECT Sum(Efectivo)
    FROM   facturas
    WHERE  ( fecha_factura >= @fi
             AND fecha_factura <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_facturas_en_espera_con_fecha_y_monto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_facturas_en_espera_con_fecha_y_monto]
AS
    SELECT idFactura,
           Comprobante as NumFactura,
           fecha_factura AS Fecha,
           Id_caja,
           ACCION
    FROM   facturas
    WHERE  Estado = 'EN ESPERA'
           AND ACCION <> 'COTIZACION'
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_formato_ticket]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_formato_ticket]
AS
    SELECT EMPRESA.Logo,
           Empresa.Nombre_Empresa,
           Ticket.*
    FROM   Ticket
           INNER JOIN EMPRESA
                   ON EMPRESA.Id_empresa = Ticket.Id_Empresa

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_gastos_por_turnos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_gastos_por_turnos] @idcaja INT,
                                              @fi     AS DATETIME,
                                              @ff     AS DATETIME
AS
    SELECT dbo.Gastos_varios.Id_gasto,
           dbo.Gastos_varios.Fecha,
           dbo.Conceptos.Descripcion Concepto,
           dbo.Gastos_varios.Descripcion,
           dbo.Gastos_varios.Importe
    FROM   dbo.Conceptos
           INNER JOIN dbo.Gastos_varios
                   ON dbo.Conceptos.Id_concepto = dbo.Gastos_varios.Id_concepto
    WHERE  Gastos_varios.Id_caja = @idcaja
           AND ( Fecha >= @fi
                 AND Fecha <= @ff )

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_id_compra_por_id_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Mostrar_id_compra_por_id_caja] @Id_caja INT
AS
    SELECT Max(idCompra)
    FROM   compras
    WHERE  Id_caja = @Id_caja
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_id_cotizacion_por_id_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_id_cotizacion_por_id_caja] @Id_caja INT
AS
    SELECT Max(idcotizacion)
    FROM   Cotizacion
    WHERE  Id_caja = @Id_caja

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_id_cotizacion_por_id_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_id_cotizacion_por_id_cotizacion] @Id_caja INT
AS
    SELECT Max(idcotizacion)
    FROM   Cotizacion
    WHERE  Id_caja = @Id_caja

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_id_factura_por_id_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_id_factura_por_id_caja] @Id_caja INT
AS
    SELECT Max(idFactura)
    FROM   facturas
    WHERE  Id_caja = @Id_caja

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_impresoras_por_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_impresoras_por_caja] @Serial AS VARCHAR(max)
AS
    SELECT Impresora_Ticket
    FROM   Caja
    WHERE  Serial_PC = @Serial

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_ingresos_por_turnos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_ingresos_por_turnos] @idcaja INT,
                                                @fi     AS DATETIME,
                                                @ff     AS DATETIME
AS
    SELECT Id_ingreso,
           Fecha,
           Descripcion,
           Importe
    FROM   Ingresos_varios
    WHERE  Id_caja = @idcaja
           AND ( Fecha >= @fi
                 AND Fecha <= @ff )

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_inicio_de_sesion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_inicio_de_sesion] @id_serial_pc AS VARCHAR(max)
AS
    SELECT Inicios_de_sesion_por_caja.Id_usuario,
           Persona.nombre
    FROM   Inicios_de_sesion_por_caja
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = Inicios_de_sesion_por_caja.Id_usuario
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
    WHERE  Id_serial_Pc = @id_serial_pc

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_inventarios_bajo_minimo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_inventarios_bajo_minimo]
AS
    SELECT p.Codigo,
           p.Descripcion,
           p.PrecioCompra          AS [Precio_de_Compra],
           CP.Descripcion AS Categoria,
           p.Stock,
           d.StockMinimo              AS [Stock_Minimo],
           CP.Descripcion,
           EMPRESA.Nombre_Empresa,
           EMPRESA.Logo
    FROM   dbo.Producto as p
	inner join dbo.DetalleProducto as d
	on p.idProducto = d.idProducto
           CROSS JOIN EMPRESA
          inner join CategoriaProductos as CP
	on p.idCategoria = cp.idCategoria
    WHERE  p.Stock <= d.StockMinimo

GO
/****** Object:  StoredProcedure [dbo].[MOSTRAR_Inventarios_bajo_minimo_COUNT]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[MOSTRAR_Inventarios_bajo_minimo_COUNT]
AS
select  count(idProducto ) from Producto 
inner join DetalleProductos on Producto.idProducto = DetalleProductos.idProducto
				where Stock <= DetalleProductos.Stock_minimo 

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_inventarios_todos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_inventarios_todos] @letra VARCHAR(50)
AS
    SELECT p.Codigo,
           p.Descripcion,
           p.PrecioCompra                 AS Costo,
           lp.Precio_1                    AS[Precio_Venta],
           p.Stock,
           1                 AS [Stock_Minimo],
           CP.Descripcion AS Categoria,
           ROUND(p.PrecioCompra * Stock,50)         AS Importe,
           E.Nombre_Empresa,
           E.Logo
    FROM   Producto AS p
           INNER JOIN ListaPrecios AS lp
                   ON p.idPrecios = lp.idPrecios
           INNER JOIN CategoriaProductos CP
                   ON p.idCategoria = CP.idCategoria
           CROSS JOIN EMPRESA AS E
    WHERE  p.Descripcion + p.Codigo LIKE '%' + @letra + '%' 
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_mayores_gastos_por_concepto_por_anio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_mayores_gastos_por_concepto_por_anio] @anio AS INTEGER
AS
    SELECT TOP 5 CONCEPTOS.Descripcion,
                 CONVERT(VARCHAR(50), Sum(Importe))
    FROM   GASTOSVARIOS
           INNER JOIN CONCEPTOS
                   ON CONCEPTOS.Id_concepto = GASTOSVARIOS.Id_concepto
    WHERE  GASTOSVARIOS.TIPO = 'SALIDA'
           AND Datepart (year, Fecha_del_Gasto) = @anio
    GROUP  BY CONCEPTOS.Descripcion
    ORDER  BY Sum(Importe) DESC 
GO
/****** Object:  StoredProcedure [dbo].[mostrar_mayores_GASTOS_POR_CONCEPTO_por_mes_de_anio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[mostrar_mayores_GASTOS_POR_CONCEPTO_por_mes_de_anio]
@mes as varchar(50),
@anio as integer
as

SELECT    top 5 CONCEPTOS.Descripcion  , convert(varchar(50),SUM(Importe))    FROM GASTOSVARIOS INNER JOIN CONCEPTOS ON CONCEPTOS.Id_concepto =GASTOSVARIOS.Id_concepto 
WHERE GASTOSVARIOS.TIPO ='SALIDA' and datename(month,Fecha_del_Gasto) =@mes and DATEPART (year,Fecha_del_Gasto) =@anio
GROUP BY CONCEPTOS.Descripcion 
Order by SUM(Importe) desc




GO
/****** Object:  StoredProcedure [dbo].[Mostrar_movimientos_de_caja_por_serial]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_movimientos_de_caja_por_serial] @serial VARCHAR(max)
AS
    SELECT USUARIO2.Login,
           Persona.nombre
    FROM   MOVIMIENTOCAJACIERRE
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = MOVIMIENTOCAJACIERRE.Id_usuario
           INNER JOIN Caja
                   ON Caja.Id_Caja = MOVIMIENTOCAJACIERRE.Id_caja
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
    WHERE  Caja.Serial_PC = @serial
           AND MOVIMIENTOCAJACIERRE.Estado = 'CAJA APERTURADA'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_movimientos_de_caja_por_serial_y_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_movimientos_de_caja_por_serial_y_usuario] @serial    VARCHAR(50),
                                                                     @idusuario INT
AS
    SELECT USUARIO2.Login,
           Persona.nombre
    FROM   MOVIMIENTOCAJACIERRE
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = MOVIMIENTOCAJACIERRE.Id_usuario
           INNER JOIN Caja
                   ON Caja.Id_Caja = MOVIMIENTOCAJACIERRE.Id_caja
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
    WHERE  Caja.Serial_PC = @serial
           AND MOVIMIENTOCAJACIERRE.Estado = 'CAJA APERTURADA'
           AND MOVIMIENTOCAJACIERRE.Id_usuario = @idusuario
           AND USUARIO2.Estado = 'ACTIVO'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_movimientos_de_kardex]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_movimientos_de_kardex] @idProducto INT
AS
    SELECT KARDEX.Fecha,
           Producto.Descripcion,
           KARDEX.Motivo                                               AS Movimiento,
           KARDEX.Cantidad,
           KARDEX.Tipo,
           KARDEX.Cantidad,
           KARDEX.Hay                                                  AS Hay,
           Persona.nombre                                              AS Cajero,
           CategoriaProductos.Descripcion as Categoria,
           KARDEX.Costo_unt,
           KARDEX.Total,
                      CategoriaProductos.Descripcion,
           EMPRESA.Nombre_Empresa,
           EMPRESA.Logo,
           Producto.Stock,
           CONVERT(NUMERIC(18, 2), Producto.Stock * KARDEX.Costo_unt) AS TotalInfacturario
    FROM   dbo.KARDEX
           INNER JOIN Producto
                   ON Producto.idProducto = KARDEX.Id_producto
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = KARDEX.Id_usuario
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
           CROSS JOIN EMPRESA
           INNER JOIN CategoriaProductos
                   ON Producto.idCategoria = CategoriaProductos.idCategoria
    WHERE  Producto.idProducto = @idProducto
    ORDER  BY KARDEX.Id_kardex DESC

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_notas_por_alumno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_notas_por_alumno] @Id_alumno INT
AS
    SELECT dbo.NOTAS.*,
           dbo.Alumnos.Nombres + ' '
           + dbo.Alumnos.Apellido_Paterno + ' '
           + Apellido_Materno,
           dbo.Alumnos.Nombres,
           dbo.Alumnos.Codigo
    FROM   NOTAS
           INNER JOIN Alumnos
                   ON Alumnos.idalumno = NOTAS.Id_alumno
    WHERE  NOTAS.Id_alumno = @Id_alumno
    ORDER  BY NOTAS.Id_notas DESC

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_agregados_a_compra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_productos_agregados_a_compra] @idCompra AS INT
AS
    SELECT detalle_compra . Codigo,
           ( detalle_compra .Descripcion )                           AS Producto,
           dbo.detalle_compra.cantidad                  AS Cantidad,
           dbo.detalle_compra.preciounitario                         AS PrecioUnidad,
           CONVERT(NUMERIC(18, 2), dbo.detalle_compra.Total_a_pagar) AS Importe,
           detalle_compra .Id_producto,
           DBO.detalle_compra.iddetalle_compra,
           dbo.compras.Estado,
           detalle_compra .Stock,
           dbo.detalle_compra.cantidad,
           compras.idProveedor,
           detalle_compra .Stock,
           detalle_compra .Stock,
           Se_vende_a,
           detalle_compra.idCompra,
		   detalle_compra.Descuento,
		   		   detalle_compra.itbis_calculo as Itbis
    FROM   dbo.detalle_compra
           INNER JOIN compras
                   ON dbo.detalle_compra.idCompra = compras.idCompra
    WHERE  dbo.detalle_compra.idCompra = @idCompra
           AND detalle_compra.cantidad > 0
    ORDER  BY detalle_compra.iddetalle_compra DESC
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_agregados_a_compras_en_espera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_productos_agregados_a_compras_en_espera] @idCompra INT
AS
    SELECT dbo.detalle_compra.Descripcion       AS Producto,
           dbo.detalle_compra.cantidad AS Cantidad,
           dbo.detalle_compra.preciounitario    AS PrecioUnidad,
           dbo.detalle_compra.Total_a_pagar     AS Importe,
           dbo.compras.ACCION
    FROM   dbo.compras
           INNER JOIN dbo.detalle_compra
                   ON dbo.compras.idCompra = dbo.detalle_compra.idCompra
    WHERE  detalle_compra.idCompra = @idCompra
           AND detalle_compra.cantidad > 0
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_agregados_a_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_productos_agregados_a_cotizacion] @idcotizacion AS INT
AS
    SELECT detalle_cotizacion . Codigo,
           ( detalle_cotizacion .Descripcion )                           AS Producto,
           dbo.detalle_cotizacion.Cantidad_mostrada                      AS Cantidad,
           dbo.detalle_cotizacion.preciounitario                         AS PrecioUnidad,
           CONVERT(NUMERIC(18, 2), dbo.detalle_cotizacion.Total_a_pagar) AS Importe,
           detalle_cotizacion .Id_producto,
           DBO.detalle_cotizacion.iddetalle_cotizacion,
           dbo.Cotizacion.Estado,
           detalle_cotizacion .Stock,
           dbo.detalle_cotizacion.cantidad,
           Cotizacion.idclientev,
           detalle_cotizacion .Stock,
           detalle_cotizacion .Stock,
           Usa_inventarios,
           Se_vende_a,
           detalle_cotizacion.idcotizacion
    FROM   dbo.detalle_cotizacion
           INNER JOIN Cotizacion
                   ON dbo.detalle_cotizacion.idcotizacion = Cotizacion.idcotizacion
    WHERE  dbo.detalle_cotizacion .idcotizacion = @idcotizacion
           AND detalle_cotizacion.cantidad > 0
    ORDER  BY detalle_cotizacion.iddetalle_cotizacion DESC

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_agregados_a_cotizaciones_en_espera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_productos_agregados_a_cotizaciones_en_espera] @idFactura INT
AS
    SELECT dbo.detalle_factura.Descripcion       AS Producto,
           dbo.detalle_factura.cantidad AS Cantidad,
           dbo.detalle_factura.preciounitario    AS [P Unit],
           dbo.detalle_factura.Total_a_pagar     AS Importe,
           facturas.ACCION
    FROM   dbo.facturas
           INNER JOIN dbo.detalle_factura
                   ON dbo.facturas.idFactura = dbo.detalle_factura.idFactura
    WHERE  detalle_factura.idFactura = @idFactura
           AND detalle_factura.cantidad > 0
           AND facturas.ACCION = 'COTIZACION'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_agregados_a_factura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_productos_agregados_a_factura] @idFactura AS INT
AS
    SELECT detalle_factura . Codigo,
           ( detalle_factura .Descripcion )                           AS Producto,
           dbo.detalle_factura.cantidad                               AS Cantidad,
           dbo.detalle_factura.preciounitario                         AS PrecioUnidad,
           CONVERT(NUMERIC(18, 2), dbo.detalle_factura.Total_a_pagar) AS Importe,
           detalle_factura .Id_producto,
           DBO.detalle_factura.iddetalle_factura,
           dbo.facturas.Estado,
           detalle_factura .Stock,
           dbo.detalle_factura.cantidad,
           facturas.idclientev,
           detalle_factura .Stock,
           detalle_factura .Stock,
           Se_vende_a,
           detalle_factura.idFactura,
		   detalle_factura.Descuento,
		   (SELECT CONVERT(DECIMAL(10,2), ROUND(detalle_factura.itbis, 2, 1)) Itbis) as itbis,
		   detalle_factura.itbis_calculo
    FROM   dbo.detalle_factura
           INNER JOIN facturas
                   ON dbo.detalle_factura.idFactura = facturas.idFactura
    WHERE  dbo.detalle_factura .idFactura = @idFactura
           AND detalle_factura.cantidad > 0
    ORDER  BY detalle_factura.iddetalle_factura DESC
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_agregados_a_facturas_en_espera]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_productos_agregados_a_facturas_en_espera] @idFactura INT
AS
    SELECT dbo.detalle_factura.Descripcion       AS Producto,
           dbo.detalle_factura.cantidad AS Cantidad,
           dbo.detalle_factura.preciounitario    AS PrecioUnidad,
           dbo.detalle_factura.Total_a_pagar     AS Importe,
           facturas.ACCION
    FROM   dbo.facturas
           INNER JOIN dbo.detalle_factura
                   ON dbo.facturas.idFactura = dbo.detalle_factura.idFactura
    WHERE  detalle_factura.idFactura = @idFactura
           AND detalle_factura.cantidad > 0
           AND facturas.ACCION <> 'COTIZACION'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_vencidos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_productos_vencidos]
AS
    SELECT p.idProducto,
           p.Codigo,
           p.Descripcion,
           d.FechaVencimiento                                          AS F_vencimiento,
           p.Stock,
           Datediff(day,  d.FechaVencimiento , CONVERT(DATE, Getdate ()))AS [Dias Vencidos]
    FROM   dbo.Producto as p
	inner join dbo.DetalleProducto as d
	on p.idProducto = d.idProducto
    WHERE   d.FechaVencimiento <> 'NO APLICA'
           AND  d.FechaVencimiento <= CONVERT(DATE, Getdate ())

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_productos_vencidos_en_menos_de_30_dias]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_productos_vencidos_en_menos_de_30_dias]
AS
    SELECT p.idProducto,
           p.Codigo,
           p.Descripcion,
           d.FechaVencimiento                                          AS F_vencimiento,
           p.Stock,
           Datediff(day,  d.FechaVencimiento , CONVERT(DATE, Getdate ()))AS [Dias Vencidos]
    FROM   dbo.Producto as p
	inner join dbo.DetalleProducto as d
	on p.idProducto = d.idProducto
    WHERE   d.FechaVencimiento <> 'NO APLICA'
           AND  d.FechaVencimiento <= CONVERT(DATE, Getdate ())
           AND ( Datediff(day, d.FechaVencimiento, CONVERT(DATE, Getdate ())) ) * ( -1 ) <= 30
    ORDER  BY ( Datediff(day, d.FechaVencimiento, CONVERT(DATE, Getdate ())) ) * ( -1 ) ASC

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_proveedores]
AS
    SELECT c.IdProveedor,
           c.idPersona,
           p.nombre              AS Nombre,
           p.apellido            AS Apellido,
           CC.Correo,
           p.fechaNacimiento,
           d.idDireccion,
           d.Descripcion         AS Direccion,
           do.idDocumento,
           do.numeracion         AS Documento,
           do.Tipo               AS TipoDocumento,
           t.idTelefono,
           t.numero              AS Telefono,
           tt.idTipoTelefono,
           tt.descripcion        AS TipoTelefono,
           c.IdentificadorFiscal AS [Identificador Fiscal],
           c.Estado,
           c.Saldo,
		   CC.idCorreo
    FROM   dbo.Proveedores AS c
           INNER JOIN dbo.Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
           INNER JOIN TipoTelefono AS tt
                   ON t.idTipoTelefono = tt.idTipoTelefono
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
           INNER JOIN Documento AS do
                   ON do.idDocumento = p.idDocumento
			inner join Correos as CC
			on p.idCorreo = CC.idCorreo
				   
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_stock_de_detalle_de_compras]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_stock_de_detalle_de_compras] @Id_producto INT
AS
    SELECT detalle_compra.Stock,
           detalle_compra.Descripcion
    FROM   compras
           INNER JOIN detalle_compra
                   ON detalle_compra.idCompra = compras.idCompra
    WHERE  compras.Estado = 'EN ESPERA'
           AND detalle_compra.Id_producto = @Id_producto
          
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_stock_de_detalle_de_cotizacion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_stock_de_detalle_de_cotizacion] @Id_producto INT
AS
    SELECT detalle_cotizacion.Stock,
           detalle_cotizacion.Descripcion
    FROM   Cotizacion
           INNER JOIN detalle_cotizacion
                   ON detalle_cotizacion.idcotizacion = Cotizacion.idcotizacion
    WHERE  Cotizacion.Estado = 'EN ESPERA'
           AND detalle_cotizacion.Id_producto = @Id_producto
           AND detalle_cotizacion.Usa_inventarios = 'SI'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_stock_de_detalle_de_facturas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrar_stock_de_detalle_de_facturas] @Id_producto INT
AS
    SELECT detalle_factura.Stock,
           detalle_factura.Descripcion
    FROM   facturas
           INNER JOIN detalle_factura
                   ON detalle_factura.idFactura = facturas.idFactura
    WHERE  facturas.Estado = 'EN ESPERA'
           AND detalle_factura.Id_producto = @Id_producto

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_ticket_impreso]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_ticket_impreso] @Id_factura      INT,
                                          @total_en_letras VARCHAR(50)
AS
    DECLARE @Descuento INT

    SET @Descuento = (SELECT Sum (Descuento)
                                  FROM   detalle_factura
                                         INNER JOIN facturas
                                                 ON facturas.idFactura = detalle_factura.idFactura
                                  WHERE  detalle_factura.idFactura = @Id_factura)

    

    SELECT Det.Descripcion                                    AS Producto,
           Det.cantidad                              AS Cant,
           Det.preciounitario                                 AS P_Unit,
           Det.Total_a_pagar                                  AS Importe,
           EMPRESA.Nombre_Empresa                             AS Empresa,
           EMPRESA.Logo,
           Ticket.*,
           Ven.fecha_factura                                  AS fecha,
           Ven.Monto_total,
           UsuN.nombre                                        AS Usuario,
           Ven.Pago_con,
           Ven.Vuelto,
           EMPRESA.Moneda,
           CliN.Nombre,
           Ven.Tipo_de_pago,
		   @Descuento as Descuento,
		   Descuento as Descuentos,
          -- @cantidad_de_productos                             AS Cantidad_de_productos,
           @total_en_letras                                   AS total_en_letras,
           Ven.Comprobante,
           Ven.Numero_de_doc,
		   Det.Itbis
    FROM   detalle_factura AS Det
           INNER JOIN facturas AS Ven
                   ON DET.idFactura = Ven.idFactura
           INNER JOIN clientes AS Cli
                   ON Ven.idclientev = Cli.idclientev
           INNER JOIN usuario2 AS Usu
                   ON Ven.Id_usuario = Usu.idUsuario
           INNER JOIN Empleados AS Emp
                   ON Usu.idEmpleado = Emp.idEmpleado
           INNER JOIN Persona AS CliN
                   ON Cli.idPersona = CliN.idPersona
           INNER JOIN Persona AS UsuN
                   ON Emp.idPersona = UsuN.idPersona
           CROSS JOIN EMPRESA
           CROSS JOIN Ticket
    WHERE  Det.idFactura = @Id_factura
           AND Ven.Monto_total > 0
    ORDER  BY Det.iddetalle_factura DESC 
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_tipo_de_documentos_para_insertar_estos_mismos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_tipo_de_documentos_para_insertar_estos_mismos]
AS
    SELECT dbo.Serializacion.Serie,
           dbo.Serializacion.Cantidad_de_numeros,
           dbo.Serializacion.numerofin,
           dbo.Serializacion.Id_serializacion,
           ( dbo.Serializacion.Serie + ' - '
             + dbo.Serializacion.Cantidad_de_numeros
             + dbo.Serializacion.numerofin ) AS serie_completa,
           Serializacion.tipodoc             AS COMPROBANTE,
           Por_defecto
    FROM   dbo.Serializacion
    WHERE  destino = 'facturaS'
            OR destino = 'OTROS'

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_tipos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_tipos] @buscar VARCHAR(50)
AS
  BEGIN
      SELECT idTipoTelefono,
             descripcion AS tipoTelefono
      FROM   tipoTelefono
      WHERE  descripcion LIKE '%' + @buscar + '%'
	  and (descripcion <> 'Telefono Empresarial' or descripcion<>'Celular Empresarial') 
  END

GO
/****** Object:  StoredProcedure [dbo].[Mostrar_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrar_usuario]
AS
    SELECT u.idUsuario,
           u.idEmpleado,
           e.idPersona,
           p.nombre          AS Nombre,
           p.apellido        AS Apellido,
           u.Login,
           u.Password,
           R.Rol,
           u.Nombre_de_icono AS NombreIcono,
           u.Icono,
           u.Estado,
            p.idCorreo,
		   C.Correo
    FROM   USUARIO2 AS u
           INNER JOIN Empleados AS e
                   ON u.idEmpleado = e.idEmpleado
           INNER JOIN Persona AS p
                   ON e.idPersona = p.idPersona
		   INNER JOIN Roles AS R
				ON u.idRol = R.idRol
				INNER JOIN correos as C
				on p.idCorreo = c.idCorreo
    WHERE  u.Estado = 'ACTIVO'

GO
/****** Object:  StoredProcedure [dbo].[Mostraralmacen]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostraralmacen]
AS
    SELECT a.idAlmacen,
		   a.idLocalizacion,
           a.Descripcion AS Almacen,
		   a.stock_minimo as StockMinimo,
		   l.Zona,
		   l.NoAnaquel as NoAnaquel,
		   l.Localizacion,
		   d.descripcion as Direccion
    FROM Almacen AS a 
	Inner join Localizacion as l
	on a.idLocalizacion = l.idLocalizacion
	Inner join Direccion as d
	on a.idDireccion = d.idDireccion
GO
/****** Object:  StoredProcedure [dbo].[MostraralmacenBuscar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[MostraralmacenBuscar]
@buscar as varchar(50)
AS
    SELECT a.idAlmacen,
		   a.idLocalizacion,
           a.Descripcion AS Almacen,
		   a.stock_minimo as StockMinimo,
		   l.Zona,
		   l.NoAnaquel as NoAnaquel,
		   l.Localizacion,
		   d.descripcion as Direccion
    FROM Almacen AS a 
	Inner join Localizacion as l
	on a.idLocalizacion = l.idLocalizacion
	Inner join Direccion as d
	on a.idDireccion = d.idDireccion
	where a.Descripcion Like '%' + @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[mostrarCategorias]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrarCategorias] 
AS
  BEGIN
      SELECT idCategoria,
             Descripcion AS Categoria
			 ,Departamento as Departamento
			 ,Impuestos.Impuesto,
			 Descuentos.Descuento
      FROM   CategoriaProductos
	  Inner join Impuestos on CategoriaProductos.idItbis = Impuestos.idImpuesto
	  Inner join Descuentos on CategoriaProductos.idDescuento = Descuentos.idDescuento
  END
GO
/****** Object:  StoredProcedure [dbo].[mostrarCategorias_parametros]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrarCategorias_parametros]
AS
  BEGIN
      SELECT idCategoria,
             Descripcion AS Categoria
			 ,Departamento as Departamento
      FROM   CategoriaProductos
  END
GO
/****** Object:  StoredProcedure [dbo].[mostrarCategorias2]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[mostrarCategorias2] @buscar VARCHAR(50)
AS
  BEGIN
      SELECT idCategoria,
             Descripcion AS Categoria
			 ,Departamento as Departamento
			 ,Impuestos.Impuesto,
			 Descuentos.Descuento
      FROM   CategoriaProductos
	  Inner join Impuestos on CategoriaProductos.idItbis = Impuestos.idImpuesto
	  Inner join Descuentos on CategoriaProductos.idDescuento = Descuentos.idDescuento
      WHERE  Descripcion + Departamento LIKE '%' + @buscar + '%'
  END
GO
/****** Object:  StoredProcedure [dbo].[mostrarClavesSat]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[mostrarClavesSat] @buscar VARCHAR(50)
AS
  BEGIN
      SELECT idClaveSat,
             Clave AS Clave
			 ,Nombre as Nombre
			 ,Descripcion as Descripción
      FROM   ClavesSat
      WHERE  Descripcion + Nombre LIKE '%' + @buscar + '%'
  END
GO
/****** Object:  StoredProcedure [dbo].[mostrarControlCobros]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrarControlCobros]
@numFact as int
AS
    SELECT
		F.NumFact
	,	F.idControlPago,
           F.Monto,
           F.Detalle,
           F.Fecha,
           F.idProveedor,
           F.idUsuario,
           F.idCaja,
           F.Comprobante,
           F.Efectivo,
           F.Tarjeta,
           F.TransferenciaBancaria
    FROM   FacturasExternas AS F 
    Inner join Proveedores as P
	on F.idProveedor = P.IdProveedor
	where F.NumFact = @NumFact
GO
/****** Object:  StoredProcedure [dbo].[Mostrarcontrolpagos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Mostrarcontrolpagos]
AS
    SELECT *
    FROM   ControlPago

GO
/****** Object:  StoredProcedure [dbo].[mostrarDescuento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[mostrarDescuento]
AS
  BEGIN
      SELECT idDescuento
			 ,Descuento
			 ,TipoDescuento as TipoDescuento
      FROM   Descuentos
  END
GO
/****** Object:  StoredProcedure [dbo].[Mostrardireccion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrardireccion]
AS
    SELECT d.idDireccion,
           d.Descripcion AS Destinatario,
           r.idRegion,
           r.descripcion AS Region,
           m.idMunicipio,
           m.descripcion AS Municipio,
           s.idSector,
           s.descripcion AS Sector,
           p.idProvincia,
           p.descripcion AS Provincia,
           c.idCalle,
           c.descripcion AS Calle
    FROM   Direccion AS d
           INNER JOIN Region AS r
                   ON d.idRegion = r.idRegion
           INNER JOIN Municipio AS m
                   ON m.idMunicipio = d.idMunicipio
           INNER JOIN Sector AS s
                   ON s.idSector = d.idSector
           INNER JOIN Provincia AS p
                   ON p.idProvincia = d.idProvincia
           INNER JOIN Calle AS c
                   ON c.idCalle = d.idCalle

GO
/****** Object:  StoredProcedure [dbo].[Mostrarempleadosvehiculos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarempleadosvehiculos]
AS
    SELECT e.idEmpleado,
           p.nombre as Nombre,
           e.Departamento,
           e.Estado
    FROM   Empleados AS e
           INNER JOIN Persona AS p
                   ON e.idPersona = p.idPersona
    WHERE  (Estado = 'ACTIVO' OR Estado <> 'PROCESANDO ENVIO')
           AND Departamento = 'Departamento de Envios'
		   

GO
/****** Object:  StoredProcedure [dbo].[MostrarempleadosvehiculosV]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[MostrarempleadosvehiculosV]
AS
    SELECT e.idEmpleado,
           p.nombre as Nombre,
           e.Departamento,
           e.Estado
    FROM   Empleados AS e
           INNER JOIN Persona AS p
                   ON e.idPersona = p.idPersona
    WHERE  (Estado = 'ACTIVO' OR Estado = 'PROCESANDO ENVIO')
           AND Departamento = 'Departamento de Envios'
		   

GO
/****** Object:  StoredProcedure [dbo].[mostrarEstadosCuentaCliente]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarEstadosCuentaCliente]
@idcliente int
as

SELECT        d.Descripcion, d.cantidad, 
d.preciounitario, v.Credito, v.Estado
FROM            dbo.detalle_factura as d INNER JOIN
                         dbo.facturas as v ON d.idFactura =v.idFactura

 where v.idclientev=@idcliente and v.Credito >0

GO
/****** Object:  StoredProcedure [dbo].[mostrarEstadosCuentaProveedor]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarEstadosCuentaProveedor]
@idProveedor int
as

SELECT        d.Descripcion, d.cantidad, 
d.preciounitario, v.TotalPagado as TotalCredito, v.Estado
FROM            dbo.detalle_compra as d INNER JOIN
                         dbo.compras as v ON d.idCompra = v.idCompra

 where v.idProveedor=@idProveedor and v.TotalPagado >0

GO
/****** Object:  StoredProcedure [dbo].[mostrarEstadosFacturas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrarEstadosFacturas] @idProveedor INT
AS
    SELECT F.idFactura,
           F.NumFact,
           F.NumPed,
           F.FechaPedido,
           F.FechaVencimiento,
           F.Total,
           F.Tipo AS TipoFactura,
		   F.Saldo as Saldo,
           F.idProveedor
    FROM   FacturasProveedores AS F
           INNER JOIN Proveedores AS P
                   ON F.idProveedor = P.IdProveedor
    WHERE  P.idProveedor = @idProveedor
           AND F.Total > 0 
GO
/****** Object:  StoredProcedure [dbo].[Mostrarfacturasgrafica]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarfacturasgrafica]
AS
    DECLARE @anio INT

    SET @anio = Datepart (YEAR, Getdate())

    SELECT ( Datename(MONTH, fecha_factura) + ' '
             + Datename(YEAR, fecha_factura ) ) AS fecha,
           Sum(Monto_total)                   AS Total
    FROM   facturas
    WHERE  Datepart(YEAR, fecha_factura) = @anio
    GROUP  BY Datename(MONTH, fecha_factura),
              Datename (YEAR, fecha_factura)

GO
/****** Object:  StoredProcedure [dbo].[Mostrarfacturasgraficafechas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarfacturasgraficafechas] @fi DATE,
                                               @ff DATE
AS
    SELECT ( Datename(MONTH, fecha_factura) + ' '
             + Datename(YEAR, fecha_factura ) ) AS fecha,
           Sum(Monto_total)                   AS Total
    FROM   facturas
    WHERE  CONVERT(DATE, fecha_factura) >= @fi
           AND CONVERT(DATE, fecha_factura) <= @ff
    GROUP  BY Datename(MONTH, fecha_factura),
              Datename (YEAR, fecha_factura)

GO
/****** Object:  StoredProcedure [dbo].[mostrarImpuestoGeneral]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrarImpuestoGeneral]
AS
  BEGIN
      SELECT idImpuesto,
             Nombre AS nombre,
			 Impuesto as Itbis,
			 Tipo as Tipo,
			 Estado
      FROM   Impuestos
	  where Estado = 'General'
	  AND Tipo <> 'Impuesto Categoria'
  END
GO
/****** Object:  StoredProcedure [dbo].[mostrarImpuestoGeneralProductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrarImpuestoGeneralProductos]
AS
      SELECT idImpuesto,
             Nombre AS nombre,
			 Impuesto as Itbis,
			 Tipo as Tipo,
			 Estado
      FROM   Impuestos
	  where Estado = 'ACTIVO'
	  AND Tipo <> 'Impuesto Categoria' AND Tipo = 'Impuesto Productos'
GO
/****** Object:  StoredProcedure [dbo].[mostrarImpuestos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrarImpuestos]
AS
  BEGIN
      SELECT idImpuesto,
             Nombre AS nombre,
			 Impuesto as Itbis,
			 Tipo as Tipo,
			 Estado
      FROM   Impuestos
	  where Estado = 'ACTIVO'
	  AND Tipo <> 'Impuesto Categoria'
  END
GO
/****** Object:  StoredProcedure [dbo].[Mostrarpedidoespecifico]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarpedidoespecifico] @idPedido AS INT
AS
    SELECT idPedido              AS NumPedido,
           idCliente             AS Cliente,
           idFactura             AS NumFactura,
           idEmpleado            AS Empleado,
           idVehiculo            AS Vehiculo,
           FechaEnvio            AS Fecha,
           Destinatario          AS NombreCliente,
           DireccionDestinatario AS Direccion,
           Estado                AS EstadoPedido
    FROM   Pedidos
    WHERE  idPedido = @idPedido

GO
/****** Object:  StoredProcedure [dbo].[Mostrarpedidosencurso]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarpedidosencurso]
AS
    SELECT idPedido              AS NumPedido,
           idCliente             AS Cliente,
           idFactura             AS NumFactura,
           idEmpleado            AS Empleado,
           idVehiculo            AS Vehiculo,
           FechaEnvio            AS Fecha,
           Destinatario          AS NombreCliente,
           DireccionDestinatario AS Direccion,
           Estado                AS EstadoPedido
    FROM   Pedidos
    WHERE  Estado <> 'FINALIZADO'

GO
/****** Object:  StoredProcedure [dbo].[MostrarPermisosPorUsuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MostrarPermisosPorUsuario]
@idusuario int
as 
select 
r.Rol
from USUARIO2 as u
Inner join Roles as r
on u.idRol = r.idRol
where u.idUsuario = @idusuario and u.Estado ='ACTIVO'







GO
/****** Object:  StoredProcedure [dbo].[Mostrarpmasvendidos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarpmasvendidos]
AS
    SELECT TOP 5 Sum(detalle_factura.cantidad) AS Cantidad,
                 Producto.Descripcion
    FROM   detalle_factura
           INNER JOIN Producto
                   ON Producto.idProducto = detalle_factura.Id_producto
    GROUP  BY Producto.Descripcion

GO
/****** Object:  StoredProcedure [dbo].[mostrarPreciosCompra]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrarPreciosCompra]
@idProducto as varchar(50)
AS
      SELECT pr.idProveedor,
             pr.idProducto,
			 Pe.nombre as Nombre,
			 pr.PrecioCompra,
			 pr.FechaCompra as Fecha
      FROM   PreciosCompraProveedor as pr
	  inner join Proveedores as p
	  on pr.IdProveedor = p.IdProveedor
	  inner join Persona as Pe
	  on p.idPersona = Pe.idPersona
	  where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[Mostrarprodutos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mostrarprodutos]
AS
    SELECT p.idProducto,
           p.idCategoria,
           p.idPrecios,
           p.Codigo AS Codigo,
           p.Descripcion,
           p.Stock,
           p.PrecioCompra,
           p.idImpuesto,
           p.idDescuento,
		   cp.Descripcion as Categoria,
		   cp.Departamento as DepartamentoCat,
		   lp.idMayoreo,
		   lp.Precio_1 as PrecioVenta,
		   lp.Precio_2,
		   lp.Precio_3,
		   lp.Precio_4,
		   vm.Unidades_1,
		   vm.Unidades_2,
		   vm.Unidades_3,
		   vm.Unidades_4,
		   i.Impuesto as Itbis,
		   d.Descuento as Descuento,
		   UPP.Descripcion AS UnidadCompra,
		   UPP2.Descripcion as UnidadVenta,
		   UP.idUnidadCompra,
		   UP.idUnidadVenta
    FROM   Producto AS p 
	Inner join CategoriaProductos as cp
	on p.idCategoria = cp.idCategoria
	Inner join ListaPrecios as lp
	on p.idPrecios = lp.idPrecios
	Inner joiN VentasMayoreo AS vm
	on lp.idMayoreo = vm.idMayoreo
	inner join Impuestos as i
	on p.idImpuesto = i.idImpuesto
	inner join Descuentos as d
	on p.idDescuento = d.idDescuento
	inner join UnidadesVSProducto as UP
	on UP.idProducto = p.idProducto
	inner join UnidadesProductos as UPP
	on UP.idUnidadCompra = UPP.idUnidad
	inner join UnidadesProductos as UPP2
	ON UP.idUnidadVenta = UPP2.idUnidad
	
GO
/****** Object:  StoredProcedure [dbo].[MostrarprodutosDetalle]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[MostrarprodutosDetalle]
@idProducto as int
AS
    SELECT 
	DP.idDetalleProducto,
	DP.idProducto,
    DP.idProveedor,
	PE.nombre,
	DP.Localizacion,
	DP.StockMinimo,
	DP.UsoInterno,
	DP.Granel,
	DP.Peso,
	DP.FechaVencimiento 
	FROM   DetalleProducto AS DP
	INNER JOIN Producto as P
	on DP.idProducto = p.idProducto
	inner join Proveedores as PR
	on DP.idProveedor = PR.IdProveedor
	Inner join Persona as PE
	on PR.idPersona = PE.idPersona
	WHERE dp.idProducto = @idProducto
	
	
GO
/****** Object:  StoredProcedure [dbo].[Mostrarpuertos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarpuertos] @idcaja INT
AS
    SELECT PuertoBalanza,
           EstadoBalanza
    FROM   Caja
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[mostrarRol]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrarRol]
as
select idRol, Rol from Roles
GO
/****** Object:  StoredProcedure [dbo].[Mostrartemacaja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrartemacaja] @idcaja INT
AS
    SELECT Tema
    FROM   Caja
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Mostrartipovehiculo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrartipovehiculo] @buscar VARCHAR(50)
AS
    SELECT idTipoVehiculo,
           descripcion AS TipoVehiculo,
           capacidad   AS Capacidad
    FROM   TipoVehiculo
    WHERE  descripcion LIKE '%' + @buscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[mostrarUnidades]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrarUnidades]
AS
  BEGIN
      SELECT idUnidad
			 ,idClaveSat
			 ,Descripcion as Descripción
      FROM   UnidadesProductos

  END
GO
/****** Object:  StoredProcedure [dbo].[mostrarUnidades2]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[mostrarUnidades2]
@letra as varchar(50)
AS
  BEGIN
      SELECT idUnidad
			 ,idClaveSat
			 ,Descripcion as Descripción
      FROM   UnidadesProductos
	  where Descripcion Like '%' + @letra + '%'
  END
GO
/****** Object:  StoredProcedure [dbo].[Mostrarvehiculos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Mostrarvehiculos]
AS
    SELECT v.idVehiculo,
           v.idTipoVehiculo,
           tv.descripcion AS Descripcion,
           v.NPlaca,
           v.Transmision,
           v.Color,
           v.Marca,
           v.Modelo,
           v.Ano,
           tv.capacidad   AS Capacidad,
           v.Icono,
           v.Estado
    FROM   Vehiculos AS v
           INNER JOIN TipoVehiculo AS tv
                   ON v.idTipoVehiculo = tv.idTipoVehiculo
    WHERE  Estado = 'ACTIVO'
            OR Estado = 'PROCESANDO ENVIO'

GO
/****** Object:  StoredProcedure [dbo].[Mostrarvehiculosdisponibles]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Mostrarvehiculosdisponibles]
AS
    SELECT idVehiculo,
		   Modelo,
           Estado
    FROM   Vehiculos
    WHERE  Estado = 'ACTIVO' or Estado <> 'PROCESANDO ENVIO'

GO
/****** Object:  StoredProcedure [dbo].[Mostrarvehiculosv]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Mostrarvehiculosv]
AS
    SELECT v.idVehiculo,
           v.idTipoVehiculo,
           tv.descripcion AS Descripcion,
           v.NPlaca,
           tv.capacidad   AS Capacidad,
           v.Estado
    FROM   Vehiculos AS v
           INNER JOIN TipoVehiculo AS tv
                   ON v.idTipoVehiculo = tv.idTipoVehiculo
    WHERE  (Estado = 'ACTIVO' OR Estado = 'PROCESANDO ENVIO')
            

GO
/****** Object:  StoredProcedure [dbo].[obtenerAccesoUsuarios]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerAccesoUsuarios]
@idUsuario as int
AS
	Select u.idUsuario,u.idRol,r.Rol, m.Modulo, o.Operacion
	FROM USUARIO2 AS u
	INNER JOIN Roles AS r
	ON u.idRol = r.idRol
	INNER JOIN rolVSoperacion AS rs
	ON r.idRol = rs.idRol
	INNER JOIN Operaciones AS o
	ON rs.idOperacion = o.idIOperacion
	INNER JOIN Modulo AS m
	ON o.idModulo = m.idModulo
	WHERE u.idUsuario = @idUsuario
GO
/****** Object:  StoredProcedure [dbo].[obtenerAccesoUsuariosLogin]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerAccesoUsuariosLogin]
@Login as varchar(50)
AS
	Select u.idUsuario,u.idRol,r.Rol, m.Modulo, o.Operacion, u.Icono
	FROM USUARIO2 AS u
	INNER JOIN Roles AS r
	ON u.idRol = r.idRol
	INNER JOIN rolVSoperacion AS rs
	ON r.idRol = rs.idRol
	INNER JOIN Operaciones AS o
	ON rs.idOperacion = o.idIOperacion
	INNER JOIN Modulo AS m
	ON o.idModulo = m.idModulo
	WHERE u.Login = @Login
GO
/****** Object:  StoredProcedure [dbo].[Obtenercalle]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenercalle]
AS
    SELECT idCalle
    FROM   Calle
    WHERE  idCalle = (SELECT Max(idCalle)
                      FROM   Calle)

GO
/****** Object:  StoredProcedure [dbo].[Obtenerdatosempresa]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Obtenerdatosempresa]
AS
    SELECT E.*,
           D.idDireccion as idDireccionE,
           D.idCalle,
           D.idMunicipio,
           D.idCiudad AS idCiudadE,
           C.descripcion  AS Calle,
           M.descripcion  AS Municipio,
           CC.Ciudad AS CiudadE,
		   DF.*,
		   CO.Correo,
		   T.numero as Telefono,
		   TC.numero AS Celular
    FROM   EMPRESA AS E
           INNER JOIN Direccion AS D
                   ON E.idDireccion = D.idDireccion
           INNER JOIN Calle AS C
                   ON D.idCalle = C.idCalle
           INNER JOIN Municipio AS M
                   ON D.idMunicipio = M.idMunicipio
           INNER JOIN Ciudad AS CC
                   ON D.idCiudad = CC.idCiudad 
		   INNER JOIN DatosFiscales as DF
		   on E.idDatosFiscales = DF.idDatosFiscales
		   INNER JOIN Correos AS CO
		   on E.idCorreo = CO.idCorreo
		   inner join Telefono as T 
		   on E.idTelefono = T.idTelefono
		   inner join Telefono as TC
		   on E.idCelular = TC.idTelefono
		   inner join TipoTelefono as TT
		   on T.idTipoTelefono = TT.idTipoTelefono 
		   WHERE TT.descripcion = 'Telefono Empresarial' or TT.descripcion = 'Celular Empresarial'
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDetalleVenta]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerDetalleVenta]
@idProducto as int,
@idFactura as int
as
	Select df.iddetalle_factura from detalle_factura  as df 
	inner join facturas as f on df.idFactura = f.idFactura
	where df.idFactura = @idFactura and df.Id_producto =@idProducto
GO
/****** Object:  StoredProcedure [dbo].[Obtenerdocumento]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerdocumento]
AS
    SELECT idDocumento
    FROM   Documento
    WHERE  idDocumento = (SELECT Max(idDocumento)
                          FROM   Documento)

GO
/****** Object:  StoredProcedure [dbo].[Obtenerdocumentoid]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerdocumentoid] @documento AS VARCHAR(50)
AS
    SELECT idDocumento
    FROM   Documento
    WHERE  numeracion = @documento

GO
/****** Object:  StoredProcedure [dbo].[ObtenerFoto]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ObtenerFoto]
as
Select Logo from EMPRESA
GO
/****** Object:  StoredProcedure [dbo].[Obtenerhorario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerhorario]
AS
    SELECT idHorario
    FROM   Horario
    WHERE  idHorario = (SELECT Max(idHorario)
                        FROM   Horario)

GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaPrecioMayorPorProductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerListaPrecioMayorPorProductos]
@idProducto as int
as
	Select LP.Unidades_1 as Unidad1,LP.Unidades_2 Unidad2,LP.Unidades_3 Unidad3,LP.Unidades_4 as Unidad4 from VentasMayoreo as LP
	inner join ListaPrecios as L on LP.idMayoreo = L.idMayoreo
	inner join Producto as P on L.idPrecios = P.idPrecios
	where P.idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaPrecioPorProductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerListaPrecioPorProductos]
@idProducto as int
as
	Select LP.Precio_1 as Precio1,LP.Precio_2 as Precio2,LP.Precio_3 as Precio3,LP.Precio_4 as Precio4 from ListaPrecios as LP
	inner join Producto as p on LP.idPrecios = p.idPrecios where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaPrecioPorProductos1]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerListaPrecioPorProductos1]
@idProducto as int
as
	Select LP.idPrecios, LP.Precio_1 as Precio1 from ListaPrecios as LP
	inner join Producto as p on LP.idPrecios = p.idPrecios where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaPrecioPorProductos2]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerListaPrecioPorProductos2]
@idProducto as int
as
	Select LP.idPrecios, LP.Precio_1 as Precio2 from ListaPrecios as LP
	inner join Producto as p on LP.idPrecios = p.idPrecios where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaPrecioPorProductos3]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerListaPrecioPorProductos3]
@idProducto as int
as
	Select LP.idPrecios, LP.Precio_1 as Precio3 from ListaPrecios as LP
	inner join Producto as p on LP.idPrecios = p.idPrecios where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaPrecioPorProductos4]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerListaPrecioPorProductos4]
@idProducto as int
as
	Select LP.idPrecios, LP.Precio_1 as Precio4 from ListaPrecios as LP
	inner join Producto as p on LP.idPrecios = p.idPrecios where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaProductos]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerListaProductos]
@idFactura as int
AS
Select a.idProducto, p.Descripcion as Producto from aux_Productos  as a 
inner join Producto as p on a.idProducto = p.idProducto
where a.idFactura = @idFactura
GO
/****** Object:  StoredProcedure [dbo].[Obtenermunicipio]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenermunicipio]
AS
    SELECT idMunicipio
    FROM   Municipio
    WHERE  idMunicipio = (SELECT Max(idMunicipio)
                          FROM   Municipio)

GO
/****** Object:  StoredProcedure [dbo].[Obtenerpersona]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerpersona]
AS
    SELECT idPersona
    FROM   Persona
    WHERE  idPersona = (SELECT Max(idPersona)
                        FROM   Persona)

GO
/****** Object:  StoredProcedure [dbo].[Obtenerpersonaid]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerpersonaid] @nombre AS VARCHAR(50)
AS
    SELECT idPersona
    FROM   Persona
    WHERE  nombre = @nombre

GO
/****** Object:  StoredProcedure [dbo].[Obtenerprovincia]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerprovincia]
AS
    SELECT idProvincia
    FROM   Provincia
    WHERE  idProvincia = (SELECT Max(idProvincia)
                          FROM   Provincia)

GO
/****** Object:  StoredProcedure [dbo].[Obtenerregion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenerregion]
AS
    SELECT idRegion
    FROM   Region
    WHERE  idRegion = (SELECT Max(idRegion)
                       FROM   Region)

GO
/****** Object:  StoredProcedure [dbo].[Obtenersector]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenersector]
AS
    SELECT idSector
    FROM   Sector
    WHERE  idSector = (SELECT Max(idSector)
                       FROM   Sector)

GO
/****** Object:  StoredProcedure [dbo].[Obtenertelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenertelefono]
AS
    SELECT idTelefono
    FROM   Telefono
    WHERE  idTelefono = (SELECT Max(idTelefono)
                         FROM   Telefono)

GO
/****** Object:  StoredProcedure [dbo].[Obtenertelefonoid]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenertelefonoid] @telefono AS VARCHAR(50)
AS
    SELECT idTelefono
    FROM   Telefono
    WHERE  numero = @telefono

GO
/****** Object:  StoredProcedure [dbo].[Obtenertipohorarip]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenertipohorarip]
AS
    SELECT idTipoHorario
    FROM   TipoHorario
    WHERE  idTipoHorario = (SELECT Max(idTipoHorario)
                            FROM   TipoHorario)

GO
/****** Object:  StoredProcedure [dbo].[Obtenertipotelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenertipotelefono]
AS
    SELECT idTipoTelefono
    FROM   Tipotelefono
    WHERE  idTipoTelefono = (SELECT Max(idTipoTelefono)
                             FROM   Tipotelefono)

GO
/****** Object:  StoredProcedure [dbo].[Obtenertipotelefonoid]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Obtenertipotelefonoid] @TipoTelefono AS VARCHAR(50)
AS
    SELECT idTipoTelefono
    FROM   TipoTelefono
    WHERE  descripcion = @TipoTelefono

GO
/****** Object:  StoredProcedure [dbo].[ObtenerUltimoCorreo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ObtenerUltimoCorreo]
as
Select idCorreo from Correos where idCorreo=(select max(idCorreo) from Correos)
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUltimoDetalleFactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ObtenerUltimoDetalleFactura]
as
	SELECT iddetalle_factura FROM detalle_factura WHERE iddetalle_factura=(SELECT Max(iddetalle_factura) FROM detalle_factura)
GO
/****** Object:  StoredProcedure [dbo].[obtenerUsuariosRestaurar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerUsuariosRestaurar]
AS
	Select u.idUsuario,u.Login
	FROM USUARIO2 AS u
	
GO
/****** Object:  StoredProcedure [dbo].[Procesarpedido]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Procesarpedido] @idPedido INT
AS
    UPDATE Pedidos
    SET    Estado = 'FINALIZADO'
    WHERE  idPedido = @idPedido

GO
/****** Object:  StoredProcedure [dbo].[RegistrarFactura]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[RegistrarFactura] 
@NumPed AS VARCHAR(MAX),
@NumFact AS VARCHAR(MAX),
@FechaV AS date,
@FechaP AS date,
@Tipo AS VARCHAR(MAX),
@Total AS numeric(18,2),
@Saldo AS numeric(18,2)
,@idProveedor as int
AS
    IF EXISTS(SELECT NumFact
              FROM   FacturasProveedores
              WHERE  NumFact = @NumFact)
      RAISERROR('Esta Numero de Factura ya existe',16,1 )
    ELSE
      INSERT INTO FacturasProveedores
      VALUES      ( @NumFact, @NumPed, @FechaP, @FechaV, @Total,@Tipo,@Saldo, @idProveedor)
GO
/****** Object:  StoredProcedure [dbo].[Reportecuestasporcobrar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportecuestasporcobrar]
AS
    SELECT p.nombre,
           t.numero,
           Saldo
    FROM   clientes AS c
           INNER JOIN Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
    WHERE  Saldo > 0

GO
/****** Object:  StoredProcedure [dbo].[Reportecuestasporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportecuestasporpagar]
AS
    SELECT p.nombre,
           t.numero,
           Saldo
    FROM   Proveedores AS pr
           INNER JOIN Persona AS p
                   ON pr.idPersona = p.idPersona
           INNER JOIN Telefono AS t
                   ON p.idTelefono = t.idTelefono
    WHERE  Saldo > 0

GO
/****** Object:  StoredProcedure [dbo].[Reporteganancias]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteganancias]
AS
    SELECT CONVERT(NUMERIC(18, 2), Sum(Ganancia))
    FROM   detalle_factura

GO
/****** Object:  StoredProcedure [dbo].[Reportegananciasfecha]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportegananciasfecha] @fi DATE,
                                          @ff DATE
AS
    SELECT CONVERT(NUMERIC(18, 2), Sum(Ganancia))
    FROM   detalle_factura
           INNER JOIN facturas
                   ON facturas.idFactura = detalle_factura.idFactura
    WHERE  CONVERT (DATE, fecha_factura) >= @fi
           AND CONVERT(DATE, fecha_factura) <= @ff

GO
/****** Object:  StoredProcedure [dbo].[Reportegastosaniocombo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportegastosaniocombo]
AS
    SET Nocount ON;

    SELECT DISTINCT Datepart (year, Fecha) AS anio
    FROM   Gastos_varios

GO
/****** Object:  StoredProcedure [dbo].[Reportegastosaniografica]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportegastosaniografica] @anio AS INT
AS
    SELECT TOP 5 Conceptos.Descripcion,
                 Sum(Gastos_varios.Importe) AS Monto
    FROM   Gastos_varios
           INNER JOIN Conceptos
                   ON Conceptos.Id_concepto = Gastos_varios.Id_concepto
    WHERE  Datepart (YEAR, Fecha) = @anio
    GROUP  BY Conceptos.Descripcion
    ORDER  BY Sum (Importe) DESC

GO
/****** Object:  StoredProcedure [dbo].[Reportegastosaniomesgrafica]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportegastosaniomesgrafica] @anio AS INT,
                                                @mes  AS VARCHAR(50)
AS
    SELECT TOP 5 Conceptos.Descripcion,
                 Sum(Gastos_varios.Importe) AS Monto
    FROM   Gastos_varios
           INNER JOIN Conceptos
                   ON Conceptos.Id_concepto = Gastos_varios.Id_concepto
    WHERE  Datepart (YEAR, Fecha) = @anio
           AND Datename(MONTH, Fecha) = @mes
    GROUP  BY Conceptos.Descripcion
    ORDER  BY Sum (Importe) DESC

GO
/****** Object:  StoredProcedure [dbo].[Reportegastosmescombo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportegastosmescombo] @anio INT
AS
    SET Nocount ON;

    SELECT DISTINCT Datename (MONTH, Fecha) AS mes
    FROM   Gastos_varios
    WHERE  Datepart(year, Fecha) = @anio

GO
/****** Object:  StoredProcedure [dbo].[Reporteporcobrar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteporcobrar]
AS
    SELECT Sum(Saldo)
    FROM   clientes

GO
/****** Object:  StoredProcedure [dbo].[Reporteporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteporpagar]
AS
    SELECT Sum(Saldo)
    FROM   Proveedores

GO
/****** Object:  StoredProcedure [dbo].[Reporteproductobajominimo]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteproductobajominimo]
AS
    SELECT Count(Producto.idProducto)
    FROM   Producto
	Inner join DetalleProducto
	on Producto.idProducto = DetalleProducto.idProducto
	WHERE  Stock <= StockMinimo

GO
/****** Object:  StoredProcedure [dbo].[Reporteresumenfacturasempleadofechas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteresumenfacturasempleadofechas] @idEmpleado INT,
                                                       @fi         DATE,
                                                       @ff         DATE
AS
    SELECT CONVERT(DATE, facturas.fecha_factura)                 AS fecha_factura,
           Sum(facturas.Monto_total)                           AS Monto,
           Sum(detalle_factura.Costo * detalle_factura.cantidad) AS Costo,
           Sum(detalle_factura.Ganancia)                       AS Ganancia,
           @fi                                               AS fi,
           @ff                                               AS ff,
           Persona.nombre                                    AS Empleado
    FROM   facturas
           INNER JOIN detalle_factura
                   ON detalle_factura.idFactura = facturas.idFactura
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = facturas.Id_usuario
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
    WHERE  facturas.Monto_total > 0
           AND facturas.Id_usuario = @idEmpleado
           AND ( CONVERT(DATE, facturas.fecha_factura) >= @fi
                 AND CONVERT(DATE, facturas.fecha_factura) <= @ff )
    GROUP  BY CONVERT(DATE, facturas.fecha_factura),
              Persona.nombre

GO
/****** Object:  StoredProcedure [dbo].[Reporteresumenfacturasfechas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteresumenfacturasfechas] @fi DATE,
                                               @ff DATE
AS
    DECLARE @empleado VARCHAR(50)

    SET @empleado = 'Todos'

    SELECT CONVERT(DATE, facturas.fecha_factura)                 AS fecha_factura,
           Sum(facturas.Monto_total)                           AS Monto,
           Sum(detalle_factura.Costo * detalle_factura.cantidad) AS Costo,
           Sum(detalle_factura.Ganancia)                       AS Ganancia,
           @fi                                               AS fi,
           @ff                                               AS ff,
           @empleado                                         AS Empleado
    FROM   facturas
           INNER JOIN detalle_factura
                   ON detalle_factura.idFactura = facturas.idFactura
    WHERE  facturas.Monto_total > 0
           AND ( CONVERT(DATE, facturas.fecha_factura) >= @fi
                 AND CONVERT(DATE, facturas.fecha_factura) <= @ff )
    GROUP  BY CONVERT(DATE, facturas.fecha_factura)

GO
/****** Object:  StoredProcedure [dbo].[Reporteresumenfacturashoy]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteresumenfacturashoy]
AS
    DECLARE @fi AS VARCHAR(50)

    SET @fi = 'Siempre'

    DECLARE @ff AS VARCHAR(50)

    SET @ff= CONVERT(VARCHAR(50), Getdate())

    DECLARE @empleado VARCHAR(50)

    SET @empleado = 'Todos'

    SELECT CONVERT(DATE, facturas.fecha_factura)                 AS fecha_factura,
           Sum(facturas.Monto_total)                           AS Monto,
           Sum(detalle_factura.Costo * detalle_factura.cantidad) AS Costo,
           Sum(detalle_factura.Ganancia)                       AS Ganancia,
           @fi                                               AS fi,
           @ff                                               AS ff,
           @empleado                                         AS Empleado
    FROM   facturas
           INNER JOIN detalle_factura
                   ON detalle_factura.idFactura = facturas.idFactura
    WHERE  facturas.Monto_total > 0
    GROUP  BY CONVERT(DATE, facturas.fecha_factura)

GO
/****** Object:  StoredProcedure [dbo].[Reporteresumenfacturashoyempleado]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reporteresumenfacturashoyempleado] @idEmpleado INT
AS
    DECLARE @fi AS VARCHAR(50)

    SET @fi = 'Siempre'

    DECLARE @ff AS VARCHAR(50)

    SET @ff= CONVERT(VARCHAR(50), Getdate())

    SELECT CONVERT(DATE, facturas.fecha_factura)                 AS fecha_factura,
           Sum(facturas.Monto_total)                           AS Monto,
           Sum(detalle_factura.Costo * detalle_factura.cantidad) AS Costo,
           Sum(detalle_factura.Ganancia)                       AS Ganancia,
           @fi                                               AS fi,
           @ff                                               AS ff,
           Persona.nombre                                    Empleado
    FROM   facturas
           INNER JOIN detalle_factura
                   ON detalle_factura.idFactura = facturas.idFactura
           INNER JOIN USUARIO2
                   ON USUARIO2.idUsuario = facturas.Id_usuario
           INNER JOIN Empleados
                   ON USUARIO2.idEmpleado = Empleados.idEmpleado
           INNER JOIN Persona
                   ON Empleados.idPersona = Persona.idPersona
    WHERE  facturas.Monto_total > 0
           AND facturas.Id_usuario = @idEmpleado
    GROUP  BY CONVERT(DATE, facturas.fecha_factura),
              Persona.nombre

GO
/****** Object:  StoredProcedure [dbo].[Reportetotalfacturas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportetotalfacturas]
AS
    SELECT Sum(Monto_total)
    FROM   dbo.facturas

GO
/****** Object:  StoredProcedure [dbo].[Reportetotalfacturasfechas]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Reportetotalfacturasfechas] @fi DATE,
                                             @ff DATE
AS
    SELECT Sum(Monto_total)
    FROM   dbo.facturas
    WHERE  CONVERT (DATE, fecha_factura) >= @fi
           AND CONVERT(DATE, fecha_factura) <= @ff

GO
/****** Object:  StoredProcedure [dbo].[Restaurar_caja]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Restaurar_caja] @idcaja INTEGER
AS
    UPDATE Caja
    SET    Estado = 'Caja Restaurada'
    WHERE  Id_Caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Restaurar_clientes]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Restaurar_clientes] @Idcliente AS INT
AS
    UPDATE clientes
    SET    Estado = 'ACTIVO'
    WHERE  idclientev = @Idcliente

GO
/****** Object:  StoredProcedure [dbo].[Restaurar_empleados]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Restaurar_empleados] @idEmpleado AS INT
AS
    UPDATE Empleados
    SET    Estado = 'ACTIVO'
    WHERE  idEmpleado = @idEmpleado

GO
/****** Object:  StoredProcedure [dbo].[Restaurar_proveedores]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Restaurar_proveedores] @IdProveedor AS INT
AS
    UPDATE Proveedores
    SET    Estado = 'ACTIVO'
    WHERE  IdProveedor = @IdProveedor

GO
/****** Object:  StoredProcedure [dbo].[Sumar_creditoporcobrar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sumar_creditoporcobrar] @idcaja INT,
                                           @fi     DATETIME,
                                           @ff     DATETIME
AS
    SELECT Sum(Saldo)
    FROM   CreditoPorCobrar
    WHERE  ( Fecha_registro >= @fi
             AND Fecha_registro <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Sumar_creditoporpagar]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sumar_creditoporpagar] @idcaja INT,
                                          @fi     DATETIME,
                                          @ff     DATETIME
AS
    SELECT Sum(Saldo)
    FROM   CreditoPorPagar
    WHERE  ( Fecha_registro >= @fi
             AND Fecha_registro <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Sumar_gastos_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sumar_gastos_por_turno] @idcaja INT,
                                           @fi     DATETIME,
                                           @ff     DATETIME
AS
    SELECT Sum(Importe)
    FROM   Gastos_varios
    WHERE  ( Fecha >= @fi
             AND Fecha <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Sumar_ingresos_por_turno]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sumar_ingresos_por_turno] @idcaja INT,
                                             @fi     DATETIME,
                                             @ff     DATETIME
AS
    SELECT Sum(Importe)
    FROM   Ingresos_varios
    WHERE  ( Fecha >= @fi
             AND Fecha <= @ff )
           AND Id_caja = @idcaja

GO
/****** Object:  StoredProcedure [dbo].[Validar_usuario]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Validar_usuario] @password VARCHAR(50),
                                    @login    VARCHAR(50)
AS
    SELECT *
    FROM   USUARIO2
    WHERE  Password = @password
           AND Login = @Login
           AND Estado = 'ACTIVO'

GO
/****** Object:  StoredProcedure [dbo].[Verificarcliente]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Verificarcliente] @nombre AS VARCHAR(50)
AS
    SELECT c.idclientev,
           p.nombre as Nombre,
           d.Descripcion,
           c.Estado
    FROM   clientes AS c
           INNER JOIN Persona AS p
                   ON c.idPersona = p.idPersona
           INNER JOIN Direccion AS d
                   ON p.idDireccion = d.idDireccion
    WHERE  p.nombre = 'pedrito'
           AND c.Estado = 'ACTIVO'

GO
/****** Object:  StoredProcedure [dbo].[Verificardireccion]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Verificardireccion] @descripcion AS VARCHAR(50)
AS
    SELECT Descripcion
    FROM   Direccion
    WHERE  Descripcion = @descripcion

GO
/****** Object:  StoredProcedure [dbo].[verificarEmpresa]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[verificarEmpresa]
as
	Select Id_empresa from EMPRESA
GO
/****** Object:  StoredProcedure [dbo].[Verificartipotelefono]    Script Date: 16/12/2020 11:23:07:AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Verificartipotelefono] @descripcion AS VARCHAR(50)
AS
    SELECT descripcion
    FROM   TipoTelefono
    WHERE  descripcion = @descripcion

GO
USE [master]
GO
ALTER DATABASE [BASEDATOS] SET  READ_WRITE 
GO


CREATE LOGIN pruebas2020 WITH PASSWORD = 'pruebas123'
GO
Use BASEDATOS ;
GO
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'pruebas2020')
BEGIN
    CREATE USER [pruebas2020] FOR LOGIN [pruebas2020]
    EXEC sp_addrolemember N'db_owner', N'pruebas2020' 
    EXEC master..sp_addsrvrolemember @loginame = N'pruebas2020', @rolename = N'sysadmin'
END;
GO