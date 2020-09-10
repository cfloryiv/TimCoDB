CREATE PROCEDURE [dbo].[spBooks_All]
AS
begin

	set nocount on;

	select [ID], [Title], [Author], [NumberPages],[Binding],[PubDate],[PersonID],[Date]
	from dbo.Book;

end

