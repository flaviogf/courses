CREATE DATABASE store;

CREATE TABLE transactions (
  id SERIAL PRIMARY KEY,
  ccnum VARCHAR(32),
  date DATE,
  amount MONEY,
  cvv CHAR(2),
  exp DATE
);
