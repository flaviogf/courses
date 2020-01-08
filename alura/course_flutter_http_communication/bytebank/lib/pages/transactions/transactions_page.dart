import 'package:flutter/material.dart';

class TransactionsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('New transaction'),
      ),
      body: ListView(
        children: <Widget>[
          Card(
            child: ListTile(
              leading: Icon(
                Icons.monetization_on,
                color: Theme.of(context).primaryColor,
              ),
              title: Text(
                '1000.0',
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
              subtitle: Text('000-0'),
            ),
          )
        ],
      ),
    );
  }
}
