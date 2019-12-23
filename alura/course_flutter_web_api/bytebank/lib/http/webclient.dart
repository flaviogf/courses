import 'dart:convert';

import 'package:bytebank/models/contact.dart';
import 'package:bytebank/models/transaction.dart';
import 'package:http/http.dart';
import 'package:http_interceptor/http_client_with_interceptor.dart';
import 'package:http_interceptor/http_interceptor.dart';

class LoggingInterceptor implements InterceptorContract {
  @override
  Future<RequestData> interceptRequest({RequestData data}) async {
    print('Request');
    print('url: ${data.requestUrl}');
    print('headers: ${data.headers}');
    print('body: ${data.body}');
    return data;
  }

  @override
  Future<ResponseData> interceptResponse({ResponseData data}) async {
    print('Response');
    print('statusCode: ${data.statusCode}');
    print('headers: ${data.headers}');
    print('body: ${data.body}');
    return data;
  }
}

final Client client = HttpClientWithInterceptor.build(
  interceptors: [LoggingInterceptor()],
);

const String url = 'http://2ef4cdcd.ngrok.io/transaction';

Future<List<Transaction>> findAll() async {
  final Response response = await client.get(url).timeout(Duration(seconds: 5));

  final List<dynamic> json = jsonDecode(response.body);

  final List<Transaction> transactions = json.map(
    (it) {
      final Contact contact = Contact(
        it['contact']['name'],
        it['contact']['account'],
      );

      final Transaction transaction = Transaction(
        it['id'],
        it['value'],
        contact,
        it['date'],
      );

      return transaction;
    },
  ).toList();

  return transactions;
}

Future<Transaction> insert(Transaction transaction) async {
  final String json = jsonEncode(
    {
      'value': transaction.value,
      'contactName': transaction.contact.name,
      'contactAccount': transaction.contact.account,
      'date': transaction.date,
    },
  );

  final Response response = await client.post(
    url,
    headers: {'Content-Type': 'application/json'},
    body: json,
  );

  final Map<String, dynamic> body = jsonDecode(response.body);

  final Contact contact = Contact(
    body['contact']['name'],
    body['contact']['account'],
  );

  return Transaction(
    body['id'],
    body['value'],
    contact,
    body['date'],
  );
}
