CREATE TABLE products (
    id serial primary key,
    name varchar,
    description varchar,
    price decimal,
    quantity integer
);

INSERT INTO products (
    name,
    description,
    price,
    quantity
) VALUES (
    'Camiseta',
    'Preta',
    19,
    10
);

INSERT INTO products (
    name,
    description,
    price,
    quantity
) VALUES (
    'Fone',
    'Muito bom',
    99,
    5
);
