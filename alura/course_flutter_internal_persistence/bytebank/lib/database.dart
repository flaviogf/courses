import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

Future<Database> getDatabase() async {
  return openDatabase(
    join(await getDatabasesPath(), 'bytebank.db'),
    onCreate: (database, version) {
      return database.execute(
        'CREATE TABLE contacts(id INTEGER PRIMARY KEY, name TEXT, account TEXT)',
      );
    },
    version: 1,
    onDowngrade: onDatabaseDowngradeDelete,
  );
}
