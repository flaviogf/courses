import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/pages/detail/detail_bloc.dart';
import 'package:youtubesearch/pages/detail/detail_event.dart';
import 'package:youtubesearch/pages/detail/detail_state.dart';

class MockVideoRepository extends Mock implements VideoRepository {}

void main() {
  group('DetailBloc', () {
    DetailBloc _bloc;

    setUp(() {
      MockVideoRepository videoRepository = MockVideoRepository();

      when(videoRepository.findOne(any)).thenAnswer((_) => Future.value(null));

      _bloc = DetailBloc(videoRepository);
    });

    test(
      'should the initial state be "DetailStateInitial"',
      () {
        expect(_bloc.initialState, DetailStateInitial());
      },
    );

    test(
      'should return the state "DetailStateLoading" when the event "DetailEventFindOne" is emitted',
      () {
        _bloc.add(DetailEventFindOne('video id'));

        expectLater(
          _bloc,
          emitsInOrder([
            DetailStateInitial(),
            DetailStateLoading(),
          ]),
        );
      },
    );

    test(
      'should return the state "DetailStateSuccess" when the event "DetailEventFindOne" is emitted successfully',
      () {
        _bloc.add(DetailEventFindOne('video id'));

        expectLater(
          _bloc,
          emitsInOrder([
            DetailStateInitial(),
            DetailStateLoading(),
            DetailStateSuccess(null),
          ]),
        );
      },
    );
  });
}
