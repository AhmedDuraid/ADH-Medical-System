CREATE TABLE [dbo].[Plan] (
    [Id]          NVARCHAR (128) NOT NULL,
    [Day1]        TEXT           NULL,
    [Day2]        TEXT           NULL,
    [Day3]        TEXT           NULL,
    [Day4]        TEXT           NULL,
    [Day5]        TEXT           NULL,
    [Day6]        TEXT           NULL,
    [Day7]        TEXT           NULL,
    [Description] TEXT           NOT NULL,
    [Type]        NVARCHAR (125) NOT NULL,
    CONSTRAINT [PK_medicine_plan] PRIMARY KEY CLUSTERED ([Id] ASC)
);

