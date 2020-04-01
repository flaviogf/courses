package br.com.flaviogf.manager.repositories;

import br.com.flaviogf.manager.entities.User;

import java.util.Optional;

public interface UserRepository {
    Optional<User> findOne(String username);
}
