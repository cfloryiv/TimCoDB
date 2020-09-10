CREATE PROCEDURE [dbo].[spMedicalVisits_All]

AS
begin

	set nocount on;

	select [ID], [Date], [Doctor], [Notes], [Type], [PersonID]
	from dbo.MedicalVisit;

end
