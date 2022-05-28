CREATE PROCEDURE AddOrderDetails 
(
	@OrderId INT,
	@BookId INT,
	@Amount INT
)
AS
INSERT INTO order_detail (order_id, book_id, amount)
VALUES (@OrderId, @BookId, @Amount)
UPDATE books 
SET amount = amount - @Amount
WHERE book_id = @BookId
GO
