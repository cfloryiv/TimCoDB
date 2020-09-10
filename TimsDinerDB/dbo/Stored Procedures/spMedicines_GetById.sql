CREATE PROCEDURE [dbo].[spMedicines_GetById]
@ID int


AS
begin

	set nocount on;

	select [ID], [Name], PillSize, [Cost], Doctor
	from dbo.Medicine
	where ID = @ID;

end
