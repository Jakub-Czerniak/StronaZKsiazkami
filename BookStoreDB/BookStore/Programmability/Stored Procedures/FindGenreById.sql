CREATE PROCEDURE [dbo].[FindGenreById]
( 
	@genre_id INT
)
AS 
SELECT genre_id as Id, genre_name as GenreName
FROM genres
WHERE genre_id = @genre_id
