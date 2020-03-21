package br.com.flaviogf.example3;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class ProductTest {

    @Test
    public void getNameShouldReturnTheNameOfProduct() {
        Product product = new Product("PS3", 1500);
        assertEquals("PS3", product.getName());
    }

    @Test
    public void getPriceShouldReturnThePriceOfProduct() {
        Product product = new Product("PS3", 150000);
        assertEquals(150000, product.getPrice());
    }
}
