﻿CREATE PROCEDURE FindAllBooks 
AS
	SELECT books.title, authors.first_name as Author_first_name, authors.last_name as Author_last_name, books.short_desc, books.price, books.amount
	FROM books
	INNER JOIN authors on books.author_id =authors.author_id
GO
