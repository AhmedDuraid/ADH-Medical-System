
CREATE TABLE [dbo].[AassignedMedicines](
	[Id] [nvarchar](128) NOT NULL,
	[PatientId] [nvarchar](128) NULL,
	[MedicineId] [nvarchar](128) NULL,
	[AddedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_medicine_patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AassignedMedicines]  WITH CHECK ADD  CONSTRAINT [FK_AassignedMedicines_Medicines] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([Id])
GO

ALTER TABLE [dbo].[AassignedMedicines] CHECK CONSTRAINT [FK_AassignedMedicines_Medicines]
GO

ALTER TABLE [dbo].[AassignedMedicines]  WITH CHECK ADD  CONSTRAINT [FK_AassignedMedicines_Users] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[AassignedMedicines] CHECK CONSTRAINT [FK_AassignedMedicines_Users]
GO

ALTER TABLE [dbo].[AassignedMedicines]  WITH CHECK ADD  CONSTRAINT [FK_AassignedMedicines_Users1] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[AassignedMedicines] CHECK CONSTRAINT [FK_AassignedMedicines_Users1]
GO

