CREATE PROCEDURE [dbo].[spDoctors_Insert]
	@Name varchar(50),
	@Hospital varchar(50),
	@TelNo varchar(50),
	@Speciality varchar(50),
	@ID int output
AS
begin

	set nocount on;

	insert into dbo.[Doctor]([Name], Hospital, TelNo, Speciality)
	values (@Name, @Hospital, @TelNo, @Speciality);

	set @ID = SCOPE_IDENTITY();

end