package br.com.flaviogf.marketplace.repositories;

import br.com.flaviogf.marketplace.models.Store;
import org.springframework.data.jpa.repository.JpaRepository;

public interface StoreRepository extends JpaRepository<Store, Long> {
}
