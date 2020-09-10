CREATE PROCEDURE [dbo].[spLedgers_Insert]
	@AccountNumber nchar(10),
	@ClassID nchar(10),
	@Year int,
	@Budget money,
	@Actual money,
	@ID int output
AS
begin

	set nocount on;

	insert into dbo.Ledger (AccountNumber, ClassID, [Year], Budget, Actual)
	values (@AccountNumber, @ClassID, @Year, @Budget, @Actual)

	set @ID = SCOPE_IDENTITY();

end
