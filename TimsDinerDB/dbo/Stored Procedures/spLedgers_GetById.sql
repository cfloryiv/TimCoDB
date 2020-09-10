CREATE PROCEDURE [dbo].[spLedgers_GetById]
@Id int

AS
begin

	set nocount on;

	select [Id], AccountNumber, ClassID, [Year], Budget, Actual
	from dbo.Ledger
	where Id = @Id;

end