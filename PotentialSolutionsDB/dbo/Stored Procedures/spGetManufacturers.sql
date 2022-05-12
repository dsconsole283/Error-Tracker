CREATE PROCEDURE [dbo].[spGetManufacturers]
	
AS
	SELECT Manufacturer
	FROM dbo.Manufacturers
	ORDER BY Manufacturer ASC