CREATE PROCEDURE FindAllOrders
AS
SELECT orders.order_id as Id, orders.first_name as FirstName, orders.last_name as LastName, addresses.city, addresses.address, addresses.apartment, addresses.postcode, orders.order_date as OrderDate, orders.cost as TotalCost, orders.curr_status as Status
FROM orders
INNER JOIN addresses on orders.address_id=addresses.address_id
GO
