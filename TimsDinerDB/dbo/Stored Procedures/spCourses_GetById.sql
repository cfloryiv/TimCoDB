CREATE PROCEDURE [dbo].[spCourses_GetById]
@ID int
AS
begin

	select ID, Platform, [Name], Author, Cost, PersonID, [Date] 
	from dbo.Course
	where ID = @ID;
end
