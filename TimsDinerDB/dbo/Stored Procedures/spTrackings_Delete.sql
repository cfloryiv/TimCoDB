CREATE PROCEDURE [dbo].[spTrackings_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.Tracking
	where ID = @ID;

end