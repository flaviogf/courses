import 'package:bytebank/dao/contact_dao.dart';
import 'package:bytebank/models/contact.dart';
import 'package:flutter/material.dart';

class ContactForm extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return ContactFormState();
  }
}

class ContactFormState extends State<ContactForm> {
  final TextEditingController _nameTextEditingController =
      TextEditingController();
  final TextEditingController _accountTextEditingController =
      TextEditingController();
  final ContactDao _dao = ContactDao();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('New contact'),
      ),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Column(
          children: <Widget>[
            TextField(
              controller: _nameTextEditingController,
              decoration: InputDecoration(
                labelText: 'Name',
              ),
              style: TextStyle(
                fontSize: 24,
              ),
            ),
            Padding(
              padding: EdgeInsets.only(top: 8.0),
              child: TextField(
                controller: _accountTextEditingController,
                decoration: InputDecoration(
                  labelText: 'Account',
                ),
                style: TextStyle(
                  fontSize: 24,
                ),
                keyboardType: TextInputType.number,
              ),
            ),
            Row(
              children: <Widget>[
                Expanded(
                  flex: 1,
                  child: Padding(
                    padding: EdgeInsets.only(top: 16.0),
                    child: RaisedButton(
                      onPressed: () async {
                        final String name = _nameTextEditingController.text;
                        final String account =
                            _accountTextEditingController.text;
                        final Contact contact = Contact(name, account);
                        await _dao.insert(contact);
                        Navigator.of(context).pop();
                      },
                      child: Text('Confirm'),
                    ),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
