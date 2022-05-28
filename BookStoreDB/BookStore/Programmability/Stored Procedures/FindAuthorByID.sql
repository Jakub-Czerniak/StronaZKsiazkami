CREATE PROCEDURE [dbo].[FindAuthorByID]
(
	@author_id INT
)
AS
SELECT first_name, last_name
FROM authors
WHERE author_id = @author_id
