CREATE PROCEDURE [dbo].[spBooks_Update]
	@Title varchar(50),
	@Author varchar(50),
	@Binding varchar(50),
	@NumberPages int,
	@PersonID int,
	@PubDate datetime2(7),
	@Date datetime2(7),
	@ID int
AS
begin

	set nocount on;

	update dbo.[Book]
	set Title=@Title, Author=@Author, [Binding]=@Binding, NumberPages=@NumberPages, PersonID=@PersonID, PubDate=@PubDate, [Date]=@Date
	where ID=@ID;

end