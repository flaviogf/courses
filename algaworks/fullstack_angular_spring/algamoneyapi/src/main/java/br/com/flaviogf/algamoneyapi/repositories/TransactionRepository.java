package br.com.flaviogf.algamoneyapi.repositories;

import br.com.flaviogf.algamoneyapi.models.Transaction;
import org.springframework.data.jpa.repository.JpaRepository;

public interface TransactionRepository extends JpaRepository<Transaction, Long> {
}
