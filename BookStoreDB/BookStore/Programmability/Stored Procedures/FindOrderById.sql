CREATE PROCEDURE [dbo].[FindOrderById]
(
	@order_id INT
)
AS
SELECT adress_id, order_date, cost, curr_status, first_name, last_name
FROM orders
WHERE order_id = @order_id

