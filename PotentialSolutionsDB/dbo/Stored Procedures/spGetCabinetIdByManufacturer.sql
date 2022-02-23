CREATE PROCEDURE [dbo].[spGetCabinetIdByManufacturer]
	@Manufacturer varchar(50)
AS
	SELECT cp.Id
	FROM dbo.Cabinet_Platform AS cp
	INNER JOIN dbo.Manufacturers AS m ON cp.ManufacturerId = m.Id
	WHERE m.Manufacturer = @Manufacturer
	ORDER BY cp.Id ASC;