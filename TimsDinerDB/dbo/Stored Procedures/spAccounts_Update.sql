CREATE PROCEDURE [dbo].[spAccounts_Update]
	@AccountNumber nchar(10),
	@ClassID nchar(10),
	@Description varchar(50),
	@Type char
AS
begin

	set nocount on;

	update dbo.Account
	set AccountNumber=@AccountNumber, ClassID=@ClassID, [Description]=@Description, [Type]=@Type
	where AccountNumber=@AccountNumber and ClassID=@ClassID;

end