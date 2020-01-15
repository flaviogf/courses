import 'package:equatable/equatable.dart';

abstract class TransactionState extends Equatable {}

class InitiatedTransactionState extends TransactionState {
  @override
  List<Object> get props => [];
}

class StoredTransactionState extends TransactionState {
  @override
  List<Object> get props => [];
}
