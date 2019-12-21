class Transfer {
  final String accountNumber;
  final int value;

  Transfer(
    this.accountNumber,
    this.value,
  );

  @override
  String toString() {
    return 'Transfer{accountNumber:$accountNumber}, value:$value}';
  }
}
