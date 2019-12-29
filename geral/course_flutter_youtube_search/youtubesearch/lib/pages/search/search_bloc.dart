import 'package:bloc/bloc.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';
import 'package:youtubesearch/pages/search/search_event.dart';
import 'package:youtubesearch/pages/search/search_state.dart';

class SearchBloc extends Bloc<SearchEvent, SearchState> {
  final VideoRepository _videoRepository;

  SearchBloc(this._videoRepository);

  @override
  SearchState get initialState => SearchStateInitial();

  @override
  Stream<SearchState> mapEventToState(SearchEvent event) async* {
    if (event is SearchEventFind) {
      yield SearchStateLoading();

      if (event.title.isEmpty) {
        yield SearchStateInitial();
      }

      if (event.title.isNotEmpty) {
        List<Video> videos = await _videoRepository.find(event.title);
        yield SearchStateSuccess(event.title, videos);
      }
    }

    if (event is SearchEventNext) {
      if (state is SearchStateSuccess) {
        final SearchStateSuccess currentState = state as SearchStateSuccess;

        String nextPageToken = await _videoRepository.next();

        List<Video> videos = await _videoRepository.find(
          currentState.title,
          page: nextPageToken,
        );

        yield SearchStateSuccess(
          currentState.title,
          currentState.data + videos,
        );
      }
    }
  }
}
