import java.io.PrintStream;
import java.math.BigDecimal;
import java.util.Scanner;

public class WithdrawOperation implements Operation {
    private final Scanner scanner;
    private final PrintStream printStream;

    public WithdrawOperation(Scanner scanner, PrintStream printStream) {
        this.scanner = scanner;
        this.printStream = printStream;
    }

    @Override
    public void execute(Account account) {
        printStream.println("Enter amount to withdraw: ");
        account.withdraw(BigDecimal.valueOf(scanner.nextDouble()));
    }
}