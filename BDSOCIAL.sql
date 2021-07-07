USE [master]
GO
/****** Object:  Database [BDSOCIAL]    Script Date: 7/7/2021 10:15:45 ******/
CREATE DATABASE [BDSOCIAL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDSOCIAL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDSOCIAL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDSOCIAL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDSOCIAL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDSOCIAL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDSOCIAL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDSOCIAL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDSOCIAL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDSOCIAL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDSOCIAL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDSOCIAL] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDSOCIAL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDSOCIAL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDSOCIAL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDSOCIAL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDSOCIAL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDSOCIAL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDSOCIAL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDSOCIAL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDSOCIAL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDSOCIAL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDSOCIAL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDSOCIAL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDSOCIAL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDSOCIAL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDSOCIAL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDSOCIAL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDSOCIAL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDSOCIAL] SET RECOVERY FULL 
GO
ALTER DATABASE [BDSOCIAL] SET  MULTI_USER 
GO
ALTER DATABASE [BDSOCIAL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDSOCIAL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDSOCIAL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDSOCIAL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDSOCIAL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDSOCIAL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDSOCIAL', N'ON'
GO
ALTER DATABASE [BDSOCIAL] SET QUERY_STORE = OFF
GO
USE [BDSOCIAL]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[id_coment] [int] NOT NULL,
	[texto] [varchar](50) NULL,
	[id_imagen] [int] NOT NULL,
	[fecha] [date] NULL,
	[id_publi] [int] NOT NULL,
	[id_user] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[id_coment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTipoReac]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTipoReac](
	[id_tiporeact] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_CTipoReac] PRIMARY KEY CLUSTERED 
(
	[id_tiporeact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTipoUser]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTipoUser](
	[id_tipouser] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_CTipoUser] PRIMARY KEY CLUSTERED 
(
	[id_tipouser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtypePubli]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtypePubli](
	[id_typepost] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_CtypePubli] PRIMARY KEY CLUSTERED 
