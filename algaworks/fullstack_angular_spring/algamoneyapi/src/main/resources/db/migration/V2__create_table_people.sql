CREATE TABLE people (
    id BIGINT(20) PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    active TINYINT(1) NOT NULL,
    street VARCHAR(255) NULL,
    number VARCHAR(255) NULL,
    complement VARCHAR(255) NULL,
    neighborhood VARCHAR(255) NULL,
    zipCode VARCHAR(255) NULL,
    city VARCHAR(255) NULL,
    state VARCHAR(255) NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO people (name, active) VALUES ('Frank', 1);
INSERT INTO people (name, active) VALUES ('Nina', 1);
INSERT INTO people (name, active) VALUES ('Rex', 1);
INSERT INTO people (name, active) VALUES ('Tank', 1);
