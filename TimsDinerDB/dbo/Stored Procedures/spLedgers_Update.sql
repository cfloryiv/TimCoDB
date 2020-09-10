CREATE PROCEDURE [dbo].[spLedgers_Update]
	@AccountNumber nchar(10),
	@ClassID nchar(10),
	@Year int,
	@Budget money,
	@Actual money,
	@ID int
AS
begin

	set nocount on;

	update dbo.Ledger
	set AccountNumber=@AccountNumber, ClassID=@ClassID, [Year]=@Year, Budget=@Budget, Actual=@Actual
	where ID=@ID;


end