import 'package:sqflite/sqflite.dart' as sqflite;
import 'package:bytebank/models/contact.dart';

class ContactRepository {
  final sqflite.Database _database;

  ContactRepository(this._database);

  Future<Contact> insert(Contact contact) async {
    Map<String, dynamic> values = Map();
    values['name'] = contact.name;
    values['account'] = contact.account;

    final int id = await this._database.insert('contacts', values);

    return Contact(contact.name, contact.account, id: id);
  }

  Future<List<Contact>> find() async {
    final List<Map<String, dynamic>> contacts =
        await this._database.query('contacts');

    return contacts
        .map((it) => Contact(it['name'], it['account'], id: it['id']))
        .toList();
  }
}
