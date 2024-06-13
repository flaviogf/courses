import java.math.BigDecimal;

public class CheckingAccount implements Account {
    private final String customer;
    private BigDecimal balance;

    public CheckingAccount(String customer, BigDecimal balance) {
        this.customer = customer;
        this.balance = balance;
    }

    @Override
    public String getCustomer() {
        return customer;
    }

    @Override
    public BigDecimal getBalance() {
        return balance;
    }

    @Override
    public String getType() {
        return "Checking Account";
    }

    @Override
    public void deposit(BigDecimal value) {
        balance = balance.add(value);
    }

    @Override
    public void withdraw(BigDecimal bigDecimal) {
        balance = balance.subtract(bigDecimal);
    }
}