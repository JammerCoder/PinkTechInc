USE [master]
GO
/****** Object:  Database [PinkTech]    Script Date: 5/2/2016 6:44:37 AM ******/
CREATE DATABASE [PinkTech]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PinkTech', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PinkTech.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PinkTech_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PinkTech_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PinkTech] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PinkTech].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PinkTech] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PinkTech] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PinkTech] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PinkTech] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PinkTech] SET ARITHABORT OFF 
GO
ALTER DATABASE [PinkTech] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PinkTech] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PinkTech] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PinkTech] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PinkTech] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PinkTech] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PinkTech] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PinkTech] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PinkTech] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PinkTech] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PinkTech] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PinkTech] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PinkTech] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PinkTech] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PinkTech] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PinkTech] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PinkTech] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PinkTech] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PinkTech] SET  MULTI_USER 
GO
ALTER DATABASE [PinkTech] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PinkTech] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PinkTech] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PinkTech] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PinkTech] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PinkTech]
GO
/****** Object:  Table [dbo].[tblSecurityLevel]    Script Date: 5/2/2016 6:44:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSecurityLevel](
	[SecurityLevelID] [int] IDENTITY(1,1) NOT NULL,
	[SecurityLevelName] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tblSecurityLevel] PRIMARY KEY CLUSTERED 
(
	[SecurityLevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 5/2/2016 6:44:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[NickName] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NULL,
	[Zip] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Passwrd] [varchar](50) NOT NULL,
	[CreatedDate] [varchar](50) NOT NULL CONSTRAINT [DF_tblUsers_CreateDate]  DEFAULT (getdate()),
	[IsActive] [bit] NOT NULL,
	[SecurityLevelID] [int] NOT NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblSecurityLevel] FOREIGN KEY([SecurityLevelID])
REFERENCES [dbo].[tblSecurityLevel] ([SecurityLevelID])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblSecurityLevel]
GO
/****** Object:  StoredProcedure [dbo].[spUserFetchByName]    Script Date: 5/2/2016 6:44:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUserFetchByName]
@UserName varchar(50)

AS

 SELECT UserID, FirstName, MiddleName, LastName, UserName, Email, Passwrd, tblUsers.SecurityLevelID, SecurityLevelName, IsActive 
	FROM tblUsers, tblSecurityLevel
	WHERE tblUsers.UserName = @UserName
	AND tblUsers.SecurityLevelID = tblSecurityLevel.SecurityLevelID
GO
/****** Object:  StoredProcedure [dbo].[spUserInfoFetchByID]    Script Date: 5/2/2016 6:44:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUserInfoFetchByID] 
@UserID varchar(50)
AS
SELECT UserID, FirstName, MiddleName, LastName, UserName, Password, tblUsers.SecurityLevelID, IsActive 
	FROM tblUsers, tblSecurityLevel
	WHERE tblUsers.UserID = @UserID
	AND tblUsers.SecurityLevelID = tblSecurityLevel.SecurityLevelID
GO
/****** Object:  StoredProcedure [dbo].[spUserInfoFetchCredentials]    Script Date: 5/2/2016 6:44:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUserInfoFetchCredentials] 
@UserName varchar(50),
@Passwrd varchar(50)

AS

 SELECT UserID, FirstName, MiddleName, LastName, UserName, Email, Passwrd, tblUsers.SecurityLevelID, SecurityLevelName, IsActive 
	FROM tblUsers, tblSecurityLevel
	WHERE tblUsers.UserName = @UserName AND tblUsers.Passwrd = @Passwrd
	AND tblUsers.SecurityLevelID = tblSecurityLevel.SecurityLevelID
GO
USE [master]
GO
ALTER DATABASE [PinkTech] SET  READ_WRITE 
GO
