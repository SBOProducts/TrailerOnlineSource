/****** Object:  Table [dbo].[MetaTags]    Script Date: 1/6/2015 3:01:01 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[MetaTags](
	[MetaTagsId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](52) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[KeyWords] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Author] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Robots] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_PageMetadata] PRIMARY KEY CLUSTERED 
(
	[MetaTagsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

