-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spAssignedPlan_AddNew
	@Id nvarchar(128)
	,@PatientId nvarchar(128)
	,@PlanId nvarchar(128)
	,@AddedBy nvarchar(128)
	,@StartOn date
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[AssignedPlan]
           ([Id]
           ,[PatientId]
           ,[PlanId]
           ,[AddedBy]
           ,[StartOn])
     VALUES
           (@Id
           ,@PatientId
           ,@PlanId
           ,@AddedBy
           ,@StartOn)
END
