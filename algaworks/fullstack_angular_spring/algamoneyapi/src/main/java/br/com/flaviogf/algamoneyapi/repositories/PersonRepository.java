package br.com.flaviogf.algamoneyapi.repositories;

import br.com.flaviogf.algamoneyapi.models.Person;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PersonRepository extends JpaRepository<Person, Long> {
}
