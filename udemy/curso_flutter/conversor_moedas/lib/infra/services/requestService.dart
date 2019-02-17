import 'package:http/http.dart' as http;
import 'dart:convert';

class RequestService {
  Future<dynamic> get(String url) async {
    var response = await http.get(url);
    return jsonDecode(response.body);
  }
}
