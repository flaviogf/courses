CREATE TABLE user_permissions(
    user_id BIGINT(20),
    permission_id BIGINT(20),
    PRIMARY KEY(user_id, permission_id),
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (permission_id) REFERENCES permissions(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO user_permissions VALUES(1, 1);
INSERT INTO user_permissions VALUES(1, 2);
INSERT INTO user_permissions VALUES(1, 3);
INSERT INTO user_permissions VALUES(1, 4);
INSERT INTO user_permissions VALUES(1, 5);
INSERT INTO user_permissions VALUES(1, 6);
INSERT INTO user_permissions VALUES(1, 7);
INSERT INTO user_permissions VALUES(1, 8);

INSERT INTO user_permissions VALUES(2, 2);
INSERT INTO user_permissions VALUES(2, 5);
INSERT INTO user_permissions VALUES(2, 8);
