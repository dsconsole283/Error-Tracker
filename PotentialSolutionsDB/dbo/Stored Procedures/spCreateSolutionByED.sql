CREATE PROCEDURE [dbo].[spCreateSolutionByED]
	 @Solution varchar(2000)
	,@Description varchar(50)
	,@Cabinet varchar(50)
AS
	IF NOT EXISTS
		(
		SELECT ps.Solution FROM dbo.PotentialSolutions AS ps
		WHERE ps.Solution = @Solution
		)
		BEGIN
		INSERT INTO dbo.PotentialSolutions (Solution)
		VALUES (@Solution)
		END
	IF NOT EXISTS
		(
		SELECT esl.ErrorId, esl.SolutionId FROM dbo.Error_Solution_Link AS esl
		INNER JOIN dbo.PotentialSolutions AS ps ON ps.Id = esl.SolutionId
		INNER JOIN dbo.ErrorDescriptions AS ed ON ed.Id = esl.ErrorId
		INNER JOIN dbo.Cabinet_Platform AS cp ON cp.Id = esl.CabinetId
		WHERE ps.Id = 
				(SELECT ps.Id FROM dbo.PotentialSolutions AS ps WHERE ps.Solution = @Solution)
		AND 
			  ed.Id =
				(SELECT ed.Id FROM dbo.ErrorDescriptions AS ed WHERE ed.Description = @Description)
		AND
			  cp.Id = 
				(SELECT cp.Id FROM dbo.Cabinet_Platform AS cp WHERE cp.Cabinet = @Cabinet)
		)
	BEGIN
		DECLARE 

		@SolutionId int
		,@ErrorId int
		,@CabinetId int

		SET

		@SolutionId =
			(
			SELECT Id
			FROM dbo.PotentialSolutions AS ps
			WHERE ps.Solution = @Solution
			)

		SET

		@ErrorId =
			(
			SELECT Id
			FROM dbo.ErrorDescriptions AS ed
			WHERE ed.Description = @Description
			)

		SET 

		@CabinetId =
			(
			SELECT Id
			FROM dbo.Cabinet_Platform AS cp
			WHERE cp.Cabinet = @Cabinet
			)

		INSERT INTO dbo.Error_Solution_Link (SolutionId, ErrorId, CabinetId)
		VALUES (@SolutionId, @ErrorId, @CabinetId);
	END;