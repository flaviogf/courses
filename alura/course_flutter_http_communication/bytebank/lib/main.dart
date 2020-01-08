import 'package:bytebank/pages/contact/store_contact_bloc.dart';
import 'package:flutter/material.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:sqflite/sqflite.dart' as sqflite;
import 'package:bytebank/data/repositories/contact_repository.dart';
import 'package:bytebank/data/database.dart';
import 'package:bytebank/pages/home/home_page.dart';

void main() async {
  runApp(ByteBankApp());

  final sqflite.Database database = await DatabaseFactory.create();

  kiwi.Container()
    ..registerInstance(database)
    ..registerFactory((c) => ContactRepository(c.resolve()))
    ..registerFactory((c) => StoreContactBloc(c.resolve()));
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
