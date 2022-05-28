CREATE PROCEDURE FindOrderDetailsById @Id INT
AS
SELECT orders.first_name, orders.last_name, addresses.city,addresses.address ,addresses.apartment,addresses.postcode,orders.order_date,orders.cost , books.title, authors.first_name, authors.last_name, order_detail.amount
FROM books
INNER JOIN authors on books.author_id = authors.author_id
INNER JOIN order_detail on books.book_id = order_detail.book_id
INNER JOIN orders on order_detail.book_id = orders.order_id
INNER JOIN addresses on orders.address_id = addresses.address_id
WHERE orders.order_id = @Id
GO

