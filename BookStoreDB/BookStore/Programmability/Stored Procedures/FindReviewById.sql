CREATE PROCEDURE [dbo].[FindReviewById]
(
	@review_id INT
)
AS
SELECT book_id, username, rating, text_review
FROM reviews
WHERE review_id = @review_id

