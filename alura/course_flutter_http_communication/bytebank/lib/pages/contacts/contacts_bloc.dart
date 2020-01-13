import 'package:bloc/bloc.dart';
import 'package:bytebank/data/repositories/contact_repository.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/pages/contacts/contacts_event.dart';
import 'package:bytebank/pages/contacts/contacts_state.dart';

class ContactsBloc extends Bloc<ContactsEvent, ContactsState> {
  final ContactRepository _contactRepository;

  ContactsBloc(this._contactRepository);

  @override
  ContactsState get initialState => InitiatedContactsState();

  @override
  Stream<ContactsState> mapEventToState(ContactsEvent event) async* {
    final List<Contact> contacts = await _contactRepository.find();
    yield FindedContactsState(contacts);
  }
}
