CREATE PROCEDURE [dbo].[FindBookByTitle]
(
	@title INT
)
AS
SELECT book_id, author_id, price, short_desc, amount
FROM books
WHERE title = @title