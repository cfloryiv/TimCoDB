CREATE PROCEDURE [dbo].[spMedicines_Update]
	@Name varchar(50),
	@PillSize varchar(50),
	@Cost decimal,
	@Doctor varchar(50),

	@ID int
AS
begin

	set nocount on;

	update dbo.Medicine
	set [Name]=@Name, PillSize=@PillSize, [Cost]=@Cost, Doctor=@Doctor
	where ID=@ID;


end