import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

Future<Database> getDatabase() async {
  final String path = join(await getDatabasesPath(), 'bytebank.db');

  return openDatabase(
    path,
    onCreate: (database, version) {
      database.execute('CREATE TABLE contacts(id INTEGER PRIMARY KEY, name TEXT, account TEXT)');
    },
    onDowngrade: onDatabaseDowngradeDelete,
    version: 1,
  );
}
