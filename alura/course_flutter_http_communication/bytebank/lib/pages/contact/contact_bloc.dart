import 'package:bloc/bloc.dart';
import 'package:bytebank/data/repositories/contact_repository.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/pages/contact/contact_event.dart';
import 'package:bytebank/pages/contact/contact_state.dart';

class ContactBloc extends Bloc<ContactEvent, ContactState> {
  final ContactRepository _contactRepository;

  ContactBloc(this._contactRepository);

  @override
  ContactState get initialState => InitiatedContactState();

  @override
  Stream<ContactState> mapEventToState(ContactEvent event) async* {
    if (event is StoreContactEvent) {
      await _contactRepository.insert(Contact(event.name, event.account));
      yield StoredContactState();
    }
  }
}
