import java.io.PrintStream;
import java.util.Map;
import java.util.Scanner;

public class Atm {
    private final Scanner scanner;
    private final PrintStream printStream;
    private final Map<Integer, Operation> operations;

    public Atm(Scanner scanner, PrintStream printStream, Map<Integer, Operation> operations) {
        this.scanner = scanner;
        this.printStream = printStream;
        this.operations = operations;
    }

    public void run(Account account) {
        printStream.println("**********");
        printStream.println("Customer Initial Data");
        printStream.println("Name: " + account.getCustomer());
        printStream.println("Type: " + account.getType());
        printStream.println("Balance: " + account.getBalance());

        while (true) {
            printStream.println();
            printStream.println("Operations");
            printStream.println("1 - Display Balance");
            printStream.println("2 - Deposit");
            printStream.println("3 - Withdraw");
            printStream.println("4 - Exit");
            printStream.println();

            printStream.println("Enter your choice: ");

            int choice = scanner.nextInt();
            if (choice == 4) break;

            operations.get(choice).execute(account);
        }
    }
}