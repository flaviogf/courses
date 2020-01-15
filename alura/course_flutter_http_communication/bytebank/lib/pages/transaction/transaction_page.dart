import 'package:bytebank/components/authenticate_dialog.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/pages/transaction/transaction_event.dart';
import 'package:bytebank/pages/transaction/transaction_state.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:bytebank/pages/transaction/transaction_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class TransactionPage extends StatelessWidget {
  final Contact contact;

  const TransactionPage({Key key, this.contact}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BlocProvider<TransactionBloc>(
      create: (_) => kiwi.Container().resolve<TransactionBloc>(),
      child: Scaffold(
        appBar: AppBar(
          title: Text('New transaction'),
        ),
        body: TransactionForm(
          contact: contact,
        ),
      ),
    );
  }
}

class TransactionForm extends StatefulWidget {
  final Contact contact;

  const TransactionForm({Key key, this.contact}) : super(key: key);

  @override
  State<StatefulWidget> createState() => TransactionFormState();
}

class TransactionFormState extends State<TransactionForm> {
  final TextEditingController _valueController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return BlocListener<TransactionBloc, TransactionState>(
      listener: (context, state) {
        if (state is StoredTransactionState) {
          Navigator.of(context).pop();
        }
      },
      child: SingleChildScrollView(
        child: SafeArea(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Padding(
                padding: EdgeInsets.only(
                  top: 16.0,
                  left: 16.0,
                  right: 16.0,
                ),
                child: Text(
                  widget.contact.name,
                  style: TextStyle(
                    fontSize: 24,
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.only(
                  top: 16.0,
                  left: 16.0,
                  right: 16.0,
                ),
                child: Text(
                  widget.contact.account,
                  style: TextStyle(
                    fontSize: 42,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.all(16.0),
                child: TextField(
                  keyboardType: TextInputType.number,
                  controller: _valueController,
                  decoration: InputDecoration(
                    labelText: 'Valor',
                    hintText: '0000',
                    icon: Icon(
                      Icons.monetization_on,
                    ),
                  ),
                  style: TextStyle(
                    fontSize: 32,
                  ),
                ),
              ),
              Container(
                width: MediaQuery.of(context).size.width,
                padding: EdgeInsets.all(16.0),
                child: RaisedButton(
                  onPressed: () {
                    final AuthenticateDialog dialog = AuthenticateDialog(
                      confirm: (email, password) {
                        final int value =
                            int.tryParse(_valueController.text) ?? 0;

                        BlocProvider.of<TransactionBloc>(context).add(
                          StoreTransactionEvent(
                            email,
                            password,
                            widget.contact,
                            value,
                          ),
                        );
                      },
                    );

                    showDialog(context: context, builder: (_) => dialog);
                  },
                  child: Text('Confirm'),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
