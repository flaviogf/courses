import 'package:bytebank/models/contact.dart';
import 'package:equatable/equatable.dart';

abstract class TransactionEvent extends Equatable {}

class StoreTransactionEvent extends TransactionEvent {
  final String email;
  final String password;
  final Contact contact;
  final int value;

  StoreTransactionEvent(this.email, this.password, this.contact, this.value);

  @override
  List<Object> get props => [contact, value];
}
