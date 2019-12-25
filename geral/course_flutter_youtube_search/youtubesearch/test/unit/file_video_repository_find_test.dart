import 'dart:io';

import 'package:flutter_test/flutter_test.dart';
import 'package:youtubesearch/lib/file_video_repository.dart';
import 'package:youtubesearch/models/video.dart';

void main() {
  group('File video repository find should', () {
    test('return a list of videos with five videos', () async {
      final File file = File('test/fixtures/search_list.json');

      final FileVideoRepository videoRepository = FileVideoRepository(file);

      final List<Video> videos = await videoRepository.find('name');

      expect(5, videos.length);
      expect('4qcf7dcNL7w', videos[0].id);
      expect(
        '&quot;Relaxando&quot; na CCXP! (Esse é o Jovem Nerd 😈)',
        videos[0].title,
      );
    });
  });
}
