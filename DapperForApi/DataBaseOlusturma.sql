/************* Önce Yükleme yapacaðýnýz MS-SQL Serverin bulunduðu bilgisayarýnýzda 'C' Harddiskine girip 'Mstf' adýnda klasör oluþturmalýsýnýz ***************/
/************* Önce Yükleme yapacaðýnýz MS-SQL Serverin bulunduðu bilgisayarýnýzda 'C' Harddiskine girip 'Mstf' adýnda klasör oluþturmalýsýnýz ***************/
/************* Önce Yükleme yapacaðýnýz MS-SQL Serverin bulunduðu bilgisayarýnýzda 'C' Harddiskine girip 'Mstf' adýnda klasör oluþturmalýsýnýz ***************/
USE [master]
GO
/****** Object:  Database [DapperApi]    Script Date: 5.09.2016 19:06:09 ******/
CREATE DATABASE [DapperApi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DapperApi', FILENAME = N'C:\Mstf\DapperApi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DapperApi_log', FILENAME = N'C:\Mstf\DapperApi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DapperApi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DapperApi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DapperApi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DapperApi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DapperApi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DapperApi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DapperApi] SET ARITHABORT OFF 
GO
ALTER DATABASE [DapperApi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DapperApi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DapperApi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DapperApi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DapperApi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DapperApi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DapperApi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DapperApi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DapperApi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DapperApi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DapperApi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DapperApi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DapperApi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DapperApi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DapperApi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DapperApi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DapperApi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DapperApi] SET RECOVERY FULL 
GO
ALTER DATABASE [DapperApi] SET  MULTI_USER 
GO
ALTER DATABASE [DapperApi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DapperApi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DapperApi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DapperApi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DapperApi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DapperApi', N'ON'
GO
ALTER DATABASE [DapperApi] SET QUERY_STORE = OFF
GO
USE [DapperApi]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 5.09.2020 19:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](max) NOT NULL,
	[OlusturmaTarihi] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 5.09.2020 19:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[KategoriId] [bigint] NULL,
	[UrunAdi] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](max) NOT NULL,
	[Fiyat] [decimal](18, 2) NOT NULL,
	[OlusturmaTarihi] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategori] ON 
GO
INSERT [dbo].[Kategori] ([Id], [KategoriAdi], [Aciklama], [OlusturmaTarihi]) VALUES (1, N'KategoriADI_1', N'ACIKLAMA_1', CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Kategori] ([Id], [KategoriAdi], [Aciklama], [OlusturmaTarihi]) VALUES (4, N'KategoriADI_4', N'ACIKLAMA_4', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Kategori] ([Id], [KategoriAdi], [Aciklama], [OlusturmaTarihi]) VALUES (5, N'KategoriADI_5', N'ACIKLAMA_5', CAST(N'2018-09-03T23:03:17.7866667' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Kategori] OFF
GO
SET IDENTITY_INSERT [dbo].[Urun] ON 
GO
INSERT [dbo].[Urun] ([Id], [KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi]) VALUES (1, 1, N'ÜrünADI_1', N'AÇIKLAMA_1', CAST(10.00 AS Decimal(18, 2)), CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Urun] ([Id], [KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi]) VALUES (4, 4, N'ÜrünADI_4', N'AÇIKLAMA_4', CAST(40.00 AS Decimal(18, 2)), CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Urun] ([Id], [KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi]) VALUES (5, 5, N'ÜrünADI_5', N'AÇIKLAMA_5', CAST(50.00 AS Decimal(18, 2)), CAST(N'2018-09-03T23:00:07.3533333' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Urun] OFF
GO
USE [master]
GO
ALTER DATABASE [DapperApi] SET  READ_WRITE 
GO