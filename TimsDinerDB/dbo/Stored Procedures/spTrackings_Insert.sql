CREATE PROCEDURE [dbo].[spTrackings_Insert]
	@Date datetime2(7),
	@Qty int,
	@PersonID int,
	@Item nvarchar(50),
	@Depleted nchar(1),
	@DepletedDate datetime2(7),

	@ID int output
AS
begin

	set nocount on;

	insert into dbo.[Tracking]([Date], Qty, PersonID, Item, Depleted, DepletedDate)
	values (@Date, @Qty, @PersonID, @Item, @Depleted, @DepletedDate);

	set @ID = SCOPE_IDENTITY();

end