CREATE PROCEDURE [dbo].[AddBookGenre]
	@book_id int = 0,
	@genre_id int =0
AS
IF NOT EXISTS
(
SELECT * WHERE books_genres.book_id = @book_id AND books_genres.genre_id = @genre_id
)
BEGIN
	INSERT INTO books_genres(genre_id, book_id) VALUES( @genre_id, @book_id)
END
RETURN 0
