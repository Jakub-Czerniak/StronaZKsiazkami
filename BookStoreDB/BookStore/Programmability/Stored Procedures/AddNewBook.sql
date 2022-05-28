CREATE PROCEDURE AddNewBook (@title VARCHAR(255), @author_first_name VARCHAR (50), @author_last_name VARCHAR (50), @price SMALLMONEY, @desc VARCHAR(2550), @amount INT, @genre_name VARCHAR(255))
AS
DECLARE @author_id INT;
DECLARE @genre_id INT;
DECLARE @book_id INT;
IF EXISTS
(
	SELECT * FROM authors
	WHERE first_name=@author_first_name AND last_name=@author_last_name
)
BEGIN
	SET @author_id = (SELECT author_id FROM authors
	WHERE first_name=@author_first_name AND last_name=@author_last_name)
	INSERT INTO books(title, author_id, price, short_desc, amount) VALUES(@title, @author_id, @price, @desc, @amount);
	SET @book_id = SCOPE_IDENTITY()
	IF EXISTS
	(SELECT * FROM genres WHERE genre_name=@genre_name)
	BEGIN
		SET @genre_id = (SELECT genre_id FROM genres WHERE genre_name=@genre_name)
		INSERT INTO books_genres (book_id, genre_id) VALUES (@book_id, @genre_id)
	END
	ELSE
	BEGIN
		INSERT INTO genres(genre_name) VALUES (@genre_name)
		SET @genre_id = SCOPE_IDENTITY()
		INSERT INTO books_genres (book_id, genre_id) VALUES (@book_id, @genre_id)

	END
END
ELSE
BEGIN
	INSERT INTO authors(first_name, last_name) VALUES(@author_first_name, @author_last_name)
	SET @author_id = SCOPE_IDENTITY()
	INSERT INTO books(title, author_id, price, short_desc, amount) VALUES(@title, @author_id, @price, @desc, @amount);
	SET @book_id = SCOPE_IDENTITY()
	IF EXISTS
		(SELECT * FROM genres WHERE genre_name=@genre_name)
		BEGIN
			SET @genre_id = (SELECT genre_id FROM genres WHERE genre_name=@genre_name)
			INSERT INTO books_genres (book_id, genre_id) VALUES (@book_id, @genre_id)
		END
		ELSE
		BEGIN
			INSERT INTO genres(genre_name) VALUES (@genre_name)
			SET @genre_id = SCOPE_IDENTITY()
			INSERT INTO books_genres (book_id, genre_id) VALUES (@book_id, @genre_id)

		END
END
GO
