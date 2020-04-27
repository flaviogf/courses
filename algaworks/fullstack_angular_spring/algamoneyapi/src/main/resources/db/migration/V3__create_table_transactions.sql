CREATE TABLE transactions (
    id BIGINT(20) PRIMARY KEY AUTO_INCREMENT,
    description VARCHAR(20) NOT NULL,
    due_date DATE NOT NULL,
    pay_date DATE NULL,
    amount DECIMAL(10, 2) NOT NULL,
    note VARCHAR(200) NULL,
    type VARCHAR(20) NOT NULL,
    category_id BIGINT(20) NOT NULL,
    person_id BIGINT(20) NOT NULL,
    FOREIGN KEY(category_id) REFERENCES categories(id),
    FOREIGN KEY(person_id) REFERENCES people(id)
) Engine=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO transactions (description, due_date, pay_date, amount, note, type, category_id, person_id) VALUES('Salary', '2017-06-10', '2017-06-10', 6500.00, null, 'REVENUE', 1, 1)
