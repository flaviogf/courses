CREATE TABLE categories (
    id BIGINT(20) PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO categories (name) VALUES ("Recreation");
INSERT INTO categories (name) VALUES ("Food");
INSERT INTO categories (name) VALUES ("Supermarket");
INSERT INTO categories (name) VALUES ("Pharmacy");
INSERT INTO categories (name) VALUES ("Other");
