CREATE PROCEDURE [dbo].[FindAdressById]
(
	@adress_id INT
)
AS
SELECT city, addres, apartment, postcode
FROM adresses
WHERE adress_id = @adress_id

