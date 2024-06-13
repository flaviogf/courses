import java.io.PrintStream;
import java.math.BigDecimal;
import java.util.Scanner;

public class DepositOperation implements Operation {
    private final Scanner scanner;
    private final PrintStream printStream;

    public DepositOperation(Scanner scanner, PrintStream printStream) {
        this.scanner = scanner;
        this.printStream = printStream;
    }

    @Override
    public void execute(Account account) {
        printStream.println("Enter deposit amount:");
        account.deposit(BigDecimal.valueOf(scanner.nextDouble()));
    }
}