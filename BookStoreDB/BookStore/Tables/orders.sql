CREATE TABLE orders
(
	order_id INT IDENTITY (1,1) PRIMARY KEY,
	address_id INT NOT NULL,
	order_date DATETIME2 NOT NULL,
	cost SMALLMONEY NOT NULL,
	curr_status VARCHAR(255) NOT NULL,
	first_name VARCHAR (50) NOT NULL,
	last_name VARCHAR (50) NOT NULL,

	CONSTRAINT fk_adress FOREIGN KEY (address_id) REFERENCES addresses (address_id) ON DELETE CASCADE ON UPDATE CASCADE
);
