USE [master]
GO
/****** Object:  Database [LIBRARY]    Script Date: 01/14/2014 16:45:21 ******/
CREATE DATABASE [LIBRARY] ON  PRIMARY 
( NAME = N'LIBRARY', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LIBRARY.mdf' , SIZE = 102400KB , MAXSIZE = UNLIMITED, FILEGROWTH = 102400KB )
 LOG ON 
( NAME = N'LIBRARY_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LIBRARY_log.ldf' , SIZE = 102400KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LIBRARY] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LIBRARY].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LIBRARY] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [LIBRARY] SET ANSI_NULLS OFF
GO
ALTER DATABASE [LIBRARY] SET ANSI_PADDING OFF
GO
ALTER DATABASE [LIBRARY] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [LIBRARY] SET ARITHABORT OFF
GO
ALTER DATABASE [LIBRARY] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [LIBRARY] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [LIBRARY] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [LIBRARY] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [LIBRARY] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [LIBRARY] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [LIBRARY] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [LIBRARY] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [LIBRARY] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [LIBRARY] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [LIBRARY] SET  DISABLE_BROKER
GO
ALTER DATABASE [LIBRARY] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [LIBRARY] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [LIBRARY] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [LIBRARY] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [LIBRARY] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [LIBRARY] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [LIBRARY] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [LIBRARY] SET  READ_WRITE
GO
ALTER DATABASE [LIBRARY] SET RECOVERY FULL
GO
ALTER DATABASE [LIBRARY] SET  MULTI_USER
GO
ALTER DATABASE [LIBRARY] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [LIBRARY] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'LIBRARY', N'ON'
GO
USE [LIBRARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/14/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Email] [nvarchar](100) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [Username], [Name], [Surname], [CreatedOn], [IsActive], [Email], [IsAdmin]) VALUES (1, N'ayilmaz', N'Ahmet', N'Yılmaz', CAST(0x0000A29201458296 AS DateTime), 1, N'ayilmaz@kutuphane.com', 1)
INSERT [dbo].[User] ([UserId], [Username], [Name], [Surname], [CreatedOn], [IsActive], [Email], [IsAdmin]) VALUES (2, N'dulucay', N'Doruk', N'Uluçay', CAST(0x0000A29700DA6CD9 AS DateTime), 1, N'doruk36@yahoo.com', 0)
INSERT [dbo].[User] ([UserId], [Username], [Name], [Surname], [CreatedOn], [IsActive], [Email], [IsAdmin]) VALUES (4, N'aykac', NULL, NULL, CAST(0x0000A2AE00D2A47B AS DateTime), 0, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Username], [Name], [Surname], [CreatedOn], [IsActive], [Email], [IsAdmin]) VALUES (5, N'irgin', NULL, NULL, CAST(0x0000A2A80173FC87 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Username], [Name], [Surname], [CreatedOn], [IsActive], [Email], [IsAdmin]) VALUES (6, N'gates', NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Username], [Name], [Surname], [CreatedOn], [IsActive], [Email], [IsAdmin]) VALUES (7, N'mdemir', NULL, NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[MenuItems]    Script Date: 01/14/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuItems](
	[MenuItemId] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [varchar](50) NULL,
	[Path] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IsAdministration] [bit] NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[MenuItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (1, N'Request Book', N'../Home/RequestBook', NULL, 0)
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (2, N'Return Book', N'../Home/ReturnBooks', NULL, 0)
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (3, N'Add Book', N'../Home/AddBook', NULL, 1)
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (4, N'Add Author', N'../Home/AddAuthor', NULL, 1)
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (5, N'User List', N'../User/UserList', NULL, 1)
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (6, N'Requests', N'../Home/Requests', NULL, 1)
INSERT [dbo].[MenuItems] ([MenuItemId], [Caption], [Path], [Description], [IsAdministration]) VALUES (7, N'All Books', N'../Home/AllBooks', NULL, 1)
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 01/14/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogId] [int] IDENTITY(1,1) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[InnerException] [nvarchar](max) NULL,
	[OccuredOn] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ErrorLog] ON
