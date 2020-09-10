CREATE PROCEDURE [dbo].[spRefills_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.Refill
	where ID = @ID;

end
