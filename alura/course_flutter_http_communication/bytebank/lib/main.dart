import 'package:bytebank/data/repositories/transaction_repository.dart';
import 'package:flutter/material.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:sqflite/sqflite.dart' as sqflite;
import 'package:bytebank/pages/home/home_page.dart';
import 'package:bytebank/data/database.dart';

void main() async {
  runApp(ByteBankApp());

  final sqflite.Database database = await DatabaseFactory.create();

  kiwi.Container()
    ..registerInstance(database)
    ..registerFactory((c) => TransactionRepository(c.resolve()));
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
