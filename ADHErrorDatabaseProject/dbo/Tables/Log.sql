CREATE TABLE [dbo].[Log] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Date]       DATETIME       CONSTRAINT [DF_Log_Date] DEFAULT (getdate()) NULL,
    [Message]    NVARCHAR (MAX) NULL,
    [StackTrace] NVARCHAR (MAX) NULL,
    [Source]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC)
);

