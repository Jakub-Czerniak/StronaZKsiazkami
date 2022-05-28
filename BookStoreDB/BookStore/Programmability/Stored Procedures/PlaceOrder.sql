CREATE PROCEDURE [dbo].[PlaceOrder]
(
	@curr_status VARCHAR(255),
	@first_name VARCHAR(50),
	@last_name VARCHAR(50),
	@city VARCHAR(50),
	@addres VARCHAR(255),
	@apartment VARCHAR(255),
	@postcode VARCHAR(6),
	@cost SMALLMONEY
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM adresses WHERE city = @city AND addres = @addres AND apartment = @apartment AND postcode = @postcode)
BEGIN
INSERT INTO adresses (city, addres, apartment, postcode)
VALUES(@city, @addres, @apartment, @postcode)
END

DECLARE @address_id INT
SET @address_id = (SELECT adress_id FROM adresses WHERE city = @city AND addres = @addres AND apartment = @apartment AND postcode = @postcode);
INSERT INTO orders (adress_id, order_date, cost, curr_status,first_name,last_name)
VALUES(@address_id, (SELECT GETDATE()), @cost, @curr_status, @first_name, @last_name	)

END
