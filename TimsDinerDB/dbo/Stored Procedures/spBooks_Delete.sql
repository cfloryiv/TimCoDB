CREATE PROCEDURE [dbo].[spBooks_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.[Book]
	where ID = @ID;

end