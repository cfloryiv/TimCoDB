CREATE PROCEDURE [dbo].[spMedicalVisits_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.MedicalVisit
	where ID = @ID;

end