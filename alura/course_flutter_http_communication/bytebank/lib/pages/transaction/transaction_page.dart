import 'package:flutter/material.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:bytebank/data/repositories/transaction_repository.dart';
import 'package:bytebank/models/transaction.dart';

class TransactionPage extends StatefulWidget {
  final TransactionRepository repository =
      kiwi.Container().resolve<TransactionRepository>();

  @override
  State<StatefulWidget> createState() => TransactionPageState();
}

class TransactionPageState extends State<TransactionPage> {
  final TextEditingController _accountController = TextEditingController();
  final TextEditingController _valueController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('New transaction'),
      ),
      body: SingleChildScrollView(
        child: SafeArea(
          child: Column(
            children: <Widget>[
              Padding(
                padding: EdgeInsets.only(
                  top: 8.0,
                  right: 16.0,
                  bottom: 8.0,
                  left: 16.0,
                ),
                child: TextField(
                  controller: _accountController,
                  decoration: InputDecoration(
                    labelText: 'Account',
                    hintText: '000-0',
                  ),
                  style: TextStyle(
                    fontSize: 32,
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.only(
                  top: 8.0,
                  right: 16.0,
                  bottom: 8.0,
                  left: 16.0,
                ),
                child: TextField(
                  controller: _valueController,
                  decoration: InputDecoration(
                    labelText: 'Value',
                    hintText: '1000.00',
                    icon: Icon(Icons.monetization_on),
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
                  onPressed: () async {
                    final String account = _accountController.text;

                    final int value = int.parse(_valueController.text);

                    final Transaction transaction = Transaction(account, value);

                    await widget.repository.insert(transaction);

                    Navigator.of(context).pop();
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
