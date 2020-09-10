CREATE PROCEDURE [dbo].[spMedicines_Delete]
	@ID int
AS
begin

	set nocount on;

	delete
	from dbo.Medicine
	where ID = @ID;

end