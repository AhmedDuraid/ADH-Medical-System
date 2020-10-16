
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	AddNew request
-- =============================================
CREATE PROCEDURE spTestRequests_AddNewRequest
	@Id nvarchar(128)
	,@PatientId nvarchar(128)
	,@TestId nvarchar(128)
	,@CreatorID nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

   INSERT INTO [dbo].[TestRequests]
		   ([Id]
		   ,[Date]
		   ,[PatientId]
		   ,[TestId]
		   ,[CreatorID])
	 VALUES
		   (@Id
		   ,GETDATE()
		   ,@PatientId
		   ,@TestId
		   ,@CreatorID
		   )
END
GO
