CREATE PROCEDURE [dbo].[spBooks_GetById]
@ID int

AS
begin

	set nocount on;

	select [ID], [Title], [Author], [NumberPages],[Binding],[PubDate],[PersonID],[Date]
	from dbo.Book
	where ID = @ID;

end

