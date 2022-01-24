CREATE DATABASE say_hello;

\c say_hello;

CREATE TABLE people (
  id SERIAL PRIMARY KEY,
  name VARCHAR(255),
  quote VARCHAR(255)
);

INSERT INTO people (name, quote) VALUES
('Frank', 'How are you doing?'),
('Peter', 'Hey guys!');
