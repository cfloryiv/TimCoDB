CREATE PROCEDURE [dbo].[spMedicines_Insert]
	@Name varchar(50),
	@PillSize varchar(50),
	@Cost decimal,
	@Doctor varchar(50),

	@ID int output
AS
begin

	set nocount on;

	insert into dbo.[Medicine](Name, PillSize, [Cost], Doctor)
	values (@Name, @PillSize, @Cost, @Doctor);

	set @ID = SCOPE_IDENTITY();

end
