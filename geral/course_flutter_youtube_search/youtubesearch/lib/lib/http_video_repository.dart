import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';

const String API_TOKEN = '';

class HttpVideoRepository implements VideoRepository {
  final http.Client _client;
  String _next;
  String _previous;

  HttpVideoRepository(this._client);

  @override
  Future<List<Video>> find(String name, {String page}) async {
    final String url =
        'https://www.googleapis.com/youtube/v3/search?part=id,snippet&q=$name&type=video&key=$API_TOKEN${page != null ? '&pageToken=$page' : ''}';

    final http.Response response = await _client.get(url);

    final String json = response.body;

    final Map<String, dynamic> content = jsonDecode(json);

    final List<dynamic> items = content['items'];

    List<Video> videos = items
        .map(
          (it) => Video(it['id']['videoId'], it['snippet']['title']),
        )
        .toList();

    _next = content['nextPageToken'];
    _previous = content['prevPageToken'];

    return videos;
  }

  @override
  Future<String> next() async {
    return _next;
  }

  @override
  Future<String> previous() async {
    return _previous;
  }
}
