CREATE PROCEDURE [dbo].[spMedicalVisits_GetById]
@ID int


AS
begin

	set nocount on;

	select [ID], [Date], [Doctor], [Notes], [Type], [PersonID]
	from dbo.MedicalVisit
	where ID = @ID;

end
