CREATE PROCEDURE [dbo].[spDoctors_Update]
	@Name varchar(50),
	@Hospital varchar(50),
	@TelNo varchar(50),
	@Speciality varchar(50),
	@ID int
AS
begin

	set nocount on;

	update dbo.Doctor
	set [Name]=@Name, Hospital=@Hospital, TelNo=@TelNo, Speciality=@Speciality
	where ID=@ID;


end