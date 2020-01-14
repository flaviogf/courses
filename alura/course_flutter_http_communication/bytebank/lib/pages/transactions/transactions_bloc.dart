import 'package:bloc/bloc.dart';
import 'package:bytebank/models/transaction.dart';
import 'package:bytebank/pages/transactions/transactions_event.dart';
import 'package:bytebank/pages/transactions/transactions_state.dart';
import 'package:bytebank/services/transaction_service.dart';

class TransactionsBloc extends Bloc<TransactionsEvent, TransactionsState> {
  final TransactionService _transactionService;

  TransactionsBloc(this._transactionService);

  @override
  TransactionsState get initialState => InitiatedTransationsState();

  @override
  Stream<TransactionsState> mapEventToState(TransactionsEvent event) async* {
    if (event is FindTransactionsEvent) {
      final List<Transaction> transactions =
          await _transactionService.findAll();

      yield FindedTransactionsState(transactions);
    }
  }
}
