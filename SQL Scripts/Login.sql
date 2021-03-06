USE [PinkTech]
GO
/****** Object:  Table [dbo].[tblSecurityLevel]    Script Date: 5/5/2016 2:18:52 AM ******/
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
/****** Object:  Table [dbo].[tblUsers]    Script Date: 5/5/2016 2:18:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUserFetchByName]    Script Date: 5/5/2016 2:18:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUserInfoFetchCredentials]    Script Date: 5/5/2016 2:18:52 AM ******/
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
