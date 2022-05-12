CREATE PROCEDURE [dbo].[spGetAllSolutions]
	
AS
BEGIN
	SELECT Solution
	FROM PotentialSolutions
	ORDER BY Solution ASC
END
