USE [PinkTech]
GO
/****** Object:  Table [dbo].[tblMessages]    Script Date: 5/5/2016 2:34:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMessages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[CreatedDate] [varchar](50) NOT NULL CONSTRAINT [DF_tblMessages_CreatedDate]  DEFAULT (getdate()),
	[SenderID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_tblMessages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserMessages]    Script Date: 5/5/2016 2:34:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserMessages](
	[UserID] [int] NOT NULL,
	[MessageID] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblMessages]  WITH CHECK ADD  CONSTRAINT [FK_tblMessages_tblUsers] FOREIGN KEY([SenderID])
REFERENCES [dbo].[tblUsers] ([UserID])
GO
ALTER TABLE [dbo].[tblMessages] CHECK CONSTRAINT [FK_tblMessages_tblUsers]
GO
ALTER TABLE [dbo].[tblUserMessages]  WITH CHECK ADD  CONSTRAINT [FK_tblUserMessages_tblMessages] FOREIGN KEY([MessageID])
REFERENCES [dbo].[tblMessages] ([MessageID])
GO
ALTER TABLE [dbo].[tblUserMessages] CHECK CONSTRAINT [FK_tblUserMessages_tblMessages]
GO
ALTER TABLE [dbo].[tblUserMessages]  WITH CHECK ADD  CONSTRAINT [FK_tblUserMessages_tblUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUsers] ([UserID])
GO
ALTER TABLE [dbo].[tblUserMessages] CHECK CONSTRAINT [FK_tblUserMessages_tblUsers]
GO
/****** Object:  StoredProcedure [dbo].[spUserMessagesFetchByID]    Script Date: 5/5/2016 2:34:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserMessagesFetchByID] 
@UserID int

AS

 SELECT tblUserMessages.UserID, tblUserMessages.MessageID, tblMessages.Subject, tblUsers.UserName[Sender],tblMessages.CreatedDate, tblMessages.Status
	FROM tblUserMessages, tblMessages, tblUsers
	WHERE tblUserMessages.UserID = @UserID
	AND tblUserMessages.MessageID = tblMessages.MessageID and tblMessages.SenderID = tblUsers.UserID 
	
GO
