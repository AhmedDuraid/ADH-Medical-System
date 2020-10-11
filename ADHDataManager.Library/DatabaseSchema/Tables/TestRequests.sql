
CREATE TABLE [dbo].[TestRequests](
	[Id] [nvarchar](128) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PatientId] [nvarchar](128) NULL,
	[TestId] [nvarchar](128) NULL,
	[Result] [text] NULL,
	[CreatorID] [nvarchar](128) NULL,
 CONSTRAINT [PK_lap_test_requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TestRequests] ADD  CONSTRAINT [DF_lap_test_requests_date]  DEFAULT (getdate()) FOR [Date]
GO

ALTER TABLE [dbo].[TestRequests]  WITH CHECK ADD  CONSTRAINT [FK_TestRequests_LabTests] FOREIGN KEY([TestId])
REFERENCES [dbo].[LabTests] ([Id])
GO

ALTER TABLE [dbo].[TestRequests] CHECK CONSTRAINT [FK_TestRequests_LabTests]
GO

ALTER TABLE [dbo].[TestRequests]  WITH CHECK ADD  CONSTRAINT [FK_TestRequests_Users] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[TestRequests] CHECK CONSTRAINT [FK_TestRequests_Users]
GO

ALTER TABLE [dbo].[TestRequests]  WITH CHECK ADD  CONSTRAINT [FK_TestRequests_Users1] FOREIGN KEY([CreatorID])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[TestRequests] CHECK CONSTRAINT [FK_TestRequests_Users1]
GO

