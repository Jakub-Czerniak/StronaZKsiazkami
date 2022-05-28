CREATE PROCEDURE [dbo].[FindBookByAuthorId]
(
	@author_id VARCHAR (255)
)
AS
SELECT book_id, title, price, short_desc, amount
FROM books
WHERE author_id = @author_id
