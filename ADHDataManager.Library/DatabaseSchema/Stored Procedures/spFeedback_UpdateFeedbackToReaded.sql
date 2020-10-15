SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spFeedback_UpdateFeedbackToReaded
	@ReaderId nvarchar(128),
	@FeedbackId nvarchar(128)
	
AS
BEGIN
	SET NOCOUNT ON;

   UPDATE [dbo].[Feedback]
   SET 
      [HasBeenRead] = 1
      ,[UpdatedDate] = GETDATE()
      ,[ReadedBy] = @ReaderId
 WHERE Id=@FeedbackId
END
GO
