CREATE PROCEDURE AddNewBook (@title VARCHAR(255), @author_first_name VARCHAR (50), @author_last_name VARCHAR (50), @price SMALLMONEY, @desc VARCHAR(2550), @amount INT)
AS
DECLARE @author_id INT;
IF EXISTS
(
SELECT * FROM authors
WHERE first_name=@author_first_name AND last_name=@author_last_name
)
BEGIN
	SET @author_id = (SELECT author_id FROM authors
	WHERE first_name=@author_first_name AND last_name=@author_last_name)
INSERT INTO books(title, author_id, price, short_desc, amount) VALUES(@title, @author_id, @price, @desc, @amount);
END
ELSE
BEGIN
INSERT INTO authors(first_name, last_name) VALUES(@author_first_name, @author_last_name)
SET @author_id = SCOPE_IDENTITY()
INSERT INTO books(title, author_id, price, short_desc, amount) VALUES(@title, @author_id, @price, @desc, @amount);
END
GO
