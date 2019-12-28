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
    yield SearchStateLoading();

    if (event is SearchEventFind) {
      if (event.name.isEmpty) {
        yield SearchStateInitial();
      }

      if (event.name.isNotEmpty) {
        List<Video> videos = await _videoRepository.find(event.name);
        yield SearchStateSuccess(videos);
      }
    }
  }
}
