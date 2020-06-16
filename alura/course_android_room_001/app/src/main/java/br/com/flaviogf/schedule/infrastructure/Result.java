package br.com.flaviogf.schedule.infrastructure;

public class Result<T> {
    private final T value;
    private final Boolean isSuccess;
    private final String message;

    private Result(T value, Boolean isSuccess, String message) {
        this.value = value;
        this.isSuccess = isSuccess;
        this.message = message;
    }

    public T getValue() {
        return value;
    }

    public Boolean isSuccess() {
        return isSuccess;
    }

    public Boolean isFailure() {
        return !isSuccess;
    }

    public String getMessage() {
        return message;
    }

    public static <T> Result<T> ok(T value) {
        return new Result<>(value, true, null);
    }

    public static <T> Result<T> fail(String message) {
        return new Result<>(null, false, message);
    }
}
