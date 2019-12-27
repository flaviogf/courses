import 'package:youtubesearch/models/video.dart';

abstract class VideoRepository {
  Future<List<Video>> find(String name, {String page});

  Future<String> next();

  Future<String> previous();
}
