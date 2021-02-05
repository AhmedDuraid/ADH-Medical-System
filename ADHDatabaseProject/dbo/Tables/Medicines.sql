CREATE TABLE [dbo].[Medicines] (
    [Id]               NVARCHAR (128) NOT NULL,
    [Name]             NVARCHAR (128) NOT NULL,
    [Description]      TEXT           NOT NULL,
    [Contraindication] TEXT           CONSTRAINT [DF_medicines_contraindication] DEFAULT (NULL) NULL,
    [RecommendedDose]  NVARCHAR (256) NULL,
    CONSTRAINT [PK_medicines] PRIMARY KEY CLUSTERED ([Id] ASC)
);

