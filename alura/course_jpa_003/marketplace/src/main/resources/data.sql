INSERT INTO `store` (`name`) VALUES ('Music dot');
INSERT INTO `store` (`name`) VALUES ('Casa do Código');
INSERT INTO `store` (`name`) VALUES ('Musical Alegre');

INSERT INTO `category` (`name`) VALUES ('Technology');
INSERT INTO `category` (`name`) VALUES ('Music');

INSERT INTO `product` (`name`, `cover`, `description`, `price`, `store_id`) VALUES ('Guitar Course', 'guitar-course.jpg', 'Guitar crash course', 399.99, 1);
INSERT INTO `product` (`name`, `cover`, `description`, `price`, `store_id`) VALUES ('Spring Framework', 'spring-framework.jpg', 'Spring Framework crash course', 19.99, 2);
INSERT INTO `product` (`name`, `cover`, `description`, `price`, `store_id`) VALUES ('Guitar', 'guitar.jpg', 'Guitar', 699.99, 3);

INSERT INTO `product_categories` (`product_id`, `categories_id`) VALUES (1, 1);
INSERT INTO `product_categories` (`product_id`, `categories_id`) VALUES (1, 2);
INSERT INTO `product_categories` (`product_id`, `categories_id`) VALUES (2, 1);
INSERT INTO `product_categories` (`product_id`, `categories_id`) VALUES (3, 2);
