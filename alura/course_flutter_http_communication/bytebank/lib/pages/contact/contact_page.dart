import 'package:bytebank/pages/contact/store_contact_event.dart';
import 'package:bytebank/pages/contact/store_contact_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:bytebank/pages/contact/store_contact_bloc.dart';

class ContactPage extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => ContactPageState();
}

class ContactPageState extends State<ContactPage> {
  final StoreContactBloc _contactBloc =
      kiwi.Container().resolve<StoreContactBloc>();

  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _accountController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return BlocProvider<StoreContactBloc>(
      create: (_) => _contactBloc,
      child: BlocListener<StoreContactBloc, StoreContactState>(
        listener: (context, state) {
          if (state is StoreContactStateStored) {
            Navigator.of(context).pop();
          }
        },
        child: BlocBuilder<StoreContactBloc, StoreContactState>(
          builder: (context, state) {
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

                            final StoreContactEvent contact = StoreContactEvent(
                              name,
                              account,
                            );

                            _contactBloc.add(contact);
                          },
                          child: Text('Confirm'),
                        ),
                      )
                    ],
                  ),
                ),
              ),
            );
          },
        ),
      ),
    );
  }

  @override
  void dispose() {
    super.dispose();
    _contactBloc.close();
  }
}
