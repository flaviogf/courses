import 'package:equatable/equatable.dart';

abstract class ContactsEvent extends Equatable {}

class FindContactsEvent extends ContactsEvent {
  @override
  List<Object> get props => [];
}
