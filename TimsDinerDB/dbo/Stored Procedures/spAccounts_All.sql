CREATE PROCEDURE [dbo].[spAccounts_All]
AS
begin

	set nocount on;

	select AccountNumber, ClassID, [Description], [Type]
	from dbo.Account;

end