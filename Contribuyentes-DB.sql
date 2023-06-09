USE [master]
GO
/****** Object:  Database [ContribuyentesDB]    Script Date: 5/18/2023 2:41:46 AM ******/
CREATE DATABASE [ContribuyentesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContribuyentesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ContribuyentesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContribuyentesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ContribuyentesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ContribuyentesDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContribuyentesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContribuyentesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContribuyentesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContribuyentesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContribuyentesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContribuyentesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ContribuyentesDB] SET  MULTI_USER 
GO
ALTER DATABASE [ContribuyentesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContribuyentesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContribuyentesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContribuyentesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContribuyentesDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContribuyentesDB', N'ON'
GO
ALTER DATABASE [ContribuyentesDB] SET QUERY_STORE = OFF
GO
USE [ContribuyentesDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/18/2023 2:41:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprobantesFiscales]    Script Date: 5/18/2023 2:41:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobantesFiscales](
	[NCF] [nvarchar](450) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Itbis18] [decimal](18, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UltimaFechaModificacion] [datetime] NOT NULL,
	[RncCedula] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_ComprobantesFiscales] PRIMARY KEY CLUSTERED 
(
	[NCF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contribuyentes]    Script Date: 5/18/2023 2:41:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contribuyentes](
	[Nombre] [nvarchar](max) NOT NULL,
	[IdTipoPersona] [smallint] NOT NULL,
	[IdEstatus] [smallint] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UltimaFechaModificacion] [datetime] NOT NULL,
	[RncCedula] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Contribuyentes] PRIMARY KEY CLUSTERED 
(
	[RncCedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estatus]    Script Date: 5/18/2023 2:41:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estatus](
	[IdEstatus] [smallint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UltimaFechaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Estatus] PRIMARY KEY CLUSTERED 
(
	[IdEstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPersonas]    Script Date: 5/18/2023 2:41:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersonas](
	[IdTipoPersona] [smallint] IDENTITY(1,1) NOT NULL,
	[DescripcionPersona] [nvarchar](150) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UltimaFechaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_TipoPersonas] PRIMARY KEY CLUSTERED 
(
	[IdTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515051547_InitialCreate', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515214830_DroppingFKeys', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515221720_ReversingEverything', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516003714_AddingAgain', N'7.0.5')
GO
INSERT [dbo].[ComprobantesFiscales] ([NCF], [Monto], [Itbis18], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'E310000000001', CAST(200.00 AS Decimal(18, 2)), CAST(36.00 AS Decimal(18, 2)), CAST(N'2023-05-15T22:47:52.863' AS DateTime), CAST(N'2023-05-15T22:47:52.863' AS DateTime), N'98754321012')
INSERT [dbo].[ComprobantesFiscales] ([NCF], [Monto], [Itbis18], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'E310000000002', CAST(1000.00 AS Decimal(18, 2)), CAST(180.00 AS Decimal(18, 2)), CAST(N'2023-05-15T23:04:25.487' AS DateTime), CAST(N'2023-05-15T23:04:25.487' AS DateTime), N'98754321012')
GO
INSERT [dbo].[Contribuyentes] ([Nombre], [IdTipoPersona], [IdEstatus], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'FARMACIA TU SALUD', 2, 2, CAST(N'2023-05-15T20:45:36.217' AS DateTime), CAST(N'2023-05-15T20:45:36.217' AS DateTime), N'123456789')
INSERT [dbo].[Contribuyentes] ([Nombre], [IdTipoPersona], [IdEstatus], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'JUAN PEREZ', 1, 1, CAST(N'2023-05-15T20:44:35.700' AS DateTime), CAST(N'2023-05-15T20:44:35.700' AS DateTime), N'98754321012')
GO
SET IDENTITY_INSERT [dbo].[Estatus] ON 

INSERT [dbo].[Estatus] ([IdEstatus], [Descripcion], [FechaCreacion], [UltimaFechaModificacion]) VALUES (1, N'activo', CAST(N'2023-05-15T16:39:55.487' AS DateTime), CAST(N'2023-05-15T16:39:55.487' AS DateTime))
INSERT [dbo].[Estatus] ([IdEstatus], [Descripcion], [FechaCreacion], [UltimaFechaModificacion]) VALUES (2, N'inactivo', CAST(N'2023-05-15T16:41:39.897' AS DateTime), CAST(N'2023-05-15T16:41:39.897' AS DateTime))
SET IDENTITY_INSERT [dbo].[Estatus] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPersonas] ON 

INSERT [dbo].[TipoPersonas] ([IdTipoPersona], [DescripcionPersona], [FechaCreacion], [UltimaFechaModificacion]) VALUES (1, N'PERSONA FISICA', CAST(N'2023-05-15T16:48:13.930' AS DateTime), CAST(N'2023-05-15T16:48:13.930' AS DateTime))
INSERT [dbo].[TipoPersonas] ([IdTipoPersona], [DescripcionPersona], [FechaCreacion], [UltimaFechaModificacion]) VALUES (2, N'PERSONA JURIDICA', CAST(N'2023-05-15T16:49:22.450' AS DateTime), CAST(N'2023-05-15T16:49:22.450' AS DateTime))
SET IDENTITY_INSERT [dbo].[TipoPersonas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ComprobantesFiscales_RncCedula]    Script Date: 5/18/2023 2:41:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_ComprobantesFiscales_RncCedula] ON [dbo].[ComprobantesFiscales]
(
	[RncCedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contribuyentes_IdEstatus]    Script Date: 5/18/2023 2:41:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Contribuyentes_IdEstatus] ON [dbo].[Contribuyentes]
(
	[IdEstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contribuyentes_IdTipoPersona]    Script Date: 5/18/2023 2:41:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Contribuyentes_IdTipoPersona] ON [dbo].[Contribuyentes]
(
	[IdTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ComprobantesFiscales] ADD  DEFAULT (N'') FOR [RncCedula]
GO
ALTER TABLE [dbo].[Contribuyentes] ADD  DEFAULT (N'') FOR [RncCedula]
GO
ALTER TABLE [dbo].[ComprobantesFiscales]  WITH CHECK ADD  CONSTRAINT [FK_ComprobantesFiscales_Contribuyentes_B] FOREIGN KEY([RncCedula])
REFERENCES [dbo].[Contribuyentes] ([RncCedula])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComprobantesFiscales] CHECK CONSTRAINT [FK_ComprobantesFiscales_Contribuyentes_B]
GO
ALTER TABLE [dbo].[Contribuyentes]  WITH CHECK ADD  CONSTRAINT [FK_Contribuyentes_Estatus] FOREIGN KEY([IdEstatus])
REFERENCES [dbo].[Estatus] ([IdEstatus])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contribuyentes] CHECK CONSTRAINT [FK_Contribuyentes_Estatus]
GO
ALTER TABLE [dbo].[Contribuyentes]  WITH CHECK ADD  CONSTRAINT [FK_Contribuyentes_TipoPersonas] FOREIGN KEY([IdTipoPersona])
REFERENCES [dbo].[TipoPersonas] ([IdTipoPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contribuyentes] CHECK CONSTRAINT [FK_Contribuyentes_TipoPersonas]
GO
USE [master]
GO
ALTER DATABASE [ContribuyentesDB] SET  READ_WRITE 
GO
