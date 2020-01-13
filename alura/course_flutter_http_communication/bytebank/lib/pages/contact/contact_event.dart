import 'package:equatable/equatable.dart';

abstract class ContactEvent extends Equatable {}

class StoreContactEvent extends ContactEvent {
  final String name;
  final String account;

  StoreContactEvent(this.name, this.account);

  @override
  List<Object> get props => [name, account];
}
