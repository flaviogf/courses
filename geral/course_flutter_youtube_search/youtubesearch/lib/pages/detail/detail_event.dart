import 'package:equatable/equatable.dart';

abstract class DetailEvent extends Equatable {}

class DetailEventFindOne extends DetailEvent {
  final String id;

  DetailEventFindOne(this.id);

  @override
  List<Object> get props => [id];
}
