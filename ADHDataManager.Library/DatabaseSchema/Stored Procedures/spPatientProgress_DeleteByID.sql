SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-17
-- Description:	Delete progress // admin
-- =============================================
CREATE PROCEDURE spPatientProgress_DeleteByID 
	@ProgressId nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [dbo].[PatientProgress]
      WHERE Id = @ProgressId
END
GO
