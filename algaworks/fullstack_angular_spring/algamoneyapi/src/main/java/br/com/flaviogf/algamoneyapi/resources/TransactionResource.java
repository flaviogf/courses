package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.exceptions.PersonInactiveException;
import br.com.flaviogf.algamoneyapi.models.Person;
import br.com.flaviogf.algamoneyapi.models.Transaction;
import br.com.flaviogf.algamoneyapi.repositories.PersonRepository;
import br.com.flaviogf.algamoneyapi.repositories.TransactionRepository;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.time.LocalDate;
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
    @PreAuthorize("hasRole('READ_TRANSACTION')")
    public ResponseEntity<Page<Transaction>> index(
            @RequestParam(value = "description", required = false) String description,
            @RequestParam(value = "from", required = false) @DateTimeFormat(pattern = "yyyy-MM-dd") LocalDate from,
            @RequestParam(value = "to", required = false) @DateTimeFormat(pattern = "yyyy-MM-dd") LocalDate to,
            Pageable pageable
    ) {
        if (description != null) {
            Page<Transaction> transactions = transactionRepository.findAllByDescription(description, pageable);
            return ResponseEntity.ok(transactions);
        }

        if (from != null && to != null) {
            Page<Transaction> transactions = transactionRepository.findAllByPeriod(from, to, pageable);
            return ResponseEntity.ok(transactions);
        }

        Page<Transaction> transactions = transactionRepository.findAll(pageable);
        return ResponseEntity.ok(transactions);
    }

    @GetMapping("/{id}")
    @PreAuthorize("hasRole('READ_TRANSACTION')")
    public ResponseEntity<Transaction> show(@PathVariable Long id) {
        Optional<Transaction> optional = transactionRepository.findById(id);

        if (!optional.isPresent()) {
            return ResponseEntity.notFound().build();
        }

        Transaction transaction = optional.get();

        return ResponseEntity.ok(transaction);
    }

    @PostMapping
    @PreAuthorize("hasRole('CREATE_TRANSACTION')")
    public ResponseEntity<Transaction> store(@Valid @RequestBody Transaction transaction) {
        Optional<Person> person = personRepository.findById(transaction.getPerson().getId());

        if (!person.isPresent() || person.get().isInactive()) {
            throw new PersonInactiveException(String.format("Person with id %d are inactive and can not register a new transaction", transaction.getPerson().getId()));
        }

        Transaction registered = transactionRepository.save(transaction);

        return ResponseEntity.ok(registered);
    }
}
