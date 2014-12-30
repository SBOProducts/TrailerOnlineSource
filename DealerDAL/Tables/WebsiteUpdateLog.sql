/****** Object:  Table [dbo].[WebsiteUpdateLog]    Script Date: 12/29/2014 11:45:49 PM ******/
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

