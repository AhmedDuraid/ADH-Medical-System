CREATE TABLE [dbo].[LabTests] (
    [Id]          NVARCHAR (128) NOT NULL,
    [TestName]    NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR(250)           NOT NULL,
    [LastUpdate]  DATETIME       CONSTRAINT [DF_lab_tests_last_update] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_lab_tests] PRIMARY KEY CLUSTERED ([Id] ASC)
);

