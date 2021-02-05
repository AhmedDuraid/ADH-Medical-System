CREATE TABLE [dbo].[Roles] (
    [Id]                 NVARCHAR (128) NOT NULL,
    [Name]               NVARCHAR (256) NOT NULL,
    [NormalizedRoleName] NVARCHAR (256) NULL,
    CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

