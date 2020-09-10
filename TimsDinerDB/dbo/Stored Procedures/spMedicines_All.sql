CREATE PROCEDURE [dbo].[spMedicines_All]

AS
begin

	set nocount on;

	select [ID], [Name], PillSize, [Cost], Doctor
	from dbo.Medicine;

end
