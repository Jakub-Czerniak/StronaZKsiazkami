CREATE PROCEDURE ChangeOrderStatus (@order_id INT ,@status VARCHAR(255))
AS
UPDATE orders
SET curr_status = @status
WHERE order_id = @order_id
GO
