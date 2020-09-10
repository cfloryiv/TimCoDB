CREATE PROCEDURE [dbo].[spDoctors_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.Doctor
	where ID = @ID;

end