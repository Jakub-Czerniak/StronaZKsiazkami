CREATE PROCEDURE [dbo].[FindGenreByName]
	(@GenreName VARCHAR(255))
AS
	SELECT genres.genre_id as Id, genres.genre_name as GenreName
	FROM genres
	WHERE genres.genre_name = @GenreName

