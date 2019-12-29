import 'package:equatable/equatable.dart';
import 'package:youtubesearch/models/video.dart';

abstract class SearchState extends Equatable {}

class SearchStateInitial extends SearchState {
  final List<Video> data = [];

  @override
  List<Object> get props => [data];
}

class SearchStateLoading extends SearchState {
  @override
  List<Object> get props => [];
}

class SearchStateSuccess extends SearchState {
  final String title;
  final List<Video> data;

  SearchStateSuccess(this.title, this.data);

  @override
  List<Object> get props => [data];
}
