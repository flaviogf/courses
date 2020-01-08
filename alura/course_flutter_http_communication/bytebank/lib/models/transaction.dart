import 'package:bytebank/models/contact.dart';

class Transaction {
  final int id;
  final int value;
  final Contact contact;

  Transaction(this.value, this.contact, {this.id});
}
