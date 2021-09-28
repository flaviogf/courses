CREATE TABLE countries (
	country_code char(2) PRIMARY KEY,
	country_name text UNIQUE
);

CREATE TABLE cities (
	name text NOT NULL,
	postal_code varchar(9) CHECK(postal_code <> ''),
	country_code char(2) REFERENCES countries,
	PRIMARY KEY(country_code, postal_code)
);

CREATE TABLE venues (
	venue_id SERIAL PRIMARY KEY,
	name varchar(255),
	street_address text,
	type char(7) CHECK(type in ('public', 'private')) DEFAULT 'public',
	postal_code varchar(9),
	country_code char(2),
	FOREIGN KEY(country_code, postal_code) REFERENCES cities (country_code, postal_code) MATCH FULL
);

CREATE TABLE events (
	event_id SERIAL PRIMARY KEY,
	title text,
	starts timestamp with time zone,
	ends timestamp with time zone,
	venue_id int REFERENCES venues
);

INSERT INTO countries VALUES
('us', 'United States'),
('mx', 'Mexico'),
('au', 'Australia'),
('gb', 'United Kingdom'),
('de', 'Germany'),
('ll', 'Loompaland');

INSERT INTO cities VALUES
('Portland', '97206', 'us');

INSERT INTO venues (name, postal_code, country_code) VALUES
('Voodoo Doughnut', '97206', 'us');

INSERT INTO events (title, starts, ends, venue_id) VALUES
('Fight Club', '2018-02-15 17:30:00', '2018-02-15 19:30:00', 1),
('April Fools Day', '2018-04-01 00:00:00', '2018-04-01 23:59:00', NULL),
('Christmas Day', '2018-02-15 19:30:00', '2018-12-25 23:59:00', NULL);
