import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:youtubesearch/lib/http_video_repository.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';

class MockClient extends Mock implements http.Client {}

void main() {
  group('Video repository', () {
    group('find should', () {
      test('return a list of videos with five videos', () async {
        final String searchList =
            await File('test/fixtures/search_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              searchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        final List<Video> videos = await videoRepository.find('jovem nerd');

        expect(5, videos.length);
        expect('4qcf7dcNL7w', videos[0].id);
        expect(
          '&quot;Relaxando&quot; na CCXP! (Esse é o Jovem Nerd 😈)',
          videos[0].title,
        );
      });
    });

    group('next should', () {
      test('equal to "CAUQAA"', () async {
        final String searchList =
            await File('test/fixtures/search_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              searchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        await videoRepository.find('jovem nerd');

        final String next = await videoRepository.next();

        expect(next, 'CAUQAA');
      });
    });

    group('previous should', () {
      test('equal to "CAUQAQ"', () async {
        final String searchList =
            await File('test/fixtures/search_list.json').readAsString();
        final String nextSearchList =
            await File('test/fixtures/next_search_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              searchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        await videoRepository.find('jovem nerd');

        final String page = await videoRepository.next();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              nextSearchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        await videoRepository.find('jovem nerd', page: page);

        final String previous = await videoRepository.previous();

        expect(previous, 'CAUQAQ');
      });
    });
  });
}
