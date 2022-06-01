CREATE PROCEDURE [dbo].[FindBookByTitle]
(
	@title VARCHAR(255)
)
AS
	SELECT  books.book_id as Id
FROM books
INNER JOIN authors on books.author_id = authors.author_id
WHERE title = @title