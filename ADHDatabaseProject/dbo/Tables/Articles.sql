CREATE TABLE [dbo].[Articles] (
    [Id]         NVARCHAR (128) NOT NULL,
    [Titel]      NVARCHAR (100) NOT NULL,
    [Body]       TEXT           NOT NULL,
    [CreateDate] DATETIME       CONSTRAINT [DF_articles_date] DEFAULT (getdate()) NOT NULL,
    [LastUpdate] DATETIME       CONSTRAINT [DF_articles_last_update] DEFAULT (getdate()) NOT NULL,
    [Show]       BIT            CONSTRAINT [DF_articles_show] DEFAULT ((1)) NOT NULL,
    [UserId]     NVARCHAR (128) NULL,
    CONSTRAINT [PK_articles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_articles_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE SET NULL ON UPDATE SET NULL
);

