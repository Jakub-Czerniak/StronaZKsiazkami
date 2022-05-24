CREATE PROCEDURE FindBookById (@id INT)
AS
	SELECT  books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	INNER JOIN authors on books.author_id = authors.author_id
	WHERE books.book_id = @id
RETURN 0
