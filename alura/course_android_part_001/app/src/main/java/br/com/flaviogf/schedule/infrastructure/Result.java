package br.com.flaviogf.schedule.infrastructure;

public class Result<T> {
    private final T value;
    private final Boolean isSuccess;
    private final String message;

    private Result(T value, boolean isSuccess, String message) {
        this.value = value;
        this.isSuccess = isSuccess;
        this.message = message;
    }

    public T getValue() {
        return value;
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
        return new Result<>(null, true, "");
    }

    public static <T> Result<T> ok(T value) {
        return new Result<>(value, true, "");
    }

    public static <T> Result<T> fail(String message) {
        return new Result<>(null, false, message);
    }
}
