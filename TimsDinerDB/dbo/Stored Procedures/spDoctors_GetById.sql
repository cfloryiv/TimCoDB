CREATE PROCEDURE [dbo].[spDoctors_GetById]
@ID int

AS
begin

	set nocount on;

	select [ID], [Name], [Hospital], [TelNo], [Speciality]
	from dbo.Doctor
	where ID = @ID;

end
