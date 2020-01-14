import 'dart:convert';

import 'package:bytebank/models/contact.dart';
import 'package:bytebank/models/transaction.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class TransactionService {
  final Client _client;

  TransactionService(this._client);

  Future<List<Transaction>> findAll() async {
    final Response response = await _client.get(
      'http://580a498e.ngrok.io/api/transaction',
    );

    debugPrint(response.toString());

    List<Map<String, dynamic>> transactions = jsonDecode(response.body);

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
