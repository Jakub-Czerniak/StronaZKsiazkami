CREATE PROCEDURE [dbo].[AddOrderDetail]
(
	@order_id INT,
	@book_id INT,
	@amount INT
)
AS
	INSERT INTO order_detail (order_id, book_id, amount)
	VALUES	(@order_id, @book_id, @amount)
RETURN 0
