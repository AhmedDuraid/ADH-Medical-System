-- =============================================
CREATE PROCEDURE [dbo].[spUsers_GetUsers] 
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[UserName]
      ,[Email]
      ,[EmailConfirmed]
      ,[IsAuthenticated]
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

END
