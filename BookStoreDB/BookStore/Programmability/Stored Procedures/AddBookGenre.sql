CREATE PROCEDURE [dbo].[AddBookGenre]
	@book_id int = 0,
	@genre_id int =0
AS
	INSERT INTO books_genres(genre_id, book_id) VALUES( @genre_id, @book_id)
RETURN 0
