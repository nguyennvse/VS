USE [master]
GO
/****** Object:  Database [VB_Business]    Script Date: 3/5/2019 5:56:09 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 3/5/2019 5:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Account_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuyOrder]    Script Date: 3/5/2019 5:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Total] [int] NULL,
	[Day] [date] NULL,
 CONSTRAINT [PK_BuyOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuyOrderDetail]    Script Date: 3/5/2019 5:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyOrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GoodCode] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[OrderID] [int] NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK_BuyOrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods]    Script Date: 3/5/2019 5:56:09 PM ******/
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
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/5/2019 5:56:09 PM ******/
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
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonalInfo]    Script Date: 3/5/2019 5:56:09 PM ******/
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
 CONSTRAINT [PK_Personal_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceList]    Script Date: 3/5/2019 5:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceListDetail]    Script Date: 3/5/2019 5:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceListDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PriceListID] [int] NULL,
	[GoodCode] [nvarchar](50) NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_PriceListDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([username], [password], [Role], [ID]) VALUES (N'tham', N'tham', N'Quản lý', 3)
INSERT [dbo].[Account] ([username], [password], [Role], [ID]) VALUES (N'a', N'a', N'Nhân Viên', 4)
INSERT [dbo].[Account] ([username], [password], [Role], [ID]) VALUES (N'phuc', N'phuc', N'Giám đốc', 6)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[BuyOrder] ON 

INSERT [dbo].[BuyOrder] ([ID], [Total], [Day]) VALUES (1, 1, CAST(N'2019-03-06' AS Date))
INSERT [dbo].[BuyOrder] ([ID], [Total], [Day]) VALUES (2, 0, CAST(N'2019-03-05' AS Date))
SET IDENTITY_INSERT [dbo].[BuyOrder] OFF
SET IDENTITY_INSERT [dbo].[BuyOrderDetail] ON 

INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (0, N'kt', 1, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (1, N'kt', 10, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (2, N'kl', 3, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (3, N'kt', 4, 1, 2)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (4, N'kl', 5, 1, 2)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (5, N'ss', 6, 1, 2)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (6, N'ss', 7, 1, 3)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (7, N'kl', 8, 1, 3)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (8, N'kt', 9, 1, 3)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (9, N'gvn', 10, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (10, N'htdl', 11, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (11, N'htc', 12, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (12, N'tx', 13, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (13, N'hbb', 14, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (14, N'bct', 15, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (15, N'crdl', 16, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (16, N'httlx', 17, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (17, N'gs', 18, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (18, N'blbb', 19, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (19, N'bpn', 20, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (20, N'rmx', 21, 1, 1)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [Quantity], [OrderID], [CustomerID]) VALUES (21, N'bcbt', 22, 1, 1)
SET IDENTITY_INSERT [dbo].[BuyOrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Goods] ON 

INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (2, N'Khoai Tây', N'Kg', 20000, N'kt')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (3, N'Khoai Lang', N'Kg', 30000, N'kl')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (8, N'Su Su', N'Kg', 11111, N'ss')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (9, N'Gừng VN', N'Kg', 35000, N'gvn')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (10, N'Hành Tây Đà Lạt', N'Kg ', 19000, N'htdl')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (11, N'Hành Tím Củ', N'Kg', 27000, N'htc')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (12, N'Tỏi Xay', N'Kg', 30000, N'tx')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (13, N'Hành Bắc Bảo', N'Kg', 71000, N'hbb')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (14, N'Bông Cải Trắng', N'Kg', 47000, N'bct')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (15, N'Cà Rốt Đà Lạt', N'Kg', 25000, N'crdl')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (16, N'Hủ Tiếu Tươi Lớn (Xào)', N'Kg', 11000, N'httlx')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (17, N'Giá sống', N'Kg', 10000, N'gs')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (18, N'Xương Ống Có Thịt', N'Kg', 65000, N'xoct')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (19, N'Bún Lớn (Bún Bò)', N'Kg', 10000, N'blbb')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (20, N'Bánh Phở Nam', N'Kg', 10000, N'bpn')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (21, N'Rau Muống Xào', N'Kg', 20000, N'rmx')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (22, N'Bắp Chuối Bào Trắng', N'Kg', 32000, N'bcbt')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (23, N'Chả Lụa Mặn ĐB', N'Kg', 130000, N'clmdb')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (24, N'Dưa Mắm Dưa Leo', N'Kg', 30000, N'dmdl')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (25, N'Giò Heo Lóc Xương Để Nguyên Da', N'Kg', 97000, N'ghlxdd')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (26, N'Sườn Non Cánh Buồm', N'Kg', 143000, N'sncb')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (27, N'Trứng Gà', N'Quả', 2150, N'tg')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (28, N'Trứng Cút Hộp', N'Hộp', 17400, N'tch')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (29, N'Thịt Ba Chỉ Rút Xương', N'Kg', 113000, N'tbcrx')
SET IDENTITY_INSERT [dbo].[Goods] OFF
SET IDENTITY_INSERT [dbo].[PersonalInfo] ON 

INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (0, N'Phúc', N'vb', 16544564, 945762521, 16544564, N'vb@gmail.com', 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (1, N'Nhật Hạ', N'Khách Sạn Nhật Hạ 1', 123123123, 234823847, 123123231, N'vb@gmail.com', 1)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (2, N'Thảo', N'vs', 239489834, 234928349, 239489834, N'vb@gmail.com', 1)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (3, N'Phạm', N'vs', 1234234234, 234234234, 234234234, N'vs@gmail.com', 1)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (7, N'Hoàng', N'b', 1234556, 231234, 1234556, N'a@gmaill.com', 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (8, N'Toàn', N'sb', 22222, 0, 22222, N'vb@gmail.com', 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (9, N'Thắm', N'sdfsd', 111111, 111111, 1111111, N'tham@gmail.com', 0)
INSERT [dbo].[PersonalInfo] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (10, N'Hằng', N'sgk', 111111, 111111, 1111111, N'hang@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[PersonalInfo] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Account]    Script Date: 3/5/2019 5:56:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [VB_Business] SET  READ_WRITE 
GO
