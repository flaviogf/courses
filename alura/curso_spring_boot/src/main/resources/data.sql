DROP TABLE IF EXISTS course;

CREATE TABLE course
(
    id       INT PRIMARY KEY,
    name     VARCHAR(250),
    category VARCHAR(250)
);

INSERT INTO course
VALUES (1, 'Spring Boot', 'Programming');

INSERT INTO course
VALUES (2, '.NET Core', 'Programming');
