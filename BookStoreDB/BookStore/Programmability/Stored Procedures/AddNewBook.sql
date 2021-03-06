CREATE PROCEDURE AddNewBook (@title VARCHAR(255), @author_first_name VARCHAR (50), @author_last_name VARCHAR (50), @price SMALLMONEY, @desc VARCHAR(2550), @amount INT)
AS
DECLARE @author_id INT;
DECLARE @book_id INT;

IF EXISTS
(
	SELECT * FROM authors
	WHERE first_name=@author_first_name AND last_name=@author_last_name
)
BEGIN
	IF NOT EXISTS
	(
		SELECT * FROM books
		WHERE title=@title 
	)
	BEGIN
		SET @author_id = (SELECT author_id FROM authors
		WHERE first_name=@author_first_name AND last_name=@author_last_name)
		INSERT INTO books(title, author_id, price, short_desc, amount) VALUES(@title, @author_id, @price, @desc, @amount);
		SET @book_id = SCOPE_IDENTITY()
	END
	ELSE
		DECLARE @remaining_amount INT;
		SET @remaining_amount = (SELECT amount FROM books WHERE title=@title)
		SET @amount = @remaining_amount + @amount
		UPDATE books SET amount = @amount WHERE	 title=@title 
		UPDATE books SET price = @price  WHERE	title=@title 
		UPDATE books SET short_desc = @desc  WHERE	title=@title 
		SELECT books.book_id as Id FROM books
		WHERE title = @title
END
ELSE
BEGIN
	INSERT INTO authors(first_name, last_name) VALUES(@author_first_name, @author_last_name)
	SET @author_id = SCOPE_IDENTITY()
	INSERT INTO books(title, author_id, price, short_desc, amount) VALUES(@title, @author_id, @price, @desc, @amount);
	SET @book_id = SCOPE_IDENTITY() 
	SELECT SCOPE_IDENTITY() as Id
END

GO
