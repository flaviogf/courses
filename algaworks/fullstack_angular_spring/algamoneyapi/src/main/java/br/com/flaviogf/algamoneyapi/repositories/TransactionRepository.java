package br.com.flaviogf.algamoneyapi.repositories;

import br.com.flaviogf.algamoneyapi.models.Transaction;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.time.LocalDate;

public interface TransactionRepository extends JpaRepository<Transaction, Long> {
    @Query("SELECT t FROM Transaction t WHERE t.description LIKE %:description% ORDER BY t.id")
    Page<Transaction> findAllByDescription(@Param("description") String description, Pageable pageable);

    @Query("SELECT t FROM Transaction t WHERE t.dueDate >= :from AND t.dueDate <= :to ORDER BY t.id")
    Page<Transaction> findAllByPeriod(@Param("from") LocalDate from, @Param("to") LocalDate to, Pageable pageable);
}
