import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart' as sqflite;

class DatabaseFactory {
  static Future<sqflite.Database> create() async {
    return sqflite.openDatabase(
      join(await sqflite.getDatabasesPath(), 'bytebank.db'),
      onCreate: (database, version) {
        return database.execute(
          'CREATE TABLE contacts (id INTEGER PRIMARY KEY, name TEXT, account TEXT)',
        );
      },
      version: 1,
      onDowngrade: sqflite.onDatabaseDowngradeDelete,
    );
  }
}
