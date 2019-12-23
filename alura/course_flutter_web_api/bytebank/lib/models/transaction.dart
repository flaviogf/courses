import 'package:bytebank/models/contact.dart';

class Transaction {
  final String id;
  final int value;
  final Contact contact;
  final String date;

  Transaction(this.id, this.value, this.contact, this.date);

  @override
  String toString() {
    return 'Transaction{id:$id, value:$value, contact:$contact, date:$date}';
  }
}
