import 'package:flutter/material.dart';

class TransactionPage extends StatelessWidget {
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
                  onPressed: () {},
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
