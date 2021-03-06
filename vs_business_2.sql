USE [master]
GO
/****** Object:  Database [VB_Business]    Script Date: 2/27/2019 1:30:26 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 2/27/2019 1:30:26 AM ******/
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
/****** Object:  Table [dbo].[BuyOrder]    Script Date: 2/27/2019 1:30:26 AM ******/
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
/****** Object:  Table [dbo].[BuyOrderDetail]    Script Date: 2/27/2019 1:30:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyOrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GoodCode] [nvarchar](50) NULL,
	[GoodName] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Total] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_BuyOrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods]    Script Date: 2/27/2019 1:30:26 AM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 2/27/2019 1:30:26 AM ******/
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
/****** Object:  Table [dbo].[Personal_Info]    Script Date: 2/27/2019 1:30:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal_Info](
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
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([username], [password], [Role], [ID]) VALUES (N'tham', N'tham', N'Quản lý', 3)
INSERT [dbo].[Account] ([username], [password], [Role], [ID]) VALUES (N'a', N'a', N'Nhân Viên', 4)
INSERT [dbo].[Account] ([username], [password], [Role], [ID]) VALUES (N'phuc', N'phuc', N'Giám đốc', 6)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[BuyOrder] ON 

INSERT [dbo].[BuyOrder] ([ID], [Total], [Day]) VALUES (1, 1, CAST(N'2019-02-23' AS Date))
SET IDENTITY_INSERT [dbo].[BuyOrder] OFF
SET IDENTITY_INSERT [dbo].[BuyOrderDetail] ON 

INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [GoodName], [Quantity], [Total], [OrderID]) VALUES (0, N'kt', N'khoai tây', 10, 200000, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [GoodName], [Quantity], [Total], [OrderID]) VALUES (1, N'kt', N'khoai tây', 10, 200000, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [GoodName], [Quantity], [Total], [OrderID]) VALUES (2, N'kl', N'khoai lang', 20, 600000, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [GoodName], [Quantity], [Total], [OrderID]) VALUES (3, N'kt', N'khoai tây', 10, 200000, NULL)
INSERT [dbo].[BuyOrderDetail] ([ID], [GoodCode], [GoodName], [Quantity], [Total], [OrderID]) VALUES (4, N'kl', N'khoai lang', 20, 600000, NULL)
SET IDENTITY_INSERT [dbo].[BuyOrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Goods] ON 

INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (2, N'khoai tây', N'ký', 20000, N'kt')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (3, N'khoai lang', N'ký', 30000, N'kl')
INSERT [dbo].[Goods] ([ID], [Name], [Unit], [Price], [Code]) VALUES (8, N'su su', N'kg', 11111, N'ss')
SET IDENTITY_INSERT [dbo].[Goods] OFF
SET IDENTITY_INSERT [dbo].[Personal_Info] ON 

INSERT [dbo].[Personal_Info] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (0, N'phuc', N'vb', 16544564, 945762521, 16544564, N'vb@gmail.com', 0)
INSERT [dbo].[Personal_Info] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (1, N'nguyen', N'vs', 123123123, 234823847, 123123231, N'vb@gmail.com', 1)
INSERT [dbo].[Personal_Info] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (2, N'thama', N'vs', 239489834, 234928349, 239489834, N'vb@gmail.com', 2)
INSERT [dbo].[Personal_Info] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (3, N'hagn', N'vs', 1234234234, 234234234, 234234234, N'vs@gmail.com', 0)
INSERT [dbo].[Personal_Info] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (7, N' baa', N'b', 1234556, 231234, 1234556, N'a@gmaill.com', 0)
INSERT [dbo].[Personal_Info] ([ID], [Name], [Company], [MST], [Phone], [Fax], [Email], [Type]) VALUES (8, N'toan', N'sb', 22222, 0, 22222, N'vb@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[Personal_Info] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Account]    Script Date: 2/27/2019 1:30:26 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [VB_Business] SET  READ_WRITE 
GO
