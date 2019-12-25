import 'dart:convert';
import 'dart:io';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';

class FileVideoRepository implements VideoRepository {
  final File file;

  FileVideoRepository(this.file);

  @override
  Future<List<Video>> find(String name) async {
    final String json = file.readAsStringSync();

    final Map<String, dynamic> content = jsonDecode(json);

    final List<dynamic> items = content['items'];

    List<Video> videos = items
        .map(
          (it) => Video(it['id']['videoId'], it['snippet']['title']),
        )
        .toList();

    return videos;
  }
}
