-- =============================================
-- Author:		dbo
-- Create date: 2020-10-20
-- Description:	insert new test 
-- =============================================
CREATE PROCEDURE [dbo].spLabTests_AddNewTest
	@TestName nvarchar(128)
	,@Description TEXT
	,@TestId nvarchar(128)

AS
BEGIN

	SET NOCOUNT ON;

   INSERT INTO [dbo].[LabTests]
           ([Id]
           ,[TestName]
           ,[Description])
     VALUES
           (@TestId
           ,@TestName
           ,@Description)
END
