CREATE PROCEDURE [dbo].[spCourses_All]

AS
begin

	select ID, Platform, Name, Author, Cost, PersonID, Date 
	from dbo.Course;
end
