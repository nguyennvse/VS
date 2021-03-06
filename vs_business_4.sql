USE [master]
GO
/****** Object:  Database [VB_Business]    Script Date: 3/7/2019 6:27:39 PM ******/
CREATE DATABASE [VB_Business]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VB_Business', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\VB_Business.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VB_Business_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\VB_Business_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VB_Business] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VB_Business].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VB_Business] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VB_Business] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VB_Business] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VB_Business] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VB_Business] SET ARITHABORT OFF 
GO
ALTER DATABASE [VB_Business] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VB_Business] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VB_Business] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VB_Business] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VB_Business] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VB_Business] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VB_Business] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VB_Business] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VB_Business] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VB_Business] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VB_Business] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VB_Business] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VB_Business] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VB_Business] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VB_Business] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VB_Business] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VB_Business] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VB_Business] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VB_Business] SET  MULTI_USER 
GO
ALTER DATABASE [VB_Business] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VB_Business] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VB_Business] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VB_Business] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VB_Business] SET DELAYED_DURABILITY = DISABLED 
GO
USE [VB_Business]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_Account_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuyOrder]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Total] [int] NULL,
	[Day] [date] NULL,
	[CustomerID] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_BuyOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuyOrderDetail]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyOrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GoodCode] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[OrderID] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_BuyOrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[Code] [nvarchar](50) NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[Good_id] [int] NULL,
	[Quantity] [int] NULL,
	[Date] [date] NULL,
	[Customer_id] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonalInfo]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NULL,
	[MST] [int] NULL,
	[Phone] [int] NULL,
	[Fax] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_Personal_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceList]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceListDetail]    Script Date: 3/7/2019 6:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceListDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PriceListID] [int] NULL,
	[GoodCode] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_PriceListDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([username], [password], [Role], [ID], [isDelete]) VALUES (N'tham', N'1', N'Giám Đốc', 3, 0)
