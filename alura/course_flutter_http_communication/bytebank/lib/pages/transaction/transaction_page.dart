import 'package:bytebank/models/contact.dart';
import 'package:flutter/material.dart';

class TransactionPage extends StatefulWidget {
  final Contact contact;

  const TransactionPage({Key key, this.contact}) : super(key: key);

  @override
  State<StatefulWidget> createState() => TransactionPageState();
}

class TransactionPageState extends State<TransactionPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('New transaction'),
      ),
      body: SingleChildScrollView(
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
              )
            ],
          ),
        ),
      ),
    );
  }
}
