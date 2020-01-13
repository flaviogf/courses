import 'package:bytebank/models/contact.dart';
import 'package:equatable/equatable.dart';

abstract class ContactsState extends Equatable {}

class InitiatedContactsState extends ContactsState {
  final List<Contact> contacts = List();

  @override
  List<Object> get props => [];
}

class FindedContactsState extends ContactsState {
  final List<Contact> contacts;

  FindedContactsState(this.contacts);

  @override
  List<Object> get props => [contacts];
}
