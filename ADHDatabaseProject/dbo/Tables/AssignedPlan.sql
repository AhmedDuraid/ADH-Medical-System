CREATE TABLE [dbo].[AssignedPlan] (
    [Id]        NVARCHAR (128) NOT NULL,
    [PatientId] NVARCHAR (128) NULL,
    [PlanId]    NVARCHAR (128) NULL,
    [AddedBy]   NVARCHAR (128) NULL,
    [StartOn]   DATE           CONSTRAINT [DF_AssignedPlan_StartOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_plan] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AssignedPlan_Plan] FOREIGN KEY ([PlanId]) REFERENCES [dbo].[Plan] ([Id]),
    CONSTRAINT [FK_AssignedPlan_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_AssignedPlan_Users1] FOREIGN KEY ([AddedBy]) REFERENCES [dbo].[Users] ([Id])
);

