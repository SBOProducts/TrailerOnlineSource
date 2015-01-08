/****** Object:  Table [dbo].[WebsiteUpdateLog]    Script Date: 12/30/2014 10:47:42 AM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[WebsiteUpdateLog](
	[WebsiteUpdateId] [int] NOT NULL,
	[InstallSequence] [int] NOT NULL,
	[ActionType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Message] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_WebsiteUpdateLog] PRIMARY KEY CLUSTERED 
(
	[WebsiteUpdateId] ASC,
	[InstallSequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Index [WebsiteUpdateLog_WebsiteUpdateId]    Script Date: 12/30/2014 10:47:42 AM ******/
CREATE NONCLUSTERED INDEX [WebsiteUpdateLog_WebsiteUpdateId] ON [dbo].[WebsiteUpdateLog]
(
	[WebsiteUpdateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
