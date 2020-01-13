import 'package:equatable/equatable.dart';

abstract class ContactState extends Equatable {}

class InitiatedContactState extends ContactState {
  @override
  List<Object> get props => [];
}

class StoredContactState extends ContactState {
  @override
  List<Object> get props => [];
}
