import 'package:bloc/bloc.dart';
import 'package:bytebank/models/transaction.dart';
import 'package:bytebank/pages/transaction/transaction_event.dart';
import 'package:bytebank/pages/transaction/transaction_state.dart';
import 'package:bytebank/services/sign_in_service.dart';
import 'package:bytebank/services/transaction_service.dart';

class TransactionBloc extends Bloc<TransactionEvent, TransactionState> {
  final SignInService _signInService;
  final TransactionService _transactionService;

  TransactionBloc(this._signInService, this._transactionService);

  @override
  TransactionState get initialState => InitiatedTransactionState();

  @override
  Stream<TransactionState> mapEventToState(TransactionEvent event) async* {
    if (event is StoreTransactionEvent) {
      final String token = await _signInService.signIn(
        event.email,
        event.password,
      );
      final Transaction transaction = Transaction(
        event.value,
        event.contact,
      );
      await _transactionService.create(transaction, token: token);
      yield StoredTransactionState();
    }
  }
}
