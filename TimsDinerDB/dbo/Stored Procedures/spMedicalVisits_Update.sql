CREATE PROCEDURE [dbo].[spMedicalVisits_Update]
	@Doctor varchar(50),
	@Date datetime2(7),
	@Notes varchar(50),
	@Type varchar(50),
	@PersonID int,

	@ID int
AS
begin

	set nocount on;

	update dbo.MedicalVisit
	set Doctor=@Doctor, [Date]=@Date, Notes=@Notes, [Type]=@Type, PersonID=@PersonID
	where ID=@ID;

end
