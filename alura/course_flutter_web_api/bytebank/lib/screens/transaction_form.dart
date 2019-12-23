import 'package:bytebank/http/webclient.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/models/transaction.dart';
import 'package:flutter/material.dart';

class TransactionForm extends StatefulWidget {
  final Contact contact;

  TransactionForm({Key key, this.contact}) : super(key: key);

  @override
  State<StatefulWidget> createState() => TransactionFormState();
}

class TransactionFormState extends State<TransactionForm> {
  final TextEditingController _valueController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('New transaction'),
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            Padding(
              padding: EdgeInsets.only(left: 16.0, right: 16.0, top: 16.0),
              child: Text(
                widget.contact.name,
                style: TextStyle(
                  fontSize: 36.0,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Padding(
              padding: EdgeInsets.only(top: 8.0, left: 16.0, right: 16.0),
              child: Text(
                widget.contact.account,
                style: TextStyle(
                  fontSize: 24.0,
                ),
              ),
            ),
            Padding(
              padding: EdgeInsets.only(top: 8.0, left: 16.0, right: 16.0),
              child: TextField(
                controller: _valueController,
                decoration: InputDecoration(
                  labelText: 'Value',
                ),
                style: TextStyle(
                  fontSize: 24.0,
                ),
                keyboardType: TextInputType.number,
              ),
            ),
            Padding(
              padding: EdgeInsets.all(16.0),
              child: SizedBox(
                width: double.maxFinite,
                child: RaisedButton(
                  onPressed: () async {
                    final int value = int.tryParse(_valueController.text) ?? 0;

                    final Transaction transaction = Transaction(
                      null,
                      value,
                      widget.contact,
                      DateTime.now().toIso8601String(),
                    );

                    await insert(transaction);

                    Navigator.of(context).pop();
                  },
                  child: Text('Confirm'),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
