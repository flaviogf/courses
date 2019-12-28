import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:http_interceptor/http_interceptor.dart';
import 'package:youtubesearch/lib/http_video_repository.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/pages/search/search_bloc.dart';
import 'package:youtubesearch/pages/search/search_page.dart';

void main() async {
  kiwi.Container()
    ..registerFactory<http.Client, HttpClientWithInterceptor>((_) {
      return HttpClientWithInterceptor.build(
        interceptors: [LoggingInterceptor()],
      );
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

class LoggingInterceptor implements InterceptorContract {
  @override
  Future<RequestData> interceptRequest({RequestData data}) async {
    print('Request');
    print('Url: ${data.url}');
    print('Headers: ${data.headers}');
    print('Body: ${data.body}');
    return data;
  }

  @override
  Future<ResponseData> interceptResponse({ResponseData data}) async {
    print('Response');
    print('Headers: ${data.headers}');
    print('Body: ${data.body}');
    print('Status code: ${data.statusCode}');
    return data;
  }
}
