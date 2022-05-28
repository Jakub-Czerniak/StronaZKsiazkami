CREATE PROCEDURE [dbo].[PlaceReview]
(
	@book_id INT,
	@rating INT,
	@review VARCHAR(2550),
	@username VARCHAR(50)
)
AS
BEGIN

INSERT INTO reviews
VALUES(@book_id, @username, @rating,@review)
END
