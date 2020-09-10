CREATE PROCEDURE [dbo].[spAccounts_Insert]
	@AccountNumber nchar(10),
	@ClassID nchar(10),
	@Description nvarchar(50),
	@Type char
AS
begin

	set nocount on;

	insert into dbo.[Account] (AccountNumber, ClassID, [Description], [Type])
	values (@AccountNumber, @ClassID, @Description, @Type);



end
