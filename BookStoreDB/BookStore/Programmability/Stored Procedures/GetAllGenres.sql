CREATE PROCEDURE [dbo].[GetAllGenres]
AS
	SELECT genres.genre_id as Id, genres.genre_name as GenreName FROM genres
RETURN 0
