CREATE PROCEDURE [dbo].[spTrackings_Update]
	@Date datetime2(7),
	@Qty int,
	@PersonID int,
	@Item nvarchar(50),
	@Depleted nchar(1),
	@DepletedDate datetime2(7),

	@ID int
AS
begin

	set nocount on;

	update dbo.Tracking
	set [Date]=@Date, Qty=@Qty, PersonID=@PersonID, Item=@Item, Depleted=@Depleted, DepletedDate=@DepletedDate
	where ID=@ID;

end