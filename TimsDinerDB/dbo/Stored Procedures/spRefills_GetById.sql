CREATE PROCEDURE [dbo].[spRefills_GetById]
@ID int

AS
begin

	set nocount on;

	select [ID], [Name], [Date], [PillSize], [Cost], [PersonID], [Period], [Doctor]
	from dbo.Refill
	where ID = @ID;

end
 