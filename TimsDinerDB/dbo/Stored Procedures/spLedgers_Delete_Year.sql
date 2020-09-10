CREATE PROCEDURE [dbo].[spLedgers_Delete_Year]
	@Year int
AS
begin

	set nocount on;

	delete
	from dbo.Ledger
	where Year=@Year;

end