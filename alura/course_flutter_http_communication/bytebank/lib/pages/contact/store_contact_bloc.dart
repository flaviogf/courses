import 'package:bloc/bloc.dart';
import 'package:bytebank/data/repositories/contact_repository.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/pages/contact/store_contact_event.dart';
import 'package:bytebank/pages/contact/store_contact_state.dart';

class StoreContactBloc extends Bloc<StoreContactEvent, StoreContactState> {
  final ContactRepository _contactRepository;

  StoreContactBloc(this._contactRepository);

  @override
  StoreContactState get initialState => StoreContactStateInitiated();

  @override
  Stream<StoreContactState> mapEventToState(StoreContactEvent event) async* {
    await _contactRepository.insert(Contact(event.name, event.account));
    yield StoreContactStateStored();
  }
}
