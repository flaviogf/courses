import 'package:bytebank/models/transaction.dart';
import 'package:sqflite/sqflite.dart' as sqflite;

class TransactionRepository {
  final sqflite.Database _database;

  TransactionRepository(this._database);

  Future<Transaction> insert(Transaction transaction) async {
    final String sql =
        'INSERT INTO transactions (account, value) VALUES (?, ?)';

    await this._database.execute(sql, [transaction.account, transaction.value]);

    return transaction;
  }
}
