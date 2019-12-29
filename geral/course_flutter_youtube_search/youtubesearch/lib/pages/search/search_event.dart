import 'package:equatable/equatable.dart';

abstract class SearchEvent extends Equatable {}

class SearchEventFind extends SearchEvent {
  final String title;

  SearchEventFind(this.title);

  @override
  List<Object> get props => [title];
}

class SearchEventNext extends SearchEvent {
  @override
  List<Object> get props => [];
}