(
	[id_typepost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GruposS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GruposS](
	[id_grupo] [int] IDENTITY(1,1) NOT NULL,
	[tipo_grupo] [varchar](50) NULL,
 CONSTRAINT [PK_GruposS] PRIMARY KEY CLUSTERED 
(
	[id_grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImagenesS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagenesS](
	[id_imagen] [int] IDENTITY(1,1) NOT NULL,
	[imagen] [image] NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_ImagenesS] PRIMARY KEY CLUSTERED 
(
	[id_imagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MensajesS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MensajesS](
	[id_msj] [int] NOT NULL,
	[id_emisor] [int] NOT NULL,
	[id_receptor] [int] IDENTITY(1,1) NOT NULL,
	[texto] [varchar](50) NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_MensajesS] PRIMARY KEY CLUSTERED 
(
	[id_msj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostGruposS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostGruposS](
	[id_publicacion] [int] NOT NULL,
	[id_grupo] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[texto] [varchar](50) NULL,
	[id_imagen] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_PostGruposS] PRIMARY KEY CLUSTERED 
(
	[id_publicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublicacionesS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublicacionesS](
	[id_publicacion] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha] [date] NULL,
	[id_typepost] [int] NOT NULL,
	[text] [varchar](50) NULL,
	[id_imagen] [int] NOT NULL,
	[id_postshared] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PublicacionesS] PRIMARY KEY CLUSTERED 
(
	[id_publicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReaccionesS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReaccionesS](
	[id_reaccion] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_publicacion] [int] NOT NULL,
	[fecha] [date] NULL,
	[id_typereact] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ReaccionesS] PRIMARY KEY CLUSTERED 
(
	[id_reaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioGrupoS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioGrupoS](
	[id_user] [int] NOT NULL,
	[id_grupo] [int] IDENTITY(1,1) NOT NULL,
	[tipo_usuario] [varchar](50) NULL,
 CONSTRAINT [PK_UsuarioGrupoS] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosS]    Script Date: 7/7/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosS](
	[id_user] [int] NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[contraseña] [varchar](50) NULL,
 CONSTRAINT [PK_UsuariosS] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comentarios] ON 
GO
INSERT [dbo].[Comentarios] ([id_coment], [texto], [id_imagen], [fecha], [id_publi], [id_user]) VALUES (1, N'hola como estas?', 1, CAST(N'2021-07-05' AS Date), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Comentarios] OFF
GO
SET IDENTITY_INSERT [dbo].[CTipoReac] ON 
GO
INSERT [dbo].[CTipoReac] ([id_tiporeact], [nombre]) VALUES (1, N'Like')
GO
INSERT [dbo].[CTipoReac] ([id_tiporeact], [nombre]) VALUES (2, N'Me gusta')
GO
INSERT [dbo].[CTipoReac] ([id_tiporeact], [nombre]) VALUES (3, N'Me encanta')
GO
INSERT [dbo].[CTipoReac] ([id_tiporeact], [nombre]) VALUES (4, N'Me entristece')
GO
SET IDENTITY_INSERT [dbo].[CTipoReac] OFF
GO
SET IDENTITY_INSERT [dbo].[CTipoUser] ON 
GO
INSERT [dbo].[CTipoUser] ([id_tipouser], [nombre]) VALUES (2, N'Admin')
GO
INSERT [dbo].[CTipoUser] ([id_tipouser], [nombre]) VALUES (3, N'Comun')
GO
SET IDENTITY_INSERT [dbo].[CTipoUser] OFF
GO
SET IDENTITY_INSERT [dbo].[PublicacionesS] ON 
GO
INSERT [dbo].[PublicacionesS] ([id_publicacion], [id_usuario], [fecha], [id_typepost], [text], [id_imagen], [id_postshared]) VALUES (1, 1, CAST(N'2021-05-24' AS Date), 1, N'hola como estan?', 1, 1)
GO
INSERT [dbo].[PublicacionesS] ([id_publicacion], [id_usuario], [fecha], [id_typepost], [text], [id_imagen], [id_postshared]) VALUES (2, 1, CAST(N'2021-05-24' AS Date), 1, N'como ven esto?', 2, 4)
GO
SET IDENTITY_INSERT [dbo].[PublicacionesS] OFF
GO
SET IDENTITY_INSERT [dbo].[ReaccionesS] ON 
GO
INSERT [dbo].[ReaccionesS] ([id_reaccion], [id_usuario], [id_publicacion], [fecha], [id_typereact]) VALUES (1, 1, 1, CAST(N'2021-06-14' AS Date), 1)
GO
INSERT [dbo].[ReaccionesS] ([id_reaccion], [id_usuario], [id_publicacion], [fecha], [id_typereact]) VALUES (2, 1, 2, CAST(N'2021-06-15' AS Date), 2)
GO
INSERT [dbo].[ReaccionesS] ([id_reaccion], [id_usuario], [id_publicacion], [fecha], [id_typereact]) VALUES (3, 3, 2, CAST(N'2021-07-14' AS Date), 3)
GO
INSERT [dbo].[ReaccionesS] ([id_reaccion], [id_usuario], [id_publicacion], [fecha], [id_typereact]) VALUES (4, 5, 4, CAST(N'2021-05-24' AS Date), 4)
GO
INSERT [dbo].[ReaccionesS] ([id_reaccion], [id_usuario], [id_publicacion], [fecha], [id_typereact]) VALUES (5, 2, 4, CAST(N'2021-06-20' AS Date), 5)
GO
SET IDENTITY_INSERT [dbo].[ReaccionesS] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioGrupoS] ON 
GO
INSERT [dbo].[UsuarioGrupoS] ([id_user], [id_grupo], [tipo_usuario]) VALUES (1, 1, N'Comun')
GO
INSERT [dbo].[UsuarioGrupoS] ([id_user], [id_grupo], [tipo_usuario]) VALUES (2, 2, N'Celebridad')
GO
SET IDENTITY_INSERT [dbo].[UsuarioGrupoS] OFF
GO
INSERT [dbo].[UsuariosS] ([id_user], [nombres], [apellidos], [direccion], [email], [telefono], [contraseña]) VALUES (1, N'Mario Carlos', N'Gade Mayorga', N'Avenida San Patricio', N'gadea26@gmail.com', N'84574714', N'contragade')
GO
INSERT [dbo].[UsuariosS] ([id_user], [nombres], [apellidos], [direccion], [email], [telefono], [contraseña]) VALUES (2, N'Maria Josefa', N'Cardenas Solis', N'Del palito de naranja para arriba', N'cardenasmari@gmail.com', N'82364578', N'carcon1234')
GO
INSERT [dbo].[UsuariosS] ([id_user], [nombres], [apellidos], [direccion], [email], [telefono], [contraseña]) VALUES (3, N'Carlos Jose', N'Hernandez Kla', N'Reparto Marck Carls 26', N'carjo@gmail.com', N'85214654', N'carcom1')
GO
INSERT [dbo].[UsuariosS] ([id_user], [nombres], [apellidos], [direccion], [email], [telefono], [contraseña]) VALUES (4, N'Mario Cesar', N'Vado Garcia', N'Calle 43 avenida siempre viva', N'tupapichulo@gmail.com', N'78345625', N'contraseña99')
GO
INSERT [dbo].[UsuariosS] ([id_user], [nombres], [apellidos], [direccion], [email], [telefono], [contraseña]) VALUES (5, N'Marck Suck', N'Perez Jil', N'Avenida 58 calle 42', N'marck98@gmail.com', N'74751245', N'marcks25')
GO
INSERT [dbo].[UsuariosS] ([id_user], [nombres], [apellidos], [direccion], [email], [telefono], [contraseña]) VALUES (8, N'Hector Jose', N'Mayorga Perez', N'asdsadasd', N'asdasd@gmail.com', N'86244798', N'sodasdpkkkj')
GO
USE [master]
GO
ALTER DATABASE [BDSOCIAL] SET  READ_WRITE 
GO
