CREATE PROCEDURE [dbo].[GetAllBookGenre]
AS
	SET NOCOUNT ON;
	SELECT books.book_id as BookId, genres.genre_id as GenreId from books_genres
	INNER JOIN books ON books_genres.book_id = books.book_id
	INNER JOIN genres ON books_genres.genre_id = genres.genre_id
RETURN 0
