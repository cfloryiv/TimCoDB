CREATE PROCEDURE [dbo].[spCourses_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.[Course]
	where ID = @ID;

end