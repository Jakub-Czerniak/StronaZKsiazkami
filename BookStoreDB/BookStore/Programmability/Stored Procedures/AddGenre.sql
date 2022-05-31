CREATE PROCEDURE [dbo].[AddGenre]
	(@name VARCHAR(255))
AS
	IF NOT EXISTS( SELECT * FROM genres WHERE genres.genre_name = @name)
	BEGIN
	INSERT INTO genres(genre_name) VALUES(@name)
	END
RETURN 0
