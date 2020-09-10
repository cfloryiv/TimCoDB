CREATE PROCEDURE [dbo].[spMedicalVisits_Insert]
	@Doctor varchar(50),
	@Date datetime2(7),
	@Notes varchar(50),
	@Type varchar(50),
	@PersonID int,

	@ID int output
AS
begin

	set nocount on;

	insert into dbo.[MedicalVisit](Doctor, [Date], Notes, [Type], PersonID)
	values (@Doctor, @Date, @Notes, @Type, @PersonID);

	set @ID = SCOPE_IDENTITY();

end
