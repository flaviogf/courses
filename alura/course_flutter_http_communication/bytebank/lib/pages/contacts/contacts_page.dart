import 'package:bytebank/pages/transaction/transaction_page.dart';
import 'package:flutter/material.dart';
import 'package:bytebank/pages/contact/contact_page.dart';

class ContactsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Transfers'),
      ),
      body: ListView(
        children: <Widget>[
          GestureDetector(
            onTap: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (_) => TransactionPage(),
                ),
              );
            },
            child: Card(
              child: ListTile(
                leading: Icon(
                  Icons.person,
                  color: Theme.of(context).primaryColor,
                ),
                title: Text(
                  'Flavio',
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
                subtitle: Text('000-0'),
              ),
            ),
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (_) => ContactPage(),
            ),
          );
        },
        child: Icon(Icons.add),
      ),
    );
  }
}
