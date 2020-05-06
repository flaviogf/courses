CREATE TABLE users(
    id BIGINT(20) PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO users VALUES (1, 'admin', 'admin@algamoney.com', '$2a$10$x8XahPQXa2q3pJyoFKVi4uunT1vue8blmSycbep6w8SP5Y310I7HK');
INSERT INTO users VALUES (2, 'frank', 'frank@algamoney.com', '$2a$10$wfVe3lwtRrXTY1Ghb0VSXeJQm7xRlYTv6IunhqhVpaWZ0ZDZ1unAa');
