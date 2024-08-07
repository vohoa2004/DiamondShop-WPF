USE [master]
GO
/****** Object:  Database [Net1814_212_3_Diamond]    Script Date: 7/10/2024 5:48:15 PM ******/
CREATE DATABASE [Net1814_212_3_Diamond]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Net1814_212_3_Diamond', FILENAME = N'E:\SEMESTER_5\PRN212\Project\Net1814_212_3_Diamond\DB\Net1814_212_3_Diamond.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Net1814_212_3_Diamond_log', FILENAME = N'E:\SEMESTER_5\PRN212\Project\Net1814_212_3_Diamond\DB\Net1814_212_3_Diamond_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Net1814_212_3_Diamond].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ARITHABORT OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET RECOVERY FULL 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET  MULTI_USER 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Net1814_212_3_Diamond', N'ON'
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET QUERY_STORE = OFF
GO
USE [Net1814_212_3_Diamond]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/10/2024 5:48:16 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[CustomerID] [nvarchar](254) NOT NULL,
	[Email] [nvarchar](254) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [nvarchar](10) NULL,
	[IsActive] [bit] NULL,
	[Country] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIAMOND]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIAMOND](
	[DiamondID] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Clarity] [nvarchar](50) NOT NULL,
	[Carat] [decimal](5, 2) NOT NULL,
	[Cut] [nvarchar](50) NOT NULL,
	[CertificateScan] [nvarchar](max) NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[AmountAvailable] [int] NOT NULL,
	[CategoryID] [nvarchar](36) NOT NULL,
	[ImageUrl] [varchar](255) NULL,
	[DateAcquired] [date] NULL,
	[CertifyingAuthority] [nvarchar](100) NULL,
	[Polish] [nvarchar](50) NULL,
	[Symmetry] [nvarchar](50) NULL,
	[Fluorescence] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiamondID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERDETAIL]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERDETAIL](
	[OrderDetailID] [nvarchar](36) NOT NULL,
	[OrderID] [nvarchar](36) NOT NULL,
	[LineTotal] [decimal](18, 2) NOT NULL,
	[MainDiamondID] [nvarchar](36) NOT NULL,
	[ShellID] [nvarchar](36) NOT NULL,
	[SubDiamondID] [nvarchar](36) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitWeight] [decimal](5, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[DiscountPercentage] [decimal](5, 2) NOT NULL,
	[Note] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[OrderID] [nvarchar](36) NOT NULL,
	[CustomerID] [nvarchar](254) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[ShippingAddress] [nvarchar](255) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[PaymentStatus] [nvarchar](50) NOT NULL,
	[ShippingStatus] [nvarchar](50) NOT NULL,
	[PromotionID] [nvarchar](36) NULL,
	[OrderDescription] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTCATEGORY]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTCATEGORY](
	[CategoryID] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [varchar](255) NULL,
	[IconUrl] [varchar](255) NULL,
	[PromotionImageUrl] [varchar](255) NULL,
	[IsFeatured] [bit] NULL,
	[PromotionalTagline] [varchar](255) NULL,
	[ProductAmount] [int] NULL,
	[CareInstructions] [varchar](max) NULL,
	[MinimumPrice] [decimal](18, 2) NULL,
	[MaximumPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROMOTION]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROMOTION](
	[PromotionID] [nvarchar](36) NOT NULL,
	[Amount] [decimal](5, 2) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Code] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[Status] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[PromotionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHELL]    Script Date: 7/10/2024 5:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHELL](
	[ShellID] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[AmountAvailable] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Style] [nvarchar](50) NULL,
	[Metal] [nvarchar](50) NULL,
	[Weight] [decimal](10, 2) NULL,
	[DiamondShape] [nvarchar](100) NULL,
	[TotalDiamonds] [int] NULL,
	[CategoryId] [nvarchar](36) NULL,
	[ImageURL] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShellID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU001', N'john.doe@example.com', N'Do', N'John', N'123 Main St, Anytown', N'123-456-7890', CAST(N'1980-05-18' AS Date), N'Male', 1, N'USA')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU002', N'jane.smith@example.com', N'Smith', N'Jane', N'456 Oak Ave, Newtown', N'987-654-3210', CAST(N'1985-10-20' AS Date), N'Female', 1, N'Canada')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU003', N'michael.jones@example.com', N'Jones', N'Michael', N'789 Elm Rd, Villageville', N'555-123-4567', CAST(N'1992-03-25' AS Date), N'Male', 0, N'UK')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU004', N'emily.brown@example.com', N'Brown', N'Emily', N'321 Pine Ln, Cityville', N'222-333-4444', CAST(N'1988-12-10' AS Date), N'Female', 1, N'Australia')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU005', N'david.wilson@example.com', N'Wilson', N'David', N'567 Cedar Dr, Lakeside', N'777-888-9999', CAST(N'1975-08-07' AS Date), N'Male', 1, N'New Zealand')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU006', N'sarah.nguyen@example.com', N'Nguyen', N'Sarah', N'888 Maple Ave, Hilltop', N'111-222-3333', CAST(N'1990-04-30' AS Date), N'Female', 1, N'Vietnam')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU007', N'roberto.garcia@example.com', N'Garcia', N'Roberto', N'222 Birch St, Rivertown', N'444-555-6666', CAST(N'1983-11-18' AS Date), N'Male', 1, N'Mexico')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU008', N'maria.santos@example.com', N'Santos', N'Maria', N'999 Willow Blvd, Seaside', N'666-777-8888', CAST(N'1987-09-22' AS Date), N'Female', 0, N'Brazil')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU009', N'james.white@example.com', N'White', N'James', N'444 Aspen Rd, Mountainview', N'333-111-2222', CAST(N'1982-06-12' AS Date), N'Male', 1, N'Germany')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU010', N'lisa.thomas@example.com', N'Thomas', N'Lisa', N'555 Oakwood Ave, Lakeshore', N'888-999-0000', CAST(N'1995-01-05' AS Date), N'Female', 1, N'France')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Email], [LastName], [FirstName], [Address], [PhoneNumber], [DateOfBirth], [Gender], [IsActive], [Country]) VALUES (N'CU011', N'john.doe@example.com', N'Do', N'John', N'123 Main St, Anytown', N'123-456-7890', CAST(N'1980-05-18' AS Date), N'Male', 1, N'USA')
