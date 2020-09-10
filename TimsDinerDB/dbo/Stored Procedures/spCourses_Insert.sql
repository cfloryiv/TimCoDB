CREATE PROCEDURE [dbo].[spCourses_Insert]
	@Platform varchar(50),
	@Name varchar(50),
	@Author varchar(50),
	@Cost Decimal,
	@PersonID int,
	@Date datetime2(7),
	@ID int output

AS
begin

	set nocount on;

	insert into dbo.[Course](Platform, [Name], Author, Cost, PersonID, [Date])
	values (@Platform, @Name, @Author, @Cost, @PersonID, @Date);

	set @ID = SCOPE_IDENTITY();
	
end
