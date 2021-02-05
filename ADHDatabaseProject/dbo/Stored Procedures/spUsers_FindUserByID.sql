-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return user information
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_FindUserByID] 
	@UserId nvarchar(256)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[UserName]
      ,[Email]
      ,[EmailConfirmed]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[BirthDate]
      ,[PhoneNumber]
      ,[Gender]
      ,[Nationality]
      ,[Address]
      ,[CreateDate]
  FROM [dbo].[Users]
  WHERE Id = @UserId
END
