CREATE PROCEDURE [dbo].[spSugars_GetById]
@ID int

AS
begin

	set nocount on;

	select [ID], [Date], Level
	from dbo.Sugar
	where ID = @ID;

end