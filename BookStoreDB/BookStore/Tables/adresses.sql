CREATE TABLE adresses
(
	adress_id INT IDENTITY (1,1) PRIMARY KEY,
	city VARCHAR (50) NOT NULL,
	addres VARCHAR (255) NOT NULL,
	apartment VARCHAR (10),
	postcode VARCHAR (6) NOT NULL
);