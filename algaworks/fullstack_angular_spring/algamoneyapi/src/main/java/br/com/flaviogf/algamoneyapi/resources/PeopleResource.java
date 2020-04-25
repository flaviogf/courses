package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.models.Person;
import br.com.flaviogf.algamoneyapi.repositories.PersonRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import java.net.URI;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/people")
public class PeopleResource {
    private final PersonRepository personRepository;

    @Autowired
    public PeopleResource(PersonRepository personRepository) {
        this.personRepository = personRepository;
    }

    @GetMapping
    public ResponseEntity<List<Person>> index() {
        List<Person> people = personRepository.findAll();

        return ResponseEntity.ok(people);
    }

    @PostMapping
    public ResponseEntity<Person> store(@RequestBody Person person) {
        Person created = personRepository.save(person);

        URI uri = ServletUriComponentsBuilder.fromCurrentRequest().path("/{id}").buildAndExpand(created.getId()).toUri();

        return ResponseEntity.created(uri).body(person);
    }

    @GetMapping("/{id}")
    public ResponseEntity<Person> show(@PathVariable Long id) {
        Optional<Person> person = personRepository.findById(id);

        return person.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
