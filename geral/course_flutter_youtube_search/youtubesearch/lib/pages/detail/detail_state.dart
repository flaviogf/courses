import 'package:equatable/equatable.dart';
import 'package:youtubesearch/models/video.dart';

abstract class DetailState extends Equatable {}

class DetailStateInitial extends DetailState {
  @override
  List<Object> get props => [];
}

class DetailStateLoading extends DetailState {
  @override
  List<Object> get props => [];
}

class DetailStateSuccess extends DetailState {
  final Video data;

  DetailStateSuccess(this.data);

  @override
  List<Object> get props => [data];
}
