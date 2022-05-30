CREATE TABLE employess
(
	employe_id INT IDENTITY (1,1) PRIMARY KEY,
	email VARCHAR (255) NOT NULL,
	UNIQUE(email),
	password VARCHAR (2550) NOT NULL
)
