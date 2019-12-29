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
  Future<List<Video>> find(String name, {String page = ''}) async {
    final String url = getSearchUrl(name, page);

    final http.Response response = await _client.get(url);

    final String json = response.body;

    final Map<String, dynamic> content = jsonDecode(json);

    final List<dynamic> items = content['items'];

    List<Video> videos = items
        .map(
          (it) => Video(
            it['id']['videoId'],
            it['snippet']['title'],
            it['snippet']['thumbnails']['high']['url'],
          ),
        )
        .toList();

    _next = content['nextPageToken'];
    _previous = content['prevPageToken'];

    return videos;
  }

  @override
  Future<Video> findOne(String id) async {
    final String url = getVideoUrl(id);

    final http.Response response = await _client.get(url);

    final String json = response.body;

    final Map<String, dynamic> content = jsonDecode(json);

    final List<dynamic> items = content['items'];

    final Video video = Video(
      items[0]['id'],
      items[0]['snippet']['title'],
      items[0]['snippet']['thumbnails']['high']['url'],
    );

    return video;
  }

  @override
  Future<String> next() async {
    return _next;
  }

  @override
  Future<String> previous() async {
    return _previous;
  }

  String getSearchUrl(String name, String page) {
    if (page.isEmpty) {
      return 'https://www.googleapis.com/youtube/v3/search?part=snippet&q=$name&type=video&key=$API_TOKEN';
    }

    return 'https://www.googleapis.com/youtube/v3/search?part=snippet&q=$name&type=video&pageToken=$page&key=$API_TOKEN';
  }

  String getVideoUrl(String id) {
    return 'https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&id=$id&maxResults=1&key=$API_TOKEN';
  }
}
