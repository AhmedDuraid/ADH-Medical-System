CREATE TABLE [dbo].[Feedback] (
    [Id]           NVARCHAR (128) NOT NULL,
    [Titel]        NVARCHAR (128) NOT NULL,
    [Name]         NVARCHAR (256) NOT NULL,
    [Email]        NVARCHAR (256) NOT NULL,
    [Phone]        CHAR (20)      NOT NULL,
    [FeedbackBody] TEXT           NOT NULL,
    [Date]         DATETIME       CONSTRAINT [DF_feedback_date] DEFAULT (getdate()) NOT NULL,
    [HasBeenRead]  BIT            CONSTRAINT [DF_feedback_has_been_read] DEFAULT ((0)) NOT NULL,
    [UpdatedDate]  DATETIME       CONSTRAINT [DF_feedback_updated_date] DEFAULT (getdate()) NOT NULL,
    [ReadedBy]     NVARCHAR (128) NULL,
    CONSTRAINT [PK_feedback] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Feedback_Users] FOREIGN KEY ([ReadedBy]) REFERENCES [dbo].[Users] ([Id])
);

