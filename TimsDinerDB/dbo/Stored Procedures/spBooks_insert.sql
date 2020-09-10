CREATE PROCEDURE [dbo].[spBooks_insert]
	@Title varchar(50),
	@Author varchar(50),
	@Binding varchar(50),
	@NumberPages int,
	@PersonID int,
	@PubDate datetime2(7),
	@Date datetime2(7),
	@ID int output
AS
begin

	set nocount on;

	insert into dbo.[Book](Title, Author, [Binding], NumberPages, PersonID, PubDate, [Date])
	values (@Title, @Author, @Binding, @NumberPages, @PersonID, @PubDate, @Date);

	set @ID = SCOPE_IDENTITY();

end