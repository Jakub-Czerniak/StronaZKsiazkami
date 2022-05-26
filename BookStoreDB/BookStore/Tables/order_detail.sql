CREATE TABLE order_detail
(
	detail_id INT IDENTITY (1,1) PRIMARY KEY,
	order_id INT NOT NULL,
	book_id INT NOT NULL,
	amount INT NOT NULL,

	CONSTRAINT fk_book FOREIGN KEY (book_id) REFERENCES books (book_id) ON DELETE CASCADE ON UPDATE CASCADE
)
