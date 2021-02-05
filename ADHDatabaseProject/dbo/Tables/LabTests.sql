CREATE TABLE [dbo].[LabTests] (
    [Id]          NVARCHAR (128) NOT NULL,
    [TestName]    NVARCHAR (128) NOT NULL,
    [Description] TEXT           NOT NULL,
    [LastUpdate]  DATETIME       CONSTRAINT [DF_lab_tests_last_update] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_lab_tests] PRIMARY KEY CLUSTERED ([Id] ASC)
);

