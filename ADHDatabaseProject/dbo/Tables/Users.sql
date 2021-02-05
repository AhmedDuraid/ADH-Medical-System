CREATE TABLE [dbo].[Users] (
    [Id]                 NVARCHAR (128) NOT NULL,
    [UserName]           NVARCHAR (256) NOT NULL,
    [Email]              NVARCHAR (256) NOT NULL,
    [EmailConfirmed]     BIT            NULL,
    [PasswordHash]       NVARCHAR (MAX) NOT NULL,
    [NormalizedUserName] NVARCHAR (256) NULL,
    [NormalizedEmail]    NVARCHAR (256) NULL,
    [AuthenticationType] NVARCHAR (256) NULL,
    [IsAuthenticated]    BIT            NULL,
    [FirstName]          NVARCHAR (128) NULL,
    [MiddleName]         NVARCHAR (128) NULL,
    [LastName]           NVARCHAR (128) NULL,
    [BirthDate]          DATE           NULL,
    [PhoneNumber]        CHAR (15)      NULL,
    [Gender]             CHAR (10)      NULL,
    [Nationality]        NVARCHAR (50)  NULL,
    [Address]            NVARCHAR (50)  NULL,
    [CreateDate]         DATETIME       CONSTRAINT [DF_users_create_date] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

