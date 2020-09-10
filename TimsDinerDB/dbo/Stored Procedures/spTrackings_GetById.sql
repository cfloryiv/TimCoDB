CREATE PROCEDURE [dbo].[spTrackings_GetById]
@ID int

AS
begin

	set nocount on;

	select [ID], [Date], Qty, PersonID, Item, Depleted, DepletedDate
	from dbo.Tracking
	where ID = @ID;

end