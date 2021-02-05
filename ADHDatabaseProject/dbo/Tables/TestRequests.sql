CREATE TABLE [dbo].[TestRequests] (
    [Id]         NVARCHAR (128) NOT NULL,
    [Date]       DATETIME       CONSTRAINT [DF_lap_test_requests_date] DEFAULT (getdate()) NOT NULL,
    [PatientId]  NVARCHAR (128) NOT NULL,
    [TestId]     NVARCHAR (128) NOT NULL,
    [Result]     TEXT           NULL,
    [CreatorID]  NVARCHAR (128) NULL,
    [ResultDate] DATE           NULL,
    [TesterId]   NVARCHAR (128) NULL,
    CONSTRAINT [PK_lap_test_requests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TestRequests_LabTests] FOREIGN KEY ([TestId]) REFERENCES [dbo].[LabTests] ([Id]),
    CONSTRAINT [FK_TestRequests_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_TestRequests_Users1] FOREIGN KEY ([CreatorID]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_TestRequests_Users2] FOREIGN KEY ([TesterId]) REFERENCES [dbo].[Users] ([Id])
);