INSERT [dbo].[Account] ([username], [password], [Role], [ID], [isDelete]) VALUES (N'a', N'a', N'Nhân Viên', 4, 0)
INSERT [dbo].[Account] ([username], [password], [Role], [ID], [isDelete]) VALUES (N'phuc', N'phuc', N'Giám đốc', 6, 0)
INSERT [dbo].[Account] ([username], [password], [Role], [ID], [isDelete]) VALUES (N'nguyen', N'nguyen', N'Giám Đốc', 8, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[BuyOrder] ON 

INSERT [dbo].[BuyOrder] ([ID], [Total], [Day], [CustomerID], [isDelete]) VALUES (1, 1, CAST(N'2019-03-06' AS Date), 1, NULL)
INSERT [dbo].[BuyOrder] ([ID], [Total], [Day], [CustomerID], [isDelete]) VALUES (2, 0, CAST(N'2019-03-05' AS Date), 2, NULL)
INSERT [dbo].[BuyOrder] ([ID], [Total], [Day], [CustomerID], [isDelete]) VALUES (7, NULL, CAST(N'2019-03-07' AS Date), 1, NULL)
INSERT [dbo].[BuyOrder] ([ID], [Total], [Day], [CustomerID], [isDelete]) VALUES (8, NULL, CAST(N'2019-03-07' AS Date), 2, NULL)
SET IDENTITY_INSERT [dbo].[BuyOrder] OFF
SET IDENTITY_INSERT [dbo].[BuyOrderDetail] ON 

INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (4, N'kl', 5, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (5, N'ss', 6, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (9, N'gvn', 10, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (10, N'htdl', 11, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (11, N'htc', 12, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (12, N'tx', 13, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (13, N'hbb', 14, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (14, N'bct', 15, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (15, N'crdl', 16, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (16, N'httlx', 17, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (17, N'gs', 18, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (18, N'blbb', 19, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (19, N'bpn', 20, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (20, N'rmx', 21, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (21, N'bcbt', 22, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (23, N'tbcrx', 10, 1, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (93, N'kt', 2, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (94, N'kl', 3, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (95, N'ss', 4, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (96, N'gvn', 5, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (97, N'htdl', 6, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (98, N'htc', 7, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (99, N'tx', 8, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (100, N'hbb', 9, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (101, N'bct', 10, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (102, N'crdl', 11, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (103, N'httlx', 12, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (104, N'gs', 13, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (105, N'xoct', 14, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (106, N'blbb', 15, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (107, N'bpn', 16, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (108, N'rmx', 17, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (109, N'bcbt', 18, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (110, N'clmdb', 19, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (111, N'dmdl', 20, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (112, N'ghlxdd', 21, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (113, N'sncb', 22, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (114, N'tg', 23, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (115, N'tch', 24, 7, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (117, N'kl', 2, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (118, N'ss', 2, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (119, N'gvn', 2, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (120, N'htdl', 2, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (121, N'htc', 2, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (122, N'tx', 2, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (123, N'hbb', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (124, N'bct', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (125, N'crdl', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (126, N'httlx', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (127, N'gs', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (128, N'xoct', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (129, N'blbb', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (130, N'bpn', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (131, N'rmx', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (132, N'bcbt', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (133, N'clmdb', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (134, N'dmdl', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (135, N'ghlxdd', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (136, N'sncb', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (137, N'tg', 1, 8, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [isDelete]) VALUES (138, N'tch', 1, 8, NULL)
SET IDENTITY_INSERT [dbo].[BuyOrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Goods] ON 

INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (2, N'Khoai Tây', N'Kg', 21000, N'kt', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (3, N'Khoai Lang', N'Kg', 30000, N'kl', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (8, N'Su Su', N'Kg', 11111, N'ss', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (9, N'Gừng VN', N'Kg', 35000, N'gvn', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (10, N'Hành Tây Đà Lạt', N'Kg ', 19000, N'htdl', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (11, N'Hành Tím Củ', N'Kg', 27000, N'htc', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (12, N'Tỏi Xay', N'Kg', 30000, N'tx', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (13, N'Hành Bắc Bảo', N'Kg', 71000, N'hbb', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (14, N'Bông Cải Trắng', N'Kg', 47000, N'bct', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (15, N'Cà Rốt Đà Lạt', N'Kg', 25000, N'crdl', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (16, N'Hủ Tiếu Tươi Lớn (Xào)', N'Kg', 11000, N'httlx', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (17, N'Giá sống', N'Kg', 10000, N'gs', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (18, N'Xương Ống Có Thịt', N'Kg', 65000, N'xoct', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (19, N'Bún Lớn (Bún Bò)', N'Kg', 10000, N'blbb', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (20, N'Bánh Phở Nam', N'Kg', 10000, N'bpn', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (21, N'Rau Muống Xào', N'Kg', 20000, N'rmx', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (22, N'Bắp Chuối Bào Trắng', N'Kg', 32000, N'bcbt', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (23, N'Chả Lụa Mặn ĐB', N'Kg', 130000, N'clmdb', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (24, N'Dưa Mắm Dưa Leo', N'Kg', 30000, N'dmdl', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (25, N'Giò Heo Lóc Xương Để Nguyên Da', N'Kg', 97000, N'ghlxdd', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (26, N'Sườn Non Cánh Buồm', N'Kg', 143000, N'sncb', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (27, N'Trứng Gà', N'Quả', 2150, N'tg', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (28, N'Trứng Cút Hộp', N'Hộp', 17400, N'tch', 0)
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code], [isDelete]) VALUES (29, N'Thịt Ba Chỉ Rút Xương', N'Kg', 113000, N'tbcrx', 1)
SET IDENTITY_INSERT [dbo].[Goods] OFF
SET IDENTITY_INSERT [dbo].[PersonalInfo] ON 

INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (0, N'Mỹ Phúc', N'vb', 16544564, 945762521, 16544564, N'vb@gmail.com', 0, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (1, N'Nguyễn Nhật Hạ', N'Khách Sạn Nhật Hạ 1', 123123231, 234823847, 123123231, N'vb@gmail.com', 1, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (2, N'Thảo', N'vs', 239489834, 234928349, 239489834, N'vb@gmail.com', 1, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (3, N'Phạm', N'vs', 1234234234, 234234234, 234234234, N'vs@gmail.com', 1, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (7, N'Hoàng', N'b', 1234556, 231234, 1234556, N'a@gmaill.com', 0, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (8, N'Toàn', N'sb', 22222, 0, 22222, N'vb@gmail.com', 0, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (9, N'Thắm', N'sdfsd', 111111, 111111, 1111111, N'tham@gmail.com', 0, 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (10, N'Hằng', N'sgk', 111111, 111111, 1111111, N'hang@gmail.com', 1, 1)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type], [isDelete]) VALUES (12, N'Nguyễn Nhật Hạ 2', N'Khách Sạn Nhật Hạ 2', 123123231, 234823847, 123123231, N'vb@gmail.com', 0, NULL)
SET IDENTITY_INSERT [dbo].[PersonalInfo] OFF
SET IDENTITY_INSERT [dbo].[PriceList] ON 

INSERT [dbo].[PriceList] ([ID], [CustomerID], [isDelete]) VALUES (1, 1, NULL)
INSERT [dbo].[PriceList] ([ID], [CustomerID], [isDelete]) VALUES (2, 7, NULL)
INSERT [dbo].[PriceList] ([ID], [CustomerID], [isDelete]) VALUES (3, 0, NULL)
INSERT [dbo].[PriceList] ([ID], [CustomerID], [isDelete]) VALUES (4, 2, NULL)
SET IDENTITY_INSERT [dbo].[PriceList] OFF
SET IDENTITY_INSERT [dbo].[PriceListDetail] ON 

INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (1, 1, N'kt', 10000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (2, 1, N'kl', 11000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (3, 1, N'ss', 12000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (4, 1, N'gvn', 13000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (5, 1, N'htdl', 14000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (6, 1, N'htc', 15000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (7, 1, N'tx', 16000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (8, 1, N'hbb', 17000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (9, 1, N'bct', 18000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (10, 1, N'crdl', 19000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (11, 1, N'httlx', 20000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (12, 1, N'gs', 21000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (13, 1, N'xoct', 22000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (14, 1, N'blbb', 23000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (15, 1, N'bpn', 24000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (16, 1, N'rmx', 25000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (17, 1, N'bcbt', 26000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (18, 1, N'clmdb', 27000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (19, 1, N'dmdl', 28000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (20, 1, N'ghlxdd', 29000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (21, 1, N'sncb', 30000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (22, 1, N'tg', 31000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (23, 1, N'tch', 32000, NULL)
INSERT [dbo].[PriceListDetail] ([ID], [PriceListID], [GoodCode], [Price], [isDelete]) VALUES (24, 1, N'tbcrx', 33000, NULL)
SET IDENTITY_INSERT [dbo].[PriceListDetail] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Account]    Script Date: 3/7/2019 6:27:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [VB_Business] SET  READ_WRITE 
GO
