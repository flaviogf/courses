import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/pages/search/search_bloc.dart';
import 'package:youtubesearch/pages/search/search_event.dart';
import 'package:youtubesearch/pages/search/search_state.dart';

class MockVideoRepository extends Mock implements VideoRepository {}

void main() {
  group('SearchBloc', () {
    SearchBloc _bloc;

    setUp(() {
      VideoRepository videoRepository = MockVideoRepository();

      when(videoRepository.find(any)).thenAnswer((_) => Future.value([]));

      _bloc = SearchBloc(videoRepository);
    });

    test(
      'should the initial state be "SearchStateInitial"',
      () {
        expect(_bloc.initialState, SearchStateInitial());
      },
    );

    test(
      'should return the state "SearchStateLoading" when the event "SearchEventFind" is emitted',
      () async {
        _bloc.add(SearchEventFind('Name of video'));

        expectLater(
          _bloc,
          emitsInOrder([
            SearchStateInitial(),
            SearchStateLoading(),
          ]),
        );
      },
    );

    test(
      'should return the state "SearchStateSuccess" when the event "SearchEventFind" is successfully emitted.',
      () {
        _bloc.add(SearchEventFind('Name of video'));

        expectLater(
          _bloc,
          emitsInOrder([
            SearchStateInitial(),
            SearchStateLoading(),
            SearchStateSuccess([])
          ]),
        );
      },
    );

    test(
        'should return the state "SearchStateInitial" when the event "SearchEventFind" is emitted with the name empty',
        () {
      _bloc.add(SearchEventFind(''));

      expectLater(
        _bloc,
        emitsInOrder([
          SearchStateInitial(),
          SearchStateLoading(),
          SearchStateInitial(),
        ]),
      );
    });
  });
}
