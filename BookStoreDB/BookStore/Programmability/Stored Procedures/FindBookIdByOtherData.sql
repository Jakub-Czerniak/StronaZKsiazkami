CREATE PROCEDURE [dbo].[FindBookIdByOtherData]
(@Title VARCHAR(255), @Short_desc VARCHAR(2550), @Price SMALLMONEY, @Amount INT)
AS
	SELECT  books.book_id as Id,books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	JOIN authors ON authors.author_id = books.author_id
	WHERE books.title = @Title AND books.short_desc = @Short_desc AND books.price = @Price AND books.amount = @Amount
RETURN 0
