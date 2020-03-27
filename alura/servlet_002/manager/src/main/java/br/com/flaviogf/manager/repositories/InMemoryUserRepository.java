package br.com.flaviogf.manager.repositories;

import br.com.flaviogf.manager.entities.User;

import java.util.HashMap;
import java.util.Map;
import java.util.Optional;

public class InMemoryUserRepository implements UserRepository {
    private static Map<String, User> users = new HashMap<>();

    static {
        User user = new User("frank", "test");
        users.put(user.getUsername(), user);
    }

    @Override
    public Optional<User> findOne(String username) {
        User user = users.get(username);

        if (user == null) {

            return Optional.empty();
        }

        return Optional.of(user);
    }
}
