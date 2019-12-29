import 'package:bloc/bloc.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';
import 'package:youtubesearch/pages/detail/detail_event.dart';
import 'package:youtubesearch/pages/detail/detail_state.dart';

class DetailBloc extends Bloc<DetailEvent, DetailState> {
  VideoRepository _videoRepository;

  DetailBloc(this._videoRepository);

  @override
  DetailState get initialState => DetailStateInitial();

  @override
  Stream<DetailState> mapEventToState(DetailEvent event) async* {
    if (event is DetailEventFindOne) {
      yield DetailStateLoading();

      final Video video = await _videoRepository.findOne(event.id);

      yield DetailStateSuccess(video);
    }
  }
}
