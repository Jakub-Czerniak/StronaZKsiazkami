CREATE PROCEDURE [dbo].[FindAllBookGenres]
	@book_id int = 0
AS
	SELECT genres.genre_name from books_genres
	INNER JOIN books on books_genres.book_id = books.book_id
	INNER JOIN genres on books_genres.genre_id = genres.genre_id
RETURN 0
