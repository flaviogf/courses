import 'package:equatable/equatable.dart';

abstract class TransactionsEvent extends Equatable {}

class FindTransactionsEvent extends TransactionsEvent {
  @override
  List<Object> get props => [];
}
