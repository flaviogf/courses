abstract class SearchEvent {}

class SearchEventFind extends SearchEvent {
  final String name;

  SearchEventFind(this.name);
}
