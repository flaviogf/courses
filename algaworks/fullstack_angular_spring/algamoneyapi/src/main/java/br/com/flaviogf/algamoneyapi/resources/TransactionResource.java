package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.exceptions.PersonInactiveException;
import br.com.flaviogf.algamoneyapi.models.Person;
import br.com.flaviogf.algamoneyapi.models.Transaction;
import br.com.flaviogf.algamoneyapi.repositories.PersonRepository;
import br.com.flaviogf.algamoneyapi.repositories.TransactionRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/transactions")
public class TransactionResource {
    private final TransactionRepository transactionRepository;
    private final PersonRepository personRepository;

    public TransactionResource(TransactionRepository transactionRepository, PersonRepository personRepository) {
        this.transactionRepository = transactionRepository;
        this.personRepository = personRepository;
    }

    @GetMapping
    public ResponseEntity<List<Transaction>> index() {
        List<Transaction> transactions = transactionRepository.findAll();

        return ResponseEntity.ok(transactions);
    }

    @GetMapping("/{id}")
    public ResponseEntity<Transaction> show(@PathVariable Long id) {
        Optional<Transaction> optional = transactionRepository.findById(id);

        if (!optional.isPresent()) {
            return ResponseEntity.notFound().build();
        }

        Transaction transaction = optional.get();

        return ResponseEntity.ok(transaction);
    }

    @PostMapping
    public ResponseEntity<Transaction> store(@Valid @RequestBody Transaction transaction) {
        Optional<Person> person = personRepository.findById(transaction.getPerson().getId());

        if (!person.isPresent() || person.get().isInactive()) {
            throw new PersonInactiveException(String.format("Person with id %d are inactive and can not register a new transaction", transaction.getPerson().getId()));
        }

        Transaction registered = transactionRepository.save(transaction);

        return ResponseEntity.ok(registered);
    }
}
