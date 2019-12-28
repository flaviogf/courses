import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:youtubesearch/lib/http_video_repository.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/pages/search/search_bloc.dart';
import 'package:youtubesearch/pages/search/search_page.dart';

void main() async {
  kiwi.Container()
    ..registerFactory((_) {
      return http.Client();
    })
    ..registerFactory<VideoRepository, HttpVideoRepository>((it) {
      return HttpVideoRepository(
        it.resolve(),
      );
    })
    ..registerFactory((it) {
      return SearchBloc(
        it.resolve(),
      );
    });

  runApp(YoutubeSearchApp());
}

class YoutubeSearchApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        primaryColor: Colors.red[600],
        accentColor: Colors.redAccent[400],
      ),
      home: SearchPage(),
    );
  }
}
