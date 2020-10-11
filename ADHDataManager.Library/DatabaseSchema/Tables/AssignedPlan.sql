
CREATE TABLE [dbo].[AssignedPlan](
	[Id] [nvarchar](128) NOT NULL,
	[PatientId] [nvarchar](128) NULL,
	[PlanId] [nvarchar](128) NULL,
	[AddedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_plan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AssignedPlan]  WITH CHECK ADD  CONSTRAINT [FK_AssignedPlan_Plan] FOREIGN KEY([PlanId])
REFERENCES [dbo].[Plan] ([Id])
GO

ALTER TABLE [dbo].[AssignedPlan] CHECK CONSTRAINT [FK_AssignedPlan_Plan]
GO

ALTER TABLE [dbo].[AssignedPlan]  WITH CHECK ADD  CONSTRAINT [FK_AssignedPlan_Users] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[AssignedPlan] CHECK CONSTRAINT [FK_AssignedPlan_Users]
GO

ALTER TABLE [dbo].[AssignedPlan]  WITH CHECK ADD  CONSTRAINT [FK_AssignedPlan_Users1] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[AssignedPlan] CHECK CONSTRAINT [FK_AssignedPlan_Users1]
GO


