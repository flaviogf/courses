import java.math.BigDecimal;

public interface Account {
    String getCustomer();

    BigDecimal getBalance();

    String getType();

    void deposit(BigDecimal bigDecimal);

    void withdraw(BigDecimal bigDecimal);
}