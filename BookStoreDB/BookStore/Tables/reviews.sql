﻿CREATE TABLE [dbo].[reviews]
(
	review_id INT IDENTITY (1,1) PRIMARY KEY,
	book_id INT NOT NULL,
	username VARCHAR(50) NOT NULL,
	rating SMALLINT NOT NULL,
	text_review VARCHAR(2500),

	CONSTRAINT fk1_book FOREIGN KEY (book_id) REFERENCES books (book_id) ON DELETE CASCADE ON UPDATE CASCADE
)
