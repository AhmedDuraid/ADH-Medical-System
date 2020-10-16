
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-15
-- Description:	Return all assigned med by doctor name
-- =============================================
CREATE PROCEDURE spAassignedMedicines_FindAllByDoctorId
	@DoctorID nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	  SELECT Assigned.Id
		  ,patient.Id AS PatientId
		  ,patient.FirstName AS PatientFirstName
		  ,patient.LastName  AS PatientLastName
		  ,Med.Id AS MedicineId
		  ,Med.[Name] AS MedicineName
		  ,Med.[Description] AS MedicineDescription
		  ,Doctor.Id AS DoctoreID
		  ,Doctor.FirstName AS DoctoreFirstName
		  ,Doctor.LastName AS DoctoreLastNameName
	FROM [dbo].[AssignedMedicines] AS Assigned
	JOIN Users patient ON patient.Id = Assigned.PatientId
	JOIN Users Doctor ON Doctor.Id = Assigned.AddedBy
	JOIN Medicines Med ON Med.Id =Assigned.MedicineId  
	WHERE Assigned.AddedBy = @DoctorID
END
GO