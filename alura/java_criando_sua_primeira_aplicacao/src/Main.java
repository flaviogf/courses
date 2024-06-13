import java.io.PrintStream;
import java.math.BigDecimal;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        PrintStream printStream = System.out;
        Map<Integer, Operation> operations = Map.of(1, new DisplayBalanceOperation(printStream), 2, new DepositOperation(scanner, printStream), 3, new WithdrawOperation(scanner, printStream));

        Atm atm = new Atm(scanner, printStream, operations);

        Account account = new CheckingAccount("Flávio", new BigDecimal("1000.00"));

        atm.run(account);
    }
}