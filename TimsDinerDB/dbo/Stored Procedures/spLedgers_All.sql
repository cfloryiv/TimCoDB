CREATE PROCEDURE [dbo].[spLedgers_All]
AS
begin

	set nocount on;

	select AccountNumber, ClassID, [ID], [Year], Budget, Actual
	from dbo.Ledger;

end