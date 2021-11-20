CREATE PROCEDURE [dbo].[spCreateCabinetByManufacturer]
	@Cabinet varchar(50),
	@Manufacturer varchar(50)

AS

DECLARE @ManufacturerId int

SET @ManufacturerId = (SELECT Id
	FROM dbo.Manufacturers
	WHERE Manufacturer = @Manufacturer)

IF EXISTS 
(
	SELECT Cabinet 
	FROM dbo.Cabinet_Platform 
	WHERE Cabinet = @Cabinet
)
	RETURN 0
ELSE
	INSERT INTO dbo.Cabinet_Platform (Cabinet, ManufacturerId)
	VALUES (@Cabinet, @ManufacturerId);
