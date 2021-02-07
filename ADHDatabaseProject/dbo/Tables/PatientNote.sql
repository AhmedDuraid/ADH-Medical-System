CREATE TABLE [dbo].[PatientNote] (
    [Id]            NVARCHAR (128) NOT NULL,
    [Date]          DATE           CONSTRAINT [DF_patient_note_date] DEFAULT (getdate()) NOT NULL,
    [Body]          NVARCHAR(500)           NOT NULL,
    [PatientId]     NVARCHAR (128) NULL,
    [AddedBy]       NVARCHAR (128) NULL,
    [ShowToPatient] BIT            CONSTRAINT [DF_PatientNote_Show] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_patient_note] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PatientNote_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_PatientNote_Users1] FOREIGN KEY ([AddedBy]) REFERENCES [dbo].[Users] ([Id])
);

