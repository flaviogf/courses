import 'package:bytebank/models/contact.dart';
import 'package:bytebank/screens/contact_form.dart';
import 'package:flutter/material.dart';

class ContactList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Contacts'),
      ),
      body: ListView(
        children: <Widget>[
          Card(
            child: ListTile(
              title: Text('Flavio'),
              subtitle: Text('0000-0'),
            ),
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          final Contact contact = await Navigator.push(
            context,
            MaterialPageRoute(builder: (context) {
              return ContactForm();
            }),
          );

          if (contact == null) {
            return;
          }

          debugPrint(contact.toString());
        },
        child: Icon(Icons.add),
      ),
    );
  }
}
