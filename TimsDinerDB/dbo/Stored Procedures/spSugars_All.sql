CREATE PROCEDURE [dbo].[spSugars_All]
AS
begin

	set nocount on;

	select [ID], Level, [Date]
	from dbo.Sugar;

end
