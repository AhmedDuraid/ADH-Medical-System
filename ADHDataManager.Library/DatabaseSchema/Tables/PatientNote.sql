
CREATE TABLE [dbo].[PatientNote](
	[Id] [nvarchar](128) NOT NULL,
	[Date] [date] NOT NULL,
	[Body] [text] NOT NULL,
	[PatientId] [nvarchar](128) NULL,
	[AddedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_patient_note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[PatientNote] ADD  CONSTRAINT [DF_patient_note_date]  DEFAULT (getdate()) FOR [Date]
GO

ALTER TABLE [dbo].[PatientNote]  WITH CHECK ADD  CONSTRAINT [FK_PatientNote_Users] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[PatientNote] CHECK CONSTRAINT [FK_PatientNote_Users]
GO

ALTER TABLE [dbo].[PatientNote]  WITH CHECK ADD  CONSTRAINT [FK_PatientNote_Users1] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[PatientNote] CHECK CONSTRAINT [FK_PatientNote_Users1]
GO


