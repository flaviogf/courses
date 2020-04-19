package br.com.flaviogf.casadocodigo.models;

public class BasketItem {
    private Product product;
    private EPriceType priceType;

    @Deprecated
    public BasketItem() {
    }

    public BasketItem(Product product, EPriceType priceType) {
        this.product = product;
        this.priceType = priceType;
    }

    public Product getProduct() {
        return product;
    }

    public void setProduct(Product product) {
        this.product = product;
    }

    public EPriceType getPrice() {
        return priceType;
    }

    public void setPrice(EPriceType priceType) {
        this.priceType = priceType;
    }

    @Override
    public boolean equals(Object obj) {
        BasketItem basketItem = (BasketItem) obj;
        return basketItem.product.equals(product) && basketItem.priceType.equals(priceType);
    }

    @Override
    public int hashCode() {
        return product.hashCode() + priceType.hashCode();
    }
}
