CREATE PROCEDURE [dbo].[spSugars_Update]
	@Date datetime2(7),
	@Level int,

	@ID int
AS
begin

	set nocount on;

	update dbo.Sugar
	set [Date]=@Date, Level=@Level
	where ID=@ID;

end