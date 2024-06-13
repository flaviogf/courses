import java.io.PrintStream;

public class DisplayBalanceOperation implements Operation {
    private final PrintStream printStream;

    public DisplayBalanceOperation(PrintStream printStream) {
        this.printStream = printStream;
    }

    @Override
    public void execute(Account account) {
        printStream.println("Balance: " + account.getBalance());
    }
}