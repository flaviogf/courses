import 'package:bytebank/models/contact.dart';
import 'package:equatable/equatable.dart';

abstract class TransactionEvent extends Equatable {}

class StoreTransactionEvent extends TransactionEvent {
  final Contact contact;
  final int value;

  StoreTransactionEvent(this.contact, this.value);

  @override
  List<Object> get props => [contact, value];
}
