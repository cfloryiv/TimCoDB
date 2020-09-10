CREATE PROCEDURE [dbo].[spCourses_Update]
	@Platform varchar(50),
	@Name varchar(50),
	@Author varchar(50),
	@Cost Decimal,
	@PersonID int,
	@Date datetime2(7),
	@ID int

AS
begin

	set nocount on;

	update dbo.Course
	set Platform=@Platform, [Name]=@Name, Author=@Author, Cost=@Cost, PersonID=@PersonID, [Date]=@Date
	where ID=@ID;
	
end
