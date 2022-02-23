CREATE PROCEDURE [dbo].[spGetCabinetsbyManufacturer]
	@Manufacturer varchar(50)
AS

SET NOCOUNT ON

	SELECT Cabinet
	FROM dbo.Cabinet_Platform
	INNER JOIN dbo.Manufacturers ON dbo.Cabinet_Platform.ManufacturerId = dbo.Manufacturers.Id
	WHERE Manufacturers.Id = (
			
			SELECT Id
			FROM dbo.Manufacturers
			WHERE Manufacturer = @Manufacturer
	)
	ORDER BY Cabinet ASC;