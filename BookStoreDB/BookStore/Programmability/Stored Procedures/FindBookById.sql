CREATE PROCEDURE FindBookById (@id INT)
AS
	SELECT  books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount, genres.genre_name
	FROM books
	JOIN authors ON authors.author_id = books.author_id
	JOIN genres ON genre_id = (SELECT books_genres.genre_id FROM books_genres WHERE books_genres.book_id = @id)
	WHERE books.book_id = @id
RETURN 0
