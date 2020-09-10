CREATE PROCEDURE [dbo].[spTrackings_All]

AS
begin

	set nocount on;

	select [ID], [Date], Qty, PersonID, Item, Depleted, DepletedDate
	from dbo.Tracking;

end
