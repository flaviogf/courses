import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:youtubesearch/lib/http_video_repository.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';

void main() async {
  runApp(YoutubeSearchApp());

  final VideoRepository repository = HttpVideoRepository(http.Client());

  final List<Video> videos = await repository.find('jovem nerd');

  debugPrint(videos.toString());
}

class YoutubeSearchApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('Youtube search'),
        ),
        body: Center(
          child: Text("It's running."),
        ),
      ),
    );
  }
}
