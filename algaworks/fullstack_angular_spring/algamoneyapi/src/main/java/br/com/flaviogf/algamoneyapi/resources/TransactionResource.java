package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.models.Transaction;
import br.com.flaviogf.algamoneyapi.repositories.TransactionRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/transactions")
public class TransactionResource {
    private final TransactionRepository transactionRepository;

    public TransactionResource(TransactionRepository transactionRepository) {
        this.transactionRepository = transactionRepository;
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
}
