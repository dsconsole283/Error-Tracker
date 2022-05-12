CREATE PROCEDURE [dbo].[spGetErrorsByCabinet]
	@Cabinet varchar(50)
AS

SET NOCOUNT ON

	SELECT [Description]
	FROM dbo.ErrorDescriptions AS ed
	INNER JOIN dbo.Cabinet_Error_Link AS cel ON cel.ErrorId = ed.Id
	INNER JOIN dbo.Cabinet_Platform AS cp ON cp.Id = cel.CabinetId
	WHERE CabinetId = (SELECT Id FROM dbo.Cabinet_Platform WHERE Cabinet = @Cabinet)
	ORDER BY [Description] ASC