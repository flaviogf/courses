import 'package:bytebank/pages/transaction/transaction_page.dart';
import 'package:flutter/material.dart';

class TransactionsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Transactions'),
      ),
      body: ListView(
        children: <Widget>[
          Card(
            child: ListTile(
              leading: Icon(
                Icons.monetization_on,
                color: Theme.of(context).primaryColor,
              ),
              title: Text('\$ 1000.00'),
              subtitle: Text('000-0'),
            ),
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (_) => TransactionPage(),
            ),
          );
        },
        child: Icon(Icons.add),
      ),
    );
  }
}
