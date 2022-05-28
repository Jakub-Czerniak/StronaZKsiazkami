CREATE TABLE addresses
(
	address_id INT IDENTITY (1,1) PRIMARY KEY,
	city VARCHAR (50) NOT NULL,
	address VARCHAR (255) NOT NULL,
	apartment VARCHAR (10),
	postcode VARCHAR (6) NOT NULL
);