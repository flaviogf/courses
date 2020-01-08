import 'package:flutter/material.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:bytebank/data/repositories/contact_repository.dart';
import 'package:bytebank/models/contact.dart';

class ContactPage extends StatefulWidget {
  final ContactRepository repository =
      kiwi.Container().resolve<ContactRepository>();

  @override
  State<StatefulWidget> createState() => ContactPageState();
}

class ContactPageState extends State<ContactPage> {
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _accountController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('New contact'),
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
                    labelText: 'Name',
                    hintText: 'João',
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
                  controller: _nameController,
                  decoration: InputDecoration(
                    labelText: 'Account',
                    hintText: '000-0',
                    icon: Icon(Icons.monetization_on),
                  ),
                  keyboardType: TextInputType.number,
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
                    final String name = _nameController.text;

                    final String account = _accountController.text;

                    final Contact contact = Contact(name, account);

                    await widget.repository.insert(contact);

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
