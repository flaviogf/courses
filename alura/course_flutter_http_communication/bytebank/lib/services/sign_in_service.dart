import 'dart:convert';

import 'package:http/http.dart';

class SignInService {
  final Client _client;

  SignInService(this._client);

  Future<String> signIn(String email, String password) async {
    final Map<String, dynamic> values = Map();

    values['email'] = email;
    values['password'] = password;

    final String json = jsonEncode(values);

    final Response response = await _client.post(
      'http://a7d868ac.ngrok.io/api/signin',
      headers: {'Content-Type': 'application/json'},
      body: json,
    );

    final String token = response.body;

    return token;
  }
}
