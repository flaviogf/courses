import 'package:sqflite/sqflite.dart' as sqflite;
import 'package:path/path.dart';

class DatabaseFactory {
  static Future<sqflite.Database> create() async {
    return sqflite.openDatabase(
      join(await sqflite.getDatabasesPath(), 'bytebank.db'),
      onCreate: (database, version) {
        return database.execute(
          'CREATE TABLE transactions (id INTEGER PRIMARY KEY, account TEXT, value INTEGER)',
        );
      },
      version: 3,
      onDowngrade: sqflite.onDatabaseDowngradeDelete,
    );
  }
}
