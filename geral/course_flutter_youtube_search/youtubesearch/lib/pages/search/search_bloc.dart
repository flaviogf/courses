import 'package:bloc/bloc.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';
import 'package:youtubesearch/pages/search/search_event.dart';

class SearchBloc extends Bloc<SearchEvent, List<Video>> {
  final VideoRepository _videoRepository;

  SearchBloc(this._videoRepository);

  @override
  List<Video> get initialState => List();

  @override
  Stream<List<Video>> mapEventToState(SearchEvent event) async* {
    if (event is SearchEventFind) {
      List<Video> videos = await _videoRepository.find(event.name);
      yield videos;
    }
  }
}
