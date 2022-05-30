CREATE PROCEDURE Login @Email VARCHAR(255), @Password VARCHAR(2550)
AS
--INSERT INTO employess (email, password) VALUES (@Email, @Password)
SELECT employess.employe_id FROM employess
WHERE employess.email = @Email AND employess.password=@Password
GO