GO
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D001', N'Diamond One', N'D', N'VVS1', CAST(1.00 AS Decimal(5, 2)), N'Excellent', N'Scan001', CAST(1000.00 AS Decimal(18, 2)), 10, N'C01', NULL, CAST(N'2024-06-05' AS Date), N'Viet Nam', N'Well', N'Good', N'Nice')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D002', N'Diamond Two', N'E', N'VVS2', CAST(1.50 AS Decimal(5, 2)), N'Very Good', N'Scan002', CAST(2000.00 AS Decimal(18, 2)), 20, N'C02', NULL, CAST(N'2023-05-05' AS Date), N'Viet Nam', N'Well', N'Nice', N'Good')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D003', N'Diamond Three', N'F', N'VS1', CAST(2.00 AS Decimal(5, 2)), N'Good', N'Scan003', CAST(3000.00 AS Decimal(18, 2)), 30, N'C03', NULL, CAST(N'2022-01-02' AS Date), N'Viet Nam', N'Good', N'Nice', N'Well')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D004', N'Diamond Four', N'G', N'VS2', CAST(2.50 AS Decimal(5, 2)), N'Fair', N'Scan004', CAST(4000.00 AS Decimal(18, 2)), 40, N'C04', NULL, CAST(N'2021-06-04' AS Date), N'Viet Nam', N'Good', N'Well', N'Nice')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D005', N'Diamond Five', N'H', N'SI1', CAST(3.00 AS Decimal(5, 2)), N'Poor', N'Scan005', CAST(5000.00 AS Decimal(18, 2)), 50, N'C05', NULL, CAST(N'2020-10-08' AS Date), N'Viet Nam', N'Nice', N'Well', N'Good')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D006', N'Diamond Six', N'I', N'SI2', CAST(3.50 AS Decimal(5, 2)), N'Excellent', N'Scan006', CAST(6000.00 AS Decimal(18, 2)), 60, N'C06', NULL, CAST(N'2023-12-15' AS Date), N'Viet Nam', N'Nice', N'Good', N'Well')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D007', N'Diamond Seven', N'J', N'I1', CAST(4.00 AS Decimal(5, 2)), N'Very Good', N'Scan007', CAST(7000.00 AS Decimal(18, 2)), 70, N'C07', NULL, CAST(N'2022-09-17' AS Date), N'Viet Nam', N'Good', N'Nice', N'Well')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D008', N'Diamond Eight', N'K', N'I2', CAST(4.50 AS Decimal(5, 2)), N'Good', N'Scan008', CAST(8000.00 AS Decimal(18, 2)), 80, N'C01', NULL, CAST(N'2022-11-24' AS Date), N'Viet Nam', N'Nice', N'Well', N'Good')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D009', N'Diamond Nine', N'L', N'I3', CAST(5.00 AS Decimal(5, 2)), N'Fair', N'Scan009', CAST(9000.00 AS Decimal(18, 2)), 90, N'C02', NULL, CAST(N'2023-08-09' AS Date), N'Viet Nam', N'Well', N'Good', N'Nice')
INSERT [dbo].[DIAMOND] ([DiamondID], [Name], [Color], [Clarity], [Carat], [Cut], [CertificateScan], [Cost], [AmountAvailable], [CategoryID], [ImageUrl], [DateAcquired], [CertifyingAuthority], [Polish], [Symmetry], [Fluorescence]) VALUES (N'D010', N'Diamond Ten', N'M', N'VVS1', CAST(5.50 AS Decimal(5, 2)), N'Poor', N'Scan010', CAST(10000.00 AS Decimal(18, 2)), 100, N'C03', NULL, CAST(N'2021-10-22' AS Date), N'Viet Nam', N'Nice', N'Well', N'Good')
GO
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD001', N'O001', CAST(1500.00 AS Decimal(18, 2)), N'D001', N'S001', N'D002', 1, CAST(1.50 AS Decimal(5, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD002', N'O002', CAST(2500.00 AS Decimal(18, 2)), N'D002', N'S002', N'D003', 2, CAST(1.00 AS Decimal(5, 2)), CAST(175.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(5, 2)), N'Discount applied')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD003', N'O003', CAST(4000.00 AS Decimal(18, 2)), N'D003', N'S003', N'D004', 1, CAST(2.00 AS Decimal(5, 2)), CAST(700.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD004', N'O004', CAST(4500.00 AS Decimal(18, 2)), N'D004', N'S004', N'D005', 3, CAST(1.25 AS Decimal(5, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(5, 2)), N'Special offer')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD005', N'O005', CAST(5500.00 AS Decimal(18, 2)), N'D005', N'S005', N'D006', 1, CAST(1.75 AS Decimal(5, 2)), CAST(800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD006', N'O006', CAST(6500.00 AS Decimal(18, 2)), N'D006', N'S006', N'D007', 2, CAST(1.50 AS Decimal(5, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD007', N'O007', CAST(7500.00 AS Decimal(18, 2)), N'D007', N'S007', N'D008', 1, CAST(1.00 AS Decimal(5, 2)), CAST(900.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD008', N'O008', CAST(8500.00 AS Decimal(18, 2)), N'D008', N'S008', N'D009', 2, CAST(2.50 AS Decimal(5, 2)), CAST(175.00 AS Decimal(18, 2)), CAST(8.00 AS Decimal(5, 2)), N'Promo discount')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD009', N'O009', CAST(9500.00 AS Decimal(18, 2)), N'D009', N'S009', N'D010', 1, CAST(1.75 AS Decimal(5, 2)), CAST(550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD010', N'O010', CAST(10500.00 AS Decimal(18, 2)), N'D010', N'S010', N'D001', 3, CAST(1.20 AS Decimal(5, 2)), CAST(316.67 AS Decimal(18, 2)), CAST(15.00 AS Decimal(5, 2)), N'Christmas discount')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD011', N'O001', CAST(2500.00 AS Decimal(18, 2)), N'D002', N'S002', N'D003', 2, CAST(1.50 AS Decimal(5, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD012', N'O001', CAST(2500.00 AS Decimal(18, 2)), N'D002', N'S002', N'D003', 2, CAST(1.50 AS Decimal(5, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD014', N'O001', CAST(1500.00 AS Decimal(18, 2)), N'D001', N'S001', N'D002', 1, CAST(1.50 AS Decimal(5, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD015', N'O001', CAST(1500.00 AS Decimal(18, 2)), N'D001', N'S001', N'D002', 1, CAST(1.50 AS Decimal(5, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD016', N'O001', CAST(2500.00 AS Decimal(18, 2)), N'D002', N'S002', N'D003', 2, CAST(1.50 AS Decimal(5, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), N'')
INSERT [dbo].[ORDERDETAIL] ([OrderDetailID], [OrderID], [LineTotal], [MainDiamondID], [ShellID], [SubDiamondID], [Quantity], [UnitWeight], [UnitPrice], [DiscountPercentage], [Note]) VALUES (N'OD022', N'O004', CAST(4500.00 AS Decimal(18, 2)), N'D004', N'S004', N'D005', 3, CAST(1.25 AS Decimal(5, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(5, 2)), N'Special offer')
GO
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O001', N'CU001', CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), N'Cash', N'123 Maple St', CAST(12000.00 AS Decimal(18, 2)), N'Paid', N'Completed', N'P001', N'Make a beautiful unique product')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O002', N'CU002', CAST(N'2024-02-03T00:00:00.0000000' AS DateTime2), N'Bank', N'456 Pine St', CAST(2500.00 AS Decimal(18, 2)), N'Paid', N'Delivering', N'P002', N'Edited Order')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O003', N'CU003', CAST(N'2024-03-01T00:00:00.0000000' AS DateTime2), N'Cash', N'789 Elm St', CAST(4000.00 AS Decimal(18, 2)), N'Paid', N'Cancelled', N'P003', N'')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O004', N'CU004', CAST(N'2024-04-01T00:00:00.0000000' AS DateTime2), N'Bank', N'101 Oak St', CAST(9000.00 AS Decimal(18, 2)), N'NotPaid', N'Delivering', NULL, N'')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O005', N'CU005', CAST(N'2024-05-01T00:00:00.0000000' AS DateTime2), N'Cash', N'202 Birch St', CAST(5500.00 AS Decimal(18, 2)), N'Paid', N'Completed', N'P005', N'')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O006', N'CU006', CAST(N'2024-06-01T00:00:00.0000000' AS DateTime2), N'Bank', N'303 Cedar St', CAST(6500.00 AS Decimal(18, 2)), N'NotPaid', N'Delivering', N'P006', N'')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O007', N'CU007', CAST(N'2024-07-01T00:00:00.0000000' AS DateTime2), N'Cash', N'404 Spruce St', CAST(7500.00 AS Decimal(18, 2)), N'Paid', N'Completed', N'P007', N'')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O008', N'CU008', CAST(N'2024-08-01T00:00:00.0000000' AS DateTime2), N'Bank', N'505 Redwood St', CAST(8500.00 AS Decimal(18, 2)), N'NotPaid', N'Delivering', N'P008', NULL)
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O009', N'CU009', CAST(N'2024-09-01T00:00:00.0000000' AS DateTime2), N'Cash', N'606 Willow St', CAST(9500.00 AS Decimal(18, 2)), N'Paid', N'Completed', N'P009', NULL)
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O010', N'CU010', CAST(N'2024-10-01T00:00:00.0000000' AS DateTime2), N'Bank', N'707 Maple St', CAST(10500.00 AS Decimal(18, 2)), N'NotPaid', N'Delivering', N'P010', NULL)
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O011', N'CU003', CAST(N'2024-03-01T00:00:00.0000000' AS DateTime2), N'Cash', N'789 Elm St', CAST(0.00 AS Decimal(18, 2)), N'Paid', N'Cancelled', N'P003', N'')
INSERT [dbo].[ORDERS] ([OrderID], [CustomerID], [Date], [PaymentMethod], [ShippingAddress], [TotalPrice], [PaymentStatus], [ShippingStatus], [PromotionID], [OrderDescription]) VALUES (N'O012', N'CU001', CAST(N'2024-04-01T00:00:00.0000000' AS DateTime2), N'Bank', N'101 Oak St', CAST(0.00 AS Decimal(18, 2)), N'NotPaid', N'Delivering', NULL, N'')
GO
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C01', N'Engagement Rings', N'Beautiful engagement rings for your special moment', N'https://example.com/icons/engagement_rings.png', N'https://example.com/promo/engagement_rings.png', 1, N'Make your proposal unforgettable', 150, N'Keep away from chemicals. Clean with a soft cloth.', CAST(500.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C02', N'Wedding Bands', N'Elegant wedding bands to symbolize your eternal love', N'https://example.com/icons/wedding_bands.png', N'https://example.com/promo/wedding_bands.png', 1, N'Celebrate your love with our wedding bands', 200, N'Avoid scratches and store in a safe place.', CAST(300.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C03', N'Diamond Earrings', N'Exquisite diamond earrings for every occasion', N'https://example.com/icons/diamond_earrings.png', N'https://example.com/promo/diamond_earrings.png', 0, N'Shine bright with our diamond earrings', 100, N'Keep away from heat. Clean regularly.', CAST(200.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C04', N'Diamond Necklaces', N'Stunning diamond necklaces to make a statement', N'https://example.com/icons/diamond_necklaces.png', N'https://example.com/promo/diamond_necklaces.png', 1, N'Adorn yourself with elegance', 120, N'Store in a jewelry box. Clean with a soft cloth.', CAST(600.00 AS Decimal(18, 2)), CAST(60000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C05', N'Bracelets', N'Beautiful diamond bracelets for every wrist', N'https://example.com/icons/diamond_bracelets.png', N'https://example.com/promo/diamond_bracelets.png', 0, N'Add a touch of sparkle to your outfit', 80, N'Avoid water and chemicals. Clean with a soft cloth.', CAST(250.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C06', N'Watches', N'Luxurious watches with diamond embellishments', N'https://example.com/icons/watches.png', N'https://example.com/promo/watches.png', 1, N'Keep time with elegance', 50, N'Avoid water. Clean with a soft cloth.', CAST(1000.00 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRODUCTCATEGORY] ([CategoryID], [Name], [Description], [IconUrl], [PromotionImageUrl], [IsFeatured], [PromotionalTagline], [ProductAmount], [CareInstructions], [MinimumPrice], [MaximumPrice]) VALUES (N'C07', N'Pendants', N'Charming diamond pendants for any occasion', N'https://example.com/icons/pendants.png', N'https://example.com/promo/pendants.png', 1, N'Make a statement with our pendants', 90, N'Store in a jewelry box. Clean with a soft cloth.', CAST(300.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P001', CAST(10.00 AS Decimal(5, 2)), CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2), N'New Year Promotion', N'NY2024', NULL, NULL, NULL, N'Happy New Year')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P002', CAST(15.00 AS Decimal(5, 2)), CAST(N'2024-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-28T00:00:00.0000000' AS DateTime2), N'Valentine Day Sale', N'V2024', NULL, NULL, NULL, N'Valentine Gift')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P003', CAST(20.00 AS Decimal(5, 2)), CAST(N'2024-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-03-31T00:00:00.0000000' AS DateTime2), N'Spring Sale', N'SPRING2024', NULL, NULL, NULL, N'Warn Spring')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P004', CAST(25.00 AS Decimal(5, 2)), CAST(N'2024-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-04-30T00:00:00.0000000' AS DateTime2), N'Easter Sale', N'EASTER2024', NULL, NULL, NULL, N'Celebrate Easter')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P005', CAST(30.00 AS Decimal(5, 2)), CAST(N'2024-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-05-31T00:00:00.0000000' AS DateTime2), N'May Day Sale', N'MAY2024', NULL, NULL, NULL, N'Hello May Day')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P006', CAST(35.00 AS Decimal(5, 2)), CAST(N'2024-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-06-30T00:00:00.0000000' AS DateTime2), N'Summer Sale', N'SUMMER2024', NULL, NULL, NULL, N'Hi Summer')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P007', CAST(40.00 AS Decimal(5, 2)), CAST(N'2024-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-31T00:00:00.0000000' AS DateTime2), N'July Sale', N'JULY2024', NULL, NULL, NULL, N'Happy July')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P008', CAST(45.00 AS Decimal(5, 2)), CAST(N'2024-08-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), N'August Sale', N'AUG2024', NULL, NULL, NULL, N'Happy August')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P009', CAST(50.00 AS Decimal(5, 2)), CAST(N'2024-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-30T00:00:00.0000000' AS DateTime2), N'Fall Sale', N'FALL2024', NULL, NULL, NULL, N'Fall Discount')
INSERT [dbo].[PROMOTION] ([PromotionID], [Amount], [ValidFrom], [ValidTo], [Description], [Code], [CreatedBy], [CreatedDate], [Status], [Name]) VALUES (N'P010', CAST(55.00 AS Decimal(5, 2)), CAST(N'2024-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T00:00:00.0000000' AS DateTime2), N'Halloween Sale', N'HALLOWEEN2024', NULL, NULL, NULL, N'Horror Halloween')
GO
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S001', N'Shell One', CAST(100.00 AS Decimal(18, 2)), 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S002', N'Shell Two', CAST(200.00 AS Decimal(18, 2)), 40, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S003', N'Shell Three', CAST(300.00 AS Decimal(18, 2)), 30, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S004', N'Shell Four', CAST(400.00 AS Decimal(18, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S005', N'Shell Five', CAST(500.00 AS Decimal(18, 2)), 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S006', N'Shell Six', CAST(600.00 AS Decimal(18, 2)), 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S007', N'Shell Seven', CAST(700.00 AS Decimal(18, 2)), 25, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S008', N'Shell Eight', CAST(800.00 AS Decimal(18, 2)), 35, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S009', N'Shell Nine', CAST(900.00 AS Decimal(18, 2)), 45, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S010', N'Shell Ten', CAST(1000.00 AS Decimal(18, 2)), 55, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S012', N'Shell One', CAST(100.00 AS Decimal(18, 2)), 50, N'', NULL, N'', CAST(3.00 AS Decimal(10, 2)), N'', 10, N'C02', N'')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S1', N'Classic Halo Engagement Ring', CAST(1500.00 AS Decimal(18, 2)), 20, N'A timeless halo ring with a round diamond center.', NULL, N'Platinum', CAST(5.50 AS Decimal(10, 2)), N'Round', 45, N'C01', N'http://example.com/images/halo_ring.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S10', N'Hoop Diamond Earrings', CAST(1500.00 AS Decimal(18, 2)), 15, N'Glamorous hoop earrings with channel set diamonds.', NULL, N'Platinum', CAST(4.50 AS Decimal(10, 2)), N'Round', 20, N'C03', N'http://example.com/images/hoop_earrings.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S11', N'Diamond Infinity Necklace', CAST(2200.00 AS Decimal(18, 2)), 10, N'A stylish infinity necklace with pave diamonds.', NULL, N'White Gold', CAST(3.70 AS Decimal(10, 2)), N'Round', 30, N'C04', N'http://example.com/images/infinity_necklace.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S12', N'Cuff Diamond Bracelet', CAST(3000.00 AS Decimal(18, 2)), 8, N'An exquisite cuff bracelet with bezel set diamonds.', NULL, N'Yellow Gold', CAST(12.00 AS Decimal(10, 2)), N'Round', 25, N'C05', N'http://example.com/images/cuff_bracelet.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S13', N'Teardrop Diamond Pendant', CAST(1100.00 AS Decimal(18, 2)), 15, N'An elegant teardrop-shaped diamond pendant.', NULL, N'Platinum', CAST(3.20 AS Decimal(10, 2)), N'Pear', 1, N'C07', N'http://example.com/images/teardrop_pendant.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S2', N'Eternity Wedding Band', CAST(1200.00 AS Decimal(18, 2)), 25, N'A stunning eternity band with round diamonds.', NULL, N'White Gold', CAST(3.20 AS Decimal(10, 2)), N'Round', 30, N'C02', N'http://example.com/images/eternity_band.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S3', N'Stud Diamond Earrings', CAST(800.00 AS Decimal(18, 2)), 30, N'Elegant stud earrings with princess cut diamonds.', NULL, N'Yellow Gold', CAST(2.00 AS Decimal(10, 2)), N'Princess', 2, N'C03', N'http://example.com/images/stud_earrings.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S4', N'Solitaire Diamond Necklace', CAST(1800.00 AS Decimal(18, 2)), 15, N'A solitaire diamond pendant necklace.', NULL, N'Rose Gold', CAST(4.00 AS Decimal(10, 2)), N'Round', 1, N'C04', N'http://example.com/images/solitaire_necklace.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S5', N'Diamond Tennis Bracelet', CAST(2500.00 AS Decimal(18, 2)), 10, N'A luxurious diamond tennis bracelet.', NULL, N'Platinum', CAST(10.50 AS Decimal(10, 2)), N'Round', 50, N'C05', N'http://example.com/images/tennis_bracelet.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S6', N'Diamond Bezel Watch', CAST(3500.00 AS Decimal(18, 2)), 5, N'A sophisticated watch with a diamond bezel.', NULL, N'Stainless Steel', CAST(120.00 AS Decimal(10, 2)), N'Round', 60, N'C06', N'http://example.com/images/diamond_watch.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S7', N'Heart Diamond Pendant', CAST(950.00 AS Decimal(18, 2)), 18, N'A charming heart-shaped diamond pendant.', NULL, N'White Gold', CAST(3.00 AS Decimal(10, 2)), N'Heart', 1, N'C07', N'http://example.com/images/heart_pendant.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S8', N'Vintage Solitaire Engagement Ring', CAST(2000.00 AS Decimal(18, 2)), 12, N'A vintage-style solitaire ring with an emerald cut diamond.', NULL, N'Yellow Gold', CAST(6.00 AS Decimal(10, 2)), N'Emerald', 1, N'C01', N'http://example.com/images/vintage_solitaire_ring.jpg')
INSERT [dbo].[SHELL] ([ShellID], [Name], [Price], [AmountAvailable], [Description], [Style], [Metal], [Weight], [DiamondShape], [TotalDiamonds], [CategoryId], [ImageURL]) VALUES (N'S9', N'Pave Set Wedding Band', CAST(1100.00 AS Decimal(18, 2)), 20, N'A pave set wedding band with small round diamonds.', NULL, N'Rose Gold', CAST(2.80 AS Decimal(10, 2)), N'Round', 40, N'C02', N'http://example.com/images/pave_set_band.jpg')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PRODUCTC__737584F618942B8A]    Script Date: 7/10/2024 5:48:16 PM ******/
ALTER TABLE [dbo].[PRODUCTCATEGORY] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRODUCTCATEGORY] ADD  DEFAULT ((0)) FOR [IsFeatured]
GO
ALTER TABLE [dbo].[DIAMOND]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[PRODUCTCATEGORY] ([CategoryID])
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD FOREIGN KEY([MainDiamondID])
REFERENCES [dbo].[DIAMOND] ([DiamondID])
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[ORDERS] ([OrderID])
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD FOREIGN KEY([ShellID])
REFERENCES [dbo].[SHELL] ([ShellID])
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD FOREIGN KEY([SubDiamondID])
REFERENCES [dbo].[DIAMOND] ([DiamondID])
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CUSTOMER] ([CustomerID])
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD FOREIGN KEY([PromotionID])
REFERENCES [dbo].[PROMOTION] ([PromotionID])
GO
ALTER TABLE [dbo].[SHELL]  WITH CHECK ADD  CONSTRAINT [FK_CategoryID] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[PRODUCTCATEGORY] ([CategoryID])
GO
ALTER TABLE [dbo].[SHELL] CHECK CONSTRAINT [FK_CategoryID]
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD CHECK  (([DiscountPercentage]>=(0) AND [DiscountPercentage]<=(100)))
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD CHECK  (([PaymentMethod]='Bank' OR [PaymentMethod]='Cash'))
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD CHECK  (([PaymentStatus]='NotPaid' OR [PaymentStatus]='Paid'))
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD CHECK  (([ShippingStatus]='Cancelled' OR [ShippingStatus]='Completed' OR [ShippingStatus]='Delivering'))
GO
ALTER TABLE [dbo].[PROMOTION]  WITH CHECK ADD CHECK  (([Amount]>=(0) AND [Amount]<=(100)))
GO
ALTER TABLE [dbo].[PROMOTION]  WITH CHECK ADD CHECK  (([Status]='Inactive' OR [Status]='Active'))
GO
USE [master]
GO
ALTER DATABASE [Net1814_212_3_Diamond] SET  READ_WRITE 
GO
