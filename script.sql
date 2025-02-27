USE [master]
GO
/****** Object:  Database [HutechQuestionBank]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE DATABASE [HutechQuestionBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HutechQuestionBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\HutechQuestionBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HutechQuestionBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\HutechQuestionBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HutechQuestionBank] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HutechQuestionBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HutechQuestionBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HutechQuestionBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HutechQuestionBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HutechQuestionBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HutechQuestionBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HutechQuestionBank] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HutechQuestionBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HutechQuestionBank] SET  MULTI_USER 
GO
ALTER DATABASE [HutechQuestionBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HutechQuestionBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HutechQuestionBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HutechQuestionBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HutechQuestionBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HutechQuestionBank] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HutechQuestionBank] SET QUERY_STORE = ON
GO
ALTER DATABASE [HutechQuestionBank] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HutechQuestionBank]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/28/2024 4:13:56 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[KhoaID] [uniqueidentifier] NULL,
	[Img] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[MaCauHoi] [uniqueidentifier] NOT NULL,
	[MaPhan] [uniqueidentifier] NOT NULL,
	[MaSoCauHoi] [int] NOT NULL,
	[NoiDung] [nvarchar](max) NULL,
	[HoanVi] [bit] NOT NULL,
	[CapDo] [smallint] NOT NULL,
	[SoCauHoiCon] [int] NOT NULL,
	[DoPhanCachCauHoi] [float] NULL,
	[MaCauHoiCha] [uniqueidentifier] NULL,
	[XoaTamCauHoi] [bit] NULL,
	[SoLanDuocThi] [int] NULL,
	[SoLanDung] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NgaySua] [datetime] NULL,
	[CloId] [int] NULL,
 CONSTRAINT [PK_CauHoi] PRIMARY KEY CLUSTERED 
(
	[MaCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauTraLoi]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauTraLoi](
	[MaCauTraLoi] [uniqueidentifier] NOT NULL,
	[MaCauHoi] [uniqueidentifier] NOT NULL,
	[NoiDung] [nvarchar](max) NULL,
	[ThuTu] [int] NOT NULL,
	[LaDapAn] [bit] NOT NULL,
	[HoanVi] [bit] NOT NULL,
 CONSTRAINT [PK_CauTraLoi] PRIMARY KEY CLUSTERED 
(
	[MaCauTraLoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDeThi]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDeThi](
	[MaDeThi] [uniqueidentifier] NOT NULL,
	[MaPhan] [uniqueidentifier] NOT NULL,
	[MaCauHoi] [uniqueidentifier] NOT NULL,
	[ThuTu] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDeThi] PRIMARY KEY CLUSTERED 
(
	[MaDeThi] ASC,
	[MaPhan] ASC,
	[MaCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clos]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clos](
	[CloId] [int] IDENTITY(1,1) NOT NULL,
	[CloName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clos] PRIMARY KEY CLUSTERED 
(
	[CloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeThi]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeThi](
	[MaDeThi] [uniqueidentifier] NOT NULL,
	[MaMonHoc] [uniqueidentifier] NOT NULL,
	[TenDeThi] [nvarchar](250) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[DaDuyet] [bit] NULL,
 CONSTRAINT [PK_DeThi] PRIMARY KEY CLUSTERED 
(
	[MaDeThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[MaFile] [uniqueidentifier] NOT NULL,
	[MaCauHoi] [uniqueidentifier] NULL,
	[TenFile] [nvarchar](250) NULL,
	[LoaiFile] [int] NULL,
	[MaCauTraLoi] [uniqueidentifier] NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[MaFile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [uniqueidentifier] NOT NULL,
	[TenKhoa] [nvarchar](250) NOT NULL,
	[XoaTamKhoa] [bit] NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaTran]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaTran](
	[Id] [uniqueidentifier] NOT NULL,
	[MaMonHoc] [uniqueidentifier] NOT NULL,
	[MaPhan] [uniqueidentifier] NOT NULL,
	[Clo1] [int] NOT NULL,
	[Clo2] [int] NOT NULL,
	[Clo3] [int] NOT NULL,
	[SoCauHoi] [int] NOT NULL,
	[TenPhan] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MaTran] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMonHoc] [uniqueidentifier] NOT NULL,
	[MaKhoa] [uniqueidentifier] NOT NULL,
	[MaSoMonHoc] [nvarchar](50) NOT NULL,
	[TenMonHoc] [nvarchar](250) NOT NULL,
	[XoaTamMonHoc] [bit] NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phan]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phan](
	[MaPhan] [uniqueidentifier] NOT NULL,
	[MaMonHoc] [uniqueidentifier] NOT NULL,
	[TenPhan] [nvarchar](250) NOT NULL,
	[NoiDung] [nvarchar](max) NULL,
	[ThuTu] [int] NOT NULL,
	[SoLuongCauHoi] [int] NOT NULL,
	[MaPhanCha] [uniqueidentifier] NULL,
	[MaSoPhan] [int] NULL,
	[XoaTamPhan] [bit] NULL,
	[LaCauHoiNhom] [bit] NOT NULL,
 CONSTRAINT [PK_Phan] PRIMARY KEY CLUSTERED 
(
	[MaPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YeuCauRutTrich]    Script Date: 5/28/2024 4:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YeuCauRutTrich](
	[MaYeuCauDe] [uniqueidentifier] NOT NULL,
	[HoTenGiaoVien] [nvarchar](50) NULL,
	[NoiDungRutTrich] [nvarchar](max) NULL,
	[NgayLay] [datetime] NULL,
 CONSTRAINT [PK_YeuCauDe] PRIMARY KEY CLUSTERED 
(
	[MaYeuCauDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240507173919_v1', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240508060733_v2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240513081721_v3', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240526120446_v1', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240526120557_v2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240528085714_v3', N'8.0.4')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8a49199b-ceff-4a03-8d4c-71ddb2690b2c', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bc7c1084-b114-4674-9a03-759887333fbc', N'Member', N'MEMBER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e11e581d-dd92-41e6-8b6e-261089aa599c', N'Manager', N'MANAGER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ce60a5d-31a8-4930-927d-386c74362a88', N'8a49199b-ceff-4a03-8d4c-71ddb2690b2c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b77623e8-ba5c-4b07-b836-ae32720bddbf', N'8a49199b-ceff-4a03-8d4c-71ddb2690b2c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'df73a01f-7fad-4f78-9b84-093459d13981', N'8a49199b-ceff-4a03-8d4c-71ddb2690b2c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ce60a5d-31a8-4930-927d-386c74362a88', N'e11e581d-dd92-41e6-8b6e-261089aa599c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9e9415f-2d44-4e50-b38c-d5f2881e1a1a', N'e11e581d-dd92-41e6-8b6e-261089aa599c')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Address], [KhoaID], [Img], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8ce60a5d-31a8-4930-927d-386c74362a88', N'phanhuunghia', N'dlbd', N'cd018129-5dc0-45ef-989e-b06539d0cde4', N'1.jpg', N'aihgn123', N'AIHGN123', N'phanhuunghia12.1tpk@gmail.com', N'PHANHUUNGHIA12.1TPK@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEMlFI0kYLIX3+mN2Xk6DrKx7O51evtSGk7kpV+0HogO+zUzDFvgODPtC8Jhf7PKRHw==', N'JBXXEGSQA2IEJ5YDBQQVRVDTWS7HUNWI', N'f47a0de6-a333-4e63-a475-ce1be4a7eef0', N'1234567890', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Address], [KhoaID], [Img], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b77623e8-ba5c-4b07-b836-ae32720bddbf', N'nguyen thanh tuoi', N'aaaaaaaaaaa', N'fc1fe637-5112-437f-bb40-0b0b4f68cd73', NULL, N'thanhtuoi1', N'THANHTUOI1', N'thanhtuoi852123@gmail.com', N'THANHTUOI852123@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEG8SrcYwGnqJd1OJt/e9/dnBG9nU7e5W0V0pfJpsuVG+bucQkUxP022X697Tvrm49A==', N'UJF7MXBS5OIRENMTEYNPTGSEBIVMX2VF', N'707fb967-eed8-4aaa-9657-389bc02181f5', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Address], [KhoaID], [Img], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b9e9415f-2d44-4e50-b38c-d5f2881e1a1a', N'nguyenthanhtuoi', N'aaaaaaaaa', N'cd018129-5dc0-45ef-989e-b06539d0cde4', NULL, N'thanhtuoi', N'THANHTUOI', N'nguyenthanhtuoi1230@gmail.com', N'NGUYENTHANHTUOI1230@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEPAjUt3WlwS/VYmg83NSMXyvp5qLHkKdZw5YYnTWxaHB51yfhIysAZfCh7u2eca00Q==', N'XE3OAW2MCTH6W2JFCWSPCQKKYSJ3WS2G', N'3c088c83-7ed7-4f1b-aeb2-af6ec5a56487', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Address], [KhoaID], [Img], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'df73a01f-7fad-4f78-9b84-093459d13981', N'nttuoi', N'bd', N'fc1fe637-5112-437f-bb40-0b0b4f68cd73', NULL, N'tuoidz', N'TUOIDZ', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAtx5jgL+mKtni3WvQX+lL/NKfGAfLnlvOoREu+CcvlOewZJN0RhqIbKqOlx5RNpRg==', N'H3ZZNE67QEGNZ35UOUGQRJBECW4PHTKU', N'83f2b8a4-d216-42c3-a160-f682ca36de9b', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'96ab03c3-da1f-48b4-b630-05fe8659a152', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', 7, N'<p>đ&acirc;y l&agrave; c&acirc;u hỏi clo3 phần 2</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:44:54.607' AS DateTime), CAST(N'2024-05-28T14:44:54.607' AS DateTime), 3)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', 9, N'<p>đ&acirc;y l&agrave; c&acirc;u hỏi clo 3 phần 3</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:45:46.487' AS DateTime), CAST(N'2024-05-28T14:45:46.487' AS DateTime), 3)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'f595599e-892c-4adb-9d87-1d4d01b9317a', N'10670948-b137-468d-966a-dce24ee842c2', 1, N'<p>Đ&acirc;y l&agrave; c&acirc;u hỏi CLO1&nbsp;</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:42:17.853' AS DateTime), CAST(N'2024-05-28T14:42:17.853' AS DateTime), 1)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'a67b3551-4374-4672-98a0-286077eda0a5', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', 10, N'<p>1</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T16:05:38.367' AS DateTime), CAST(N'2024-05-28T16:05:38.367' AS DateTime), NULL)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'342f53bf-8767-4687-9b85-32161943f820', N'10670948-b137-468d-966a-dce24ee842c2', 3, N'<p>Đ&acirc;y l&agrave; c&acirc;u hỏi clo2 phan 1</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:43:04.700' AS DateTime), CAST(N'2024-05-28T14:43:04.700' AS DateTime), 2)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', N'10670948-b137-468d-966a-dce24ee842c2', 4, N'<p>đ&acirc;y l&agrave; c&acirc;u hỏi clo 3 phan 1</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:43:27.280' AS DateTime), CAST(N'2024-05-28T14:43:27.280' AS DateTime), 3)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'e6b36c35-9f1d-45e7-8927-5124276c3d52', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', 11, N'<p>1</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T16:05:45.630' AS DateTime), CAST(N'2024-05-28T16:05:45.630' AS DateTime), NULL)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'7a3a2fba-7fbe-4492-bde0-6e2c6038aa4a', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', 12, N'<p>323123</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T16:06:25.497' AS DateTime), CAST(N'2024-05-28T16:06:25.497' AS DateTime), NULL)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'74d69239-d475-4d01-b3c3-6e3bfbf69529', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', 5, N'<p>đ&acirc;y l&agrave; c&acirc;u hỏi clo1 phan 2</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:43:41.170' AS DateTime), CAST(N'2024-05-28T14:43:41.170' AS DateTime), 1)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'abe45086-4a78-4bea-9ac6-756f13307fb9', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', 8, N'<p>đ&acirc;y l&agrave; c&acirc;u hỏi clo 1 phần 3</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:45:34.393' AS DateTime), CAST(N'2024-05-28T14:45:34.393' AS DateTime), 1)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'747355d1-dc7c-4d26-ba96-b17f06094adc', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', 6, N'<p>đ&acirc;y l&agrave; c&acirc;u hỏi clo2 phan 2</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:43:59.133' AS DateTime), CAST(N'2024-05-28T14:43:59.133' AS DateTime), 2)
INSERT [dbo].[CauHoi] ([MaCauHoi], [MaPhan], [MaSoCauHoi], [NoiDung], [HoanVi], [CapDo], [SoCauHoiCon], [DoPhanCachCauHoi], [MaCauHoiCha], [XoaTamCauHoi], [SoLanDuocThi], [SoLanDung], [NgayTao], [NgaySua], [CloId]) VALUES (N'c91e3443-7b48-42ca-b531-f6376abbb20d', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', 2, N'<p>Đ&acirc;y l&agrave; c&acirc;u hỏi CLO2 Phần 3 .</p>', 0, 0, 0, 0, N'00000000-0000-0000-0000-000000000000', 0, 0, 0, CAST(N'2024-05-28T14:42:43.297' AS DateTime), CAST(N'2024-05-28T14:42:43.297' AS DateTime), 2)
GO
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'90e3cb07-2444-4e2e-b22e-008b77d14c21', N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', N'1', 1, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'2a05d313-fa40-4c9f-b517-04fc4c3a546b', N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'9c0defcb-e974-4aeb-a0d8-072790392349', N'7a3a2fba-7fbe-4492-bde0-6e2c6038aa4a', N'2', 4, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'03cfebcf-226e-49bb-8f4b-0e0019b84312', N'96ab03c3-da1f-48b4-b630-05fe8659a152', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'8ebe261d-6c80-4071-a879-2e716ad7f6b8', N'a67b3551-4374-4672-98a0-286077eda0a5', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'076df817-e314-487f-ae09-318ee28687e6', N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'406bbde2-d0d5-4f73-9b9a-323039e2e2f4', N'96ab03c3-da1f-48b4-b630-05fe8659a152', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'f7b25799-388d-49f1-b468-3c8429fba7f8', N'74d69239-d475-4d01-b3c3-6e3bfbf69529', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'd817cbf0-6ffa-4c64-b948-41d8fee51c2c', N'c91e3443-7b48-42ca-b531-f6376abbb20d', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'0dd431e0-4b73-4e8d-954e-48a5155002b0', N'7a3a2fba-7fbe-4492-bde0-6e2c6038aa4a', N'2', 1, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'4eaa7c26-bf05-4862-a0bc-499f5dbf4313', N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'ffd19610-1944-467c-a0c6-532800784c67', N'e6b36c35-9f1d-45e7-8927-5124276c3d52', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'aa85c190-2ed3-482d-9dc6-5767b9c1de85', N'abe45086-4a78-4bea-9ac6-756f13307fb9', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'47935546-c074-4860-bba5-5b408e8d1e64', N'342f53bf-8767-4687-9b85-32161943f820', N'1', 1, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'6e8fed3d-3da1-4b4b-90e4-5cd05d0e9eec', N'747355d1-dc7c-4d26-ba96-b17f06094adc', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'7ee0da29-94eb-41f1-9dd2-5e17d15be628', N'c91e3443-7b48-42ca-b531-f6376abbb20d', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'e51ca314-89b8-4078-831d-5e56510184f5', N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'20c35077-7a80-4165-990b-5ebb2883594e', N'f595599e-892c-4adb-9d87-1d4d01b9317a', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'4647e38d-1be8-46f8-ad0a-62c4ad983de3', N'abe45086-4a78-4bea-9ac6-756f13307fb9', N'1', 1, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'33b46c50-f77e-452e-b64d-68e1185821fa', N'e6b36c35-9f1d-45e7-8927-5124276c3d52', N'1', 1, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'd83d9eaa-ae50-4272-a202-6bc8b0681532', N'a67b3551-4374-4672-98a0-286077eda0a5', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'1b0761e8-ab97-4d4e-a453-75a865779ce6', N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'785c362d-966b-47ea-9299-790f049dba4a', N'abe45086-4a78-4bea-9ac6-756f13307fb9', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'9d2e95d1-4604-49ea-a916-814918770cbb', N'a67b3551-4374-4672-98a0-286077eda0a5', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'b75682c3-77df-42b1-988e-81ba271d20ba', N'342f53bf-8767-4687-9b85-32161943f820', N'1', 4, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'f740547b-e69c-40f4-a401-82feb196578b', N'f595599e-892c-4adb-9d87-1d4d01b9317a', N'1', 1, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'7afe9fa3-9c09-4536-9b85-94114455815c', N'f595599e-892c-4adb-9d87-1d4d01b9317a', N'1', 4, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'30633ae7-f1d2-41c8-a702-9b0ef949e4f0', N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'0d8c4074-1dda-46ea-9198-a3d8d14f523d', N'7a3a2fba-7fbe-4492-bde0-6e2c6038aa4a', N'2', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'fe9d98d2-8283-46ca-99ff-a421ce21a1dd', N'747355d1-dc7c-4d26-ba96-b17f06094adc', N'1', 1, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'7ed1c9f3-c742-4275-8307-a57f3307a5b8', N'747355d1-dc7c-4d26-ba96-b17f06094adc', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'2d640b10-dba3-4908-bfa7-aca91a1bef75', N'f595599e-892c-4adb-9d87-1d4d01b9317a', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'4650f7f5-66ce-4386-82b7-afca5d2b1daa', N'342f53bf-8767-4687-9b85-32161943f820', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'cfcb3997-8284-4c73-907c-b0db6691bf49', N'a67b3551-4374-4672-98a0-286077eda0a5', N'1', 1, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'4541f650-a99c-4233-bd36-b57164df037a', N'74d69239-d475-4d01-b3c3-6e3bfbf69529', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'3300aa35-1450-45d5-a155-b6eb2c6e0b82', N'abe45086-4a78-4bea-9ac6-756f13307fb9', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'3ada6f7a-bc4c-4b29-b475-c2de55e2bd9d', N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', N'1', 1, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'f2fe3159-c259-4ab4-81cb-c3274d72f43e', N'74d69239-d475-4d01-b3c3-6e3bfbf69529', N'1', 1, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'a7748135-3565-47a6-b9a3-cac738ce67be', N'e6b36c35-9f1d-45e7-8927-5124276c3d52', N'1', 3, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'03a0f73e-f604-4458-84ae-d13a58d0b0c2', N'74d69239-d475-4d01-b3c3-6e3bfbf69529', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'efd1b2a5-2654-406b-891f-d868bd945385', N'c91e3443-7b48-42ca-b531-f6376abbb20d', N'1', 1, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'b9315a69-2806-468c-92e3-db4751263c9f', N'7a3a2fba-7fbe-4492-bde0-6e2c6038aa4a', N'2', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'ab01764d-f215-4793-b1ba-dc6ed1d956a9', N'96ab03c3-da1f-48b4-b630-05fe8659a152', N'1', 2, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'32c56afb-e7a7-400d-9165-e56e614c218b', N'96ab03c3-da1f-48b4-b630-05fe8659a152', N'1', 1, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'6c931783-60be-4401-b421-e8f5076b279e', N'747355d1-dc7c-4d26-ba96-b17f06094adc', N'1', 4, 0, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'c49ef881-7d93-4afe-8308-f103c4ccfb47', N'c91e3443-7b48-42ca-b531-f6376abbb20d', N'1', 4, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'bf0cbdf5-e574-49c0-be7e-f665f0fbd1ae', N'e6b36c35-9f1d-45e7-8927-5124276c3d52', N'1', 4, 1, 0)
INSERT [dbo].[CauTraLoi] ([MaCauTraLoi], [MaCauHoi], [NoiDung], [ThuTu], [LaDapAn], [HoanVi]) VALUES (N'aa2728b9-a5b4-4ae3-ae32-fc575495c5f2', N'342f53bf-8767-4687-9b85-32161943f820', N'1', 2, 0, 0)
GO
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', 2)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'abe45086-4a78-4bea-9ac6-756f13307fb9', 3)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'c91e3443-7b48-42ca-b531-f6376abbb20d', 1)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', N'747355d1-dc7c-4d26-ba96-b17f06094adc', 4)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'10670948-b137-468d-966a-dce24ee842c2', N'f595599e-892c-4adb-9d87-1d4d01b9317a', 6)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'10670948-b137-468d-966a-dce24ee842c2', N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', 5)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'6366cdd2-eaa8-4e0e-ab60-0736aaf8d520', 3)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'e6b36c35-9f1d-45e7-8927-5124276c3d52', 1)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'c91e3443-7b48-42ca-b531-f6376abbb20d', 2)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', N'96ab03c3-da1f-48b4-b630-05fe8659a152', 4)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', N'74d69239-d475-4d01-b3c3-6e3bfbf69529', 6)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'49e6bda3-bc84-47be-9c41-db86ebab7e11', N'747355d1-dc7c-4d26-ba96-b17f06094adc', 5)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'10670948-b137-468d-966a-dce24ee842c2', N'f595599e-892c-4adb-9d87-1d4d01b9317a', 8)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'10670948-b137-468d-966a-dce24ee842c2', N'342f53bf-8767-4687-9b85-32161943f820', 9)
INSERT [dbo].[ChiTietDeThi] ([MaDeThi], [MaPhan], [MaCauHoi], [ThuTu]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'10670948-b137-468d-966a-dce24ee842c2', N'dc6c81df-156b-4b4e-bd31-3583c8696c7d', 7)
GO
SET IDENTITY_INSERT [dbo].[Clos] ON 

INSERT [dbo].[Clos] ([CloId], [CloName]) VALUES (1, N'CLO1')
INSERT [dbo].[Clos] ([CloId], [CloName]) VALUES (2, N'CLO2')
INSERT [dbo].[Clos] ([CloId], [CloName]) VALUES (3, N'CLO3')
SET IDENTITY_INSERT [dbo].[Clos] OFF
GO
INSERT [dbo].[DeThi] ([MaDeThi], [MaMonHoc], [TenDeThi], [NgayTao], [DaDuyet]) VALUES (N'287380ed-f03e-45e6-aad2-2ecf965d27aa', N'b7a37a5a-7ef8-4c0a-b573-4c2460465401', N'Huong dan hoc', CAST(N'2024-05-28T15:30:11.633' AS DateTime), NULL)
INSERT [dbo].[DeThi] ([MaDeThi], [MaMonHoc], [TenDeThi], [NgayTao], [DaDuyet]) VALUES (N'2e72c601-e22c-4f54-924f-611ece8d2ac0', N'b7a37a5a-7ef8-4c0a-b573-4c2460465401', N'Huong dan hoc', CAST(N'2024-05-28T16:11:39.723' AS DateTime), NULL)
GO
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [XoaTamKhoa]) VALUES (N'fc1fe637-5112-437f-bb40-0b0b4f68cd73', N'Quan tri kinh doanh', 0)
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [XoaTamKhoa]) VALUES (N'cd018129-5dc0-45ef-989e-b06539d0cde4', N'Cong nghe thong tin', 0)
GO
INSERT [dbo].[MonHoc] ([MaMonHoc], [MaKhoa], [MaSoMonHoc], [TenMonHoc], [XoaTamMonHoc]) VALUES (N'b7a37a5a-7ef8-4c0a-b573-4c2460465401', N'fc1fe637-5112-437f-bb40-0b0b4f68cd73', N'3', N'Huong dan hoc', 0)
INSERT [dbo].[MonHoc] ([MaMonHoc], [MaKhoa], [MaSoMonHoc], [TenMonHoc], [XoaTamMonHoc]) VALUES (N'191d6493-ca57-4960-b6bd-551c774547b9', N'fc1fe637-5112-437f-bb40-0b0b4f68cd73', N'2', N'quantrikinhdoanh', 0)
INSERT [dbo].[MonHoc] ([MaMonHoc], [MaKhoa], [MaSoMonHoc], [TenMonHoc], [XoaTamMonHoc]) VALUES (N'7fbef918-5e33-4915-92c3-97f8f7b51bad', N'cd018129-5dc0-45ef-989e-b06539d0cde4', N'1', N'1', 0)
GO
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'4ec6cfe0-8205-4174-b451-132e14096af2', N'7fbef918-5e33-4915-92c3-97f8f7b51bad', N'baomat', N'wrtwjurstag', 100, 0, N'00000000-0000-0000-0000-000000000000', 4, 0, 0)
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'0c5f5242-21c9-4ee2-beb3-382fa6884ea5', N'191d6493-ca57-4960-b6bd-551c774547b9', N'kinhte', N'sdfssdf', 100, 0, N'00000000-0000-0000-0000-000000000000', 3, 0, 0)
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'179058c9-a197-4989-966e-44b4ff7caa9e', N'191d6493-ca57-4960-b6bd-551c774547b9', N'2', N'2', 100, 0, N'00000000-0000-0000-0000-000000000000', 2, 0, 0)
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'7e6361ff-4b4c-470a-b5ad-bb0c89f3226c', N'b7a37a5a-7ef8-4c0a-b573-4c2460465401', N'Phần 3', N'asdasdasdad', 100, 0, N'00000000-0000-0000-0000-000000000000', 7, 0, 0)
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'49e6bda3-bc84-47be-9c41-db86ebab7e11', N'b7a37a5a-7ef8-4c0a-b573-4c2460465401', N'phan 2', N'sdrdsrdsrsd', 100, 0, N'00000000-0000-0000-0000-000000000000', 6, 0, 0)
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'10670948-b137-468d-966a-dce24ee842c2', N'b7a37a5a-7ef8-4c0a-b573-4c2460465401', N'phan 1', N'dsfdsfdsfds', 100, 0, N'00000000-0000-0000-0000-000000000000', 5, 0, 0)
INSERT [dbo].[Phan] ([MaPhan], [MaMonHoc], [TenPhan], [NoiDung], [ThuTu], [SoLuongCauHoi], [MaPhanCha], [MaSoPhan], [XoaTamPhan], [LaCauHoiNhom]) VALUES (N'9b54b311-a964-4eb6-83b8-e3b31ed75128', N'7fbef918-5e33-4915-92c3-97f8f7b51bad', N'1', N'1', 100, 0, N'00000000-0000-0000-0000-000000000000', 1, 0, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_KhoaID]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_KhoaID] ON [dbo].[AspNetUsers]
(
	[KhoaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CauHoi_CloId]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_CauHoi_CloId] ON [dbo].[CauHoi]
(
	[CloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CauHoi_MaPhan]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_CauHoi_MaPhan] ON [dbo].[CauHoi]
(
	[MaPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CauTraLoi_MaCauHoi]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_CauTraLoi_MaCauHoi] ON [dbo].[CauTraLoi]
(
	[MaCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDeThi_MaCauHoi]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDeThi_MaCauHoi] ON [dbo].[ChiTietDeThi]
(
	[MaCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDeThi_MaPhan]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDeThi_MaPhan] ON [dbo].[ChiTietDeThi]
(
	[MaPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DeThi_MaMonHoc]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_DeThi_MaMonHoc] ON [dbo].[DeThi]
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Files_MaCauHoi]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Files_MaCauHoi] ON [dbo].[Files]
(
	[MaCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MonHoc_MaKhoa]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_MonHoc_MaKhoa] ON [dbo].[MonHoc]
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Phan_MaMonHoc]    Script Date: 5/28/2024 4:13:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Phan_MaMonHoc] ON [dbo].[Phan]
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Khoa_KhoaID] FOREIGN KEY([KhoaID])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Khoa_KhoaID]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_Clos_CloId] FOREIGN KEY([CloId])
REFERENCES [dbo].[Clos] ([CloId])
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_CauHoi_Clos_CloId]
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_Phan] FOREIGN KEY([MaPhan])
REFERENCES [dbo].[Phan] ([MaPhan])
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_CauHoi_Phan]
GO
ALTER TABLE [dbo].[CauTraLoi]  WITH CHECK ADD  CONSTRAINT [FK_CauTraLoi_CauHoi] FOREIGN KEY([MaCauHoi])
REFERENCES [dbo].[CauHoi] ([MaCauHoi])
GO
ALTER TABLE [dbo].[CauTraLoi] CHECK CONSTRAINT [FK_CauTraLoi_CauHoi]
GO
ALTER TABLE [dbo].[ChiTietDeThi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDeThi_CauHoi1] FOREIGN KEY([MaCauHoi])
REFERENCES [dbo].[CauHoi] ([MaCauHoi])
GO
ALTER TABLE [dbo].[ChiTietDeThi] CHECK CONSTRAINT [FK_ChiTietDeThi_CauHoi1]
GO
ALTER TABLE [dbo].[ChiTietDeThi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDeThi_DeThi] FOREIGN KEY([MaDeThi])
REFERENCES [dbo].[DeThi] ([MaDeThi])
GO
ALTER TABLE [dbo].[ChiTietDeThi] CHECK CONSTRAINT [FK_ChiTietDeThi_DeThi]
GO
ALTER TABLE [dbo].[ChiTietDeThi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDeThi_Phan] FOREIGN KEY([MaPhan])
REFERENCES [dbo].[Phan] ([MaPhan])
GO
ALTER TABLE [dbo].[ChiTietDeThi] CHECK CONSTRAINT [FK_ChiTietDeThi_Phan]
GO
ALTER TABLE [dbo].[DeThi]  WITH CHECK ADD  CONSTRAINT [FK_DeThi_MonHoc] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[DeThi] CHECK CONSTRAINT [FK_DeThi_MonHoc]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_File_CauHoi] FOREIGN KEY([MaCauHoi])
REFERENCES [dbo].[CauHoi] ([MaCauHoi])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_File_CauHoi]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_MonHoc_Khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_MonHoc_Khoa]
GO
ALTER TABLE [dbo].[Phan]  WITH CHECK ADD  CONSTRAINT [FK_Phan_MonHoc] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[Phan] CHECK CONSTRAINT [FK_Phan_MonHoc]
GO
USE [master]
GO
ALTER DATABASE [HutechQuestionBank] SET  READ_WRITE 
GO
