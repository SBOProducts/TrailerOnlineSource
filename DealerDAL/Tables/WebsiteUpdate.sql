/****** Object:  Table [dbo].[WebsiteUpdate]    Script Date: 12/29/2014 3:27:07 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[WebsiteUpdate](
	[WebsiteUpdateId] [int] IDENTITY(1,1) NOT NULL,
	[VersionInstalled] [int] NOT NULL,
	[UpdateDescription] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PreviousVersion] [int] NOT NULL,
	[InstalledByUserName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[InstallDate] [datetime] NOT NULL,
 CONSTRAINT [PK_WebsiteUpdate] PRIMARY KEY CLUSTERED 
(
	[WebsiteUpdateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
