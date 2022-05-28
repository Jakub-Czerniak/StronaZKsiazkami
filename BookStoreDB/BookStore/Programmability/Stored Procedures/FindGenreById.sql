CREATE PROCEDURE [dbo].[FindGenreById]
( 
	@genre_id INT
)
AS 
SELECT genre_name
FROM genres
WHERE genre_id = @genre_id
