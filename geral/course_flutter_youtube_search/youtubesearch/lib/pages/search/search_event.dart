import 'package:equatable/equatable.dart';

abstract class SearchEvent extends Equatable {}

class SearchEventFind extends SearchEvent {
  final String name;

  SearchEventFind(this.name);

  @override
  List<Object> get props => [name];
}