INSERT [dbo].[ErrorLog] ([ErrorLogId], [Exception], [InnerException], [OccuredOn], [UserId]) VALUES (1, N'test', N'inner test', CAST(0x0000A2A8018B380F AS DateTime), NULL)
INSERT [dbo].[ErrorLog] ([ErrorLogId], [Exception], [InnerException], [OccuredOn], [UserId]) VALUES (2, N'test', N'inner test', CAST(0x0000A2A9000228B4 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[ErrorLog] OFF
/****** Object:  Table [dbo].[BookRequest]    Script Date: 01/14/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRequest](
	[BookRequestId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[UserId] [int] NULL,
	[Since] [date] NULL,
	[Until] [date] NULL,
	[TakenOn] [date] NULL,
	[ReturnedOn] [date] NULL,
	[RequestedOn] [date] NULL,
	[ApprovedOn] [date] NULL,
	[ApprovedBy] [int] NULL,
	[RejectedOn] [datetime] NULL,
	[RejectedBy] [int] NULL,
 CONSTRAINT [PK_BookRequest] PRIMARY KEY CLUSTERED 
(
	[BookRequestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookRequest] ON
INSERT [dbo].[BookRequest] ([BookRequestId], [BookId], [UserId], [Since], [Until], [TakenOn], [ReturnedOn], [RequestedOn], [ApprovedOn], [ApprovedBy], [RejectedOn], [RejectedBy]) VALUES (73, 4, 4, CAST(0xED370B00 AS Date), CAST(0x0D380B00 AS Date), NULL, CAST(0xF4370B00 AS Date), CAST(0xF3370B00 AS Date), CAST(0xF3370B00 AS Date), 1, NULL, NULL)
INSERT [dbo].[BookRequest] ([BookRequestId], [BookId], [UserId], [Since], [Until], [TakenOn], [ReturnedOn], [RequestedOn], [ApprovedOn], [ApprovedBy], [RejectedOn], [RejectedBy]) VALUES (74, 19, 4, CAST(0xF3370B00 AS Date), CAST(0x1E380B00 AS Date), NULL, NULL, CAST(0xF3370B00 AS Date), CAST(0xF3370B00 AS Date), 1, NULL, NULL)
INSERT [dbo].[BookRequest] ([BookRequestId], [BookId], [UserId], [Since], [Until], [TakenOn], [ReturnedOn], [RequestedOn], [ApprovedOn], [ApprovedBy], [RejectedOn], [RejectedBy]) VALUES (75, 16, 4, CAST(0xF5370B00 AS Date), CAST(0xFF370B00 AS Date), NULL, CAST(0xF4370B00 AS Date), CAST(0xF4370B00 AS Date), CAST(0xF4370B00 AS Date), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BookRequest] OFF
/****** Object:  Table [dbo].[Book]    Script Date: 01/14/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[AuthorId] [int] NULL,
	[ReleaseDate] [date] NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (1, N'At The Mountains Of Madness', 1, NULL, CAST(0x0000A292015BB7FA AS DateTime), 1)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (2, N'The Case Of Charles Dexter Ward', 1, NULL, CAST(0x0000A292015BC704 AS DateTime), 1)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (3, N'The Pit And The Pendulum', 2, NULL, CAST(0x0000A292015BD29A AS DateTime), 1)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (4, N'I Have No Mouth And I Must Scream', 3, NULL, CAST(0x0000A292015BE564 AS DateTime), 1)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (5, N'Dune', 4, NULL, CAST(0x0000A292015BF052 AS DateTime), 1)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (6, N'Dune Messiah', 4, NULL, CAST(0x0000A292015BF9B0 AS DateTime), 1)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (9, N'Call Of Cthulhu', 1, NULL, NULL, NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (13, N'The Hound', 1, NULL, NULL, NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (14, N'Vathek', 11, NULL, NULL, NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (15, N'Le Lys dans la Vallée', 12, NULL, NULL, NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (16, N'Almuric', 6, NULL, CAST(0x0000A29800E60C2D AS DateTime), NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (17, N'Tower Of The Elephant', 6, NULL, CAST(0x0000A29800E625CB AS DateTime), NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (18, N'Children Of Dune', 4, NULL, CAST(0x0000A29800E65182 AS DateTime), NULL)
INSERT [dbo].[Book] ([BookId], [Title], [AuthorId], [ReleaseDate], [CreatedOn], [IsActive]) VALUES (19, N'God Emperor Of Dune', 4, NULL, CAST(0x0000A29800E65965 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Book] OFF
/****** Object:  Table [dbo].[Author]    Script Date: 01/14/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (1, N'Howard Philips Lovecraft')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (2, N'Edgar Allan Poe')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (3, N'Harlan Ellison')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (4, N'Frank Herbert')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (5, N'John Ronald Reuel Tolkien')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (6, N'Robert Ervin Howard')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (7, N'Arthur Machen')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (8, N'Isaac Asimov')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (9, N'Sir Arthur Conan Doyle')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (10, N'Christian Jacq')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (11, N'William Beckford')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (12, N'Honore De Balzac')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (13, N'Mario Puzo')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (14, N'Richard A Knaak')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (15, N'Vladimir Bartol')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (16, N'Peter V Brett')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (17, N'İhsan Oktay Anar')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (18, N'Reşat Nuri Güntekin')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (19, N'Franz Kafka')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (20, N'Joseph Conrad')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (21, N'Aziz Nesin')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (22, N'Clive Barker')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (23, N'Jack London')
SET IDENTITY_INSERT [dbo].[Author] OFF
/****** Object:  StoredProcedure [dbo].[uspHowManyTaken]    Script Date: 01/14/2014 16:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHowManyTaken]

@userid int
	
AS
	select COUNT(*) from BookRequest 
	where UserId=@userid
	and ApprovedOn is not null
	and ReturnedOn is null
GO
/****** Object:  StoredProcedure [dbo].[uspAvailableBooks]    Script Date: 01/14/2014 16:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAvailableBooks]
	
AS
	select * from Book B
where B.BookId not in
(
select BookId from BookRequest BR
where

(br.ApprovedOn is not null and br.ReturnedOn is null)
OR
(br.TakenOn is not null and br.ReturnedOn is null )
)
GO
/****** Object:  Default [DF_User_CreatedOn]    Script Date: 01/14/2014 16:45:23 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_User_IsActive]    Script Date: 01/14/2014 16:45:23 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_User_IsAdmin]    Script Date: 01/14/2014 16:45:23 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
/****** Object:  Default [DF_ErrorLog_OccuredOn]    Script Date: 01/14/2014 16:45:23 ******/
ALTER TABLE [dbo].[ErrorLog] ADD  CONSTRAINT [DF_ErrorLog_OccuredOn]  DEFAULT (getdate()) FOR [OccuredOn]
GO
/****** Object:  Default [DF_BookRequest_RequestedOn]    Script Date: 01/14/2014 16:45:23 ******/
ALTER TABLE [dbo].[BookRequest] ADD  CONSTRAINT [DF_BookRequest_RequestedOn]  DEFAULT (getdate()) FOR [RequestedOn]
GO
/****** Object:  Default [DF_Book_CreatedOn]    Script Date: 01/14/2014 16:45:23 ******/
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
