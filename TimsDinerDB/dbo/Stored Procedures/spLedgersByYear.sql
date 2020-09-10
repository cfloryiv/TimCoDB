CREATE PROCEDURE [dbo].[spLedgersByYear]
@Year int
AS
begin

	set nocount on;

	select AccountNumber, ClassID, [ID], [Year], Budget, Actual
	from dbo.Ledger
	where [Year]=@Year;

end