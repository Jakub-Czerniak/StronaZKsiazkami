CREATE PROCEDURE FindOrderDetailsById @OrderId INT
AS
SELECT books.title as BookTitle,  order_detail.amount
FROM books
INNER JOIN order_detail on books.book_id = order_detail.book_id
WHERE order_detail.order_id = @OrderId
GO

