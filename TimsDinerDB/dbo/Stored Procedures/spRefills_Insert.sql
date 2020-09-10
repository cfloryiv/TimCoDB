CREATE PROCEDURE [dbo].[spRefills_Insert]
	@Name varchar(50),
    @Date datetime2(7),
    @PillSize varchar(50),
    @Cost decimal,
    @PersonID int,
    @Period int,
    @Doctor varchar(50),

	@ID int output
AS
begin

	set nocount on;

	insert into dbo.[Refill]([Name], [Date], PillSize, Cost, PersonID, [Period], Doctor)
	values (@Name, @Date, @PillSize, @Cost, @PersonID, @Period, @Doctor);

	set @ID = SCOPE_IDENTITY();

end

