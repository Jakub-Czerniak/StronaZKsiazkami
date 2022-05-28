CREATE PROCEDURE [dbo].[FindReviewsByBookId]
(
	@book_id INT
)
AS
SELECT review_id as Id,book_id as BookId, rating as Rating, username as Username, text_review as TextReview
FROM reviews
WHERE book_id = @book_id