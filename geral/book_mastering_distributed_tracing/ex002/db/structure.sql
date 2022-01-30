CREATE TABLE people(
  id SERIAL PRIMARY KEY,
  name VARCHAR(250),
  quote VARCHAR(250)
);

INSERT INTO people (name, quote) VALUES
('Frank', 'How are you doing?'),
('Peter', 'Hey guys!');
