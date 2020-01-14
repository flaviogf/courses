import 'package:bytebank/models/transaction.dart';
import 'package:bytebank/pages/transactions/transactions_event.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:bytebank/pages/transactions/transactions_bloc.dart';
import 'package:bytebank/pages/transactions/transactions_state.dart';

class TransactionsPage extends StatelessWidget {
  Widget build(BuildContext context) {
    return BlocProvider<TransactionsBloc>(
      create: (_) => kiwi.Container().resolve<TransactionsBloc>()
        ..add(FindTransactionsEvent()),
      child: BlocBuilder<TransactionsBloc, TransactionsState>(
        builder: (context, state) {
          if (state is FindedTransactionsState) {
            return Scaffold(
              appBar: AppBar(
                title: Text('New transaction'),
              ),
              body: ListView.builder(
                itemCount: state.transactions.length,
                itemBuilder: (context, index) {
                  final Transaction transaction = state.transactions[index];

                  return Card(
                    child: ListTile(
                      leading: Icon(
                        Icons.monetization_on,
                        color: Theme.of(context).primaryColor,
                      ),
                      title: Text(
                        transaction.value.toString(),
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      subtitle: Text(transaction.contact.account),
                    ),
                  );
                },
              ),
            );
          }

          return Scaffold(
            appBar: AppBar(
              title: Text('New transaction'),
            ),
            body: Container(
              child: Center(
                child: CircularProgressIndicator(),
              ),
            ),
          );
        },
      ),
    );
  }
}
