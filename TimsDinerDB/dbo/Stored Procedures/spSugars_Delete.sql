CREATE PROCEDURE [dbo].[spSugars_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.Sugar
	where ID = @ID;

end
