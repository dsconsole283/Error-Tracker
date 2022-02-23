CREATE PROCEDURE [dbo].[spCreateManufacturer]
	@Manufacturer varchar(50)

AS
IF EXISTS 
(
	SELECT Manufacturer
	FROM dbo.Manufacturers 
	WHERE Manufacturer = @Manufacturer
)
	RETURN 0
ELSE
	INSERT INTO dbo.Manufacturers (Manufacturer)
	VALUES (@Manufacturer);