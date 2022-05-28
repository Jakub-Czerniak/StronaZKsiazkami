CREATE PROCEDURE PlaceOrder
(
	@firstname VARCHAR(50),
	@lasttname VARCHAR(50),
	@city VARCHAR(50),
	@address VARCHAR(255),
	@apartment VARCHAR(255),
	@postcode VARCHAR(6),
	@cost SMALLMONEY
)
AS
DECLARE @address_id INT

IF NOT EXISTS(SELECT * FROM addresses WHERE city = @city AND address = @address AND apartment = @apartment AND postcode = @postcode)
BEGIN
INSERT INTO addresses (city, address, apartment, postcode)
VALUES(@city, @address, @apartment, @postcode)
SET @address_id = SCOPE_IDENTITY()
END
ELSE
BEGIN
SET @address_id = (SELECT address_id FROM addresses WHERE city = @city AND address = @address AND apartment = @apartment AND postcode = @postcode);
END

INSERT INTO orders (address_id, order_date, cost,curr_status,first_name,last_name)
VALUES(@address_id, (SELECT GETDATE()), @cost, 'Order placed', @firstname,@lasttname)

SELECT SCOPE_IDENTITY() as Id

GO
