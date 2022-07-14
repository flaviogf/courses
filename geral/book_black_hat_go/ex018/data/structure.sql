CREATE DATABASE store;

\c store;

CREATE TABLE public.transactions (
  id SERIAL PRIMARY KEY,
  ccnum VARCHAR(32),
  date DATE,
  amount MONEY,
  cvv CHAR(4),
  exp DATE
);
