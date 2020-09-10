CREATE PROCEDURE [dbo].[spAccounts_Delete]
	@AccountNumber nchar(10),
	@ClassID nchar(10)
AS
begin

	set nocount on;

	delete
	from dbo.Account
	where AccountNumber=@AccountNumber and ClassID=@ClassID;

end