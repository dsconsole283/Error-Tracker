CREATE PROCEDURE [dbo].[spGetSolutionByErrorDescription]
	@Description varchar(2000)
	,@Cabinet varchar(50)
AS

SET NOCOUNT ON

	SELECT Solution
	FROM dbo.PotentialSolutions AS ps
	INNER JOIN dbo.Error_Solution_Link AS esl ON esl.SolutionId = ps.Id
	INNER JOIN dbo.ErrorDescriptions AS ed ON ed.Id = esl.ErrorId
	INNER JOIN dbo.Cabinet_Platform AS cp ON cp.Id = esl.CabinetId
	WHERE
		ed.Id =
			(SELECT Id FROM dbo.ErrorDescriptions WHERE Description = @Description)
	AND
		cp.Id =
			(SELECT Id FROM dbo.Cabinet_Platform WHERE Cabinet = @Cabinet)
			ORDER BY Solution ASC