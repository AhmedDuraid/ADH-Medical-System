CREATE TABLE [dbo].[AssignedMedicines] (
    [Id]         NVARCHAR (128) NOT NULL,
    [PatientId]  NVARCHAR (128) NULL,
    [MedicineId] NVARCHAR (128) NULL,
    [AddedBy]    NVARCHAR (128) NULL,
    CONSTRAINT [PK_medicine_patient] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AassignedMedicines_Medicines] FOREIGN KEY ([MedicineId]) REFERENCES [dbo].[Medicines] ([Id]),
    CONSTRAINT [FK_AassignedMedicines_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_AassignedMedicines_Users1] FOREIGN KEY ([AddedBy]) REFERENCES [dbo].[Users] ([Id])
);

