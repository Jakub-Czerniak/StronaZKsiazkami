CREATE PROCEDURE DeleteOrder @Id INT
AS
DELETE FROM order_detail 
WHERE order_detail.order_id = @Id
DELETE FROM orders
WHERE orders.order_id = @Id
GO