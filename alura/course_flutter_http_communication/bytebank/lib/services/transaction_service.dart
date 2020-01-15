import 'dart:convert';
import 'package:http/http.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/models/transaction.dart';

class TransactionService {
  final Client _client;

  TransactionService(this._client);

  Future<Transaction> create(Transaction transaction) async {
    Map<String, dynamic> values = Map();

    values['value'] = transaction.value;
    values['contactName'] = transaction.contact.name;
    values['contactAccount'] = transaction.contact.account;

    final String json = jsonEncode(values);

    final Response response = await _client.post(
      'http://a7d868ac.ngrok.io/api/transaction',
      headers: {'Content-Type': 'application/json'},
      body: json,
    );

    return transaction;
  }

  Future<List<Transaction>> findAll() async {
    final Response response = await _client.get(
      'http://a7d868ac.ngrok.io/api/transaction',
    );

    List<dynamic> transactions = jsonDecode(response.body);

    return transactions.map((it) {
      final Contact contact = Contact(
        it['contact']['name'],
        it['contact']['account'],
      );

      final Transaction transaction = Transaction(
        it['value'],
        contact,
        id: it['id'],
      );

      return transaction;
    }).toList();
  }
}
