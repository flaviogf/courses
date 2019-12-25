import 'package:youtubesearch/models/video.dart';

abstract class VideoRepository {
  Future<List<Video>> find(String name);
}
