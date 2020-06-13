package br.com.flaviogf.schedule.infrastructure;

public class Result<T> {
    private final Boolean isSuccess;
    private final String message;

    private Result(boolean isSuccess, String message) {
        this.isSuccess = isSuccess;
        this.message = message;
    }

    public boolean isSuccess() {
        return isSuccess;
    }

    public boolean isFailure() {
        return !isSuccess;
    }

    public String getMessage() {
        return message;
    }

    public static <T> Result<T> ok() {
        return new Result<>(true, "");
    }

    public static <T> Result<T> fail(String message) {
        return new Result<>(false, message);
    }
}
