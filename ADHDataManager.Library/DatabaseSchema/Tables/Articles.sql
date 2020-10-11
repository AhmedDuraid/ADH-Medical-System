
CREATE TABLE [dbo].[Articles](
	[Id] [nvarchar](128) NOT NULL,
	[Titel] [nvarchar](256) NOT NULL,
	[Body] [text] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[Show] [bit] NOT NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_articles_date]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_articles_last_update]  DEFAULT (getdate()) FOR [LastUpdate]
GO

ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_articles_show]  DEFAULT ((1)) FOR [Show]
GO

ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_articles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_articles_Users]
GO


