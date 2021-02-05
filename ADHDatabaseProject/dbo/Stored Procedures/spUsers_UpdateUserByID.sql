-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	update user by his ID 
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_UpdateUserByID]
	@UserId nvarchar(128)
	,@FirstName nvarchar(128)
	,@MiddleName nvarchar(128)
	,@LastName nvarchar(128)
	,@BirthDate date
	,@PhoneNumber char(15)
	,@Gender char(10)
	,@Nationality nvarchar(50)
	,@Address nvarchar(50)
	

AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [dbo].[Users]
   SET 
      [FirstName] = @FirstName
      ,[MiddleName] = @MiddleName
      ,[LastName] = @LastName
      ,[BirthDate] = @BirthDate
      ,[PhoneNumber] = @PhoneNumber
      ,[Gender] = @Gender
      ,[Nationality] = @Nationality
      ,[Address] =@Address
 WHERE Users.Id=@UserId
END
