-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	delete plan
-- =============================================
CREATE PROCEDURE spPlans_DeletePlan
	@Id nvarchar(128)
	
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.AssignedPlan
		WHERE AssignedPlan.PlanId = @Id

	DELETE FROM [dbo].[Plan]
		WHERE Id = @Id
END
