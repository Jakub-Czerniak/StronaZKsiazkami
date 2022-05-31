CREATE PROCEDURE [dbo].[FindBookByString]
(
	@param1 VARCHAR(255) 
)
AS
	SELECT books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	JOIN authors ON authors.author_id = books.author_id
	WHERE books.title LIKE CONCAT('%',@param1, '%') AND books.amount > 0
	UNION 
	SELECT books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	JOIN authors ON authors.author_id = books.author_id
	WHERE authors.last_name LIKE CONCAT('%', @param1, '%') AND books.amount > 0
	UNION 
	SELECT books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	JOIN authors ON authors.author_id = books.author_id
	WHERE authors.first_name LIKE CONCAT('%', @param1, '%') AND books.amount > 0
	UNION 
	SELECT books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	JOIN authors ON authors.author_id = books.author_id
	WHERE books.short_desc LIKE CONCAT('%', @param1, '%') AND books.amount > 0
RETURN 0