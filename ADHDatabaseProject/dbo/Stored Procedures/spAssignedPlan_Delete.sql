-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].spAssignedPlan_Delete
	@Id nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM AssignedPlan
		WHERE Id = @Id
END
