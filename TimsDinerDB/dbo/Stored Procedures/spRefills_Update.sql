CREATE PROCEDURE [dbo].[spRefills_Update]
	@Name varchar(50),
    @Date datetime2(7),
    @PillSize varchar(50),
    @Cost decimal,
    @PersonID int,
    @Period int,
    @Doctor varchar(50),

	@ID int
AS
begin

	set nocount on;

	update dbo.Refill
	set [Name]=@Name, [Date]=@Date, PillSize=@PillSize, [Cost]=@Cost, PersonID=@PersonID, [Period]=@Period, Doctor=@Doctor
	where ID=@ID;

end