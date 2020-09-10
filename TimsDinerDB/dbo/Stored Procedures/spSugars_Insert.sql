CREATE PROCEDURE [dbo].[spSugars_Insert]
	@Date datetime2(7),
	@Level int,
	@ID int output
AS
begin

	set nocount on;

	insert into dbo.Sugar([Date], Level)
	values (@Date, @Level);

	set @ID = SCOPE_IDENTITY();

end
