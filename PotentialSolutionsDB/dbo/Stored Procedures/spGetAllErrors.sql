CREATE PROCEDURE [dbo].[spGetAllErrors]
	
AS
BEGIN
	SELECT [Description]
	FROM ErrorDescriptions
	ORDER BY [Description] ASC
END
