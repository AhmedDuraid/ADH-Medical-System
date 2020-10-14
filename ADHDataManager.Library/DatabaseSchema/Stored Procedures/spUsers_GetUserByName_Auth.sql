SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return user from user table by his name, Auth system 
-- =============================================
ALTER PROCEDURE [dbo].[spUsers_GetUserByName_Auth] 
	
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
