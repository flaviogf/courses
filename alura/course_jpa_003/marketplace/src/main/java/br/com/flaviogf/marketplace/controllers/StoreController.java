package br.com.flaviogf.marketplace.controllers;

import br.com.flaviogf.marketplace.models.Store;
import br.com.flaviogf.marketplace.repositories.StoreRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/store")
public class StoreController {
    private final StoreRepository storeRepository;

    @Autowired
    public StoreController(StoreRepository storeRepository) {
        this.storeRepository = storeRepository;
    }

    @GetMapping
    public ResponseEntity<List<Store>> index() {
        List<Store> stores = storeRepository.findAll();

        return ResponseEntity.ok(stores);
    }
}
