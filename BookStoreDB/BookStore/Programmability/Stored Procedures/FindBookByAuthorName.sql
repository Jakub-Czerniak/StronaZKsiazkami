CREATE PROCEDURE [dbo].[FindBookByAuthorName]
(
	@author_lastname VARCHAR (255)
)
AS
BEGIN
DECLARE @AUTHOR_ID AS INT
SET @AUTHOR_ID = (SELECT author_id FROM authors WHERE last_name = @author_lastname)
SELECT title, short_desc, price
FROM books
WHERE author_id = @AUTHOR_ID
END