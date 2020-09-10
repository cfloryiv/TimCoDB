CREATE PROCEDURE [dbo].[spAccounts_GetById]
@AccountNumber nchar(10),
@ClassID nchar(10)

AS
begin

	set nocount on;

	select AccountNumber, ClassID, [Description], [Type]
	from dbo.Account
	where AccountNumber=@AccountNumber and ClassID=@ClassID;

end
