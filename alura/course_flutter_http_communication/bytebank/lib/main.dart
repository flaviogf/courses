import 'package:bytebank/pages/contact/contact_bloc.dart';
import 'package:bytebank/pages/contacts/contacts_bloc.dart';
import 'package:bytebank/pages/transactions/transactions_bloc.dart';
import 'package:bytebank/services/transaction_service.dart';
import 'package:flutter/material.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:sqflite/sqflite.dart' as sqflite;
import 'package:http/http.dart' as http;
import 'package:bytebank/data/repositories/contact_repository.dart';
import 'package:bytebank/data/database.dart';
import 'package:bytebank/pages/home/home_page.dart';

void main() async {
  runApp(ByteBankApp());

  final sqflite.Database database = await DatabaseFactory.create();

  kiwi.Container()
    ..registerInstance(database)
    ..registerInstance(http.Client())
    ..registerFactory((c) => ContactRepository(c.resolve()))
    ..registerFactory((c) => TransactionService(c.resolve()))
    ..registerFactory((c) => ContactBloc(c.resolve()))
    ..registerFactory((c) => ContactsBloc(c.resolve()))
    ..registerFactory((c) => TransactionsBloc(c.resolve()));
}

class ByteBankApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        primaryColor: Colors.green[900],
        accentColor: Colors.blueAccent[700],
        buttonTheme: ButtonThemeData(
          buttonColor: Colors.blueAccent[700],
          textTheme: ButtonTextTheme.primary,
        ),
      ),
      title: 'ByteBank',
      home: HomePage(),
    );
  }
}
