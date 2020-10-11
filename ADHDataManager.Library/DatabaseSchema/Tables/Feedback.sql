
CREATE TABLE [dbo].[Feedback](
	[Id] [nvarchar](128) NOT NULL,
	[Titel] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Phone] [char](20) NOT NULL,
	[FeedbackBody] [text] NOT NULL,
	[Date] [datetime] NOT NULL,
	[HasBeenRead] [bit] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ReadedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_feedback_date]  DEFAULT (getdate()) FOR [Date]
GO

ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_feedback_has_been_read]  DEFAULT ((0)) FOR [HasBeenRead]
GO

ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_feedback_updated_date]  DEFAULT (getdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Users] FOREIGN KEY([ReadedBy])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Users]
GO


