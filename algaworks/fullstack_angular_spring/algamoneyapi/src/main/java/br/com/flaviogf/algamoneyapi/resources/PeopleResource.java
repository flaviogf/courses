package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.models.Person;
import br.com.flaviogf.algamoneyapi.repositories.PersonRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.util.BeanDefinitionUtils;
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

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> destroy(@PathVariable Long id) {
        Optional<Person> person = personRepository.findById(id);

        if (!person.isPresent()) {
            return ResponseEntity.notFound().build();
        }

        personRepository.delete(person.get());

        return ResponseEntity.noContent().build();
    }

    @PutMapping("/{id}")
    public ResponseEntity<Person> update(@PathVariable Long id, @RequestBody Person person) {
        Optional<Person> optional = personRepository.findById(id);

        if (!optional.isPresent()) {
            return ResponseEntity.notFound().build();
        }

        Person registered = optional.get();

        BeanUtils.copyProperties(person, registered, "id");

        personRepository.save(registered);

        return ResponseEntity.ok(person);
    }
}
