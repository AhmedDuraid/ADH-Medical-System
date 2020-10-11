
CREATE TABLE [dbo].[PatientProgress](
	[Id] [nvarchar](128) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Weight] [float] NOT NULL,
	[BMI] [float] NOT NULL,
	[PatientId] [nvarchar](128) NULL,
	[AddedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_patient_progress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PatientProgress] ADD  CONSTRAINT [DF_patient_progress_date]  DEFAULT (getdate()) FOR [Date]
GO

ALTER TABLE [dbo].[PatientProgress]  WITH CHECK ADD  CONSTRAINT [FK_patient_progress_Users] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[PatientProgress] CHECK CONSTRAINT [FK_patient_progress_Users]
GO

ALTER TABLE [dbo].[PatientProgress]  WITH CHECK ADD  CONSTRAINT [FK_patient_progress_Users1] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[PatientProgress] CHECK CONSTRAINT [FK_patient_progress_Users1]
GO

