USE [master]
GO
/****** Object:  Database [JX3TradingPlatform]    Script Date: 2023/12/14 下午 04:51:57 ******/
CREATE DATABASE [JX3TradingPlatform]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JX3TradingPlatform', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\JX3TradingPlatform.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JX3TradingPlatform_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\JX3TradingPlatform_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [JX3TradingPlatform] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JX3TradingPlatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JX3TradingPlatform] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET ARITHABORT OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JX3TradingPlatform] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JX3TradingPlatform] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JX3TradingPlatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JX3TradingPlatform] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JX3TradingPlatform] SET  MULTI_USER 
GO
ALTER DATABASE [JX3TradingPlatform] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JX3TradingPlatform] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JX3TradingPlatform] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JX3TradingPlatform] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JX3TradingPlatform] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JX3TradingPlatform] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JX3TradingPlatform] SET QUERY_STORE = ON
GO
ALTER DATABASE [JX3TradingPlatform] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [JX3TradingPlatform]
GO
/****** Object:  User [hiyoru]    Script Date: 2023/12/14 下午 04:51:57 ******/
CREATE USER [hiyoru] FOR LOGIN [hiyoru] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [hiyoru]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2023/12/14 下午 04:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2023/12/14 下午 04:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SkinName] [nvarchar](20) NOT NULL,
	[Price] [int] NOT NULL,
	[AddDate] [date] NOT NULL,
	[BuyerID] [varchar](20) NULL,
	[SellerID] [varchar](20) NULL,
	[Status] [int] NOT NULL,
	[Type] [nvarchar](4) NOT NULL,
	[TransDate] [date] NULL,
	[TransAccount] [nchar](10) NULL,
	[Recipient] [nvarchar](20) NULL,
 CONSTRAINT [PK__Products__3214EC273AA52092] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skins]    Script Date: 2023/12/14 下午 04:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skins](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[EName] [nvarchar](50) NULL,
	[LaunchDate] [date] NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
	[PicturePath] [varchar](50) NULL,
 CONSTRAINT [PK_Skins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/12/14 下午 04:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[BankAccount] [varchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (1, N'髮型')
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (2, N'服裝')
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (3, N'外裝禮盒')
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (4, N'披風')
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (5, N'掛寵')
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (6, N'特效')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (1, N'金髮．金陵鳳', 480000, CAST(N'2023-12-10' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (2, N'金髮．金陵鳳', 360000, CAST(N'2023-12-08' AS Date), N'b123', NULL, 0, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (5, N'金髮．因陀羅', 170000, CAST(N'2023-11-20' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (7, N'金髮．因陀羅', 170000, CAST(N'2023-11-11' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (8, N'金髮．璨月蝶心', 200000, CAST(N'2023-10-25' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (9, N'金髮．熔金卷波
', 50000, CAST(N'2023-12-11' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (10, N'金髮．月華半朧', 50000, CAST(N'2023-12-11' AS Date), N'b123', N's123', 1, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (11, N'金髮．浮生樂', 45000, CAST(N'2023-12-11' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (12, N'金髮．陌上相思', 55000, CAST(N'2023-12-11' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (13, N'金髮．山亭燕月', 20000, CAST(N'2023-12-11' AS Date), NULL, N's123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (14, N'金髮．淡月微波', 8000, CAST(N'2023-12-11' AS Date), N'b123', N's123', 4, N'販售', CAST(N'2023-12-12' AS Date), N'01234     ', N'Banana')
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (15, N'金髮．鳳歸雲', 35000, CAST(N'2023-12-11' AS Date), N'bb123', N's123', 2, N'販售', CAST(N'2023-12-12' AS Date), N'46789     ', N'Banana')
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (16, N'金髮．金陵鳳', 450000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (17, N'金髮．因陀羅', 168000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (18, N'金髮．璨月蝶心', 195000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (19, N'金髮．熔金卷波
', 52000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (20, N'金髮．浮生樂', 45000, CAST(N'2023-12-11' AS Date), N'b123', N'ss123', 1, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (21, N'金髮．陌上相思', 55000, CAST(N'2023-12-11' AS Date), N'b123', N'ss123', 4, N'販售', CAST(N'2023-12-12' AS Date), N'01234     ', N'Banana')
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (22, N'金髮．山亭燕月', 18000, CAST(N'2023-12-11' AS Date), N'bb123', N'ss123', 4, N'販售', CAST(N'2023-12-12' AS Date), N'12345     ', N'balala')
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (23, N'金髮．淡月微波', 8500, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (24, N'金髮．鳳歸雲', 36000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (25, N'金髮．月華半朧', 52000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (26, N'金髮．月華半朧', 52000, CAST(N'2023-12-11' AS Date), NULL, N'ss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (32, N'金髮．淡月微波', 8200, CAST(N'2023-12-11' AS Date), NULL, N'b123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (33, N'金髮．月華半朧', 52000, CAST(N'2023-12-11' AS Date), N'b123', NULL, 0, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (34, N'金髮．淡月微波', 7500, CAST(N'2023-12-12' AS Date), N'bb123', NULL, 0, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (35, N'金髮．浮生樂', 44000, CAST(N'2023-12-12' AS Date), NULL, N'bb123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (36, N'金髮．鳳歸雲', 35000, CAST(N'2023-12-12' AS Date), N'bb123', N's123', 1, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (37, N'天選風不欺．無塵', 1400, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (38, N'天選風不欺．無懼', 1400, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (39, N'天選風不欺．無懼', 1400, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (40, N'箜篌踏歌．壇霞
', 1300, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (41, N'箜篌踏歌．閬海', 1300, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (42, N'天選金月．初雪
', 1500, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (43, N'夜隱仙．素菊', 900, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (44, N'夜隱仙．玄葵', 900, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (45, N'墨韻青髓．緋煙', 850, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (46, N'纖雲錦纜．塵露', 1100, CAST(N'2023-12-13' AS Date), NULL, N'sss123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (47, N'天選風不欺．無憂', 1400, CAST(N'2023-12-13' AS Date), N'b123', N's321', 2, N'販售', CAST(N'2023-12-13' AS Date), N'12345     ', N'Allen')
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (48, N'天選風不欺．無執', 1400, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (49, N'墨韻青髓．墨玉', 880, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (50, N'纖雲錦纜．玉琳', 1050, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (51, N'夜燼無聲', 3200, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (52, N'團絨戲', 3600, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (53, N'知凝', 850, CAST(N'2023-12-13' AS Date), N'bbb123', N's321', 1, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (54, N'遊茵', 600, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (55, N'掛寵．絨團團', 1700, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (56, N'掛寵．喵嗚嗚', 1700, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (57, N'掛寵．宿明明', 1700, CAST(N'2023-12-13' AS Date), NULL, N's321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (58, N'淡芳盈香禮盒', 2000, CAST(N'2023-12-13' AS Date), NULL, N'b123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (59, N'夜燼無聲', 3100, CAST(N'2023-12-13' AS Date), NULL, N'b123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (60, N'廣漠聽星禮盒', 9500, CAST(N'2023-12-13' AS Date), NULL, N'ss321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (61, N'霜落輕裘禮盒', 3500, CAST(N'2023-12-13' AS Date), NULL, N'ss321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (62, N'墜夜流金禮盒', 2000, CAST(N'2023-12-13' AS Date), NULL, N'ss321', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (63, N'天選風不欺．無懼', 1300, CAST(N'2023-12-13' AS Date), N'bbb123', NULL, 0, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (64, N'天選風不欺．無憂', 1300, CAST(N'2023-12-13' AS Date), N'bbb123', NULL, 0, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (65, N'夜隱仙．玄葵', 850, CAST(N'2023-12-13' AS Date), N'bbb123', NULL, 0, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (66, N'夜隱仙．素菊', 900, CAST(N'2023-12-13' AS Date), NULL, N'bbb123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (67, N'墨韻青髓．緋煙', 850, CAST(N'2023-12-13' AS Date), NULL, N'bbb123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (68, N'纖雲錦纜．玉琳', 1050, CAST(N'2023-12-13' AS Date), NULL, N'bbb123', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (69, N'箜篌踏歌．壇霞
', 1200, CAST(N'2023-12-13' AS Date), N'allen', N'bllen', 4, N'販售', CAST(N'2023-12-13' AS Date), N'12345     ', N'Allen')
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (70, N'天選金月．初雪
', 1400, CAST(N'2023-12-13' AS Date), N'bllen', N'allen', 1, N'購買', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (71, N'箜篌踏歌．閬海', 1200, CAST(N'2023-12-13' AS Date), NULL, N'allen', 0, N'販售', NULL, NULL, NULL)
INSERT [dbo].[Products] ([ID], [SkinName], [Price], [AddDate], [BuyerID], [SellerID], [Status], [Type], [TransDate], [TransAccount], [Recipient]) VALUES (73, N'天選風不欺．無懼', 1300, CAST(N'2023-12-13' AS Date), N'allen', NULL, 0, N'購買', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10101, N'金髮．金陵鳳', N'一代金', CAST(N'2015-12-12' AS Date), N'髮型', N'10101.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10102, N'金髮．因陀羅', N'猴金', CAST(N'2016-02-29' AS Date), N'髮型', N'10102.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10103, N'金髮．璨月蝶心', N'狐金', CAST(N'2016-04-28' AS Date), N'髮型', N'10103.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10104, N'金髮．熔金卷波
', N'蝶金', CAST(N'2016-11-11' AS Date), N'髮型', N'10104.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10105, N'金髮．月華半朧', N'雞金', CAST(N'2017-02-20' AS Date), N'髮型', N'10105.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10106, N'金髮．浮生樂', N'喵金', CAST(N'2017-04-20' AS Date), N'髮型', N'10106.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10107, N'金髮．陌上相思', N'考金', CAST(N'2017-06-08' AS Date), N'髮型', N'10107.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10108, N'金髮．山亭燕月', N'國金', CAST(N'2017-09-28' AS Date), N'髮型', N'10108.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10109, N'金髮．淡月微波', N'倒閉金、天使金', CAST(N'2017-12-12' AS Date), N'髮型', N'10109.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (10110, N'金髮．鳳歸雲', N'狗金', CAST(N'2018-03-02' AS Date), N'髮型', N'10110.png')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20101, N'箜篌踏歌．壇霞
', N'復刻粉水母', CAST(N'2022-09-26' AS Date), N'服裝', N'20101.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20102, N'箜篌踏歌．閬海', N'復刻藍水母', CAST(N'2022-09-26' AS Date), N'服裝', N'20102.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20103, N'天選金月．初雪
', N'復刻白娃娃菜', CAST(N'2021-10-29' AS Date), N'服裝', N'20103.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20104, N'天選風不欺．無塵', NULL, CAST(N'2023-04-28' AS Date), N'服裝', N'20104.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20105, N'天選風不欺．無懼', NULL, CAST(N'2023-04-28' AS Date), N'服裝', N'20105.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20106, N'天選風不欺．無憂', NULL, CAST(N'2023-04-28' AS Date), N'服裝', N'20106.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20107, N'天選風不欺．無執', NULL, CAST(N'2023-04-28' AS Date), N'服裝', N'20107.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20108, N'夜隱仙．素菊', NULL, CAST(N'2021-12-02' AS Date), N'服裝', N'20108.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20109, N'夜隱仙．玄葵', NULL, CAST(N'2021-12-02' AS Date), N'服裝', N'20109.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20110, N'墨韻青髓．緋煙', NULL, CAST(N'2021-12-02' AS Date), N'服裝', N'20110.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20111, N'墨韻青髓．墨玉', NULL, CAST(N'2021-12-02' AS Date), N'服裝', N'20111.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20112, N'纖雲錦纜．塵露', NULL, CAST(N'2023-07-12' AS Date), N'服裝', N'20112.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (20113, N'纖雲錦纜．玉琳', NULL, CAST(N'2023-07-12' AS Date), N'服裝', N'20113.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (30101, N'廣漠聽星禮盒', N'衍天盒', CAST(N'2020-12-21' AS Date), N'外裝禮盒', N'30101.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (30102, N'霜落輕裘禮盒', N'狐狸盒', CAST(N'2023-01-12' AS Date), N'外裝禮盒', N'30102.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (30103, N'墜夜流金禮盒', N'蛇盒', CAST(N'2023-01-12' AS Date), N'外裝禮盒', N'30103.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (30108, N'遙步通天禮盒', N'西遊盒', CAST(N'2023-08-10' AS Date), N'外裝禮盒', N'30108.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (30110, N'淡芳盈香禮盒', N'六代中秋盒', CAST(N'2021-09-16' AS Date), N'外裝禮盒', N'30110.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (40101, N'夜燼無聲', N'二代黑狐狸毛', CAST(N'2019-11-11' AS Date), N'披風', N'40101.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (40102, N'團絨戲', NULL, CAST(N'2021-04-05' AS Date), N'披風', N'40102.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (50101, N'掛寵．綏綏', N'橘闊耳狐', CAST(N'2019-10-14' AS Date), N'掛寵', N'50101.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (50102, N'掛寵．亭亭', N'白闊耳狐', CAST(N'2019-10-14' AS Date), N'掛寵', N'50102.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (50103, N'掛寵．容華', N'黃闊耳狐', CAST(N'2019-10-14' AS Date), N'掛寵', N'50103.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (50104, N'掛寵．宿明明', N'橘老虎', CAST(N'2022-01-20' AS Date), N'掛寵', N'50104.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (50105, N'掛寵．喵嗚嗚', N'白老虎', CAST(N'2022-01-20' AS Date), N'掛寵', N'50105.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (50106, N'掛寵．絨團團', N'黃老虎', CAST(N'2022-01-20' AS Date), N'掛寵', N'50106.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (60101, N'知凝', NULL, CAST(N'2022-02-28' AS Date), N'特效', N'60101.jpg')
INSERT [dbo].[Skins] ([ID], [Name], [EName], [LaunchDate], [CategoryName], [PicturePath]) VALUES (60102, N'遊茵', NULL, CAST(N'2022-02-28' AS Date), N'特效', N'60102.jpg')
GO
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'allen', N'allen', N'allen', N'allen@gmail.com', N'0912345678', N'700-123412241234')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'b123', N'b123', N'一個富婆', N'j123@gmail.com', N'0912321321', N'005-000011112222')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'bb123', N'bb123', N'木白白', N'bb123@gmail.com', N'0900123321', N'005-0001000200030004')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'bbb123', N'bbb123', N'秋小冰', N'chou8888@gmail.com', N'0987654321', N'812-555544443333')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'bllen', N'bllen', N'bllen', N'bllen@gmail.com', N'0912345678', N'700-134561255554')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'pig1014', N'pig', N'苡辰小公主', N'pig@gmail.com', N'0912123123', N'700-132412341234')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N's123', N's123', N'外觀大盤商', N's123@gmail.com', N'0912123123', N'700-123412341234')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N's321', N's321', N'啵啵桃', N'bobo321@gmail.com', N'0921321321', N'008-432143214321')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'ss123', N'ss123', N'大盤商二號', N'ss123@gmail.com', N'0922333444', N'808-341612344564')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'ss321', N'ss321', N'喵窩', N'miao@gmail.com', N'0922522522', N'021-522252225222')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'sss123', N'sss123', N'長安花', N'sss123@gmail.com', N'0988777666', N'808-888877776666')
INSERT [dbo].[Users] ([ID], [Password], [UserName], [Email], [PhoneNumber], [BankAccount]) VALUES (N'test123', N'test123', N'test123', N'test123@gmail.com', N'0911222333', NULL)
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
USE [master]
GO
ALTER DATABASE [JX3TradingPlatform] SET  READ_WRITE 
GO
