CREATE PROCEDURE [dbo].[spCreateEDByCabinet]
	 @Description varchar(2000)
	,@Cabinet varchar(50)
AS
	IF NOT EXISTS
		(
		SELECT ed.Description FROM dbo.ErrorDescriptions AS ed
		WHERE ed.Description = @Description
		)
		BEGIN
		INSERT INTO dbo.ErrorDescriptions (Description)
		VALUES (@Description)
		END
	IF NOT EXISTS
		(
		SELECT cel.ErrorId, cel.CabinetId FROM dbo.Cabinet_Error_Link AS cel
		INNER JOIN dbo.ErrorDescriptions AS ed ON ed.Id = cel.ErrorId
		INNER JOIN dbo.Cabinet_Platform AS cp ON cp.Id = cel.CabinetId
		WHERE cp.Id = 
			(SELECT cp.Id FROM dbo.Cabinet_Platform AS cp WHERE cp.Cabinet = @Cabinet)
		AND 
			  ed.Id =
		    (SELECT ed.Id FROM dbo.ErrorDescriptions AS ed WHERE ed.Description = @Description)
		)
	BEGIN
		DECLARE 

		@CabinetId int
		,@ErrorId int

		SET

		@CabinetId =
			(
			SELECT Id
			FROM dbo.Cabinet_Platform AS cp
			WHERE cp.Cabinet = @Cabinet
			)

		SET

		@ErrorId =
		(
		SELECT Id
		FROM dbo.ErrorDescriptions AS ed
		WHERE ed.Description = @Description
		)

		INSERT INTO dbo.Cabinet_Error_Link (CabinetId, ErrorId)
		VALUES (@CabinetId, @ErrorId);
	END;