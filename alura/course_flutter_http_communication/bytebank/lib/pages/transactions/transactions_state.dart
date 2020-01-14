import 'package:bytebank/models/transaction.dart';
import 'package:equatable/equatable.dart';

abstract class TransactionsState extends Equatable {}

class InitiatedTransationsState extends TransactionsState {
  final List<Transaction> transactions = List();

  @override
  List<Object> get props => [transactions];
}

class FindedTransactionsState extends TransactionsState {
  final List<Transaction> transactions;

  FindedTransactionsState(this.transactions);

  @override
  List<Object> get props => [transactions];
}
