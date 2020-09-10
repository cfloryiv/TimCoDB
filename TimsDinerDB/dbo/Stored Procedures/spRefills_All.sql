CREATE PROCEDURE [dbo].[spRefills_All]

AS
begin

	set nocount on;

	select [ID], [Name], [Date], [PillSize], [Cost], [PersonID], [Period], [Doctor]
	from dbo.Refill;

end
 