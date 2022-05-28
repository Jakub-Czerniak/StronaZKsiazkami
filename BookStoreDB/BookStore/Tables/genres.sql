CREATE TABLE [dbo].[genres]
(
	genre_id INT IDENTITY (1,1) PRIMARY KEY,
	genre_name VARCHAR (255) NOT NULL,
	UNIQUE(genre_name)
)
