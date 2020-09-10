CREATE PROCEDURE [dbo].[spLedgers_Delete]
	@Id int
AS
begin

	set nocount on;

	delete
	from dbo.Ledger
	where Id=@Id;

end