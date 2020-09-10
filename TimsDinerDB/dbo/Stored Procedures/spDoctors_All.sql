CREATE PROCEDURE [dbo].[spDoctors_All]

AS
begin

	set nocount on;

	select [ID], [Name], [Hospital], [TelNo], [Speciality]
	from dbo.Doctor;
end
