import 'package:bytebank/models/contact.dart';
import 'package:bytebank/pages/contacts/contacts_event.dart';
import 'package:flutter/material.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:bytebank/pages/contacts/contacts_bloc.dart';
import 'package:bytebank/pages/contacts/contacts_state.dart';
import 'package:bytebank/pages/transaction/transaction_page.dart';
import 'package:bytebank/pages/contact/contact_page.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ContactsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return BlocProvider<ContactsBloc>(
      create: (_) =>
          kiwi.Container().resolve<ContactsBloc>()..add(FindContactsEvent()),
      child: BlocBuilder<ContactsBloc, ContactsState>(
        builder: (context, state) {
          if (state is FindedContactsState) {
            return Scaffold(
              appBar: AppBar(
                title: Text('Transfers'),
              ),
              body: ListView.builder(
                itemCount: state.contacts.length,
                itemBuilder: (context, index) {
                  final Contact contact = state.contacts[index];
                  return GestureDetector(
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
                          contact.name,
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        subtitle: Text(
                          contact.account,
                        ),
                      ),
                    ),
                  );
                },
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

          return Scaffold(
            appBar: AppBar(
              title: Text('Transfers'),
            ),
            body: Container(
              child: Center(
                child: CircularProgressIndicator(),
              ),
            ),
          );
        },
      ),
    );
  }
}
