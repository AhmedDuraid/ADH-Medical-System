CREATE TABLE [dbo].[PatientProgress] (
    [Id]        NVARCHAR (128) NOT NULL,
    [Date]      DATETIME       CONSTRAINT [DF_patient_progress_date] DEFAULT (getdate()) NOT NULL,
    [Weight]    FLOAT (53)     NOT NULL,
    [BMI]       FLOAT (53)     NOT NULL,
    [PatientId] NVARCHAR (128) NULL,
    [AddedBy]   NVARCHAR (128) NULL,
    CONSTRAINT [PK_patient_progress] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_patient_progress_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_patient_progress_Users1] FOREIGN KEY ([AddedBy]) REFERENCES [dbo].[Users] ([Id])
);

