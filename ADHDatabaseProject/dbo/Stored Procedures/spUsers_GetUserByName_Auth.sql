-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_GetUserByName_Auth] 
	
	@NormalizedUserName nvarchar(256)
AS
BEGIN

	SET NOCOUNT ON;


	SELECT 
		Id
		,UserName
		,Email
		,EmailConfirmed
		,PasswordHash
		,NormalizedUserName
		,AuthenticationType
		,IsAuthenticated
	FROM Users
	where NormalizedUserName = @NormalizedUserName
END
